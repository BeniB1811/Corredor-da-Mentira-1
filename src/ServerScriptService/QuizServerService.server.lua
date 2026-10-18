--!strict
-- Estado da tentativa, validação de respostas, rodada, reset e portão ficam no servidor.
local Players = game:GetService("Players")
local ReplicatedStorage = game:GetService("ReplicatedStorage")
local ServerStorage = game:GetService("ServerStorage")
local TweenService = game:GetService("TweenService")
local Workspace = game:GetService("Workspace")

local QuizConfig = require(ReplicatedStorage:WaitForChild("QuizConfig"))
local QuizBanco = require(ServerStorage:WaitForChild(QuizConfig.NOME_BANCO_QUESTOES))

type Progresso = {
	Materia: string,
	Nivel: number,
}

type SessaoQuiz = {
	Materia: string,
	Nivel: number,
	NomePorta: string,
	NomeQuestao: string,
	Alternativas: { string },
	IndiceCorreto: number,
	Tutorial: boolean,
	Respondido: boolean,
}

type AlternativaPreparada = {
	Texto: string,
	Falsa: boolean,
}

local pastaRemotes = ReplicatedStorage:FindFirstChild(QuizConfig.NOME_PASTA_REMOTES)
if not pastaRemotes then
	pastaRemotes = Instance.new("Folder")
	pastaRemotes.Name = QuizConfig.NOME_PASTA_REMOTES
	pastaRemotes.Parent = ReplicatedStorage
end

local function remote(nome: string, classe: string): Instance
	local atual = pastaRemotes:FindFirstChild(nome)
	if atual and atual.ClassName ~= classe then
		atual:Destroy()
		atual = nil
	end
	if not atual then
		atual = Instance.new(classe)
		atual.Name = nome
		atual.Parent = pastaRemotes
	end
	return atual
end

local AbrirQuiz = remote("AbrirQuiz", "RemoteEvent") :: RemoteEvent
local EnviarResposta = remote("EnviarResposta", "RemoteFunction") :: RemoteFunction
local SincronizarRodada = remote("SincronizarRodada", "RemoteEvent") :: RemoteEvent
local FimDeRodada = remote("FimDeRodada", "RemoteEvent") :: RemoteEvent
local ControlarPorta = remote("ControlarPorta", "RemoteEvent") :: RemoteEvent
local ResetarClient = remote("ResetarClient", "RemoteEvent") :: RemoteEvent
local NotificarMensagem = remote("NotificarMensagem", "RemoteEvent") :: RemoteEvent
local SolicitarReset = remote("SolicitarReset", "RemoteEvent") :: RemoteEvent
local ObterEstadoRodada = remote("ObterEstadoRodada", "RemoteFunction") :: RemoteFunction

local FASE_TUTORIAL = "Tutorial"
local FASE_PREPARACAO = "Preparando"
local FASE_ATIVA = "Ativa"
local FASE_INTERVALO = "Intervalo"
local DURACAO_AVISO = 1.2

local fase = FASE_TUTORIAL
local numeroRodada = 0
local inicioRodadaTimestamp = 0
local fimRodadaTimestamp = 0
-- Cada tentativa é a rodada individual do jogador. Os prazos são definidos
-- pelo servidor e podem reiniciar sem alterar os cronômetros dos demais.
local inicioTentativaTimestamp: { [Player]: number } = {}
local fimTentativaTimestamp: { [Player]: number } = {}
local resetComRespawnPendente: { [Player]: boolean } = {}
local tentativaManualPendenteInicio: { [Player]: boolean } = {}
local tokenPreparacao = 0
local participantes: { [Player]: boolean } = {}
local tutorialConcluido: { [Player]: boolean } = {}
local progresso: { [Player]: Progresso } = {}
local sessoes: { [Player]: SessaoQuiz } = {}
local decksQuestoes: { [Player]: { [string]: { [number]: { number } } } } = {}
local ultimoAviso: { [Player]: number } = {}
local ultimoReset: { [Player]: number } = {}
local ultimoToquePortal: { [Player]: { [BasePart]: number } } = {}
local ultimoTeleportePortal: { [Player]: number } = {}
local ultimoAvisoPortao: { [Player]: number } = {}
local promptsConectados: { [ProximityPrompt]: boolean } = {}
local portaRecompensas: BasePart? = nil
local botaoReset: BasePart? = nil
local botaoResetCasa: CFrame? = nil
local botaoResetAnimando = false

local function obterPontuacao(player: Player): number
	local valor = player:GetAttribute("AcertosQuiz")
	if typeof(valor) ~= "number" then
		return 0
	end
	return math.clamp(math.floor(valor), 0, QuizConfig.MAX_ACERTOS)
end

local function tentativaAprovadaCongelada(player: Player): boolean
	return typeof(player:GetAttribute("TempoRestanteCongeladoQuiz")) == "number"
		and obterPontuacao(player) >= QuizConfig.ACERTOS_MINIMOS_PORTAO_RECOMPENSAS
end

local function existeJogadorComTentativaDisponivel(): boolean
	for _, player in ipairs(Players:GetPlayers()) do
		if tutorialConcluido[player] == true and not tentativaAprovadaCongelada(player) then
			return true
		end
	end
	return false
end

local function atualizarLeaderstats(player: Player, pontos: number)
	local leaderstats = player:FindFirstChild("leaderstats")
	if not leaderstats then
		leaderstats = Instance.new("Folder")
		leaderstats.Name = "leaderstats"
		leaderstats.Parent = player
	end

	local value = leaderstats:FindFirstChild(QuizConfig.NOME_ESTATISTICA_TAB)
	if value and not value:IsA("StringValue") then
		value:Destroy()
		value = nil
	end
	if not value then
		value = Instance.new("StringValue")
		value.Name = QuizConfig.NOME_ESTATISTICA_TAB
		value.Parent = leaderstats
	end
	(value :: StringValue).Value = string.format("%d/%d", pontos, QuizConfig.MAX_ACERTOS)
end

