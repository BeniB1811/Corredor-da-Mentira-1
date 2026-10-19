--!strict
export type Alternativa = {
	Texto: string,
	Falsa: boolean,
}

export type Questao = {
	Nome: string,
	Alternativas: { Alternativa },
}

export type NivelQuiz = {
	Dados: { Questao },
}

local function carregarModulo(nome: string)
	local filho = script:FindFirstChild(nome) or (script.Parent and script.Parent:FindFirstChild(nome))
	if filho then
		return require(filho)
	end
	warn('[QuizBancoQuestoes] Submódulo não encontrado:', nome)
	return {}
end

local Geo1 = carregarModulo('Geo_1_5')
local Geo2 = carregarModulo('Geo_6_10')
local His1 = carregarModulo('His_1_5')
local His2 = carregarModulo('His_6_10')

local QuizBancoQuestoes: { [string]: { [number]: NivelQuiz } } = {
	["Geografia"] = {},
	["História"] = {},
}

for lvl, dados in pairs(Geo1) do QuizBancoQuestoes["Geografia"][lvl] = dados end
for lvl, dados in pairs(Geo2) do QuizBancoQuestoes["Geografia"][lvl] = dados end
for lvl, dados in pairs(His1) do QuizBancoQuestoes["História"][lvl] = dados end
for lvl, dados in pairs(His2) do QuizBancoQuestoes["História"][lvl] = dados end
QuizBancoQuestoes["Historia"] = QuizBancoQuestoes["História"]

return QuizBancoQuestoes
