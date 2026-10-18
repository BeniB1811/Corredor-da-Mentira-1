--!strict
-- A placa e a moldura são ocultadas apenas para este cliente quando uma parede
-- bloqueia a linha de visão. A SurfaceGui mantém MaxDistance = 0 para renderizar
-- em qualquer distância; AlwaysOnTop = false preserva a oclusão visual normal.
local Players = game:GetService("Players")
local RunService = game:GetService("RunService")
local Workspace = game:GetService("Workspace")

local player = Players.LocalPlayer
local NOME_PLACAR = "LeaderboardParede"
local NOME_MOLDURA = "LeaderboardPhysicalFrame"
local INTERVALO_ATUALIZACAO = 0.15

local placarEmCache: BasePart? = nil
local molduraEmCache: Model? = nil

local function obterPlacar(): BasePart?
	if placarEmCache and placarEmCache:IsDescendantOf(Workspace) then
		return placarEmCache
	end
	-- O serviço do placar preserva uma peça existente, mesmo que esteja dentro de um Model.
	local encontrado = Workspace:FindFirstChild(NOME_PLACAR, true)
	if encontrado and encontrado:IsA("BasePart") then
		placarEmCache = encontrado
		return encontrado
	end
	placarEmCache = nil
	return nil
end

local function obterMoldura(): Model?
	if molduraEmCache and molduraEmCache:IsDescendantOf(Workspace) then
		return molduraEmCache
	end
	local encontrada = Workspace:FindFirstChild(NOME_MOLDURA)
	if encontrada and encontrada:IsA("Model") then
		molduraEmCache = encontrada
		return encontrada
	end
	molduraEmCache = nil
	return nil
end

local function temLinhaDeVisao(camera: Camera, placar: BasePart, moldura: Model?, personagem: Model?): boolean
	local origem = camera.CFrame.Position
	-- A SurfaceGui usa Face = Front, cuja normal é o LookVector (-Z local).
	-- Testar o vetor invertido escondia o painel para quem estava no lado correto.
	local normalFrontal = placar.CFrame.LookVector
	if normalFrontal:Dot(origem - placar.Position) <= 0 then
		return false
	end

	local parametros = RaycastParams.new()
	parametros.FilterType = Enum.RaycastFilterType.Exclude
	local ignorar: { Instance } = { placar }
	if moldura then
		table.insert(ignorar, moldura)
	end
	if personagem then
		table.insert(ignorar, personagem)
	end
	parametros.FilterDescendantsInstances = ignorar
	parametros.IgnoreWater = true

	local meiaLargura = placar.Size.X * 0.38
	local meiaAltura = placar.Size.Y * 0.38
	local pontosLocais = {
		Vector3.new(0, 0, -placar.Size.Z * 0.5 - 0.05),
		Vector3.new(-meiaLargura, meiaAltura, -placar.Size.Z * 0.5 - 0.05),
		Vector3.new(meiaLargura, meiaAltura, -placar.Size.Z * 0.5 - 0.05),
		Vector3.new(-meiaLargura, -meiaAltura, -placar.Size.Z * 0.5 - 0.05),
		Vector3.new(meiaLargura, -meiaAltura, -placar.Size.Z * 0.5 - 0.05),
	}
	local raiosLivres = 0
	for _, pontoLocal in ipairs(pontosLocais) do
		local alvo = placar.CFrame:PointToWorldSpace(pontoLocal)
		if not Workspace:Raycast(origem, alvo - origem, parametros) then
			raiosLivres += 1
		end
	end
	return raiosLivres >= 3
end

local acumulado = 0
local function atualizarVisibilidade()
	local placar = obterPlacar()
	local moldura = obterMoldura()
	local camera = Workspace.CurrentCamera
	local personagem = player.Character
	local visivel = placar ~= nil
		and camera ~= nil
		and temLinhaDeVisao(camera :: Camera, placar :: BasePart, moldura, personagem)

	if placar then
		placar.LocalTransparencyModifier = visivel and 0 or 1
		local surface = placar:FindFirstChild("LeaderboardSurfaceGui")
		if surface and surface:IsA("SurfaceGui") then
			surface.Enabled = visivel
		end
	end

	if moldura then
		for _, descendente in ipairs(moldura:GetDescendants()) do
			if descendente:IsA("BasePart") then
				descendente.LocalTransparencyModifier = visivel and 0 or 1
			end
		end
	end
end

atualizarVisibilidade()
RunService.Heartbeat:Connect(function(deltaTime)
	acumulado += deltaTime
	if acumulado >= INTERVALO_ATUALIZACAO then
		acumulado %= INTERVALO_ATUALIZACAO
		atualizarVisibilidade()
	end
end)
