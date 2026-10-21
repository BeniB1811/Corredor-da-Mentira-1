--!strict
-- Interface responsiva: o cliente só exibe estado e envia escolhas; não calcula pontuação nem libera o portão.
local Players = game:GetService("Players")
local ReplicatedStorage = game:GetService("ReplicatedStorage")
local RunService = game:GetService("RunService")
local StarterGui = game:GetService("StarterGui")
local TweenService = game:GetService("TweenService")
local Workspace = game:GetService("Workspace")

local QuizConfig = require(ReplicatedStorage:WaitForChild("QuizConfig"))

local player = Players.LocalPlayer
local playerGui = player:WaitForChild("PlayerGui")
local screenGui = playerGui:WaitForChild("ScreenGui", 30) :: ScreenGui?
if not screenGui then
	warn("[QuizClient] ScreenGui não foi encontrada.")
	return
end

-- O botão personalizado encerra a tentativa e a respawn pode recriar a cópia
-- de PlayerGui a partir do modelo em StarterGui. Desative o reset no modelo
-- também para manter o HUD criado por este LocalScript após renascer.
local starterScreenGui = StarterGui:FindFirstChild("ScreenGui")
if starterScreenGui and starterScreenGui:IsA("ScreenGui") then
	starterScreenGui.ResetOnSpawn = false
end
screenGui.ResetOnSpawn = false
screenGui.IgnoreGuiInset = false

local frame = screenGui:WaitForChild("Frame das perguntas", 30) :: Frame?
if not frame then
	warn("[QuizClient] Frame das perguntas não foi encontrada.")
	return
end
local perguntaLabel = frame:WaitForChild("Pergunta") :: TextLabel
local fecharBotao = frame:WaitForChild("Fechar") :: TextButton
local botoesResposta = {
	frame:WaitForChild("Resposta 1") :: TextButton,
	frame:WaitForChild("Resposta 2") :: TextButton,
	frame:WaitForChild("Resposta 3") :: TextButton,
}

local pastaRemotes = ReplicatedStorage:WaitForChild("QuizRemotes", 30)
if not pastaRemotes then
	warn("[QuizClient] Pasta QuizRemotes não encontrada.")
	return
end
local AbrirQuiz = pastaRemotes:WaitForChild("AbrirQuiz") :: RemoteEvent
local EnviarResposta = pastaRemotes:WaitForChild("EnviarResposta") :: RemoteFunction
local SincronizarRodada = pastaRemotes:WaitForChild("SincronizarRodada") :: RemoteEvent
local FimDeRodada = pastaRemotes:WaitForChild("FimDeRodada") :: RemoteEvent
local ControlarPorta = pastaRemotes:WaitForChild("ControlarPorta") :: RemoteEvent
local ResetarClient = pastaRemotes:WaitForChild("ResetarClient") :: RemoteEvent
local NotificarMensagem = pastaRemotes:WaitForChild("NotificarMensagem") :: RemoteEvent
local SolicitarReset = pastaRemotes:WaitForChild("SolicitarReset") :: RemoteEvent
local ObterEstadoRodada = pastaRemotes:WaitForChild("ObterEstadoRodada") :: RemoteFunction
local DefinirModoJogo = pastaRemotes:WaitForChild(QuizConfig.NOME_REMOTE_MODO or "DefinirModoJogo", 15) :: RemoteEvent?

local function getOrCreateTextLabel(name: string): TextLabel
	local label = screenGui:FindFirstChild(name)
	if label and label:IsA("TextLabel") then
		return label
	end
	if label then
		label:Destroy()
	end
	local created = Instance.new("TextLabel")
	created.Name = name
	created.Parent = screenGui
	return created
end

local timerLabel = getOrCreateTextLabel("ContadorGeralRodada")
timerLabel.AnchorPoint = Vector2.new(0.5, 0)
timerLabel.Position = UDim2.new(0.5, 0, 0, 6)
timerLabel.Size = UDim2.fromOffset(238, 44)
timerLabel.BackgroundColor3 = Color3.fromRGB(16, 25, 42)
timerLabel.BackgroundTransparency = 0.14
timerLabel.BorderSizePixel = 0
timerLabel.Font = Enum.Font.GothamBlack
timerLabel.Text = "--:--.---"
timerLabel.TextColor3 = Color3.fromRGB(255, 220, 86)
timerLabel.TextScaled = true
timerLabel.ZIndex = 20
local timerConstraint = (timerLabel:FindFirstChildOfClass("UITextSizeConstraint") or Instance.new("UITextSizeConstraint")) :: UITextSizeConstraint
timerConstraint.MinTextSize = 17
timerConstraint.MaxTextSize = 27
timerConstraint.Parent = timerLabel
local timerCorner = (timerLabel:FindFirstChildOfClass("UICorner") or Instance.new("UICorner")) :: UICorner
timerCorner.CornerRadius = UDim.new(0, 12)
timerCorner.Parent = timerLabel
local timerStroke = (timerLabel:FindFirstChildOfClass("UIStroke") or Instance.new("UIStroke")) :: UIStroke
timerStroke.Color = Color3.fromRGB(255, 199, 57)
timerStroke.Thickness = 2
timerStroke.Parent = timerLabel

local statusLabel = getOrCreateTextLabel("EstadoRodada")
statusLabel.AnchorPoint = Vector2.new(0.5, 0)
statusLabel.Position = UDim2.new(0.5, 0, 0, 52)
statusLabel.Size = UDim2.new(0.8, 0, 0, 22)
statusLabel.BackgroundTransparency = 1
statusLabel.Font = Enum.Font.GothamMedium
statusLabel.Text = "Conclua o tutorial para iniciar"
statusLabel.TextColor3 = Color3.fromRGB(230, 239, 251)
statusLabel.TextSize = 15
statusLabel.TextWrapped = true
statusLabel.ZIndex = 20
local statusConstraint = (statusLabel:FindFirstChildOfClass("UITextSizeConstraint") or Instance.new("UITextSizeConstraint")) :: UITextSizeConstraint
statusConstraint.MinTextSize = 12
statusConstraint.MaxTextSize = 16
statusConstraint.Parent = statusLabel

