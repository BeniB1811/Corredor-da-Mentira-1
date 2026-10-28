--!strict
-- Serviço autoritativo de Ranking Global persistente (OrderedDataStore + MessagingService).
-- Classifica jogadores do Modo Ranqueado por maior pontuação e menor tempo de conclusão.

local DataStoreService = game:GetService("DataStoreService")
local MessagingService = game:GetService("MessagingService")
local Players = game:GetService("Players")
local ReplicatedStorage = game:GetService("ReplicatedStorage")
local Workspace = game:GetService("Workspace")

local QuizConfig = require(ReplicatedStorage:WaitForChild("QuizConfig"))

type PlayerRecord = {
	UserId: number,
	DisplayName: string,
	Name: string,
	Acertos: number,
	Tempo: number?,
	Timestamp: number,
}

type RankingEntry = {
	UserId: number,
	FormattedName: string,
	ScoreCount: number,
	CompletionTime: number?,
}

-- Posicionamento físico na face interna da parede principal voltada ao percurso
local BOARD_ANCHOR_POSITION = Vector3.new(367, 1052.5, 61.15)
local BOARD_FORWARD_DIRECTION = Vector3.new(0, 0, -1)
local BOARD_PROTRUSION_STUDS = 1.25
local BOARD_SIZE = Vector3.new(13, 9, 0.46)

local MAX_RANKED_PLAYERS = 10
local PERSISTENT_MODEL_NAME = "LeaderboardPersistentDisplay"
local PHYSICAL_FRAME_NAME = "LeaderboardPhysicalFrame"

local ORDERED_STORE_NAME = "QuizRankingGlobal_v2"
local STATS_STORE_NAME = "QuizPlayerStats_v2"
local GLOBAL_MESSAGING_TOPIC = QuizConfig.LEADERBOARD_MESSAGING_TOPIC
local GLOBAL_REFRESH_INTERVAL_SECONDS = 30
local SAVE_DEBOUNCE_SECONDS = 5

-- Codificação monotônica inteira: (Acertos * 10_000_000) + max(1, 10_000_000 - TempoMs)
local SCORE_FACTOR = 10_000_000
local TIME_BASE_MS = 10_000_000

-- Paleta arquitetônica sóbria e fosca
local COLOR_FRAME_HOUSING = Color3.fromRGB(22, 26, 34)
local COLOR_FRAME_RAIL = Color3.fromRGB(58, 66, 80)
local COLOR_FRAME_BOLT = Color3.fromRGB(100, 112, 130)

local COLOR_BOARD_SURFACE = Color3.fromRGB(16, 19, 26)
local COLOR_ROW_ODD = Color3.fromRGB(24, 29, 38)
local COLOR_ROW_EVEN = Color3.fromRGB(20, 24, 32)
local COLOR_BORDER_SUBTLE = Color3.fromRGB(48, 55, 69)

local COLOR_TEXT_PRIMARY = Color3.fromRGB(241, 244, 249)
local COLOR_TEXT_SECONDARY = Color3.fromRGB(156, 166, 184)
local COLOR_TEXT_MUTED = Color3.fromRGB(112, 122, 140)

local COLOR_RANK_FIRST = Color3.fromRGB(212, 167, 74)
local COLOR_RANK_SECOND = Color3.fromRGB(168, 179, 196)
local COLOR_RANK_THIRD = Color3.fromRGB(176, 118, 76)

local localRecords: { [number]: PlayerRecord } = {}
local formattedNameCache: { [number]: string } = {}
local pendingSaves: { [number]: boolean } = {}
local lastSaveTimestamps: { [number]: number } = {}
local playerConnections: { [Player]: { RBXScriptConnection } } = {}

local function computeCompositeScore(correctCount: number, completionSeconds: number?): number
	if correctCount <= 0 then
		return 0
	end
	local scoreComponent = math.clamp(correctCount, 0, QuizConfig.MAX_SCORE) * SCORE_FACTOR
	local timeComponent = 0
	if typeof(completionSeconds) == "number" and completionSeconds > 0 then
		local elapsedMs = math.floor(completionSeconds * 1000 + 0.5)
		timeComponent = math.clamp(TIME_BASE_MS - elapsedMs, 1, TIME_BASE_MS)
	end
	return scoreComponent + timeComponent
