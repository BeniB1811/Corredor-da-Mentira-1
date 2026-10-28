--!strict
-- Controlador de interface do cliente (HUD, seleção de modo, questões e indicadores visuais).
-- Toda validação de estado, pontuação, tempo e acesso a áreas permanece estritamente no servidor.

local Players = game:GetService("Players")
local ReplicatedStorage = game:GetService("ReplicatedStorage")
local RunService = game:GetService("RunService")
local StarterGui = game:GetService("StarterGui")
local TweenService = game:GetService("TweenService")
local Workspace = game:GetService("Workspace")

local QuizConfig = require(ReplicatedStorage:WaitForChild("QuizConfig"))

type PlayerState = QuizConfig.PlayerState

type RoundStateSnapshot = {
	Fase: string?,
	Ativa: boolean?,
	EstadoJogador: string?,
	TutorialConcluido: boolean?,
	FimRodadaTimestamp: number?,
	DuracaoTotal: number?,
	NumeroRodada: number?,
	Prontos: number?,
	Total: number?,
}

type QuizPromptPayload = {
	Materia: string?,
	Nivel: number?,
	Nome: string?,
	Alternativas: { string }?,
}

type AnswerSubmissionResult = {
	Aceito: boolean,
	Acertou: boolean?,
	IndiceCorreto: number?,
	Pontuacao: number?,
	TutorialConcluido: boolean?,
	Mensagem: string?,
}

type RoundEndPayload = {
	Mensagem: string?,
	Individual: boolean?,
}

-- ============================================================================
-- PALETA SÓBRIA E CONSTANTES DE DESIGN (GRID 4PX / 8PX, SUPERFÍCIES FOSCAS)
-- ============================================================================

local COLOR_SURFACE_PRIMARY = Color3.fromRGB(18, 21, 28)
local COLOR_SURFACE_SECONDARY = Color3.fromRGB(26, 30, 39)
local COLOR_SURFACE_ELEVATED = Color3.fromRGB(34, 39, 50)
local COLOR_SURFACE_PRESSED = Color3.fromRGB(14, 17, 23)
local COLOR_BACKDROP = Color3.fromRGB(9, 11, 16)

local COLOR_BORDER_SUBTLE = Color3.fromRGB(48, 55, 69)
local COLOR_BORDER_STRONG = Color3.fromRGB(68, 78, 98)

local COLOR_TEXT_PRIMARY = Color3.fromRGB(241, 244, 249)
local COLOR_TEXT_SECONDARY = Color3.fromRGB(156, 166, 184)
local COLOR_TEXT_MUTED = Color3.fromRGB(112, 122, 140)

local COLOR_CTA_PRIMARY = Color3.fromRGB(37, 99, 235)
local COLOR_CTA_PRIMARY_HOVER = Color3.fromRGB(59, 130, 246)

local COLOR_ACCENT_SUCCESS = Color3.fromRGB(22, 163, 74)
local COLOR_ACCENT_SUCCESS_BORDER = Color3.fromRGB(34, 197, 94)
local COLOR_ACCENT_DANGER = Color3.fromRGB(185, 28, 28)
local COLOR_ACCENT_DANGER_BORDER = Color3.fromRGB(239, 68, 68)
local COLOR_ACCENT_WARNING = Color3.fromRGB(217, 119, 6)
local COLOR_ARROW_MATTE_GOLD = Color3.fromRGB(202, 154, 58)

local CORNER_RADIUS_SM = UDim.new(0, 8)
local CORNER_RADIUS_MD = UDim.new(0, 12)

local QUIZ_WARNING_THRESHOLD_SECONDS = 30
local REWARD_WARNING_THRESHOLD_SECONDS = 60
local REWARD_CRITICAL_THRESHOLD_SECONDS = 15
local TOAST_DISPLAY_SECONDS = 3.2
local DOOR_OPEN_TRANSPARENCY = 0.82
local DOOR_BARRIERS_FOLDER_NAME = "QuizDoorBarriers"

local SOUND_QUESTION_OPEN_ID = "rbxassetid://9069609200"
local SOUND_ANSWER_CORRECT_ID = "rbxassetid://6026987457"
local SOUND_ANSWER_WRONG_ID = "rbxassetid://9069611299"
local SOUND_UI_CLICK_ID = "rbxassetid://6895079853"

local PLAYER_STATES = QuizConfig.PLAYER_STATES

-- ============================================================================
-- REFERÊNCIAS DE INSTÂNCIAS E REMOTES
-- ============================================================================

local localPlayer = Players.LocalPlayer
local playerGui = localPlayer:WaitForChild("PlayerGui")
local screenGui = playerGui:WaitForChild("ScreenGui", 30) :: ScreenGui?
if not screenGui then
	warn("[QuizClient] ScreenGui não foi encontrada.")
	return
end

local starterScreenGui = StarterGui:FindFirstChild("ScreenGui")
if starterScreenGui and starterScreenGui:IsA("ScreenGui") then
	starterScreenGui.ResetOnSpawn = false
end
screenGui.ResetOnSpawn = false
screenGui.IgnoreGuiInset = false

local questionFrame = screenGui:WaitForChild("Frame das perguntas", 30) :: Frame?
if not questionFrame then
	warn("[QuizClient] Frame das perguntas não foi encontrada.")
	return
end

local questionTextLabel = questionFrame:WaitForChild("Pergunta") :: TextLabel
local closeQuestionButton = questionFrame:WaitForChild("Fechar") :: TextButton
local answerButtons: { TextButton } = {
	questionFrame:WaitForChild("Resposta 1") :: TextButton,
	questionFrame:WaitForChild("Resposta 2") :: TextButton,
	questionFrame:WaitForChild("Resposta 3") :: TextButton,
}

local remotesFolder = ReplicatedStorage:WaitForChild(QuizConfig.REMOTES_FOLDER_NAME, 30)
if not remotesFolder then
	warn("[QuizClient] Pasta QuizRemotes não encontrada.")
	return
end

local AbrirQuiz = remotesFolder:WaitForChild("AbrirQuiz") :: RemoteEvent
local EnviarResposta = remotesFolder:WaitForChild("EnviarResposta") :: RemoteFunction
local SincronizarRodada = remotesFolder:WaitForChild("SincronizarRodada") :: RemoteEvent
local FimDeRodada = remotesFolder:WaitForChild("FimDeRodada") :: RemoteEvent
local ControlarPorta = remotesFolder:WaitForChild("ControlarPorta") :: RemoteEvent
local ResetarClient = remotesFolder:WaitForChild("ResetarClient") :: RemoteEvent
local NotificarMensagem = remotesFolder:WaitForChild("NotificarMensagem") :: RemoteEvent
local SolicitarReset = remotesFolder:WaitForChild("SolicitarReset") :: RemoteEvent
local ObterEstadoRodada = remotesFolder:WaitForChild("ObterEstadoRodada") :: RemoteFunction
local DefinirModoJogo = remotesFolder:WaitForChild(QuizConfig.MODE_REMOTE_NAME, 15) :: RemoteEvent?

local activeConnections: { RBXScriptConnection } = {}
local function trackConnection(connection: RBXScriptConnection): RBXScriptConnection
	table.insert(activeConnections, connection)
	return connection
end

-- ============================================================================
-- UTILITÁRIOS DE CONSTRUÇÃO VISUAL LIMPA
-- ============================================================================

local function removeLegacyGradients(target: Instance)
	for _, child in ipairs(target:GetChildren()) do
		if child:IsA("UIGradient") then
			child:Destroy()
		end
	end
end

local function ensureCorner(parent: GuiObject, radius: UDim): UICorner
	local corner = parent:FindFirstChildOfClass("UICorner")
	if not corner then
		local created = Instance.new("UICorner")
		created.Parent = parent
		corner = created
	end
	(corner :: UICorner).CornerRadius = radius
	return corner :: UICorner
end

local function ensureStroke(parent: GuiObject, color: Color3, thickness: number): UIStroke
	local stroke = parent:FindFirstChildOfClass("UIStroke")
	if not stroke then
		local created = Instance.new("UIStroke")
		created.Parent = parent
		stroke = created
	end
	local resolved = stroke :: UIStroke
	resolved.ApplyStrokeMode = Enum.ApplyStrokeMode.Border
	resolved.Color = color
	resolved.Thickness = thickness
	resolved.Transparency = 0
	return resolved
end

local function ensurePadding(parent: GuiObject, topPx: number, bottomPx: number, leftPx: number, rightPx: number): UIPadding
	local padding = parent:FindFirstChildOfClass("UIPadding")
	if not padding then
		local created = Instance.new("UIPadding")
		created.Parent = parent
		padding = created
	end
	local resolved = padding :: UIPadding
	resolved.PaddingTop = UDim.new(0, topPx)
	resolved.PaddingBottom = UDim.new(0, bottomPx)
	resolved.PaddingLeft = UDim.new(0, leftPx)
	resolved.PaddingRight = UDim.new(0, rightPx)
	return resolved
end

