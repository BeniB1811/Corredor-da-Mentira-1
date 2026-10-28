#nullable enable

using System.Collections.Concurrent;

namespace CorredorDaMentira.SessionEngine.Timers;

public interface IQuizAttemptTimerManager : IAsyncDisposable
{
    DateTimeOffset StartNewAttemptCountdown(
        long playerId,
        TimeSpan duration,
        Func<long, CancellationToken, ValueTask> onAttemptExpiredAsync,
        CancellationToken externalCancellationToken = default);

    TimeSpan? GetRemainingTime(long playerId);

    Task CancelAttemptTimerAsync(long playerId);
}

public sealed class QuizAttemptTimerManager : IQuizAttemptTimerManager
{
    private sealed class ActiveAttemptTimer : IAsyncDisposable
    {
        public ActiveAttemptTimer(
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
                // Cancelamento esperado ao reiniciar tentativa, concluir 20 questões ou desconectar.
            }
            finally
            {
                CancellationSource.Dispose();
            }
        }
    }

    private readonly TimeProvider _timeProvider;
    private readonly ConcurrentDictionary<long, ActiveAttemptTimer> _activeTimers = new();
    private int _isDisposed;

    public QuizAttemptTimerManager(TimeProvider? timeProvider = null)
    {
        _timeProvider = timeProvider ?? TimeProvider.System;
    }

    public DateTimeOffset StartNewAttemptCountdown(
        long playerId,
        TimeSpan duration,
        Func<long, CancellationToken, ValueTask> onAttemptExpiredAsync,
        CancellationToken externalCancellationToken = default)
    {
        ObjectDisposedException.ThrowIf(Volatile.Read(ref _isDisposed) == 1, this);
        ArgumentNullException.ThrowIfNull(onAttemptExpiredAsync);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(duration, TimeSpan.Zero);

        if (_activeTimers.TryRemove(playerId, out ActiveAttemptTimer? previousTimer))
        {
            _ = previousTimer.DisposeAsync();
        }

        DateTimeOffset expiresAtUtc = _timeProvider.GetUtcNow().Add(duration);
        CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(externalCancellationToken);

        Task monitorTask = RunCountdownLoopAsync(playerId, expiresAtUtc, onAttemptExpiredAsync, linkedCts.Token);
        var createdTimer = new ActiveAttemptTimer(expiresAtUtc, linkedCts, monitorTask);
        _activeTimers[playerId] = createdTimer;

        return expiresAtUtc;
    }

    public TimeSpan? GetRemainingTime(long playerId)
    {
        if (!_activeTimers.TryGetValue(playerId, out ActiveAttemptTimer? activeTimer))
        {
            return null;
        }

        TimeSpan remaining = activeTimer.ExpiresAtUtc - _timeProvider.GetUtcNow();
        return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
    }

    public async Task CancelAttemptTimerAsync(long playerId)
    {
        if (_activeTimers.TryRemove(playerId, out ActiveAttemptTimer? removedTimer))
        {
            await removedTimer.DisposeAsync().ConfigureAwait(false);
        }
    }

    private async Task RunCountdownLoopAsync(
        long playerId,
        DateTimeOffset expiresAtUtc,
        Func<long, CancellationToken, ValueTask> onAttemptExpiredAsync,
        CancellationToken cancellationToken)
    {
        using var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(1), _timeProvider);

        while (!cancellationToken.IsCancellationRequested)
        {
            if (_timeProvider.GetUtcNow() >= expiresAtUtc)
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

        if (_activeTimers.TryRemove(playerId, out ActiveAttemptTimer? completedTimer))
        {
            completedTimer.CancellationSource.Dispose();
        }

        await onAttemptExpiredAsync(playerId, cancellationToken).ConfigureAwait(false);
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
            await CancelAttemptTimerAsync(playerId).ConfigureAwait(false);
        }
    }
}