local function obterEstadoRodada()
	local prontos = 0
	local total = #Players:GetPlayers()
	for _, player in ipairs(Players:GetPlayers()) do
		if tutorialConcluido[player] then
			prontos += 1
		end
	end
	return {
		Fase = fase,
		Ativa = fase == FASE_ATIVA,
		FimRodadaTimestamp = fimRodadaTimestamp,
		DuracaoTotal = QuizConfig.DURACAO_RODADA_SEGUNDOS,
		NumeroRodada = numeroRodada,
		Prontos = prontos,
		Total = total,
	}
end

local function transmitirEstadoRodada()
	SincronizarRodada:FireAllClients(obterEstadoRodada())
end

ObterEstadoRodada.OnServerInvoke = function(_player: Player)
	return obterEstadoRodada()
end

local function notificar(player: Player, mensagem: string, cor: Color3?)
	local agora = os.clock()
	if agora - (ultimoAviso[player] or 0) < DURACAO_AVISO then
		return
	end
	ultimoAviso[player] = agora
	NotificarMensagem:FireClient(player, mensagem, cor or Color3.fromRGB(255, 255, 255))
end

local function embaralhar<T>(lista: { T }): { T }
	local copia = table.clone(lista)
	for i = #copia, 2, -1 do
		local j = math.random(i)
		copia[i], copia[j] = copia[j], copia[i]
	end
	return copia
end

local function obterQuestaoAleatoria(player: Player, materia: string, nivel: number, total: number): number
	local decksJogador = decksQuestoes[player]
	if not decksJogador then
		decksJogador = {}
		decksQuestoes[player] = decksJogador
	end
	local decksMateria = decksJogador[materia]
	if not decksMateria then
		decksMateria = {}
		decksJogador[materia] = decksMateria
	end
	local deck = decksMateria[nivel]
	if not deck or #deck == 0 then
		local indices = {}
		for index = 1, total do
			table.insert(indices, index)
		end
		deck = embaralhar(indices)
		decksMateria[nivel] = deck
	end
	return table.remove(deck) :: number
end

local function enviarSessao(player: Player, sessao: SessaoQuiz)
	AbrirQuiz:FireClient(player, {
		Materia = sessao.Materia,
		Nivel = sessao.Nivel,
		Nome = sessao.NomeQuestao,
		Alternativas = sessao.Alternativas,
	})
end

local function resetarPortasDeMateria(player: Player, materia: string)
	local primeiroNivel = 1
	local nivelFinal = materia == "Geografia" and QuizConfig.NIVEL_FINAL_GEOGRAFIA or QuizConfig.NIVEL_FINAL_HISTORIA
	for nivel = primeiroNivel, nivelFinal do
		local atributo = materia == "Geografia"
			and ("QuizFeito_Nivel" .. nivel)
			or ("QuizHistoriaFeito_Nivel" .. nivel)
		player:SetAttribute(atributo, nil)
		ControlarPorta:FireClient(player, string.format("PortaNivel%d %s", nivel, materia), false)
	end
end

local function encontrarParte(nome: string): BasePart?
	local instance = Workspace:FindFirstChild(nome, true)
	if instance and instance:IsA("BasePart") then
		return instance
	end
	if instance then
		return instance:FindFirstChildWhichIsA("BasePart", true)
	end
	return nil
end

local function teleportarParaNivel(player: Player, materia: string, nivel: number)
	local character = player.Character
	if not character then
		return
	end
	local root = character:FindFirstChild("HumanoidRootPart") :: BasePart?
	local humanoid = character:FindFirstChildOfClass("Humanoid")
	if not root or not humanoid or humanoid.Health <= 0 then
		return
	end

	local alvo: BasePart? = nil
	if nivel == 0 and materia == "Geografia" then
		alvo = encontrarParte("Teleport_Inicio_Geografia")
			or encontrarParte("Inicio_Geografia")
			or encontrarParte("Botão de Interação das Perguntas de Geografia nivel 0")
		else
			alvo = encontrarParte(materia == "História" and "Teleport_Inicio_Historia" or "Teleport_Inicio_Geografia")
				or encontrarParte(materia == "História" and "Inicio_Historia" or "Inicio_Geografia")
				or encontrarParte(string.format("Botão de Interação das Perguntas de %s nivel %d", materia, nivel))
		end
	if not alvo then
		return
	end

	root.AssemblyLinearVelocity = Vector3.zero
	root.AssemblyAngularVelocity = Vector3.zero
	character:PivotTo(alvo.CFrame * CFrame.new(0, 3.5, 4))
end

local function fecharPortasTentativa(player: Player)
	for nivel = 0, QuizConfig.NIVEL_FINAL_GEOGRAFIA do
		ControlarPorta:FireClient(player, string.format("PortaNivel%d Geografia", nivel), false)
	end
	for nivel = 1, QuizConfig.NIVEL_FINAL_HISTORIA do
		ControlarPorta:FireClient(player, string.format("PortaNivel%d História", nivel), false)
	end
	ResetarClient:FireClient(player)
end