local function ensureTextSizeConstraint(parent: GuiObject, minSize: number, maxSize: number): UITextSizeConstraint
	local constraint = parent:FindFirstChildOfClass("UITextSizeConstraint")
	if not constraint then
		local created = Instance.new("UITextSizeConstraint")
		created.Parent = parent
		constraint = created
	end
	local resolved = constraint :: UITextSizeConstraint
	resolved.MinTextSize = minSize
	resolved.MaxTextSize = maxSize
	return resolved
end

local function ensureSizeConstraint(parent: GuiObject, minSize: Vector2, maxSize: Vector2): UISizeConstraint
	local constraint = parent:FindFirstChildOfClass("UISizeConstraint")
	if not constraint then
		local created = Instance.new("UISizeConstraint")
		created.Parent = parent
		constraint = created
	end
	local resolved = constraint :: UISizeConstraint
	resolved.MinSize = minSize
	resolved.MaxSize = maxSize
	return resolved
end

local function ensureScale(parent: GuiObject, name: string?): UIScale
	local existing = if name then parent:FindFirstChild(name) else parent:FindFirstChildOfClass("UIScale")
	if existing and existing:IsA("UIScale") then
		existing.Scale = 1
		return existing
	end
	if existing then
		existing:Destroy()
	end
	local created = Instance.new("UIScale")
	created.Name = name or "UIScale"
	created.Scale = 1
	created.Parent = parent
	return created
end

local function getOrCreateGuiObject(parent: Instance, name: string, className: string): GuiObject
	local existing = parent:FindFirstChild(name)
	if existing and existing.ClassName == className then
		return existing :: GuiObject
	end
	if existing then
		existing:Destroy()
	end
	local created = Instance.new(className)
	created.Name = name
	created.Parent = parent
	return created :: GuiObject
end

local function ensureSound(name: string, soundId: string, volume: number): Sound
	local existing = screenGui:FindFirstChild(name)
	local sound: Sound
	if existing and existing:IsA("Sound") then
		sound = existing
	else
		if existing then
			existing:Destroy()
		end
		local created = Instance.new("Sound")
		created.Name = name
		created.Parent = screenGui
		sound = created
	end
	sound.SoundId = soundId
	sound.Volume = volume
	return sound
end

local soundQuestionOpen = ensureSound("SomPerguntaAparecer", SOUND_QUESTION_OPEN_ID, 0.55)
local soundAnswerCorrect = ensureSound("SomAcertoQuiz", SOUND_ANSWER_CORRECT_ID, 0.6)
local soundAnswerWrong = ensureSound("SomErroQuiz", SOUND_ANSWER_WRONG_ID, 0.5)
local soundUiClick = ensureSound("SomCliqueQuiz", SOUND_UI_CLICK_ID, 0.45)

-- ============================================================================
-- HUD SUPERIOR: AÇÕES (ESQUERDA), CRONÔMETRO QUIZ (CENTRO), RECOMPENSAS (DIREITA)
-- ============================================================================

local resetButton = getOrCreateGuiObject(screenGui, "BotaoResetTentativa", "TextButton") :: TextButton
removeLegacyGradients(resetButton)
resetButton.AnchorPoint = Vector2.new(0, 0)
resetButton.Position = UDim2.fromOffset(16, 8)
resetButton.Size = UDim2.fromOffset(112, 36)
resetButton.BackgroundColor3 = COLOR_SURFACE_SECONDARY
resetButton.BackgroundTransparency = 0.04
resetButton.BorderSizePixel = 0
resetButton.AutoButtonColor = false
resetButton.Font = Enum.Font.GothamBold
resetButton.Text = "Reiniciar"
resetButton.TextColor3 = COLOR_TEXT_PRIMARY
resetButton.TextScaled = false
resetButton.TextSize = 13
resetButton.ZIndex = 20
ensureCorner(resetButton, CORNER_RADIUS_SM)
local resetButtonStroke = ensureStroke(resetButton, COLOR_BORDER_SUBTLE, 1)
local resetButtonScale = ensureScale(resetButton, "ButtonScale")

local switchModeButton = getOrCreateGuiObject(screenGui, "BotaoTrocarModo", "TextButton") :: TextButton
removeLegacyGradients(switchModeButton)
switchModeButton.AnchorPoint = Vector2.new(0, 0)
switchModeButton.Position = UDim2.fromOffset(136, 8)
switchModeButton.Size = UDim2.fromOffset(156, 36)
switchModeButton.BackgroundColor3 = COLOR_SURFACE_SECONDARY
switchModeButton.BackgroundTransparency = 0.04
switchModeButton.BorderSizePixel = 0
switchModeButton.AutoButtonColor = false
switchModeButton.Font = Enum.Font.GothamBold
switchModeButton.Text = "Modo: Selecionar"
switchModeButton.TextColor3 = COLOR_TEXT_PRIMARY
switchModeButton.TextScaled = false
switchModeButton.TextSize = 13
switchModeButton.ZIndex = 20
ensureCorner(switchModeButton, CORNER_RADIUS_SM)
local switchModeStroke = ensureStroke(switchModeButton, COLOR_BORDER_SUBTLE, 1)
local switchModeScale = ensureScale(switchModeButton, "ButtonScale")

local timerLabel = getOrCreateGuiObject(screenGui, "ContadorGeralRodada", "TextLabel") :: TextLabel
removeLegacyGradients(timerLabel)
timerLabel.AnchorPoint = Vector2.new(0.5, 0)
timerLabel.Position = UDim2.new(0.5, 0, 0, 8)
timerLabel.Size = UDim2.fromOffset(184, 36)
timerLabel.BackgroundColor3 = COLOR_SURFACE_PRIMARY
timerLabel.BackgroundTransparency = 0.06
timerLabel.BorderSizePixel = 0
timerLabel.Font = Enum.Font.GothamBold
timerLabel.Text = "--:--.---"
timerLabel.TextColor3 = COLOR_TEXT_PRIMARY
timerLabel.TextScaled = false
timerLabel.TextSize = 18
timerLabel.ZIndex = 20
ensureCorner(timerLabel, CORNER_RADIUS_SM)
ensureStroke(timerLabel, COLOR_BORDER_SUBTLE, 1)

local statusLabel = getOrCreateGuiObject(screenGui, "EstadoRodada", "TextLabel") :: TextLabel
removeLegacyGradients(statusLabel)
statusLabel.AnchorPoint = Vector2.new(0.5, 0)
statusLabel.Position = UDim2.new(0.5, 0, 0, 48)
statusLabel.Size = UDim2.new(0.6, 0, 0, 20)
statusLabel.BackgroundTransparency = 1
statusLabel.Font = Enum.Font.GothamMedium
statusLabel.Text = "Selecione um modo para iniciar"
statusLabel.TextColor3 = COLOR_TEXT_SECONDARY
statusLabel.TextScaled = false
statusLabel.TextSize = 13
statusLabel.TextWrapped = true
statusLabel.ZIndex = 20

-- HUD discreto e funcional da Área de Recompensas (contagem regressiva MM:SS)
local rewardHudPanel = getOrCreateGuiObject(screenGui, "PainelTempoRecompensas", "Frame") :: Frame
removeLegacyGradients(rewardHudPanel)
rewardHudPanel.AnchorPoint = Vector2.new(1, 0)
rewardHudPanel.Position = UDim2.new(1, -16, 0, 8)
rewardHudPanel.Size = UDim2.fromOffset(188, 52)
rewardHudPanel.BackgroundColor3 = COLOR_SURFACE_PRIMARY
rewardHudPanel.BackgroundTransparency = 0.06
rewardHudPanel.BorderSizePixel = 0
rewardHudPanel.Visible = false
rewardHudPanel.ZIndex = 20
ensureCorner(rewardHudPanel, CORNER_RADIUS_SM)
local rewardHudStroke = ensureStroke(rewardHudPanel, COLOR_BORDER_SUBTLE, 1)

local rewardHudCaption = getOrCreateGuiObject(rewardHudPanel, "TituloRecompensas", "TextLabel") :: TextLabel
rewardHudCaption.Position = UDim2.fromOffset(12, 8)
rewardHudCaption.Size = UDim2.new(1, -24, 0, 14)
rewardHudCaption.BackgroundTransparency = 1
rewardHudCaption.Font = Enum.Font.GothamBold
rewardHudCaption.Text = "ÁREA DE RECOMPENSAS"
rewardHudCaption.TextColor3 = COLOR_TEXT_SECONDARY
rewardHudCaption.TextSize = 10
rewardHudCaption.TextXAlignment = Enum.TextXAlignment.Right
rewardHudCaption.ZIndex = 21

local rewardHudTimerLabel = getOrCreateGuiObject(rewardHudPanel, "TempoRestanteMMSS", "TextLabel") :: TextLabel
rewardHudTimerLabel.Position = UDim2.fromOffset(12, 22)
rewardHudTimerLabel.Size = UDim2.new(1, -24, 0, 22)
rewardHudTimerLabel.BackgroundTransparency = 1
rewardHudTimerLabel.Font = Enum.Font.GothamBold
rewardHudTimerLabel.Text = "10:00"
rewardHudTimerLabel.TextColor3 = COLOR_TEXT_PRIMARY
rewardHudTimerLabel.TextSize = 18
rewardHudTimerLabel.TextXAlignment = Enum.TextXAlignment.Right
rewardHudTimerLabel.ZIndex = 21

