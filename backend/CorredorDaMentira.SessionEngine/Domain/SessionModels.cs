#nullable enable

namespace CorredorDaMentira.SessionEngine.Domain;

/// <summary>
/// Estados lineares obrigatórios validados exclusivamente no servidor:
/// [SelectingMode] -> [InTutorial] -> [AnsweringQuestions] -> [RewardUnlocked] -> [InRewardArea].
/// </summary>
public enum PlayerFlowState
{
    SelectingMode = 0,
    InTutorial = 1,
    AnsweringQuestions = 2,
    RewardUnlocked = 3,
    InRewardArea = 4,
}

public enum GameMode
{
    Unselected = 0,
    TimedRanked = 1,
    FreePractice = 2,
}

public enum SubjectCategory
{
    Geografia = 0,
    Historia = 1,
}

public sealed record PlayerSessionSnapshot(
    long PlayerId,
    PlayerFlowState CurrentState,
    GameMode SelectedMode,
    bool IsTutorialCompleted,
    bool IsQuizTimeClosed,
    int CorrectAnswersCount,
    int AttemptNumber,
    DateTimeOffset? AttemptStartedAtUtc,
    DateTimeOffset? AttemptExpiresAtUtc,
    DateTimeOffset? RewardAreaExpiresAtUtc
);

public sealed record StateTransitionResult(
    bool IsAllowed,
    PlayerFlowState ResultingState,
    string FeedbackMessage
);

public sealed record QuestionValidationRequest(
    long PlayerId,
    SubjectCategory Subject,
    int Level,
    int SelectedOptionIndex,
    int CorrectLieOptionIndex
);

public sealed record QuestionValidationResult(
    bool IsAccepted,
    bool IsCorrect,
    int UpdatedScore,
    PlayerFlowState UpdatedState,
    string FeedbackMessage
);

public sealed record QuizAttemptExpirationEvent(
    long PlayerId,
    bool WasAttemptInvalidated,
    int FinalScore,
    DateTimeOffset ExpiredAtUtc,
    string NotificationMessage
);

public sealed record RewardAreaExpirationEvent(
    long PlayerId,
    DateTimeOffset ExpiredAtUtc,
    string NotificationMessage
);
