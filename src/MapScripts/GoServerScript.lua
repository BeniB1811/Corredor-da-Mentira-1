--!strict
-- Compatibilidade segura do botão de controle de veículo na Área de Recompensas.
-- Preserva a interface local do modelo e elimina carregamento remoto dinâmico (InsertService).

local DISTANCE_TOLERANCE_STUDS = 4

local parentInstance = script.Parent
if not parentInstance or not parentInstance:IsA("BasePart") then
	return
end

local buttonPart = parentInstance :: BasePart
local clickDetector = buttonPart:FindFirstChild("CD")
local guiTemplate = script:FindFirstChild("GoPlayer")

if guiTemplate then
	local targetReference = guiTemplate:FindFirstChild("GoPlayer")
	if targetReference and targetReference:IsA("ObjectValue") then
		targetReference.Value = buttonPart
	end
end

local engineSound = buttonPart:FindFirstChildOfClass("Sound") or Instance.new("Sound")
engineSound.PlaybackSpeed = 1
engineSound.Volume = 0.5
engineSound.Looped = true
engineSound.Parent = buttonPart

if clickDetector and clickDetector:IsA("ClickDetector") then
	local detector = clickDetector :: ClickDetector
	local clickConnection = detector.MouseClick:Connect(function(player: Player)
		local character = player.Character
		local rootPart = character and character:FindFirstChild("HumanoidRootPart")
		if not rootPart or not rootPart:IsA("BasePart") then
			return
		end
		local maxDistance = detector.MaxActivationDistance + DISTANCE_TOLERANCE_STUDS
		if (rootPart.Position - buttonPart.Position).Magnitude > maxDistance then
			return
		end
		local playerGui = player:FindFirstChildOfClass("PlayerGui")
		if playerGui and not playerGui:FindFirstChild("GoPlayer") and guiTemplate then
			guiTemplate:Clone().Parent = playerGui
		end
	end)

	script.Destroying:Connect(function()
		clickConnection:Disconnect()
	end)
end