-- Notificação Toast limpa com barra lateral semântica de 3px
local existingLegacyToast = screenGui:FindFirstChild("QuizToastNotification")
if existingLegacyToast and not existingLegacyToast:IsA("Frame") then
	existingLegacyToast:Destroy()
end

local toastFrame = getOrCreateGuiObject(screenGui, "QuizToastNotification", "Frame") :: Frame
toastFrame.AnchorPoint = Vector2.new(0.5, 0)
toastFrame.Position = UDim2.new(0.5, 0, 0, 76)
toastFrame.Size = UDim2.new(0.76, 0, 0, 44)
toastFrame.BackgroundColor3 = COLOR_SURFACE_PRIMARY
toastFrame.BackgroundTransparency = 0.05
toastFrame.BorderSizePixel = 0
toastFrame.Visible = false
toastFrame.ClipsDescendants = true
toastFrame.ZIndex = 28
ensureSizeConstraint(toastFrame, Vector2.new(280, 40), Vector2.new(480, 56))
ensureCorner(toastFrame, CORNER_RADIUS_SM)
ensureStroke(toastFrame, COLOR_BORDER_SUBTLE, 1)

local toastAccentBar = getOrCreateGuiObject(toastFrame, "AccentBar", "Frame") :: Frame
toastAccentBar.Position = UDim2.fromOffset(0, 0)
toastAccentBar.Size = UDim2.new(0, 3, 1, 0)
toastAccentBar.BackgroundColor3 = COLOR_CTA_PRIMARY
toastAccentBar.BorderSizePixel = 0
toastAccentBar.ZIndex = 29

local toastTextLabel = getOrCreateGuiObject(toastFrame, "Message", "TextLabel") :: TextLabel
toastTextLabel.Position = UDim2.fromOffset(16, 0)
toastTextLabel.Size = UDim2.new(1, -28, 1, 0)
toastTextLabel.BackgroundTransparency = 1
toastTextLabel.Font = Enum.Font.GothamMedium
toastTextLabel.Text = ""
toastTextLabel.TextColor3 = COLOR_TEXT_PRIMARY
toastTextLabel.TextSize = 14
toastTextLabel.TextWrapped = true
toastTextLabel.TextXAlignment = Enum.TextXAlignment.Left
toastTextLabel.TextYAlignment = Enum.TextYAlignment.Center
toastTextLabel.ZIndex = 29

local function bindSubtleButtonFeedback(
	button: TextButton,
	scaleInstance: UIScale,
	strokeInstance: UIStroke,
	restingBackground: Color3,
	hoverBackground: Color3,
	restingBorder: Color3,
	hoverBorder: Color3
)
	local transitionInfo = TweenInfo.new(0.12, Enum.EasingStyle.Quad, Enum.EasingDirection.Out)
	trackConnection(button.MouseEnter:Connect(function()
		TweenService:Create(button, transitionInfo, { BackgroundColor3 = hoverBackground }):Play()
		TweenService:Create(strokeInstance, transitionInfo, { Color = hoverBorder }):Play()
	end))
	trackConnection(button.MouseLeave:Connect(function()
		TweenService:Create(scaleInstance, transitionInfo, { Scale = 1 }):Play()
		TweenService:Create(button, transitionInfo, { BackgroundColor3 = restingBackground }):Play()
		TweenService:Create(strokeInstance, transitionInfo, { Color = restingBorder }):Play()
	end))
	trackConnection(button.InputBegan:Connect(function(input: InputObject)
		if input.UserInputType == Enum.UserInputType.MouseButton1 or input.UserInputType == Enum.UserInputType.Touch then
			TweenService:Create(scaleInstance, transitionInfo, { Scale = 0.97 }):Play()
			TweenService:Create(button, transitionInfo, { BackgroundColor3 = COLOR_SURFACE_PRESSED }):Play()
		end
	end))
	trackConnection(button.InputEnded:Connect(function(input: InputObject)
		if input.UserInputType == Enum.UserInputType.MouseButton1 or input.UserInputType == Enum.UserInputType.Touch then
			TweenService:Create(scaleInstance, transitionInfo, { Scale = 1 }):Play()
			TweenService:Create(button, transitionInfo, { BackgroundColor3 = restingBackground }):Play()
		end
	end))
end

bindSubtleButtonFeedback(
	resetButton,
	resetButtonScale,
	resetButtonStroke,
	COLOR_SURFACE_SECONDARY,
	COLOR_SURFACE_ELEVATED,
	COLOR_BORDER_SUBTLE,
	COLOR_ACCENT_DANGER_BORDER
)

bindSubtleButtonFeedback(
	switchModeButton,
	switchModeScale,
	switchModeStroke,
	COLOR_SURFACE_SECONDARY,
	COLOR_SURFACE_ELEVATED,
	COLOR_BORDER_SUBTLE,
	COLOR_BORDER_STRONG
)

-- ============================================================================
-- MODAL DE SELEÇÃO DE MODO DE JOGO (OBRIGATÓRIO ANTES DO TUTORIAL)
-- ============================================================================

local existingModeModal = screenGui:FindFirstChild("ModalSelecaoModo")
if existingModeModal then
	existingModeModal:Destroy()
end

local modeModalBackdrop = Instance.new("Frame")
modeModalBackdrop.Name = "ModalSelecaoModo"
modeModalBackdrop.Size = UDim2.fromScale(1, 1)
modeModalBackdrop.BackgroundColor3 = COLOR_BACKDROP
modeModalBackdrop.BackgroundTransparency = 0.42
modeModalBackdrop.BorderSizePixel = 0
modeModalBackdrop.Active = true
modeModalBackdrop.Visible = false
modeModalBackdrop.ZIndex = 45
modeModalBackdrop.Parent = screenGui

local modeModalCard = Instance.new("Frame")
modeModalCard.Name = "ModalCard"
modeModalCard.AnchorPoint = Vector2.new(0.5, 0.5)
modeModalCard.Position = UDim2.fromScale(0.5, 0.5)
modeModalCard.Size = UDim2.new(0.88, 0, 0.78, 0)
modeModalCard.BackgroundColor3 = COLOR_SURFACE_PRIMARY
modeModalCard.BackgroundTransparency = 0
modeModalCard.BorderSizePixel = 0
modeModalCard.ZIndex = 46
modeModalCard.Parent = modeModalBackdrop
ensureSizeConstraint(modeModalCard, Vector2.new(320, 340), Vector2.new(608, 392))
ensureCorner(modeModalCard, CORNER_RADIUS_MD)
ensureStroke(modeModalCard, COLOR_BORDER_SUBTLE, 1)
local modeModalScale = ensureScale(modeModalCard, "CardScale")

local closeModeModalButton = Instance.new("TextButton")
closeModeModalButton.Name = "FecharModal"
closeModeModalButton.AnchorPoint = Vector2.new(1, 0)
closeModeModalButton.Position = UDim2.new(1, -16, 0, 16)
closeModeModalButton.Size = UDim2.fromOffset(32, 32)
closeModeModalButton.BackgroundColor3 = COLOR_SURFACE_SECONDARY
closeModeModalButton.BorderSizePixel = 0
closeModeModalButton.AutoButtonColor = false
closeModeModalButton.Font = Enum.Font.GothamBold
closeModeModalButton.Text = "×"
closeModeModalButton.TextColor3 = COLOR_TEXT_SECONDARY
closeModeModalButton.TextSize = 20
closeModeModalButton.Visible = false
closeModeModalButton.ZIndex = 50
closeModeModalButton.Parent = modeModalCard
ensureCorner(closeModeModalButton, CORNER_RADIUS_SM)
local closeModeModalStroke = ensureStroke(closeModeModalButton, COLOR_BORDER_SUBTLE, 1)
local closeModeModalScale = ensureScale(closeModeModalButton, "ButtonScale")
bindSubtleButtonFeedback(
	closeModeModalButton,
	closeModeModalScale,
	closeModeModalStroke,
	COLOR_SURFACE_SECONDARY,
	COLOR_SURFACE_ELEVATED,
	COLOR_BORDER_SUBTLE,
	COLOR_BORDER_STRONG
)

local modeModalTitle = Instance.new("TextLabel")
modeModalTitle.Name = "Title"
modeModalTitle.Position = UDim2.fromOffset(24, 20)
modeModalTitle.Size = UDim2.new(1, -72, 0, 26)
modeModalTitle.BackgroundTransparency = 1
modeModalTitle.Font = Enum.Font.GothamBold
modeModalTitle.Text = "Selecionar Modo de Jogo"
modeModalTitle.TextColor3 = COLOR_TEXT_PRIMARY
modeModalTitle.TextSize = 20
modeModalTitle.TextXAlignment = Enum.TextXAlignment.Left
modeModalTitle.ZIndex = 47
modeModalTitle.Parent = modeModalCard

