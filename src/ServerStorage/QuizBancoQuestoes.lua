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
 Nome = "África do Sul",
 Alternativas = {
 {Texto = "É o único país do mundo que possui três cidades que dividem o título de capital.", Falsa = false},
 {Texto = "O país detém cerca de 80% das reservas de platina do planeta.", Falsa = false},
 {Texto = "É o maior produtor e exportador mundial de arroz.", Falsa = true}
 }
 },
 {
 Nome = "Índia",
 Alternativas = {
 {Texto = "É um dos maiores produtores de arroz do mundo.", Falsa = false},
 {Texto = "Possui uma das maiores populações do planeta.", Falsa = false},
 {Texto = "É o país com menor diversidade cultural da Ásia.", Falsa = true}
 }
 },
 {
 Nome = "Vietnã",
 Alternativas = {
 {Texto = "Está entre os maiores exportadores de arroz do mundo.", Falsa = false},
 {Texto = "Possui clima tropical em grande parte do território.", Falsa = false},
 {Texto = "É um país sem acesso ao mar.", Falsa = true}
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
 Nome = "Sumérios",
 Alternativas = {
 {Texto = "Inventaram a escrita cuneiforme.", Falsa = false},
 {Texto = "Localizavam-se no sul da Mesopotâmia.", Falsa = false},
 {Texto = "Construíram as pirâmides de Gizé para proteger os faraós.", Falsa = true}
 }
 },
 {
 Nome = "Egípcios",
 Alternativas = {
 {Texto = "As grandes pirâmides de Gizé foram construídas para proteger os faraós vivos de invasões.", Falsa = true},
 {Texto = "O faraó era visto como uma divindade viva.", Falsa = false},
 {Texto = "Desenvolveram técnicas avançadas de irrigação com o Rio Nilo.", Falsa = false}
 }
 },
 {
 Nome = "Hebreus",
 Alternativas = {
 {Texto = "Foi a primeira grande civilização a praticar o monoteísmo.", Falsa = false},
 {Texto = "Originários da região da Palestina.", Falsa = false},
 {Texto = "Eram conhecidos por construir os maiores jardins suspensos do mundo.", Falsa = true}
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