end

local function decodeCompositeScore(compositeScore: number): (number, number?)
	if compositeScore <= 0 then
		return 0, nil
	end
	local correctCount = math.floor(compositeScore / SCORE_FACTOR)
	local remainder = compositeScore % SCORE_FACTOR
	local completionSeconds: number? = nil
	if remainder > 0 then
		local elapsedMs = TIME_BASE_MS - remainder
		if elapsedMs >= 0 then
			completionSeconds = elapsedMs / 1000
		end
	end
	return correctCount, completionSeconds
end

local function resolveFormattedName(userId: number): string
	local onlinePlayer = Players:GetPlayerByUserId(userId)
	if onlinePlayer then
		local formatted = string.format("%s (@%s)", onlinePlayer.DisplayName, onlinePlayer.Name)
		formattedNameCache[userId] = formatted
		return formatted
	end
	local cached = formattedNameCache[userId]
	if cached then
		return cached
	end
	local ok, resolvedName = pcall(function()
		return Players:GetNameFromUserIdAsync(userId)
	end)
	if ok and typeof(resolvedName) == "string" and #resolvedName > 0 then
		local formatted = string.format("%s (@%s)", resolvedName, resolvedName)
		formattedNameCache[userId] = formatted
		return formatted
	end
	return string.format("Jogador_%d", userId)
end

local function saveRecordToDataStore(record: PlayerRecord)
	local compositeScore = computeCompositeScore(record.Acertos, record.Tempo)
	if compositeScore <= 0 then
		return
	end
	local userKey = tostring(record.UserId)

	pcall(function()
		local orderedStore = DataStoreService:GetOrderedDataStore(ORDERED_STORE_NAME)
		orderedStore:SetAsync(userKey, compositeScore)
	end)

	pcall(function()
		local statsStore = DataStoreService:GetDataStore(STATS_STORE_NAME)
		statsStore:SetAsync(userKey, {
			UserId = record.UserId,
			DisplayName = record.DisplayName,
			Name = record.Name,
			Acertos = record.Acertos,
			Tempo = record.Tempo,
			Timestamp = record.Timestamp,
		})
	end)

	pcall(function()
		MessagingService:PublishAsync(GLOBAL_MESSAGING_TOPIC, {
			UserId = record.UserId,
			Acertos = record.Acertos,
			Tempo = record.Tempo,
			Timestamp = os.time(),
		})
	end)
end

-- ============================================================================
-- CONSTRUÇÃO DO PAINEL FÍSICO E INTERFACE SURFACEGUI SÓBRIA
-- ============================================================================

local function getOrCreateBoardPart(): BasePart
	local found = Workspace:FindFirstChild(QuizConfig.LEADERBOARD_BOARD_NAME, true)
	local boardPart: BasePart
	if found and found:IsA("BasePart") then
		boardPart = found
	else
		local created = Instance.new("Part")
		created.Name = QuizConfig.LEADERBOARD_BOARD_NAME
		created.Parent = Workspace
		boardPart = created
	end

	boardPart.Name = QuizConfig.LEADERBOARD_BOARD_NAME
	boardPart.Anchored = true
	boardPart.CanCollide = false
	boardPart.CanTouch = false
	boardPart.CanQuery = false
	boardPart.CastShadow = false
	boardPart.Material = Enum.Material.SmoothPlastic
	boardPart.Color = COLOR_BOARD_SURFACE
	boardPart.Size = BOARD_SIZE

	local panelCenter = BOARD_ANCHOR_POSITION + BOARD_FORWARD_DIRECTION * BOARD_PROTRUSION_STUDS
	boardPart.CFrame = CFrame.lookAt(panelCenter, panelCenter + BOARD_FORWARD_DIRECTION)
	return boardPart
end

local boardPart = getOrCreateBoardPart()

local existingPersistentModel = Workspace:FindFirstChild(PERSISTENT_MODEL_NAME)
if existingPersistentModel and not existingPersistentModel:IsA("Model") then
	existingPersistentModel:Destroy()
	existingPersistentModel = nil
end

local persistentModel: Model = if existingPersistentModel and existingPersistentModel:IsA("Model")
	then existingPersistentModel
	else (function(): Model
		local created = Instance.new("Model")
		created.Name = PERSISTENT_MODEL_NAME
		return created
	end)()