local toastLabel = getOrCreateTextLabel("QuizToastNotification")
toastLabel.AnchorPoint = Vector2.new(0.5, 0)
toastLabel.Position = UDim2.new(0.5, 0, 0, 82)
toastLabel.Size = UDim2.new(0.84, 0, 0, 54)
toastLabel.BackgroundColor3 = Color3.fromRGB(18, 28, 45)
toastLabel.BackgroundTransparency = 0.1
toastLabel.BorderSizePixel = 0
toastLabel.Font = Enum.Font.GothamBold
toastLabel.Text = ""
toastLabel.TextColor3 = Color3.fromRGB(255, 255, 255)
toastLabel.TextSize = 18
toastLabel.TextScaled = false
toastLabel.TextWrapped = true
toastLabel.Visible = false
toastLabel.ZIndex = 25
local toastConstraint = (toastLabel:FindFirstChildOfClass("UISizeConstraint") or Instance.new("UISizeConstraint")) :: UISizeConstraint
toastConstraint.MinSize = Vector2.new(270, 48)
toastConstraint.MaxSize = Vector2.new(520, 66)
toastConstraint.Parent = toastLabel
local toastCorner = (toastLabel:FindFirstChildOfClass("UICorner") or Instance.new("UICorner")) :: UICorner
toastCorner.CornerRadius = UDim.new(0, 12)
toastCorner.Parent = toastLabel
local toastStroke = (toastLabel:FindFirstChildOfClass("UIStroke") or Instance.new("UIStroke")) :: UIStroke
toastStroke.Color = Color3.fromRGB(255, 207, 84)
toastStroke.Thickness = 1.5
toastStroke.Parent = toastLabel

local resetButton = screenGui:FindFirstChild("BotaoResetTentativa")
if resetButton and not resetButton:IsA("TextButton") then
	resetButton:Destroy()
	resetButton = nil
end
if not resetButton then
	resetButton = Instance.new("TextButton")
	resetButton.Name = "BotaoResetTentativa"
	resetButton.Parent = screenGui
end
local reset = resetButton :: TextButton
reset.AnchorPoint = Vector2.new(0, 0)
reset.Position = UDim2.new(0, 16, 0, 6)
reset.Size = UDim2.fromOffset(136, 48)
reset.BackgroundColor3 = Color3.fromRGB(191, 50, 66)
reset.BackgroundTransparency = 0.04
reset.BorderSizePixel = 0
reset.AutoButtonColor = false
reset.Font = Enum.Font.GothamBlack
reset.Text = "↻  RESETAR"
reset.TextColor3 = Color3.fromRGB(255, 255, 255)
reset.TextScaled = true
reset.TextWrapped = true
reset.ZIndex = 20
local resetTextConstraint = (reset:FindFirstChildOfClass("UITextSizeConstraint") or Instance.new("UITextSizeConstraint")) :: UITextSizeConstraint
resetTextConstraint.MinTextSize = 15
resetTextConstraint.MaxTextSize = 21
resetTextConstraint.Parent = reset
local resetCorner = (reset:FindFirstChildOfClass("UICorner") or Instance.new("UICorner")) :: UICorner
resetCorner.CornerRadius = UDim.new(0, 12)
resetCorner.Parent = reset
local resetStroke = (reset:FindFirstChildOfClass("UIStroke") or Instance.new("UIStroke")) :: UIStroke
resetStroke.Color = Color3.fromRGB(255, 188, 195)
resetStroke.Thickness = 1.5
resetStroke.Parent = reset
local resetScale = (reset:FindFirstChildOfClass("UIScale") or Instance.new("UIScale")) :: UIScale
resetScale.Scale = 1
resetScale.Parent = reset

local botaoTrocarModoObj = screenGui:FindFirstChild("BotaoTrocarModo")
if botaoTrocarModoObj and not botaoTrocarModoObj:IsA("TextButton") then
	botaoTrocarModoObj:Destroy()
	botaoTrocarModoObj = nil
end
if not botaoTrocarModoObj then
	botaoTrocarModoObj = Instance.new("TextButton")
	botaoTrocarModoObj.Name = "BotaoTrocarModo"
	botaoTrocarModoObj.Parent = screenGui
end
local botaoTrocarModo = botaoTrocarModoObj :: TextButton
botaoTrocarModo.AnchorPoint = Vector2.new(0, 0)
botaoTrocarModo.Position = UDim2.new(0, 160, 0, 6)
botaoTrocarModo.Size = UDim2.fromOffset(150, 48)
botaoTrocarModo.BackgroundColor3 = Color3.fromRGB(22, 36, 58)
botaoTrocarModo.BackgroundTransparency = 0.08
botaoTrocarModo.BorderSizePixel = 0
botaoTrocarModo.AutoButtonColor = false
botaoTrocarModo.Font = Enum.Font.GothamBlack
botaoTrocarModo.Text = "🎮 MUDAR MODO"
botaoTrocarModo.TextColor3 = Color3.fromRGB(255, 222, 105)
botaoTrocarModo.TextScaled = true
botaoTrocarModo.TextWrapped = true
botaoTrocarModo.ZIndex = 20

local trocarModoTextConstraint = (botaoTrocarModo:FindFirstChildOfClass("UITextSizeConstraint") or Instance.new("UITextSizeConstraint")) :: UITextSizeConstraint
trocarModoTextConstraint.MinTextSize = 12
trocarModoTextConstraint.MaxTextSize = 17
trocarModoTextConstraint.Parent = botaoTrocarModo

local trocarModoCorner = (botaoTrocarModo:FindFirstChildOfClass("UICorner") or Instance.new("UICorner")) :: UICorner
trocarModoCorner.CornerRadius = UDim.new(0, 12)
trocarModoCorner.Parent = botaoTrocarModo

local trocarModoStroke = (botaoTrocarModo:FindFirstChildOfClass("UIStroke") or Instance.new("UIStroke")) :: UIStroke
trocarModoStroke.Color = Color3.fromRGB(255, 204, 60)
trocarModoStroke.Thickness = 1.5
trocarModoStroke.Parent = botaoTrocarModo

local trocarModoScale = (botaoTrocarModo:FindFirstChildOfClass("UIScale") or Instance.new("UIScale")) :: UIScale
trocarModoScale.Scale = 1
trocarModoScale.Parent = botaoTrocarModo

local function animarBotaoTrocarModo(pressionado: boolean)
	local info = TweenInfo.new(0.09, Enum.EasingStyle.Quad, Enum.EasingDirection.Out)
	TweenService:Create(trocarModoScale, info, { Scale = pressionado and 0.95 or 1 }):Play()
	TweenService:Create(botaoTrocarModo, info, {
		BackgroundColor3 = pressionado and Color3.fromRGB(15, 25, 42) or Color3.fromRGB(22, 36, 58),
	}):Play()
end
botaoTrocarModo.InputBegan:Connect(function(input)
	if input.UserInputType == Enum.UserInputType.MouseButton1 or input.UserInputType == Enum.UserInputType.Touch then
		animarBotaoTrocarModo(true)
	end
end)
botaoTrocarModo.InputEnded:Connect(function(input)
	if input.UserInputType == Enum.UserInputType.MouseButton1 or input.UserInputType == Enum.UserInputType.Touch then
		animarBotaoTrocarModo(false)
	end
end)

local somPergunta = (screenGui:FindFirstChild("SomPerguntaAparecer") or Instance.new("Sound")) :: Sound
somPergunta.Name = "SomPerguntaAparecer"
somPergunta.SoundId = "rbxassetid://9069609200"
somPergunta.Volume = 0.65
somPergunta.Parent = screenGui

