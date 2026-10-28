#nullable enable

using System.Collections.Concurrent;
using CorredorDaMentira.SessionEngine.Domain;

namespace CorredorDaMentira.SessionEngine.Timers;

public interface IRewardAreaTimerManager : IAsyncDisposable
{
    DateTimeOffset StartOrGetCountdown(
        long playerId,
        TimeSpan duration,
        Func<RewardAreaExpirationEvent, CancellationToken, ValueTask> onExpiredAsync,
        CancellationToken externalCancellationToken = default);

    TimeSpan? GetRemainingTime(long playerId);

    Task CancelTimerAsync(long playerId);
}

public sealed class RewardAreaTimerManager : IRewardAreaTimerManager
{
    private sealed class ActiveRewardTimer : IAsyncDisposable
    {
        public ActiveRewardTimer(
            DateTimeOffset expiresAtUtc,
            CancellationTokenSource cancellationSource,
            Task executionTask)
        {
            ExpiresAtUtc = expiresAtUtc;
            CancellationSource = cancellationSource;
            ExecutionTask = executionTask;
        }

        public DateTimeOffset ExpiresAtUtc { get; }
        public CancellationTokenSource CancellationSource { get; }
        public Task ExecutionTask { get; }

        public async ValueTask DisposeAsync()
        {
            await CancellationSource.CancelAsync().ConfigureAwait(false);
            try
            {
                await ExecutionTask.ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Cancelamento esperado ao revogar sessão ou desconectar jogador.
            }
            finally
            {
                CancellationSource.Dispose();
            }
        }
    }

    private readonly TimeProvider _timeProvider;
    private readonly ConcurrentDictionary<long, ActiveRewardTimer> _activeTimers = new();
    private int _isDisposed;

    public RewardAreaTimerManager(TimeProvider? timeProvider = null)
    {
        _timeProvider = timeProvider ?? TimeProvider.System;
    }

    public DateTimeOffset StartOrGetCountdown(
        long playerId,
        TimeSpan duration,
        Func<RewardAreaExpirationEvent, CancellationToken, ValueTask> onExpiredAsync,
        CancellationToken externalCancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(Volatile.Read(ref _isDisposed) == 1, this);
        ArgumentNullException.ThrowIfNull(onExpiredAsync);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(duration, TimeSpan.Zero);

        if (_activeTimers.TryGetValue(playerId, out ActiveRewardTimer? existingTimer))
        {
            return existingTimer.ExpiresAtUtc;
        }

        DateTimeOffset expiresAtUtc = _timeProvider.GetUtcNow().Add(duration);
        CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(externalCancellationToken);

        Task monitorTask = RunCountdownLoopAsync(playerId, expiresAtUtc, onExpiredAsync, linkedCts.Token);
        var createdTimer = new ActiveRewardTimer(expiresAtUtc, linkedCts, monitorTask);

        if (_activeTimers.TryAdd(playerId, createdTimer))
        {
            return expiresAtUtc;
        }

        linkedCts.Cancel();
        linkedCts.Dispose();
        return _activeTimers.TryGetValue(playerId, out ActiveRewardTimer? winner)
            ? winner.ExpiresAtUtc
            : expiresAtUtc;
    }

    public TimeSpan? GetRemainingTime(long playerId)
    {
        if (!_activeTimers.TryGetValue(playerId, out ActiveRewardTimer? activeTimer))
        {
            return null;
        }

        TimeSpan remaining = activeTimer.ExpiresAtUtc - _timeProvider.GetUtcNow();
        return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
    }

    public async Task CancelTimerAsync(long playerId)
    {
        if (_activeTimers.TryRemove(playerId, out ActiveRewardTimer? removedTimer))
        {
            await removedTimer.DisposeAsync().ConfigureAwait(false);
        }
    }

    private async Task RunCountdownLoopAsync(
        long playerId,
        DateTimeOffset expiresAtUtc,
        Func<RewardAreaExpirationEvent, CancellationToken, ValueTask> onExpiredAsync,
        CancellationToken cancellationToken)
    {
        using var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(1), _timeProvider);

        while (!cancellationToken.IsCancellationRequested)
        {
            DateTimeOffset nowUtc = _timeProvider.GetUtcNow();
            if (nowUtc >= expiresAtUtc)
            {
                break;
            }

            bool hasNextTick = await periodicTimer.WaitForNextTickAsync(cancellationToken).ConfigureAwait(false);
            if (!hasNextTick)
            {
                return;
            }
        }

        cancellationToken.ThrowIfCancellationRequested();

        if (_activeTimers.TryRemove(playerId, out ActiveRewardTimer? completedTimer))
        {
            completedTimer.CancellationSource.Dispose();
        }

        var expirationEvent = new RewardAreaExpirationEvent(
            playerId,
            _timeProvider.GetUtcNow(),
            "Seu tempo na Área de Recompensas terminou.");

        await onExpiredAsync(expirationEvent, cancellationToken).ConfigureAwait(false);
    }

    public async ValueTask DisposeAsync()
    {
        if (Interlocked.Exchange(ref _isDisposed, 1) == 1)
        {
            return;
        }

        long[] playerIds = _activeTimers.Keys.ToArray();
        foreach (long playerId in playerIds)
        {
            await CancelTimerAsync(playerId).ConfigureAwait(false);
        }
    }
}
