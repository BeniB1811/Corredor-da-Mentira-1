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

local QuizBancoQuestoes: { [string]: { [number]: NivelQuiz } } = {
 ["Geografia"] = {
 [0] = {
 Dados = {
 {
 Nome = "Brasil",
 Alternativas = {
 {Texto = "Conhecido pela culinária diversificada e seu famoso prato: Feijoada.", Falsa = false},
 {Texto = "Possui a maior floresta tropical úmida do mundo.", Falsa = false},
 {Texto = "Tem fortes ações vulcânicas em seu território atual.", Falsa = true}
 }
 }
 }
 },
 [1] = {
		Dados = {
			{
				Nome = "Alemanha",
				Alternativas = {
					{Texto = "É o país com a famosa rede de rodovias de alta velocidade chamada Autobahn.", Falsa = false},
					{Texto = "O primeiro livro impresso no Ocidente com tipos móveis (Bíblia de Gutenberg) foi feito lá.", Falsa = false},
					{Texto = "É o único país da Europa que não tem nenhuma saída para o mar.", Falsa = true},
				}
			},
			{
				Nome = "França",
				Alternativas = {
					{Texto = "A famosa Torre Eiffel fica localizada em Paris, sua capital.", Falsa = false},
					{Texto = "É um dos países mais visitados por turistas de todo o mundo.", Falsa = false},
					{Texto = "É o único país do continente europeu que possui duas capitais oficiais ao mesmo tempo.", Falsa = true},
				}
			},
			{
				Nome = "Espanha",
				Alternativas = {
					{Texto = "Está localizada na Península Ibérica, no sudoeste da Europa.", Falsa = false},
					{Texto = "É famosa pela animada festa tradicional de La Tomatina, com guerra de tomates.", Falsa = false},
					{Texto = "É o único país do planeta inteiro onde as pessoas falam a língua espanhola.", Falsa = true},
				}
			},
			{
				Nome = "Itália",
				Alternativas = {
					{Texto = "O antigo e histórico Coliseu fica localizado em sua capital, Roma.", Falsa = false},
					{Texto = "Seu mapa no globo terrestre tem o formato famoso de uma bota.", Falsa = false},
					{Texto = "Fica localizada no meio do Oceano Pacífico e não possui montanhas.", Falsa = true},
				}
			},
			{
				Nome = "Portugal",
				Alternativas = {
					{Texto = "Lisboa é a sua capital e foi o ponto de partida de grandes navegações históricas.", Falsa = false},
					{Texto = "O português é a língua oficial falada pelo seu povo.", Falsa = false},
					{Texto = "Faz fronteira terrestre direta com a França e com a Alemanha.", Falsa = true},
				}
			},
			{
				Nome = "Japão",
				Alternativas = {
					{Texto = "É um país insular formado por milhares de ilhas no Oceano Pacífico.", Falsa = false},
					{Texto = "O Monte Fuji é um vulcão sagrado e o ponto mais alto do país.", Falsa = false},
					{Texto = "Fica localizado no continente africano, bem perto do deserto do Saara.", Falsa = true},
				}
			},
			{
				Nome = "Estados Unidos",
				Alternativas = {
					{Texto = "Sua capital federal é a cidade de Washington, D.C.", Falsa = false},
					{Texto = "A famosa Estátua da Liberdade fica situada na cidade de Nova York.", Falsa = false},
					{Texto = "O país é composto por apenas dez estados em todo o seu território.", Falsa = true},
				}
			},
			{
				Nome = "Canadá",
				Alternativas = {
					{Texto = "É o segundo maior país do mundo em extensão territorial total.", Falsa = false},
					{Texto = "A folha de bordo vermelha é o símbolo nacional estampado em sua bandeira.", Falsa = false},
					{Texto = "Possui clima quente e desértico durante todos os meses do ano.", Falsa = true},
				}
			},
			{
				Nome = "México",
				Alternativas = {
					{Texto = "Abriga antigas e famosas pirâmides construídas pelos povos maia e asteca.", Falsa = false},
					{Texto = "Sua culinária tradicional inclui pratos típicos como tacos e guacamole.", Falsa = false},
					{Texto = "Está localizado no continente da América do Sul, ao lado do Brasil.", Falsa = true},
				}
			},
			{
				Nome = "Argentina",
				Alternativas = {
					{Texto = "É um país vizinho do Brasil situado na América do Sul.", Falsa = false},
					{Texto = "A região sul da Patagônia possui montanhas nevadas e geleiras grandiosas.", Falsa = false},
					{Texto = "O idioma oficial falado em todo o país é a língua portuguesa.", Falsa = true},
				}
			},
			{
				Nome = "Austrália",
				Alternativas = {
					{Texto = "É famosa por sua fauna única no mundo, abrigando cangurus e coalas.", Falsa = false},
					{Texto = "É ao mesmo tempo um país e a maior massa de terra do continente da Oceania.", Falsa = false},
					{Texto = "Seu território é totalmente congelado e coberto por geleiras permanentes.", Falsa = true},
				}
			},
			{
				Nome = "Egito",
				Alternativas = {
					{Texto = "O Rio Nilo, um dos mais longos do mundo, atravessa o país de ponta a ponta.", Falsa = false},
					{Texto = "Abriga as históricas e monumentais Pirâmides de Gizé e a Grande Esfinge.", Falsa = false},
					{Texto = "Está localizado no continente da Europa, fazendo fronteira com a Alemanha.", Falsa = true},
				}
			},
			{
				Nome = "China",
				Alternativas = {
					{Texto = "Abriga a Grande Muralha, uma imensa fortificação de pedra construída há séculos.", Falsa = false},
					{Texto = "O urso-panda gigante é um animal nativo de suas florestas de bambu.", Falsa = false},
					{Texto = "Sua capital oficial é a cidade de Tóquio.", Falsa = true},
				}
			},
			{
				Nome = "Reino Unido",
				Alternativas = {
					{Texto = "A torre do relógio Big Ben e o Palácio de Buckingham ficam em Londres.", Falsa = false},
					{Texto = "É formado pela união de Inglaterra, Escócia, País de Gales e Irlanda do Norte.", Falsa = false},
					{Texto = "Está conectado à África por uma grande ponte terrestre de rodovias.", Falsa = true},
				}
			},
			{
				Nome = "Rússia",
				Alternativas = {
					{Texto = "É o maior país do planeta Terra em extensão de área territorial.", Falsa = false},
					{Texto = "Seu vasto território se estende por dois continentes: a Europa e a Ásia.", Falsa = false},
					{Texto = "Por ser muito quente, nunca cai neve em nenhuma parte do seu território.", Falsa = true},
				}
			},
			{
				Nome = "Brasil",
				Alternativas = {
					{Texto = "É o maior país da América do Sul e o quinto maior do mundo em área.", Falsa = false},
					{Texto = "Abriga a maior parte da Floresta Amazônica e da bacia do Rio Amazonas.", Falsa = false},
					{Texto = "A atual capital federal do país é a cidade litorânea do Rio de Janeiro.", Falsa = true},
				}
			},
			{
				Nome = "Índia",
				Alternativas = {
					{Texto = "O imponente Taj Mahal é um dos monumentos mais famosos do mundo construído lá.", Falsa = false},
					{Texto = "O tigre-de-bengala é um dos animais mais representativos de suas florestas.", Falsa = false},
					{Texto = "Fica localizada na América Central, entre o Oceano Atlântico e o Caribe.", Falsa = true},
				}
			},
			{
				Nome = "Grécia",
				Alternativas = {
					{Texto = "Foi o berço do surgimento dos Jogos Olímpicos na antiguidade clássica.", Falsa = false},
					{Texto = "Possui milhares de ilhas banhadas pelo azul do Mar Mediterrâneo.", Falsa = false},
					{Texto = "Faz fronteira terrestre com o Brasil e divide a Bacia Amazônica.", Falsa = true},
				}
			},
			{
				Nome = "Chile",
				Alternativas = {
					{Texto = "É um país longo e estreito espremido entre o Oceano Pacífico e as montanhas.", Falsa = false},
					{Texto = "A Cordilheira dos Andes se estende ao longo de toda a sua fronteira oriental.", Falsa = false},
					{Texto = "Possui fronteira terrestre direta e contínua com o território do Brasil.", Falsa = true},
				}
			},
			{
				Nome = "Peru",
				Alternativas = {
					{Texto = "Abriga a antiga e impressionante cidade histórica de pedra de Machu Picchu.", Falsa = false},
					{Texto = "A civilização Inca desenvolveu seu grande império nessa região montanhosa.", Falsa = false},
					{Texto = "É um país completamente plano que não possui nenhuma montanha ou floresta.", Falsa = true},
				}
			},
			{
				Nome = "África do Sul",
				Alternativas = {
					{Texto = "Possui três capitais oficiais que dividem as funções do governo.", Falsa = false},
					{Texto = "Seus parques nacionais preservam animais como leões, girafas e rinocerontes.", Falsa = false},
					{Texto = "Fica localizada no hemisfério norte, bem próxima ao Polo Norte.", Falsa = true},
				}
			},
			{
				Nome = "Noruega",
				Alternativas = {
					{Texto = "É famosa no mundo inteiro por seus fiordes, vales profundos esculpidos por geleiras.", Falsa = false},
					{Texto = "No verão do extremo norte do país, o Sol quase não se põe durante a noite.", Falsa = false},
					{Texto = "Fica localizada bem no centro do deserto de areia do Saara.", Falsa = true},
				}
			},
			{
				Nome = "Suíça",
				Alternativas = {
					{Texto = "É famosa mundialmente pela cadeia de montanhas dos Alpes e seus queijos e chocolates.", Falsa = false},
					{Texto = "Não possui nenhuma costa banhada pelo mar, sendo cercada por outros países.", Falsa = false},
					{Texto = "É o país com a maior população do planeta Terra, com mais de dois bilhões de pessoas.", Falsa = true},
				}
			},
			{
				Nome = "Países Baixos (Holanda)",
				Alternativas = {
					{Texto = "É muito conhecida pelos tradicionais moinhos de vento e vastos campos de tulipas.", Falsa = false},
					{Texto = "Sua capital, Amsterdã, possui dezenas de canais de água navegáveis.", Falsa = false},
					{Texto = "É o país que possui as montanhas e picos mais altos do planeta Terra.", Falsa = true},
				}
			},
			{
				Nome = "Nova Zelândia",
				Alternativas = {
					{Texto = "É formada principalmente por duas grandes ilhas, a Ilha Norte e a Ilha Sul.", Falsa = false},
					{Texto = "O kiwi é uma curiosa ave símbolo nacional que não voa e tem bico longo.", Falsa = false},
					{Texto = "Faz fronteira terrestre direta com os Estados Unidos e com o Canadá.", Falsa = true},
				}
			},
			{
				Nome = "Coreia do Sul",
				Alternativas = {
					{Texto = "Sua vibrante capital é a moderna cidade metropolitana de Seul.", Falsa = false},
					{Texto = "É uma potência mundial na criação de tecnologias, celulares e jogos eletrônicos.", Falsa = false},
					{Texto = "Fica situada no continente americano, logo abaixo da linha do Equador.", Falsa = true},
				}
			},
			{
				Nome = "Colômbia",
				Alternativas = {
					{Texto = "É um dos maiores e mais famosos produtores de café de qualidade do planeta.", Falsa = false},
					{Texto = "Tem litoral banhado tanto pelo Oceano Pacífico quanto pelo Mar do Caribe.", Falsa = false},
					{Texto = "A moeda oficial utilizada em todas as suas compras é o Euro.", Falsa = true},
				}
			},
			{
				Nome = "Uruguai",
				Alternativas = {
					{Texto = "Faz fronteira ao norte diretamente com o estado brasileiro do Rio Grande do Sul.", Falsa = false},
					{Texto = "Montevidéu é a capital e a cidade mais populosa do território uruguaio.", Falsa = false},
					{Texto = "Possui vulcões gigantescos que entram em erupção de lava todos os anos.", Falsa = true},
				}
			},
			{
				Nome = "Arábia Saudita",
				Alternativas = {
					{Texto = "Grande parte do seu território é ocupada por desertos quentes de areia e dunas.", Falsa = false},
					{Texto = "É um dos maiores países produtores e exportadores de petróleo do planeta.", Falsa = false},
					{Texto = "Possui centenas de rios naturais de água doce caudalosos que nunca secam.", Falsa = true},
				}
			},
			{
				Nome = "Turquia",
				Alternativas = {
					{Texto = "A histórica cidade de Istambul possui uma parte na Europa e outra na Ásia.", Falsa = false},
					{Texto = "É famosa por seus bazares cheios de especiarias coloridas e tapetes artesanais.", Falsa = false},
					{Texto = "Fica situada no continente gelado da Antártida, rodeada de blocos de gelo.", Falsa = true},
				}
			},
			{
				Nome = "Madagascar",
				Alternativas = {
					{Texto = "É uma enorme ilha localizada no Oceano Índico, próxima à costa sudeste da África.", Falsa = false},
					{Texto = "É o lar natural de dezenas de espécies de lêmures e árvores gigantes chamadas baobás.", Falsa = false},
					{Texto = "É uma ilha coberta por neve constante localizada no Círculo Polar Ártico.", Falsa = true},
				}
			},
			{
				Nome = "Irlanda",
				Alternativas = {
					{Texto = "É apelidada de Ilha Esmeralda devido à sua paisagem verdejante de campos e colinas.", Falsa = false},
					{Texto = "O trevo de três folhas é um dos símbolos tradicionais mais populares do país.", Falsa = false},
					{Texto = "Está localizada no meio da América Central, cercada por florestas tropicais secas.", Falsa = true},
				}
			},
			{
				Nome = "Suécia",
				Alternativas = {
					{Texto = "É um país nórdico na Europa conhecido por suas florestas e milhares de lagos limpos.", Falsa = false},
					{Texto = "Estocolmo é a sua capital, construída sobre várias ilhas conectadas por pontes.", Falsa = false},
					{Texto = "Possui clima de selva tropical com temperaturas que chegam a 50 graus no inverno.", Falsa = true},
				}
			},
			{
				Nome = "Finlândia",
				Alternativas = {
					{Texto = "A região da Lapônia, no norte do país, é famosa mundialmente como a terra do Papai Noel.", Falsa = false},
					{Texto = "Possui dezenas de milhares de lagos de água doce cristalina espalhados pelo território.", Falsa = false},
					{Texto = "Fica localizada bem no centro do deserto da Austrália.", Falsa = true},
				}
			},
			{
				Nome = "Dinamarca",
				Alternativas = {
					{Texto = "Copenhague é a sua bela capital conhecida por ciclovias e canais à beira-mar.", Falsa = false},
					{Texto = "É a terra onde nasceram os famosos brinquedos de montar de blocos de Lego.", Falsa = false},
					{Texto = "Faz divisa terrestre direta com a Argentina e o Uruguai na América do Sul.", Falsa = true},
				}
			},
			{
				Nome = "Islândia",
				Alternativas = {
					{Texto = "É uma ilha no Atlântico Norte famosa pela mistura de geleiras frias e vulcões ativos.", Falsa = false},
					{Texto = "Possui gêiseres impressionantes, que são fontes naturais de água quente que jorram do solo.", Falsa = false},
					{Texto = "É o país mais seco e arenoso do mundo, sem nenhuma gota de gelo em seu solo.", Falsa = true},
				}
			},
			{
				Nome = "Marrocos",
				Alternativas = {
					{Texto = "Fica localizado no norte da África, bem pertinho do continente europeu.", Falsa = false},
					{Texto = "Possui cidades históricas conhecidas por construções de barro e mercados de temperos.", Falsa = false},
					{Texto = "Sua capital nacional é a cidade sul-americana de Buenos Aires.", Falsa = true},
				}
			},
			{
				Nome = "Tailândia",
				Alternativas = {
					{Texto = "É um país do Sudeste Asiático famoso por templos budistas dourados e praias tropicais.", Falsa = false},
					{Texto = "O elefante-asiático é considerado um animal sagrado e histórico na cultura tailandesa.", Falsa = false},
					{Texto = "Faz fronteira terrestre com os Estados Unidos e o Canadá.", Falsa = true},
				}
			},
			{
				Nome = "Quênia",
				Alternativas = {
					{Texto = "Suas savanas abrigam grandes migrações de gnus, zebras e animais selvagens.", Falsa = false},
					{Texto = "Fica localizado na porção oriental do continente africano, banhado pelo Oceano Índico.", Falsa = false},
					{Texto = "O solo do país fica completamente congelado e coberto de gelo o ano todo.", Falsa = true},
				}
			},
			{
				Nome = "Equador",
				Alternativas = {
					{Texto = "Seu nome faz homenagem à Linha do Equador imaginária que passa pelo seu território.", Falsa = false},
					{Texto = "As famosas Ilhas Galápagos, ricas em tartarugas gigantes, pertencem ao seu país.", Falsa = false},
					{Texto = "É o maior país do mundo em área territorial, superando a Rússia e a China.", Falsa = true},
				}
			},
			{
				Nome = "Bolívia",
				Alternativas = {
					{Texto = "Abriga o impressionante Salar de Uyuni, o maior deserto de sal do planeta Terra.", Falsa = false},
					{Texto = "É um país da América do Sul que não possui saída costeira para nenhum oceano.", Falsa = false},
					{Texto = "Possui milhares de quilômetros de praias tropicais banhadas pelo Oceano Atlântico.", Falsa = true},
				}
			},
			{
				Nome = "Paraguai",
				Alternativas = {
					{Texto = "Divide com o Brasil a Usina Hidrelétrica de Itaipu, uma das maiores do planeta.", Falsa = false},
					{Texto = "Assim como a Bolívia, é um país sul-americano que não tem saída para o mar.", Falsa = false},
					{Texto = "O japonês é a única língua oficial falada por todos os seus habitantes.", Falsa = true},
				}
			},
			{
				Nome = "Panamá",
				Alternativas = {
					{Texto = "Abriga o Canal do Panamá, que liga diretamente os oceanos Atlântico e Pacífico.", Falsa = false},
					{Texto = "É uma faixa estreita de terra que une a América do Norte à América do Sul.", Falsa = false},
					{Texto = "Fica localizado no continente asiático, entre a China e o Japão.", Falsa = true},
				}
			},
			{
				Nome = "Cuba",
				Alternativas = {
					{Texto = "É a maior ilha localizada nas águas quentes do Mar do Caribe.", Falsa = false},
					{Texto = "Havana é a sua capital histórica, conhecida pela arquitetura colonial e carros clássicos.", Falsa = false},
					{Texto = "Fica localizada no meio do Oceano Índico, ao lado da ilha de Madagascar.", Falsa = true},
				}
			},
			{
				Nome = "Jamaica",
				Alternativas = {
					{Texto = "É uma ilha caribenha famosa no mundo por sua rica cultura musical e praias claras.", Falsa = false},
					{Texto = "O velocista Usain Bolt, o homem mais rápido do mundo, nasceu nesse país.", Falsa = false},
					{Texto = "É o país mais frio do continente americano, com tempestades de neve diárias.", Falsa = true},
				}
			},
			{
				Nome = "Áustria",
				Alternativas = {
					{Texto = "Fica no coração da Europa e é cercada pelas imponentes montanhas dos Alpes.", Falsa = false},
					{Texto = "Viena, sua capital, é mundialmente reconhecida pela história da música clássica e palácios.", Falsa = false},
					{Texto = "É uma ilha no Caribe cercada por recifes de corais e coqueiros tropicais.", Falsa = true},
				}
			},
			{
				Nome = "Bélgica",
				Alternativas = {
					{Texto = "É famosa mundialmente pela produção artesanal de chocolates finos e deliciosos waffles.", Falsa = false},
					{Texto = "Bruxelas é a capital do país e abriga a sede da União Europeia.", Falsa = false},
					{Texto = "A única língua falada em todo o país é o russo moderno.", Falsa = true},
				}
			},
			{
				Nome = "Polônia",
				Alternativas = {
					{Texto = "É um país da Europa Central com litoral banhado pelas águas do Mar Báltico.", Falsa = false},
					{Texto = "Sua capital é Varsóvia, uma cidade que reconstruiu seus belos monumentos históricos.", Falsa = false},
					{Texto = "Divide fronteira terrestre contínua com a Austrália e o Japão.", Falsa = true},
				}
			},
			{
				Nome = "Filipinas",
				Alternativas = {
					{Texto = "É um arquipélago tropical composto por mais de 7 mil ilhas no Oceano Pacífico.", Falsa = false},
					{Texto = "Manila é a sua movimentada capital com grande herança histórica espanhola e asiática.", Falsa = false},
					{Texto = "Fica localizada dentro do Círculo Polar Ártico, coberta por icebergs.", Falsa = true},
				}
			},
			{
				Nome = "Costa Rica",
				Alternativas = {
					{Texto = "É famosa por suas florestas tropicais preservadas e riquíssima biodiversidade de animais.", Falsa = false},
					{Texto = "Está localizada na América Central e possui praias no Pacífico e no Caribe.", Falsa = false},
					{Texto = "É um deserto de areia seco onde não cresce nenhuma árvore ou planta.", Falsa = true},
				}
			}
		}
	},
 [2] = {
		Dados = {
			{
				Nome = "Os Vulcões",
				Alternativas = {
					{Texto = "São aberturas na crosta terrestre por onde sobem magma quente, cinzas e gases.", Falsa = false},
					{Texto = "Quando o magma atinge a superfície da Terra e escorre, passa a ser chamado de lava.", Falsa = false},
					{Texto = "Quando entram em erupção, os vulcões cospem blocos maciços de gelo congelado.", Falsa = true},
				}
			},
			{
				Nome = "Círculo de Fogo do Pacífico",
				Alternativas = {
					{Texto = "É uma vasta região ao redor do Oceano Pacífico com grande concentração de vulcões ativos.", Falsa = false},
					{Texto = "Nessa área ocorrem a maioria dos terremotos mais intensos registrados no planeta Terra.", Falsa = false},
					{Texto = "É uma aliança gigante de metal dourado que flutua suspensa na atmosfera terrestre.", Falsa = true},
				}
			},
			{
				Nome = "Os Terremotos",
				Alternativas = {
					{Texto = "São tremores da crosta provocados pelo movimento brusco e atrito entre placas tectônicas.", Falsa = false},
					{Texto = "A intensidade e energia liberada pelos terremotos costumam ser medidas na escala Richter.", Falsa = false},
					{Texto = "Acontecem exclusivamente quando rebanhos de elefantes pulam ao mesmo tempo no chão.", Falsa = true},
				}
			},
			{
				Nome = "Os Tsunamis",
				Alternativas = {
					{Texto = "São ondas gigantescas formadas no oceano após terremotos submarinos ou erupções vulcânicas.", Falsa = false},
					{Texto = "Podem atravessar oceanos inteiros em alta velocidade e invadir cidades litorâneas.", Falsa = false},
					{Texto = "São pequenas bolhas de sabão coloridas que flutuam calmamente na beira da praia.", Falsa = true},
				}
			},
			{
				Nome = "Placas Tectônicas",
				Alternativas = {
					{Texto = "São grandes blocos rochosos semirrígidos que formam a camada sólida externa da Terra.", Falsa = false},
					{Texto = "Movem-se muito lentamente ao longo de milhões de anos sobre o manto pastoso do planeta.", Falsa = false},
					{Texto = "São folhas finas de aço parafusadas no fundo do mar por operários humanos.", Falsa = true},
				}
			},
			{
				Nome = "O Rio Amazonas",
				Alternativas = {
					{Texto = "É o rio mais caudaloso do planeta Terra, despejando o maior volume de água doce no oceano.", Falsa = false},
					{Texto = "Nasce na Cordilheira dos Andes e corre em direção ao leste até desaguar no Oceano Atlântico.", Falsa = false},
					{Texto = "É um pequeno riacho de água salgada localizado no centro do continente europeu.", Falsa = true},
				}
			},
			{
				Nome = "O Rio Nilo",
				Alternativas = {
					{Texto = "É um dos rios mais compridos e históricos do mundo, atravessando vários países da África.", Falsa = false},
					{Texto = "Suas águas deságuam no Mar Mediterrâneo, formando um grande e fértil delta de terra.", Falsa = false},
					{Texto = "É um rio que seca por completo todos os domingos e segundas-feiras do ano.", Falsa = true},
				}
			},
			{
				Nome = "Cataratas do Iguaçu",
				Alternativas = {
					{Texto = "São um conjunto impressionante de centenas de quedas d'água entre o Brasil e a Argentina.", Falsa = false},
					{Texto = "Ficam localizadas dentro do Parque Nacional do Iguaçu, cercadas por rica mata atlântica.", Falsa = false},
					{Texto = "Ficam localizadas no meio das dunas de areia seca do deserto do Saara.", Falsa = true},
				}
			},
			{
				Nome = "Cataratas do Niágara",
				Alternativas = {
					{Texto = "Ficam situadas na fronteira entre o estado de Nova York (EUA) e a província de Ontário (Canadá).", Falsa = false},
					{Texto = "Possuem grande volume d'água e são famosas no mundo inteiro por passeios de barco.", Falsa = false},
					{Texto = "Suas águas correm ao contrário, subindo pelas montanhas até atingir as nuvens do céu.", Falsa = true},
				}
			},
			{
				Nome = "Cordilheira dos Andes",
				Alternativas = {
					{Texto = "É a mais longa cadeia de montanhas contínua do planeta, estendendo-se por toda a América do Sul.", Falsa = false},
					{Texto = "Abriga picos nevados imponentes como o monte Aconcágua e lagos em grandes altitudes.", Falsa = false},
					{Texto = "Fica situada bem no centro plano do continente insular da Austrália.", Falsa = true},
				}
			},
			{
				Nome = "Cordilheira do Himalaia",
				Alternativas = {
					{Texto = "É a cadeia montanhosa mais alta do planeta Terra, situada no continente da Ásia.", Falsa = false},
					{Texto = "Surgiu do choque constante entre a placa tectônica da Índia e a placa da Eurásia.", Falsa = false},
					{Texto = "É uma vasta planície costeira ao nível do mar coberta por praias quentes.", Falsa = true},
				}
			},
			{
				Nome = "O Monte Everest",
				Alternativas = {
					{Texto = "É a montanha com a maior altitude da Terra, com seu pico a mais de 8.800 metros do mar.", Falsa = false},
					{Texto = "Fica localizado na fronteira entre o Nepal e a China, enfrentando nevascas rigorosas.", Falsa = false},
					{Texto = "Possui piscinas térmicas naturais de água morna onde banhistas nadam no seu topo.", Falsa = true},
				}
			},
			{
				Nome = "O Grand Canyon",
				Alternativas = {
					{Texto = "É um imenso desfiladeiro esculpido ao longo de milhões de anos pelas águas do Rio Colorado.", Falsa = false},
					{Texto = "Suas encostas exibem camadas coloridas de rochas antigas no estado do Arizona, nos EUA.", Falsa = false},
					{Texto = "Foi escavado por pás de plástico de brinquedo durante as férias de uma única semana.", Falsa = true},
				}
			},
			{
				Nome = "Deserto do Saara",
				Alternativas = {
					{Texto = "É o maior deserto quente do planeta Terra, cobrindo grande parte do norte da África.", Falsa = false},
					{Texto = "Apresenta dias extremamente quentes e noites com temperaturas consideravelmente baixas.", Falsa = false},
					{Texto = "É uma floresta densa e úmida onde cai chuva torrencial todas as manhãs do ano.", Falsa = true},
				}
			},
			{
				Nome = "Deserto do Atacama",
				Alternativas = {
					{Texto = "É considerado o deserto não polar mais árido e seco de todo o planeta Terra.", Falsa = false},
					{Texto = "Seu céu limpo e seco faz dele um dos melhores lugares do mundo para observar estrelas.", Falsa = false},
					{Texto = "Sofre com tempestades diárias de chuva que inundam todas as suas cidades.", Falsa = true},
				}
			},
			{
				Nome = "Os Oásis",
				Alternativas = {
					{Texto = "São áreas férteis com fontes naturais de água doce que brotam no meio de regiões desérticas.", Falsa = false},
					{Texto = "Permitem o cultivo de palmeiras como tamareiras e servem de abrigo para viajantes e animais.", Falsa = false},
					{Texto = "São ilusões mágicas que desaparecem no ar quando qualquer pessoa se aproxima deles.", Falsa = true},
				}
			},
			{
				Nome = "Floresta Amazônica",
				Alternativas = {
					{Texto = "É a maior floresta tropical do mundo, abrigando milhões de espécies de plantas e animais.", Falsa = false},
					{Texto = "Ajuda a regular as chuvas de grande parte da América do Sul com seus rios voadores de vapor.", Falsa = false},
					{Texto = "É formada exclusivamente por pinheiros finos cobertos por camadas de neve o ano inteiro.", Falsa = true},
				}
			},
			{
				Nome = "Bioma Tundra",
				Alternativas = {
					{Texto = "É um bioma muito frio localizado nas regiões polares do extremo norte do planeta Terra.", Falsa = false},
					{Texto = "Possui vegetação rasteira de musgos e liquens porque o solo profundo fica sempre congelado.", Falsa = false},
					{Texto = "É famoso no mundo por suas plantações naturais de bananas, melancias e coqueiros.", Falsa = true},
				}
			},
			{
				Nome = "Bioma Taiga (Floresta Boreal)",
				Alternativas = {
					{Texto = "É uma vasta floresta de coníferas e pinheiros adaptados a invernos longos e rigorosos.", Falsa = false},
					{Texto = "Forma um grande cinturão verde em países do hemisfério norte como Canadá e Rússia.", Falsa = false},
					{Texto = "É a região mais quente da Terra onde a temperatura nunca cai abaixo de 40 graus.", Falsa = true},
				}
			},
			{
				Nome = "As Savanas",
				Alternativas = {
					{Texto = "São biomas formados por gramíneas e árvores esparsas de troncos tortuosos e resistentes.", Falsa = false},
					{Texto = "Na África, abrigam grandes manadas de animais herbívoros como zebras, gnus e girafas.", Falsa = false},
					{Texto = "Ficam completamente submersas sob cem metros de água do mar durante todos os meses.", Falsa = true},
				}
			},
			{
				Nome = "O Cerrado Brasileiro",
				Alternativas = {
					{Texto = "É a savana mais rica em biodiversidade do mundo, situada principalmente no centro do Brasil.", Falsa = false},
					{Texto = "É conhecido como o berço das águas por abrigar as nascentes de importantes rios brasileiros.", Falsa = false},
					{Texto = "Fica congelado sob dez metros de neve durante todas as estações do ano.", Falsa = true},
				}
			},
			{
				Nome = "A Caatinga",
				Alternativas = {
					{Texto = "É um bioma que só existe no Brasil, cobrindo grande parte do interior da Região Nordeste.", Falsa = false},
					{Texto = "Plantas como o mandacaru armazenam água em seu caule para sobreviver a períodos de seca.", Falsa = false},
					{Texto = "É uma floresta pantanosa e gelada onde moram pinguins e focas polares.", Falsa = true},
				}
			},
			{
				Nome = "O Pantanal",
				Alternativas = {
					{Texto = "É a maior planície de inundação contínua do planeta, localizada no Centro-Oeste brasileiro.", Falsa = false},
					{Texto = "Na época das cheias, grande parte das terras fica coberta por águas rasas repletas de peixes.", Falsa = false},
					{Texto = "Fica situado no cume das montanhas mais altas da Cordilheira do Himalaia.", Falsa = true},
				}
			},
			{
				Nome = "A Mata Atlântica",
				Alternativas = {
					{Texto = "É uma floresta tropical brasileira que originalmente acompanhava quase todo o litoral do país.", Falsa = false},
					{Texto = "Abriga espécies raras e ameaçadas de extinção como o mico-leão-dourado e o pau-brasil.", Falsa = false},
					{Texto = "É um deserto seco de dunas de areia onde não cresce nenhuma árvore nativa.", Falsa = true},
				}
			},
			{
				Nome = "Os Manguezais",
				Alternativas = {
					{Texto = "São ecossistemas costeiros que funcionam como berçários naturais para caranguejos e peixes.", Falsa = false},
					{Texto = "As árvores do mangue possuem raízes aéreas que se fixam em solos lodosos e salobros.", Falsa = false},
					{Texto = "Ficam situados nos topos pontudos de montanhas com neves eternas.", Falsa = true},
				}
			},
			{
				Nome = "Recifes de Corais",
				Alternativas = {
					{Texto = "São estruturas submarinas coloridas formadas por colônias de pequenos animais marinhos.", Falsa = false},
					{Texto = "Fornecem abrigo e alimento para milhares de espécies de peixes, tartarugas e polvos.", Falsa = false},
					{Texto = "São blocos de plástico descartável fabricados em fábricas de brinquedos modernos.", Falsa = true},
				}
			},
			{
				Nome = "Grande Barreira de Corais",
				Alternativas = {
					{Texto = "É a maior estrutura construída por seres vivos do planeta, localizada no litoral da Austrália.", Falsa = false},
					{Texto = "É tão imensa e vistosa que pode ser vista por astronautas a partir do espaço sideral.", Falsa = false},
					{Texto = "É uma muralha de cimento e tijolos construída por humanos para impedir a maré.", Falsa = true},
				}
			},
			{
				Nome = "O Mar Morto",
				Alternativas = {
					{Texto = "É um grande lago no Oriente Médio com concentração de sal quase dez vezes maior que o oceano.", Falsa = false},
					{Texto = "A alta densidade da água muito salgada faz as pessoas boiarem naturalmente sem afundar.", Falsa = false},
					{Texto = "É o oceano mais profundo da Terra onde vivem tubarões gigantes e baleias assassinas.", Falsa = true},
				}
			},
			{
				Nome = "O Mar Mediterrâneo",
				Alternativas = {
					{Texto = "É um mar quase fechado que fica posicionado entre o sul da Europa e o norte da África.", Falsa = false},
					{Texto = "Está ligado ao Oceano Atlântico por meio da passagem estreita do Estreito de Gibraltar.", Falsa = false},
					{Texto = "Fica localizado no centro da Antártida, completamente coberto por ursos polares.", Falsa = true},
				}
			},
			{
				Nome = "O Ciclo da Água",
				Alternativas = {
					{Texto = "A água líquida dos rios e mares evapora com o calor do Sol e sobe para o ar como vapor.", Falsa = false},
					{Texto = "Nas alturas mais frias, o vapor condensa formando nuvens que voltam como chuva para o solo.", Falsa = false},
					{Texto = "Toda a água da chuva no planeta vem de torneiras gigantes instaladas na superfície da Lua.", Falsa = true},
				}
			},
			{
				Nome = "A Evaporação",
				Alternativas = {
					{Texto = "É a transformação da água líquida em vapor de água invisível provocada pelo aumento do calor.", Falsa = false},
					{Texto = "Ocorre constantemente na superfície dos oceanos, lagos, rios e até na roupa do varal.", Falsa = false},
					{Texto = "Ocorre quando a água da jarra é colocada no congelador e vira cubos de gelo sólido.", Falsa = true},
				}
			},
			{
				Nome = "A Condensação",
				Alternativas = {
					{Texto = "Ocorre quando o vapor de água invisível se resfria e volta a ser gotículas líquidas de água.", Falsa = false},
					{Texto = "É o processo físico fundamental responsável pelo surgimento e crescimento das nuvens no céu.", Falsa = false},
					{Texto = "Faz a água líquida ferver instantaneamente a mil graus como chamas de fogo.", Falsa = true},
				}
			},
			{
				Nome = "A Precipitação",
				Alternativas = {
					{Texto = "É o retorno da água das nuvens para a superfície da Terra na forma líquida de chuva.", Falsa = false},
					{Texto = "Quando a temperatura do ar nas nuvens está muito baixa, a água pode cair como neve ou granizo.", Falsa = false},
					{Texto = "É quando a água sobe das plantas direto para o espaço sem passar pelo ar.", Falsa = true},
				}
			},
			{
				Nome = "O Lençol Freático",
				Alternativas = {
					{Texto = "É uma camada subterrânea onde a água das chuvas fica acumulada entre grãos de terra e rochas.", Falsa = false},
					{Texto = "Alimenta nascentes de rios naturais e permite a perfuração de poços de água doce límpida.", Falsa = false},
					{Texto = "É um lençol de tecido de algodão estendido sobre as árvores para proteger da poeira.", Falsa = true},
				}
			},
			{
				Nome = "Geleiras e Icebergs",
				Alternativas = {
					{Texto = "Geleiras são massas espessas de neve acumulada que se movem muito lentamente pela montanha.", Falsa = false},
					{Texto = "A maior parte do volume e tamanho de um iceberg flutuante fica escondida embaixo da água.", Falsa = false},
					{Texto = "Os icebergs são formados por blocos de água doce fervente que soltam fumaça quente.", Falsa = true},
				}
			},
			{
				Nome = "O Fenômeno do Arco-Íris",
				Alternativas = {
					{Texto = "Surge quando raios de luz solar atravessam gotículas de chuva suspensas no ar da atmosfera.", Falsa = false},
					{Texto = "A refração e reflexão da luz decompõem o raio solar em uma faixa de sete cores principais.", Falsa = false},
					{Texto = "Só consegue aparecer no meio da noite escura sem nenhuma gota de umidade no ar.", Falsa = true},
				}
			},
			{
				Nome = "A Aurora Boreal",
				Alternativas = {
					{Texto = "É um espetáculo de luzes brilhantes e onduladas que surgem no céu perto do Polo Norte.", Falsa = false},
					{Texto = "Ocorre pelo choque de partículas carregadas do vento solar com gases da alta atmosfera.", Falsa = false},
					{Texto = "É produzida por holofotes elétricos ligados em gramados de campos de futebol à noite.", Falsa = true},
				}
			},
			{
				Nome = "Furacões e Tufões",
				Alternativas = {
					{Texto = "São imensos sistemas de tempestades giratórias com ventos muito velozes e fortes chuvas.", Falsa = false},
					{Texto = "Geralmente se formam sobre águas oceânicas mornas em regiões de clima tropical e subtropical.", Falsa = false},
					{Texto = "Formam-se espontaneamente dentro de garrafas plásticas de refrigerante tampadas na gaveta.", Falsa = true},
				}
			},
			{
				Nome = "Os Tornados",
				Alternativas = {
					{Texto = "São colunas de ar giratórias com formato de funil que descem de nuvens escuras até tocar o solo.", Falsa = false},
					{Texto = "Apesar de terem tamanho menor que furacões, seus ventos pontuais podem ser extremamente destrutivos.", Falsa = false},
					{Texto = "São brisas leves e calmas que não conseguem mover nem uma folha seca de árvore.", Falsa = true},
				}
			},
			{
				Nome = "As Marés Oceânicas",
				Alternativas = {
					{Texto = "São movimentos diários de subida e descida do nível das águas do mar ao longo das praias.", Falsa = false},
					{Texto = "Acontecem principalmente pela atração gravitacional que a Lua e o Sol exercem sobre a Terra.", Falsa = false},
					{Texto = "Acontecem porque cardumes de sardinhas começam a bater suas nadadeiras todas juntas.", Falsa = true},
				}
			},
			{
				Nome = "Camadas da Terra",
				Alternativas = {
					{Texto = "O planeta é formado pela Crosta rochosa na superfície, pelo Manto quente e pelo Núcleo no centro.", Falsa = false},
					{Texto = "A crosta terrestre onde vivemos é a camada mais fina de todas as três divisões do planeta.", Falsa = false},
					{Texto = "O interior da Terra é completamente oco e recheado de queijo derretido no centro.", Falsa = true},
				}
			},
			{
				Nome = "O Núcleo da Terra",
				Alternativas = {
					{Texto = "Fica localizado no centro do nosso planeta, formado predominantemente por ferro e níquel.", Falsa = false},
					{Texto = "Possui temperaturas e pressões altíssimas que podem atingir níveis comparáveis à superfície do Sol.", Falsa = false},
					{Texto = "É uma enorme bola de neve congelada com temperatura de dez graus negativos.", Falsa = true},
				}
			},
			{
				Nome = "Rochas e Minerais",
				Alternativas = {
					{Texto = "As rochas são formadas pela união natural e sólida de um ou mais tipos de minerais.", Falsa = false},
					{Texto = "Dividem-se em rochas magmáticas (vulcânicas), sedimentares (camadas) e metamórficas.", Falsa = false},
					{Texto = "Nascem como maçãs penduradas em galhos de árvores frutíferas no quintal.", Falsa = true},
				}
			},
			{
				Nome = "Estalactites e Estalagmites",
				Alternativas = {
					{Texto = "São formações rochosas pontudas encontradas no interior de cavernas de rochas calcárias.", Falsa = false},
					{Texto = "As estalactites crescem de cima para baixo no teto, e as estalagmites sobem a partir do chão.", Falsa = false},
					{Texto = "São esculturas talhadas em madeira verde por famílias de castores selvagens.", Falsa = true},
				}
			},
			{
				Nome = "Os Cânions",
				Alternativas = {
					{Texto = "São vales profundos com encostas de rocha quase verticais formados pela erosão de rios antigos.", Falsa = false},
					{Texto = "O Parque Nacional de Aparados da Serra abriga cânions gigantescos no sul do Brasil.", Falsa = false},
					{Texto = "Surgem da noite para o dia após uma garoa passageira de cinco minutos no campo.", Falsa = true},
				}
			},
			{
				Nome = "Planícies e Planaltos",
				Alternativas = {
					{Texto = "Planícies são terrenos planos de baixa altitude onde predomina o depósito de sedimentos.", Falsa = false},
					{Texto = "Planaltos são terrenos mais elevados onde o desgaste e a erosão superam o acúmulo de terra.", Falsa = false},
					{Texto = "As montanhas mais altas da Terra têm altitudes menores que as praias de areia do mar.", Falsa = true},
				}
			},
			{
				Nome = "Aquífero Guarani",
				Alternativas = {
					{Texto = "É um dos maiores reservatórios naturais de água doce subterrânea de todo o planeta Terra.", Falsa = false},
					{Texto = "Estende-se por baixo do solo de vários estados do Brasil, do Paraguai, Uruguai e Argentina.", Falsa = false},
					{Texto = "É uma enorme poça de água salgada localizada no topo de um vulcão na Austrália.", Falsa = true},
				}
			},
			{
				Nome = "Erosão do Solo",
				Alternativas = {
					{Texto = "É o processo natural de desgaste e transporte de terra e rochas causado por vento e chuvas.", Falsa = false},
					{Texto = "O desmatamento acelera a erosão porque as raízes das plantas deixam de segurar a terra firme.", Falsa = false},
					{Texto = "É a criação mágica e espontânea de barras de ouro puro no meio de hortas caseiras.", Falsa = true},
				}
			},
			{
				Nome = "Mata Ciliar e Rios",
				Alternativas = {
					{Texto = "É a vegetação nativa que cresce nas margens de rios e córregos, parecida com cílios nos olhos.", Falsa = false},
					{Texto = "Protege os rios contra o assoreamento de terra e preserva a pureza da água para os animais.", Falsa = false},
					{Texto = "Jogar lixo e pneus velhos nas margens ajuda a alimentar as plantas aquáticas do rio.", Falsa = true},
				}
			},
			{
				Nome = "Polo Norte e Polo Sul",
				Alternativas = {
					{Texto = "O Polo Norte é formado por gelo flutuante no Oceano Ártico, sem uma massa de terra por baixo.", Falsa = false},
					{Texto = "O Polo Sul é um continente de rochas (a Antártida) coberto por uma espessa camada de geleiras.", Falsa = false},
					{Texto = "Ambos os polos possuem praias de areia dourada quente onde crescem coqueirais tropicais.", Falsa = true},
				}
			}
		}
	},
 [3] = {
 Dados = {
 {
 Nome = "Noruega",
 Alternativas = {
 {Texto = "Possui a segunda maior linha costa do mundo considerando seus fiordes.", Falsa = false},
 {Texto = "É o país com mais ouros nos Jogos Olímpicos de Inverno.", Falsa = false},
 {Texto = "Em Oslo, o sol nunca se põe durante todo o ano.", Falsa = true}
 }
 },
 {
 Nome = "Canadá",
 Alternativas = {
 {Texto = "Possui uma das maiores linhas costeiras do mundo.", Falsa = false},
 {Texto = "Contém grande parte da água doce do planeta em seus lagos.", Falsa = false},
 {Texto = "Está localizado inteiramente no hemisfério sul.", Falsa = true}
 }
 },
 {
 Nome = "Indonésia",
 Alternativas = {
 {Texto = "É um arquipélago com milhares de ilhas.", Falsa = false},
 {Texto = "Está localizada em zona tropical.", Falsa = false},
 {Texto = "Não possui atividade vulcânica.", Falsa = true}
 }
 }
 }
 },
 [4] = {
 Dados = {
 {
 Nome = "Chile",
 Alternativas = {
 {Texto = "É o país mais longo do mundo no sentido norte-sul.", Falsa = false},
 {Texto = "Abriga o deserto mais seco do mundo.", Falsa = false},
 {Texto = "Faz fronteira terrestre com o Brasil.", Falsa = true}
 }
 },
 {
 Nome = "Argentina",
 Alternativas = {
 {Texto = "Possui grande extensão territorial na América do Sul.", Falsa = false},
 {Texto = "Inclui regiões frias como a Patagônia.", Falsa = false},
 {Texto = "Não possui acesso ao oceano.", Falsa = true}
 }
 },
 {
 Nome = "Nepal",
 Alternativas = {
 {Texto = "Abriga o Monte Everest.", Falsa = false},
 {Texto = "Possui relevo predominantemente montanhoso.", Falsa = false},
 {Texto = "Está localizado na África.", Falsa = true}
 }
 }
 }
 },
 [5] = {
 Dados = {
 {
 Nome = "Arábia Saudita",
 Alternativas = {
 {Texto = "É o maior país do mundo sem rios permanentes, dependendo de chuvas e reservatórios artificiais.", Falsa = false},
 {Texto = "Importa camelos e areia da Austrália porque a areia do seu deserto é fina demais para construção.", Falsa = false},
 {Texto = "Proibiu usinas de dessalinização, tornando a água potável totalmente dependente da chuva.", Falsa = true}
 }
 },
 {
 Nome = "Austrália",
 Alternativas = {
 {Texto = "Possui vastas áreas desérticas quase inabitáveis.", Falsa = false},
 {Texto = "Possui biodiversidade única, com espécies inexistentes em outros lugares.", Falsa = false},
 {Texto = "Austrália é o lugar mais frio da Terra, com temperaturas que nunca passam de -10°C, sendo coberta por gelo eterno de ponta a ponta.", Falsa = true}
 }
 },
 {
 Nome = "Líbia",
 Alternativas = {
 {Texto = "Grande parte do território é deserto do Saara.", Falsa = false},
 {Texto = "População concentrada apenas em cidades costeiras.", Falsa = false},
 {Texto = "Apresenta falta de chuvas e clima temperado o ano inteiro.", Falsa = true}
 }
 }
 }
 },
 [6] = {
 Dados = {
 {
 Nome = "Mongólia",
 Alternativas = {
 {Texto = "Menor densidade demográfica do mundo, com vastas estepes desabitadas.", Falsa = false},
 {Texto = "Parte da população ainda vive em tendas móveis chamadas Gers.", Falsa = false},
 {Texto = "Possui grande frota de navios cargueiros mesmo sem saída para o oceano.", Falsa = true}
 }
 },
 {
 Nome = "Namíbia",
 Alternativas = {
 {Texto = "Baixa densidade populacional.", Falsa = false},
 {Texto = "Abriga o deserto da Namíbia, um dos mais antigos do mundo.", Falsa = false},
 {Texto = "Está localizada no norte da Ásia e faz fronteira com a Sibéria.", Falsa = true}
 }
 },
 {
 Nome = "Islândia",
 Alternativas = {
 {Texto = "Intensa atividade geotérmica e vulcânica.", Falsa = false},
 {Texto = "População pequena, concentrada em cidades costeiras.", Falsa = false},
 {Texto = "É um deserto de areia super quente e seco localizado no coração da África.", Falsa = true}
 }
 }
 }
 },
 [7] = {
 Dados = {
 {
 Nome = "Etiópia",
 Alternativas = {
 {Texto = "Possui um calendário próprio com 13 meses, estando cerca de 7 a 8 anos atrasado em relação ao ocidental.", Falsa = false},
 {Texto = "É amplamente reconhecida na história por nunca ter sido formalmente colonizada por potências europeias.", Falsa = false},
 {Texto = "Fica localizada na América do Sul e faz fronteira com o oceano Atlântico.", Falsa = true}
 }
 },
 {
 Nome = "Irã",
 Alternativas = {
 {Texto = "É o berço de uma das civilizações mais antigas do mundo e abriga monumentos históricos importantes.", Falsa = false},
 {Texto = "O país foi historicamente conhecido pelo nome de Pérsia até o século XX.", Falsa = false},
 {Texto = "É uma pequena ilha da Oceania totalmente cercada por recifes de coral.", Falsa = true}
 }
 },
 {
 Nome = "Afeganistão",
 Alternativas = {
 {Texto = "Apresenta um território predominantemente montanhoso com o sistema de Hindu Kush.", Falsa = false},
 {Texto = "Está localizado na Ásia Central e historicamente serviu como ponto de importantes rotas comerciais.", Falsa = false},
 {Texto = "É um país plano coberto por gelo eterno e com temperaturas que nunca passam de -40°C.", Falsa = true}
 }
 }
 }
 },
 [8] = {
 Dados = {
 {
 Nome = "Coreia do Norte",
 Alternativas = {
 {Texto = "Possui o maior estádio do mundo (Estádio Primeiro de Maio), capaz de abrigar cerca de 114 mil espectadores.", Falsa = false},
 {Texto = "Adota oficialmente o calendário Juche, cuja contagem de anos se inicia a partir de 1912.", Falsa = false},
 {Texto = "Sua economia baseia-se puramente no livre mercado capitalista e sem nenhuma estatal.", Falsa = true}
 }
 },
 {
 Nome = "Turcomenistão",
 Alternativas = {
 {Texto = "Possui imensas reservas naturais de gás natural em seu subsolo.", Falsa = false},
 {Texto = "Seu território é amplamente coberto pelo deserto de Karakum.", Falsa = false},
 {Texto = "Tem uma longa costa litorânea banhada diretamente pelo Oceano Pacífico.", Falsa = true}
 }
 },
 {
 Nome = "Eritreia",
 Alternativas = {
 {Texto = "Fica localizada no Chifre da África, uma região estratégica do continente.", Falsa = false},
 {Texto = "Conquistou formalmente sua independência no ano de 1993.", Falsa = false},
 {Texto = "É o maior exportador de carros elétricos de alta tecnologia do planeta.", Falsa = true}
 }
 }
 }
 },
 [9] = {
 Dados = {
 {
 Nome = "Suriname",
 Alternativas = {
 {Texto = "Cerca de 93% do seu território é composto por florestas tropicais densas e preservadas.", Falsa = false},
 {Texto = "O holandês é considerado o idioma oficial falado pela administração e população.", Falsa = false},
 {Texto = "É o maior país territorial da Europa e faz fronteira direta com a China.", Falsa = true}
 }
 },
 {
 Nome = "Guiana",
 Alternativas = {
 {Texto = "É o único país localizado na América do Sul que possui o inglês como sua língua oficial.", Falsa = false},
 {Texto = "Possui baixíssima densidade populacional, mantendo grande parte de suas florestas originais intactas.", Falsa = false},
 {Texto = "Fica localizado bem no meio do deserto do Saara, cercado por dunas de areia.", Falsa = true}
 }
 },
 {
 Nome = "Gabão",
 Alternativas = {
 {Texto = "Tem uma grande cobertura de floresta tropical preservada com riquíssima biodiversidade.", Falsa = false},
 {Texto = "Possui baixa densidade populacional, com a maioria dos habitantes vivendo em poucas áreas urbanas.", Falsa = false},
 {Texto = "Está localizado no norte da Europa e faz fronteira com a Finlândia.", Falsa = true}
 }
 }
 }
 },
 [10] = {
 Dados = {
 {
 Nome = "Kiribati",
 Alternativas = {
 {Texto = "É o único país do mundo que possui território espalhado por todos os quatro hemisférios da Terra.", Falsa = false},
 {Texto = "Foi a primeira nação a entrar no ano 2000 e celebrar o novo milênio devido à posição da Linha Internacional de Data.", Falsa = false},
 {Texto = "Está localizado no centro da Europa e possui grandes cordilheiras cobertas de gelo e pistas de esqui.", Falsa = true}
 }
 },
 {
 Nome = "Nauru",
 Alternativas = {
 {Texto = "É uma das menores nações insulares e independentes do mundo, localizada no Oceano Pacífico.", Falsa = false},
 {Texto = "Possui um território plano que foi historicamente transformado pela intensa mineração de fosfato.", Falsa = false},
 {Texto = "É famoso por possuir o maior deserto de areia contínuo do mundo, com dunas que chegam a 300 metros de altura.", Falsa = true}
 }
 },
 {
 Nome = "Butão",
 Alternativas = {
 {Texto = "É mundialmente famoso por priorizar o índice de Felicidade Interna Bruta (FIB) em vez do PIB.", Falsa = false},
 {Texto = "Está localizado na cordilheira do Himalaia, apresentando um relevo extremamente montanhoso e vales profundos.", Falsa = false},
 {Texto = "É uma grande ilha caribenha conhecida por suas praias tropicais cheias de coqueiros e clima quente o ano todo.", Falsa = true}
 }
 }
 }
 }
 },
 ["História"] = {
 [1] = {
		Dados = {
			{
				Nome = "Os Dinossauros",
				Alternativas = {
					{Texto = "Viveram na Terra durante a Era Mesozoica, milhões de anos antes dos primeiros humanos.", Falsa = false},
					{Texto = "A maioria das espécies de dinossauros se reproduzia botando ovos com casca dura.", Falsa = false},
					{Texto = "Conviviam diariamente com os seres humanos nas cidades e andavam pelas ruas.", Falsa = true},
				}
			},
			{
				Nome = "Período Paleolítico",
				Alternativas = {
					{Texto = "Foi o período mais longo da história humana, também chamado de Idade da Pedra Lascada.", Falsa = false},
					{Texto = "Nessa época, os seres humanos aprenderam a produzir e controlar o fogo.", Falsa = false},
					{Texto = "As pessoas construíam arranha-céus e usavam eletricidade em suas casas de pedra.", Falsa = true},
				}
			},
			{
				Nome = "Período Neolítico",
				Alternativas = {
					{Texto = "Ficou conhecido pelo surgimento da agricultura e pelo cultivo dos primeiros alimentos.", Falsa = false},
					{Texto = "Os humanos desenvolveram a cerâmica para cozinhar e guardar grãos e líquidos.", Falsa = false},
					{Texto = "Foi a época histórica em que os seres humanos inventaram os primeiros computadores.", Falsa = true},
				}
			},
			{
				Nome = "Idade dos Metais",
				Alternativas = {
					{Texto = "Os seres humanos aprenderam a derreter e moldar metais como cobre, bronze e ferro.", Falsa = false},
					{Texto = "As ferramentas de metal tornaram as tarefas de plantar e construir muito mais fáceis.", Falsa = false},
					{Texto = "As ferramentas eram feitas exclusivamente de plástico moldado no calor.", Falsa = true},
				}
			},
			{
				Nome = "Tiranossauro Rex",
				Alternativas = {
					{Texto = "Era um predador carnívoro de grande porte que andava sobre duas fortes pernas traseiras.", Falsa = false},
					{Texto = "Suas mandíbulas possuíam dentes serrilhados que podiam esmagar ossos com facilidade.", Falsa = false},
					{Texto = "Possuía grandes asas cobertas de penas e voava sobre florestas em busca de comida.", Falsa = true},
				}
			},
			{
				Nome = "Braquiossauro",
				Alternativas = {
					{Texto = "Era um dinossauro herbívoro gigante com um pescoço muito comprido.", Falsa = false},
					{Texto = "Seu longo pescoço permitia alcançar as folhas mais frescas no topo das árvores altas.", Falsa = false},
					{Texto = "Era um predador ágil que caçava outros dinossauros no fundo de oceanos profundos.", Falsa = true},
				}
			},
			{
				Nome = "Tricerátops",
				Alternativas = {
					{Texto = "Tinha três chifres pontudos no rosto e uma grande gola óssea protetora no pescoço.", Falsa = false},
					{Texto = "Era um dinossauro herbívoro que se alimentava de plantas rasteiras e arbustos.", Falsa = false},
					{Texto = "Disparava raios de eletricidade pelos seus chifres para espantar inimigos.", Falsa = true},
				}
			},
			{
				Nome = "Velociraptor",
				Alternativas = {
					{Texto = "Era um dinossauro carnívoro veloz que possuía uma garra curva e afiada em cada pata.", Falsa = false},
					{Texto = "Estudos científicos modernos mostram que ele possuía penas cobrindo seu corpo.", Falsa = false},
					{Texto = "Era um gigante mais pesado que uma baleia-azul que se movia lentamente.", Falsa = true},
				}
			},
			{
				Nome = "Estegossauro",
				Alternativas = {
					{Texto = "Possuía duas fileiras de placas ósseas triangulares enfileiradas ao longo das costas.", Falsa = false},
					{Texto = "A ponta da sua cauda tinha quatro espinhos afiados usados para se defender de predadores.", Falsa = false},
					{Texto = "Possuía um cérebro gigante do tamanho de uma melancia com inteligência humana.", Falsa = true},
				}
			},
			{
				Nome = "Pterossauros",
				Alternativas = {
					{Texto = "Eram répteis voadores que dominaram os céus durante a mesma época dos dinossauros.", Falsa = false},
					{Texto = "Suas asas eram formadas por uma membrana de pele resistente presa a um dedo alongado.", Falsa = false},
					{Texto = "Eram pássaros modernos idênticos aos canários que viviam em gaiolas pré-históricas.", Falsa = true},
				}
			},
			{
				Nome = "Espinossauro",
				Alternativas = {
					{Texto = "Possuía uma enorme vela nas costas sustentada por espinhas ósseas alongadas.", Falsa = false},
					{Texto = "Seu focinho longo e dentes cônicos eram ideais para capturar grandes peixes na água.", Falsa = false},
					{Texto = "Vivia dentro de blocos de gelo no Polo Sul se alimentando de pinguins pré-históricos.", Falsa = true},
				}
			},
			{
				Nome = "Fósseis",
				Alternativas = {
					{Texto = "São restos ou vestígios de animais e plantas antigas preservados em camadas de rocha.", Falsa = false},
					{Texto = "Pegadas deixadas na lama que endureceu ao longo de milhões de anos também são fósseis.", Falsa = false},
					{Texto = "Qualquer osso se transforma em um fóssil de pedra após ficar dez minutos no quintal.", Falsa = true},
				}
			},
			{
				Nome = "Paleontólogos",
				Alternativas = {
					{Texto = "São os cientistas responsáveis por encontrar, escavar e estudar fósseis de seres do passado.", Falsa = false},
					{Texto = "Usam pincéis delicados e ferramentas finas para retirar fósseis da rocha sem quebrar.", Falsa = false},
					{Texto = "São profissionais treinados para consertar motores a jato de naves espaciais modernas.", Falsa = true},
				}
			},
			{
				Nome = "Extinção dos Dinossauros",
				Alternativas = {
					{Texto = "Aconteceu há cerca de 66 milhões de anos após o impacto de um grande asteroide na Terra.", Falsa = false},
					{Texto = "A poeira levantada pelo choque cobriu o Sol por meses, mudando o clima do planeta.", Falsa = false},
					{Texto = "Os dinossauros construíram foguetes e se mudaram em massa para o planeta Marte.", Falsa = true},
				}
			},
			{
				Nome = "Era do Gelo",
				Alternativas = {
					{Texto = "Foi um período da Terra em que temperaturas baixas cobriram vastas áreas com geleiras.", Falsa = false},
					{Texto = "Vários animais desenvolveram pelos grossos e camadas de gordura para sobreviver ao frio.", Falsa = false},
					{Texto = "Foi uma época em que o planeta Terra se transformou em uma panela de água fervente.", Falsa = true},
				}
			},
			{
				Nome = "O Mamute",
				Alternativas = {
					{Texto = "Era um parente pré-histórico dos elefantes coberto por uma espessa camada de pelos longos.", Falsa = false},
					{Texto = "Possuía presas de marfim curvadas que podiam ultrapassar três metros de comprimento.", Falsa = false},
					{Texto = "Passava o dia nas praias tropicais do Caribe nadando entre corais aquecidos.", Falsa = true},
				}
			},
			{
				Nome = "Tigre-dentes-de-sabre",
				Alternativas = {
					{Texto = "Era um poderoso felino pré-histórico famoso por seus dois dentes caninos compridos.", Falsa = false},
					{Texto = "Usava seus dentes longos e afiados para caçar presas grandes e pesadas na Era do Gelo.", Falsa = false},
					{Texto = "Era uma espécie de peixe de escamas verdes que nadava em rios amazônicos.", Falsa = true},
				}
			},
			{
				Nome = "Preguiça-Gigante",
				Alternativas = {
					{Texto = "Era um animal herbívoro pré-histórico enorme que viveu na América do Sul e no Brasil.", Falsa = false},
					{Texto = "Podia alcançar vários metros de altura quando se apoiava sobre as patas traseiras.", Falsa = false},
					{Texto = "Era menor que uma formiga e costumava viver dentro de troncos ocos de maçã.", Falsa = true},
				}
			},
			{
				Nome = "Homens das Cavernas",
				Alternativas = {
					{Texto = "Eram nossos ancestrais pré-históricos que usavam abrigos naturais contra o vento e frio.", Falsa = false},
					{Texto = "Viviam em pequenos grupos que cooperavam entre si para caçar e colher alimentos.", Falsa = false},
					{Texto = "Compravam suas cavernas em agências imobiliárias usando moedas de ouro de piratas.", Falsa = true},
				}
			},
			{
				Nome = "Pinturas Rupestres",
				Alternativas = {
					{Texto = "São desenhos gravados em paredes e tetos de cavernas por seres humanos pré-históricos.", Falsa = false},
					{Texto = "Costumavam representar animais como bisões, cavalos selvagens e cenas de caçadas.", Falsa = false},
					{Texto = "Eram feitas usando canetinhas hidrográficas coloridas e tintas acrílicas sintéticas.", Falsa = true},
				}
			},
			{
				Nome = "Tinta Pré-Histórica",
				Alternativas = {
					{Texto = "Era preparada misturando pós de minerais, argila colorida, carvão e gordura animal.", Falsa = false},
					{Texto = "Alguns desenhos foram feitos soprando tinta em pó ao redor da mão apoiada na rocha.", Falsa = false},
					{Texto = "Era comprada pronta em latas de tinta spray vendidas em armazéns antigos.", Falsa = true},
				}
			},
			{
				Nome = "Descoberta do Fogo",
				Alternativas = {
					{Texto = "Permitiu aos primeiros humanos cozinhar a carne dos alimentos e deixá-la mais macia.", Falsa = false},
					{Texto = "O calor das chamas ajudou a espantar predadores noturnos e a aquecer as noites frias.", Falsa = false},
					{Texto = "O fogo foi aceso pelos primeiros homens com caixas de fósforos de madeira modernas.", Falsa = true},
				}
			},
			{
				Nome = "Pedra Lascada",
				Alternativas = {
					{Texto = "Técnica em que uma pedra dura batia em outra para soltar lascas com bordas muito afiadas.", Falsa = false},
					{Texto = "As lascas de pedra eram usadas como raspadores para limpar couro e facas de corte.", Falsa = false},
					{Texto = "As pedras eram cortadas com aparelhos de laser elétricos de alta tecnologia.", Falsa = true},
				}
			},
			{
				Nome = "Povos Nômades",
				Alternativas = {
					{Texto = "Grupos que não tinham moradia fixa e mudavam de região quando os recursos acabavam.", Falsa = false},
					{Texto = "Seguiam as rotas dos animais para caçar e buscavam novos frutos e plantas da estação.", Falsa = false},
					{Texto = "Moravam no mesmo apartamento durante cinquenta anos sem sair para nenhum lugar.", Falsa = true},
				}
			},
			{
				Nome = "Armas de Caça Primitivas",
				Alternativas = {
					{Texto = "Lanças de madeira com pontas afiadas de pedra eram arremessadas contra animais de caça.", Falsa = false},
					{Texto = "O propulsor de lanças foi inventado para lançar os dardos com muito mais força e alcance.", Falsa = false},
					{Texto = "Eram espingardas automáticas equipadas com miras telescópicas de visão noturna.", Falsa = true},
				}
			},
			{
				Nome = "Roupas na Pré-História",
				Alternativas = {
					{Texto = "Eram feitas com peles e pelos de animais caçados, limpas e costuradas para dar abrigo.", Falsa = false},
					{Texto = "Eram essenciais para proteger os corpos do frio congelante e dos ventos nas caçadas.", Falsa = false},
					{Texto = "Eram confeccionadas com tecidos de náilon e fechadas por zíperes de metal inox.", Falsa = true},
				}
			},
			{
				Nome = "Agulhas de Osso",
				Alternativas = {
					{Texto = "Eram feitas polindo lascas finas de ossos de animais com um pequeno furo na extremidade.", Falsa = false},
					{Texto = "Permitiram passar tendões e tiras de couro para costurar roupas muito bem ajustadas.", Falsa = false},
					{Texto = "Eram fabricadas em aço inoxidável cirúrgico com baterias eletrônicas embutidas.", Falsa = true},
				}
			},
			{
				Nome = "Arco e Flecha",
				Alternativas = {
					{Texto = "Foi uma invenção revolucionária que permitiu aos caçadores atingir alvos rápidos de longe.", Falsa = false},
					{Texto = "Utilizava a força da madeira recurvada e a tensão de cordas feitas de fibras vegetais.", Falsa = false},
					{Texto = "Precisava de uma tomada elétrica conectada à parede para disparar suas flechas.", Falsa = true},
				}
			},
			{
				Nome = "Origem da Agricultura",
				Alternativas = {
					{Texto = "Os humanos perceberam que sementes caídas na terra brotavam e davam novas plantas.", Falsa = false},
					{Texto = "O plantio de grãos como trigo e cevada garantiu comida sem depender apenas da caça.", Falsa = false},
					{Texto = "Plantavam pedaços de plástico no solo esperando colher brinquedos prontos nas árvores.", Falsa = true},
				}
			},
			{
				Nome = "Povos Sedentários",
				Alternativas = {
					{Texto = "Ao aprender a plantar alimentos, as pessoas passaram a se fixar em um local permanente.", Falsa = false},
					{Texto = "Construíram as primeiras aldeias com moradias duradouras perto de rios e terras férteis.", Falsa = false},
					{Texto = "Viajavam toda semana em viagens de trem de alta velocidade para mudar de cidade.", Falsa = true},
				}
			},
			{
				Nome = "Domesticação de Animais",
				Alternativas = {
					{Texto = "Humanos começaram a cuidar de animais como cabras, ovelhas e vacas para obter leite e lã.", Falsa = false},
					{Texto = "A criação de rebanhos fornecia alimento regular sem o perigo das caçadas na floresta.", Falsa = false},
					{Texto = "Os primeiros povos domesticavam tiranossauros rex para carregar compras nas aldeias.", Falsa = true},
				}
			},
			{
				Nome = "O Cão na Pré-História",
				Alternativas = {
					{Texto = "O lobo foi o primeiro animal a ser domesticado, tornando-se o fiel amigo dos humanos.", Falsa = false},
					{Texto = "Cães primitivos ajudavam os caçadores a farejar presas e protegiam a aldeia durante a noite.", Falsa = false},
					{Texto = "O primeiro animal domesticado pela humanidade foi o tubarão-baleia dos oceanos.", Falsa = true},
				}
			},
			{
				Nome = "A Cerâmica",
				Alternativas = {
					{Texto = "Vasos e potes eram moldados em barro úmido e depois assados no fogo para endurecer.", Falsa = false},
					{Texto = "Permitiu cozinhar alimentos líquidos em sopas e estocar água e grãos por meses.", Falsa = false},
					{Texto = "Os primeiros potes de cerâmica eram moldados usando garrafas plásticas recicladas.", Falsa = true},
				}
			},
			{
				Nome = "A Tecelagem",
				Alternativas = {
					{Texto = "Aprenderam a trançar fios de lã animal e de fibras de plantas para criar os primeiros panos.", Falsa = false},
					{Texto = "Os tecidos leves tornaram as vestimentas muito mais confortáveis nos períodos mais quentes.", Falsa = false},
					{Texto = "Os tecidos eram produzidos em fábricas computadorizadas com robôs de alta precisão.", Falsa = true},
				}
			},
			{
				Nome = "Primeiras Canoas",
				Alternativas = {
					{Texto = "Eram feitas cavando o interior de troncos grossos de árvores com auxílio do fogo e raspadeiras.", Falsa = false},
					{Texto = "Facilitaram a travessia de rios largos e permitiram a pesca em águas mais fundas.", Falsa = false},
					{Texto = "Eram movidas por motores de popa a gasolina com turbinas submarinas de corrida.", Falsa = true},
				}
			},
			{
				Nome = "A Invenção da Roda",
				Alternativas = {
					{Texto = "Foi uma das invenções mais importantes, facilitando o transporte de cargas muito pesadas.", Falsa = false},
					{Texto = "As primeiras rodas eram discos maciços feitos de pedras esculpidas ou troncos de madeira.", Falsa = false},
					{Texto = "Possuíam pneus modernos de borracha sintética cheios de ar e calotas de liga leve.", Falsa = true},
				}
			},
			{
				Nome = "Pedra Polida",
				Alternativas = {
					{Texto = "Técnica em que as pedras eram friccionadas com areia e água até ficarem lisinhas e afiadas.", Falsa = false},
					{Texto = "Machados de pedra polida eram muito mais eficientes para cortar troncos de árvores.", Falsa = false},
					{Texto = "As pedras eram amaciadas usando amaciante de roupas e sabão em pó moderno.", Falsa = true},
				}
			},
			{
				Nome = "O Metal Cobre",
				Alternativas = {
					{Texto = "Foi um dos primeiros metais trabalhados pelos humanos por ser maleável e fácil de moldar.", Falsa = false},
					{Texto = "Podia ser martelado a frio ou derretido em fornos rústicos para criar ferramentas e pontas.", Falsa = false},
					{Texto = "O cobre brotava em árvores frutíferas e era colhido nos galhos como se fosse maçã.", Falsa = true},
				}
			},
			{
				Nome = "A Descoberta do Bronze",
				Alternativas = {
					{Texto = "Surgiu da mistura inteligente do cobre derretido com estanho, criando uma liga resistente.", Falsa = false},
					{Texto = "Ferramentas e armas de bronze eram bem mais duráveis e mantinham o corte por mais tempo.", Falsa = false},
					{Texto = "O bronze era recolhido no fundo das nuvens durante tempestades de chuva forte.", Falsa = true},
				}
			},
			{
				Nome = "A Idade do Ferro",
				Alternativas = {
					{Texto = "O ferro exigia fornos de alta temperatura para derreter, sendo o metal mais resistente da época.", Falsa = false},
					{Texto = "Permitiu criar arados mais fortes para cavar a terra e foices para a colheita dos campos.", Falsa = false},
					{Texto = "O ferro derretia espontaneamente quando era exposto a uma simples brisa de vento frio.", Falsa = true},
				}
			},
			{
				Nome = "Casas Primitivas",
				Alternativas = {
					{Texto = "Eram erguidas com armações de galhos de madeira, paredes de barro e teto de palha seca.", Falsa = false},
					{Texto = "Protegiam as famílias do sol forte, da chuva e das feras da natureza ao redor.", Falsa = false},
					{Texto = "Eram construídas com grandes placas de vidro blindado e ar-condicionado central.", Falsa = true},
				}
			},
			{
				Nome = "O Escambo Primitivo",
				Alternativas = {
					{Texto = "Era um sistema de comércio baseado na troca direta de mercadorias sem o uso de dinheiro.", Falsa = false},
					{Texto = "Quem tinha excesso de grãos de trigo podia trocar por potes de cerâmica ou carne de peixe.", Falsa = false},
					{Texto = "As compras das aldeias antigas eram pagas com cartões de crédito e Pix no celular.", Falsa = true},
				}
			},
			{
				Nome = "Monumentos de Megálitos",
				Alternativas = {
					{Texto = "Eram construções formadas por blocos gigantes de pedra colocados em pé pelos povos pré-históricos.", Falsa = false},
					{Texto = "Exigiam o esforço coordenado de dezenas ou centenas de pessoas puxando pedras sobre troncos.", Falsa = false},
					{Texto = "Os blocos eram erguidos por guindastes movidos a diesel de construção moderna.", Falsa = true},
				}
			},
			{
				Nome = "Stonehenge",
				Alternativas = {
					{Texto = "É um famoso monumento pré-histórico de pedras gigantes dispostas em círculos na Inglaterra.", Falsa = false},
					{Texto = "Pesquisadores acreditam que o monumento servia para observar os movimentos do Sol e da Lua.", Falsa = false},
					{Texto = "Foi construído no ano de 2015 para funcionar como um shopping center de jogos.", Falsa = true},
				}
			},
			{
				Nome = "O Fóssil de Luzia",
				Alternativas = {
					{Texto = "É o fóssil de esqueleto humano mais antigo já encontrado no território da América do Sul.", Falsa = false},
					{Texto = "Foi descoberto em uma caverna na região de Lagoa Santa, no estado de Minas Gerais no Brasil.", Falsa = false},
					{Texto = "Foi encontrado congelado dentro de um cubo de gelo artificial em um laboratório moderno.", Falsa = true},
				}
			},
			{
				Nome = "Serra da Capivara",
				Alternativas = {
					{Texto = "Parque Nacional no Piauí que abriga milhares de pinturas rupestres antiquíssimas no Brasil.", Falsa = false},
					{Texto = "É considerado um Patrimônio Cultural da Humanidade protegido pela UNESCO.", Falsa = false},
					{Texto = "Fica localizado no centro da Europa, cercado por montanhas dos Alpes suíços.", Falsa = true},
				}
			},
			{
				Nome = "Megafauna no Brasil",
				Alternativas = {
					{Texto = "Animais gigantes habitaram o território brasileiro pré-histórico há milhares de anos.", Falsa = false},
					{Texto = "O gliptodonte, parecido com um tatu do tamanho de um carro pequeno, viveu no Brasil.", Falsa = false},
					{Texto = "Dinossauros gigantes nadavam no mar de Copacabana durante o ano de 1950.", Falsa = true},
				}
			},
			{
				Nome = "O Âmbar Pré-Histórico",
				Alternativas = {
					{Texto = "É uma resina vegetal endurecida de árvores antigas que preservou insetos dentro dela.", Falsa = false},
					{Texto = "Permite aos cientistas observar pequenos detalhes de seres vivos de milhões de anos atrás.", Falsa = false},
					{Texto = "É uma geleia doce comestível que escorria espontaneamente do teto das cavernas.", Falsa = true},
				}
			},
			{
				Nome = "Ninhos de Dinossauros",
				Alternativas = {
					{Texto = "Fósseis mostram que muitas espécies colocavam ovos em ninhos circulares escavados na terra.", Falsa = false},
					{Texto = "Alguns dinossauros cuidavam dos filhotes após o nascimento, trazendo comida ao ninho.", Falsa = false},
					{Texto = "Filhotes de dinossauro nasciam de ovos já vestindo armaduras e capacetes de metal.", Falsa = true},
				}
			},
			{
				Nome = "O Fim da Pré-História",
				Alternativas = {
					{Texto = "A Pré-História termina oficialmente no momento em que a humanidade desenvolve a escrita.", Falsa = false},
					{Texto = "A escrita permitiu registrar leis, acontecimentos e histórias em tabuletas de argila.", Falsa = false},
					{Texto = "A Pré-História acabou quando todos os vulcões do planeta explodiram ao mesmo tempo.", Falsa = true},
				}
			}
		}
	},
 [2] = {
		Dados = {
			{
				Nome = "O Rio Nilo no Egito Antigo",
				Alternativas = {
					{Texto = "Suas cheias periódicas deixavam uma camada de lodo escuro e fértil nas margens para plantar.", Falsa = false},
					{Texto = "O historiador grego Heródoto chamou a civilização egípcia de uma dádiva do Rio Nilo.", Falsa = false},
					{Texto = "Era um rio de lava de vulcão fervente por onde barcos de madeira não podiam navegar.", Falsa = true},
				}
			},
			{
				Nome = "Os Faraós",
				Alternativas = {
					{Texto = "Eram os governantes supremos do Egito, considerados também representantes vivos dos deuses.", Falsa = false},
					{Texto = "Usavam coroas especiais e cetros dourados como símbolos de sua autoridade real e militar.", Falsa = false},
					{Texto = "Eram escolhidos pelo povo por meio de votação eletrônica em urnas a cada dois anos.", Falsa = true},
				}
			},
			{
				Nome = "As Pirâmides de Gizé",
				Alternativas = {
					{Texto = "Foram construídas como túmulos grandiosos de pedra para guardar os corpos e tesouros dos faraós.", Falsa = false},
					{Texto = "A Grande Pirâmide foi construída para o faraó Quéops há mais de quatro mil anos.", Falsa = false},
					{Texto = "Foram levantadas usando guindastes elétricos modernos e caminhões caçamba a diesel.", Falsa = true},
				}
			},
			{
				Nome = "A Grande Esfinge",
				Alternativas = {
					{Texto = "É uma monumental escultura em pedra com corpo de leão deitado e cabeça humana com touca real.", Falsa = false},
					{Texto = "Foi esculpida próxima às pirâmides de Gizé para servir de guardiã espiritual da necrópole.", Falsa = false},
					{Texto = "Possui asas de avião supersônico e uma cabeça feita de circuitos de computador modernos.", Falsa = true},
				}
			},
			{
				Nome = "A Mumificação",
				Alternativas = {
					{Texto = "Era um ritual sagrado para preservar o corpo dos mortos usando sal natrão, resinas e linho.", Falsa = false},
					{Texto = "Acreditavam que o espírito precisava reconhecer o corpo preservado para viver no além.", Falsa = false},
					{Texto = "Consistia em mergulhar o corpo em caldas de chocolate quente com granulados de doce.", Falsa = true},
				}
			},
			{
				Nome = "Os Sarcófagos",
				Alternativas = {
					{Texto = "Eram caixões de pedra ou madeira ricamente pintados com símbolos protetores e o rosto do morto.", Falsa = false},
					{Texto = "Protegiam a múmia e podiam ser colocados um dentro do outro como caixas especiais.", Falsa = false},
					{Texto = "Eram caixas de papelão amassado que eram jogadas na lixeira do palácio após o velório.", Falsa = true},
				}
			},
			{
				Nome = "Os Vasos Canópicos",
				Alternativas = {
					{Texto = "Eram quatro recipientes com tampas esculpidas em cabeças de deuses para guardar órgãos internos.", Falsa = false},
					{Texto = "Guardavam o fígado, os pulmões, o estômago e os intestinos que eram retirados do corpo.", Falsa = false},
					{Texto = "Eram xícaras de porcelana moderna usadas para servir café com leite aos sacerdotes.", Falsa = true},
				}
			},
			{
				Nome = "Os Hieróglifos",
				Alternativas = {
					{Texto = "Eram a escrita sagrada egípcia composta por centenas de figuras de pássaros, olhos e símbolos.", Falsa = false},
					{Texto = "Eram gravados em paredes de templos de pedra, túmulos de reis e folhas compridas de papiro.", Falsa = false},
					{Texto = "Eram compostos por letras em inglês digitadas em teclados sem fio modernos.", Falsa = true},
				}
			},
			{
				Nome = "O Papel Papiro",
				Alternativas = {
					{Texto = "Era feito a partir das hastes de uma planta aquática que crescia em abundância no Rio Nilo.", Falsa = false},
					{Texto = "As tiras da planta eram prensadas e secas, criando uma das primeiras folhas de escrita da história.", Falsa = false},
					{Texto = "Era um tipo de plástico transparente sintético fabricado com derivados de petróleo.", Falsa = true},
				}
			},
			{
				Nome = "A Pedra de Roseta",
				Alternativas = {
					{Texto = "Foi um bloco de pedra negro achado com um mesmo decreto escrito em grego e hieróglifos.", Falsa = false},
					{Texto = "Permitiu ao pesquisador Champollion decifrar pela primeira vez os hieróglifos egípcios antigos.", Falsa = false},
					{Texto = "Era um aparelho celular antigo de pedra que transmitia músicas populares pelo rádio.", Falsa = true},
				}
			},
			{
				Nome = "O Faraó Tutancâmon",
				Alternativas = {
					{Texto = "Ficou famoso como o faraó menino porque assumiu o trono do Egito com apenas nove anos de idade.", Falsa = false},
					{Texto = "Sua tumba foi descoberta quase intacta no Vale dos Reis, contendo uma máscara de ouro puro.", Falsa = false},
					{Texto = "Reinou por mais de cem anos e foi o inventor do primeiro automóvel a gasolina.", Falsa = true},
				}
			},
			{
				Nome = "A Rainha Cleópatra",
				Alternativas = {
					{Texto = "Foi uma governante famosa do Egito Antigo, reconhecida por sua inteligência e habilidades políticas.", Falsa = false},
					{Texto = "Falava vários idiomas e fez alianças históricas com grandes líderes romanos da sua época.", Falsa = false},
					{Texto = "Foi uma astronauta pioneira que viajou em um foguete para dar uma volta na Lua.", Falsa = true},
				}
			},
			{
				Nome = "O Faraó Ramsés II",
				Alternativas = {
					{Texto = "Foi um dos faraós que governou por mais tempo, liderando grandes batalhas e erguendo monumentos.", Falsa = false},
					{Texto = "Mandou construir os impressionantes templos esculpidos na rocha da montanha em Abu Simbel.", Falsa = false},
					{Texto = "Voava pelos céus do Egito pilotando um helicóptero de combate equipado com mísseis.", Falsa = true},
				}
			},
			{
				Nome = "A Deusa Ísis",
				Alternativas = {
					{Texto = "Era uma das deusas mais queridas do Egito, associada à magia, à cura e à proteção materna.", Falsa = false},
					{Texto = "Era esposa do deus Osíris e mãe do deus Hórus nas narrativas sagradas da mitologia egípcia.", Falsa = false},
					{Texto = "Era uma deusa com formato de guindaste de ferro que ajudava nas obras da cidade.", Falsa = true},
				}
			},
			{
				Nome = "O Deus Rá",
				Alternativas = {
					{Texto = "Era o deus egípcio do Sol, considerado uma das divindades criadoras mais poderosas do panteão.", Falsa = false},
					{Texto = "Os egípcios acreditavam que ele cruzava o céu diariamente em uma grande barca solar sagrada.", Falsa = false},
					{Texto = "Era o deus do gelo polar e da escuridão eterna que congelava o calor de todas as plantas.", Falsa = true},
				}
			},
			{
				Nome = "O Deus Anúbis",
				Alternativas = {
					{Texto = "Era representado como um homem com cabeça de chacal negro protetor dos mortos.", Falsa = false},
					{Texto = "Era o guardião do ritual de mumificação e pesava o coração das pessoas na balança divina.", Falsa = false},
					{Texto = "Tinha a cabeça de um periquito verde cantante que assobiava marchinhas nos templos.", Falsa = true},
				}
			},
			{
				Nome = "O Deus Hórus",
				Alternativas = {
					{Texto = "Era representado com a cabeça de um falcão vigilante e o famoso olho protetor de Hórus.", Falsa = false},
					{Texto = "O faraó no trono era visto pelos egípcios como a representação do próprio Hórus vivo na Terra.", Falsa = false},
					{Texto = "Era uma baleia de água doce que nadava de cabeça para baixo no fundo do Rio Nilo.", Falsa = true},
				}
			},
			{
				Nome = "O Deus Osíris",
				Alternativas = {
					{Texto = "Era o deus da vegetação, da ressurreição e o soberano do reino dos mortos na mitologia.", Falsa = false},
					{Texto = "Geralmente era desenhado com o corpo enfaixado como uma múmia e a pele na cor verde da vida.", Falsa = false},
					{Texto = "Era um monstro de fogo voador que devorava as plantações de trigo das margens do rio.", Falsa = true},
				}
			},
			{
				Nome = "Os Gatos no Egito Antigo",
				Alternativas = {
					{Texto = "Eram animais sagrados muito queridos que protegiam as casas e celeiros caçando ratos e cobras.", Falsa = false},
					{Texto = "Eram associados à deusa Bastet, protetora do lar e da alegria, e recebiam sepultamento digno.", Falsa = false},
					{Texto = "Eram estritamente proibidos em todo o território egípcio sob pena de prisão perpétua.", Falsa = true},
				}
			},
			{
				Nome = "O Escaravelho Sagrado",
				Alternativas = {
					{Texto = "Era um amuleto muito popular esculpido em pedras verdes ou azuis para trazer boa sorte e vida.", Falsa = false},
					{Texto = "Inspirado no besouro que rola bolas de terra, simbolizava o Sol nascendo a cada novo dia.", Falsa = false},
					{Texto = "Era um pássaro aquático migratório gigante com cauda de pavão emplumada de prata.", Falsa = true},
				}
			},
			{
				Nome = "Maquiagem no Egito (Kohl)",
				Alternativas = {
					{Texto = "Homens e mulheres pintavam o contorno dos olhos com pó mineral escuro misturado com óleos.", Falsa = false},
					{Texto = "A maquiagem escura ajudava a proteger os olhos contra o brilho excessivo do sol do deserto.", Falsa = false},
					{Texto = "A maquiagem dos egípcios era feita exclusivamente com graxa suja de motor de caminhão.", Falsa = true},
				}
			},
			{
				Nome = "Barcos a Vela no Nilo",
				Alternativas = {
					{Texto = "O Nilo funcionava como a principal estrada líquida do Egito para o transporte de cargas e pessoas.", Falsa = false},
					{Texto = "Usavam a correnteza da água para descer o rio e a força do vento nas velas para subir ao sul.", Falsa = false},
					{Texto = "Eram impulsionados por reatores nucleares submarinos que quebravam a barreira do som.", Falsa = true},
				}
			},
			{
				Nome = "A Alimentação dos Egípcios",
				Alternativas = {
					{Texto = "A dieta básica do povo incluía pães de cevada e trigo, cebolas, alho, lentilhas e peixe do rio.", Falsa = false},
					{Texto = "Frutas doces como figos, uvas e tâmaras eram apreciadas como sobremesas saudáveis no Egito.", Falsa = false},
					{Texto = "As famílias jantavam caixas de pizza congelada de micro-ondas todas as noites nos palácios.", Falsa = true},
				}
			},
			{
				Nome = "A Cerveja dos Egípcios",
				Alternativas = {
					{Texto = "Era uma bebida espessa e fermentada de grãos de cevada, considerada um alimento do dia a dia.", Falsa = false},
					{Texto = "Era rica em nutrientes e muitas vezes consumida porque era mais pura e segura que a água crua.", Falsa = false},
					{Texto = "Era servida em garrafas plásticas descartáveis com canudos de plástico coloridos.", Falsa = true},
				}
			},
			{
				Nome = "O Ouro dos Faraós",
				Alternativas = {
					{Texto = "O Egito possuía jazidas de ouro no deserto oriental e no sul, produzindo joias deslumbrantes.", Falsa = false},
					{Texto = "Os egípcios chamavam o ouro de carne dos deuses por seu brilho brilhante que não enferruja.", Falsa = false},
					{Texto = "As peças de ouro dos túmulos eram todas moldadas com massinha de modelar escolar comum.", Falsa = true},
				}
			},
			{
				Nome = "Os Escribas Egípcios",
				Alternativas = {
					{Texto = "Eram funcionários de grande prestígio que dominavam a complexa escrita e a contabilidade do reino.", Falsa = false},
					{Texto = "Registravam a quantidade de grãos colhidos nos armazéns reais, impostos e ordens do faraó.", Falsa = false},
					{Texto = "Eram robôs com inteligência artificial que imprimiam relatórios em impressoras a laser.", Falsa = true},
				}
			},
			{
				Nome = "Escolas no Antigo Egito",
				Alternativas = {
					{Texto = "As escolas funcionavam geralmente anexas aos templos religiosos para filhos de nobres e escribas.", Falsa = false},
					{Texto = "A maioria das crianças do campo aprendia a plantar, cuidar de animais ou fazer cerâmica com os pais.", Falsa = false},
					{Texto = "Todas as crianças do país usavam notebooks e tablets conectados ao Wi-Fi na sala de aula.", Falsa = true},
				}
			},
			{
				Nome = "Brinquedos das Crianças",
				Alternativas = {
					{Texto = "Crianças do Antigo Egito brincavam com bonecas de pano e madeira, piões e bolinhas de argila.", Falsa = false},
					{Texto = "Gostavam de nadar nas águas do rio e participar de corridas e jogos ao ar livre com amigos.", Falsa = false},
					{Texto = "Passavam o dia inteiro jogando videogames de aventura em televisores de tela plana de cinema.", Falsa = true},
				}
			},
			{
				Nome = "O Tabuleiro de Senet",
				Alternativas = {
					{Texto = "Era um dos jogos de tabuleiro mais famosos e antigos do Egito, com trinta casas em fileiras.", Falsa = false},
					{Texto = "Era praticado por pessoas comuns e pelos próprios faraós, que levavam tabuleiros aos túmulos.", Falsa = false},
					{Texto = "Era um aplicativo de celular com tela touch screen baixado em lojas de jogos virtuais.", Falsa = true},
				}
			},
			{
				Nome = "Templos de Karnak e Luxor",
				Alternativas = {
					{Texto = "Eram gigantescos complexos religiosos construídos com pedras maciças em homenagem ao deus Amon.", Falsa = false},
					{Texto = "Possuíam grandes avenidas de esfinges e colunas com mais de vinte metros cobertas de relevos.", Falsa = false},
					{Texto = "Foram montados exclusivamente com peças de plástico colorido de encaixe de brinquedo.", Falsa = true},
				}
			},
			{
				Nome = "O Trabalho no Campo",
				Alternativas = {
					{Texto = "Os camponeses trabalhavam no cultivo de grãos nas margens do Nilo e na colheita sob o sol quente.", Falsa = false},
					{Texto = "Durante a época em que o Nilo inundava os campos, muitos eram chamados para trabalhar nas obras reais.", Falsa = false},
					{Texto = "Os camponeses usavam tratores automáticos com piloto automático guiado por GPS moderno.", Falsa = true},
				}
			},
			{
				Nome = "A Fértil Mesopotâmia",
				Alternativas = {
					{Texto = "Era uma região histórica no Oriente Médio situada entre os vales dos rios Tigre e Eufrates.", Falsa = false},
					{Texto = "Seu solo fértil permitiu o surgimento de algumas das primeiras cidades da história da humanidade.", Falsa = false},
					{Texto = "Fica localizada bem no centro da densa Floresta Amazônica no norte do território do Brasil.", Falsa = true},
				}
			},
			{
				Nome = "O Povo Sumério",
				Alternativas = {
					{Texto = "Foi uma das civilizações mais antigas da Mesopotâmia, famosa pela invenção da escrita cuneiforme.", Falsa = false},
					{Texto = "Construíram canais de irrigação para controlar as águas dos rios e abastecer suas plantações.", Falsa = false},
					{Texto = "Inventaram o primeiro modelo de carro voador supersônico com motores elétricos.", Falsa = true},
				}
			},
			{
				Nome = "A Escrita Cuneiforme",
				Alternativas = {
					{Texto = "Era feita gravando símbolos com uma haste em forma de cunha sobre placas de barro úmido.", Falsa = false},
					{Texto = "Depois de gravadas, as tabuletas de argila secavam ao sol ou no forno para durar séculos.", Falsa = false},
					{Texto = "Era uma fonte digital de computador instalada em editores de texto modernos para imprimir.", Falsa = true},
				}
			},
			{
				Nome = "Os Zigurates",
				Alternativas = {
					{Texto = "Eram imponentes construções em formato de pirâmide de degraus erguidas nas cidades mesopotâmicas.", Falsa = false},
					{Texto = "No topo dessas torres ficava o templo sagrado dedicado ao deus protetor daquela cidade.", Falsa = false},
					{Texto = "Eram pistas de esqui no gelo cobertas de neve artificial para turistas esquiarem no verão.", Falsa = true},
				}
			},
			{
				Nome = "A Cidade de Babilônia",
				Alternativas = {
					{Texto = "Foi uma das capitais mais ricas e famosas do mundo antigo, repleta de muralhas e portões azuis.", Falsa = false},
					{Texto = "O Portão de Ishtar era uma das entradas mais bonitas da cidade, decorado com touros e dragões.", Falsa = false},
					{Texto = "Era uma minúscula tenda de pano montada em cima de um rochedo deserto no meio do oceano.", Falsa = true},
				}
			},
			{
				Nome = "O Código de Hamurabi",
				Alternativas = {
					{Texto = "Foi um dos códigos de leis escritas mais antigos da história, criado por um rei da Babilônia.", Falsa = false},
					{Texto = "Suas leis foram gravadas em um grande bloco de pedra escura para que todos conhecessem as regras.", Falsa = false},
					{Texto = "Foi escrito em páginas de caderno escolar com caneta marca-texto colorida e fita crepe.", Falsa = true},
				}
			},
			{
				Nome = "Jardins Suspensos da Babilônia",
				Alternativas = {
					{Texto = "Segundo lendas antigas, eram belos terraços com plantas e flores irrigadas no alto do palácio.", Falsa = false},
					{Texto = "Foram considerados por historiadores gregos como uma das Sete Maravilhas do Mundo Antigo.", Falsa = false},
					{Texto = "Eram canteiros de flores reais que flutuavam no ar amarrados a centenas de balões de gás hélio.", Falsa = true},
				}
			},
			{
				Nome = "O Relógio de Sol",
				Alternativas = {
					{Texto = "Foi um instrumento inventado por povos antigos para medir a passagem das horas pela sombra do Sol.", Falsa = false},
					{Texto = "Conforme a Terra girava, a sombra projetada por uma haste marcava as divisões do dia no solo.", Falsa = false},
					{Texto = "Possuía tela digital de vidro temperado conectada via Bluetooth a celulares modernos.", Falsa = true},
				}
			},
			{
				Nome = "O Calendário de 365 Dias",
				Alternativas = {
					{Texto = "Os egípcios criaram um calendário solar com 12 meses de 30 dias mais 5 dias dedicados aos deuses.", Falsa = false},
					{Texto = "O calendário era muito útil para saber a época exata da cheia do Rio Nilo e do plantio de trigo.", Falsa = false},
					{Texto = "Era um calendário curioso onde o ano inteiro tinha apenas quatro semanas de duração.", Falsa = true},
				}
			},
			{
				Nome = "A Medicina Egípcia",
				Alternativas = {
					{Texto = "Os médicos egípcios tratavam doentes com ervas, limpavam feridas com mel e imobilizavam fraturas.", Falsa = false},
					{Texto = "Graças à prática de mumificação, os egípcios aprenderam muito sobre a anatomia do corpo humano.", Falsa = false},
					{Texto = "Curavam doenças aplicando vacinas de nanotecnologia com robôs microscópicos nos pacientes.", Falsa = true},
				}
			},
			{
				Nome = "Os Navegadores Fenícios",
				Alternativas = {
					{Texto = "Eram marinheiros e comerciantes habilidosos que navegavam por todo o Mar Mediterrâneo.", Falsa = false},
					{Texto = "Criaram um alfabeto inovador baseado em sons que facilitou o comércio entre diferentes povos.", Falsa = false},
					{Texto = "Viajavam pelo fundo dos oceanos usando submarinos atômicos com radares de sonar modernos.", Falsa = true},
				}
			},
			{
				Nome = "Rotas de Comércio Antigas",
				Alternativas = {
					{Texto = "Povos antigos viajavam em caravanas pelo deserto para trocar azeite, cerâmicas, tecidos e incenso.", Falsa = false},
					{Texto = "Cidades como Tiro, Babilônia e Alexandria tornaram-se grandes mercados de encontro de mercadores.", Falsa = false},
					{Texto = "As mercadorias eram despachadas em aviões de carga supersônicos com entrega no mesmo dia.", Falsa = true},
				}
			},
			{
				Nome = "A Barca Solar de Quéops",
				Alternativas = {
					{Texto = "Era um grande barco de madeira de cedro desmontado e enterrado ao lado da Grande Pirâmide de Gizé.", Falsa = false},
					{Texto = "Foi construído para permitir ao faraó navegar pelo céu com os deuses após a vida terrena.", Falsa = false},
					{Texto = "Possuía turbinas a jato que soltavam labaredas de fogo azul para quebrar a velocidade do som.", Falsa = true},
				}
			},
			{
				Nome = "As Bigas de Guerra",
				Alternativas = {
					{Texto = "Eram carruagens leves de madeira puxadas por dois cavalos velozes, com um condutor e um arqueiro.", Falsa = false},
					{Texto = "Revolucionaram as batalhas no Oriente Médio e no Egito Antigo pela sua velocidade e mobilidade.", Falsa = false},
					{Texto = "Eram veículos blindados de metal pesado com esteiras de tanque e canhões automáticos.", Falsa = true},
				}
			},
			{
				Nome = "Espelhos e Pentes Egípcios",
				Alternativas = {
					{Texto = "Os egípcios fabricavam pentes finos de marfim ou madeira e espelhos de cobre ou bronze polido.", Falsa = false},
					{Texto = "A higiene diária era essencial, e nobres egípcios lavavam-se várias vezes ao dia e raspavam pelos.", Falsa = false},
					{Texto = "Usavam câmeras de celular com iluminação de anel de LED para verificar o visual no espelho.", Falsa = true},
				}
			},
			{
				Nome = "A Cidade de Tebas",
				Alternativas = {
					{Texto = "Foi uma das capitais mais importantes do Egito Antigo durante a época dos grandes impérios.", Falsa = false},
					{Texto = "Ficava no Alto Egito, perto dos grandes templos e da famosa necrópole do Vale dos Reis.", Falsa = false},
					{Texto = "Era uma cidade submarina instalada dentro de uma cúpula de vidro no fundo do oceano.", Falsa = true},
				}
			},
			{
				Nome = "O Vale dos Reis",
				Alternativas = {
					{Texto = "É um vale desértico onde faraós do Novo Império foram sepultados em tumbas cavadas na rocha.", Falsa = false},
					{Texto = "As tumbas eram escavadas no subterrâneo das montanhas para tentar esconder os tesouros de ladrões.", Falsa = false},
					{Texto = "Era um parque aquático moderno repleto de tobogãs coloridos e piscinas de ondas mecânicas.", Falsa = true},
				}
			},
			{
				Nome = "Casas de Barro (Adobe)",
				Alternativas = {
					{Texto = "A maioria das moradias egípcias era feita com tijolos de barro do Nilo misturados com palha seca.", Falsa = false},
					{Texto = "As paredes grossas de barro ajudavam a manter o interior das casas fresco no calor do deserto.", Falsa = false},
					{Texto = "Eram cabanas modernas feitas de folhas de isopor e janelas de vidro à prova de bala.", Falsa = true},
				}
			},
			{
				Nome = "O Legado do Antigo Egito",
				Alternativas = {
					{Texto = "O fascínio pelas pirâmides, pelas múmias e pelos templos do Egito atrai milhões de pessoas até hoje.", Falsa = false},
					{Texto = "Seus conhecimentos de geometria, irrigação, arte e astronomia influenciaram muitas civilizações.", Falsa = false},
					{Texto = "O Egito Antigo nunca existiu na realidade e foi uma história inventada para um desenho animado.", Falsa = true},
				}
			}
		}
	},
 [3] = {
 Dados = {
 {
 Nome = "Esparta",
 Alternativas = {
 {Texto = "A cidade era militar e proibia qualquer tipo de exército ou treinamento militar.", Falsa = true},
 {Texto = "Localizada na península do Peloponeso.", Falsa = false},
 {Texto = "Sistema político baseado na diarquia (dois reis).", Falsa = false}
 }
 },
 {
 Nome = "Atenas",
 Alternativas = {
 {Texto = "Criadora da democracia direta.", Falsa = false},
 {Texto = "O voto era permitido a todos, incluindo mulheres e escravos.", Falsa = true},
 {Texto = "Grande foco na filosofia, artes e teatro.", Falsa = false}
 }
 },
 {
 Nome = "Império de Alexandre",
 Alternativas = {
 {Texto = "Propagou a cultura grega pelo oriente (Helenismo).", Falsa = false},
 {Texto = "Fundou diversas cidades com o nome de Alexandria.", Falsa = false},
 {Texto = "Alexandre foi derrotado por Júlio César na Batalha de Roma.", Falsa = true}
 }
 }
 }
 },
 [4] = {
 Dados = {
 {
 Nome = "República Romana",
 Alternativas = {
 {Texto = "Período de grande expansão territorial pelo Mediterrâneo.", Falsa = false},
 {Texto = "O Senado era a principal instituição política.", Falsa = false},
 {Texto = "Os imperadores eram escolhidos por sorteio entre os plebeus.", Falsa = true}
 }
 },
 {
 Nome = "Império Romano",
 Alternativas = {
 {Texto = "Estabeleceu a Pax Romana, um período de relativa estabilidade.", Falsa = false},
 {Texto = "Oficializou o Cristianismo como religião do Estado no século IV.", Falsa = false},
 {Texto = "Aboliu a escravidão logo no primeiro ano de sua fundação.", Falsa = true}
 }
 },
 {
 Nome = "Invasões Bárbaras",
 Alternativas = {
 {Texto = "Grupos como Visigodos e Vândalos pressionaram as fronteiras.", Falsa = false},
 {Texto = "O Império Romano do Ocidente caiu em 476 d.C.", Falsa = false},
 {Texto = "Os bárbaros destruíram todos os livros existentes no mundo.", Falsa = true}
 }
 }
 }
 },
 [5] = {
 Dados = {
 {
 Nome = "Império Carolíngio",
 Alternativas = {
 {Texto = "Carlos Magno foi coroado pelo Papa no Natal do ano 800.", Falsa = false},
 {Texto = "Incentivou o renascimento das artes e da educação.", Falsa = false},
 {Texto = "Foi o primeiro império a utilizar o avião em combate.", Falsa = true}
 }
 },
 {
 Nome = "Império Bizantino",
 Alternativas = {
 {Texto = "A língua oficial era o latim, e a religião era o budismo.", Falsa = true},
 {Texto = "Sobreviveu por mil anos após a queda de Roma.", Falsa = false},
 {Texto = "Capital estratégica localizada entre a Europa e a Ásia.", Falsa = false}
 }
 },
 {
 Nome = "Surgimento do Islã",
 Alternativas = {
 {Texto = "Início da contagem do calendário islâmico com a Hégira.", Falsa = false},
 {Texto = "Maomé é considerado o último profeta.", Falsa = false},
 {Texto = "A religião surgiu na região onde hoje fica a França.", Falsa = true}
 }
 }
 }
 },
 [6] = {
 Dados = {
 {
 Nome = "Cruzadas",
 Alternativas = {
 {Texto = "Foram expedições religiosas e militares contra os muçulmanos.", Falsa = false},
 {Texto = "Resultaram na conquista definitiva e permanente de Jerusalém pelos cristãos.", Falsa = true},
 {Texto = "Abriram caminho para produtos orientais na Europa.", Falsa = false}
 }
 },
 {
 Nome = "Cavalaria Medieval",
 Alternativas = {
 {Texto = "Código de honra focado na lealdade e proteção dos fracos.", Falsa = false},
 {Texto = "Os cavaleiros eram sempre de origem camponesa e pobre.", Falsa = true},
 {Texto = "O treinamento começava na infância, como pagens e escudeiros.", Falsa = false}
 }
 },
 {
 Nome = "Renascimento Comercial",
 Alternativas = {
 {Texto = "Surgimento de feiras e cidades (burgos).", Falsa = false},
 {Texto = "O uso da moeda voltou a ser comum na Europa.", Falsa = false},
 {Texto = "As rotas comerciais eram feitas exclusivamente por teletransporte.", Falsa = true}
 }
 }
 }
 },
 [7] = {
 Dados = {
 {
 Nome = "Renascimento",
 Alternativas = {
 {Texto = "Valorização da ciência e da observação da natureza.", Falsa = false},
 {Texto = "Teve a Itália como seu principal foco inicial.", Falsa = false},
 {Texto = "Defendia que a Igreja deveria controlar toda a produção artística.", Falsa = true}
 }
 },
 {
 Nome = "Reforma Protestante",
 Alternativas = {
 {Texto = "João Calvino defendeu a teoria da predestinação.", Falsa = false},
 {Texto = "A Bíblia passou a ser traduzida para línguas locais.", Falsa = false},
 {Texto = "Martinho Lutero foi apoiado pelo Papa para dividir a igreja.", Falsa = true}
 }
 },
 {
 Nome = "Absolutismo",
 Alternativas = {
 {Texto = "O rei detinha o poder total, muitas vezes justificado pelo 'Direito Divino'.", Falsa = false},
 {Texto = "Luís XIV, o 'Rei Sol', foi o maior símbolo deste regime.", Falsa = false},
 {Texto = "O poder do rei era limitado por uma internet livre e democrática.", Falsa = true}
 }
 }
 }
 },
 [8] = {
 Dados = {
 {
 Nome = "Revolução Industrial",
 Alternativas = {
 {Texto = "Começou na Inglaterra no século XVIII.", Falsa = false},
 {Texto = "Melhorou instantaneamente a vida de todos os operários, acabando com a pobreza.", Falsa = true},
 {Texto = "Invenção da locomotiva e do tear mecânico.", Falsa = false}
 }
 },
 {
 Nome = "Revolução Francesa",
 Alternativas = {
 {Texto = "Extinguiu os privilégios da nobreza e do clero.", Falsa = false},
 {Texto = "Terminou com a ascensão de Napoleão Bonaparte.", Falsa = false},
 {Texto = "A rainha Maria Antonieta liderou o exército revolucionário.", Falsa = true}
 }
 },
 {
 Nome = "Independência do Brasil",
 Alternativas = {
 {Texto = "Ocorreu em 1822 através de D. Pedro I.", Falsa = false},
 {Texto = "O Brasil tornou-se uma república democrática imediatamente após o grito do Ipiranga.", Falsa = true},
 {Texto = "Foi um processo que manteve a monarquia como forma de governo.", Falsa = false}
 }
 }
 }
 },
 [9] = {
 Dados = {
 {
 Nome = "1ª Guerra Mundial",
 Alternativas = {
 {Texto = "Ficou conhecida como a 'Guerra de Trincheiras'.", Falsa = false},
 {Texto = "Terminou com o Tratado de Versalhes.", Falsa = false},
 {Texto = "Foi causada por uma disputa por petróleo na Lua.", Falsa = true}
 }
 },
 {
 Nome = "Revolução Russa",
 Alternativas = {
 {Texto = "Derrubou o regime dos Czares.", Falsa = false},
 {Texto = "Implantou o primeiro estado socialista do mundo.", Falsa = false},
 {Texto = "A Rússia tornou-se uma monarquia aliada da Inglaterra após 1917.", Falsa = true}
 }
 },
 {
 Nome = "2ª Guerra Mundial",
 Alternativas = {
 {Texto = "Envolveu o uso de porta-aviões e radares.", Falsa = false},
 {Texto = "Começou com a invasão da Polônia pela Alemanha em 1939.", Falsa = false},
 {Texto = "Os Beatles foram os principais generais britânicos na guerra.", Falsa = true}
 }
 }
 }
 },
 [10] = {
 Dados = {
 {
 Nome = "Guerra Fria",
 Alternativas = {
 {Texto = "Divisão do mundo entre o bloco capitalista e o socialista.", Falsa = false},
 {Texto = "Nunca houve um combate direto entre EUA e URSS.", Falsa = false},
 {Texto = "Foi um período de paz absoluta sem nenhuma guerra regional.", Falsa = true}
 }
 },
 {
 Nome = "Corrida Espacial",
 Alternativas = {
 {Texto = "Os EUA foram os primeiros a enviar um satélite artificial, o Sputnik.", Falsa = true},
 {Texto = "Neil Armstrong foi o primeiro homem a pisar na Lua.", Falsa = false},
 {Texto = "A cadela Laika foi o primeiro ser vivo em órbita.", Falsa = false}
 }
 },
 {
 Nome = "Atentados de 11 de Setembro",
 Alternativas = {
 {Texto = "Ataques terroristas contra as Torres Gêmeas e o Pentágono.", Falsa = false},
 {Texto = "Levou à criação de leis de segurança mais rígidas em aeroportos mundiais.", Falsa = false},
 {Texto = "Os ataques foram realizados por piratas vikings que buscavam ouro.", Falsa = true}
 }
 }
 }
 }
 }
}

return QuizBancoQuestoes