local function resetarTentativa(player: Player, contarNovaTentativa: boolean?, inicioServidor: number?)
	if contarNovaTentativa and tutorialConcluido[player] == true then
		local tentativaAtual = tonumber(player:GetAttribute("NumeroTentativaQuiz")) or 1
		player:SetAttribute("NumeroTentativaQuiz", tentativaAtual + 1)
	end
	sessoes[player] = nil
	decksQuestoes[player] = {}
	player:SetAttribute("AcertosQuiz", 0)
	player:SetAttribute("TempoConclusaoQuiz", nil)
	player:SetAttribute("TempoRestanteCongeladoQuiz", nil)
	if fase == FASE_ATIVA and participantes[player] == true then
		local agoraServidor = inicioServidor or Workspace:GetServerTimeNow()
		inicioTentativaTimestamp[player] = agoraServidor
		fimTentativaTimestamp[player] = agoraServidor + QuizConfig.DURACAO_RODADA_SEGUNDOS
		player:SetAttribute("InicioTentativaQuiz", agoraServidor)
		player:SetAttribute("FimTentativaQuiz", fimTentativaTimestamp[player])
		fimRodadaTimestamp = math.max(fimRodadaTimestamp, fimTentativaTimestamp[player])
	else
		inicioTentativaTimestamp[player] = nil
		fimTentativaTimestamp[player] = nil
		player:SetAttribute("InicioTentativaQuiz", nil)
		player:SetAttribute("FimTentativaQuiz", nil)
	end
	atualizarLeaderstats(player, 0)
	for nivel = 0, QuizConfig.NIVEL_FINAL_GEOGRAFIA do
		player:SetAttribute("QuizFeito_Nivel" .. nivel, nil)
	end
	for nivel = 1, QuizConfig.NIVEL_FINAL_HISTORIA do
		player:SetAttribute("QuizHistoriaFeito_Nivel" .. nivel, nil)
	end
	if tutorialConcluido[player] then
		player:SetAttribute("QuizFeito_Nivel0", true)
	end
	local nivelInicial = tutorialConcluido[player] and 1 or 0
	progresso[player] = { Materia = "Geografia", Nivel = nivelInicial }
	fecharPortasTentativa(player)
end

local function todosConcluiramTutorial(): boolean
	local jogadores = Players:GetPlayers()
	if #jogadores == 0 then
		return false
	end
	for _, player in ipairs(jogadores) do
		if not tutorialConcluido[player] then
			return false
		end
	end
	return true
end

local iniciarRodada: () -> ()

local function tentarIniciarRodada()
	if fase ~= FASE_TUTORIAL and fase ~= FASE_INTERVALO then
		return
	end
	if not todosConcluiramTutorial() or not existeJogadorComTentativaDisponivel() then
		return
	end

	tokenPreparacao += 1
	local tokenAtual = tokenPreparacao
	fase = FASE_PREPARACAO
	fimRodadaTimestamp = 0
	transmitirEstadoRodada()

	task.delay(QuizConfig.TEMPO_PREPARACAO_RODADA_SEGUNDOS, function()
		if tokenAtual ~= tokenPreparacao or fase ~= FASE_PREPARACAO then
			return
		end
		if not todosConcluiramTutorial() then
			fase = FASE_TUTORIAL
			transmitirEstadoRodada()
			return
		end
		iniciarRodada()
	end)
end

local function proximoNivel(materia: string, nivel: number): Progresso
	if materia == "Geografia" and nivel >= QuizConfig.NIVEL_FINAL_GEOGRAFIA then
		return { Materia = "História", Nivel = 1 }
	elseif materia == "História" and nivel >= QuizConfig.NIVEL_FINAL_HISTORIA then
		return { Materia = "Geografia", Nivel = 1 }
	end
	return { Materia = materia, Nivel = nivel + 1 }
end

local function obterDadosDoNivel(materia: string, nivel: number)
	local dadosMateria = QuizBanco[materia]
	local dadosNivel = dadosMateria and dadosMateria[nivel]
	local questoes = dadosNivel and dadosNivel.Dados
	if type(questoes) ~= "table" or #questoes == 0 then
		return nil
	end
	return questoes
end

local function dentroDoAlcance(player: Player, part: BasePart, distancia: number): boolean
	local character = player.Character
	local root = character and character:FindFirstChild("HumanoidRootPart")
	if not root or not root:IsA("BasePart") then
		return false
	end
	return (root.Position - part.Position).Magnitude <= distancia + 4
end