local modeModalSubtitle = Instance.new("TextLabel")
modeModalSubtitle.Name = "Subtitle"
modeModalSubtitle.Position = UDim2.fromOffset(24, 48)
modeModalSubtitle.Size = UDim2.new(1, -48, 0, 20)
modeModalSubtitle.BackgroundTransparency = 1
modeModalSubtitle.Font = Enum.Font.Gotham
modeModalSubtitle.Text = "Escolha o formato da partida antes de iniciar o tutorial obrigatório."
modeModalSubtitle.TextColor3 = COLOR_TEXT_SECONDARY
modeModalSubtitle.TextSize = 13
modeModalSubtitle.TextWrapped = true
modeModalSubtitle.TextXAlignment = Enum.TextXAlignment.Left
modeModalSubtitle.ZIndex = 47
modeModalSubtitle.Parent = modeModalCard

local modeCardsContainer = Instance.new("Frame")
modeCardsContainer.Name = "CardsContainer"
modeCardsContainer.Position = UDim2.fromOffset(24, 80)
modeCardsContainer.Size = UDim2.new(1, -48, 1, -104)
modeCardsContainer.BackgroundTransparency = 1
modeCardsContainer.ZIndex = 47
modeCardsContainer.Parent = modeModalCard

local function createModeOptionCard(
	cardName: string,
	anchorX: number,
	posScaleX: number,
	tagText: string,
	titleText: string,
	descriptionText: string,
	ctaText: string,
	isPrimaryCta: boolean
): TextButton
	local optionCard = Instance.new("Frame")
	optionCard.Name = cardName
	optionCard.AnchorPoint = Vector2.new(anchorX, 0)
	optionCard.Position = UDim2.fromScale(posScaleX, 0)
	optionCard.Size = UDim2.new(0.486, 0, 1, 0)
	optionCard.BackgroundColor3 = COLOR_SURFACE_SECONDARY
	optionCard.BorderSizePixel = 0
	optionCard.ZIndex = 48
	optionCard.Parent = modeCardsContainer
	ensureCorner(optionCard, CORNER_RADIUS_SM)
	ensureStroke(optionCard, COLOR_BORDER_SUBTLE, 1)

	local tagLabel = Instance.new("TextLabel")
	tagLabel.Name = "Tag"
	tagLabel.Position = UDim2.fromOffset(16, 16)
	tagLabel.Size = UDim2.new(1, -32, 0, 14)
	tagLabel.BackgroundTransparency = 1
	tagLabel.Font = Enum.Font.GothamBold
	tagLabel.Text = tagText
	tagLabel.TextColor3 = if isPrimaryCta then COLOR_CTA_PRIMARY_HOVER else COLOR_TEXT_MUTED
	tagLabel.TextSize = 11
	tagLabel.TextXAlignment = Enum.TextXAlignment.Left
	tagLabel.ZIndex = 49
	tagLabel.Parent = optionCard

	local titleLabel = Instance.new("TextLabel")
	titleLabel.Name = "OptionTitle"
	titleLabel.Position = UDim2.fromOffset(16, 34)
	titleLabel.Size = UDim2.new(1, -32, 0, 24)
	titleLabel.BackgroundTransparency = 1
	titleLabel.Font = Enum.Font.GothamBold
	titleLabel.Text = titleText
	titleLabel.TextColor3 = COLOR_TEXT_PRIMARY
	titleLabel.TextSize = 17
	titleLabel.TextXAlignment = Enum.TextXAlignment.Left
	titleLabel.ZIndex = 49
	titleLabel.Parent = optionCard

	local descriptionLabel = Instance.new("TextLabel")
	descriptionLabel.Name = "OptionDescription"
	descriptionLabel.Position = UDim2.fromOffset(16, 66)
	descriptionLabel.Size = UDim2.new(1, -32, 1, -130)
	descriptionLabel.BackgroundTransparency = 1
	descriptionLabel.Font = Enum.Font.Gotham
	descriptionLabel.Text = descriptionText
	descriptionLabel.TextColor3 = COLOR_TEXT_SECONDARY
	descriptionLabel.TextSize = 13
	descriptionLabel.TextWrapped = true
	descriptionLabel.TextXAlignment = Enum.TextXAlignment.Left
	descriptionLabel.TextYAlignment = Enum.TextYAlignment.Top
	descriptionLabel.LineHeight = 1.25
	descriptionLabel.ZIndex = 49
	descriptionLabel.Parent = optionCard

	local ctaButton = Instance.new("TextButton")
	ctaButton.Name = "ActionButton"
	ctaButton.AnchorPoint = Vector2.new(0.5, 1)
	ctaButton.Position = UDim2.new(0.5, 0, 1, -16)
	ctaButton.Size = UDim2.new(1, -32, 0, 40)
	ctaButton.BackgroundColor3 = if isPrimaryCta then COLOR_CTA_PRIMARY else COLOR_SURFACE_ELEVATED
	ctaButton.BorderSizePixel = 0
	ctaButton.AutoButtonColor = false
	ctaButton.Font = Enum.Font.GothamBold
	ctaButton.Text = ctaText
	ctaButton.TextColor3 = COLOR_TEXT_PRIMARY
	ctaButton.TextSize = 13
	ctaButton.ZIndex = 50
	ctaButton.Parent = optionCard
	ensureCorner(ctaButton, CORNER_RADIUS_SM)

	local ctaStroke = ensureStroke(
		ctaButton,
		if isPrimaryCta then COLOR_CTA_PRIMARY_HOVER else COLOR_BORDER_STRONG,
		1
	)
	local ctaScale = ensureScale(ctaButton, "ButtonScale")
	bindSubtleButtonFeedback(
		ctaButton,
		ctaScale,
		ctaStroke,
		if isPrimaryCta then COLOR_CTA_PRIMARY else COLOR_SURFACE_ELEVATED,
		if isPrimaryCta then COLOR_CTA_PRIMARY_HOVER else COLOR_BORDER_SUBTLE,
		if isPrimaryCta then COLOR_CTA_PRIMARY_HOVER else COLOR_BORDER_STRONG,
		if isPrimaryCta then COLOR_TEXT_PRIMARY else COLOR_TEXT_SECONDARY
	)

	return ctaButton
end

local selectTimedButton = createModeOptionCard(
	"OpcaoComCronometro",
	0,
	0,
	"RANKING GLOBAL",
	"Com Cronômetro",
	"• Limite de 10 minutos por tentativa\n• Cronômetro visível no topo da tela\n• Pontuação e tempo elegíveis ao Top 10 Global",
	"Jogar com Cronômetro",
	true
)

local selectFreeButton = createModeOptionCard(
	"OpcaoSemCronometro",
	1,
	1,
	"PRÁTICA LIVRE",
	"Sem Cronômetro",
	"• Sem limite de tempo para responder\n• Cronômetro oculto durante o percurso\n• Progresso não contabilizado no Ranking Global",
	"Jogar no Modo Livre",
	false
)

local isModeModalOpen = false

local function canDismissModeModal(): boolean
	local hasMode = localPlayer:GetAttribute("ModoComCronometro") ~= nil
	local currentState = localPlayer:GetAttribute("PlayerState")
	return hasMode and currentState ~= PLAYER_STATES.SELECTING_MODE
end

local function updateModeModalDismissVisibility()
	closeModeModalButton.Visible = canDismissModeModal()
end

local function openModeModal()
	updateModeModalDismissVisibility()
	if isModeModalOpen then
		return
	end
	isModeModalOpen = true
	modeModalBackdrop.Visible = true
	modeModalScale.Scale = 0.96
	modeModalBackdrop.BackgroundTransparency = 1
	local openInfo = TweenInfo.new(0.18, Enum.EasingStyle.Quint, Enum.EasingDirection.Out)
	TweenService:Create(modeModalBackdrop, openInfo, { BackgroundTransparency = 0.42 }):Play()
	TweenService:Create(modeModalScale, openInfo, { Scale = 1 }):Play()
end

local function closeModeModal(forceClose: boolean?)
	if not isModeModalOpen then
		return
	end
	if not forceClose and not canDismissModeModal() then
		return
	end
	isModeModalOpen = false
	local closeInfo = TweenInfo.new(0.14, Enum.EasingStyle.Quad, Enum.EasingDirection.In)
	local scaleTween = TweenService:Create(modeModalScale, closeInfo, { Scale = 0.96 })
	TweenService:Create(modeModalBackdrop, closeInfo, { BackgroundTransparency = 1 }):Play()
	scaleTween:Play()
	scaleTween.Completed:Wait()
	if not isModeModalOpen then
		modeModalBackdrop.Visible = false
		modeModalScale.Scale = 1
	end
end

local function submitModeChoice(enableTimedMode: boolean)
	pcall(function()
		soundUiClick:Play()
	end)
	if DefinirModoJogo then
		DefinirModoJogo:FireServer(enableTimedMode)
	end
	closeModeModal(true)
end

trackConnection(closeModeModalButton.Activated:Connect(function()
	closeModeModal(false)
end))
trackConnection(switchModeButton.Activated:Connect(openModeModal))
trackConnection(selectTimedButton.Activated:Connect(function()
	submitModeChoice(true)
end))
trackConnection(selectFreeButton.Activated:Connect(function()
	submitModeChoice(false)
end))

-- ============================================================================
-- ESTILIZAÇÃO LIMPA DO PAINEL DE QUESTÕES (FRAME DAS PERGUNTAS)
-- ============================================================================

local preservedQuestionChildren: { [Instance]: boolean } = {
	[questionTextLabel] = true,
	[closeQuestionButton] = true,
}
for _, button in ipairs(answerButtons) do
	preservedQuestionChildren[button] = true
