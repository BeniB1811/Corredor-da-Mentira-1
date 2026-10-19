--!strict
-- Placar de recordes globais persistente via DataStoreService.
-- Classifica os jogadores por maior número de acertos e menor tempo de conclusão.
local Players = game:GetService("Players")
local ReplicatedStorage = game:GetService("ReplicatedStorage")
local Workspace = game:GetService("Workspace")
local DataStoreService = game:GetService("DataStoreService")
local MessagingService = game:GetService("MessagingService")
local RunService = game:GetService("RunService")

local QuizConfig = require(ReplicatedStorage:WaitForChild("QuizConfig"))

-- Marca preta da imagem, na face interna da Grey Wall voltada para o percurso.
-- O ponto mantém a posição na parede; o painel avança 1,25 studs para o percurso.
local POSICAO_PLACAR = Vector3.new(367, 1052.5, 61.15)
local DIRECAO_PLACAR = Vector3.new(0, 0, -1)
local DISTANCIA_DESTAQUE = 1.25
local TAMANHO_PLACAR = Vector3.new(13, 9, 0.46)
local MAX_JOGADORES = 10
local NOME_MODELO_PERSISTENTE = "LeaderboardPersistentDisplay"

-- Nomes das chaves de DataStore e Mensageria Global
local NOME_ORDERED_STORE = "QuizRankingGlobal_v2"
local NOME_STATS_STORE = "QuizPlayerStats_v2"
local TOPICO_RANKING_GLOBAL = QuizConfig.TOPICO_MESSAGING_RANKING or "QuizLeaderboardGlobalUpdate"
local INTERVALO_ATUALIZACAO_GLOBAL = 30 -- segundos entre consultas ao Top 10

-- Fatores para combinar Acertos e Menor Tempo em um único inteiro ordenável:
-- Score = (Acertos * 10.000.000) + max(1, 10.000.000 - TempoEmMs)
-- 20 acertos em 60s -> 200.000.000 + 9.940.000 = 209.940.000
-- 20 acertos em 120s -> 200.000.000 + 9.880.000 = 208.880.000 (menor tempo tem score maior)
-- 19 acertos -> na faixa dos 190.000.000 (nunca passa quem fez 20)
local FATOR_ACERTOS = 10_000_000
local BASE_TEMPO_MS = 10_000_000

type RecordeJogador = {
	UserId: number,
	DisplayName: string,
	Name: string,
	Acertos: number,
	Tempo: number?,
	Timestamp: number,
}

type EntradaRanking = {
	UserId: number,
	NomeFormatado: string,
	Pontos: number,
	TempoConclusao: number?,
}

local recordesLocais: { [number]: RecordeJogador } = {}
local nomesCache: { [number]: string } = {}
local pendenteSalvar: { [number]: boolean } = {}
local debounceSalvar: { [number]: number } = {}

local function calcularScore(acertos: number, tempoSegundos: number?): number
	if acertos <= 0 then
		return 0
	end
	local pontosAcertos = math.clamp(acertos, 0, QuizConfig.MAX_ACERTOS) * FATOR_ACERTOS
	local pontosTempo = 0
	if typeof(tempoSegundos) == "number" and tempoSegundos > 0 then
		local ms = math.floor(tempoSegundos * 1000 + 0.5)
		pontosTempo = math.clamp(BASE_TEMPO_MS - ms, 1, BASE_TEMPO_MS)
	end
	return pontosAcertos + pontosTempo
end

local function decodificarScore(score: number): (number, number?)
	if score <= 0 then
		return 0, nil
	end
	local acertos = math.floor(score / FATOR_ACERTOS)
	local sobra = score % FATOR_ACERTOS
	local tempoSegundos: number? = nil
	if sobra > 0 then
		local ms = BASE_TEMPO_MS - sobra
		if ms >= 0 then
			tempoSegundos = ms / 1000
		end
	end
	return acertos, tempoSegundos
end

local function obterNomeFormatado(userId: number): string
	local online = Players:GetPlayerByUserId(userId)
	if online then
		local formatado = string.format("%s  (@%s)", online.DisplayName, online.Name)
		nomesCache[userId] = formatado
		return formatado
	end
	if nomesCache[userId] then
		return nomesCache[userId]
	end
	local ok, nome = pcall(function()
		return Players:GetNameFromUserIdAsync(userId)
	end)
	if ok and typeof(nome) == "string" and #nome > 0 then
		local formatado = string.format("%s  (@%s)", nome, nome)
		nomesCache[userId] = formatado
		return formatado
	end
	return string.format("Jogador_%d", userId)
