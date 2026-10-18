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
 {Texto = "É o país com a maior rede de rodovias sem limite de velocidade do mundo (as Autobahns).", Falsa = false},
 {Texto = "O primeiro livro impresso do mundo (a Bíblia de Gutenberg) foi produzido lá.", Falsa = false},
 {Texto = "É o único país da Europa que não possui nenhuma costa ou saída para o mar.", Falsa = true}
 }
 },
 {
 Nome = "França",
 Alternativas = {
 {Texto = "É o país mais visitado do mundo.", Falsa = false},
 {Texto = "A Torre Eiffel fica localizada em sua capital.", Falsa = false},
 {Texto = "É o único país da Europa que possui duas capitais oficiais.", Falsa = true}
 }
 },
 {
 Nome = "Espanha",
 Alternativas = {
 {Texto = "É famosa pela festa La Tomatina.", Falsa = false},
 {Texto = "Está localizada na Península Ibérica.", Falsa = false},
 {Texto = "É o único país do mundo onde se fala espanhol.", Falsa = true}
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
 Nome = "Paleolítico",
 Alternativas = {
 {Texto = "Período em que o ser humano dominou o fogo.", Falsa = false},
 {Texto = "Os homens viviam em cidades estado cercadas por muros.", Falsa = true},
 {Texto = "A arte rupestre era usada para registrar o cotidiano.", Falsa = false}
 }
 },
 {
 Nome = "Neolítico",
 Alternativas = {
 {Texto = "Início da sedentarização e da agricultura.", Falsa = false},
 {Texto = "Surgimento da tecelagem e da cerâmica.", Falsa = false},
 {Texto = "Foi o período em que os humanos conviveram com os dinossauros.", Falsa = true}
 }
 },
 {
 Nome = "Idade dos Metais",
 Alternativas = {
 {Texto = "A invenção da escrita marca o fim deste período.", Falsa = true},
 {Texto = "Desenvolvimento da metalurgia do bronze e do ferro.", Falsa = false},
 {Texto = "Aparecimento das primeiras organizações políticas complexas.", Falsa = false}
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