local somAcerto = (screenGui:FindFirstChild("SomAcertoQuiz") or Instance.new("Sound")) :: Sound
somAcerto.Name = "SomAcertoQuiz"
somAcerto.SoundId = "rbxassetid://6026987457"
somAcerto.Volume = 0.7
somAcerto.Parent = screenGui

local somErro = (screenGui:FindFirstChild("SomErroQuiz") or Instance.new("Sound")) :: Sound
somErro.Name = "SomErroQuiz"
somErro.SoundId = "rbxassetid://9069611299"
somErro.Volume = 0.6
somErro.Parent = screenGui

local somClique = (screenGui:FindFirstChild("SomCliqueQuiz") or Instance.new("Sound")) :: Sound
somClique.Name = "SomCliqueQuiz"
somClique.SoundId = "rbxassetid://6895079853"
somClique.Volume = 0.55
somClique.Parent = screenGui

local modalExistente = screenGui:FindFirstChild("ModalSelecaoModo")
if modalExistente then
	modalExistente:Destroy()
end

local modal = Instance.new("Frame")
modal.Name = "ModalSelecaoModo"
modal.Size = UDim2.fromScale(1, 1)
modal.BackgroundColor3 = Color3.fromRGB(8, 14, 25)
modal.BackgroundTransparency = 0.35
modal.BorderSizePixel = 0
modal.Active = true
modal.ZIndex = 45
modal.Visible = false
modal.Parent = screenGui

local card = Instance.new("Frame")
card.Name = "ModalCard"
card.AnchorPoint = Vector2.new(0.5, 0.5)
card.Position = UDim2.fromScale(0.5, 0.5)
card.Size = UDim2.new(0.88, 0, 0.82, 0)
card.BackgroundColor3 = Color3.fromRGB(15, 23, 40)
card.BackgroundTransparency = 0.05
card.BorderSizePixel = 0
card.ZIndex = 46
card.Parent = modal

local cardConstraint = Instance.new("UISizeConstraint")
cardConstraint.MinSize = Vector2.new(310, 380)
cardConstraint.MaxSize = Vector2.new(680, 480)
cardConstraint.Parent = card

local cardCorner = Instance.new("UICorner")
cardCorner.CornerRadius = UDim.new(0, 18)
cardCorner.Parent = card

local cardStroke = Instance.new("UIStroke")
cardStroke.Color = Color3.fromRGB(255, 204, 60)
cardStroke.Thickness = 2.5
cardStroke.Parent = card

local cardScale = Instance.new("UIScale")
cardScale.Name = "CardScale"
cardScale.Scale = 1
cardScale.Parent = card

local fecharModalBtn = Instance.new("TextButton")
fecharModalBtn.Name = "FecharModal"
fecharModalBtn.Size = UDim2.fromOffset(36, 36)
fecharModalBtn.Position = UDim2.new(1, -44, 0, 8)
fecharModalBtn.BackgroundTransparency = 1
fecharModalBtn.Font = Enum.Font.GothamBold
fecharModalBtn.Text = "×"
fecharModalBtn.TextColor3 = Color3.fromRGB(220, 235, 255)
fecharModalBtn.TextSize = 28
fecharModalBtn.ZIndex = 52
fecharModalBtn.Parent = card

local modalTitle = Instance.new("TextLabel")
modalTitle.Name = "Title"
modalTitle.Size = UDim2.new(1, -24, 0, 36)
modalTitle.Position = UDim2.fromOffset(12, 12)
modalTitle.BackgroundTransparency = 1
modalTitle.Font = Enum.Font.GothamBlack
modalTitle.Text = "🎮 ESCOLHA SEU MODO DE JOGO 🎮"
modalTitle.TextColor3 = Color3.fromRGB(255, 222, 105)
modalTitle.TextSize = 22
modalTitle.TextScaled = true
modalTitle.ZIndex = 47
modalTitle.Parent = card

local modalTitleConstraint = Instance.new("UITextSizeConstraint")
modalTitleConstraint.MinTextSize = 16
modalTitleConstraint.MaxTextSize = 25
modalTitleConstraint.Parent = modalTitle

local modalSubtitle = Instance.new("TextLabel")
modalSubtitle.Name = "Subtitle"
modalSubtitle.Size = UDim2.new(1, -24, 0, 24)
modalSubtitle.Position = UDim2.fromOffset(12, 48)
modalSubtitle.BackgroundTransparency = 1
modalSubtitle.Font = Enum.Font.GothamMedium
modalSubtitle.Text = "Selecione como deseja jogar antes de iniciar o tutorial:"
modalSubtitle.TextColor3 = Color3.fromRGB(195, 215, 240)
modalSubtitle.TextSize = 14
modalSubtitle.TextScaled = true
modalSubtitle.ZIndex = 47
modalSubtitle.Parent = card

local modalSubConstraint = Instance.new("UITextSizeConstraint")
modalSubConstraint.MinTextSize = 12
modalSubConstraint.MaxTextSize = 15
modalSubConstraint.Parent = modalSubtitle

local container = Instance.new("Frame")
container.Name = "CardsContainer"
container.Size = UDim2.new(1, -28, 1, -86)
container.Position = UDim2.fromOffset(14, 76)
container.BackgroundTransparency = 1
container.ZIndex = 47
container.Parent = card

