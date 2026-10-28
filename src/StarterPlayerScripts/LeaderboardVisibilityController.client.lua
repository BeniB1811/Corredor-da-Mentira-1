--!strict
-- Controlador local de oclusão visual do painel de Ranking Global.
-- Oculta localmente a placa e a moldura quando paredes bloqueiam a linha de visão da câmera.

local Players = game:GetService("Players")
local ReplicatedStorage = game:GetService("ReplicatedStorage")
local RunService = game:GetService("RunService")
local Workspace = game:GetService("Workspace")

local QuizConfig = require(ReplicatedStorage:WaitForChild("QuizConfig"))

local BOARD_PART_NAME = QuizConfig.LEADERBOARD_BOARD_NAME
local PHYSICAL_FRAME_NAME = "LeaderboardPhysicalFrame"
local VISIBILITY_UPDATE_INTERVAL_SECONDS = 0.15
local MIN_UNOBSTRUCTED_RAYS = 3

local localPlayer = Players.LocalPlayer
local cachedBoardPart: BasePart? = nil
local cachedFrameModel: Model? = nil

local function resolveBoardPart(): BasePart?
	if cachedBoardPart and cachedBoardPart:IsDescendantOf(Workspace) then
		return cachedBoardPart
	end
	local found = Workspace:FindFirstChild(BOARD_PART_NAME, true)
	if found and found:IsA("BasePart") then
		cachedBoardPart = found
		return found
	end
	cachedBoardPart = nil
	return nil
end

local function resolveFrameModel(): Model?
	if cachedFrameModel and cachedFrameModel:IsDescendantOf(Workspace) then
		return cachedFrameModel
	end
	local found = Workspace:FindFirstChild(PHYSICAL_FRAME_NAME, true)
	if found and found:IsA("Model") then
		cachedFrameModel = found
		return found
	end
	cachedFrameModel = nil
	return nil
end

local function hasLineOfSight(
	camera: Camera,
	boardPart: BasePart,
	frameModel: Model?,
	character: Model?
): boolean
	local cameraOrigin = camera.CFrame.Position
	local frontNormal = boardPart.CFrame.LookVector
	if frontNormal:Dot(cameraOrigin - boardPart.Position) <= 0 then
		return false
	end

	local raycastParams = RaycastParams.new()
	raycastParams.FilterType = Enum.RaycastFilterType.Exclude
	local excludedInstances: { Instance } = { boardPart }
	if frameModel then
		table.insert(excludedInstances, frameModel)
	end
	if character then
		table.insert(excludedInstances, character)
	end
	raycastParams.FilterDescendantsInstances = excludedInstances
	raycastParams.IgnoreWater = true

	local halfWidth = boardPart.Size.X * 0.38
	local halfHeight = boardPart.Size.Y * 0.38
	local frontDepth = -boardPart.Size.Z * 0.5 - 0.05
	local sampleOffsets: { Vector3 } = {
		Vector3.new(0, 0, frontDepth),
		Vector3.new(-halfWidth, halfHeight, frontDepth),
		Vector3.new(halfWidth, halfHeight, frontDepth),
		Vector3.new(-halfWidth, -halfHeight, frontDepth),
		Vector3.new(halfWidth, -halfHeight, frontDepth),
	}

	local clearRays = 0
	for _, localPoint in ipairs(sampleOffsets) do
		local worldTarget = boardPart.CFrame:PointToWorldSpace(localPoint)
		if not Workspace:Raycast(cameraOrigin, worldTarget - cameraOrigin, raycastParams) then
			clearRays += 1
		end
	end
	return clearRays >= MIN_UNOBSTRUCTED_RAYS
end

local function refreshBoardVisibility()
	local boardPart = resolveBoardPart()
	local frameModel = resolveFrameModel()
	local camera = Workspace.CurrentCamera
	local character = localPlayer.Character

	local isVisible = boardPart ~= nil
		and camera ~= nil
		and hasLineOfSight(camera :: Camera, boardPart :: BasePart, frameModel, character)

	if boardPart then
		boardPart.LocalTransparencyModifier = if isVisible then 0 else 1
		local surfaceGui = boardPart:FindFirstChild("LeaderboardSurfaceGui")
		if surfaceGui and surfaceGui:IsA("SurfaceGui") then
			surfaceGui.Enabled = isVisible
		end
	end

	if frameModel then
		for _, descendant in ipairs(frameModel:GetDescendants()) do
			if descendant:IsA("BasePart") then
				descendant.LocalTransparencyModifier = if isVisible then 0 else 1
			end
		end
	end
end

local accumulatedDelta = 0
refreshBoardVisibility()

local heartbeatConnection = RunService.Heartbeat:Connect(function(deltaTime: number)
	accumulatedDelta += deltaTime
	if accumulatedDelta >= VISIBILITY_UPDATE_INTERVAL_SECONDS then
		accumulatedDelta %= VISIBILITY_UPDATE_INTERVAL_SECONDS
		refreshBoardVisibility()
	end
end)

script.Destroying:Connect(function()
	heartbeatConnection:Disconnect()
end)
