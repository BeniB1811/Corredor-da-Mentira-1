--!strict
-- Placar do servidor atual. Atualiza quando pontuação ou conclusão mudam.
local Players = game:GetService("Players")
local ReplicatedStorage = game:GetService("ReplicatedStorage")
local Workspace = game:GetService("Workspace")

local QuizConfig = require(ReplicatedStorage:WaitForChild("QuizConfig"))

-- Marca preta da imagem, na face interna da Grey Wall voltada para o percurso.
-- O ponto mantém a posição na parede; o painel avança 1,25 studs para o percurso.
local POSICAO_PLACAR = Vector3.new(367, 1052.5, 61.15)
local DIRECAO_PLACAR = Vector3.new(0, 0, -1)
local DISTANCIA_DESTAQUE = 1.25
local TAMANHO_PLACAR = Vector3.new(13, 9, 0.46)
local MAX_JOGADORES = 10
local NOME_MODELO_PERSISTENTE = "LeaderboardPersistentDisplay"

type EntradaRanking = {
	Player: Player,
	Pontos: number,
	TempoConclusao: number?,
}

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

-- O controlador local precisa encontrar a placa mesmo quando ela está fora do
-- raio de streaming do personagem. O modelo contém apenas os componentes do
-- painel e permanece disponível sem desativar a oclusão normal por paredes.
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

-- Moldura 3D presa ao mesmo plano e orientação da tela. As barras ficam
-- fora do canvas para manter a leitura da SurfaceGui desobstruída.
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
-- A visibilidade por jogador é controlada localmente, incluindo as peças físicas.
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
title.Text = "CLASSIFICAÇÃO"
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
subtitle.Text = "RODADA ATUAL"
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
empty.Text = "Aguardando jogadores..."
empty.TextColor3 = Color3.fromRGB(216, 228, 242)
empty.TextSize = 23
empty.Parent = list

local function obterListaOrdenada(): { EntradaRanking }
	local dados: { EntradaRanking } = {}
	for _, player in ipairs(Players:GetPlayers()) do
		local pontos = player:GetAttribute("AcertosQuiz")
		if typeof(pontos) ~= "number" then
			pontos = 0
		end
		local tempoConclusao = player:GetAttribute("TempoConclusaoQuiz")
		if typeof(tempoConclusao) ~= "number" or tempoConclusao < 0 then
			tempoConclusao = nil
		end
		table.insert(dados, {
			Player = player,
			Pontos = math.clamp(math.floor(pontos), 0, QuizConfig.MAX_ACERTOS),
			TempoConclusao = tempoConclusao,
		})
	end
	table.sort(dados, function(a, b)
		if a.Pontos ~= b.Pontos then
			return a.Pontos > b.Pontos
		end
		if a.TempoConclusao ~= b.TempoConclusao then
			if a.TempoConclusao == nil then return false end
			if b.TempoConclusao == nil then return true end
			return a.TempoConclusao < b.TempoConclusao
		end
		local nomeA = string.lower(a.Player.Name)
		local nomeB = string.lower(b.Player.Name)
		return nomeA < nomeB
	end)
	return dados
end

local function atualizar()
	local dados = obterListaOrdenada()
	empty.Visible = #dados == 0
	for index, row in ipairs(rows) do
		local entry = dados[index]
		row.Visible = entry ~= nil
		if entry then
			local rank = row:FindFirstChild("Rank") :: TextLabel
			local name = row:FindFirstChild("PlayerName") :: TextLabel
			local score = row:FindFirstChild("Score") :: TextLabel
			local time = row:FindFirstChild("CompletionTime") :: TextLabel
			rank.Text = string.format("%02d", index)
			name.Text = string.format("%s  (@%s)", entry.Player.DisplayName, entry.Player.Name)
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

local function observarJogador(player: Player)
	player:GetAttributeChangedSignal("AcertosQuiz"):Connect(atualizar)
	player:GetAttributeChangedSignal("TempoConclusaoQuiz"):Connect(atualizar)
	atualizar()
end

Players.PlayerAdded:Connect(observarJogador)
Players.PlayerRemoving:Connect(function()
	task.defer(atualizar)
end)
for _, player in ipairs(Players:GetPlayers()) do
	observarJogador(player)
end
atualizar()
-- Publica o conjunto já montado como uma única unidade persistente.
modeloPersistente.Parent = Workspace
