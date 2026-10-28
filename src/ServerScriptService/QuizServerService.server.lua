--!strict
-- Serviço autoritativo de sessão, máquina de estados linear, validação de questões,
-- barreiras físicas por CollisionGroups e controle de tempo da Área de Recompensas.

local PhysicsService = game:GetService("PhysicsService")
local Players = game:GetService("Players")
local ReplicatedStorage = game:GetService("ReplicatedStorage")
local ServerStorage = game:GetService("ServerStorage")
local TweenService = game:GetService("TweenService")
local Workspace = game:GetService("Workspace")

local QuizConfig = require(ReplicatedStorage:WaitForChild("QuizConfig"))
local QuizBanco = require(ServerStorage:WaitForChild(QuizConfig.QUESTION_BANK_NAME))

type PlayerState = QuizConfig.PlayerState
type SubjectName = QuizConfig.SubjectName

type QuizProgress = {
	Subject: SubjectName,
	Level: number,
}

type PreparedChoice = {
	Text: string,
	IsLie: boolean,
}

type ActiveQuestionSession = {
	Subject: SubjectName,
	Level: number,
	DoorName: string,
	QuestionTitle: string,
	Choices: { string },
	CorrectIndex: number,
	IsTutorial: boolean,
	Answered: boolean,
}

type PlayerSession = {
	State: PlayerState,
	TutorialCompleted: boolean,
	StartingSubject: SubjectName?,
	Progress: QuizProgress?,
	ActiveQuestion: ActiveQuestionSession?,
	QuestionDecks: { [string]: { [number]: { number } } },
	AttemptNumber: number,
	AttemptStartTimestamp: number?,
	AttemptEndTimestamp: number?,
	AttemptTimerToken: number,
	RewardQualifiedTeleportDone: boolean,
	RewardAreaEndTimestamp: number?,
	RewardTimerToken: number,
	PendingRespawnReset: boolean,
	LastNotificationClock: number,
	LastResetClock: number,
	LastBarrierNoticeClock: number,
	LastPortalTeleportClock: number,
	PortalTouchClocks: { [BasePart]: number },
	Connections: { RBXScriptConnection },
	CharacterConnections: { RBXScriptConnection },
}

local PLAYER_STATES = QuizConfig.PLAYER_STATES

local COLLISION_GROUP_TUTORIAL_BARRIER = "QuizTutorialBarrier"
local COLLISION_GROUP_REWARD_BARRIER = "QuizRewardBarrier"
local COLLISION_GROUP_PLAYER_LOCKED = "QuizPlayerLocked"
local COLLISION_GROUP_PLAYER_ACTIVE = "QuizPlayerActive"
local COLLISION_GROUP_PLAYER_REWARD = "QuizPlayerReward"

local DOOR_BARRIERS_FOLDER_NAME = "QuizDoorBarriers"
local TUTORIAL_BARRIER_NAME = "BarreiraTutorialSolida"
local REWARD_BARRIER_NAME = "BarreiraRecompensasSolida"

local MAIN_LOBBY_HUB_POSITION = Vector3.new(406.5, 1049.5, 33.5)
local MAIN_LOBBY_LOOK_TARGET = Vector3.new(406.5, 1049.5, 79.6)
local TUTORIAL_SPAWN_POSITION = Vector3.new(406.5, 1049.5, -20.0)
local TUTORIAL_LOOK_TARGET = Vector3.new(406.5, 1049.5, 8.5)
local REWARD_RETURN_LOBBY_POSITION = Vector3.new(405.025, 1049.5, 73.5)
local REWARD_RETURN_LOOK_TARGET = Vector3.new(405.025, 1049.5, 33.5)

local TUTORIAL_BARRIER_POSITION = Vector3.new(406.5, 1055.0, 9.75)
local TUTORIAL_BARRIER_SIZE = Vector3.new(12.0, 20.0, 3.5)

local REWARD_GATE_FALLBACK_POSITION = Vector3.new(405.025, 1051.0, 79.6)
local REWARD_GATE_VISUAL_SIZE = Vector3.new(5.55, 10.0, 0.24)
local REWARD_BARRIER_SIZE = Vector3.new(10.0, 18.0, 3.0)
local CORRIDOR_SHIELD_SIZE = Vector3.new(2.8, 19.0, 10.0)

local BARRIER_NOTICE_COOLDOWN_SECONDS = 1.8
local PORTAL_TOUCH_COOLDOWN_SECONDS = 0.65
local PORTAL_GLOBAL_COOLDOWN_SECONDS = 1.2

local COLOR_NOTICE_INFO = Color3.fromRGB(226, 232, 240)
local COLOR_NOTICE_WARNING = Color3.fromRGB(245, 158, 11)
local COLOR_NOTICE_SUCCESS = Color3.fromRGB(34, 197, 94)
local COLOR_NOTICE_DANGER = Color3.fromRGB(239, 68, 68)

local remotesFolder = ReplicatedStorage:FindFirstChild(QuizConfig.REMOTES_FOLDER_NAME)
if not remotesFolder then
	local createdFolder = Instance.new("Folder")
	createdFolder.Name = QuizConfig.REMOTES_FOLDER_NAME
	createdFolder.Parent = ReplicatedStorage
	remotesFolder = createdFolder
end

local function ensureRemote(remoteName: string, className: string): Instance
	local folder = remotesFolder :: Instance
	local existing = folder:FindFirstChild(remoteName)
	if existing and existing.ClassName ~= className then
		existing:Destroy()
		existing = nil
	end
	if not existing then
		local created = Instance.new(className)
		created.Name = remoteName
		created.Parent = folder
		return created
	end
	return existing
end

local AbrirQuiz = ensureRemote("AbrirQuiz", "RemoteEvent") :: RemoteEvent
local EnviarResposta = ensureRemote("EnviarResposta", "RemoteFunction") :: RemoteFunction
local SincronizarRodada = ensureRemote("SincronizarRodada", "RemoteEvent") :: RemoteEvent
local FimDeRodada = ensureRemote("FimDeRodada", "RemoteEvent") :: RemoteEvent
local ControlarPorta = ensureRemote("ControlarPorta", "RemoteEvent") :: RemoteEvent
local ResetarClient = ensureRemote("ResetarClient", "RemoteEvent") :: RemoteEvent
local NotificarMensagem = ensureRemote("NotificarMensagem", "RemoteEvent") :: RemoteEvent
local SolicitarReset = ensureRemote("SolicitarReset", "RemoteEvent") :: RemoteEvent
local ObterEstadoRodada = ensureRemote("ObterEstadoRodada", "RemoteFunction") :: RemoteFunction
local DefinirModoJogo = ensureRemote(QuizConfig.MODE_REMOTE_NAME, "RemoteEvent") :: RemoteEvent

local doorBarriersFolder: Folder = (function(): Folder
	local existing = Workspace:FindFirstChild(DOOR_BARRIERS_FOLDER_NAME)
	if existing and existing:IsA("Folder") then
		return existing
	end
	if existing then
		existing:Destroy()
	end
	local created = Instance.new("Folder")
	created.Name = DOOR_BARRIERS_FOLDER_NAME
	created.Parent = Workspace
	return created
end)()

local playerSessions: { [Player]: PlayerSession } = {}
local connectedPrompts: { [ProximityPrompt]: boolean } = {}
local connectedDoors: { [BasePart]: boolean } = {}
local rewardGatePart: BasePart? = nil
local resetButtonPart: BasePart? = nil
local resetButtonHomeCFrame: CFrame? = nil
local isResetButtonAnimating = false

-- ============================================================================
-- GERENCIAMENTO DE COLLISION GROUPS (BARREIRAS FÍSICAS AUTORITATIVAS)
-- ============================================================================

local function ensureCollisionGroupRegistered(groupName: string)
	if not PhysicsService:IsCollisionGroupRegistered(groupName) then
		PhysicsService:RegisterCollisionGroup(groupName)
	end
end

