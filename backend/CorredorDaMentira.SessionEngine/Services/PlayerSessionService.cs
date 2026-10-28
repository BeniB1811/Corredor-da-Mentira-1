#nullable enable

using System.Collections.Concurrent;
using CorredorDaMentira.SessionEngine.Domain;
using CorredorDaMentira.SessionEngine.StateMachine;
using CorredorDaMentira.SessionEngine.Timers;

namespace CorredorDaMentira.SessionEngine.Services;

public interface IPlayerSessionService : IAsyncDisposable
{
    PlayerSessionSnapshot OpenSession(long playerId);

    StateTransitionResult SelectGameMode(
        long playerId,
        GameMode requestedMode,
        Func<QuizAttemptExpirationEvent, CancellationToken, ValueTask>? onQuizAttemptExpiredAsync = null,
        CancellationToken cancellationToken = default);

    QuestionValidationResult SubmitTutorialAnswer(
        long playerId,
        int selectedOptionIndex,
        int correctLieOptionIndex,
        Func<QuizAttemptExpirationEvent, CancellationToken, ValueTask>? onQuizAttemptExpiredAsync = null,
        CancellationToken cancellationToken = default);

    QuestionValidationResult SubmitQuestionAnswer(QuestionValidationRequest request);

    Task<StateTransitionResult> TryEnterRewardAreaAsync(
        long playerId,
        Func<RewardAreaExpirationEvent, CancellationToken, ValueTask> onSessionRewardExpiredAsync,
        CancellationToken cancellationToken = default);

    Task CloseSessionAsync(long playerId);

    PlayerSessionSnapshot? GetSessionSnapshot(long playerId);
}

public sealed class PlayerSessionService : IPlayerSessionService
{
    public const int MaxQuizScore = 20;
    public const int MinimumRewardQualificationScore = 15;
    public static readonly TimeSpan QuizAttemptDuration = TimeSpan.FromSeconds(600);
    public static readonly TimeSpan RewardAreaDuration = TimeSpan.FromSeconds(600);

    private sealed class MutablePlayerSession
    {
        public readonly object SyncRoot = new();
        public long PlayerId { get; init; }
        public PlayerFlowState CurrentState { get; set; } = PlayerFlowState.SelectingMode;
        public GameMode SelectedMode { get; set; } = GameMode.Unselected;
        public bool IsTutorialCompleted { get; set; }
        public bool IsQuizTimeClosed { get; set; }
        public int CorrectAnswersCount { get; set; }
        public int AttemptNumber { get; set; }
        public DateTimeOffset? AttemptStartedAtUtc { get; set; }
        public DateTimeOffset? AttemptExpiresAtUtc { get; set; }
        public DateTimeOffset? RewardAreaExpiresAtUtc { get; set; }

        public PlayerSessionSnapshot ToSnapshot() =>
            new(
                PlayerId,
                CurrentState,
                SelectedMode,
                IsTutorialCompleted,
                IsQuizTimeClosed,
                CorrectAnswersCount,
                AttemptNumber,
                AttemptStartedAtUtc,
                AttemptExpiresAtUtc,
                RewardAreaExpiresAtUtc);
    }

    private readonly IPlayerStateMachine _stateMachine;
    private readonly IQuizAttemptTimerManager _quizTimerManager;
    private readonly IRewardAreaTimerManager _rewardTimerManager;
    private readonly TimeProvider _timeProvider;
    private readonly ConcurrentDictionary<long, MutablePlayerSession> _sessions = new();

    public PlayerSessionService(
        IPlayerStateMachine stateMachine,
        IQuizAttemptTimerManager quizTimerManager,
        IRewardAreaTimerManager rewardTimerManager,
        TimeProvider? timeProvider = null)
    {
        ArgumentNullException.ThrowIfNull(stateMachine);
        ArgumentNullException.ThrowIfNull(quizTimerManager);
        ArgumentNullException.ThrowIfNull(rewardTimerManager);

        _stateMachine = stateMachine;
        _quizTimerManager = quizTimerManager;
        _rewardTimerManager = rewardTimerManager;
        _timeProvider = timeProvider ?? TimeProvider.System;
    }

    public PlayerSessionSnapshot OpenSession(long playerId)
    {
        MutablePlayerSession session = _sessions.GetOrAdd(
            playerId,
            static id => new MutablePlayerSession { PlayerId = id });

        lock (session.SyncRoot)
        {
            return session.ToSnapshot();
        }
    }