local function criarCardOpcao(nome: string, xPos: number, corBorda: Color3, corFundo: Color3, icone: string, titulo: string, badge: string, desc: string, textoBtn: string, corBtn: Color3, textoCorBtn: Color3): TextButton
	local optFrame = Instance.new("Frame")
	optFrame.Name = nome
	optFrame.Size = UDim2.new(0.485, 0, 1, 0)
	optFrame.Position = UDim2.new(xPos, 0, 0, 0)
	optFrame.BackgroundColor3 = corFundo
	optFrame.BackgroundTransparency = 0.12
	optFrame.BorderSizePixel = 0
	optFrame.ZIndex = 48
	optFrame.Parent = container

	local optCorner = Instance.new("UICorner")
	optCorner.CornerRadius = UDim.new(0, 14)
	optCorner.Parent = optFrame

	local optStroke = Instance.new("UIStroke")
	optStroke.Color = corBorda
	optStroke.Thickness = 2
	optStroke.Parent = optFrame

	local optTitle = Instance.new("TextLabel")
	optTitle.Name = "OptTitle"
	optTitle.Size = UDim2.new(1, -16, 0, 30)
	optTitle.Position = UDim2.fromOffset(8, 8)
	optTitle.BackgroundTransparency = 1
	optTitle.Font = Enum.Font.GothamBlack
	optTitle.Text = icone .. " " .. titulo
	optTitle.TextColor3 = corBorda
	optTitle.TextSize = 17
	optTitle.TextScaled = true
	optTitle.ZIndex = 49
	optTitle.Parent = optFrame

	local optBadge = Instance.new("TextLabel")
	optBadge.Name = "OptBadge"
	optBadge.Size = UDim2.new(1, -16, 0, 20)
	optBadge.Position = UDim2.fromOffset(8, 38)
	optBadge.BackgroundTransparency = 1
	optBadge.Font = Enum.Font.GothamBold
	optBadge.Text = badge
	optBadge.TextColor3 = Color3.fromRGB(255, 235, 150)
	optBadge.TextSize = 12
	optBadge.TextScaled = true
	optBadge.ZIndex = 49
	optBadge.Parent = optFrame

	local optDesc = Instance.new("TextLabel")
	optDesc.Name = "OptDesc"
	optDesc.Size = UDim2.new(1, -20, 1, -114)
	optDesc.Position = UDim2.fromOffset(10, 62)
	optDesc.BackgroundTransparency = 1
	optDesc.Font = Enum.Font.GothamMedium
	optDesc.Text = desc
	optDesc.TextColor3 = Color3.fromRGB(225, 235, 250)
	optDesc.TextSize = 13
	optDesc.TextWrapped = true
	optDesc.TextXAlignment = Enum.TextXAlignment.Left
	optDesc.TextYAlignment = Enum.TextYAlignment.Top
	optDesc.ZIndex = 49
	optDesc.Parent = optFrame

	local optBtn = Instance.new("TextButton")
	optBtn.Name = "BtnEscolher"
	optBtn.Size = UDim2.new(1, -20, 0, 42)
	optBtn.Position = UDim2.new(0, 10, 1, -48)
	optBtn.BackgroundColor3 = corBtn
	optBtn.BorderSizePixel = 0
	optBtn.AutoButtonColor = false
	optBtn.Font = Enum.Font.GothamBlack
	optBtn.Text = textoBtn
	optBtn.TextColor3 = textoCorBtn
	optBtn.TextSize = 15
	optBtn.TextScaled = true
	optBtn.ZIndex = 50
	optBtn.Parent = optFrame

	local btnCorner = Instance.new("UICorner")
	btnCorner.CornerRadius = UDim.new(0, 10)
	btnCorner.Parent = optBtn

	local btnStroke = Instance.new("UIStroke")
	btnStroke.Color = Color3.fromRGB(255, 255, 255)
	btnStroke.Transparency = 0.5
	btnStroke.Thickness = 1.5
	btnStroke.Parent = optBtn

	local btnScale = Instance.new("UIScale")
	btnScale.Scale = 1
	btnScale.Parent = optBtn

	optBtn.MouseEnter:Connect(function()
		TweenService:Create(btnScale, TweenInfo.new(0.12), { Scale = 1.04 }):Play()
	end)
	optBtn.MouseLeave:Connect(function()
		TweenService:Create(btnScale, TweenInfo.new(0.12), { Scale = 1.0 }):Play()
	end)

	return optBtn
end

local btnCom = criarCardOpcao(
	"OpcaoComCronometro",
	0,
	Color3.fromRGB(255, 195, 55),
	Color3.fromRGB(28, 42, 68),
	"⏱️",
	"COM CRONÔMETRO",
	"[ 🏆 RANKING GLOBAL ]",
	"• 10 minutos para concluir o quiz\n• Cronômetro visível no topo da tela\n• Seus acertos e tempo disputam o Top 10 Mundial!\n• Desafie seus amigos e bata recordes!",
	"JOGAR COM CRONÔMETRO",
	Color3.fromRGB(255, 185, 45),
	Color3.fromRGB(15, 20, 35)
)

local btnSem = criarCardOpcao(
	"OpcaoSemCronometro",
	0.515,
	Color3.fromRGB(50, 220, 175),
	Color3.fromRGB(18, 45, 52),
	"🎯",
	"SEM CRONÔMETRO",
	"[ 🌟 MODO LIVRE ]",
	"• Jogue no seu próprio ritmo\n• Sem limite de tempo para responder\n• Cronômetro oculto no topo da tela\n• Ideal para aprender e praticar!",
	"JOGAR SEM CRONÔMETRO",
	Color3.fromRGB(45, 195, 150),
	Color3.fromRGB(10, 25, 25)
)

local modalAberto = false
local function mostrarModalModo()
	if modalAberto then
		return
	end
	modalAberto = true
	modal.Visible = true
	cardScale.Scale = 0.7
	modal.BackgroundTransparency = 1
	TweenService:Create(modal, TweenInfo.new(0.25), { BackgroundTransparency = 0.35 }):Play()
	TweenService:Create(cardScale, TweenInfo.new(0.35, Enum.EasingStyle.Back, Enum.EasingDirection.Out), { Scale = 1.0 }):Play()
end

local function fecharModalModo()
	if not modalAberto then
		return
	end
	modalAberto = false
	local t = TweenService:Create(cardScale, TweenInfo.new(0.2, Enum.EasingStyle.Back, Enum.EasingDirection.In), { Scale = 0.7 })
	TweenService:Create(modal, TweenInfo.new(0.2), { BackgroundTransparency = 1 }):Play()
	t:Play()
	t.Completed:Wait()
	modal.Visible = false
	cardScale.Scale = 1.0
end

fecharModalBtn.Activated:Connect(fecharModalModo)
botaoTrocarModo.Activated:Connect(mostrarModalModo)

local function escolherModo(comCronometro: boolean)
	pcall(function() somClique:Play() end)
	if DefinirModoJogo then
		DefinirModoJogo:FireServer(comCronometro)
	end
	fecharModalModo()
end

btnCom.Activated:Connect(function()
	escolherModo(true)
end)
btnSem.Activated:Connect(function()
	escolherModo(false)
end)

local function formatarTempo(segundos: number): string
	local totalMilissegundos = math.floor(math.max(0, segundos) * 1000 + 0.5)
	local minutos = math.floor(totalMilissegundos / 60000)
	local segundosRestantes = math.floor(totalMilissegundos / 1000) % 60
	local milissegundos = totalMilissegundos % 1000
	return string.format("%02d:%02d.%03d", minutos, segundosRestantes, milissegundos)
end

local function renderizarTempoCongelado(): boolean
	local tempoCongelado = player:GetAttribute("TempoConclusaoQuiz")
	local restanteCongelado = player:GetAttribute("TempoRestanteCongeladoQuiz")
	if typeof(tempoCongelado) ~= "number" or typeof(restanteCongelado) ~= "number" then
		return false
	end
	timerLabel.Text = formatarTempo(tempoCongelado)
	timerLabel.TextColor3 = Color3.fromRGB(120, 235, 165)
	local pontos = tonumber(player:GetAttribute("AcertosQuiz")) or 0
	statusLabel.Text = string.format("%d/20  ·  TEMPO CONGELADO", pontos)
	statusLabel.TextColor3 = Color3.fromRGB(120, 235, 165)
	return true