local function configureCollisionGroups()
	local requiredGroups = {
		COLLISION_GROUP_TUTORIAL_BARRIER,
		COLLISION_GROUP_REWARD_BARRIER,
		COLLISION_GROUP_PLAYER_LOCKED,
		COLLISION_GROUP_PLAYER_ACTIVE,
		COLLISION_GROUP_PLAYER_REWARD,
	}
	for _, groupName in ipairs(requiredGroups) do
		ensureCollisionGroupRegistered(groupName)
	end

	-- Fail-closed por padrão: qualquer peça em Default colide com ambas as barreiras
	PhysicsService:CollisionGroupSetCollidable("Default", COLLISION_GROUP_TUTORIAL_BARRIER, true)
	PhysicsService:CollisionGroupSetCollidable("Default", COLLISION_GROUP_REWARD_BARRIER, true)

	-- Jogadores antes de concluir [Seleção de Modo] + [Tutorial Obrigatório]
	PhysicsService:CollisionGroupSetCollidable(COLLISION_GROUP_PLAYER_LOCKED, COLLISION_GROUP_TUTORIAL_BARRIER, true)
	PhysicsService:CollisionGroupSetCollidable(COLLISION_GROUP_PLAYER_LOCKED, COLLISION_GROUP_REWARD_BARRIER, true)

	-- Jogadores em [Resolução de Questões] (tutorial concluído, < 15 acertos)
	PhysicsService:CollisionGroupSetCollidable(COLLISION_GROUP_PLAYER_ACTIVE, COLLISION_GROUP_TUTORIAL_BARRIER, false)
	PhysicsService:CollisionGroupSetCollidable(COLLISION_GROUP_PLAYER_ACTIVE, COLLISION_GROUP_REWARD_BARRIER, true)

	-- Jogadores qualificados para [Área de Recompensas] (>= 15 acertos dentro da validade)
	PhysicsService:CollisionGroupSetCollidable(COLLISION_GROUP_PLAYER_REWARD, COLLISION_GROUP_TUTORIAL_BARRIER, false)
	PhysicsService:CollisionGroupSetCollidable(COLLISION_GROUP_PLAYER_REWARD, COLLISION_GROUP_REWARD_BARRIER, false)

	local playerGroups = {
		COLLISION_GROUP_PLAYER_LOCKED,
		COLLISION_GROUP_PLAYER_ACTIVE,
		COLLISION_GROUP_PLAYER_REWARD,
	}
	for _, groupA in ipairs(playerGroups) do
		PhysicsService:CollisionGroupSetCollidable(groupA, "Default", true)
		if PhysicsService:IsCollisionGroupRegistered("RaceCars") then
			PhysicsService:CollisionGroupSetCollidable(groupA, "RaceCars", true)
		end
		for _, groupB in ipairs(playerGroups) do
			PhysicsService:CollisionGroupSetCollidable(groupA, groupB, true)
		end
	end
end

local function resolveCollisionGroupForState(state: PlayerState): string
	if state == PLAYER_STATES.REWARD_UNLOCKED or state == PLAYER_STATES.IN_REWARD_AREA then
		return COLLISION_GROUP_PLAYER_REWARD
	elseif state == PLAYER_STATES.ANSWERING_QUESTIONS then
		return COLLISION_GROUP_PLAYER_ACTIVE
	end
	return COLLISION_GROUP_PLAYER_LOCKED
end

local function applyCharacterCollisionGroup(player: Player, session: PlayerSession)
	local character = player.Character
	if not character then
		return
	end
	local targetGroup = resolveCollisionGroupForState(session.State)
	for _, descendant in ipairs(character:GetDescendants()) do
		if descendant:IsA("BasePart") then
			descendant.CollisionGroup = targetGroup
		end
	end
end

-- ============================================================================
-- UTILITÁRIOS DE ESTADO, PONTUAÇÃO, NOTIFICAÇÃO E TELEPORTE SEGURO
-- ============================================================================

local function getPlayerScore(player: Player): number
	local rawScore = player:GetAttribute("AcertosQuiz")
	if typeof(rawScore) ~= "number" then
		return 0
	end
	return math.clamp(math.floor(rawScore), 0, QuizConfig.MAX_SCORE)
end

local function isTimedModeEnabled(player: Player): boolean
	return player:GetAttribute("ModoComCronometro") == true
end

local function isFrozenApprovedAttempt(player: Player): boolean
	return typeof(player:GetAttribute("TempoRestanteCongeladoQuiz")) == "number"
		and getPlayerScore(player) >= QuizConfig.REWARD_MIN_SCORE
end

local function updateLeaderstats(player: Player, score: number)
	local leaderstats = player:FindFirstChild("leaderstats")
	if not leaderstats then
		local folder = Instance.new("Folder")
		folder.Name = "leaderstats"
		folder.Parent = player
		leaderstats = folder
	end

	local statValue = leaderstats:FindFirstChild(QuizConfig.TAB_STAT_NAME)
	if statValue and not statValue:IsA("StringValue") then
		statValue:Destroy()
		statValue = nil
	end
	if not statValue then
		local created = Instance.new("StringValue")
		created.Name = QuizConfig.TAB_STAT_NAME
		created.Parent = leaderstats
		statValue = created
	end
	(statValue :: StringValue).Value = string.format("%d/%d", score, QuizConfig.MAX_SCORE)
end