end

removeLegacyGradients(questionFrame)
removeLegacyGradients(questionTextLabel)
removeLegacyGradients(closeQuestionButton)

for _, child in ipairs(questionFrame:GetChildren()) do
	if child:IsA("GuiObject") and not preservedQuestionChildren[child] then
		if child.Name ~= "CategoriaNivelLabel" and child.Name ~= "InstrucaoQuestaoLabel" and child.Name ~= "SeparadorCabecalho" then
			child.Visible = false
		end
	end
end

questionFrame.AnchorPoint = Vector2.new(0.5, 0.5)
questionFrame.Position = UDim2.fromScale(0.5, 0.52)
questionFrame.Size = UDim2.new(0.9, 0, 0.74, 0)
questionFrame.BackgroundColor3 = COLOR_SURFACE_PRIMARY
questionFrame.BackgroundTransparency = 0.02
questionFrame.BorderSizePixel = 0
questionFrame.Visible = false
ensureSizeConstraint(questionFrame, Vector2.new(312, 312), Vector2.new(544, 416))
ensureCorner(questionFrame, CORNER_RADIUS_MD)
ensureStroke(questionFrame, COLOR_BORDER_SUBTLE, 1)
local questionFrameScale = ensureScale(questionFrame, "FrameQuizScale")

local questionCategoryLabel = getOrCreateGuiObject(questionFrame, "CategoriaNivelLabel", "TextLabel") :: TextLabel
questionCategoryLabel.AnchorPoint = Vector2.new(0, 0)
questionCategoryLabel.Position = UDim2.fromOffset(24, 18)
questionCategoryLabel.Size = UDim2.new(1, -80, 0, 16)
questionCategoryLabel.BackgroundTransparency = 1
questionCategoryLabel.Font = Enum.Font.GothamBold
questionCategoryLabel.Text = "QUESTÃO"
questionCategoryLabel.TextColor3 = COLOR_CTA_PRIMARY_HOVER
questionCategoryLabel.TextSize = 11
questionCategoryLabel.TextXAlignment = Enum.TextXAlignment.Left

local questionInstructionLabel = getOrCreateGuiObject(questionFrame, "InstrucaoQuestaoLabel", "TextLabel") :: TextLabel
questionInstructionLabel.AnchorPoint = Vector2.new(0, 0)
questionInstructionLabel.Position = UDim2.fromOffset(24, 124)
questionInstructionLabel.Size = UDim2.new(1, -48, 0, 16)
questionInstructionLabel.BackgroundTransparency = 1
questionInstructionLabel.Font = Enum.Font.GothamMedium
questionInstructionLabel.Text = "Selecione a única afirmação FALSA abaixo:"
questionInstructionLabel.TextColor3 = COLOR_TEXT_MUTED
questionInstructionLabel.TextSize = 12
questionInstructionLabel.TextXAlignment = Enum.TextXAlignment.Left

local headerDivider = getOrCreateGuiObject(questionFrame, "SeparadorCabecalho", "Frame") :: Frame
headerDivider.Position = UDim2.fromOffset(24, 148)
headerDivider.Size = UDim2.new(1, -48, 0, 1)
headerDivider.BackgroundColor3 = COLOR_BORDER_SUBTLE
headerDivider.BorderSizePixel = 0

closeQuestionButton.AnchorPoint = Vector2.new(1, 0)
closeQuestionButton.Position = UDim2.new(1, -16, 0, 16)
closeQuestionButton.Size = UDim2.fromOffset(32, 32)
closeQuestionButton.BackgroundColor3 = COLOR_SURFACE_SECONDARY
closeQuestionButton.BackgroundTransparency = 0
closeQuestionButton.BorderSizePixel = 0
closeQuestionButton.AutoButtonColor = false
closeQuestionButton.Font = Enum.Font.GothamBold
closeQuestionButton.Text = "×"
closeQuestionButton.TextColor3 = COLOR_TEXT_SECONDARY
closeQuestionButton.TextScaled = false
closeQuestionButton.TextSize = 20
ensureCorner(closeQuestionButton, CORNER_RADIUS_SM)
local closeQuestionStroke = ensureStroke(closeQuestionButton, COLOR_BORDER_SUBTLE, 1)
local closeQuestionScale = ensureScale(closeQuestionButton, "ButtonScale")
bindSubtleButtonFeedback(
	closeQuestionButton,
	closeQuestionScale,
	closeQuestionStroke,
	COLOR_SURFACE_SECONDARY,
	COLOR_SURFACE_ELEVATED,
	COLOR_BORDER_SUBTLE,
	COLOR_BORDER_STRONG
)

questionTextLabel.AnchorPoint = Vector2.new(0, 0)
questionTextLabel.Position = UDim2.fromOffset(24, 40)
questionTextLabel.Size = UDim2.new(1, -48, 0, 78)
questionTextLabel.BackgroundTransparency = 1
questionTextLabel.BorderSizePixel = 0
questionTextLabel.Font = Enum.Font.GothamBold
questionTextLabel.TextColor3 = COLOR_TEXT_PRIMARY
questionTextLabel.TextWrapped = true
questionTextLabel.TextScaled = true
questionTextLabel.TextXAlignment = Enum.TextXAlignment.Left
questionTextLabel.TextYAlignment = Enum.TextYAlignment.Center
ensureTextSizeConstraint(questionTextLabel, 15, 21)

local answerButtonStrokes: { UIStroke } = {}
local hasSubmittedCurrentAnswer = false

for index, button in ipairs(answerButtons) do
	removeLegacyGradients(button)
	button.AnchorPoint = Vector2.new(0.5, 0)
	button.Position = UDim2.new(0.5, 0, 0, 164 + (index - 1) * 76)
	button.Size = UDim2.new(1, -48, 0, 64)
	button.BackgroundColor3 = COLOR_SURFACE_SECONDARY
	button.BackgroundTransparency = 0
	button.BorderSizePixel = 0
	button.AutoButtonColor = false
	button.Font = Enum.Font.GothamMedium
	button.TextColor3 = COLOR_TEXT_PRIMARY
	button.TextWrapped = true
	button.TextScaled = true
	button.TextXAlignment = Enum.TextXAlignment.Left
	button.TextYAlignment = Enum.TextYAlignment.Center
	ensureCorner(button, CORNER_RADIUS_SM)
	ensurePadding(button, 8, 8, 16, 16)
	ensureTextSizeConstraint(button, 13, 17)

	local stroke = ensureStroke(button, COLOR_BORDER_SUBTLE, 1)
	answerButtonStrokes[index] = stroke

	local hoverInfo = TweenInfo.new(0.12, Enum.EasingStyle.Quad, Enum.EasingDirection.Out)
	trackConnection(button.MouseEnter:Connect(function()
		if not hasSubmittedCurrentAnswer and button.Active then
			TweenService:Create(button, hoverInfo, { BackgroundColor3 = COLOR_SURFACE_ELEVATED }):Play()
			TweenService:Create(stroke, hoverInfo, { Color = COLOR_BORDER_STRONG }):Play()
		end
	end))
	trackConnection(button.MouseLeave:Connect(function()
		if not hasSubmittedCurrentAnswer and button.Active then
			TweenService:Create(button, hoverInfo, { BackgroundColor3 = COLOR_SURFACE_SECONDARY }):Play()
			TweenService:Create(stroke, hoverInfo, { Color = COLOR_BORDER_SUBTLE }):Play()
		end
	end))
end

local function resetAnswerButtonsVisualState()
	for index, button in ipairs(answerButtons) do
		button.BackgroundColor3 = COLOR_SURFACE_SECONDARY
		button.TextColor3 = COLOR_TEXT_PRIMARY
		button.BackgroundTransparency = 0
		button.TextTransparency = 0
		button.Active = true
		button.AutoButtonColor = false
		local stroke = answerButtonStrokes[index]
		if stroke then
			stroke.Color = COLOR_BORDER_SUBTLE
			stroke.Transparency = 0
		end
	end
end

local isClosingQuestion = false
local function closeQuestionModal()
	if not questionFrame.Visible or isClosingQuestion then
		questionFrame.Visible = false
		hasSubmittedCurrentAnswer = false
		resetAnswerButtonsVisualState()
		return
	end
	isClosingQuestion = true
	local closeTween = TweenService:Create(
		questionFrameScale,
		TweenInfo.new(0.14, Enum.EasingStyle.Quad, Enum.EasingDirection.In),
		{ Scale = 0.96 }
	)
	closeTween:Play()
	closeTween.Completed:Wait()
	questionFrame.Visible = false
	questionFrameScale.Scale = 1
	isClosingQuestion = false
	hasSubmittedCurrentAnswer = false
	resetAnswerButtonsVisualState()
end

trackConnection(closeQuestionButton.Activated:Connect(closeQuestionModal))

-- ============================================================================
-- TOAST DE NOTIFICAÇÕES CONTEXTUAIS
-- ============================================================================

local currentToastToken = 0
local activeToastTween: Tween? = nil