end

local function salvarRecordeNoDataStore(recorde: RecordeJogador)
	local score = calcularScore(recorde.Acertos, recorde.Tempo)
	if score <= 0 then
		return
	end
	local userKey = tostring(recorde.UserId)

	pcall(function()
		local orderedStore = DataStoreService:GetOrderedDataStore(NOME_ORDERED_STORE)
		orderedStore:SetAsync(userKey, score)
	end)

	pcall(function()
		local statsStore = DataStoreService:GetDataStore(NOME_STATS_STORE)
		statsStore:SetAsync(userKey, {
			UserId = recorde.UserId,
			DisplayName = recorde.DisplayName,
			Name = recorde.Name,
			Acertos = recorde.Acertos,
			Tempo = recorde.Tempo,
			Timestamp = recorde.Timestamp,
		})
	end)

	-- Propaga a atualização instantaneamente para todos os servidores via MessagingService
	pcall(function()
		MessagingService:PublishAsync(TOPICO_RANKING_GLOBAL, {
			UserId = recorde.UserId,
			Acertos = recorde.Acertos,
			Tempo = recorde.Tempo,
			Timestamp = os.time(),
		})
	end)
end

local function obterOuCriarParte(): BasePart
	local encontrada = Workspace:FindFirstChild(QuizConfig.NOME_QUADRO_LEADERBOARD, true)
	local part: BasePart
	if encontrada and encontrada:IsA("BasePart") then
		part = encontrada
	else
		part = Instance.new("Part")
		part.Name = QuizConfig.NOME_QUADRO_LEADERBOARD
		part.Parent = Workspace
	end

	part.Name = QuizConfig.NOME_QUADRO_LEADERBOARD
	part.Anchored = true
	part.CanCollide = false
	part.CanTouch = false
	part.CanQuery = false
	part.CastShadow = false
	part.Material = Enum.Material.SmoothPlastic
	part.Color = Color3.fromRGB(16, 23, 38)
	part.Size = TAMANHO_PLACAR
	local centroDoPainel = POSICAO_PLACAR + DIRECAO_PLACAR * DISTANCIA_DESTAQUE
	part.CFrame = CFrame.lookAt(centroDoPainel, centroDoPainel + DIRECAO_PLACAR)
	return part
end

local part = obterOuCriarParte()

local modeloExistente = Workspace:FindFirstChild(NOME_MODELO_PERSISTENTE)
if modeloExistente and not modeloExistente:IsA("Model") then
	modeloExistente:Destroy()
	modeloExistente = nil
end

local modeloPersistente: Model
if modeloExistente and modeloExistente:IsA("Model") then
	modeloPersistente = modeloExistente
else
	modeloPersistente = Instance.new("Model")
	modeloPersistente.Name = NOME_MODELO_PERSISTENTE
end
modeloPersistente.ModelStreamingMode = Enum.ModelStreamingMode.Persistent
modeloPersistente.Parent = nil
part.Parent = modeloPersistente

local molduraAntiga = Workspace:FindFirstChild("LeaderboardPhysicalFrame", true)
if molduraAntiga then
	molduraAntiga:Destroy()
end

local moldura = Instance.new("Model")
moldura.Name = "LeaderboardPhysicalFrame"
moldura.ModelStreamingMode = Enum.ModelStreamingMode.Atomic
moldura.Parent = modeloPersistente

local function criarPecaMoldura(nome: string, tamanho: Vector3, deslocamento: CFrame, cor: Color3, material: Enum.Material, formato: Enum.PartType?)
	local peca = Instance.new("Part")
	peca.Name = nome
	peca.Anchored = true
	peca.CanCollide = false
	peca.CanTouch = false
	peca.CanQuery = false
	peca.CastShadow = true
	peca.Material = material
	peca.Color = cor
	peca.Size = tamanho
	if formato then
		peca.Shape = formato
	end
	peca.CFrame = part.CFrame * deslocamento
	peca.Parent = moldura
	return peca
end

local grafite = Color3.fromRGB(24, 34, 49)
local metalDourado = Color3.fromRGB(181, 132, 42)
criarPecaMoldura(
	"Housing",
	Vector3.new(13.8, 9.8, 0.9),
	CFrame.new(0, 0, 0.25),
	grafite,
	Enum.Material.Metal
)