    public PlayerSessionSnapshot? GetSessionSnapshot(long playerId)
    {
        if (!_sessions.TryGetValue(playerId, out MutablePlayerSession? session))
        {
            return null;
        }

        lock (session.SyncRoot)
        {
            return session.ToSnapshot();
        }
    }

    public StateTransitionResult SelectGameMode(
        long playerId,
        GameMode requestedMode,
        Func<QuizAttemptExpirationEvent, CancellationToken, ValueTask>? onQuizAttemptExpiredAsync = null,
        CancellationToken cancellationToken = default)
    {
        if (requestedMode is GameMode.Unselected)
        {
            return new StateTransitionResult(false, PlayerFlowState.SelectingMode, "Modo de jogo inválido.");
        }

        MutablePlayerSession session = _sessions.GetOrAdd(
            playerId,
            static id => new MutablePlayerSession { PlayerId = id });

        lock (session.SyncRoot)
        {
            session.SelectedMode = requestedMode;

            if (!session.IsTutorialCompleted)
            {
                StateTransitionResult decision = _stateMachine.EvaluateTransition(
                    session.ToSnapshot(),
                    PlayerFlowState.InTutorial,
                    MinimumRewardQualificationScore);

                if (decision.IsAllowed)
                {
                    session.CurrentState = decision.ResultingState;
                }

                return decision;
            }

            if (requestedMode is GameMode.TimedRanked)
            {
                StartTimedQuizAttemptInternal(session, incrementAttempt: true, onQuizAttemptExpiredAsync, cancellationToken);
            }
            else
            {
                _ = _quizTimerManager.CancelAttemptTimerAsync(playerId);
                session.AttemptStartedAtUtc = null;
                session.AttemptExpiresAtUtc = null;
            }

            return new StateTransitionResult(true, session.CurrentState, "Modo de jogo atualizado.");
        }
    }

    public QuestionValidationResult SubmitTutorialAnswer(
        long playerId,
        int selectedOptionIndex,
        int correctLieOptionIndex,
        Func<QuizAttemptExpirationEvent, CancellationToken, ValueTask>? onQuizAttemptExpiredAsync = null,
        CancellationToken cancellationToken = default)
    {
        if (!_sessions.TryGetValue(playerId, out MutablePlayerSession? session))
        {
            return new QuestionValidationResult(
                false,
                false,
                0,
                PlayerFlowState.SelectingMode,
                "Sessão não encontrada.");
        }

        lock (session.SyncRoot)
        {
            if (session.SelectedMode is GameMode.Unselected || session.CurrentState is PlayerFlowState.SelectingMode)
            {
                return new QuestionValidationResult(
                    false,
                    false,
                    session.CorrectAnswersCount,
                    session.CurrentState,
                    "Selecione um modo de jogo antes de iniciar o tutorial.");
            }

            if (session.IsTutorialCompleted)
            {
                return new QuestionValidationResult(
                    false,
                    false,
                    session.CorrectAnswersCount,
                    session.CurrentState,
                    "O tutorial obrigatório já foi concluído.");
            }

            session.IsTutorialCompleted = true;
            session.AttemptNumber = 1;
            session.CorrectAnswersCount = 0;
            session.IsQuizTimeClosed = false;

            StateTransitionResult transition = _stateMachine.EvaluateTransition(
                session.ToSnapshot(),
                PlayerFlowState.AnsweringQuestions,
                MinimumRewardQualificationScore);

            if (transition.IsAllowed)
            {
                session.CurrentState = transition.ResultingState;
            }

            if (session.SelectedMode is GameMode.TimedRanked)
            {
                StartTimedQuizAttemptInternal(session, incrementAttempt: false, onQuizAttemptExpiredAsync, cancellationToken);
            }

            bool isCorrect = selectedOptionIndex == correctLieOptionIndex;
            return new QuestionValidationResult(
                true,
                isCorrect,
                session.CorrectAnswersCount,
                session.CurrentState,
                "Tutorial concluído. Escolha Geografia ou História no saguão principal.");
        }
    }

