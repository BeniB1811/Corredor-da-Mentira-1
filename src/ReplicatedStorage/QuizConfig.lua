--!strict
-- Configuração compartilhada e contratos de constantes entre servidor e cliente.
-- O banco de questões permanece em ServerStorage para preservar o gabarito exclusivamente no servidor.

export type PlayerState =
	"SelectingMode"
	| "InTutorial"
	| "AnsweringQuestions"
	| "RewardUnlocked"
	| "InRewardArea"

export type SubjectName = "Geografia" | "História"

local PLAYER_STATES = table.freeze({
	SELECTING_MODE = "SelectingMode" :: PlayerState,
	IN_TUTORIAL = "InTutorial" :: PlayerState,
	ANSWERING_QUESTIONS = "AnsweringQuestions" :: PlayerState,
	REWARD_UNLOCKED = "RewardUnlocked" :: PlayerState,
	IN_REWARD_AREA = "InRewardArea" :: PlayerState,
})

local QuizConfig = {
	-- Constantes semânticas principais (SCREAMING_SNAKE_CASE)
	ROUND_DURATION_SECONDS = 600,
	REWARD_AREA_DURATION_SECONDS = 600,
	RESULT_DISPLAY_SECONDS = 1.5,
	NOTIFICATION_COOLDOWN_SECONDS = 1.2,
	RESET_COOLDOWN_SECONDS = 2.0,
	MAX_SCORE = 20,
	REWARD_MIN_SCORE = 15,
	MAX_GEOGRAPHY_LEVEL = 10,
	MAX_HISTORY_LEVEL = 10,
	REWARD_APPROACH_DISTANCE_STUDS = 10,

	TAB_STAT_NAME = "Acertos",
	REWARD_GATE_NAME = "PortaoRecompensas",
	REWARD_GATE_ATTRIBUTE = "IsRewardGate",
	LEADERBOARD_BOARD_NAME = "LeaderboardParede",
	REMOTES_FOLDER_NAME = "QuizRemotes",
	QUESTION_BANK_NAME = "QuizBancoQuestoes",
	RESET_BUTTON_NAME = "Botão de resetar pontos",
	MODE_REMOTE_NAME = "DefinirModoJogo",
	LEADERBOARD_MESSAGING_TOPIC = "QuizLeaderboardGlobalUpdate",

	PLAYER_STATES = PLAYER_STATES,

	-- Aliases de compatibilidade com módulos existentes
	DURACAO_RODADA_SEGUNDOS = 600,
	DURACAO_AREA_RECOMPENSAS_SEGUNDOS = 600,
	INTERVALO_ENTRE_RODADAS_SEGUNDOS = 5,
	TEMPO_PREPARACAO_RODADA_SEGUNDOS = 2,
	TEMPO_EXIBICAO_RESULTADO = 1.5,
	MAX_ACERTOS = 20,
	ACERTOS_MINIMOS_PORTAO_RECOMPENSAS = 15,
	NOME_ESTATISTICA_TAB = "Acertos",
	NIVEL_FINAL_GEOGRAFIA = 10,
	NIVEL_FINAL_HISTORIA = 10,
	NOME_PORTAO_RECOMPENSAS = "PortaoRecompensas",
	NOME_QUADRO_LEADERBOARD = "LeaderboardParede",
	NOME_PASTA_REMOTES = "QuizRemotes",
	NOME_BANCO_QUESTOES = "QuizBancoQuestoes",
	NOME_ATRIBUTO_PORTAO_RECOMPENSAS = "IsRewardGate",
	NOME_BOTAO_RESET = "Botão de resetar pontos",
	NOME_REMOTE_MODO = "DefinirModoJogo",
	TOPICO_MESSAGING_RANKING = "QuizLeaderboardGlobalUpdate",
}

return table.freeze(QuizConfig)