local function buildSessionSnapshot(player: Player, session: PlayerSession?)
	local currentState: PlayerState = if session then session.State else PLAYER_STATES.SELECTING_MODE
	local isActivePhase = currentState == PLAYER_STATES.ANSWERING_QUESTIONS
		or currentState == PLAYER_STATES.REWARD_UNLOCKED
		or currentState == PLAYER_STATES.IN_REWARD_AREA
	local phaseLabel = if isActivePhase then "Ativa" else "Tutorial"
	local endTimestamp = if session and session.AttemptEndTimestamp then session.AttemptEndTimestamp else 0

	return {
		Fase = phaseLabel,
		Ativa = isActivePhase,
		EstadoJogador = currentState,
		TutorialConcluido = if session then session.TutorialCompleted else false,
		FimRodadaTimestamp = endTimestamp,
		DuracaoTotal = QuizConfig.ROUND_DURATION_SECONDS,
		NumeroRodada = if session then math.max(1, session.AttemptNumber) else 1,
		Prontos = if session and session.TutorialCompleted then 1 else 0,
		Total = math.max(1, #Players:GetPlayers()),
	}
end

local function syncClientSessionState(player: Player, session: PlayerSession)
	SincronizarRodada:FireClient(player, buildSessionSnapshot(player, session))
end

ObterEstadoRodada.OnServerInvoke = function(player: Player)
	return buildSessionSnapshot(player, playerSessions[player])
end

local function setPlayerState(player: Player, session: PlayerSession, nextState: PlayerState)
	session.State = nextState
	player:SetAttribute("PlayerState", nextState)
	applyCharacterCollisionGroup(player, session)
	syncClientSessionState(player, session)
end

local function notifyPlayer(player: Player, message: string, color: Color3?, bypassCooldown: boolean?)
	local session = playerSessions[player]
	if not session then
		return
	end
	local now = os.clock()
	if not bypassCooldown and (now - session.LastNotificationClock) < QuizConfig.NOTIFICATION_COOLDOWN_SECONDS then
		return
	end
	session.LastNotificationClock = now
	NotificarMensagem:FireClient(player, message, color or COLOR_NOTICE_INFO)
end

local function findWorkspacePart(partName: string): BasePart?
	local instance = Workspace:FindFirstChild(partName, true)
	if instance and instance:IsA("BasePart") then
		return instance
	end
	if instance then
		return instance:FindFirstChildWhichIsA("BasePart", true)
	end
	return nil
end

local function safePivotCharacter(player: Player, targetCFrame: CFrame)
	local character = player.Character
	if not character then
		return
	end
	local rootPart = character:FindFirstChild("HumanoidRootPart") :: BasePart?
	local humanoid = character:FindFirstChildOfClass("Humanoid")
	if not rootPart or not humanoid or humanoid.Health <= 0 then
		return
	end

	-- Desacopla de qualquer VehicleSeat/Seat antes do teleporte para nunca arrastar veículos
	local seatPart = humanoid.SeatPart
	if seatPart then
		local seatWeld = seatPart:FindFirstChild("SeatWeld")
		if seatWeld then
			seatWeld:Destroy()
		end
		humanoid.Sit = false
		task.wait()
		if player.Parent ~= Players or character.Parent == nil or humanoid.Health <= 0 then
			return
		end
	end

	rootPart.AssemblyLinearVelocity = Vector3.zero
	rootPart.AssemblyAngularVelocity = Vector3.zero
	character:PivotTo(targetCFrame)
end

local function teleportToMainLobby(player: Player)
	safePivotCharacter(player, CFrame.lookAt(MAIN_LOBBY_HUB_POSITION, MAIN_LOBBY_LOOK_TARGET))
end

local function teleportToTutorialRoom(player: Player)
	local spawnLocation = Workspace:FindFirstChildOfClass("SpawnLocation")
	if spawnLocation then
		local origin = Vector3.new(spawnLocation.Position.X, spawnLocation.Position.Y + 3.5, TUTORIAL_SPAWN_POSITION.Z)
		safePivotCharacter(player, CFrame.lookAt(origin, Vector3.new(origin.X, origin.Y, TUTORIAL_LOOK_TARGET.Z)))
	else
		safePivotCharacter(player, CFrame.lookAt(TUTORIAL_SPAWN_POSITION, TUTORIAL_LOOK_TARGET))
	end
end

local function teleportToSubjectLevel(player: Player, subject: SubjectName, level: number)
	local targetPart: BasePart? = nil
	if level == 0 and subject == "Geografia" then
		teleportToTutorialRoom(player)
		return
	end

	targetPart = findWorkspacePart(if subject == "História" then "Teleport_Inicio_Historia" else "Teleport_Inicio_Geografia")
		or findWorkspacePart(if subject == "História" then "Inicio_Historia" else "Inicio_Geografia")
		or findWorkspacePart(string.format("Botão de Interação das Perguntas de %s nivel %d", subject, level))

	if not targetPart then
		teleportToMainLobby(player)
		return
	end
	safePivotCharacter(player, targetPart.CFrame * CFrame.new(0, 3.5, 4))
end

local function teleportToRewardGateApproach(player: Player, distanceStuds: number?)
	local approachDistance = distanceStuds or QuizConfig.REWARD_APPROACH_DISTANCE_STUDS
	local gate = rewardGatePart or findWorkspacePart(QuizConfig.REWARD_GATE_NAME)
	local gatePosition = if gate then gate.Position else REWARD_GATE_FALLBACK_POSITION

	local standPosition = Vector3.new(gatePosition.X, 1049.5, gatePosition.Z - approachDistance)
	local lookPosition = Vector3.new(gatePosition.X, 1049.5, gatePosition.Z)
	safePivotCharacter(player, CFrame.lookAt(standPosition, lookPosition))
end

-- ============================================================================
-- CONTROLE DE PORTAS, TEMPORIZADORES DE QUIZ E TEMPORIZADOR DE RECOMPENSAS
-- ============================================================================

local function shuffleList<T>(items: { T }): { T }
	local copy = table.clone(items)
	for index = #copy, 2, -1 do
		local swapIndex = math.random(index)
		copy[index], copy[swapIndex] = copy[swapIndex], copy[index]
	end
	return copy
end

local function drawQuestionIndex(session: PlayerSession, subject: SubjectName, level: number, totalQuestions: number): number
	local subjectDecks = session.QuestionDecks[subject]
	if not subjectDecks then
		subjectDecks = {}
		session.QuestionDecks[subject] = subjectDecks
	end
	local deck = subjectDecks[level]
	if not deck or #deck == 0 then
		local indices = table.create(totalQuestions)
		for index = 1, totalQuestions do
			table.insert(indices, index)
		end
		deck = shuffleList(indices)
		subjectDecks[level] = deck
	end
	return table.remove(deck) :: number
end

local function resetSubjectDoors(player: Player, subject: SubjectName)
	local maxLevel = if subject == "Geografia" then QuizConfig.MAX_GEOGRAPHY_LEVEL else QuizConfig.MAX_HISTORY_LEVEL
	for level = 1, maxLevel do
		local attributeName = if subject == "Geografia"
			then ("QuizFeito_Nivel" .. level)
			else ("QuizHistoriaFeito_Nivel" .. level)
		player:SetAttribute(attributeName, nil)
		ControlarPorta:FireClient(player, string.format("PortaNivel%d %s", level, subject), false)
	end
end

local function closeAllAttemptDoors(player: Player, preserveTutorialDoor: boolean)
	local startGeoLevel = if preserveTutorialDoor then 1 else 0
	for level = startGeoLevel, QuizConfig.MAX_GEOGRAPHY_LEVEL do
		ControlarPorta:FireClient(player, string.format("PortaNivel%d Geografia", level), false)
	end
	if preserveTutorialDoor then
		ControlarPorta:FireClient(player, "PortaNivel0 Geografia", true)
	end
	for level = 1, QuizConfig.MAX_HISTORY_LEVEL do
		ControlarPorta:FireClient(player, string.format("PortaNivel%d História", level), false)
	end
	ResetarClient:FireClient(player)
end

local function cancelRewardAreaCountdown(player: Player, session: PlayerSession)
	session.RewardTimerToken += 1
	session.RewardAreaEndTimestamp = nil
	player:SetAttribute("RewardAreaEndTimestamp", nil)
end

local resetPlayerAttempt: (player: Player, session: PlayerSession, incrementAttempt: boolean) -> ()

local function startQuizAttemptCountdown(player: Player, session: PlayerSession)
	session.AttemptTimerToken += 1
	local currentToken = session.AttemptTimerToken

	if not isTimedModeEnabled(player) then
		session.AttemptStartTimestamp = Workspace:GetServerTimeNow()
		session.AttemptEndTimestamp = nil
		player:SetAttribute("InicioTentativaQuiz", nil)
		player:SetAttribute("FimTentativaQuiz", nil)
		return
	end

	local nowServer = Workspace:GetServerTimeNow()
	local deadline = nowServer + QuizConfig.ROUND_DURATION_SECONDS
	session.AttemptStartTimestamp = nowServer
	session.AttemptEndTimestamp = deadline
	player:SetAttribute("InicioTentativaQuiz", nowServer)
	player:SetAttribute("FimTentativaQuiz", deadline)

	task.spawn(function()
		while player.Parent == Players and playerSessions[player] == session and session.AttemptTimerToken == currentToken do
			if isFrozenApprovedAttempt(player) then
				return
			end
			local remaining = deadline - Workspace:GetServerTimeNow()
			if remaining <= 0 then
				break
			end
			task.wait(math.clamp(remaining, 0.1, 1.0))
		end

		if player.Parent ~= Players or playerSessions[player] ~= session or session.AttemptTimerToken ~= currentToken then
			return
		end
		if isFrozenApprovedAttempt(player) or not isTimedModeEnabled(player) then
			return
		end

		-- Prazo da tentativa ranqueada esgotado antes dos 15 acertos: reinicia tentativa com segurança
		resetPlayerAttempt(player, session, true)
		FimDeRodada:FireClient(player, {
			Mensagem = "Tempo esgotado. Nova tentativa iniciada no saguão principal.",
			Individual = true,
		})
		notifyPlayer(
			player,
			"O tempo da tentativa esgotou. Uma nova tentativa foi iniciada.",
			COLOR_NOTICE_WARNING,
			true
		)
		task.defer(teleportToMainLobby, player)
	end)
end

resetPlayerAttempt = function(player: Player, session: PlayerSession, incrementAttempt: boolean)
	cancelRewardAreaCountdown(player, session)

	if session.TutorialCompleted then
		if incrementAttempt or session.AttemptNumber <= 0 then
			session.AttemptNumber = math.max(1, session.AttemptNumber + (if incrementAttempt then 1 else 0))
		end
	else
		session.AttemptNumber = 0
	end
	player:SetAttribute("NumeroTentativaQuiz", session.AttemptNumber)

	session.ActiveQuestion = nil
	session.QuestionDecks = {}
	session.StartingSubject = nil
	session.RewardQualifiedTeleportDone = false

	player:SetAttribute("AcertosQuiz", 0)
	player:SetAttribute("TempoConclusaoQuiz", nil)
	player:SetAttribute("TempoRestanteCongeladoQuiz", nil)
	updateLeaderstats(player, 0)

	for level = 0, QuizConfig.MAX_GEOGRAPHY_LEVEL do
		player:SetAttribute("QuizFeito_Nivel" .. level, nil)
	end
	for level = 1, QuizConfig.MAX_HISTORY_LEVEL do
		player:SetAttribute("QuizHistoriaFeito_Nivel" .. level, nil)
	end

	if session.TutorialCompleted then
		player:SetAttribute("QuizFeito_Nivel0", true)
		session.Progress = nil
		setPlayerState(player, session, PLAYER_STATES.ANSWERING_QUESTIONS)
		startQuizAttemptCountdown(player, session)
	else
		session.AttemptTimerToken += 1
		session.AttemptStartTimestamp = nil
		session.AttemptEndTimestamp = nil
		player:SetAttribute("InicioTentativaQuiz", nil)
		player:SetAttribute("FimTentativaQuiz", nil)
		session.Progress = { Subject = "Geografia", Level = 0 }

		local hasChosenMode = player:GetAttribute("ModoComCronometro") ~= nil
		setPlayerState(
			player,
			session,
			if hasChosenMode then PLAYER_STATES.IN_TUTORIAL else PLAYER_STATES.SELECTING_MODE
		)
	end

	closeAllAttemptDoors(player, session.TutorialCompleted)
end

local function handleRewardAreaTimeExpired(player: Player, session: PlayerSession)
	if player.Parent ~= Players or playerSessions[player] ~= session then
		return
	end

	local wasInRewardArea = session.State == PLAYER_STATES.IN_REWARD_AREA
	local rootPart = player.Character and player.Character:FindFirstChild("HumanoidRootPart")
	local physicallyInRewardZone = rootPart ~= nil
		and rootPart:IsA("BasePart")
		and rootPart.Position.Y < 500

	-- Revoga acesso às recompensas, limpa timer e restaura tentativa para o estado padrão
	resetPlayerAttempt(player, session, true)

	if wasInRewardArea or physicallyInRewardZone then
		teleportToMainLobby(player)
	end

	notifyPlayer(
		player,
		"Seu tempo na Área de Recompensas terminou.",
		COLOR_NOTICE_WARNING,
		true
	)
end

local function activateRewardAreaSession(player: Player, session: PlayerSession)
	setPlayerState(player, session, PLAYER_STATES.IN_REWARD_AREA)

	-- Mantém a mesma janela estrita de 10 minutos caso o jogador saia e retorne ao portal
	if session.RewardAreaEndTimestamp ~= nil then
		if Workspace:GetServerTimeNow() >= session.RewardAreaEndTimestamp then
			handleRewardAreaTimeExpired(player, session)
		end
		return
	end

	local deadline = Workspace:GetServerTimeNow() + QuizConfig.REWARD_AREA_DURATION_SECONDS
	session.RewardAreaEndTimestamp = deadline
	player:SetAttribute("RewardAreaEndTimestamp", deadline)

	session.RewardTimerToken += 1
	local currentToken = session.RewardTimerToken

	task.spawn(function()
		while player.Parent == Players and playerSessions[player] == session and session.RewardTimerToken == currentToken do
			local remaining = deadline - Workspace:GetServerTimeNow()
			if remaining <= 0 then
				break
			end
			task.wait(math.clamp(remaining, 0.1, 1.0))
		end

		if player.Parent ~= Players or playerSessions[player] ~= session or session.RewardTimerToken ~= currentToken then
			return
		end

		handleRewardAreaTimeExpired(player, session)
	end)
end

-- ============================================================================
-- VALIDAÇÃO DE QUESTÕES E PROGRESSÃO LINEAR DE MATÉRIAS
-- ============================================================================

local function getLevelQuestions(subject: SubjectName, level: number): { any }?
	local subjectTable = QuizBanco[subject]
	local levelEntry = subjectTable and subjectTable[level]
	local questions = levelEntry and levelEntry.Dados
	if type(questions) ~= "table" or #questions == 0 then
		return nil
	end
	return questions
end

local function isWithinInteractionDistance(player: Player, part: BasePart, maxDistance: number): boolean
	local character = player.Character
	local rootPart = character and character:FindFirstChild("HumanoidRootPart")
	if not rootPart or not rootPart:IsA("BasePart") then
		return false
	end
	return (rootPart.Position - part.Position).Magnitude <= (maxDistance + 4)
end

local function sendQuestionToClient(player: Player, question: ActiveQuestionSession)
	AbrirQuiz:FireClient(player, {
		Materia = question.Subject,
		Nivel = question.Level,
		Nome = question.QuestionTitle,
		Alternativas = question.Choices,
	})
end

local function handleQuizPromptTriggered(
	player: Player,
	subject: SubjectName,
	level: number,
	doorName: string,
	part: BasePart,
	prompt: ProximityPrompt
)
	local session = playerSessions[player]
	if not session then
		return
	end
	if not isWithinInteractionDistance(player, part, prompt.MaxActivationDistance) then
		return
	end

	local isTutorialQuestion = subject == "Geografia" and level == 0
	if isTutorialQuestion then
		if session.TutorialCompleted then
			return
		end
		if session.State == PLAYER_STATES.SELECTING_MODE or player:GetAttribute("ModoComCronometro") == nil then
			DefinirModoJogo:FireClient(player)
			notifyPlayer(player, "Selecione um modo de jogo antes de iniciar o tutorial.", COLOR_NOTICE_WARNING)
			return
		end
		if session.State ~= PLAYER_STATES.IN_TUTORIAL then
			return
		end
	else
		-- Validação estrita da máquina de estados: nunca permite pular Seleção de Modo ou Tutorial
		if session.State == PLAYER_STATES.SELECTING_MODE or player:GetAttribute("ModoComCronometro") == nil then
			DefinirModoJogo:FireClient(player)
			notifyPlayer(player, "Selecione um modo de jogo antes de iniciar o tutorial.", COLOR_NOTICE_WARNING)
			return
		end
		if not session.TutorialCompleted or session.State == PLAYER_STATES.IN_TUTORIAL then
			notifyPlayer(player, "Complete o tutorial antes de prosseguir.", COLOR_NOTICE_WARNING)
			return
		end
		if session.State == PLAYER_STATES.IN_REWARD_AREA then
			notifyPlayer(player, "Retorne ao saguão principal para responder questões.", COLOR_NOTICE_WARNING)
			return
		end

		local expectedProgress = session.Progress
		if not expectedProgress then
			if level == 1 and (subject == "Geografia" or subject == "História") then
				session.StartingSubject = subject
				session.Progress = { Subject = subject, Level = 1 }
			else
				notifyPlayer(
					player,
					"Dirija-se ao Nível 1 de Geografia ou de História para iniciar o percurso.",
					COLOR_NOTICE_WARNING
				)
				return
			end
		elseif expectedProgress.Subject ~= subject or expectedProgress.Level ~= level then
			notifyPlayer(
				player,
				string.format("Responda primeiro %s · Nível %d.", expectedProgress.Subject, expectedProgress.Level),
				COLOR_NOTICE_WARNING
			)
			return
		end
	end

	local existingQuestion = session.ActiveQuestion
	if existingQuestion then
		if existingQuestion.Answered then
			return
		end
		if existingQuestion.Subject == subject and existingQuestion.Level == level then
			sendQuestionToClient(player, existingQuestion)
		end
		return
	end

	local questions = getLevelQuestions(subject, level)
	if not questions then
		warn(string.format("[QuizServer] Banco sem questões para %s nível %d.", subject, level))
		return
	end

	local chosenIndex = drawQuestionIndex(session, subject, level, #questions)
	local rawQuestion = questions[chosenIndex]
	if type(rawQuestion) ~= "table" or type(rawQuestion.Alternativas) ~= "table" or #rawQuestion.Alternativas ~= 3 then
		warn(string.format("[QuizServer] Questão inválida em %s nível %d.", subject, level))
		return
	end

	local preparedChoices: { PreparedChoice } = {}
	local lieCount = 0
	for _, rawChoice in ipairs(rawQuestion.Alternativas) do
		if type(rawChoice) ~= "table" or type(rawChoice.Texto) ~= "string" or typeof(rawChoice.Falsa) ~= "boolean" then
			warn(string.format("[QuizServer] Alternativa inválida em %s nível %d.", subject, level))
			return
		end
		table.insert(preparedChoices, {
			Text = rawChoice.Texto,
			IsLie = rawChoice.Falsa,
		})
		if rawChoice.Falsa then
			lieCount += 1
		end
	end
	if lieCount ~= 1 then
		warn(string.format("[QuizServer] Esperada 1 alternativa falsa em %s nível %d; encontradas %d.", subject, level, lieCount))
		return
	end

	local shuffledChoices = shuffleList(preparedChoices)
	local clientChoices: { string } = table.create(#shuffledChoices)
	local correctChoiceIndex = 0
	for index, choice in ipairs(shuffledChoices) do
		table.insert(clientChoices, choice.Text)
		if choice.IsLie then
			correctChoiceIndex = index
		end
	end

	local activeQuestion: ActiveQuestionSession = {
		Subject = subject,
		Level = level,
		DoorName = doorName,
		QuestionTitle = tostring(rawQuestion.Nome),
		Choices = clientChoices,
		CorrectIndex = correctChoiceIndex,
		IsTutorial = isTutorialQuestion,
		Answered = false,
	}
	session.ActiveQuestion = activeQuestion
	sendQuestionToClient(player, activeQuestion)
end

local function handleAnswerSubmission(player: Player, selectedIndex: any)
	local session = playerSessions[player]
	if not session then
		return { Aceito = false, Mensagem = "Sessão não inicializada." }
	end

	local activeQuestion = session.ActiveQuestion
	if not activeQuestion or activeQuestion.Answered then
		return { Aceito = false, Mensagem = "Não há uma questão ativa." }
	end

	if typeof(selectedIndex) ~= "number"
		or selectedIndex ~= selectedIndex
		or selectedIndex % 1 ~= 0
		or selectedIndex < 1
		or selectedIndex > #activeQuestion.Choices
	then
		return { Aceito = false, Mensagem = "Alternativa inválida." }
	end

	local timedMode = isTimedModeEnabled(player)
	if activeQuestion.IsTutorial then
		if session.TutorialCompleted or session.State ~= PLAYER_STATES.IN_TUTORIAL or player:GetAttribute("ModoComCronometro") == nil then
			session.ActiveQuestion = nil
			return { Aceito = false, Mensagem = "Selecione um modo de jogo antes de concluir o tutorial." }
		end
	else
		local timerExpired = timedMode
			and not isFrozenApprovedAttempt(player)
			and (session.AttemptEndTimestamp or 0) <= Workspace:GetServerTimeNow()
		local validQuizState = session.TutorialCompleted
			and (session.State == PLAYER_STATES.ANSWERING_QUESTIONS or session.State == PLAYER_STATES.REWARD_UNLOCKED)
		if not validQuizState or timerExpired then
			session.ActiveQuestion = nil
			return { Aceito = false, Mensagem = "Esta tentativa não está mais aceitando respostas." }
		end
	end

	activeQuestion.Answered = true
	local isCorrect = selectedIndex == activeQuestion.CorrectIndex
	local levelAttribute = if activeQuestion.Subject == "Geografia"
		then ("QuizFeito_Nivel" .. activeQuestion.Level)
		else ("QuizHistoriaFeito_Nivel" .. activeQuestion.Level)

	player:SetAttribute(levelAttribute, true)
	ControlarPorta:FireClient(player, activeQuestion.DoorName, true)

	local score = getPlayerScore(player)
	if activeQuestion.IsTutorial then
		session.TutorialCompleted = true
		session.AttemptNumber = 1
		resetPlayerAttempt(player, session, false)
		notifyPlayer(
			player,
			"Tutorial concluído. Escolha Geografia ou História no saguão principal.",
			COLOR_NOTICE_SUCCESS,
			true
		)
		task.delay(QuizConfig.RESULT_DISPLAY_SECONDS + 0.15, function()
			if player.Parent == Players and playerSessions[player] == session then
				teleportToMainLobby(player)
			end
		end)
	else
		if isCorrect then
			score = math.min(QuizConfig.MAX_SCORE, score + 1)
			player:SetAttribute("AcertosQuiz", score)
			updateLeaderstats(player, score)

			-- Atualiza tempo de conclusão ranqueado ao atingir ou superar 15 acertos
			if timedMode and score >= QuizConfig.REWARD_MIN_SCORE and session.AttemptStartTimestamp then
				local nowServer = Workspace:GetServerTimeNow()
				local elapsed = math.max(0, nowServer - session.AttemptStartTimestamp)
				player:SetAttribute("TempoConclusaoQuiz", elapsed)
				if player:GetAttribute("TempoRestanteCongeladoQuiz") == nil then
					local endTimestamp = session.AttemptEndTimestamp or nowServer
					player:SetAttribute("TempoRestanteCongeladoQuiz", math.max(0, endTimestamp - nowServer))
				end
			end
		end

		local justQualifiedForRewards = false
		if score >= QuizConfig.REWARD_MIN_SCORE and not session.RewardQualifiedTeleportDone then
			session.RewardQualifiedTeleportDone = true
			justQualifiedForRewards = true
			setPlayerState(player, session, PLAYER_STATES.REWARD_UNLOCKED)

			if timedMode then
				notifyPlayer(
					player,
					"15 acertos alcançados. Tempo registrado no Ranking Global e Área de Recompensas liberada.",
					COLOR_NOTICE_SUCCESS,
					true
				)
			else
				notifyPlayer(
					player,
					"15 acertos alcançados. O acesso à Área de Recompensas está liberado.",
					COLOR_NOTICE_SUCCESS,
					true
				)
			end

			task.delay(QuizConfig.RESULT_DISPLAY_SECONDS + 0.15, function()
				if player.Parent == Players and playerSessions[player] == session then
					teleportToRewardGateApproach(player, QuizConfig.REWARD_APPROACH_DISTANCE_STUDS)
				end
			end)
		end

		local currentProgress = session.Progress
		if currentProgress and currentProgress.Subject == activeQuestion.Subject and currentProgress.Level == activeQuestion.Level then
			local firstSubject: SubjectName = session.StartingSubject or "Geografia"
			local secondSubject: SubjectName = if firstSubject == "Geografia" then "História" else "Geografia"
			local firstMaxLevel = if firstSubject == "Geografia" then QuizConfig.MAX_GEOGRAPHY_LEVEL else QuizConfig.MAX_HISTORY_LEVEL
			local secondMaxLevel = if secondSubject == "Geografia" then QuizConfig.MAX_GEOGRAPHY_LEVEL else QuizConfig.MAX_HISTORY_LEVEL

			local finishedFirstSubject = activeQuestion.Subject == firstSubject and activeQuestion.Level == firstMaxLevel
			local finishedSecondSubject = activeQuestion.Subject == secondSubject and activeQuestion.Level == secondMaxLevel

			if finishedFirstSubject then
				session.Progress = { Subject = secondSubject, Level = 1 }
				resetSubjectDoors(player, secondSubject)
				notifyPlayer(
					player,
					string.format("%s concluída. Prosseguindo para %s · Nível 1.", firstSubject, secondSubject),
					COLOR_NOTICE_INFO,
					true
				)
				task.delay(QuizConfig.RESULT_DISPLAY_SECONDS + 0.15, function()
					if player.Parent == Players and playerSessions[player] == session then
						teleportToSubjectLevel(player, secondSubject, 1)
					end
				end)
			elseif finishedSecondSubject then
				if timedMode and player:GetAttribute("TempoConclusaoQuiz") == nil and session.AttemptStartTimestamp then
					player:SetAttribute(
						"TempoConclusaoQuiz",
						math.max(0, Workspace:GetServerTimeNow() - session.AttemptStartTimestamp)
					)
				end

				if score < QuizConfig.REWARD_MIN_SCORE then
					local completedAttempt = session.AttemptNumber
					task.delay(QuizConfig.RESULT_DISPLAY_SECONDS + 0.15, function()
						if player.Parent == Players
							and playerSessions[player] == session
							and session.AttemptNumber == completedAttempt
						then
							resetPlayerAttempt(player, session, true)
							teleportToMainLobby(player)
							notifyPlayer(
								player,
								string.format(
									"Tentativa concluída com %d/%d acertos (mínimo %d). Nova tentativa iniciada.",
									score,
									QuizConfig.MAX_SCORE,
									QuizConfig.REWARD_MIN_SCORE
								),
								COLOR_NOTICE_WARNING,
								true
							)
						end
					end)
				else
					session.Progress = nil
					if not justQualifiedForRewards then
						notifyPlayer(
							player,
							"Percurso completo concluído. Aproveite a Área de Recompensas.",
							COLOR_NOTICE_SUCCESS,
							true
						)
						task.delay(QuizConfig.RESULT_DISPLAY_SECONDS + 0.15, function()
							if player.Parent == Players
								and playerSessions[player] == session
								and session.State == PLAYER_STATES.REWARD_UNLOCKED
							then
								teleportToRewardGateApproach(player, QuizConfig.REWARD_APPROACH_DISTANCE_STUDS)
							end
						end)
					end
				end
			else
				session.Progress = {
					Subject = activeQuestion.Subject,
					Level = activeQuestion.Level + 1,
				}
			end
		end
	end

	task.delay(QuizConfig.RESULT_DISPLAY_SECONDS, function()
		if playerSessions[player] == session and session.ActiveQuestion == activeQuestion then
			session.ActiveQuestion = nil
		end
	end)

	return {
		Aceito = true,
		Acertou = isCorrect,
		IndiceCorreto = activeQuestion.CorrectIndex,
		Pontuacao = score,
		TutorialConcluido = activeQuestion.IsTutorial,
	}
end

EnviarResposta.OnServerInvoke = handleAnswerSubmission

-- ============================================================================
-- SELEÇÃO DE MODO E REINÍCIO DE TENTATIVA
-- ============================================================================

local function animatePhysicalResetButton()
	if not resetButtonPart or not resetButtonHomeCFrame or isResetButtonAnimating then
		return
	end
	isResetButtonAnimating = true
	local buttonPart = resetButtonPart
	local homeCFrame = resetButtonHomeCFrame
	local pressedCFrame = homeCFrame * CFrame.new(0, -0.14, 0)

	local pressDown = TweenService:Create(
		buttonPart,
		TweenInfo.new(0.08, Enum.EasingStyle.Quad, Enum.EasingDirection.Out),
		{ CFrame = pressedCFrame, Color = Color3.fromRGB(115, 22, 22) }
	)
	local releaseUp = TweenService:Create(
		buttonPart,
		TweenInfo.new(0.12, Enum.EasingStyle.Quad, Enum.EasingDirection.Out),
		{ CFrame = homeCFrame, Color = Color3.fromRGB(153, 27, 27) }
	)
	pressDown:Play()
	pressDown.Completed:Wait()
	releaseUp:Play()
	releaseUp.Completed:Wait()
	isResetButtonAnimating = false
end

local function processManualReset(player: Player, respawnCharacter: boolean)
	local session = playerSessions[player]
	if not session then
		return
	end

	local now = os.clock()
	if (now - session.LastResetClock) < QuizConfig.RESET_COOLDOWN_SECONDS then
		return
	end
	session.LastResetClock = now

	-- Impede bypass do fluxo linear obrigatório caso acionado antes do fim do tutorial
	if not session.TutorialCompleted then
		if player:GetAttribute("ModoComCronometro") == nil then
			setPlayerState(player, session, PLAYER_STATES.SELECTING_MODE)
			DefinirModoJogo:FireClient(player)
			notifyPlayer(player, "Selecione um modo de jogo antes de iniciar o tutorial.", COLOR_NOTICE_WARNING, true)
		else
			setPlayerState(player, session, PLAYER_STATES.IN_TUTORIAL)
			teleportToTutorialRoom(player)
			notifyPlayer(player, "Complete o tutorial antes de prosseguir.", COLOR_NOTICE_WARNING, true)
		end
		return
	end

	resetPlayerAttempt(player, session, true)
	notifyPlayer(
		player,
		string.format("Tentativa %d iniciada. Escolha uma matéria no saguão principal.", session.AttemptNumber),
		COLOR_NOTICE_INFO,
		true
	)

	if respawnCharacter then
		local humanoid = player.Character and player.Character:FindFirstChildOfClass("Humanoid")
		if humanoid and humanoid.Health > 0 then
			session.PendingRespawnReset = true
			humanoid.Health = 0
			return
		end
	end
	task.defer(teleportToMainLobby, player)
end

SolicitarReset.OnServerEvent:Connect(function(player: Player)
	processManualReset(player, false)
	if resetButtonPart then
		task.spawn(animatePhysicalResetButton)
	end
end)

DefinirModoJogo.OnServerEvent:Connect(function(player: Player, requestedTimedMode: any)
	if typeof(requestedTimedMode) ~= "boolean" then
		return
	end
	local session = playerSessions[player]
	if not session then
		return
	end

	local nextTimedMode = requestedTimedMode == true
	local currentMode = player:GetAttribute("ModoComCronometro")

	-- Mesmo modo já ativo: nenhuma ação necessária
	if currentMode == nextTimedMode and session.State ~= PLAYER_STATES.SELECTING_MODE then
		return
	end

	-- Primeira seleção obrigatória de modo antes do tutorial
	if currentMode == nil or session.State == PLAYER_STATES.SELECTING_MODE then
		player:SetAttribute("ModoComCronometro", nextTimedMode)
		if session.TutorialCompleted then
			resetPlayerAttempt(player, session, false)
			task.defer(teleportToMainLobby, player)
		else
			setPlayerState(player, session, PLAYER_STATES.IN_TUTORIAL)
			notifyPlayer(
				player,
				if nextTimedMode
					then "Modo Ranqueado selecionado. Conclua o tutorial à frente para iniciar."
					else "Modo Livre selecionado. Conclua o tutorial à frente para iniciar.",
				COLOR_NOTICE_INFO,
				true
			)
		end
		return
	end

	-- Troca de Modo Ranqueado -> Modo Livre: registra tentativa atual no ranking e remove cronômetro
	if currentMode == true and nextTimedMode == false then
		if session.TutorialCompleted then
			session.AttemptNumber += 1
			player:SetAttribute("NumeroTentativaQuiz", session.AttemptNumber)

			if player:GetAttribute("TempoConclusaoQuiz") == nil and session.AttemptStartTimestamp then
				local elapsed = math.max(0, Workspace:GetServerTimeNow() - session.AttemptStartTimestamp)
				player:SetAttribute("TempoConclusaoQuiz", elapsed)
			end

			task.wait(0.15)
			if player.Parent ~= Players or playerSessions[player] ~= session then
				return
			end
		end

		player:SetAttribute("ModoComCronometro", false)
		session.AttemptTimerToken += 1
		session.AttemptStartTimestamp = nil
		session.AttemptEndTimestamp = nil
		player:SetAttribute("InicioTentativaQuiz", nil)
		player:SetAttribute("FimTentativaQuiz", nil)
		syncClientSessionState(player, session)

		notifyPlayer(
			player,
			"Modo Livre ativado. A tentativa ranqueada anterior foi salva.",
			COLOR_NOTICE_SUCCESS,
			true
		)
		return
	end

	-- Troca de Modo Livre -> Modo Ranqueado: reinicia progresso para iniciar tentativa válida de 10 minutos
	if currentMode == false and nextTimedMode == true then
		player:SetAttribute("ModoComCronometro", true)
		if session.TutorialCompleted then
			resetPlayerAttempt(player, session, true)
			task.defer(teleportToMainLobby, player)
			notifyPlayer(
				player,
				"Modo Ranqueado ativado. Progresso reiniciado com limite de 10 minutos.",
				COLOR_NOTICE_INFO,
				true
			)
		else
			setPlayerState(player, session, PLAYER_STATES.IN_TUTORIAL)
			notifyPlayer(
				player,
				"Modo alterado para Ranqueado. Conclua o tutorial para iniciar.",
				COLOR_NOTICE_INFO,
				true
			)
		end
	end
end)

-- ============================================================================
-- BARREIRAS FÍSICAS ANTI-CLIPPING, PORTAS, BOTÃO DE RESET E PORTAIS
-- ============================================================================

local function mapInteractionButton(partName: string): (SubjectName?, number?)
	for level = 0, QuizConfig.MAX_GEOGRAPHY_LEVEL do
		if partName == string.format("Botão de Interação das Perguntas de Geografia nivel %d", level) then
			return "Geografia", level
		end
	end
	for level = 1, QuizConfig.MAX_HISTORY_LEVEL do
		if partName == string.format("Botão de Interação das Perguntas de História nivel %d", level) then
			return "História", level
		end
	end
	return nil, nil
end

local function parseDoorName(partName: string): (number?, SubjectName?)
	for level = 0, QuizConfig.MAX_GEOGRAPHY_LEVEL do
		if partName == string.format("PortaNivel%d Geografia", level) then
			return level, "Geografia"
		end
	end
	for level = 1, QuizConfig.MAX_HISTORY_LEVEL do
		if partName == string.format("PortaNivel%d História", level) then
			return level, "História"
		end
	end
	return nil, nil
end

local function connectQuizPrompt(prompt: ProximityPrompt)
	if connectedPrompts[prompt] then
		return
	end
	local parentPart = prompt:FindFirstAncestorWhichIsA("BasePart")
	if not parentPart then
		return
	end
	local subject, level = mapInteractionButton(parentPart.Name)
	if not subject or level == nil then
		return
	end

	connectedPrompts[prompt] = true
	prompt.ActionText = if level == 0 then "Iniciar tutorial" else "Responder questão"
	prompt.ObjectText = if level == 0 then "Tutorial Obrigatório" else string.format("%s · Nível %d", subject, level)
	prompt.RequiresLineOfSight = false
	prompt.MaxActivationDistance = 12
	prompt.HoldDuration = 0
	prompt.Enabled = true

	prompt.Triggered:Connect(function(player: Player)
		handleQuizPromptTriggered(
			player,
			subject,
			level,
			string.format("PortaNivel%d %s", level, subject),
			parentPart,
			prompt
		)
	end)
end

local function notifyLockedBarrierTouch(player: Player, subject: SubjectName, level: number)
	local session = playerSessions[player]
	if not session then
		return
	end
	local now = os.clock()
	if (now - session.LastBarrierNoticeClock) < BARRIER_NOTICE_COOLDOWN_SECONDS then
		return
	end
	session.LastBarrierNoticeClock = now

	if session.State == PLAYER_STATES.SELECTING_MODE or player:GetAttribute("ModoComCronometro") == nil then
		DefinirModoJogo:FireClient(player)
		notifyPlayer(player, "Selecione um modo de jogo antes de prosseguir.", COLOR_NOTICE_WARNING, true)
	elseif not session.TutorialCompleted or level == 0 then
		notifyPlayer(player, "Complete o tutorial antes de prosseguir.", COLOR_NOTICE_WARNING, true)
	else
		notifyPlayer(
			player,
			string.format("Responda a questão de %s · Nível %d antes de prosseguir.", subject, level),
			COLOR_NOTICE_WARNING,
			true
		)
	end
end

local function ensureTutorialStructuralBarrier()
	local existing = doorBarriersFolder:FindFirstChild(TUTORIAL_BARRIER_NAME)
	local barrier: BasePart
	if existing and existing:IsA("BasePart") then
		barrier = existing
	else
		if existing then
			existing:Destroy()
		end
		local part = Instance.new("Part")
		part.Name = TUTORIAL_BARRIER_NAME
		part.Parent = doorBarriersFolder
		barrier = part
	end

	barrier.Anchored = true
	barrier.CanCollide = true
	barrier.CanTouch = true
	barrier.CanQuery = false
	barrier.Transparency = 1
	barrier.Size = TUTORIAL_BARRIER_SIZE
	barrier.CFrame = CFrame.new(TUTORIAL_BARRIER_POSITION)
	barrier.CollisionGroup = COLLISION_GROUP_TUTORIAL_BARRIER

	barrier.Touched:Connect(function(hit: BasePart)
		local character = hit:FindFirstAncestorOfClass("Model")
		local player = character and Players:GetPlayerFromCharacter(character)
		if not player then
			return
		end
		local session = playerSessions[player]
		if session and not session.TutorialCompleted then
			notifyLockedBarrierTouch(player, "Geografia", 0)
		end
	end)
end

local function createOrUpdateCorridorShield(door: BasePart, subject: SubjectName, level: number)
	local shieldName = "BarreiraFisica_" .. door.Name
	local existing = doorBarriersFolder:FindFirstChild(shieldName)
	local shield: BasePart
	if existing and existing:IsA("BasePart") then
		shield = existing
	else
		if existing then
			existing:Destroy()
		end
		local part = Instance.new("Part")
		part.Name = shieldName
		part.Parent = doorBarriersFolder
		shield = part
	end

	-- Alinha a face frontal da barreira espessa exatamente com a face frontal da porta visível
	local xOffset = if subject == "Geografia" then 0.9 else -0.9
	shield.Anchored = true
	shield.CanCollide = true
	shield.CanTouch = true
	shield.CanQuery = false
	shield.Transparency = 1
	shield.Size = CORRIDOR_SHIELD_SIZE
	shield.CFrame = CFrame.new(door.Position + Vector3.new(xOffset, 4.0, 0))
	shield:SetAttribute("TargetDoorName", door.Name)

	if shield:GetAttribute("TouchBound") ~= true then
		shield:SetAttribute("TouchBound", true)
		shield.Touched:Connect(function(hit: BasePart)
			local character = hit:FindFirstAncestorOfClass("Model")
			local player = character and Players:GetPlayerFromCharacter(character)
			if not player then
				return
			end
			local attributeName = if subject == "Geografia"
				then ("QuizFeito_Nivel" .. level)
				else ("QuizHistoriaFeito_Nivel" .. level)
			if player:GetAttribute(attributeName) ~= true then
				notifyLockedBarrierTouch(player, subject, level)
			end
		end)
	end
end

local function connectPhysicalDoor(door: BasePart)
	if connectedDoors[door] then
		return
	end
	local level, subject = parseDoorName(door.Name)
	if level == nil or not subject then
		return
	end

	connectedDoors[door] = true
	door.Anchored = true
	door.CanCollide = true
	door.CanTouch = true

	if level == 0 and subject == "Geografia" then
		door.CollisionGroup = COLLISION_GROUP_TUTORIAL_BARRIER
	else
		createOrUpdateCorridorShield(door, subject, level)
	end

	-- Sem teleporte punitivo: a contenção ocorre por colisão física sólida + feedback limpo na UI
	door.Touched:Connect(function(hit: BasePart)
		local character = hit:FindFirstAncestorOfClass("Model")
		local player = character and Players:GetPlayerFromCharacter(character)
		if not player then
			return
		end
		local attributeName = if subject == "Geografia"
			then ("QuizFeito_Nivel" .. level)
			else ("QuizHistoriaFeito_Nivel" .. level)
		if player:GetAttribute(attributeName) ~= true then
			notifyLockedBarrierTouch(player, subject, level)
		end
	end)
end

local function findMarkedRewardPortal(): BasePart?
	for _, descendant in ipairs(Workspace:GetDescendants()) do
		if descendant:IsA("BasePart") and descendant:GetAttribute(QuizConfig.REWARD_GATE_ATTRIBUTE) == true then
			return descendant
		end
	end
	return nil
end

local function configureRewardGateAndBarrier()
	rewardGatePart = findWorkspacePart(QuizConfig.REWARD_GATE_NAME)
	local markedPortal = findMarkedRewardPortal()
	if not rewardGatePart then
		local createdGate = Instance.new("Part")
		createdGate.Name = QuizConfig.REWARD_GATE_NAME
		createdGate.Anchored = true
		createdGate.Parent = Workspace
		rewardGatePart = createdGate
	end

	local gate = rewardGatePart :: BasePart
	gate.Name = QuizConfig.REWARD_GATE_NAME
	gate.Anchored = true
	gate.CanCollide = false
	gate.CanTouch = false
	gate.CanQuery = false
	-- Paleta sóbria e fosca/translúcida, eliminando ciano neon saturado
	gate.Material = Enum.Material.Glass
	gate.Color = Color3.fromRGB(30, 41, 59)
	gate.Transparency = 0.45

	if markedPortal then
		gate.CFrame = markedPortal.CFrame
		gate.Size = REWARD_GATE_VISUAL_SIZE
		markedPortal.CanCollide = false
		markedPortal.CanTouch = true
		markedPortal.CanQuery = true
		markedPortal.Transparency = 1
	else
		gate.CFrame = CFrame.new(REWARD_GATE_FALLBACK_POSITION)
		gate.Size = REWARD_GATE_VISUAL_SIZE
	end

	-- Barreira física sólida autoritativa por CollisionGroup (sem teleporte punitivo para trás)
	local existingBarrier = doorBarriersFolder:FindFirstChild(REWARD_BARRIER_NAME)
	local rewardBarrier: BasePart
	if existingBarrier and existingBarrier:IsA("BasePart") then
		rewardBarrier = existingBarrier
	else
		if existingBarrier then
			existingBarrier:Destroy()
		end
		local created = Instance.new("Part")
		created.Name = REWARD_BARRIER_NAME
		created.Parent = doorBarriersFolder
		rewardBarrier = created
	end

	rewardBarrier.Anchored = true
	rewardBarrier.CanCollide = true
	rewardBarrier.CanTouch = true
	rewardBarrier.CanQuery = false
	rewardBarrier.Transparency = 1
	rewardBarrier.Size = REWARD_BARRIER_SIZE
	rewardBarrier.CFrame = CFrame.new(gate.Position + Vector3.new(0, 3.0, -0.15))
	rewardBarrier.CollisionGroup = COLLISION_GROUP_REWARD_BARRIER

	rewardBarrier.Touched:Connect(function(hit: BasePart)
		local character = hit:FindFirstAncestorOfClass("Model")
		local player = character and Players:GetPlayerFromCharacter(character)
		if not player then
			return
		end
		local session = playerSessions[player]
		if not session then
			return
		end
		if session.State == PLAYER_STATES.REWARD_UNLOCKED or session.State == PLAYER_STATES.IN_REWARD_AREA then
			return
		end

		local now = os.clock()
		if (now - session.LastBarrierNoticeClock) < BARRIER_NOTICE_COOLDOWN_SECONDS then
			return
		end
		session.LastBarrierNoticeClock = now

		if not session.TutorialCompleted then
			notifyPlayer(player, "Complete o tutorial antes de prosseguir.", COLOR_NOTICE_WARNING, true)
		else
			notifyPlayer(
				player,
				string.format(
					"Alcance %d acertos para liberar a Área de Recompensas (%d/%d).",
					QuizConfig.REWARD_MIN_SCORE,
					getPlayerScore(player),
					QuizConfig.MAX_SCORE
				),
				COLOR_NOTICE_WARNING,
				true
			)
		end
	end)
end

local function configurePhysicalResetButton()
	resetButtonPart = findWorkspacePart(QuizConfig.RESET_BUTTON_NAME)
	if not resetButtonPart then
		return
	end

	local part = resetButtonPart
	part.Anchored = true
	part.Material = Enum.Material.SmoothPlastic
	part.Color = Color3.fromRGB(153, 27, 27)
	part.TopSurface = Enum.SurfaceType.Smooth
	part.BottomSurface = Enum.SurfaceType.Smooth
	resetButtonHomeCFrame = part.CFrame

	local surfaceGui = part:FindFirstChild("ResetButtonSurfaceGui") :: SurfaceGui?
	if not surfaceGui then
		local created = Instance.new("SurfaceGui")
		created.Name = "ResetButtonSurfaceGui"
		created.Face = Enum.NormalId.Top
		created.SizingMode = Enum.SurfaceGuiSizingMode.PixelsPerStud
		created.PixelsPerStud = 80
		created.LightInfluence = 0
		created.Parent = part
		surfaceGui = created
	end
	for _, child in ipairs((surfaceGui :: SurfaceGui):GetChildren()) do
		child:Destroy()
	end

	local label = Instance.new("TextLabel")
	label.Name = "Label"
	label.Size = UDim2.fromScale(1, 1)
	label.BackgroundColor3 = Color3.fromRGB(24, 28, 36)
	label.BackgroundTransparency = 0.08
	label.BorderSizePixel = 0
	label.Font = Enum.Font.GothamBold
	label.Text = "REINICIAR"
	label.TextColor3 = Color3.fromRGB(241, 245, 249)
	label.TextScaled = true
	label.TextWrapped = true
	label.Parent = surfaceGui

	local sizeConstraint = Instance.new("UITextSizeConstraint")
	sizeConstraint.MinTextSize = 12
	sizeConstraint.MaxTextSize = 24
	sizeConstraint.Parent = label

	local stroke = Instance.new("UIStroke")
	stroke.Color = Color3.fromRGB(71, 85, 105)
	stroke.Thickness = 1
	stroke.Parent = label

	local prompt = part:FindFirstChildOfClass("ProximityPrompt") :: ProximityPrompt?
	if not prompt then
		local createdPrompt = Instance.new("ProximityPrompt")
		createdPrompt.Parent = part
		prompt = createdPrompt
	end
	(prompt :: ProximityPrompt).ActionText = "Reiniciar tentativa"
	;(prompt :: ProximityPrompt).ObjectText = "Zerar progresso atual"
	;(prompt :: ProximityPrompt).MaxActivationDistance = 12
	;(prompt :: ProximityPrompt).HoldDuration = 0.4
	;(prompt :: ProximityPrompt).RequiresLineOfSight = false

	;(prompt :: ProximityPrompt).Triggered:Connect(function(player: Player)
		if isWithinInteractionDistance(player, part, (prompt :: ProximityPrompt).MaxActivationDistance) then
			processManualReset(player, false)
			task.spawn(animatePhysicalResetButton)
		end
	end)

	local clickDetector = part:FindFirstChildOfClass("ClickDetector") :: ClickDetector?
	if not clickDetector then
		local createdDetector = Instance.new("ClickDetector")
		createdDetector.Parent = part
		clickDetector = createdDetector
	end
	(clickDetector :: ClickDetector).MaxActivationDistance = 12
	;(clickDetector :: ClickDetector).MouseClick:Connect(function(player: Player)
		if isWithinInteractionDistance(player, part, (clickDetector :: ClickDetector).MaxActivationDistance) then
			processManualReset(player, false)
			task.spawn(animatePhysicalResetButton)
		end
	end)
end

local function findChildBasePart(parent: Instance?, childName: string): BasePart?
	local found = parent and parent:FindFirstChild(childName, true)
	if found and found:IsA("BasePart") then
		return found
	end
	return nil
end

local function configureMapPortals()
	local configuredModels: { [Instance]: boolean } = {}
	for _, root in ipairs(Workspace:GetDescendants()) do
		if root.Name == "Teleport Portals" and not configuredModels[root] then
			local portalRed = root:FindFirstChild("PortalRed")
			local portalBlue = root:FindFirstChild("PortalBlue")
			local redTeleport = findChildBasePart(portalRed, "RedTeleport")
			local blueTeleport = findChildBasePart(portalBlue, "BlueTeleport")
			local redArrive = findChildBasePart(portalRed, "RedArrive")
			local blueArrive = findChildBasePart(portalBlue, "BlueArrive")

			if redTeleport and blueTeleport and redArrive and blueArrive then
				configuredModels[root] = true
				for _, descendant in ipairs(root:GetDescendants()) do
					if descendant:IsA("Script") then
						descendant.Disabled = true
					end
				end

				local isRewardPortalPair = blueTeleport:GetAttribute(QuizConfig.REWARD_GATE_ATTRIBUTE) == true
				if isRewardPortalPair then
					blueArrive:SetAttribute("IsRewardDestination", nil)
					redArrive:SetAttribute("IsRewardDestination", true)
				else
					-- Desativa retorno reverso a partir do saguão para o final do Nível 10
					redTeleport.CanTouch = false
				end

				local function connectPortalTouch(source: BasePart, destination: BasePart, isExitingRewardArea: boolean)
					source.Touched:Connect(function(hit: BasePart)
						local character = hit:FindFirstAncestorOfClass("Model")
						local player = character and Players:GetPlayerFromCharacter(character)
						if not player or not character then
							return
						end
						local session = playerSessions[player]
						if not session then
							return
						end
						local rootPart = character:FindFirstChild("HumanoidRootPart") :: BasePart?
						local humanoid = character:FindFirstChildOfClass("Humanoid")
						if not rootPart or not humanoid or humanoid.Health <= 0 then
							return
						end
						if (rootPart.Position - source.Position).Magnitude > 16 then
							return
						end

						local now = os.clock()
						if (now - (session.PortalTouchClocks[source] or 0)) < PORTAL_TOUCH_COOLDOWN_SECONDS then
							return
						end
						if (now - session.LastPortalTeleportClock) < PORTAL_GLOBAL_COOLDOWN_SECONDS then
							return
						end
						session.PortalTouchClocks[source] = now

						local entersRewardArea = destination:GetAttribute("IsRewardDestination") == true
						if entersRewardArea then
							local hasRewardState = session.TutorialCompleted
								and (session.State == PLAYER_STATES.REWARD_UNLOCKED or session.State == PLAYER_STATES.IN_REWARD_AREA)
								and getPlayerScore(player) >= QuizConfig.REWARD_MIN_SCORE
							if not hasRewardState then
								notifyPlayer(
									player,
									string.format(
										"Alcance %d acertos para acessar a Área de Recompensas (%d/%d).",
										QuizConfig.REWARD_MIN_SCORE,
										getPlayerScore(player),
										QuizConfig.MAX_SCORE
									),
									COLOR_NOTICE_WARNING
								)
								return
							end

							session.LastPortalTeleportClock = now
							safePivotCharacter(player, destination.CFrame + Vector3.new(0, 4, 0))
							activateRewardAreaSession(player, session)
							return
						end

						session.LastPortalTeleportClock = now
						if isExitingRewardArea then
							if session.State == PLAYER_STATES.IN_REWARD_AREA then
								setPlayerState(player, session, PLAYER_STATES.REWARD_UNLOCKED)
							end
							safePivotCharacter(
								player,
								CFrame.lookAt(REWARD_RETURN_LOBBY_POSITION, REWARD_RETURN_LOOK_TARGET)
							)
						else
							safePivotCharacter(player, destination.CFrame + Vector3.new(0, 4, 0))
						end
					end)
				end

				connectPortalTouch(blueTeleport, redArrive, false)
				if isRewardPortalPair then
					connectPortalTouch(redTeleport, blueArrive, true)
				end
			end
		end
	end
end

-- ============================================================================
-- CICLO DE VIDA DO JOGADOR (INICIALIZAÇÃO E LIMPEZA DE MEMÓRIA)
-- ============================================================================

local function disconnectAll(connections: { RBXScriptConnection })
	for _, connection in ipairs(connections) do
		connection:Disconnect()
	end
	table.clear(connections)
end

local function bindCharacterLifecycle(player: Player, session: PlayerSession, character: Model)
	disconnectAll(session.CharacterConnections)
	applyCharacterCollisionGroup(player, session)

	local descendantConn = character.DescendantAdded:Connect(function(descendant: Instance)
		if descendant:IsA("BasePart") and playerSessions[player] == session then
			descendant.CollisionGroup = resolveCollisionGroupForState(session.State)
		end
	end)
	table.insert(session.CharacterConnections, descendantConn)

	if session.PendingRespawnReset then
		session.PendingRespawnReset = false
		if session.TutorialCompleted then
			task.delay(0.25, function()
				if player.Parent == Players and playerSessions[player] == session then
					teleportToMainLobby(player)
				end
			end)
		else
			task.delay(0.25, function()
				if player.Parent == Players and playerSessions[player] == session then
					teleportToTutorialRoom(player)
				end
			end)
		end
	elseif session.TutorialCompleted then
		-- SpawnLocation padrão fica na sala do tutorial; posiciona jogadores já aprovados no saguão principal
		task.delay(0.25, function()
			if player.Parent == Players and playerSessions[player] == session then
				if session.State == PLAYER_STATES.IN_REWARD_AREA then
					setPlayerState(player, session, PLAYER_STATES.REWARD_UNLOCKED)
				end
				teleportToMainLobby(player)
			end
		end)
	end
end

local function initializePlayer(player: Player)
	if playerSessions[player] then
		return
	end

	local session: PlayerSession = {
		State = PLAYER_STATES.SELECTING_MODE,
		TutorialCompleted = false,
		StartingSubject = nil,
		Progress = { Subject = "Geografia", Level = 0 },
		ActiveQuestion = nil,
		QuestionDecks = {},
		AttemptNumber = 0,
		AttemptStartTimestamp = nil,
		AttemptEndTimestamp = nil,
		AttemptTimerToken = 0,
		RewardQualifiedTeleportDone = false,
		RewardAreaEndTimestamp = nil,
		RewardTimerToken = 0,
		PendingRespawnReset = false,
		LastNotificationClock = 0,
		LastResetClock = 0,
		LastBarrierNoticeClock = 0,
		LastPortalTeleportClock = 0,
		PortalTouchClocks = {},
		Connections = {},
		CharacterConnections = {},
	}
	playerSessions[player] = session

	player:SetAttribute("PlayerState", PLAYER_STATES.SELECTING_MODE)
	player:SetAttribute("ModoComCronometro", nil)
	player:SetAttribute("AcertosQuiz", 0)
	player:SetAttribute("NumeroTentativaQuiz", 0)
	player:SetAttribute("TempoConclusaoQuiz", nil)
	player:SetAttribute("TempoRestanteCongeladoQuiz", nil)
	player:SetAttribute("InicioTentativaQuiz", nil)
	player:SetAttribute("FimTentativaQuiz", nil)
	player:SetAttribute("RewardAreaEndTimestamp", nil)
	updateLeaderstats(player, 0)

	local charAddedConn = player.CharacterAdded:Connect(function(character: Model)
		if playerSessions[player] == session then
			bindCharacterLifecycle(player, session, character)
		end
	end)
	table.insert(session.Connections, charAddedConn)

	if player.Character then
		bindCharacterLifecycle(player, session, player.Character)
	end

	syncClientSessionState(player, session)

	task.delay(0.6, function()
		if player.Parent == Players
			and playerSessions[player] == session
			and player:GetAttribute("ModoComCronometro") == nil
		then
			DefinirModoJogo:FireClient(player)
		end
	end)
end

local function cleanupPlayer(player: Player)
	local session = playerSessions[player]
	if not session then
		return
	end

	session.AttemptTimerToken += 1
	session.RewardTimerToken += 1
	disconnectAll(session.CharacterConnections)
	disconnectAll(session.Connections)
	table.clear(session.PortalTouchClocks)
	playerSessions[player] = nil
end

-- ============================================================================
-- INICIALIZAÇÃO DO SERVIÇO
-- ============================================================================

configureCollisionGroups()
ensureTutorialStructuralBarrier()
configureRewardGateAndBarrier()
configurePhysicalResetButton()
configureMapPortals()

for _, descendant in ipairs(Workspace:GetDescendants()) do
	if descendant:IsA("ProximityPrompt") then
		connectQuizPrompt(descendant)
	elseif descendant:IsA("BasePart") and parseDoorName(descendant.Name) ~= nil then
		connectPhysicalDoor(descendant)
	end
end

Workspace.DescendantAdded:Connect(function(descendant: Instance)
	if descendant:IsA("ProximityPrompt") then
		task.defer(connectQuizPrompt, descendant)
	elseif descendant:IsA("BasePart") and parseDoorName(descendant.Name) ~= nil then
		task.defer(connectPhysicalDoor, descendant)
	end
end)

Players.PlayerAdded:Connect(initializePlayer)
Players.PlayerRemoving:Connect(cleanupPlayer)
for _, existingPlayer in ipairs(Players:GetPlayers()) do
	initializePlayer(existingPlayer)
end