    public QuestionValidationResult SubmitQuestionAnswer(QuestionValidationRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (!_sessions.TryGetValue(request.PlayerId, out MutablePlayerSession? session))
        {
            return new QuestionValidationResult(
                false,
                false,
                0,
                PlayerFlowState.SelectingMode,
                "Sessão não inicializada.");
        }

        lock (session.SyncRoot)
        {
            PlayerSessionSnapshot snapshot = session.ToSnapshot();
            if (!_stateMachine.CanPassTutorialBarrier(snapshot))
            {
                return new QuestionValidationResult(
                    false,
                    false,
                    session.CorrectAnswersCount,
                    session.CurrentState,
                    "Complete o tutorial antes de prosseguir.");
            }

            if (session.CurrentState is PlayerFlowState.InRewardArea)
            {
                return new QuestionValidationResult(
                    false,
                    false,
                    session.CorrectAnswersCount,
                    session.CurrentState,
                    "Retorne ao saguão principal para responder questões.");
            }

            bool hasQuizDeadlineExpired = session.SelectedMode is GameMode.TimedRanked
                && session.AttemptExpiresAtUtc is { } deadline
                && _timeProvider.GetUtcNow() >= deadline;

            if (session.IsQuizTimeClosed || hasQuizDeadlineExpired)
            {
                return new QuestionValidationResult(
                    false,
                    false,
                    session.CorrectAnswersCount,
                    session.CurrentState,
                    "O tempo de 10 minutos para responder questões foi encerrado.");
            }

            bool isCorrect = request.SelectedOptionIndex == request.CorrectLieOptionIndex;
            if (isCorrect)
            {
                session.CorrectAnswersCount = Math.Min(MaxQuizScore, session.CorrectAnswersCount + 1);
            }

            if (session.CorrectAnswersCount >= MinimumRewardQualificationScore
                && session.CurrentState is PlayerFlowState.AnsweringQuestions)
            {
                StateTransitionResult unlockTransition = _stateMachine.EvaluateTransition(
                    session.ToSnapshot(),
                    PlayerFlowState.RewardUnlocked,
                    MinimumRewardQualificationScore);

                if (unlockTransition.IsAllowed)
                {
                    session.CurrentState = unlockTransition.ResultingState;
                }
            }

            return new QuestionValidationResult(
                true,
                isCorrect,
                session.CorrectAnswersCount,
                session.CurrentState,
                isCorrect ? "Resposta correta." : "Resposta incorreta.");
        }
    }

    public async Task<StateTransitionResult> TryEnterRewardAreaAsync(
        long playerId,
        Func<RewardAreaExpirationEvent, CancellationToken, ValueTask> onSessionRewardExpiredAsync,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(onSessionRewardExpiredAsync);

        if (!_sessions.TryGetValue(playerId, out MutablePlayerSession? session))
        {
            return new StateTransitionResult(false, PlayerFlowState.SelectingMode, "Sessão não encontrada.");
        }

        lock (session.SyncRoot)
        {
            PlayerSessionSnapshot snapshot = session.ToSnapshot();
            if (!_stateMachine.CanEnterRewardArea(snapshot, MinimumRewardQualificationScore))
            {
                return _stateMachine.EvaluateTransition(
                    snapshot,
                    PlayerFlowState.InRewardArea,
                    MinimumRewardQualificationScore);
            }

            session.CurrentState = PlayerFlowState.InRewardArea;
        }

        // Encerra o cronômetro de questões ao ingressar na Área de Recompensas e inicia os 600s de recompensas
        await _quizTimerManager.CancelAttemptTimerAsync(playerId).ConfigureAwait(false);

        DateTimeOffset expiresAtUtc = _rewardTimerManager.StartOrGetCountdown(
            playerId,
            RewardAreaDuration,
            async (expirationEvent, token) =>
            {
                RevokeRewardAccessAndResetToLobby(expirationEvent.PlayerId, onQuizAttemptExpiredAsync: null, token);
                await onSessionRewardExpiredAsync(expirationEvent, token).ConfigureAwait(false);
            },
            cancellationToken);

        lock (session.SyncRoot)
        {
            session.RewardAreaExpiresAtUtc = expiresAtUtc;
            return new StateTransitionResult(
                true,
                session.CurrentState,
                "Entrada na Área de Recompensas confirmada pelo servidor (limite estrito de 10 minutos).");
        }
    }