local function showToastNotification(message: string, accentColor: Color3?)
	currentToastToken += 1
	local token = currentToastToken
	if activeToastTween then
		activeToastTween:Cancel()
		activeToastTween = nil
	end

	toastTextLabel.Text = message
	toastTextLabel.TextTransparency = 0
	toastAccentBar.BackgroundColor3 = accentColor or COLOR_CTA_PRIMARY
	toastAccentBar.BackgroundTransparency = 0
	toastFrame.BackgroundTransparency = 0.05
	toastFrame.Visible = true

	task.delay(TOAST_DISPLAY_SECONDS, function()
		if token ~= currentToastToken then
			return
		end
		local fadeInfo = TweenInfo.new(0.22, Enum.EasingStyle.Quad, Enum.EasingDirection.Out)
		activeToastTween = TweenService:Create(toastFrame, fadeInfo, { BackgroundTransparency = 1 })
		TweenService:Create(toastTextLabel, fadeInfo, { TextTransparency = 1 }):Play()
		TweenService:Create(toastAccentBar, fadeInfo, { BackgroundTransparency = 1 }):Play()
		if activeToastTween then
			activeToastTween:Play()
			activeToastTween.Completed:Wait()
		end
		if token == currentToastToken then
			toastFrame.Visible = false
		end
	end)
end

trackConnection(NotificarMensagem.OnClientEvent:Connect(showToastNotification))

-- ============================================================================
-- FORMATAÇÃO DE TEMPO E SINCRONIZAÇÃO DE ESTADO DO HUD
-- ============================================================================

local function formatTimeMillis(seconds: number): string
	local totalMilliseconds = math.floor(math.max(0, seconds) * 1000 + 0.5)
	local minutes = math.floor(totalMilliseconds / 60000)
	local remainingSeconds = math.floor(totalMilliseconds / 1000) % 60
	local milliseconds = totalMilliseconds % 1000
	return string.format("%02d:%02d.%03d", minutes, remainingSeconds, milliseconds)
end

local function formatTimeMinutesSeconds(seconds: number): string
	local totalSeconds = math.max(0, math.ceil(seconds))
	local minutes = math.floor(totalSeconds / 60)
	local remainingSeconds = totalSeconds % 60
	return string.format("%02d:%02d", minutes, remainingSeconds)
end

local currentPhase = "Tutorial"
local lastStatusCountdownText = ""
local lastAttemptStopwatchText = ""
local lastRewardTimerText = ""

local function renderApprovedFrozenTimer(): boolean
	local completionTime = localPlayer:GetAttribute("TempoConclusaoQuiz")
	local frozenRemaining = localPlayer:GetAttribute("TempoRestanteCongeladoQuiz")
	if typeof(completionTime) ~= "number" or typeof(frozenRemaining) ~= "number" then
		return false
	end
	timerLabel.Text = formatTimeMillis(completionTime)
	timerLabel.TextColor3 = COLOR_ACCENT_SUCCESS_BORDER
	local currentScore = tonumber(localPlayer:GetAttribute("AcertosQuiz")) or 0
	statusLabel.Text = string.format("%d/%d acertos · Recompensas liberadas", currentScore, QuizConfig.MAX_SCORE)
	statusLabel.TextColor3 = COLOR_TEXT_SECONDARY
	return true
end

local function updateModeHudControls()
	updateModeModalDismissVisibility()
	local timedMode = localPlayer:GetAttribute("ModoComCronometro")
	if timedMode == false then
		timerLabel.Visible = false
		switchModeButton.Text = "Modo: Livre"
		local attempt = math.max(1, tonumber(localPlayer:GetAttribute("NumeroTentativaQuiz")) or 1)
		local currentScore = tonumber(localPlayer:GetAttribute("AcertosQuiz")) or 0
		if currentScore >= QuizConfig.REWARD_MIN_SCORE then
			statusLabel.Text = string.format("Modo Livre · %d/%d acertos · Recompensas liberadas", currentScore, QuizConfig.MAX_SCORE)
		elseif currentPhase == "Ativa" then
			statusLabel.Text = string.format("Modo Livre · Tentativa %d", attempt)
		else
			statusLabel.Text = "Modo Livre · Conclua o tutorial para iniciar"
		end
		statusLabel.TextColor3 = COLOR_TEXT_SECONDARY
	elseif timedMode == true then
		timerLabel.Visible = true
		switchModeButton.Text = "Modo: Ranqueado"
	else
		timerLabel.Visible = false
		switchModeButton.Text = "Modo: Selecionar"
		statusLabel.Text = "Selecione um modo para iniciar"
		statusLabel.TextColor3 = COLOR_TEXT_SECONDARY
	end
end

local function applyRoundStateSnapshot(snapshot: RoundStateSnapshot)
	currentPhase = if typeof(snapshot.Fase) == "string"
		then snapshot.Fase
		else (if snapshot.Ativa then "Ativa" else "Tutorial")

	updateModeHudControls()

	local timedMode = localPlayer:GetAttribute("ModoComCronometro")
	if timedMode ~= true then
		return
	end
	if renderApprovedFrozenTimer() then
		return
	end

	if currentPhase == "Ativa" then
		local attempt = math.max(1, tonumber(localPlayer:GetAttribute("NumeroTentativaQuiz")) or 1)
		statusLabel.Text = string.format("Tentativa %d", attempt)
		statusLabel.TextColor3 = COLOR_TEXT_SECONDARY
	else
		timerLabel.Text = "--:--.---"
		timerLabel.TextColor3 = COLOR_TEXT_PRIMARY
		statusLabel.Text = "Conclua o tutorial para iniciar"
		statusLabel.TextColor3 = COLOR_TEXT_SECONDARY
	end
end

local function updateRewardAreaCountdownHud(nowServer: number)
	local rewardEndTimestamp = localPlayer:GetAttribute("RewardAreaEndTimestamp")
	local playerState = localPlayer:GetAttribute("PlayerState")

	if typeof(rewardEndTimestamp) ~= "number" or rewardEndTimestamp <= 0 then
		if rewardHudPanel.Visible then
			rewardHudPanel.Visible = false
			lastRewardTimerText = ""
		end
		return
	end

	local remainingSeconds = math.max(0, rewardEndTimestamp - nowServer)
	if remainingSeconds <= 0 and playerState ~= PLAYER_STATES.IN_REWARD_AREA then
		rewardHudPanel.Visible = false
		return
	end

	if not rewardHudPanel.Visible then
		rewardHudPanel.Visible = true
	end

	rewardHudCaption.Text = if playerState == PLAYER_STATES.IN_REWARD_AREA
		then "ÁREA DE RECOMPENSAS"
		else "TEMPO DE RECOMPENSAS"

	local formattedMMSS = formatTimeMinutesSeconds(remainingSeconds)
	if formattedMMSS ~= lastRewardTimerText then
		lastRewardTimerText = formattedMMSS
		rewardHudTimerLabel.Text = formattedMMSS
	end

	if remainingSeconds <= REWARD_CRITICAL_THRESHOLD_SECONDS then
		rewardHudTimerLabel.TextColor3 = COLOR_ACCENT_DANGER_BORDER
		rewardHudStroke.Color = COLOR_ACCENT_DANGER_BORDER
	elseif remainingSeconds <= REWARD_WARNING_THRESHOLD_SECONDS then
		rewardHudTimerLabel.TextColor3 = COLOR_ACCENT_WARNING
		rewardHudStroke.Color = COLOR_ACCENT_WARNING
	else
		rewardHudTimerLabel.TextColor3 = COLOR_TEXT_PRIMARY
		rewardHudStroke.Color = COLOR_BORDER_SUBTLE
	end
end

-- ============================================================================
-- SINCRONIZAÇÃO DE PORTAS E ESCUDOS DE CORREDOR (RESPEITANDO COLLISION GROUPS)
-- ============================================================================

local function applyDoorVisualAndLocalCollision(doorName: string, isOpen: boolean)
	-- Portão de Recompensas e Barreira do Tutorial são governados exclusivamente por CollisionGroups no servidor
	if doorName == QuizConfig.REWARD_GATE_NAME then
		return
	end

	local isTutorialDoor = doorName == "PortaNivel0 Geografia"
	local doorInstance = Workspace:FindFirstChild(doorName, true)

	local function updatePart(part: BasePart)
		part.Transparency = if isOpen then DOOR_OPEN_TRANSPARENCY else 0
		if not isTutorialDoor then
			part.CanCollide = not isOpen
		end
	end

	if doorInstance then
		if doorInstance:IsA("BasePart") then
			updatePart(doorInstance)
		elseif doorInstance:IsA("Model") then
			for _, descendant in ipairs(doorInstance:GetDescendants()) do
				if descendant:IsA("BasePart") then
					updatePart(descendant)
				end
			end
		end
	end

	if not isTutorialDoor then
		local barriersFolder = Workspace:FindFirstChild(DOOR_BARRIERS_FOLDER_NAME)
		local corridorShield = barriersFolder and barriersFolder:FindFirstChild("BarreiraFisica_" .. doorName)
		if corridorShield and corridorShield:IsA("BasePart") then
			corridorShield.CanCollide = not isOpen
		end
	end
end

trackConnection(ControlarPorta.OnClientEvent:Connect(function(doorName: string, isOpen: boolean)
	if typeof(doorName) == "string" and typeof(isOpen) == "boolean" then
		applyDoorVisualAndLocalCollision(doorName, isOpen)
	end
end))