local profundidadeAro = -0.38
local aroAltura = 0.28
local aroLargura = 0.28
local aroEspessura = 0.24
criarPecaMoldura(
	"TopRail",
	Vector3.new(13.9, aroAltura, aroEspessura),
	CFrame.new(0, 4.79, profundidadeAro),
	metalDourado,
	Enum.Material.Metal
)
criarPecaMoldura(
	"BottomRail",
	Vector3.new(13.9, aroAltura, aroEspessura),
	CFrame.new(0, -4.79, profundidadeAro),
	metalDourado,
	Enum.Material.Metal
)
criarPecaMoldura(
	"LeftRail",
	Vector3.new(aroLargura, 9.55, aroEspessura),
	CFrame.new(-6.79, 0, profundidadeAro),
	metalDourado,
	Enum.Material.Metal
)
criarPecaMoldura(
	"RightRail",
	Vector3.new(aroLargura, 9.55, aroEspessura),
	CFrame.new(6.79, 0, profundidadeAro),
	metalDourado,
	Enum.Material.Metal
)

for indice, x in ipairs({ -6.79, 6.79 }) do
	for _, y in ipairs({ -4.79, 4.79 }) do
		criarPecaMoldura(
			string.format("MountBolt%d_%d", indice, y < 0 and 1 or 2),
			Vector3.new(0.09, 0.16, 0.16),
			CFrame.new(x, y, profundidadeAro - 0.015) * CFrame.Angles(0, math.rad(90), 0),
			Color3.fromRGB(222, 192, 117),
			Enum.Material.Metal,
			Enum.PartType.Cylinder
		)
	end
end

local antigo = part:FindFirstChild("LeaderboardSurfaceGui")
if antigo then
	antigo:Destroy()
end

local surface = Instance.new("SurfaceGui")
surface.Name = "LeaderboardSurfaceGui"
surface.Face = Enum.NormalId.Front
surface.SizingMode = Enum.SurfaceGuiSizingMode.FixedSize
surface.CanvasSize = Vector2.new(1000, 700)
surface.LightInfluence = 0
surface.AlwaysOnTop = false
surface.MaxDistance = 0
surface.ZOffset = 1
surface.Parent = part

local main = Instance.new("Frame")
main.Name = "MainFrame"
main.Size = UDim2.fromScale(1, 1)
main.BorderSizePixel = 0
main.BackgroundColor3 = Color3.fromRGB(13, 22, 38)
main.BackgroundTransparency = 0.2
main.Parent = surface

local mainCorner = Instance.new("UICorner")
mainCorner.CornerRadius = UDim.new(0, 22)
mainCorner.Parent = main

local outerStroke = Instance.new("UIStroke")
outerStroke.Color = Color3.fromRGB(255, 204, 59)
outerStroke.Transparency = 0.12
outerStroke.Thickness = 4
outerStroke.Parent = main

local title = Instance.new("TextLabel")
title.Name = "Title"
title.Size = UDim2.new(1, -40, 0, 66)
title.Position = UDim2.fromOffset(20, 16)
title.BackgroundTransparency = 1
title.Font = Enum.Font.GothamBlack
title.Text = "🏆 RANKING GLOBAL 🏆"
title.TextColor3 = Color3.fromRGB(255, 220, 105)
title.TextSize = 38
title.TextXAlignment = Enum.TextXAlignment.Left
title.Parent = main

local titleConstraint = Instance.new("UITextSizeConstraint")
titleConstraint.MinTextSize = 22
titleConstraint.MaxTextSize = 38
titleConstraint.Parent = title

local subtitle = Instance.new("TextLabel")
subtitle.Name = "Subtitle"
subtitle.Size = UDim2.new(1, -40, 0, 32)
subtitle.Position = UDim2.fromOffset(20, 76)
subtitle.BackgroundTransparency = 1
subtitle.Font = Enum.Font.GothamMedium
subtitle.Text = "TOP 10 · TODOS OS SERVIDORES"
subtitle.TextColor3 = Color3.fromRGB(193, 207, 228)
subtitle.TextSize = 20
subtitle.TextXAlignment = Enum.TextXAlignment.Left
subtitle.Parent = main

local columns = Instance.new("Frame")
columns.Name = "Columns"
columns.Size = UDim2.new(1, -40, 0, 42)
columns.Position = UDim2.fromOffset(20, 120)
columns.BackgroundTransparency = 1
columns.Parent = main