end

local function aplicarEstadoRodada(dados: any)
	local modoComCronometro = player:GetAttribute("ModoComCronometro")
	if modoComCronometro == false then
		timerLabel.Visible = false
		local tentativa = tonumber(player:GetAttribute("NumeroTentativaQuiz")) or 1
		local fase = typeof(dados) == "table" and dados.Fase or "Tutorial"
		if fase == "Ativa" then
			statusLabel.Text = string.format("MODO LIVRE · RODADA %d", tentativa)
		else
			statusLabel.Text = "MODO LIVRE · SEM CRONÔMETRO"
		end
		statusLabel.TextColor3 = Color3.fromRGB(120, 235, 175)
		return
	end
	timerLabel.Visible = true
	if renderizarTempoCongelado() then
		return
	end
	local fase = typeof(dados) == "table" and dados.Fase or "Tutorial"
	if fase == "Ativa" and typeof(dados.FimRodadaTimestamp) == "number" then
		timerLabel.Text = "00:00.000"
		local tentativa = tonumber(player:GetAttribute("NumeroTentativaQuiz")) or 1
		statusLabel.Text = string.format("RODADA %d", tentativa)
	else
		timerLabel.Text = "--:--.---"
		timerLabel.TextColor3 = Color3.fromRGB(255, 220, 86)
		if fase == "Preparando" then
			statusLabel.Text = "Todos prontos · preparando a rodada"
		elseif fase == "Intervalo" then
			statusLabel.Text = "Intervalo · aguardando tutorial de quem chegou agora"
		else
			local prontos = tonumber(dados.Prontos) or 0
			local total = tonumber(dados.Total) or 0
			if total > 1 and prontos > 0 then
				statusLabel.Text = string.format("Tutorial: %d/%d jogadores prontos", prontos, total)
			else
				statusLabel.Text = "Conclua o tutorial para iniciar"
			end
		end
	end
end

local faseAtual = "Tutorial"
local ultimoTextoPrazoRodada = ""
local ultimoTextoCronometroTentativa = ""

local function atualizarEstado(dados: any)
	if typeof(dados) ~= "table" then
		return
	end
	faseAtual = typeof(dados.Fase) == "string" and dados.Fase or (dados.Ativa and "Ativa" or "Tutorial")
	aplicarEstadoRodada(dados)
end

local toastToken = 0
local toastTween: Tween? = nil
local function mostrarToast(mensagem: string, cor: Color3?)
	toastToken += 1
	local token = toastToken
	if toastTween then
		toastTween:Cancel()
		toastTween = nil
	end
	toastLabel.Text = mensagem
	toastLabel.TextColor3 = cor or Color3.fromRGB(255, 255, 255)
	toastLabel.TextTransparency = 0
	toastLabel.BackgroundTransparency = 0.1
	toastLabel.Visible = true
	task.delay(3.25, function()
		if token ~= toastToken then
			return
		end
		toastTween = TweenService:Create(toastLabel, TweenInfo.new(0.3), {
			BackgroundTransparency = 1,
			TextTransparency = 1,
		})
		toastTween:Play()
		toastTween.Completed:Wait()
		if token == toastToken then
			toastLabel.Visible = false
			toastLabel.TextTransparency = 0
		end
	end)
end
NotificarMensagem.OnClientEvent:Connect(mostrarToast)

local function resetarCoresBotoes()
	for _, button in ipairs(botoesResposta) do
		button.BackgroundColor3 = Color3.fromRGB(255, 255, 255)
		button.AutoButtonColor = true
		button.Active = true
		button.TextTransparency = 0
		button.BackgroundTransparency = 0
	end
end

local frameScale = (frame:FindFirstChild("FrameQuizScale") or Instance.new("UIScale")) :: UIScale
frameScale.Name = "FrameQuizScale"
frameScale.Scale = 1
frameScale.Parent = frame

local respondeuAtual = false
local fecharAnimando = false
local function fecharInterface()
	if not frame.Visible or fecharAnimando then
		frame.Visible = false
		respondeuAtual = false
		resetarCoresBotoes()
		return
	end
	fecharAnimando = true
	local tween = TweenService:Create(frameScale, TweenInfo.new(0.18, Enum.EasingStyle.Back, Enum.EasingDirection.In), {
		Scale = 0.55,
	})
	tween:Play()
	tween.Completed:Wait()
	frame.Visible = false
	frameScale.Scale = 1
	fecharAnimando = false
	respondeuAtual = false
	resetarCoresBotoes()
end

frame.AnchorPoint = Vector2.new(0.5, 0.5)
frame.Position = UDim2.fromScale(0.5, 0.53)
frame.Size = UDim2.new(0.92, 0, 0.78, 0)
frame.Visible = false
local frameConstraint = frame:FindFirstChildOfClass("UISizeConstraint") or Instance.new("UISizeConstraint")
frameConstraint.MinSize = Vector2.new(280, 280)
frameConstraint.MaxSize = Vector2.new(560, 460)
frameConstraint.Parent = frame
perguntaLabel.TextWrapped = true
perguntaLabel.TextScaled = true
perguntaLabel.TextYAlignment = Enum.TextYAlignment.Center
perguntaLabel.AnchorPoint = Vector2.new(0.5, 0)
perguntaLabel.Position = UDim2.new(0.5, 0, 0.03, 0)
perguntaLabel.Size = UDim2.new(0.84, 0, 0.22, 0)
local perguntaSize = perguntaLabel:FindFirstChildOfClass("UITextSizeConstraint") or Instance.new("UITextSizeConstraint")
perguntaSize.MinTextSize = 16
perguntaSize.MaxTextSize = 27
perguntaSize.Parent = perguntaLabel

fecharBotao.AnchorPoint = Vector2.new(1, 0)
fecharBotao.Position = UDim2.new(0.97, 0, 0.02, 0)
fecharBotao.Size = UDim2.new(0.09, 0, 0.12, 0)
fecharBotao.Text = "×"
fecharBotao.TextScaled = true
local closeConstraint = fecharBotao:FindFirstChildOfClass("UITextSizeConstraint") or Instance.new("UITextSizeConstraint")
closeConstraint.MinTextSize = 16
closeConstraint.MaxTextSize = 26
closeConstraint.Parent = fecharBotao

for index, button in ipairs(botoesResposta) do
	button.TextWrapped = true
	button.TextScaled = true
	button.AutoButtonColor = true
	button.AnchorPoint = Vector2.new(0.5, 0)
	button.Position = UDim2.new(0.5, 0, 0.30 + (index - 1) * 0.21, 0)
	button.Size = UDim2.new(0.88, 0, 0.17, 0)
	button.TextXAlignment = Enum.TextXAlignment.Center
	button.TextYAlignment = Enum.TextYAlignment.Center
	local constraint = button:FindFirstChildOfClass("UITextSizeConstraint") or Instance.new("UITextSizeConstraint")
	constraint.MinTextSize = 14
	constraint.MaxTextSize = 23
	constraint.Parent = button