local function syncAllLocalDoors()
	for level = 0, QuizConfig.MAX_GEOGRAPHY_LEVEL do
		local isOpen = localPlayer:GetAttribute("QuizFeito_Nivel" .. level) == true
		applyDoorVisualAndLocalCollision(string.format("PortaNivel%d Geografia", level), isOpen)
	end
	for level = 1, QuizConfig.MAX_HISTORY_LEVEL do
		local isOpen = localPlayer:GetAttribute("QuizHistoriaFeito_Nivel" .. level) == true
		applyDoorVisualAndLocalCollision(string.format("PortaNivel%d História", level), isOpen)
	end
end

for level = 0, QuizConfig.MAX_GEOGRAPHY_LEVEL do
	local attributeName = "QuizFeito_Nivel" .. level
	local doorName = string.format("PortaNivel%d Geografia", level)
	trackConnection(localPlayer:GetAttributeChangedSignal(attributeName):Connect(function()
		applyDoorVisualAndLocalCollision(doorName, localPlayer:GetAttribute(attributeName) == true)
	end))
end

for level = 1, QuizConfig.MAX_HISTORY_LEVEL do
	local attributeName = "QuizHistoriaFeito_Nivel" .. level
	local doorName = string.format("PortaNivel%d História", level)
	trackConnection(localPlayer:GetAttributeChangedSignal(attributeName):Connect(function()
		applyDoorVisualAndLocalCollision(doorName, localPlayer:GetAttribute(attributeName) == true)
	end))
end

local function observeDoorBarriersFolder(folder: Instance)
	trackConnection(folder.ChildAdded:Connect(function(child: Instance)
		if child:IsA("BasePart") then
			local targetDoorName = child:GetAttribute("TargetDoorName")
			if typeof(targetDoorName) == "string" then
				syncAllLocalDoors()
			end
		end
	end))
end

local existingBarriersFolder = Workspace:FindFirstChild(DOOR_BARRIERS_FOLDER_NAME)
if existingBarriersFolder then
	observeDoorBarriersFolder(existingBarriersFolder)
end
trackConnection(Workspace.ChildAdded:Connect(function(child: Instance)
	if child.Name == DOOR_BARRIERS_FOLDER_NAME then
		observeDoorBarriersFolder(child)
		syncAllLocalDoors()
	end
end))

-- ============================================================================
-- INDICADOR 3D FOSCO SOBRE O PORTÃO DE RECOMPENSAS (SEM NEON / SEM POINTLIGHT)
-- ============================================================================

local rewardArrowModel: Model? = nil
local rewardArrowRenderConn: RBXScriptConnection? = nil

local function destroyRewardArrowIndicator()
	if rewardArrowRenderConn then
		rewardArrowRenderConn:Disconnect()
		rewardArrowRenderConn = nil
	end
	if rewardArrowModel then
		rewardArrowModel:Destroy()
		rewardArrowModel = nil
	end
end

local function createRewardArrowIndicator()
	if rewardArrowModel then
		return
	end

	local gatePart = Workspace:FindFirstChild(QuizConfig.REWARD_GATE_NAME, true)
	local basePosition = if gatePart and gatePart:IsA("BasePart")
		then gatePart.Position + Vector3.new(0, gatePart.Size.Y * 0.5 + 4.0, 0)
		else Vector3.new(405.025, 1058.0, 79.6)

	local model = Instance.new("Model")
	model.Name = "FlechaRecompensasLocal"

	local shaft = Instance.new("Part")
	shaft.Name = "Haste"
	shaft.Size = Vector3.new(1.1, 2.8, 1.1)
	shaft.Material = Enum.Material.SmoothPlastic
	shaft.Color = COLOR_ARROW_MATTE_GOLD
	shaft.Anchored = true
	shaft.CanCollide = false
	shaft.CanTouch = false
	shaft.CanQuery = false
	shaft.CastShadow = false
	shaft.Parent = model

	local head = Instance.new("WedgePart")
	head.Name = "Ponta"
	head.Size = Vector3.new(2.8, 2.2, 2.8)
	head.Material = Enum.Material.SmoothPlastic
	head.Color = COLOR_ARROW_MATTE_GOLD
	head.Anchored = true
	head.CanCollide = false
	head.CanTouch = false
	head.CanQuery = false
	head.CastShadow = false
	head.Parent = model

	local billboard = Instance.new("BillboardGui")
	billboard.Name = "IndicadorBillboard"
	billboard.Size = UDim2.fromOffset(296, 60)
	billboard.StudsOffset = Vector3.new(0, 3.2, 0)
	billboard.AlwaysOnTop = true
	billboard.MaxDistance = 280
	billboard.LightInfluence = 0
	billboard.Adornee = shaft
	billboard.Parent = model

	local banner = Instance.new("Frame")
	banner.Size = UDim2.fromScale(1, 1)
	banner.BackgroundColor3 = COLOR_SURFACE_PRIMARY
	banner.BackgroundTransparency = 0.06
	banner.BorderSizePixel = 0
	banner.Parent = billboard
	ensureCorner(banner, CORNER_RADIUS_SM)
	ensureStroke(banner, COLOR_BORDER_STRONG, 1)

	local bannerTitle = Instance.new("TextLabel")
	bannerTitle.Position = UDim2.fromOffset(12, 8)
	bannerTitle.Size = UDim2.new(1, -24, 0, 20)
	bannerTitle.BackgroundTransparency = 1
	bannerTitle.Font = Enum.Font.GothamBold
	bannerTitle.Text = "ÁREA DE RECOMPENSAS LIBERADA"
	bannerTitle.TextColor3 = COLOR_TEXT_PRIMARY
	bannerTitle.TextSize = 13
	bannerTitle.Parent = banner

	local bannerSubtitle = Instance.new("TextLabel")
	bannerSubtitle.Position = UDim2.fromOffset(12, 30)
	bannerSubtitle.Size = UDim2.new(1, -24, 0, 18)
	bannerSubtitle.BackgroundTransparency = 1
	bannerSubtitle.Font = Enum.Font.GothamMedium
	bannerSubtitle.Text = "Atravesse o portal à frente (limite de 10 min)"
	bannerSubtitle.TextColor3 = COLOR_TEXT_SECONDARY
	bannerSubtitle.TextSize = 12
	bannerSubtitle.Parent = banner

	model.PrimaryPart = shaft
	model.Parent = Workspace
	rewardArrowModel = model

	local startClock = os.clock()
	rewardArrowRenderConn = RunService.RenderStepped:Connect(function()
		if not rewardArrowModel or not shaft.Parent or not head.Parent then
			destroyRewardArrowIndicator()
			return
		end
		local elapsed = os.clock() - startClock
		local verticalOffset = math.sin(elapsed * 2.2) * 0.45
		local yawAngle = (elapsed * 1.1) % (math.pi * 2)

		local pivotCFrame = CFrame.new(basePosition + Vector3.new(0, verticalOffset, 0))
			* CFrame.Angles(0, yawAngle, 0)
		shaft.CFrame = pivotCFrame * CFrame.new(0, 1.9, 0)
		head.CFrame = pivotCFrame * CFrame.new(0, -0.5, 0) * CFrame.Angles(0, 0, math.pi)
	end)
end

local function updateRewardArrowVisibility()
	local score = localPlayer:GetAttribute("AcertosQuiz")
	local playerState = localPlayer:GetAttribute("PlayerState")
	local shouldDisplay = typeof(score) == "number"
		and score >= QuizConfig.REWARD_MIN_SCORE
		and playerState ~= PLAYER_STATES.IN_REWARD_AREA

	if shouldDisplay then
		createRewardArrowIndicator()
	else
		destroyRewardArrowIndicator()
	end
end

trackConnection(localPlayer:GetAttributeChangedSignal("AcertosQuiz"):Connect(function()
	updateRewardArrowVisibility()
	updateModeHudControls()
end))

trackConnection(localPlayer:GetAttributeChangedSignal("PlayerState"):Connect(function()
	updateRewardArrowVisibility()
	updateModeModalDismissVisibility()
end))

trackConnection(localPlayer:GetAttributeChangedSignal("ModoComCronometro"):Connect(updateModeHudControls))

trackConnection(localPlayer.CharacterAdded:Connect(function()
	task.wait(0.2)
	syncAllLocalDoors()
	updateRewardArrowVisibility()
end))

trackConnection(ResetarClient.OnClientEvent:Connect(function()
	closeQuestionModal()
	syncAllLocalDoors()
	updateRewardArrowVisibility()
end))

-- ============================================================================
-- FLUXO DE ABERTURA E RESPOSTA DE QUESTÕES
-- ============================================================================