local function makeColumn(name: string, text: string, size: UDim2, position: UDim2, alignment: Enum.TextXAlignment)
	local label = Instance.new("TextLabel")
	label.Name = name
	label.Text = text
	label.Size = size
	label.Position = position
	label.BackgroundTransparency = 1
	label.Font = Enum.Font.GothamBold
	label.TextColor3 = Color3.fromRGB(183, 200, 222)
	label.TextSize = 19
	label.TextXAlignment = alignment
	label.Parent = columns
	local constraint = Instance.new("UITextSizeConstraint")
	constraint.MinTextSize = 14
	constraint.MaxTextSize = 19
	constraint.Parent = label
	return label
end

makeColumn("PositionHeader", "#", UDim2.new(0, 60, 1, 0), UDim2.new(0, 0, 0, 0), Enum.TextXAlignment.Center)
makeColumn("NameHeader", "JOGADOR", UDim2.new(0, 470, 1, 0), UDim2.new(0, 70, 0, 0), Enum.TextXAlignment.Left)
makeColumn("ScoreHeader", "ACERTOS", UDim2.new(0, 180, 1, 0), UDim2.new(0, 550, 0, 0), Enum.TextXAlignment.Right)
makeColumn("TimeHeader", "TEMPO", UDim2.new(0, 240, 1, 0), UDim2.new(0, 710, 0, 0), Enum.TextXAlignment.Right)

local list = Instance.new("Frame")
list.Name = "Rows"
list.Size = UDim2.new(1, -40, 1, -174)
list.Position = UDim2.fromOffset(20, 170)
list.BackgroundTransparency = 1
list.Parent = main

local layout = Instance.new("UIListLayout")
layout.Name = "RowsLayout"
layout.SortOrder = Enum.SortOrder.LayoutOrder
layout.Padding = UDim.new(0, 6)
layout.Parent = list

local rows: { Frame } = {}
for index = 1, MAX_JOGADORES do
	local row = Instance.new("Frame")
	row.Name = "Row" .. index
	row.Size = UDim2.new(1, 0, 0, 47)
	row.BorderSizePixel = 0
	row.LayoutOrder = index
	row.BackgroundColor3 = index % 2 == 1 and Color3.fromRGB(27, 43, 64) or Color3.fromRGB(18, 34, 55)
	row.BackgroundTransparency = 0.22
	row.Visible = false
	row.Parent = list

	local corner = Instance.new("UICorner")
	corner.CornerRadius = UDim.new(0, 10)
	corner.Parent = row

	local rank = Instance.new("TextLabel")
	rank.Name = "Rank"
	rank.Size = UDim2.new(0, 60, 1, 0)
	rank.BackgroundTransparency = 1
	rank.Font = Enum.Font.GothamBlack
	rank.TextColor3 = Color3.fromRGB(255, 222, 112)
	rank.TextSize = 24
	rank.TextXAlignment = Enum.TextXAlignment.Center
	rank.Parent = row

	local name = Instance.new("TextLabel")
	name.Name = "PlayerName"
	name.Size = UDim2.new(0, 470, 1, 0)
	name.Position = UDim2.new(0, 70, 0, 0)
	name.BackgroundTransparency = 1
	name.Font = Enum.Font.GothamBold
	name.TextColor3 = Color3.fromRGB(247, 249, 253)
	name.TextSize = 23
	name.TextXAlignment = Enum.TextXAlignment.Left
	name.TextTruncate = Enum.TextTruncate.AtEnd
	name.Parent = row

	local score = Instance.new("TextLabel")
	score.Name = "Score"
	score.Size = UDim2.new(0, 180, 1, 0)
	score.Position = UDim2.new(0, 550, 0, 0)
	score.BackgroundTransparency = 1
	score.Font = Enum.Font.GothamBlack
	score.TextColor3 = Color3.fromRGB(255, 255, 255)
	score.TextSize = 24
	score.TextXAlignment = Enum.TextXAlignment.Right
	score.Parent = row

	local time = Instance.new("TextLabel")
	time.Name = "CompletionTime"
	time.Size = UDim2.new(0, 240, 1, 0)
	time.Position = UDim2.new(0, 710, 0, 0)
	time.BackgroundTransparency = 1
	time.Font = Enum.Font.GothamBold
	time.TextColor3 = Color3.fromRGB(197, 224, 255)
	time.TextSize = 20
	time.TextXAlignment = Enum.TextXAlignment.Right
	time.Parent = row

	for _, label in ipairs({ rank, name, score, time }) do
		local constraint = Instance.new("UITextSizeConstraint")
		constraint.MinTextSize = 15
		constraint.MaxTextSize = 25
		constraint.Parent = label
	end
	rows[index] = row