persistentModel.ModelStreamingMode = Enum.ModelStreamingMode.Persistent
persistentModel.Parent = nil
boardPart.Parent = persistentModel

local legacyFrame = Workspace:FindFirstChild(PHYSICAL_FRAME_NAME, true)
if legacyFrame then
	legacyFrame:Destroy()
end

local physicalFrame = Instance.new("Model")
physicalFrame.Name = PHYSICAL_FRAME_NAME
physicalFrame.ModelStreamingMode = Enum.ModelStreamingMode.Atomic
physicalFrame.Parent = persistentModel

local function createFramePart(
	partName: string,
	partSize: Vector3,
	localOffset: CFrame,
	partColor: Color3,
	partMaterial: Enum.Material,
	partShape: Enum.PartType?
): Part
	local part = Instance.new("Part")
	part.Name = partName
	part.Anchored = true
	part.CanCollide = false
	part.CanTouch = false
	part.CanQuery = false
	part.CastShadow = true
	part.Material = partMaterial
	part.Color = partColor
	part.Size = partSize
	if partShape then
		part.Shape = partShape
	end
	part.CFrame = boardPart.CFrame * localOffset
	part.Parent = physicalFrame
	return part
end

createFramePart("Housing", Vector3.new(13.8, 9.8, 0.9), CFrame.new(0, 0, 0.25), COLOR_FRAME_HOUSING, Enum.Material.Metal)

local railDepth = -0.38
local railThickness = 0.24
local railBreadth = 0.26
createFramePart("TopRail", Vector3.new(13.86, railBreadth, railThickness), CFrame.new(0, 4.79, railDepth), COLOR_FRAME_RAIL, Enum.Material.Metal)
createFramePart("BottomRail", Vector3.new(13.86, railBreadth, railThickness), CFrame.new(0, -4.79, railDepth), COLOR_FRAME_RAIL, Enum.Material.Metal)
createFramePart("LeftRail", Vector3.new(railBreadth, 9.54, railThickness), CFrame.new(-6.79, 0, railDepth), COLOR_FRAME_RAIL, Enum.Material.Metal)
createFramePart("RightRail", Vector3.new(railBreadth, 9.54, railThickness), CFrame.new(6.79, 0, railDepth), COLOR_FRAME_RAIL, Enum.Material.Metal)

for xIndex, posX in ipairs({ -6.79, 6.79 }) do
	for _, posY in ipairs({ -4.79, 4.79 }) do
		createFramePart(
			string.format("MountBolt%d_%d", xIndex, if posY < 0 then 1 else 2),
			Vector3.new(0.08, 0.14, 0.14),
			CFrame.new(posX, posY, railDepth - 0.015) * CFrame.Angles(0, math.rad(90), 0),
			COLOR_FRAME_BOLT,
			Enum.Material.Metal,
			Enum.PartType.Cylinder
		)
	end
end

local existingSurfaceGui = boardPart:FindFirstChild("LeaderboardSurfaceGui")
if existingSurfaceGui then
	existingSurfaceGui:Destroy()
end

local surfaceGui = Instance.new("SurfaceGui")
surfaceGui.Name = "LeaderboardSurfaceGui"
surfaceGui.Face = Enum.NormalId.Front
surfaceGui.SizingMode = Enum.SurfaceGuiSizingMode.FixedSize
surfaceGui.CanvasSize = Vector2.new(1000, 700)
surfaceGui.LightInfluence = 0
surfaceGui.AlwaysOnTop = false
surfaceGui.MaxDistance = 0
surfaceGui.ZOffset = 1
surfaceGui.Parent = boardPart

local mainFrame = Instance.new("Frame")
mainFrame.Name = "MainFrame"
mainFrame.Size = UDim2.fromScale(1, 1)
mainFrame.BorderSizePixel = 0
mainFrame.BackgroundColor3 = COLOR_BOARD_SURFACE
mainFrame.BackgroundTransparency = 0.04
mainFrame.Parent = surfaceGui

local mainCorner = Instance.new("UICorner")
mainCorner.CornerRadius = UDim.new(0, 16)
mainCorner.Parent = mainFrame

