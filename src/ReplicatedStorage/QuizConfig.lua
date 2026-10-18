--!strict
-- Configuração compartilhada. O banco de questões fica em ServerStorage para manter o gabarito privado.
local QuizConfig = {
	DURACAO_RODADA_SEGUNDOS = 300,
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
}

return table.freeze(QuizConfig)