local function iniciarQuiz(player: Player, materia: string, nivel: number, nomePorta: string, part: BasePart, prompt: ProximityPrompt)
	if not dentroDoAlcance(player, part, prompt.MaxActivationDistance) then
		return
	end

	local tutorial = materia == "Geografia" and nivel == 0
	if tutorial then
		if tutorialConcluido[player] then
			return
		end
		if fase == FASE_ATIVA then
			notificar(player, "A rodada atual já começou. O tutorial abre no próximo intervalo.", Color3.fromRGB(255, 210, 90))
			return
		end
		if fase ~= FASE_TUTORIAL and fase ~= FASE_INTERVALO then
			return
		end
	else
		if fase ~= FASE_ATIVA or not participantes[player] then
			return
		end
		local esperado = progresso[player]
		if not esperado or esperado.Materia ~= materia or esperado.Nivel ~= nivel then
			if esperado then
				notificar(player, string.format("Responda primeiro %s, nível %d.", esperado.Materia, esperado.Nivel), Color3.fromRGB(255, 210, 90))
			end
			return
		end
	end

	local atual = sessoes[player]
	if atual then
		if atual.Respondido then
			return
		end
		if atual.Materia == materia and atual.Nivel == nivel then
			enviarSessao(player, atual)
		end
		return
	end

	local questoes = obterDadosDoNivel(materia, nivel)
	if not questoes then
		warn(string.format("[QuizServer] Banco sem questões para %s nível %d.", materia, nivel))
		return
	end

	local indiceQuestao = obterQuestaoAleatoria(player, materia, nivel, #questoes)
	local questao = questoes[indiceQuestao]
	if type(questao) ~= "table" or type(questao.Alternativas) ~= "table" or #questao.Alternativas ~= 3 then
		warn(string.format("[QuizServer] Questão inválida em %s nível %d.", materia, nivel))
		return
	end

	local preparadas: { AlternativaPreparada } = {}
	local falsas = 0
	for _, alternativa in ipairs(questao.Alternativas) do
		if type(alternativa) ~= "table" or type(alternativa.Texto) ~= "string" or typeof(alternativa.Falsa) ~= "boolean" then
			warn(string.format("[QuizServer] Alternativa inválida em %s nível %d.", materia, nivel))
			return
		end
		table.insert(preparadas, { Texto = alternativa.Texto, Falsa = alternativa.Falsa })
		if alternativa.Falsa then
			falsas += 1
		end
	end
	if falsas ~= 1 then
		warn(string.format("[QuizServer] Esperava uma alternativa falsa em %s nível %d; encontrou %d.", materia, nivel, falsas))
		return
	end

	local alternativasEmbaralhadas = embaralhar(preparadas)
	local alternativasCliente: { string } = {}
	local indiceCorreto = 0
	for index, alternativa in ipairs(alternativasEmbaralhadas) do
		table.insert(alternativasCliente, alternativa.Texto)
		if alternativa.Falsa then
			indiceCorreto = index
		end
	end

	local sessao: SessaoQuiz = {
		Materia = materia,
		Nivel = nivel,
		NomePorta = nomePorta,
		NomeQuestao = questao.Nome,
		Alternativas = alternativasCliente,
		IndiceCorreto = indiceCorreto,
		Tutorial = tutorial,
		Respondido = false,
	}
	sessoes[player] = sessao
	enviarSessao(player, sessao)
end

local function mapearBotao(nome: string): (string?, number?)
	for nivel = 0, QuizConfig.NIVEL_FINAL_GEOGRAFIA do
		if nome == string.format("Botão de Interação das Perguntas de Geografia nivel %d", nivel) then
			return "Geografia", nivel
		end
	end
	for nivel = 1, QuizConfig.NIVEL_FINAL_HISTORIA do
		if nome == string.format("Botão de Interação das Perguntas de História nivel %d", nivel) then
			return "História", nivel
		end
	end
	return nil, nil
end

local function conectarPrompt(prompt: ProximityPrompt)
	if promptsConectados[prompt] then
		return
	end
	local part = prompt:FindFirstAncestorWhichIsA("BasePart")
	if not part then
		return
	end
	local materia, nivel = mapearBotao(part.Name)
	if not materia or not nivel then
		return
	end

	promptsConectados[prompt] = true
	prompt.ActionText = "Responder quiz"
	prompt.ObjectText = string.format("%s · nível %d", materia, nivel)
	prompt.RequiresLineOfSight = false
	prompt.MaxActivationDistance = 12
	prompt.HoldDuration = 0
	prompt.Enabled = true
	prompt.Triggered:Connect(function(player: Player)
		iniciarQuiz(player, materia :: string, nivel :: number, string.format("PortaNivel%d %s", nivel, materia), part, prompt)
	end)
end

local function enviarRespostaDoJogador(player: Player, indiceEscolhido: any)
	local sessao = sessoes[player]
	if not sessao or sessao.Respondido then
		return { Aceito = false, Mensagem = "Não há uma questão ativa." }
	end
	local disponivel = sessao.Tutorial
		and (fase == FASE_TUTORIAL or fase == FASE_INTERVALO)
		and not tutorialConcluido[player]
		or (not sessao.Tutorial and fase == FASE_ATIVA and participantes[player] == true
			and (fimTentativaTimestamp[player] or 0) > Workspace:GetServerTimeNow())
	if not disponivel then
		sessoes[player] = nil
		return { Aceito = false, Mensagem = "A rodada não está aceitando respostas." }
	end
	if typeof(indiceEscolhido) ~= "number" or indiceEscolhido % 1 ~= 0 or indiceEscolhido < 1 or indiceEscolhido > #sessao.Alternativas then
		return { Aceito = false, Mensagem = "Resposta inválida." }
	end

	sessao.Respondido = true
	local acertou = indiceEscolhido == sessao.IndiceCorreto
	local nomeAtributo = sessao.Materia == "Geografia"
		and ("QuizFeito_Nivel" .. sessao.Nivel)
		or ("QuizHistoriaFeito_Nivel" .. sessao.Nivel)
	player:SetAttribute(nomeAtributo, true)

	local pontos = obterPontuacao(player)
	if acertou and not sessao.Tutorial then
		pontos = math.min(QuizConfig.MAX_ACERTOS, pontos + 1)
		player:SetAttribute("AcertosQuiz", pontos)
		atualizarLeaderstats(player, pontos)
	end

	if not sessao.Tutorial
		and pontos >= QuizConfig.ACERTOS_MINIMOS_PORTAO_RECOMPENSAS
		and not tentativaAprovadaCongelada(player)
	then
		local agoraServidor = Workspace:GetServerTimeNow()
		local inicioTentativa = inicioTentativaTimestamp[player]
			or (tonumber(player:GetAttribute("InicioTentativaQuiz")) :: number?)
			or inicioRodadaTimestamp
		local fimTentativa = fimTentativaTimestamp[player]
			or (tonumber(player:GetAttribute("FimTentativaQuiz")) :: number?)
			or agoraServidor
		player:SetAttribute("TempoConclusaoQuiz", math.max(0, agoraServidor - inicioTentativa))
		player:SetAttribute("TempoRestanteCongeladoQuiz", math.max(0, fimTentativa - agoraServidor))
		notificar(
			player,
			"Você alcançou 15 acertos. Os dois cronômetros e o tempo da leaderboard ficaram congelados até o reset.",
			Color3.fromRGB(120, 235, 165)
		)
	end

	ControlarPorta:FireClient(player, sessao.NomePorta, true)
	local proximo = progresso[player]
	if sessao.Tutorial then
		tutorialConcluido[player] = true
		progresso[player] = { Materia = "Geografia", Nivel = 1 }
		notificar(player, "Tutorial concluído. A rodada começa quando todos terminarem.", Color3.fromRGB(90, 230, 150))
		tentarIniciarRodada()
	elseif proximo and proximo.Materia == sessao.Materia and proximo.Nivel == sessao.Nivel then
		local reiniciarPorPontuacaoInsuficiente = false
		if sessao.Materia == "História"
			and sessao.Nivel == QuizConfig.NIVEL_FINAL_HISTORIA
			and player:GetAttribute("TempoConclusaoQuiz") == nil
			and (inicioTentativaTimestamp[player] or inicioRodadaTimestamp) > 0
		then
			local inicioTentativa = inicioTentativaTimestamp[player] or inicioRodadaTimestamp
			player:SetAttribute("TempoConclusaoQuiz", math.max(0, Workspace:GetServerTimeNow() - inicioTentativa))
		end
		local finalDaTentativa = sessao.Materia == "História" and sessao.Nivel == QuizConfig.NIVEL_FINAL_HISTORIA
		if finalDaTentativa and pontos < QuizConfig.ACERTOS_MINIMOS_PORTAO_RECOMPENSAS then
			reiniciarPorPontuacaoInsuficiente = true
		end
		local destino = proximoNivel(sessao.Materia, sessao.Nivel)
		if reiniciarPorPontuacaoInsuficiente then
			progresso[player] = { Materia = "Geografia", Nivel = 1 }
		elseif sessao.Nivel == QuizConfig.NIVEL_FINAL_GEOGRAFIA and sessao.Materia == "Geografia" then
			resetarPortasDeMateria(player, "História")
		elseif sessao.Nivel == QuizConfig.NIVEL_FINAL_HISTORIA and sessao.Materia == "História" then
			resetarPortasDeMateria(player, "Geografia")
		end
		if not reiniciarPorPontuacaoInsuficiente then
			progresso[player] = destino
		end
		if reiniciarPorPontuacaoInsuficiente then
			local tentativaConcluida = tonumber(player:GetAttribute("NumeroTentativaQuiz")) or 1
			task.delay(QuizConfig.TEMPO_EXIBICAO_RESULTADO + 0.15, function()
				if player.Parent == Players
					and fase == FASE_ATIVA
					and participantes[player] == true
					and (tonumber(player:GetAttribute("NumeroTentativaQuiz")) or 1) == tentativaConcluida
				then
					resetarTentativa(player, true)
					task.defer(teleportarParaNivel, player, "Geografia", 1)
					local tentativaAtual = tonumber(player:GetAttribute("NumeroTentativaQuiz")) or 1
					notificar(player, string.format("Você terminou com %d/%d. São necessários %d acertos; nova rodada iniciada (rodada %d).", pontos, QuizConfig.MAX_ACERTOS, QuizConfig.ACERTOS_MINIMOS_PORTAO_RECOMPENSAS, tentativaAtual), Color3.fromRGB(255, 190, 100))
				end
			end)
		elseif destino.Nivel == 1 and destino.Materia ~= sessao.Materia then
			task.delay(QuizConfig.TEMPO_EXIBICAO_RESULTADO + 0.15, function()
				if player.Parent == Players and fase == FASE_ATIVA and participantes[player] then
					teleportarParaNivel(player, destino.Materia, destino.Nivel)
				end
			end)
		end
	end

	local resultado = {
		Aceito = true,
		Acertou = acertou,
		IndiceCorreto = sessao.IndiceCorreto,
		Pontuacao = pontos,
		TutorialConcluido = sessao.Tutorial,
	}
	task.delay(QuizConfig.TEMPO_EXIBICAO_RESULTADO, function()
		if sessoes[player] == sessao then
			sessoes[player] = nil
		end
	end)
	return resultado
end

EnviarResposta.OnServerInvoke = enviarRespostaDoJogador

local function obterPortalRecompensas(): BasePart?
	for _, instance in ipairs(Workspace:GetDescendants()) do
		if instance:IsA("BasePart") and instance:GetAttribute(QuizConfig.NOME_ATRIBUTO_PORTAO_RECOMPENSAS) == true then
			return instance
		end
	end
	return nil
end

local function configurarPortaoRecompensas()
	portaRecompensas = encontrarParte(QuizConfig.NOME_PORTAO_RECOMPENSAS)
	local portal = obterPortalRecompensas()
	if not portaRecompensas then
		portaRecompensas = Instance.new("Part")
		portaRecompensas.Name = QuizConfig.NOME_PORTAO_RECOMPENSAS
		portaRecompensas.Anchored = true
		portaRecompensas.Parent = Workspace
	end
	local gate = portaRecompensas
	gate.Name = QuizConfig.NOME_PORTAO_RECOMPENSAS
	gate.Anchored = true
	-- A validação é direcional no servidor; uma colisão fixa também bloquearia a saída.
	gate.CanCollide = false
	gate.CanTouch = true
	gate.CanQuery = false
	gate.Material = Enum.Material.Neon
	gate.Color = Color3.fromRGB(0, 245, 255)
	gate.Transparency = 0.34

	if portal then
		gate.CFrame = portal.CFrame
		gate.Size = Vector3.new(5.55, 10, 0.28)
		portal.CanCollide = false
		portal.CanTouch = true
		portal.CanQuery = true
		portal.Transparency = 1
	else
		gate.CFrame = CFrame.new(405.025, 1051, 79.6)
		gate.Size = Vector3.new(5.55, 10, 0.28)
		warn("[QuizServer] Portal azul central não foi marcado com o atributo IsRewardGate.")
	end
	gate.Touched:Connect(function(hit)
		local character = hit:FindFirstAncestorOfClass("Model")
		local player = character and Players:GetPlayerFromCharacter(character)
		if not player or not character then
			return
		end
		local rootPart = character:FindFirstChild("HumanoidRootPart") :: BasePart?
		local humanoid = character:FindFirstChildOfClass("Humanoid")
		if not rootPart or not humanoid or humanoid.Health <= 0 then
			return
		end

		local normal = gate.CFrame.LookVector
		local lado = (rootPart.Position - gate.Position):Dot(normal)
		local velocidadeNormal = rootPart.AssemblyLinearVelocity:Dot(normal)
		-- +LookVector aponta do percurso para o lado interno do portal. Portanto,
		-- movimento no sentido oposto é saída; movimento para frente é entrada.
		local saindo = velocidadeNormal < -0.1 or (math.abs(velocidadeNormal) <= 0.1 and lado > 0)
		if saindo then
			return
		end

		local pontos = obterPontuacao(player)
		if pontos >= QuizConfig.ACERTOS_MINIMOS_PORTAO_RECOMPENSAS
			and ((fase == FASE_ATIVA and participantes[player] == true) or tentativaAprovadaCongelada(player))
		then
			return
		end

		local agora = os.clock()
		if agora - (ultimoAvisoPortao[player] or 0) > 2 then
			ultimoAvisoPortao[player] = agora
			if pontos < QuizConfig.ACERTOS_MINIMOS_PORTAO_RECOMPENSAS then
				notificar(player, string.format("Acesso às recompensas exige 15 acertos na tentativa atual (%d/%d).", pontos, QuizConfig.MAX_ACERTOS), Color3.fromRGB(255, 100, 100))
			else
				notificar(player, "O portão só libera a entrada durante uma rodada ativa.", Color3.fromRGB(255, 180, 90))
			end
		end

		-- Repele quem tenta entrar sem permissão para o lado externo do percurso.
		local distanciaSegura = gate.Size.Z * 0.5 + 3
		local deslocamento = math.max(0, distanciaSegura + lado)
		if deslocamento > 0 then
			character:PivotTo(character:GetPivot() - normal * deslocamento)
		end
		rootPart.AssemblyLinearVelocity = Vector3.zero
		rootPart.AssemblyAngularVelocity = Vector3.zero
	end)
end

local function estilizarBotaoReset()
	botaoReset = encontrarParte(QuizConfig.NOME_BOTAO_RESET)
	if not botaoReset then
		return
	end
	local part = botaoReset
	part.Anchored = true
	part.Material = Enum.Material.Neon
	part.Color = Color3.fromRGB(210, 58, 72)
	part.TopSurface = Enum.SurfaceType.Smooth
	part.BottomSurface = Enum.SurfaceType.Smooth
	botaoResetCasa = part.CFrame

	local surface = part:FindFirstChild("ResetButtonSurfaceGui") :: SurfaceGui?
	if not surface then
		surface = Instance.new("SurfaceGui")
		surface.Name = "ResetButtonSurfaceGui"
		surface.Face = Enum.NormalId.Top
		surface.SizingMode = Enum.SurfaceGuiSizingMode.PixelsPerStud
		surface.PixelsPerStud = 80
		surface.LightInfluence = 0
		surface.Parent = part
	end
	for _, child in ipairs(surface:GetChildren()) do
		child:Destroy()
	end
	local label = Instance.new("TextLabel")
	label.Name = "Label"
	label.Size = UDim2.fromScale(1, 1)
	label.BackgroundColor3 = Color3.fromRGB(78, 22, 34)
	label.BackgroundTransparency = 0.12
	label.Font = Enum.Font.GothamBlack
	label.Text = "RESETAR"
	label.TextColor3 = Color3.fromRGB(255, 255, 255)
	label.TextScaled = true
	label.TextWrapped = true
	label.Parent = surface
	local sizeConstraint = Instance.new("UITextSizeConstraint")
	sizeConstraint.MinTextSize = 12
	sizeConstraint.MaxTextSize = 26
	sizeConstraint.Parent = label
	local stroke = Instance.new("UIStroke")
	stroke.Color = Color3.fromRGB(255, 190, 190)
	stroke.Thickness = 1.5
	stroke.Parent = label
	local prompt = part:FindFirstChildOfClass("ProximityPrompt") :: ProximityPrompt?
	if not prompt then
		prompt = Instance.new("ProximityPrompt")
		prompt.Parent = part
	end
	prompt.ActionText = "Resetar tentativa"
	prompt.ObjectText = "Zerar acertos e recomeçar"
	prompt.MaxActivationDistance = 12
	prompt.HoldDuration = 0.5
	prompt.RequiresLineOfSight = false

	local clickDetector = part:FindFirstChildOfClass("ClickDetector") :: ClickDetector?
	if not clickDetector then
		clickDetector = Instance.new("ClickDetector")
		clickDetector.Parent = part
	end
	clickDetector.MaxActivationDistance = 12
end

local function animarBotaoReset()
	if not botaoReset or not botaoResetCasa or botaoResetAnimando then
		return
	end
	botaoResetAnimando = true
	local part = botaoReset
	local casa = botaoResetCasa
	local pressionado = casa * CFrame.new(0, -0.18, 0)
	local baixo = TweenService:Create(part, TweenInfo.new(0.08, Enum.EasingStyle.Quad, Enum.EasingDirection.Out), {
		CFrame = pressionado,
		Color = Color3.fromRGB(135, 35, 48),
	})
	local alto = TweenService:Create(part, TweenInfo.new(0.12, Enum.EasingStyle.Quad, Enum.EasingDirection.Out), {
		CFrame = casa,
		Color = Color3.fromRGB(210, 58, 72),
	})
	baixo:Play()
	baixo.Completed:Wait()
	alto:Play()
	alto.Completed:Wait()
	botaoResetAnimando = false
end

local function processarReset(player: Player, matarPersonagem: boolean)
	local agora = os.clock()
	if agora - (ultimoReset[player] or 0) < 2 then
		return
	end
	ultimoReset[player] = agora
	local iniciarTentativaNaProximaRodada = fase ~= FASE_ATIVA and tutorialConcluido[player] == true
	if fase == FASE_ATIVA and tutorialConcluido[player] == true then
		-- Reset após o prazo individual reabre uma nova tentativa enquanto a
		-- sessão compartilhada ainda estiver ativa.
		participantes[player] = true
	end
	local tentativaAntesDoReset = tonumber(player:GetAttribute("NumeroTentativaQuiz")) or 1
	resetarTentativa(player, true)
	if iniciarTentativaNaProximaRodada then
		tentativaManualPendenteInicio[player] = true
	end
	local tentativaAtual = tonumber(player:GetAttribute("NumeroTentativaQuiz")) or tentativaAntesDoReset
	notificar(player, string.format("Rodada reiniciada. Acertos zerados; você começou a rodada %d.", tentativaAtual), Color3.fromRGB(255, 215, 100))
	if fase == FASE_INTERVALO then
		tentarIniciarRodada()
	end
	if matarPersonagem then
		local humanoid = player.Character and player.Character:FindFirstChildOfClass("Humanoid")
		if humanoid and humanoid.Health > 0 then
			resetComRespawnPendente[player] = true
			humanoid.Health = 0
		end
	else
		local destino = tutorialConcluido[player] and 1 or 0
		task.defer(teleportarParaNivel, player, "Geografia", destino)
	end
end

SolicitarReset.OnServerEvent:Connect(function(player: Player)
	processarReset(player, true)
	if botaoReset then
		task.spawn(animarBotaoReset)
	end
end)

local function configurarBotaoReset()
	if not botaoReset then
		return
	end
	local prompt = botaoReset:FindFirstChildOfClass("ProximityPrompt") :: ProximityPrompt?
	if prompt then
		prompt.Triggered:Connect(function(player: Player)
			if dentroDoAlcance(player, botaoReset :: BasePart, prompt.MaxActivationDistance) then
				processarReset(player, true)
				task.spawn(animarBotaoReset)
			end
		end)
	end
	local clickDetector = botaoReset:FindFirstChildOfClass("ClickDetector") :: ClickDetector?
	if clickDetector then
		clickDetector.MouseClick:Connect(function(player: Player)
			if dentroDoAlcance(player, botaoReset :: BasePart, clickDetector.MaxActivationDistance) then
				processarReset(player, true)
				task.spawn(animarBotaoReset)
			end
		end)
	end
end

local function localizarParteFilha(parent: Instance?, name: string): BasePart?
	local object = parent and parent:FindFirstChild(name, true)
	if object and object:IsA("BasePart") then
		return object
	end
	return nil
end

local function configurarPortais()
	local conectados: { [Instance]: boolean } = {}
	for _, root in ipairs(Workspace:GetDescendants()) do
		if root.Name == "Teleport Portals" and not conectados[root] then
			local red = root:FindFirstChild("PortalRed")
			local blue = root:FindFirstChild("PortalBlue")
			local redTeleport = localizarParteFilha(red, "RedTeleport")
			local blueTeleport = localizarParteFilha(blue, "BlueTeleport")
			local redArrive = localizarParteFilha(red, "RedArrive")
			local blueArrive = localizarParteFilha(blue, "BlueArrive")
			if redTeleport and blueTeleport and redArrive and blueArrive then
				conectados[root] = true
				for _, child in ipairs(root:GetDescendants()) do
					if child:IsA("Script") then
						child.Disabled = true
					end
				end
				if blueTeleport:GetAttribute(QuizConfig.NOME_ATRIBUTO_PORTAO_RECOMPENSAS) == true then
					-- O PortalBlue é a entrada do percurso para as recompensas:
					-- seu destino é RedArrive. O retorno pelo PortalRed é sempre livre.
					blueArrive:SetAttribute("IsRewardDestination", nil)
					redArrive:SetAttribute("IsRewardDestination", true)
				end

				local function transportar(source: BasePart, destination: BasePart)
					source.Touched:Connect(function(hit: BasePart)
						local character = hit:FindFirstAncestorOfClass("Model")
						local player = character and Players:GetPlayerFromCharacter(character)
						if not player or not character then
							return
						end
						local rootPart = character:FindFirstChild("HumanoidRootPart") :: BasePart?
						local humanoid = character:FindFirstChildOfClass("Humanoid")
						if not rootPart or not humanoid or humanoid.Health <= 0 then
							return
						end
						if (rootPart.Position - source.Position).Magnitude > 16 then
							return
						end
						local agora = os.clock()
						local toquesDoJogador = ultimoToquePortal[player]
						if not toquesDoJogador then
							toquesDoJogador = {}
							ultimoToquePortal[player] = toquesDoJogador
						end
						if agora - (toquesDoJogador[source] or 0) < 0.65 then
							return
						end
						-- As posições de chegada ficam próximas do portal de retorno. Um
						-- cooldown global evita que a chegada ative o portal oposto no mesmo
						-- instante e devolva o jogador imediatamente.
						if agora - (ultimoTeleportePortal[player] or 0) < 1.2 then
							return
						end
						toquesDoJogador[source] = agora

						local destinoRecompensas = destination:GetAttribute("IsRewardDestination") == true
						local acessoCongelado = tentativaAprovadaCongelada(player)
						local acessoNaTentativaAtiva = fase == FASE_ATIVA
							and participantes[player] == true
							and obterPontuacao(player) >= QuizConfig.ACERTOS_MINIMOS_PORTAO_RECOMPENSAS
						if destinoRecompensas and not (acessoNaTentativaAtiva or acessoCongelado) then
							notificar(player, string.format("A entrada exige 15 acertos na tentativa atual (%d/%d).", obterPontuacao(player), QuizConfig.MAX_ACERTOS), Color3.fromRGB(255, 100, 100))
							return
						end

						rootPart.AssemblyLinearVelocity = Vector3.zero
						rootPart.AssemblyAngularVelocity = Vector3.zero
						ultimoTeleportePortal[player] = agora
						character:PivotTo(destination.CFrame + Vector3.new(0, 4, 0))
					end)
				end

				-- Só a travessia para RedArrive entra na área de recompensas.
				-- O retorno para BlueArrive nunca consulta a pontuação.
				transportar(blueTeleport, redArrive)
				transportar(redTeleport, blueArrive)
			end
		end
	end
end

iniciarRodada = function()
	numeroRodada += 1
	fase = FASE_ATIVA
	inicioRodadaTimestamp = Workspace:GetServerTimeNow()
	fimRodadaTimestamp = 0
	local iniciouTentativa = false
	for _, player in ipairs(Players:GetPlayers()) do
		if tentativaAprovadaCongelada(player) then
			participantes[player] = false
			sessoes[player] = nil
		else
			iniciouTentativa = true
			participantes[player] = true
			if not tentativaManualPendenteInicio[player] then
				player:SetAttribute("NumeroTentativaQuiz", 1)
			end
			tentativaManualPendenteInicio[player] = nil
			resetarTentativa(player, false, inicioRodadaTimestamp)
			progresso[player] = { Materia = "Geografia", Nivel = 1 }
			teleportarParaNivel(player, "Geografia", 1)
		end
	end
	if not iniciouTentativa then
		fase = FASE_INTERVALO
		transmitirEstadoRodada()
		return
	end
	transmitirEstadoRodada()

	local rodadaAtual = numeroRodada
	task.spawn(function()
		while fase == FASE_ATIVA and rodadaAtual == numeroRodada do
			local agoraServidor = Workspace:GetServerTimeNow()
			local proximaExpiracao = math.huge
			local maiorPrazo = 0
			for _, player in ipairs(Players:GetPlayers()) do
				if participantes[player] == true then
					local prazo = fimTentativaTimestamp[player] or 0
					if prazo > agoraServidor then
						proximaExpiracao = math.min(proximaExpiracao, prazo)
						maiorPrazo = math.max(maiorPrazo, prazo)
					else
						participantes[player] = false
						fimTentativaTimestamp[player] = nil
						inicioTentativaTimestamp[player] = nil
						player:SetAttribute("FimTentativaQuiz", nil)
						player:SetAttribute("InicioTentativaQuiz", nil)
						sessoes[player] = nil
						fecharPortasTentativa(player)
						if tentativaAprovadaCongelada(player) then
							FimDeRodada:FireClient(player, {
								Mensagem = "Tentativa congelada preservada. Use RESETAR para iniciar outra.",
								Individual = true,
								Concluida = true,
							})
						else
							FimDeRodada:FireClient(player, {
								Mensagem = "Seu tempo acabou. Aguarde o próximo início para tentar de novo.",
								Individual = true,
							})
						end
					end
				end
			end
			fimRodadaTimestamp = maiorPrazo
			if proximaExpiracao == math.huge then
				break
			end
			task.wait(math.min(0.25, math.max(0.01, proximaExpiracao - agoraServidor)))
		end
		if fase ~= FASE_ATIVA or rodadaAtual ~= numeroRodada then
			return
		end

		fase = FASE_INTERVALO
		fimRodadaTimestamp = 0
		for _, player in ipairs(Players:GetPlayers()) do
			participantes[player] = false
			sessoes[player] = nil
			fimTentativaTimestamp[player] = nil
			inicioTentativaTimestamp[player] = nil
			player:SetAttribute("FimTentativaQuiz", nil)
			player:SetAttribute("InicioTentativaQuiz", nil)
			fecharPortasTentativa(player)
			if not tutorialConcluido[player] then
				task.defer(teleportarParaNivel, player, "Geografia", 0)
			end
		end
		FimDeRodada:FireAllClients({ Mensagem = "Tempo da rodada esgotado." })
		transmitirEstadoRodada()
		task.delay(QuizConfig.INTERVALO_ENTRE_RODADAS_SEGUNDOS, function()
			if fase == FASE_INTERVALO then
				tentarIniciarRodada()
			end
		end)
	end)
end

local function inicializarJogador(player: Player)
	participantes[player] = false
	tutorialConcluido[player] = false
	progresso[player] = { Materia = "Geografia", Nivel = 0 }
	sessoes[player] = nil
	decksQuestoes[player] = {}
	player:SetAttribute("AcertosQuiz", 0)
	player:SetAttribute("NumeroTentativaQuiz", 0)
	player:SetAttribute("TempoConclusaoQuiz", nil)
	player:SetAttribute("TempoRestanteCongeladoQuiz", nil)
	player:SetAttribute("InicioTentativaQuiz", nil)
	player:SetAttribute("FimTentativaQuiz", nil)
	inicioTentativaTimestamp[player] = nil
	fimTentativaTimestamp[player] = nil
	atualizarLeaderstats(player, 0)

	player.CharacterAdded:Connect(function(character: Model)
		if resetComRespawnPendente[player] then
			resetComRespawnPendente[player] = nil
			if fase == FASE_ATIVA and participantes[player] then
				task.delay(0.3, teleportarParaNivel, player, "Geografia", 1)
			elseif fase == FASE_INTERVALO and not tutorialConcluido[player] then
				task.delay(0.3, teleportarParaNivel, player, "Geografia", 0)
			end
		elseif fase == FASE_ATIVA and participantes[player] then
			resetarTentativa(player)
			task.delay(0.3, teleportarParaNivel, player, "Geografia", 1)
		elseif fase == FASE_INTERVALO and not tutorialConcluido[player] then
			task.delay(0.3, teleportarParaNivel, player, "Geografia", 0)
		end
	end)
	transmitirEstadoRodada()
	if fase == FASE_ATIVA then
		notificar(player, "A rodada já começou. Você participa a partir do próximo início.", Color3.fromRGB(255, 210, 90))
	elseif tutorialConcluido[player] then
		tentarIniciarRodada()
	end
end

local function removerJogador(player: Player)
	participantes[player] = nil
	tutorialConcluido[player] = nil
	inicioTentativaTimestamp[player] = nil
	fimTentativaTimestamp[player] = nil
	resetComRespawnPendente[player] = nil
	tentativaManualPendenteInicio[player] = nil
	progresso[player] = nil
	sessoes[player] = nil
	decksQuestoes[player] = nil
	ultimoAviso[player] = nil
	ultimoReset[player] = nil
	ultimoToquePortal[player] = nil
	ultimoTeleportePortal[player] = nil
	ultimoAvisoPortao[player] = nil
	if #Players:GetPlayers() <= 1 and fase == FASE_PREPARACAO then
		tokenPreparacao += 1
		fase = FASE_TUTORIAL
		fimRodadaTimestamp = 0
	end
	transmitirEstadoRodada()
	if fase == FASE_TUTORIAL or fase == FASE_INTERVALO then
		tentarIniciarRodada()
	end
end

for _, descendant in ipairs(Workspace:GetDescendants()) do
	if descendant:IsA("ProximityPrompt") then
		conectarPrompt(descendant)
	end
end
Workspace.DescendantAdded:Connect(function(descendant: Instance)
	if descendant:IsA("ProximityPrompt") then
		task.defer(conectarPrompt, descendant)
	end
end)

configurarPortaoRecompensas()
estilizarBotaoReset()
configurarBotaoReset()
configurarPortais()

Players.PlayerAdded:Connect(inicializarJogador)
Players.PlayerRemoving:Connect(removerJogador)
for _, player in ipairs(Players:GetPlayers()) do
	inicializarJogador(player)
end