local outerStroke = Instance.new("UIStroke")
outerStroke.ApplyStrokeMode = Enum.ApplyStrokeMode.Border
outerStroke.Color = COLOR_BORDER_SUBTLE
outerStroke.Thickness = 1.5
outerStroke.Parent = mainFrame

local titleLabel = Instance.new("TextLabel")
titleLabel.Name = "Title"
titleLabel.Position = UDim2.fromOffset(32, 24)
titleLabel.Size = UDim2.new(1, -64, 0, 40)
titleLabel.BackgroundTransparency = 1
titleLabel.Font = Enum.Font.GothamBold
titleLabel.Text = "RANKING GLOBAL"
titleLabel.TextColor3 = COLOR_TEXT_PRIMARY
titleLabel.TextSize = 32
titleLabel.TextXAlignment = Enum.TextXAlignment.Left
titleLabel.Parent = mainFrame

local subtitleLabel = Instance.new("TextLabel")
subtitleLabel.Name = "Subtitle"
subtitleLabel.Position = UDim2.fromOffset(32, 66)
subtitleLabel.Size = UDim2.new(1, -64, 0, 24)
subtitleLabel.BackgroundTransparency = 1
subtitleLabel.Font = Enum.Font.GothamMedium
subtitleLabel.Text = "TOP 10 · MODO COM CRONÔMETRO · TODOS OS SERVIDORES"
subtitleLabel.TextColor3 = COLOR_TEXT_SECONDARY
subtitleLabel.TextSize = 16
subtitleLabel.TextXAlignment = Enum.TextXAlignment.Left
subtitleLabel.Parent = mainFrame

local headerDivider = Instance.new("Frame")
headerDivider.Name = "HeaderDivider"
headerDivider.Position = UDim2.fromOffset(32, 104)
headerDivider.Size = UDim2.new(1, -64, 0, 1)
headerDivider.BackgroundColor3 = COLOR_BORDER_SUBTLE
headerDivider.BorderSizePixel = 0
headerDivider.Parent = mainFrame

local columnsFrame = Instance.new("Frame")
columnsFrame.Name = "Columns"
columnsFrame.Position = UDim2.fromOffset(32, 116)
columnsFrame.Size = UDim2.new(1, -64, 0, 32)
columnsFrame.BackgroundTransparency = 1
columnsFrame.Parent = mainFrame

local function createColumnHeader(
	columnName: string,
	headerText: string,
	columnSize: UDim2,
	columnPos: UDim2,
	alignment: Enum.TextXAlignment
)
	local header = Instance.new("TextLabel")
	header.Name = columnName
	header.Text = headerText
	header.Size = columnSize
	header.Position = columnPos
	header.BackgroundTransparency = 1
	header.Font = Enum.Font.GothamBold
	header.TextColor3 = COLOR_TEXT_MUTED
	header.TextSize = 15
	header.TextXAlignment = alignment
	header.Parent = columnsFrame
end

createColumnHeader("PositionHeader", "#", UDim2.new(0, 56, 1, 0), UDim2.fromOffset(0, 0), Enum.TextXAlignment.Center)
createColumnHeader("NameHeader", "JOGADOR", UDim2.new(0, 472, 1, 0), UDim2.fromOffset(64, 0), Enum.TextXAlignment.Left)
createColumnHeader("ScoreHeader", "ACERTOS", UDim2.new(0, 160, 1, 0), UDim2.fromOffset(544, 0), Enum.TextXAlignment.Right)
createColumnHeader("TimeHeader", "TEMPO", UDim2.new(0, 200, 1, 0), UDim2.fromOffset(720, 0), Enum.TextXAlignment.Right)

local rowsContainer = Instance.new("Frame")
rowsContainer.Name = "Rows"
rowsContainer.Position = UDim2.fromOffset(32, 156)
rowsContainer.Size = UDim2.new(1, -64, 1, -180)
rowsContainer.BackgroundTransparency = 1
rowsContainer.Parent = mainFrame

local rowsLayout = Instance.new("UIListLayout")
rowsLayout.Name = "RowsLayout"
rowsLayout.SortOrder = Enum.SortOrder.LayoutOrder
rowsLayout.Padding = UDim.new(0, 6)
rowsLayout.Parent = rowsContainer