end
fecharBotao.Activated:Connect(fecharInterface)

local function aplicarEstadoPorta(objeto: Instance?, aberta: boolean)
	if not objeto then
		return
	end
	local function aplicar(part: BasePart)
		part.Transparency = aberta and 0.84 or 0
		part.CanCollide = not aberta
	end
	if objeto:IsA("BasePart") then
		aplicar(objeto)
	elseif objeto:IsA("Model") then
		for _, descendant in ipairs(objeto:GetDescendants()) do
			if descendant:IsA("BasePart") then
				aplicar(descendant)
			end
		end
	end
end

ControlarPorta.OnClientEvent:Connect(function(nomePorta: string, aberta: boolean)
	-- Portão de recompensas é decidido exclusivamente pelo servidor e por direção.
	if nomePorta == "PortaoRecompensas" then
		return
	end
	local objeto = Workspace:FindFirstChild(nomePorta, true)
	aplicarEstadoPorta(objeto, aberta)
end)

local function sincronizarPortasLocais()
	for nivel = 0, 10 do
		local aberta = player:GetAttribute("QuizFeito_Nivel" .. nivel) == true
		local objeto = Workspace:FindFirstChild(string.format("PortaNivel%d Geografia", nivel), true)
		aplicarEstadoPorta(objeto, aberta)
	end
	for nivel = 1, 10 do
		local aberta = player:GetAttribute("QuizHistoriaFeito_Nivel" .. nivel) == true
		local objeto = Workspace:FindFirstChild(string.format("PortaNivel%d História", nivel), true)
		aplicarEstadoPorta(objeto, aberta)
	end
end

for nivel = 0, 10 do
	local attr = "QuizFeito_Nivel" .. nivel
	player:GetAttributeChangedSignal(attr):Connect(function()
		local aberta = player:GetAttribute(attr) == true
		local objeto = Workspace:FindFirstChild(string.format("PortaNivel%d Geografia", nivel), true)
		aplicarEstadoPorta(objeto, aberta)
	end)
end

for nivel = 1, 10 do
	local attr = "QuizHistoriaFeito_Nivel" .. nivel
	player:GetAttributeChangedSignal(attr):Connect(function()
		local aberta = player:GetAttribute(attr) == true
		local objeto = Workspace:FindFirstChild(string.format("PortaNivel%d História", nivel), true)
		aplicarEstadoPorta(objeto, aberta)
	end)
end

-- ==============================================================================
-- INDICADOR 3D: FLECHA SOBRE O PORTÃO DE RECOMPENSAS AO ATINGIR 15 QUESTÕES
-- ==============================================================================
local modeloFlechaLocal: Model? = nil
local conexaoAnimacaoFlecha: RBXScriptConnection? = nil

local function removerFlechaRecompensas()
	if conexaoAnimacaoFlecha then
		conexaoAnimacaoFlecha:Disconnect()
		conexaoAnimacaoFlecha = nil
	end
	if modeloFlechaLocal then
		modeloFlechaLocal:Destroy()
		modeloFlechaLocal = nil
	end
end

local function criarFlechaRecompensas()
	if modeloFlechaLocal then
		return
	end

	-- Localiza a posição do Portão de Recompensas
	local gatePart = Workspace:FindFirstChild(QuizConfig.NOME_PORTAO_RECOMPENSAS, true)
	local posicaoBase = if gatePart and gatePart:IsA("BasePart")
		then gatePart.Position + Vector3.new(0, gatePart.Size.Y * 0.5 + 4.5, 0)
		else Vector3.new(405.025, 1058, 79.6)

	local model = Instance.new("Model")
	model.Name = "FlechaRecompensasLocal"

	-- Corpo superior da seta (haste)
	local haste = Instance.new("Part")
	haste.Name = "Haste"
	haste.Size = Vector3.new(1.4, 3.2, 1.4)
	haste.Material = Enum.Material.Neon
	haste.Color = Color3.fromRGB(255, 215, 0)
	haste.Anchored = true
	haste.CanCollide = false
	haste.CanTouch = false
	haste.CanQuery = false
	haste.Parent = model

	-- Ponta da seta apontando para baixo em direção ao portão
	local ponta = Instance.new("WedgePart")
	ponta.Name = "Ponta"
	ponta.Size = Vector3.new(3.6, 2.6, 3.6)
	ponta.Material = Enum.Material.Neon
	ponta.Color = Color3.fromRGB(255, 230, 60)
	ponta.Anchored = true
	ponta.CanCollide = false
	ponta.CanTouch = false
	ponta.CanQuery = false
	ponta.Parent = model

	-- Luz brilhante para destacar a porta
	local luz = Instance.new("PointLight")
	luz.Name = "LuzDourada"
	luz.Range = 28
	luz.Brightness = 3.5
	luz.Color = Color3.fromRGB(255, 220, 50)
	luz.Parent = ponta

	-- Billboard informativo no topo da seta
	local bb = Instance.new("BillboardGui")
	bb.Name = "IndicadorBillboard"
	bb.Size = UDim2.fromOffset(340, 80)
	bb.StudsOffset = Vector3.new(0, 3.8, 0)
	bb.AlwaysOnTop = true
	bb.MaxDistance = 350
	bb.Adornee = haste
	bb.Parent = model

	local banner = Instance.new("Frame")
	banner.Size = UDim2.fromScale(1, 1)
	banner.BackgroundColor3 = Color3.fromRGB(15, 24, 42)
	banner.BackgroundTransparency = 0.15
	banner.Parent = bb

	local bannerCorner = Instance.new("UICorner")
	bannerCorner.CornerRadius = UDim.new(0, 14)
	bannerCorner.Parent = banner

	local bannerStroke = Instance.new("UIStroke")
	bannerStroke.Color = Color3.fromRGB(255, 215, 0)
	bannerStroke.Thickness = 2.5
	bannerStroke.Parent = banner

	local labelAviso = Instance.new("TextLabel")
	labelAviso.Size = UDim2.fromScale(1, 1)
	labelAviso.BackgroundTransparency = 1
	labelAviso.Font = Enum.Font.GothamBlack
	labelAviso.Text = "⬇️ 🏆 RECOMPENSAS LIBERADAS! 🏆 ⬇️\nEntre para aproveitar seus prêmios!"
	labelAviso.TextColor3 = Color3.fromRGB(255, 235, 90)
	labelAviso.TextScaled = true
	labelAviso.TextWrapped = true
	labelAviso.Parent = banner

	local labelPadding = Instance.new("UIPadding")
	labelPadding.PaddingTop = UDim.new(0, 6)
	labelPadding.PaddingBottom = UDim.new(0, 6)
	labelPadding.PaddingLeft = UDim.new(0, 10)
	labelPadding.PaddingRight = UDim.new(0, 10)
	labelPadding.Parent = labelAviso

	model.PrimaryPart = haste
	model.Parent = Workspace
	modeloFlechaLocal = model

	-- Animação contínua: flutuação suave para cima e para baixo (bobbing) e rotação
	local inicioTick = os.clock()
	conexaoAnimacaoFlecha = RunService.RenderStepped:Connect(function()
		if not modeloFlechaLocal or not haste or not ponta then
			removerFlechaRecompensas()
			return
		end
		local tempo = os.clock() - inicioTick
		local oscilacaoY = math.sin(tempo * 3.5) * 0.9
		local rotacao = (tempo * 1.6) % (math.pi * 2)

		local centro = posicaoBase + Vector3.new(0, oscilacaoY, 0)
		local cframeBase = CFrame.new(centro) * CFrame.Angles(0, rotacao, 0)

		haste.CFrame = cframeBase * CFrame.new(0, 2.2, 0)
		ponta.CFrame = cframeBase * CFrame.new(0, -0.6, 0) * CFrame.Angles(0, 0, math.pi)
	end)
