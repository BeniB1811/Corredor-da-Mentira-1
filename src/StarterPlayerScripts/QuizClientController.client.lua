--!strict
-- Interface responsiva: o cliente só exibe estado e envia escolhas; não calcula pontuação nem libera o portão.
local Players = game:GetService("Players")
local ReplicatedStorage = game:GetService("ReplicatedStorage")
local RunService = game:GetService("RunService")
local StarterGui = game:GetService("StarterGui")
local TweenService = game:GetService("TweenService")
local Workspace = game:GetService("Workspace")

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

local function aplicarEstadoRodada(dados: any)
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
	end
end

local respondeuAtual = false
local function fecharInterface()
	frame.Visible = false
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

ResetarClient.OnClientEvent:Connect(function()
	fecharInterface()
	for nivel = 0, 10 do
		aplicarEstadoPorta(Workspace:FindFirstChild(string.format("PortaNivel%d Geografia", nivel), true), false)
	end
	for nivel = 1, 10 do
		aplicarEstadoPorta(Workspace:FindFirstChild(string.format("PortaNivel%d História", nivel), true), false)
	end
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
	end
	frame.Visible = true
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
			button.BackgroundColor3 = Color3.fromRGB(55, 180, 104)
		else
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
	if faseAtual ~= "Ativa" then
		return
	end
	local agoraServidor = Workspace:GetServerTimeNow()
	local inicioTentativa = player:GetAttribute("InicioTentativaQuiz")
	if typeof(inicioTentativa) == "number" then
		local tempoConcluido = player:GetAttribute("TempoConclusaoQuiz")
		-- O cronômetro grande acompanha esta tentativa; o resultado concluído
		-- permanece no atributo do servidor para a leaderboard.
		local decorrido = typeof(tempoConcluido) == "number"
			and 0
			or math.max(0, agoraServidor - inicioTentativa)
		local totalTentativaMs = math.floor(decorrido * 1000)
		local minutosTentativa = math.floor(totalTentativaMs / 60000)
		local segundosTentativa = math.floor((totalTentativaMs % 60000) / 1000)
		local milissegundosTentativa = totalTentativaMs % 1000
		local textoTentativa = string.format("%02d:%02d.%03d", minutosTentativa, segundosTentativa, milissegundosTentativa)
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
	local totalMilissegundos = math.floor(restante * 1000)
	local minutos = math.floor(totalMilissegundos / 60000)
	local segundos = math.floor((totalMilissegundos % 60000) / 1000)
	local milissegundos = totalMilissegundos % 1000
	local texto = string.format("%02d:%02d.%03d", minutos, segundos, milissegundos)
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