end

local empty = Instance.new("TextLabel")
empty.Name = "Empty"
empty.Size = UDim2.new(1, 0, 0, 52)
empty.BackgroundTransparency = 1
empty.Font = Enum.Font.GothamMedium
empty.Text = "Carregando recordes..."
empty.TextColor3 = Color3.fromRGB(216, 228, 242)
empty.TextSize = 23
empty.Parent = list

local function obterListaOrdenada(): { EntradaRanking }
	local entradas: { EntradaRanking } = {}

	-- 1. Tenta buscar do OrderedDataStore (Ranking Global persistente)
	local sucesso, paginas = pcall(function()
		local orderedStore = DataStoreService:GetOrderedDataStore(NOME_ORDERED_STORE)
		return orderedStore:GetSortedAsync(false, MAX_JOGADORES)
	end)

	if sucesso and paginas then
		local dados = paginas:GetCurrentPage()
		for _, item in ipairs(dados) do
			local uid = tonumber(item.key)
			local val = tonumber(item.value)
			if uid and val and val > 0 then
				local acertos, tempo = decodificarScore(val)
				table.insert(entradas, {
					UserId = uid,
					NomeFormatado = obterNomeFormatado(uid),
					Pontos = acertos,
					TempoConclusao = tempo,
				})
			end
		end
	end

	-- 2. Fallback caso DataStore esteja indisponível (ex: Studio offline) ou sem dados ainda
	if #entradas == 0 then
		for _, rec in pairs(recordesLocais) do
			if rec.Acertos > 0 then
				table.insert(entradas, {
					UserId = rec.UserId,
					NomeFormatado = string.format("%s  (@%s)", rec.DisplayName, rec.Name),
					Pontos = rec.Acertos,
					TempoConclusao = rec.Tempo,
				})
			end
		end
		table.sort(entradas, function(a, b)
			if a.Pontos ~= b.Pontos then
				return a.Pontos > b.Pontos
			end
			if a.TempoConclusao ~= b.TempoConclusao then
				if a.TempoConclusao == nil then return false end
				if b.TempoConclusao == nil then return true end
				return a.TempoConclusao < b.TempoConclusao
			end
			return a.NomeFormatado < b.NomeFormatado
		end)
	end

	return entradas
end

local function atualizarPlaca()
	local dados = obterListaOrdenada()
	empty.Visible = #dados == 0
	empty.Text = #dados == 0 and "Aguardando recordes..." or ""

	for index, row in ipairs(rows) do
		local entry = dados[index]
		row.Visible = entry ~= nil
		if entry then
			local rank = row:FindFirstChild("Rank") :: TextLabel
			local name = row:FindFirstChild("PlayerName") :: TextLabel
			local score = row:FindFirstChild("Score") :: TextLabel
			local time = row:FindFirstChild("CompletionTime") :: TextLabel

			rank.Text = string.format("%02d", index)
			name.Text = entry.NomeFormatado
			score.Text = string.format("%d/%d", entry.Pontos, QuizConfig.MAX_ACERTOS)

			if entry.TempoConclusao then
				local totalMilissegundos = math.floor(entry.TempoConclusao * 1000 + 0.5)
				local minutos = math.floor(totalMilissegundos / 60000)
				local segundos = math.floor(totalMilissegundos / 1000) % 60
				local milissegundos = totalMilissegundos % 1000
				time.Text = string.format("%02d:%02d.%03d", minutos, segundos, milissegundos)
			else
				time.Text = "--:--.---"
			end
		end
	end
end