end

local function verificarFlechaRecompensas()
	local pontos = player:GetAttribute("AcertosQuiz")
	if typeof(pontos) == "number" and pontos >= QuizConfig.ACERTOS_MINIMOS_PORTAO_RECOMPENSAS then
		if not modeloFlechaLocal then
			criarFlechaRecompensas()
		end
	else
		removerFlechaRecompensas()
	end
end

player:GetAttributeChangedSignal("AcertosQuiz"):Connect(verificarFlechaRecompensas)

player.CharacterAdded:Connect(function()
	task.wait(0.2)
	sincronizarPortasLocais()
	verificarFlechaRecompensas()
end)

ResetarClient.OnClientEvent:Connect(function()
	fecharInterface()
	sincronizarPortasLocais()
	removerFlechaRecompensas()
end)

task.defer(function()
	sincronizarPortasLocais()
	verificarFlechaRecompensas()
end)

AbrirQuiz.OnClientEvent:Connect(function(dados: any)
	if typeof(dados) ~= "table" or typeof(dados.Alternativas) ~= "table" then
		return
	end
	resetarCoresBotoes()
	respondeuAtual = false
	local prefixo = dados.Nivel == 0 and "Tutorial: " or string.format("%s · nível %d: ", tostring(dados.Materia), tonumber(dados.Nivel) or 0)
	perguntaLabel.Text = prefixo .. tostring(dados.Nome) .. "\nEscolha a alternativa FALSA."
	for index = 1, #botoesResposta do
		local button = botoesResposta[index]
		local text = dados.Alternativas[index]
		button.Visible = typeof(text) == "string"
		button.Text = typeof(text) == "string" and text or ""
		button.TextTransparency = 1
		button.BackgroundTransparency = 1
	end

	-- Efeito sonoro imersivo de abertura da pergunta
	pcall(function() somPergunta:Play() end)

	-- Estado inicial para pop-in suave e elástico
	frameScale.Scale = 0.62
	frame.Position = UDim2.fromScale(0.5, 0.58)
	perguntaLabel.TextTransparency = 1
	frame.Visible = true

	-- Animação Back-Out da janela
	TweenService:Create(frameScale, TweenInfo.new(0.35, Enum.EasingStyle.Back, Enum.EasingDirection.Out), {
		Scale = 1.0,
	}):Play()
	TweenService:Create(frame, TweenInfo.new(0.35, Enum.EasingStyle.Back, Enum.EasingDirection.Out), {
		Position = UDim2.fromScale(0.5, 0.53),
	}):Play()

	-- Fade-in do enunciado
	TweenService:Create(perguntaLabel, TweenInfo.new(0.22, Enum.EasingStyle.Quad, Enum.EasingDirection.Out), {
		TextTransparency = 0,
	}):Play()

	-- Entrada escalonada dos 3 botões de resposta
	for index = 1, #botoesResposta do
		local button = botoesResposta[index]
		if button.Visible then
			local finalY = 0.30 + (index - 1) * 0.21
			button.Position = UDim2.new(0.5, 0, finalY + 0.04, 0)
			task.delay(0.07 * index, function()
				if frame.Visible then
					TweenService:Create(button, TweenInfo.new(0.25, Enum.EasingStyle.Back, Enum.EasingDirection.Out), {
						Position = UDim2.new(0.5, 0, finalY, 0),
						BackgroundTransparency = 0,
						TextTransparency = 0,
					}):Play()
				end
			end)
		end
	end
end)

for index, button in ipairs(botoesResposta) do
	button.Activated:Connect(function()
		if respondeuAtual or not frame.Visible or not button.Visible then
			return
		end
		respondeuAtual = true
		for _, choice in ipairs(botoesResposta) do
			choice.Active = false
			choice.AutoButtonColor = false
		end

		local ok, resultado = pcall(function()
			return EnviarResposta:InvokeServer(index)
		end)
		if not ok or typeof(resultado) ~= "table" then
			respondeuAtual = false
			resetarCoresBotoes()
			mostrarToast("Não consegui enviar a resposta. Tente novamente.", Color3.fromRGB(255, 150, 120))
			return
		end
		if not resultado.Aceito then
			fecharInterface()
			if typeof(resultado.Mensagem) == "string" then
				mostrarToast(resultado.Mensagem, Color3.fromRGB(255, 180, 130))
			end
			return
		end

		if resultado.Acertou then
			pcall(function() somAcerto:Play() end)
			button.BackgroundColor3 = Color3.fromRGB(55, 180, 104)
		else
			pcall(function() somErro:Play() end)
			button.BackgroundColor3 = Color3.fromRGB(204, 69, 78)
			local correctIndex = tonumber(resultado.IndiceCorreto)
			if correctIndex and botoesResposta[correctIndex] then
				botoesResposta[correctIndex].BackgroundColor3 = Color3.fromRGB(55, 180, 104)
			end
		end
		task.wait(1.5)
		fecharInterface()
	end)
end

