-- Compatibilidade do botão de controle do veículo Lamborghini.
-- Mantém a interface local que já acompanha o modelo e remove a atualização remota via InsertService:LoadAsset,
-- que substituía código do jogo dinamicamente ao iniciar a experiência.
local part = script.Parent
local clickDetector = part:FindFirstChild("CD")
local guiTemplate = script:FindFirstChild("GoPlayer")

if guiTemplate and guiTemplate:FindFirstChild("GoPlayer") then
	guiTemplate.GoPlayer.Value = part
end

local sound = Instance.new("Sound")
sound.Parent = part
sound.PlaybackSpeed = 1
sound.Volume = 0.5
sound.Looped = true

if clickDetector and clickDetector:IsA("ClickDetector") then
	clickDetector.MouseClick:Connect(function(player)
		local character = player.Character
		local root = character and character:FindFirstChild("HumanoidRootPart")
		local distanciaMaxima = clickDetector.MaxActivationDistance + 4
		if not root or (root.Position - part.Position).Magnitude > distanciaMaxima then
			return
		end
		if not player.PlayerGui:FindFirstChild("GoPlayer") and guiTemplate then
			guiTemplate:Clone().Parent = player.PlayerGui
		end
	end)
end
