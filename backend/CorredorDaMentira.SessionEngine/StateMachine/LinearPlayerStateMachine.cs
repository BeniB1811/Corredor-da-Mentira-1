#nullable enable

using CorredorDaMentira.SessionEngine.Domain;

namespace CorredorDaMentira.SessionEngine.StateMachine;

public interface IPlayerStateMachine
{
    StateTransitionResult EvaluateTransition(
        PlayerSessionSnapshot currentSnapshot,
        PlayerFlowState requestedState,
        int minimumRewardScore);

    bool CanPassTutorialBarrier(PlayerSessionSnapshot snapshot);

    bool CanEnterRewardArea(PlayerSessionSnapshot snapshot, int minimumRewardScore);
}

public sealed class LinearPlayerStateMachine : IPlayerStateMachine
{
    public StateTransitionResult EvaluateTransition(
        PlayerSessionSnapshot currentSnapshot,
        PlayerFlowState requestedState,
        int minimumRewardScore)
    {
        ArgumentNullException.ThrowIfNull(currentSnapshot);

        return (currentSnapshot.CurrentState, requestedState) switch
        {
            (_, PlayerFlowState.SelectingMode) when !currentSnapshot.IsTutorialCompleted =>
                new StateTransitionResult(true, PlayerFlowState.SelectingMode, "Aguardando seleção de modo."),

            (PlayerFlowState.SelectingMode, PlayerFlowState.InTutorial)
                when currentSnapshot.SelectedMode is GameMode.TimedRanked or GameMode.FreePractice =>
                new StateTransitionResult(true, PlayerFlowState.InTutorial, "Modo confirmado. Tutorial liberado."),

            (_, PlayerFlowState.InTutorial) when currentSnapshot.SelectedMode is GameMode.Unselected =>
                new StateTransitionResult(
                    false,
                    currentSnapshot.CurrentState,
                    "Selecione um modo de jogo antes de iniciar o tutorial."),

            (PlayerFlowState.InTutorial, PlayerFlowState.AnsweringQuestions)
                when currentSnapshot.IsTutorialCompleted && currentSnapshot.SelectedMode is not GameMode.Unselected =>
                new StateTransitionResult(
                    true,
                    PlayerFlowState.AnsweringQuestions,
                    "Tutorial concluído. Percurso de questões liberado."),

            (_, PlayerFlowState.AnsweringQuestions) when !currentSnapshot.IsTutorialCompleted =>
                new StateTransitionResult(
                    false,
                    currentSnapshot.CurrentState,
                    "Complete o tutorial antes de prosseguir."),

            (PlayerFlowState.RewardUnlocked or PlayerFlowState.InRewardArea, PlayerFlowState.AnsweringQuestions)
                when currentSnapshot.IsTutorialCompleted =>
                new StateTransitionResult(
                    true,
                    PlayerFlowState.AnsweringQuestions,
                    "Nova tentativa iniciada no saguão principal."),

            (PlayerFlowState.AnsweringQuestions, PlayerFlowState.RewardUnlocked)
                when currentSnapshot.IsTutorialCompleted && currentSnapshot.CorrectAnswersCount >= minimumRewardScore =>
                new StateTransitionResult(
                    true,
                    PlayerFlowState.RewardUnlocked,
                    "Pontuação mínima atingida. Área de Recompensas liberada."),

            (PlayerFlowState.RewardUnlocked, PlayerFlowState.InRewardArea)
                when currentSnapshot.IsTutorialCompleted && currentSnapshot.CorrectAnswersCount >= minimumRewardScore =>
                new StateTransitionResult(
                    true,
                    PlayerFlowState.InRewardArea,
                    "Acesso autorizado à Área de Recompensas."),

            (PlayerFlowState.InRewardArea, PlayerFlowState.RewardUnlocked)
                when currentSnapshot.IsTutorialCompleted && currentSnapshot.CorrectAnswersCount >= minimumRewardScore =>
                new StateTransitionResult(
                    true,
                    PlayerFlowState.RewardUnlocked,
                    "Retorno ao saguão principal mantendo janela ativa de recompensas."),

            (_, PlayerFlowState.RewardUnlocked or PlayerFlowState.InRewardArea)
                when !currentSnapshot.IsTutorialCompleted =>
                new StateTransitionResult(
                    false,
                    currentSnapshot.CurrentState,
                    "Complete o tutorial antes de prosseguir."),

            (_, PlayerFlowState.RewardUnlocked or PlayerFlowState.InRewardArea) =>
                new StateTransitionResult(
                    false,
                    currentSnapshot.CurrentState,
                    $"Alcance {minimumRewardScore} acertos para liberar a Área de Recompensas."),

            var (current, target) when current == target =>
                new StateTransitionResult(true, current, "Estado mantido."),

            _ => new StateTransitionResult(
                false,
                currentSnapshot.CurrentState,
                "Transição de estado rejeitada pela validação linear do servidor."),
        };
    }

    public bool CanPassTutorialBarrier(PlayerSessionSnapshot snapshot) =>
        snapshot is
        {
            SelectedMode: GameMode.TimedRanked or GameMode.FreePractice,
            IsTutorialCompleted: true,
            CurrentState: PlayerFlowState.AnsweringQuestions
                or PlayerFlowState.RewardUnlocked
                or PlayerFlowState.InRewardArea
        };

    public bool CanEnterRewardArea(PlayerSessionSnapshot snapshot, int minimumRewardScore) =>
        CanPassTutorialBarrier(snapshot)
        && snapshot.CorrectAnswersCount >= minimumRewardScore
        && snapshot.CurrentState is PlayerFlowState.RewardUnlocked or PlayerFlowState.InRewardArea;
}