FimDeRodada.OnClientEvent:Connect(function(dados: any)
	fecharInterface()
	local modoComCronometro = player:GetAttribute("ModoComCronometro")
	if modoComCronometro == false then
		timerLabel.Visible = false
		statusLabel.Text = "MODO LIVRE · SEM CRONÔMETRO"
		statusLabel.TextColor3 = Color3.fromRGB(120, 235, 175)
		return
	end
	if renderizarTempoCongelado() then
		if typeof(dados) ~= "table" or dados.Individual ~= true then
			faseAtual = "Intervalo"
		end
		return
	end
	if typeof(dados) == "table" and dados.Individual == true then
		ultimoTextoPrazoRodada = ""
		statusLabel.Text = tostring(dados.Mensagem or "Seu tempo acabou.")
		statusLabel.TextColor3 = Color3.fromRGB(255, 160, 145)
		timerLabel.Text = "00:00.000"
		timerLabel.TextColor3 = Color3.fromRGB(255, 112, 112)
		return
	end
	faseAtual = "Intervalo"
	timerLabel.Text = "00:00.000"
	timerLabel.TextColor3 = Color3.fromRGB(255, 112, 112)
	ultimoTextoCronometroTentativa = "00:00.000"
	statusLabel.Text = typeof(dados) == "table" and tostring(dados.Mensagem or "Fim da rodada") or "Fim da rodada"
end)

RunService.Heartbeat:Connect(function()
	local modoComCronometro = player:GetAttribute("ModoComCronometro")
	if modoComCronometro == false then
		timerLabel.Visible = false
		return
	end
	if faseAtual ~= "Ativa" then
		return
	end
	if renderizarTempoCongelado() then
		return
	end
	local agoraServidor = Workspace:GetServerTimeNow()
	local inicioTentativa = player:GetAttribute("InicioTentativaQuiz")
	local tempoConclusao = player:GetAttribute("TempoConclusaoQuiz")
	if typeof(tempoConclusao) == "number" then
		local textoTentativa = formatarTempo(tempoConclusao)
		if textoTentativa ~= ultimoTextoCronometroTentativa then
			ultimoTextoCronometroTentativa = textoTentativa
			timerLabel.Text = textoTentativa
			timerLabel.TextColor3 = Color3.fromRGB(255, 220, 86)
		end
	elseif typeof(inicioTentativa) == "number" then
		local textoTentativa = formatarTempo(agoraServidor - inicioTentativa)
		if textoTentativa ~= ultimoTextoCronometroTentativa then
			ultimoTextoCronometroTentativa = textoTentativa
			timerLabel.Text = textoTentativa
			timerLabel.TextColor3 = Color3.fromRGB(255, 220, 86)
		end
	else
		timerLabel.Text = "--:--.---"
	end
	local fimTentativa = player:GetAttribute("FimTentativaQuiz")
	if typeof(fimTentativa) ~= "number" or fimTentativa <= 0 then
		return
	end
	local restante = math.max(0, fimTentativa - agoraServidor)
	local texto = formatarTempo(restante)
	local tentativa = tonumber(player:GetAttribute("NumeroTentativaQuiz")) or 1
	local textoPrazoRodada = string.format("RODADA %d  ·  RESTA %s", tentativa, texto)
	if textoPrazoRodada ~= ultimoTextoPrazoRodada then
		ultimoTextoPrazoRodada = textoPrazoRodada
		statusLabel.Text = textoPrazoRodada
	end
	if restante <= 30 then
		statusLabel.TextColor3 = Color3.fromRGB(255, 160, 145)
	else
		statusLabel.TextColor3 = Color3.fromRGB(230, 239, 251)
	end
end)

local resetDisponivel = true
local function animarReset(pressionado: boolean)
	local info = TweenInfo.new(0.09, Enum.EasingStyle.Quad, Enum.EasingDirection.Out)
	TweenService:Create(resetScale, info, { Scale = pressionado and 0.95 or 1 }):Play()
	TweenService:Create(reset, info, {
		BackgroundColor3 = pressionado and Color3.fromRGB(137, 38, 52) or Color3.fromRGB(191, 50, 66),
	}):Play()
end
reset.InputBegan:Connect(function(input)
	if input.UserInputType == Enum.UserInputType.MouseButton1 or input.UserInputType == Enum.UserInputType.Touch then
		animarReset(true)
	end
end)
reset.InputEnded:Connect(function(input)
	if input.UserInputType == Enum.UserInputType.MouseButton1 or input.UserInputType == Enum.UserInputType.Touch then
		animarReset(false)
	end
end)
reset.Activated:Connect(function()
	if not resetDisponivel then
		return
	end
	resetDisponivel = false
	reset.Text = "REINICIANDO..."
	SolicitarReset:FireServer()
	mostrarToast("Tentativa reiniciada.", Color3.fromRGB(255, 215, 120))
	task.delay(1.5, function()
		reset.Text = "↻  RESETAR"
		resetDisponivel = true
	end)
end)

task.spawn(function()
	for _ = 1, 12 do
		local ok = pcall(function()
			StarterGui:SetCore("ResetButtonCallback", false)
		end)
		if ok then
			return
		end
		task.wait(0.5)
	end
end)

SincronizarRodada.OnClientEvent:Connect(function(dados)
	ultimoTextoPrazoRodada = ""
	ultimoTextoCronometroTentativa = ""
	atualizarEstado(dados)
end)

task.spawn(function()
	local ok, dados = pcall(function()
		return ObterEstadoRodada:InvokeServer()
	end)
	if ok then
		atualizarEstado(dados)
	end
end)

-- Sincroniza visibilidade do HUD conforme escolha do modo
local function observarModo()
	local modo = player:GetAttribute("ModoComCronometro")
	if modo == false then
		timerLabel.Visible = false
		if faseAtual == "Ativa" then
			local tentativa = tonumber(player:GetAttribute("NumeroTentativaQuiz")) or 1
			statusLabel.Text = string.format("MODO LIVRE · RODADA %d", tentativa)
		else
			statusLabel.Text = "MODO LIVRE · SEM CRONÔMETRO"
		end
		statusLabel.TextColor3 = Color3.fromRGB(120, 235, 175)
		botaoTrocarModo.Text = "🎯 MODO: LIVRE"
		botaoTrocarModo.TextColor3 = Color3.fromRGB(120, 235, 175)
		trocarModoStroke.Color = Color3.fromRGB(50, 220, 175)
	elseif modo == true then
		timerLabel.Visible = true
		botaoTrocarModo.Text = "⏱️ MODO: RANQUEADO"
		botaoTrocarModo.TextColor3 = Color3.fromRGB(255, 222, 105)
		trocarModoStroke.Color = Color3.fromRGB(255, 204, 60)
	else
		botaoTrocarModo.Text = "🎮 MUDAR MODO"
		botaoTrocarModo.TextColor3 = Color3.fromRGB(255, 222, 105)
		trocarModoStroke.Color = Color3.fromRGB(255, 204, 60)
	end
end
player:GetAttributeChangedSignal("ModoComCronometro"):Connect(observarModo)
observarModo()

if DefinirModoJogo then
	DefinirModoJogo.OnClientEvent:Connect(function()
		mostrarModalModo()
	end)
end

task.defer(function()
	task.wait(0.3)
	if player:GetAttribute("ModoComCronometro") == nil then
		mostrarModalModo()
	end
end)