trackConnection(AbrirQuiz.OnClientEvent:Connect(function(payload: QuizPromptPayload)
	if typeof(payload) ~= "table" or typeof(payload.Alternativas) ~= "table" then
		return
	end

	resetAnswerButtonsVisualState()
	hasSubmittedCurrentAnswer = false

	local levelNumber = tonumber(payload.Nivel) or 0
	questionCategoryLabel.Text = if levelNumber == 0
		then "TUTORIAL OBRIGATÓRIO"
		else string.format("%s · NÍVEL %d", string.upper(tostring(payload.Materia or "QUESTÃO")), levelNumber)

	questionTextLabel.Text = tostring(payload.Nome or "")
	local choices = payload.Alternativas :: { string }

	for index, button in ipairs(answerButtons) do
		local choiceText = choices[index]
		local hasChoice = typeof(choiceText) == "string"
		button.Visible = hasChoice
		button.Text = if hasChoice then choiceText else ""
		button.BackgroundTransparency = 1
		button.TextTransparency = 1
	end

	pcall(function()
		soundQuestionOpen:Play()
	end)

	questionFrameScale.Scale = 0.96
	questionTextLabel.TextTransparency = 1
	questionFrame.Visible = true

	local openInfo = TweenInfo.new(0.18, Enum.EasingStyle.Quint, Enum.EasingDirection.Out)
	TweenService:Create(questionFrameScale, openInfo, { Scale = 1 }):Play()
	TweenService:Create(questionTextLabel, openInfo, { TextTransparency = 0 }):Play()

	for index, button in ipairs(answerButtons) do
		if button.Visible then
			local targetY = 164 + (index - 1) * 76
			button.Position = UDim2.new(0.5, 0, 0, targetY + 8)
			task.delay(0.04 * index, function()
				if questionFrame.Visible then
					TweenService:Create(button, openInfo, {
						Position = UDim2.new(0.5, 0, 0, targetY),
						BackgroundTransparency = 0,
						TextTransparency = 0,
					}):Play()
				end
			end)
		end
	end
end))

for index, button in ipairs(answerButtons) do
	trackConnection(button.Activated:Connect(function()
		if hasSubmittedCurrentAnswer or not questionFrame.Visible or not button.Visible then
			return
		end
		hasSubmittedCurrentAnswer = true
		for _, choiceButton in ipairs(answerButtons) do
			choiceButton.Active = false
		end

		local ok, rawResult = pcall(function()
			return EnviarResposta:InvokeServer(index)
		end)
		if not ok or typeof(rawResult) ~= "table" then
			hasSubmittedCurrentAnswer = false
			resetAnswerButtonsVisualState()
			showToastNotification("Falha de comunicação ao enviar resposta. Tente novamente.", COLOR_ACCENT_DANGER_BORDER)
			return
		end

		local result = rawResult :: AnswerSubmissionResult
		if not result.Aceito then
			closeQuestionModal()
			if typeof(result.Mensagem) == "string" then
				showToastNotification(result.Mensagem, COLOR_ACCENT_WARNING)
			end
			return
		end

		local feedbackInfo = TweenInfo.new(0.15, Enum.EasingStyle.Quad, Enum.EasingDirection.Out)
		local selectedStroke = answerButtonStrokes[index]

		if result.Acertou then
			pcall(function()
				soundAnswerCorrect:Play()
			end)
			TweenService:Create(button, feedbackInfo, { BackgroundColor3 = COLOR_ACCENT_SUCCESS }):Play()
			if selectedStroke then
				TweenService:Create(selectedStroke, feedbackInfo, { Color = COLOR_ACCENT_SUCCESS_BORDER }):Play()
			end
		else
			pcall(function()
				soundAnswerWrong:Play()
			end)
			TweenService:Create(button, feedbackInfo, { BackgroundColor3 = COLOR_ACCENT_DANGER }):Play()
			if selectedStroke then
				TweenService:Create(selectedStroke, feedbackInfo, { Color = COLOR_ACCENT_DANGER_BORDER }):Play()
			end
			local correctIndex = tonumber(result.IndiceCorreto)
			if correctIndex and answerButtons[correctIndex] then
				TweenService:Create(answerButtons[correctIndex], feedbackInfo, {
					BackgroundColor3 = COLOR_ACCENT_SUCCESS,
				}):Play()
				if answerButtonStrokes[correctIndex] then
					TweenService:Create(answerButtonStrokes[correctIndex], feedbackInfo, {
						Color = COLOR_ACCENT_SUCCESS_BORDER,
					}):Play()
				end
			end
		end

		task.wait(QuizConfig.RESULT_DISPLAY_SECONDS)
		closeQuestionModal()
	end))
end

-- ============================================================================
-- ATUALIZAÇÃO CONTÍNUA DOS TEMPORIZADORES (QUIZ E ÁREA DE RECOMPENSAS)
-- ============================================================================

trackConnection(FimDeRodada.OnClientEvent:Connect(function(payload: RoundEndPayload)
	closeQuestionModal()
	if localPlayer:GetAttribute("ModoComCronometro") == false then
		updateModeHudControls()
		return
	end
	if renderApprovedFrozenTimer() then
		return
	end
	lastStatusCountdownText = ""
	timerLabel.Text = "00:00.000"
	timerLabel.TextColor3 = COLOR_ACCENT_DANGER_BORDER
	statusLabel.Text = if typeof(payload) == "table" and typeof(payload.Mensagem) == "string"
		then payload.Mensagem
		else "Tempo da tentativa esgotado."
	statusLabel.TextColor3 = COLOR_ACCENT_WARNING
end))

trackConnection(RunService.Heartbeat:Connect(function()
	local nowServer = Workspace:GetServerTimeNow()
	updateRewardAreaCountdownHud(nowServer)

	local timedMode = localPlayer:GetAttribute("ModoComCronometro")
	if timedMode ~= true then
		if timerLabel.Visible then
			timerLabel.Visible = false
		end
		return
	end
	if not timerLabel.Visible then
		timerLabel.Visible = true
	end
	if currentPhase ~= "Ativa" then
		return
	end
	if renderApprovedFrozenTimer() then
		return
	end

	local startTimestamp = localPlayer:GetAttribute("InicioTentativaQuiz")
	local completionTime = localPlayer:GetAttribute("TempoConclusaoQuiz")
	if typeof(completionTime) == "number" then
		local formatted = formatTimeMillis(completionTime)
		if formatted ~= lastAttemptStopwatchText then
			lastAttemptStopwatchText = formatted
			timerLabel.Text = formatted
			timerLabel.TextColor3 = COLOR_TEXT_PRIMARY
		end
	elseif typeof(startTimestamp) == "number" then
		local formatted = formatTimeMillis(nowServer - startTimestamp)
		if formatted ~= lastAttemptStopwatchText then
			lastAttemptStopwatchText = formatted
			timerLabel.Text = formatted
			timerLabel.TextColor3 = COLOR_TEXT_PRIMARY
		end
	else
		timerLabel.Text = "--:--.---"
	end

	local endTimestamp = localPlayer:GetAttribute("FimTentativaQuiz")
	if typeof(endTimestamp) ~= "number" or endTimestamp <= 0 then
		return
	end

	local remainingSeconds = math.max(0, endTimestamp - nowServer)
	local attempt = math.max(1, tonumber(localPlayer:GetAttribute("NumeroTentativaQuiz")) or 1)
	local statusText = string.format(
		"Tentativa %d · Restam %s",
		attempt,
		formatTimeMinutesSeconds(remainingSeconds)
	)
	if statusText ~= lastStatusCountdownText then
		lastStatusCountdownText = statusText
		statusLabel.Text = statusText
	end

	if remainingSeconds <= QUIZ_WARNING_THRESHOLD_SECONDS then
		statusLabel.TextColor3 = COLOR_ACCENT_WARNING
	else
		statusLabel.TextColor3 = COLOR_TEXT_SECONDARY
	end
end))

-- ============================================================================
-- BOTÃO DE REINÍCIO E INICIALIZAÇÃO DO CLIENTE
-- ============================================================================

local isResetAvailable = true
trackConnection(resetButton.Activated:Connect(function()
	if not isResetAvailable then
		return
	end
	isResetAvailable = false
	pcall(function()
		soundUiClick:Play()
	end)
	resetButton.Text = "Aguarde..."
	SolicitarReset:FireServer()
	task.delay(QuizConfig.RESET_COOLDOWN_SECONDS, function()
		resetButton.Text = "Reiniciar"
		isResetAvailable = true
	end)
end))

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

trackConnection(SincronizarRodada.OnClientEvent:Connect(function(snapshot: RoundStateSnapshot)
	if typeof(snapshot) == "table" then
		lastStatusCountdownText = ""
		lastAttemptStopwatchText = ""
		applyRoundStateSnapshot(snapshot)
	end
end))

if DefinirModoJogo then
	trackConnection(DefinirModoJogo.OnClientEvent:Connect(openModeModal))
end

trackConnection(script.Destroying:Connect(function()
	destroyRewardArrowIndicator()
	for _, connection in ipairs(activeConnections) do
		connection:Disconnect()
	end
	table.clear(activeConnections)
end))

updateModeHudControls()
task.defer(function()
	syncAllLocalDoors()
	updateRewardArrowVisibility()

	local ok, initialSnapshot = pcall(function()
		return ObterEstadoRodada:InvokeServer()
	end)
	if ok and typeof(initialSnapshot) == "table" then
		applyRoundStateSnapshot(initialSnapshot :: RoundStateSnapshot)
	end

	task.wait(0.25)
	if localPlayer:GetAttribute("ModoComCronometro") == nil then
		openModeModal()
	end
end)