local rowFrames: { Frame } = {}
for rankIndex = 1, MAX_RANKED_PLAYERS do
	local row = Instance.new("Frame")
	row.Name = "Row" .. rankIndex
	row.Size = UDim2.new(1, 0, 0, 46)
	row.BorderSizePixel = 0
	row.LayoutOrder = rankIndex
	row.BackgroundColor3 = if rankIndex % 2 == 1 then COLOR_ROW_ODD else COLOR_ROW_EVEN
	row.Visible = false
	row.Parent = rowsContainer

	local rowCorner = Instance.new("UICorner")
	rowCorner.CornerRadius = UDim.new(0, 8)
	rowCorner.Parent = row

	local rankColor = if rankIndex == 1
		then COLOR_RANK_FIRST
		elseif rankIndex == 2 then COLOR_RANK_SECOND
		elseif rankIndex == 3 then COLOR_RANK_THIRD
		else COLOR_TEXT_SECONDARY

	if rankIndex <= 3 then
		local topStroke = Instance.new("UIStroke")
		topStroke.ApplyStrokeMode = Enum.ApplyStrokeMode.Border
		topStroke.Color = rankColor
		topStroke.Transparency = 0.65
		topStroke.Thickness = 1
		topStroke.Parent = row
	end

	local rankLabel = Instance.new("TextLabel")
	rankLabel.Name = "Rank"
	rankLabel.Size = UDim2.new(0, 56, 1, 0)
	rankLabel.BackgroundTransparency = 1
	rankLabel.Font = Enum.Font.GothamBold
	rankLabel.TextColor3 = rankColor
	rankLabel.TextSize = 20
	rankLabel.TextXAlignment = Enum.TextXAlignment.Center
	rankLabel.Parent = row

	local playerNameLabel = Instance.new("TextLabel")
	playerNameLabel.Name = "PlayerName"
	playerNameLabel.Position = UDim2.fromOffset(64, 0)
	playerNameLabel.Size = UDim2.new(0, 472, 1, 0)
	playerNameLabel.BackgroundTransparency = 1
	playerNameLabel.Font = Enum.Font.GothamMedium
	playerNameLabel.TextColor3 = COLOR_TEXT_PRIMARY
	playerNameLabel.TextSize = 20
	playerNameLabel.TextXAlignment = Enum.TextXAlignment.Left
	playerNameLabel.TextTruncate = Enum.TextTruncate.AtEnd
	playerNameLabel.Parent = row

	local scoreLabel = Instance.new("TextLabel")
	scoreLabel.Name = "Score"
	scoreLabel.Position = UDim2.fromOffset(544, 0)
	scoreLabel.Size = UDim2.new(0, 160, 1, 0)
	scoreLabel.BackgroundTransparency = 1
	scoreLabel.Font = Enum.Font.GothamBold
	scoreLabel.TextColor3 = COLOR_TEXT_PRIMARY
	scoreLabel.TextSize = 20
	scoreLabel.TextXAlignment = Enum.TextXAlignment.Right
	scoreLabel.Parent = row

	local timeLabel = Instance.new("TextLabel")
	timeLabel.Name = "CompletionTime"
	timeLabel.Position = UDim2.fromOffset(720, 0)
	timeLabel.Size = UDim2.new(0, 200, 1, 0)
	timeLabel.BackgroundTransparency = 1
	timeLabel.Font = Enum.Font.GothamMedium
	timeLabel.TextColor3 = COLOR_TEXT_SECONDARY
	timeLabel.TextSize = 19
	timeLabel.TextXAlignment = Enum.TextXAlignment.Right
	timeLabel.Parent = row

	rowFrames[rankIndex] = row
end

local emptyStateLabel = Instance.new("TextLabel")
emptyStateLabel.Name = "Empty"
emptyStateLabel.Size = UDim2.new(1, 0, 0, 48)
emptyStateLabel.BackgroundTransparency = 1
emptyStateLabel.Font = Enum.Font.GothamMedium
emptyStateLabel.Text = "Carregando recordes..."
emptyStateLabel.TextColor3 = COLOR_TEXT_SECONDARY
emptyStateLabel.TextSize = 20
emptyStateLabel.Parent = rowsContainer

-- ============================================================================
-- CONSULTA, ORDENAÇÃO E SINCRONIZAÇÃO DE RECORDES
-- ============================================================================