local function carregarRecordeJogador(player: Player)
	local userId = player.UserId
	nomesCache[userId] = string.format("%s  (@%s)", player.DisplayName, player.Name)

	local recorde: RecordeJogador? = nil
	local ok, dados = pcall(function()
		local statsStore = DataStoreService:GetDataStore(NOME_STATS_STORE)
		return statsStore:GetAsync(tostring(userId))
	end)

	if ok and typeof(dados) == "table" and typeof(dados.Acertos) == "number" then
		recorde = {
			UserId = userId,
			DisplayName = player.DisplayName,
			Name = player.Name,
			Acertos = math.clamp(math.floor(dados.Acertos), 0, QuizConfig.MAX_ACERTOS),
			Tempo = typeof(dados.Tempo) == "number" and dados.Tempo or nil,
			Timestamp = typeof(dados.Timestamp) == "number" and dados.Timestamp or os.time(),
		}
	else
		recorde = {
			UserId = userId,
			DisplayName = player.DisplayName,
			Name = player.Name,
			Acertos = 0,
			Tempo = nil,
			Timestamp = os.time(),
		}
	end

	recordesLocais[userId] = recorde
	player:SetAttribute("RecordeAcertosQuiz", recorde.Acertos)
	player:SetAttribute("RecordeTempoQuiz", recorde.Tempo)
end

local function verificarAtualizacaoRecorde(player: Player)
	-- Apenas jogadores no Modo Com Cronômetro (Ranqueado) disputam a Leaderboard Global
	if player:GetAttribute("ModoComCronometro") ~= true then
		return
	end

	local userId = player.UserId
	local recordeAtual = recordesLocais[userId]
	if not recordeAtual then
		return
	end

	local acertosTentativa = player:GetAttribute("AcertosQuiz")
	if typeof(acertosTentativa) ~= "number" then
		acertosTentativa = 0
	end
	acertosTentativa = math.clamp(math.floor(acertosTentativa), 0, QuizConfig.MAX_ACERTOS)

	local tempoTentativa = player:GetAttribute("TempoConclusaoQuiz")
	if typeof(tempoTentativa) ~= "number" or tempoTentativa <= 0 then
		tempoTentativa = nil
	end

	local eNovoRecorde = false
	if acertosTentativa > recordeAtual.Acertos then
		eNovoRecorde = true
	elseif acertosTentativa == recordeAtual.Acertos and acertosTentativa > 0 then
		if tempoTentativa and (recordeAtual.Tempo == nil or tempoTentativa < recordeAtual.Tempo) then
			eNovoRecorde = true
		end
	end

	if eNovoRecorde then
		recordeAtual.Acertos = acertosTentativa
		recordeAtual.Tempo = tempoTentativa
		recordeAtual.Timestamp = os.time()
		player:SetAttribute("RecordeAcertosQuiz", acertosTentativa)
		player:SetAttribute("RecordeTempoQuiz", tempoTentativa)
		pendenteSalvar[userId] = true

		local agora = os.clock()
		local ultimo = debounceSalvar[userId] or 0
		if agora - ultimo > 5 then
			debounceSalvar[userId] = agora
			task.defer(function()
				salvarRecordeNoDataStore(recordeAtual)
				pendenteSalvar[userId] = nil
				atualizarPlaca()
			end)
		end
	end
end

local function observarJogador(player: Player)
	carregarRecordeJogador(player)
	player:GetAttributeChangedSignal("AcertosQuiz"):Connect(function()
		verificarAtualizacaoRecorde(player)
	end)
	player:GetAttributeChangedSignal("TempoConclusaoQuiz"):Connect(function()
		verificarAtualizacaoRecorde(player)
	end)
end

Players.PlayerAdded:Connect(observarJogador)
Players.PlayerRemoving:Connect(function(player)
	local uid = player.UserId
	local rec = recordesLocais[uid]
	if rec and pendenteSalvar[uid] then
		salvarRecordeNoDataStore(rec)
		pendenteSalvar[uid] = nil
	end
	recordesLocais[uid] = nil
	debounceSalvar[uid] = nil
	task.defer(atualizarPlaca)
end)

for _, player in ipairs(Players:GetPlayers()) do
	observarJogador(player)
end

-- Sincronização em tempo real entre todos os servidores via MessagingService
pcall(function()
	MessagingService:SubscribeAsync(TOPICO_RANKING_GLOBAL, function(mensagem)
		task.delay(1.5, function()
			atualizarPlaca()
		end)
	end)
end)

-- Ciclo de atualização global periódico
task.spawn(function()
	while true do
		atualizarPlaca()
		task.wait(INTERVALO_ATUALIZACAO_GLOBAL)
	end
end)

-- Garante salvar jogadores ao fechar servidor
game:BindToClose(function()
	for uid, rec in pairs(recordesLocais) do
		if pendenteSalvar[uid] then
			salvarRecordeNoDataStore(rec)
			pendenteSalvar[uid] = nil
		end
	end
end)

-- Publica o conjunto já montado como uma única unidade persistente no mapa
modeloPersistente.Parent = Workspace