    private void StartTimedQuizAttemptInternal(
        MutablePlayerSession session,
        bool incrementAttempt,
        Func<QuizAttemptExpirationEvent, CancellationToken, ValueTask>? onQuizAttemptExpiredAsync,
        CancellationToken cancellationToken)
    {
        if (incrementAttempt || session.AttemptNumber <= 0)
        {
            session.AttemptNumber = Math.Max(1, session.AttemptNumber + (incrementAttempt ? 1 : 0));
        }

        session.CorrectAnswersCount = 0;
        session.IsQuizTimeClosed = false;
        session.RewardAreaExpiresAtUtc = null;
        session.CurrentState = PlayerFlowState.AnsweringQuestions;

        DateTimeOffset nowUtc = _timeProvider.GetUtcNow();
        session.AttemptStartedAtUtc = nowUtc;
        session.AttemptExpiresAtUtc = _quizTimerManager.StartNewAttemptCountdown(
            session.PlayerId,
            QuizAttemptDuration,
            async (expiredPlayerId, token) =>
            {
                QuizAttemptExpirationEvent? notice = HandleQuizAttemptTimeout(
                    expiredPlayerId,
                    onQuizAttemptExpiredAsync,
                    token);

                if (notice is not null && onQuizAttemptExpiredAsync is not null)
                {
                    await onQuizAttemptExpiredAsync(notice, token).ConfigureAwait(false);
                }
            },
            cancellationToken);
    }

    private QuizAttemptExpirationEvent? HandleQuizAttemptTimeout(
        long playerId,
        Func<QuizAttemptExpirationEvent, CancellationToken, ValueTask>? onQuizAttemptExpiredAsync,
        CancellationToken cancellationToken)
    {
        if (!_sessions.TryGetValue(playerId, out MutablePlayerSession? session))
        {
            return null;
        }

        lock (session.SyncRoot)
        {
            int finalScore = session.CorrectAnswersCount;
            DateTimeOffset expiredAt = _timeProvider.GetUtcNow();

            if (finalScore < MinimumRewardQualificationScore)
            {
                // Não atingiu as 15 questões em 10 minutos: invalida tentativa e inicia nova no Lobby
                StartTimedQuizAttemptInternal(session, incrementAttempt: true, onQuizAttemptExpiredAsync, cancellationToken);
                return new QuizAttemptExpirationEvent(
                    playerId,
                    WasAttemptInvalidated: true,
                    finalScore,
                    expiredAt,
                    $"Tempo de 10 minutos esgotado com {finalScore}/{MaxQuizScore} acertos. Tentativa invalidada.");
            }

            session.IsQuizTimeClosed = true;
            session.AttemptExpiresAtUtc = null;
            return new QuizAttemptExpirationEvent(
                playerId,
                WasAttemptInvalidated: false,
                finalScore,
                expiredAt,
                $"Tempo das questões encerrado ({finalScore}/{MaxQuizScore} acertos). Acesso à Área de Recompensas mantido.");
        }
    }

    private void RevokeRewardAccessAndResetToLobby(
        long playerId,
        Func<QuizAttemptExpirationEvent, CancellationToken, ValueTask>? onQuizAttemptExpiredAsync,
        CancellationToken cancellationToken)
    {
        if (!_sessions.TryGetValue(playerId, out MutablePlayerSession? session))
        {
            return;
        }

        lock (session.SyncRoot)
        {
            session.RewardAreaExpiresAtUtc = null;
            session.CorrectAnswersCount = 0;
            session.IsQuizTimeClosed = false;
            session.CurrentState = session.IsTutorialCompleted
                ? PlayerFlowState.AnsweringQuestions
                : PlayerFlowState.InTutorial;

            if (session.IsTutorialCompleted && session.SelectedMode is GameMode.TimedRanked)
            {
                StartTimedQuizAttemptInternal(session, incrementAttempt: true, onQuizAttemptExpiredAsync, cancellationToken);
            }
            else
            {
                session.AttemptNumber += 1;
                session.AttemptStartedAtUtc = null;
                session.AttemptExpiresAtUtc = null;
            }
        }
    }

    public async Task CloseSessionAsync(long playerId)
    {
        await _quizTimerManager.CancelAttemptTimerAsync(playerId).ConfigureAwait(false);
        await _rewardTimerManager.CancelTimerAsync(playerId).ConfigureAwait(false);
        _sessions.TryRemove(playerId, out _);
    }

    public async ValueTask DisposeAsync()
    {
        await _quizTimerManager.DisposeAsync().ConfigureAwait(false);
        await _rewardTimerManager.DisposeAsync().ConfigureAwait(false);
        _sessions.Clear();
    }
}