local function fetchSortedRankingEntries(): { RankingEntry }
	local entries: { RankingEntry } = {}

	local ok, pages = pcall(function()
		local orderedStore = DataStoreService:GetOrderedDataStore(ORDERED_STORE_NAME)
		return orderedStore:GetSortedAsync(false, MAX_RANKED_PLAYERS)
	end)

	if ok and pages then
		local currentPage = pages:GetCurrentPage()
		for _, item in ipairs(currentPage) do
			local userId = tonumber(item.key)
			local compositeValue = tonumber(item.value)
			if userId and compositeValue and compositeValue > 0 then
				local correctCount, completionTime = decodeCompositeScore(compositeValue)
				table.insert(entries, {
					UserId = userId,
					FormattedName = resolveFormattedName(userId),
					ScoreCount = correctCount,
					CompletionTime = completionTime,
				})
			end
		end
	end

	-- Fallback local caso DataStore não esteja disponível na sessão (ex.: Studio sem API)
	if #entries == 0 then
		for _, record in pairs(localRecords) do
			if record.Acertos > 0 then
				table.insert(entries, {
					UserId = record.UserId,
					FormattedName = string.format("%s (@%s)", record.DisplayName, record.Name),
					ScoreCount = record.Acertos,
					CompletionTime = record.Tempo,
				})
			end
		end
		table.sort(entries, function(entryA: RankingEntry, entryB: RankingEntry): boolean
			if entryA.ScoreCount ~= entryB.ScoreCount then
				return entryA.ScoreCount > entryB.ScoreCount
			end
			if entryA.CompletionTime ~= entryB.CompletionTime then
				if entryA.CompletionTime == nil then
					return false
				end
				if entryB.CompletionTime == nil then
					return true
				end
				return entryA.CompletionTime < entryB.CompletionTime
			end
			return entryA.FormattedName < entryB.FormattedName
		end)
	end

	return entries
end

local function refreshLeaderboardDisplay()
	local entries = fetchSortedRankingEntries()
	emptyStateLabel.Visible = #entries == 0
	emptyStateLabel.Text = if #entries == 0 then "Nenhum recorde registrado até o momento." else ""

	for index, row in ipairs(rowFrames) do
		local entry = entries[index]
		row.Visible = entry ~= nil
		if entry then
			local rankLabel = row:FindFirstChild("Rank") :: TextLabel
			local nameLabel = row:FindFirstChild("PlayerName") :: TextLabel
			local scoreLabel = row:FindFirstChild("Score") :: TextLabel
			local timeLabel = row:FindFirstChild("CompletionTime") :: TextLabel

			rankLabel.Text = string.format("%02d", index)
			nameLabel.Text = entry.FormattedName
			scoreLabel.Text = string.format("%d/%d", entry.ScoreCount, QuizConfig.MAX_SCORE)

			if entry.CompletionTime then
				local totalMilliseconds = math.floor(entry.CompletionTime * 1000 + 0.5)
				local minutes = math.floor(totalMilliseconds / 60000)
				local seconds = math.floor(totalMilliseconds / 1000) % 60
				local milliseconds = totalMilliseconds % 1000
				timeLabel.Text = string.format("%02d:%02d.%03d", minutes, seconds, milliseconds)
			else
				timeLabel.Text = "--:--.---"
			end
		end
	end
end

local function loadPlayerRecord(player: Player)
	local userId = player.UserId
	formattedNameCache[userId] = string.format("%s (@%s)", player.DisplayName, player.Name)

	local ok, storedData = pcall(function()
		local statsStore = DataStoreService:GetDataStore(STATS_STORE_NAME)
		return statsStore:GetAsync(tostring(userId))
	end)

	local record: PlayerRecord
	if ok and typeof(storedData) == "table" and typeof(storedData.Acertos) == "number" then
		record = {
			UserId = userId,
			DisplayName = player.DisplayName,
			Name = player.Name,
			Acertos = math.clamp(math.floor(storedData.Acertos), 0, QuizConfig.MAX_SCORE),
			Tempo = if typeof(storedData.Tempo) == "number" then storedData.Tempo else nil,
			Timestamp = if typeof(storedData.Timestamp) == "number" then storedData.Timestamp else os.time(),
		}
	else
		record = {
			UserId = userId,
			DisplayName = player.DisplayName,
			Name = player.Name,
			Acertos = 0,
			Tempo = nil,
			Timestamp = os.time(),
		}
	end

	localRecords[userId] = record
	player:SetAttribute("RecordeAcertosQuiz", record.Acertos)
	player:SetAttribute("RecordeTempoQuiz", record.Tempo)
end

local function evaluatePlayerRecordUpdate(player: Player)
	if player:GetAttribute("ModoComCronometro") ~= true then
		return
	end

	local userId = player.UserId
	local currentRecord = localRecords[userId]
	if not currentRecord then
		return
	end

	local rawScore = player:GetAttribute("AcertosQuiz")
	local attemptScore = if typeof(rawScore) == "number"
		then math.clamp(math.floor(rawScore), 0, QuizConfig.MAX_SCORE)
		else 0

	local rawTime = player:GetAttribute("TempoConclusaoQuiz")
	local attemptTime: number? = if typeof(rawTime) == "number" and rawTime > 0 then rawTime else nil

	local isNewPersonalBest = false
	if attemptScore > currentRecord.Acertos then
		isNewPersonalBest = true
	elseif attemptScore == currentRecord.Acertos and attemptScore > 0 then
		if attemptTime and (currentRecord.Tempo == nil or attemptTime < currentRecord.Tempo) then
			isNewPersonalBest = true
		end
	end

	if not isNewPersonalBest then
		return
	end

	currentRecord.Acertos = attemptScore
	currentRecord.Tempo = attemptTime
	currentRecord.Timestamp = os.time()
	player:SetAttribute("RecordeAcertosQuiz", attemptScore)
	player:SetAttribute("RecordeTempoQuiz", attemptTime)
	pendingSaves[userId] = true

	local now = os.clock()
	local lastSave = lastSaveTimestamps[userId] or 0
	if (now - lastSave) > SAVE_DEBOUNCE_SECONDS then
		lastSaveTimestamps[userId] = now
		task.defer(function()
			saveRecordToDataStore(currentRecord)
			pendingSaves[userId] = nil
			refreshLeaderboardDisplay()
		end)
	end
end

local function observePlayer(player: Player)
	if playerConnections[player] then
		return
	end
	playerConnections[player] = {}
	loadPlayerRecord(player)

	if player.Parent ~= Players then
		playerConnections[player] = nil
		return
	end

	local scoreConn = player:GetAttributeChangedSignal("AcertosQuiz"):Connect(function()
		evaluatePlayerRecordUpdate(player)
	end)
	local timeConn = player:GetAttributeChangedSignal("TempoConclusaoQuiz"):Connect(function()
		evaluatePlayerRecordUpdate(player)
	end)
	table.insert(playerConnections[player], scoreConn)
	table.insert(playerConnections[player], timeConn)
end

local function cleanupPlayer(player: Player)
	local connections = playerConnections[player]
	if connections then
		for _, connection in ipairs(connections) do
			connection:Disconnect()
		end
		table.clear(connections)
		playerConnections[player] = nil
	end

	local userId = player.UserId
	local record = localRecords[userId]
	if record and pendingSaves[userId] then
		saveRecordToDataStore(record)
		pendingSaves[userId] = nil
	end
	localRecords[userId] = nil
	lastSaveTimestamps[userId] = nil
	task.defer(refreshLeaderboardDisplay)
end

Players.PlayerAdded:Connect(observePlayer)
Players.PlayerRemoving:Connect(cleanupPlayer)
for _, existingPlayer in ipairs(Players:GetPlayers()) do
	task.spawn(observePlayer, existingPlayer)
end

pcall(function()
	MessagingService:SubscribeAsync(GLOBAL_MESSAGING_TOPIC, function()
		task.delay(1.5, refreshLeaderboardDisplay)
	end)
end)

task.spawn(function()
	while true do
		refreshLeaderboardDisplay()
		task.wait(GLOBAL_REFRESH_INTERVAL_SECONDS)
	end
end)

game:BindToClose(function()
	for userId, record in pairs(localRecords) do
		if pendingSaves[userId] then
			saveRecordToDataStore(record)
			pendingSaves[userId] = nil
		end
	end
end)

persistentModel.Parent = Workspace
