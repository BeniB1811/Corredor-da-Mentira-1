using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class GeoLevels3to6 {
    struct Alt {
        public string T;
        public bool F;
        public Alt(string t, bool f) { T = t; F = f; }
    }
    struct Q {
        public string Nome;
        public Alt[] Alts;
        public Q(string nome, Alt[] alts) { Nome = nome; Alts = alts; }
    }

    static void Main() {
        var levels = new Dictionary<int, List<Q>>();
        levels[3] = new List<Q>();
        levels[4] = new List<Q>();
        levels[5] = new List<Q>();
        levels[6] = new List<Q>();

        // ==========================================
        // NIVEL 3: EUROPA FASCINANTE (50 Questoes)
        // ==========================================
        var l3 = levels[3];
        l3.Add(new Q("A Torre de Pisa", new Alt[] {
            new Alt("É um famoso campanário de mármore na Itália conhecido mundialmente por sua inclinação.", false),
            new Alt("Começou a inclinar logo durante a sua construção devido ao solo mole e arenoso.", false),
            new Alt("Foi construída torta de propósito para servir como escorregador aquático infantil.", true)
        }));
        l3.Add(new Q("Os Canais de Veneza", new Alt[] {
            new Alt("Veneza é uma cidade italiana histórica construída sobre mais de cem ilhotas em uma lagoa.", false),
            new Alt("As pessoas se locomovem pela cidade principalmente em barcos e gôndolas tradicionais.", false),
            new Alt("É famosa por suas rodovias largas repletas de carros esportivos e caminhões velozes.", true)
        }));
        l3.Add(new Q("O Big Ben em Londres", new Alt[] {
            new Alt("Big Ben é o famoso apelido do grande sino instalado na torre do Palácio de Westminster.", false),
            new Alt("A torre do relógio é um dos símbolos arquitetônicos mais conhecidos do Reino Unido.", false),
            new Alt("É um relógio de cuco de madeira feito para anunciar a hora do almoço com passarinhos.", true)
        }));
        l3.Add(new Q("O Museu do Louvre", new Alt[] {
            new Alt("Localizado em Paris, na França, é o museu de arte mais visitado de todo o planeta Terra.", false),
            new Alt("Abriga obras de arte mundialmente famosas como o quadro da Mona Lisa de Leonardo da Vinci.", false),
            new Alt("É um museu de animais pré-históricos vivos que andam soltos entre os turistas.", true)
        }));
        l3.Add(new Q("A Catedral da Sagrada Família", new Alt[] {
            new Alt("Fica em Barcelona, na Espanha, projetada pelo genial arquiteto Antoni Gaudí.", false),
            new Alt("Sua construção começou em 1882 e continua em andamento com torres monumentais.", false),
            new Alt("Foi construída inteiramente com blocos de gelo do Polo Norte e derrete todo verão.", true)
        }));
        l3.Add(new Q("A Acrópole de Atenas", new Alt[] {
            new Alt("É uma colina rochosa na capital da Grécia que abriga monumentos clássicos como o Partenon.", false),
            new Alt("Foi o centro religioso e cívico da civilização grega há mais de 2.400 anos.", false),
            new Alt("Foi inaugurada no ano 2020 para servir como estádio de futebol na Europa.", true)
        }));
        l3.Add(new Q("O Castelo de Neuschwanstein", new Alt[] {
            new Alt("Fica situado no alto de montanhas na Alemanha e inspirou o castelo da Cinderela da Disney.", false),
            new Alt("Foi construído no século XIX pelo rei Luís II da Baviera cercado por belas florestas.", false),
            new Alt("É um castelo inflável de plástico montado no quintal de uma escola pública.", true)
        }));
        l3.Add(new Q("O Vaticano", new Alt[] {
            new Alt("É o menor país independente do mundo em território e população, encravado em Roma.", false),
            new Alt("É a sede da Igreja Católica e residência oficial do Papa, guardada pela Guarda Suíça.", false),
            new Alt("É o maior país do continente europeu e possui dezenas de portos de navios petroleiros.", true)
        }));
        l3.Add(new Q("Os Alpes Suíços", new Alt[] {
            new Alt("Cadeia montanhosa europeia famosa por picos nevados, pistas de esqui e chalés alpinos.", false),
            new Alt("O monte Matterhorn é um de seus picos mais famosos em formato de pirâmide rochosa.", false),
            new Alt("Ficam localizados no meio da floresta tropical brasileira da Amazônia.", true)
        }));
        l3.Add(new Q("Moinhos e Tulipas da Holanda", new Alt[] {
            new Alt("A Holanda é famosa por seus moinhos de vento históricos que drenavam águas das terras baixas.", false),
            new Alt("Seus coloridos campos de tulipas atraem milhões de turistas durante a primavera europeia.", false),
            new Alt("Os moinhos de vento foram construídos para gerar neve artificial na selva africana.", true)
        }));

        l3.Add(new Q("As Touradas e o Flamenco", new Alt[] {
            new Alt("O flamenco é uma dança e música tradicional espanhola marcada pelo ritmo do sapateado.", false),
            new Alt("As touradas tradicionais vêm sendo cada vez mais questionadas e proibidas em várias regiões.", false),
            new Alt("O flamenco é uma luta marcial asiática praticada por monges que usam espadas de bambu.", true)
        }));
        l3.Add(new Q("A Cidade de Praga", new Alt[] {
            new Alt("É a capital histórica da República Tcheca, conhecida como a cidade das cem cúpulas douradas.", false),
            new Alt("Sua famosa Ponte Carlos sobre o rio Moldava é repleta de estátuas medievais de pedra.", false),
            new Alt("Fica situada no meio do oceano Pacífico e não possui pontes nem construções antigas.", true)
        }));
        l3.Add(new Q("O Rio Danúbio", new Alt[] {
            new Alt("É o segundo rio mais longo da Europa, nascendo na Alemanha e desaguando no Mar Negro.", false),
            new Alt("Atravessa ou faz fronteira com dez países europeus e banha capitais como Viena e Budapeste.", false),
            new Alt("É um rio subterrâneo que corre por dentro da crosta do planeta sem ver a luz do sol.", true)
        }));
        l3.Add(new Q("A Torre Eiffel", new Alt[] {
            new Alt("Foi construída em Paris em 1889 para celebrar o centenário da Revolução Francesa.", false),
            new Alt("Tem mais de trezentos metros de altura e foi projetada pelo engenheiro Gustave Eiffel.", false),
            new Alt("Foi construída inteiramente com troncos ocos de bambu amarrados com cipó vegetal.", true)
        }));
        l3.Add(new Q("A Ilha de Creta", new Alt[] {
            new Alt("É a maior das ilhas gregas, situada nas águas quentes do sul do Mar Egeu.", false),
            new Alt("Foi o berço da antiga civilização minoica e da famosa lenda mitológica do Minotauro.", false),
            new Alt("É uma geleira coberta por neve perpétua localizada dentro do Círculo Polar Ártico.", true)
        }));
        l3.Add(new Q("O Estádio de Wembley", new Alt[] {
            new Alt("Localizado em Londres, é um dos estádios de futebol mais históricos e famosos do planeta.", false),
            new Alt("Seu arco monumental de aço sustenta o teto e pode ser avistado de vários pontos da cidade.", false),
            new Alt("Fica localizado no interior da floresta do Congo no continente africano.", true)
        }));
        l3.Add(new Q("A Cidade de Amsterdã", new Alt[] {
            new Alt("É a capital dos Países Baixos, famosa por sua intensa malha de canais e pontes charmosas.", false),
            new Alt("Possui mais bicicletas circulando em suas ruas planas do que automóveis particulares.", false),
            new Alt("É uma cidade construída em cima de uma montanha rochosa a 4 mil metros de altitude.", true)
        }));
        l3.Add(new Q("O Rio Tâmisa", new Alt[] {
            new Alt("É o principal rio que corta a cidade histórica de Londres até desaguar no Mar do Norte.", false),
            new Alt("Pontes famosas como a Tower Bridge foram erguidas sobre suas águas para ligar a cidade.", false),
            new Alt("É um rio de chocolate ao leite onde crianças nadam com boias aos sábados.", true)
        }));
        l3.Add(new Q("A Culinária Italiana", new Alt[] {
            new Alt("Pratos como pizza e espaguete tornaram-se populares no mundo inteiro a partir da Itália.", false),
            new Alt("O azeite de oliva e o queijo parmesão são ingredientes nobres de suas receitas tradicionais.", false),
            new Alt("A refeição básica tradicional dos italianos é comer carne de baleia crua no café da manhã.", true)
        }));
        l3.Add(new Q("A Cidade de Berlim", new Alt[] {
            new Alt("É a capital da Alemanha, marcada pelo histórico Portão de Brandemburgo no centro urbano.", false),
            new Alt("Durante a Guerra Fria, a cidade foi dividida ao meio pelo famoso e sombrio Muro de Berlim.", false),
            new Alt("Fica localizada em uma ilha deserta do Caribe onde o idioma oficial é o japonês.", true)
        }));

        l3.Add(new Q("A Floresta de Sherwood", new Alt[] {
            new Alt("Famosa floresta de carvalhos na Inglaterra ligada às lendas do arqueiro Robin Hood.", false),
            new Alt("Abriga árvores antiquíssimas como o lendário carvalho Major Oak de centenas de anos.", false),
            new Alt("Fica no meio do deserto do Atacama e é feita de cactos de espinhos gigantes.", true)
        }));
        l3.Add(new Q("As Terras Altas da Escócia", new Alt[] {
            new Alt("Região montanhosa famosa por vales verdes, lagos profundos chamados lochs e castelos.", false),
            new Alt("O lago Loch Ness é mundialmente conhecido pelas famosas lendas de seu monstro marinho.", false),
            new Alt("É uma praia tropical com coqueiros onde a temperatura média é de 42 graus o ano todo.", true)
        }));
        l3.Add(new Q("A Estrada Real de Edimburgo", new Alt[] {
            new Alt("É a rua histórica que liga o imponente Castelo de Edimburgo ao Palácio de Holyrood.", false),
            new Alt("Suas calçadas de pedra e becos medievais preservam séculos de história da Escócia.", false),
            new Alt("É uma pista de decolagem de aviões a jato no centro de um aeroporto espacial.", true)
        }));
        l3.Add(new Q("O Parque Güell", new Alt[] {
            new Alt("Parque colorido em Barcelona com bancos ondulados de cerâmica projetados por Antoni Gaudí.", false),
            new Alt("É considerado Patrimônio Mundial da UNESCO por sua arquitetura orgânica inspirada na natureza.", false),
            new Alt("É uma fábrica fechada de cimento que proíbe a entrada de turistas e visitantes.", true)
        }));
        l3.Add(new Q("A Torre de Belém", new Alt[] {
            new Alt("Monumento histórico localizado em Lisboa, na foz do rio Tejo, construído no século XVI.", false),
            new Alt("Servia de fortaleza militar e ponto de partida e chegada das caravelas portuguesas.", false),
            new Alt("Foi construída na cidade de Tóquio, no Japão, para transmitir sinais de televisão.", true)
        }));
        l3.Add(new Q("O Mosteiro dos Jerónimos", new Alt[] {
            new Alt("Obra-prima do estilo manuelino português em Lisboa, onde está sepultado Vasco da Gama.", false),
            new Alt("Seus arcos de pedra esculpida retratam cordas, nós e elementos marítimos das navegações.", false),
            new Alt("É um shopping center moderno inaugurado em 2022 com pistas de kart elétrico.", true)
        }));
        l3.Add(new Q("A Cidade de Veneza e as Marés", new Alt[] {
            new Alt("O fenômeno da 'Acqua Alta' faz as águas da lagoa subirem periodicamente inundando as praças.", false),
            new Alt("Passarelas elevadas de madeira são montadas para os pedestres caminharem sobre a água.", false),
            new Alt("A cidade é evacuada por foguetes espaciais sempre que cai uma gota de garoa fina.", true)
        }));
        l3.Add(new Q("A Cidade de Viena", new Alt[] {
            new Alt("Capital da Áustria, conhecida pelos grandiosos palácios imperiais como o Palácio de Schönbrunn.", false),
            new Alt("Foi a casa de grandes gênios da música clássica mundial como Mozart e Beethoven.", false),
            new Alt("Fica situada nas profundezas de uma mina de carvão subterrânea sem janelas.", true)
        }));
        l3.Add(new Q("O Estreito de Bósforo", new Alt[] {
            new Alt("Passagem de água em Istambul que divide a porção europeia da porção asiática da Turquia.", false),
            new Alt("Conecta as águas do Mar Negro ao Mar de Mármara com tráfego intenso de navios de carga.", false),
            new Alt("É uma grande cachoeira que cai em direção ao centro da Terra e nunca mais volta.", true)
        }));
        l3.Add(new Q("A Ilha de Santorini", new Alt[] {
            new Alt("Famosa ilha grega com casas brancas e cúpulas azuis construídas no alto de falésias vulcânicas.", false),
            new Alt("A caldeira marítima da ilha foi formada por uma erupção vulcânica colossal na antiguidade.", false),
            new Alt("É uma planície gelada habitada exclusivamente por pinguins e ursos polares brancos.", true)
        }));

        l3.Add(new Q("A Cidade de Dubrovnik", new Alt[] {
            new Alt("Cidade histórica na costa da Croácia banhada pelo Mar Adriático, cercada por muralhas medievais.", false),
            new Alt("Suas fortificações de pedra e telhados de terracota serviram de cenário para várias séries e filmes.", false),
            new Alt("É um parque de trailers flutuantes no meio das geleiras frias do Pólo Norte.", true)
        }));
        l3.Add(new Q("O Palácio de Versalhes", new Alt[] {
            new Alt("Grandioso palácio real perto de Paris famoso por seus salões dourados e jardins simétricos.", false),
            new Alt("Foi a residência oficial dos reis da França como Luís XIV antes da Revolução Francesa.", false),
            new Alt("Era uma cabana rústica de pescadores feita com palha de milho e bambu fino.", true)
        }));
        l3.Add(new Q("O Monte Branco (Mont Blanc)", new Alt[] {
            new Alt("É a montanha mais alta dos Alpes e da Europa Ocidental, na fronteira entre França e Itália.", false),
            new Alt("Um túnel rodoviário histórico com mais de onze quilômetros atravessa a montanha por baixo.", false),
            new Alt("É uma duna de areia móvel que viaja pelo deserto empurrada pelo vento sul.", true)
        }));
        l3.Add(new Q("A Cidade de Munique", new Alt[] {
            new Alt("É a capital da Baviera, no sul da Alemanha, famosa por sua arquitetura e tradições culturais.", false),
            new Alt("Sedia anualmente a Oktoberfest, a mais famosa festa tradicional de cultura alemã do mundo.", false),
            new Alt("Fica localizada na costa ensolarada do Oceano Índico cercada por corais tropicais.", true)
        }));
        l3.Add(new Q("A Cidade de Sevilha", new Alt[] {
            new Alt("É uma cidade histórica do sul da Espanha famosa pela imensa torre sineira da Giralda.", false),
            new Alt("Apresenta forte herança arquitetônica árabe misturada à arte cristã em seus palácios.", false),
            new Alt("É a capital da Nova Zelândia e onde vivem todos os filhotes de cangurus selvagens.", true)
        }));
        l3.Add(new Q("O Canal da Mancha", new Alt[] {
            new Alt("É o braço de mar que separa a costa sul da Inglaterra do norte do território francês.", false),
            new Alt("O Eurotúnel submarino permite que trens de passageiros atravessem por baixo da água em minutos.", false),
            new Alt("É um canal artificial feito de vidro transparente onde tubarões gigantes pulam fora.", true)
        }));
        l3.Add(new Q("A Cidade de Edimburgo", new Alt[] {
            new Alt("Capital da Escócia, famosa pelo seu castelo histórico imponente erguido sobre uma rocha vulcânica.", false),
            new Alt("Sua cidade velha medieval e a cidade nova neoclássica são Patrimônios da Humanidade.", false),
            new Alt("Fica situada no interior da Floresta Amazônica ao lado do Rio Negro no Brasil.", true)
        }));
        l3.Add(new Q("A Ilha de Capri", new Alt[] {
            new Alt("É uma charmosa ilha no Golfo de Nápoles, na Itália, famosa por suas cavernas marinhas.", false),
            new Alt("A Gruta Azul é conhecida pelo tom azul brilhante que a luz solar produz dentro da caverna d'água.", false),
            new Alt("É uma ilha vulcânica habitada exclusivamente por elefantes africanos selvagens.", true)
        }));
        l3.Add(new Q("A Cidade de Florença", new Alt[] {
            new Alt("Considerada o berço do Renascimento italiano, repleta de palácios, estátuas e pontes antigas.", false),
            new Alt("A impressionante cúpula de tijolos da Catedral de Santa Maria del Fiore foi erguida por Brunelleschi.", false),
            new Alt("É uma cidade flutuante no espaço que orbita ao redor do planeta Saturno.", true)
        }));
        l3.Add(new Q("O Parque Nacional dos Lagos de Plitvice", new Alt[] {
            new Alt("Fica na Croácia e possui dezesseis lagos em degraus interligados por dezenas de cachoeiras límpidas.", false),
            new Alt("Suas águas mudam de cor entre azul e verde-turquesa de acordo com os minerais das rochas.", false),
            new Alt("É uma planície de petróleo cru onde não há nenhuma gota de água limpa ou peixes.", true)
        }));

        l3.Add(new Q("A Cidade de Lisboa", new Alt[] {
            new Alt("Capital de Portugal, famosa por suas colinas históricas percorridas pelos tradicionais bondes amarelos.", false),
            new Alt("O bairro de Belém é mundialmente conhecido pela produção dos deliciosos pastéis de nata.", false),
            new Alt("Fica localizada nas margens congeladas do Polo Norte cercada por blocos de icebergs.", true)
        }));
        l3.Add(new Q("O Castelo de Edimburgo", new Alt[] {
            new Alt("É uma antiga fortaleza que domina a vista da cidade no topo de um antigo vulcão extinto.", false),
            new Alt("Guarda as joias da coroa escocesa e a histórica Pedra do Destino usada em coroações.", false),
            new Alt("Foi construído com pneus reciclados e latas de refrigerante amassadas no ano 2000.", true)
        }));
        l3.Add(new Q("A Cidade de Copenhague", new Alt[] {
            new Alt("É a capital da Dinamarca, famosa pelos edifícios coloridos e barcos antigos no porto de Nyhavn.", false),
            new Alt("Abriga a famosa estátua de bronze da Pequena Sereia às margens do mar da cidade.", false),
            new Alt("É um povoado isolado no topo de uma árvore na floresta onde não existem ruas.", true)
        }));
        l3.Add(new Q("Os Fiordes da Islândia", new Alt[] {
            new Alt("A ilha possui fiordes dramáticos esculpidos por gelo que abrigam colônias de aves marinhas como os papagaios-do-mar.", false),
            new Alt("Vilarejos de pescadores se instalam nas enseadas protegidas contra os ventos do mar aberto.", false),
            new Alt("São rios de água morna doce com coqueirais onde nadam jacarés de água doce tropicais.", true)
        }));
        l3.Add(new Q("A Cidade de Roma", new Alt[] {
            new Alt("Apelidada de Cidade Eterna, preserva ruínas de mais de dois mil anos ao lado de bairros modernos.", false),
            new Alt("A Fontana di Trevi é uma das fontes barrocas mais famosas onde turistas jogam moedas.", false),
            new Alt("Foi fundada em 1990 para servir como estacionamento de aviões cargueiros europeus.", true)
        }));
        l3.Add(new Q("A Torre de Londres", new Alt[] {
            new Alt("Histórica fortaleza e castelo real medieval às margens do rio Tâmisa na Inglaterra.", false),
            new Alt("Abriga as valiosas Joias da Coroa britânica e é guardada pelos tradicionais guardas Yeomen.", false),
            new Alt("Foi construída com peças plásticas de brinquedo inflável em uma praça esportiva.", true)
        }));
        l3.Add(new Q("O Estádio Camp Nou", new Alt[] {
            new Alt("Localizado em Barcelona, na Espanha, é um dos maiores estádios de futebol de todo o continente europeu.", false),
            new Alt("É o estádio histórico onde craques mundiais do futebol desfilaram seu talento por décadas.", false),
            new Alt("É um campo de hóquei no gelo construído em cima de uma balsa flutuante no Ártico.", true)
        }));
        l3.Add(new Q("A Cidade de Madri", new Alt[] {
            new Alt("É a capital da Espanha, localizada no centro geográfico da Península Ibérica.", false),
            new Alt("Abriga o Palácio Real e museus de renome internacional como o Museu do Prado e o Reina Sofia.", false),
            new Alt("É uma cidade litorânea que possui praias de água salgada em frente ao palácio.", true)
        }));
        l3.Add(new Q("A Culinária Portuguesa", new Alt[] {
            new Alt("Pratos à base de bacalhau e sardinhas assadas são referências tradicionais de sua gastronomia.", false),
            new Alt("O azeite de oliva e os doces à base de ovos e amêndoas são famosos no mundo inteiro.", false),
            new Alt("A comida típica oficial do país é hambúrguer com batata frita e refrigerante de cola.", true)
        }));
        l3.Add(new Q("O Mar Báltico", new Alt[] {
            new Alt("É um mar interior no norte da Europa que banha países escandinavos, bálticos e a Polônia.", false),
            new Alt("Apresenta águas com menor quantidade de sal do que o oceano aberto devido a rios que deságuam nele.", false),
            new Alt("Fica localizado no centro da América Central cercado por florestas equatoriais quentes.", true)
        }));

        // ==========================================
        // NIVEL 4: ASIA E ORIENTE MEDIO (50 Questoes)
        // ==========================================
        var l4 = levels[4];
        l4.Add(new Q("A Grande Muralha da China", new Alt[] {
            new Alt("É uma colossal fortificação de pedra e terra que se estende por milhares de quilômetros no norte da China.", false),
            new Alt("Foi construída e reforçada ao longo de séculos para proteger as fronteiras de invasões guerreiras.", false),
            new Alt("Foi construída em uma única tarde usando tijolos de vidro transparente e luz neon.", true)
        }));
        l4.Add(new Q("O Exército de Terracota", new Alt[] {
            new Alt("É uma coleção de milhares de soldados e cavalos de argila em tamanho real enterrados na China antiga.", false),
            new Alt("Foi criado para acompanhar e proteger o primeiro imperador chinês Qin Shi Huang em seu túmulo.", false),
            new Alt("São soldadinhos de chumbo de brinquedo fabricados em fábricas de brinquedos no ano 2010.", true)
        }));
        l4.Add(new Q("O Trem-Bala Japonês (Shinkansen)", new Alt[] {
            new Alt("É uma famosa rede de trens de alta velocidade que conecta as principais cidades do Japão há décadas.", false),
            new Alt("É reconhecido no mundo por sua incrível pontualidade com atrasos médios menores que um minuto.", false),
            new Alt("É puxado por cavalos selvagens que galopam pelos trilhos de madeira da ferrovia.", true)
        }));
        l4.Add(new Q("O Taj Mahal na Índia", new Alt[] {
            new Alt("É um monumento de mármore branco construído pelo imperador Shah Jahan em memória de sua esposa.", false),
            new Alt("Fica na cidade de Agra e é considerado uma das obras de arte arquitetônicas mais belas do mundo.", false),
            new Alt("Foi construído como hangar para aviões a jato supersônicos de guerra militar moderna.", true)
        }));
        l4.Add(new Q("O Prédio Burj Khalifa", new Alt[] {
            new Alt("Localizado na cidade de Dubai, nos Emirados Árabes, é o edifício mais alto já construído pelo homem.", false),
            new Alt("Tem mais de 828 metros de altura e possui mais de cento e sessenta andares habitáveis.", false),
            new Alt("Foi construído inteiramente de madeira de pinheiro e mede menos de dez metros de altura.", true)
        }));
        l4.Add(new Q("A Cidade de Tóquio", new Alt[] {
            new Alt("É a capital do Japão e uma das maiores e mais tecnológicas áreas metropolitanas de todo o planeta.", false),
            new Alt("Mistura templos xintoístas e budistas antigos com bairros futuristas repletos de luzes e robôs.", false),
            new Alt("É um vilarejo agrícola no interior da Europa que não possui nenhuma rede elétrica.", true)
        }));
        l4.Add(new Q("O Rio Ganges na Índia", new Alt[] {
            new Alt("É o rio mais sagrado para os hindus, que acreditam que suas águas purificam a alma dos fiéis.", false),
            new Alt("Milhões de peregrinos viajam anualmente para cidades sagradas como Varanasi para se banhar nele.", false),
            new Alt("É um canal de água salgada construído em cima de um viaduto de concreto nos EUA.", true)
        }));
        l4.Add(new Q("A Cidade Antiga de Petra", new Alt[] {
            new Alt("Fica localizada na Jordânia, famosa por templos monumentais esculpidos diretamente em paredões de rocha rosa.", false),
            new Alt("Foi a capital do antigo reino dos nabateus e é uma das Novas Sete Maravilhas do Mundo moderno.", false),
            new Alt("Foi montada com placas de papelão descartadas na praia de Copacabana no Brasil.", true)
        }));
        l4.Add(new Q("Os Templos de Angkor Wat", new Alt[] {
            new Alt("Localizado no Camboja, é o maior monumento religioso do planeta Terra, erguido pela civilização khmer.", false),
            new Alt("Suas torres em forma de flor de lótus e relevos esculpidos na pedra são cercados por um fosso d'água.", false),
            new Alt("É um parque temático moderno inaugurado no ano de 2018 com tobogãs aquáticos de plástico.", true)
        }));
        l4.Add(new Q("O Urso-Panda Gigante", new Alt[] {
            new Alt("É um animal nativo das florestas montanhosas de bambu da China e símbolo mundial de conservação.", false),
            new Alt("Sua dieta é composta quase exclusivamente por talos e folhas de bambu, que come durante horas.", false),
            new Alt("É um predador marinho carnívoro que caça focas nas águas congeladas da Antártida.", true)
        }));

        l4.Add(new Q("A Cidade de Dubai", new Alt[] {
            new Alt("Famosa por ilhas artificiais no mar em formato de palmeira e luxuosos shopping centers com aquários.", false),
            new Alt("Desenvolveu-se rapidamente no meio do deserto litorâneo impulsionada pelo comércio e turismo.", false),
            new Alt("Fica localizada no topo de uma montanha de gelo no norte da Finlândia.", true)
        }));
        l4.Add(new Q("A Cidade Proibida em Pequim", new Alt[] {
            new Alt("Foi o grandioso palácio imperial das dinastias Ming e Qing na China por quase quinhentos anos.", false),
            new Alt("Possui quase mil construções tradicionais de madeira com telhados dourados e pátios monumentais.", false),
            new Alt("É um shopping center moderno subterrâneo onde crianças compram roupas esportivas.", true)
        }));
        l4.Add(new Q("A Flor de Cerejeira (Sakura)", new Alt[] {
            new Alt("A floração das cerejeiras na primavera é um dos momentos culturais e visuais mais celebrados do Japão.", false),
            new Alt("As famílias se reúnem em parques sob as árvores floridas para fazer piqueniques no ritual chamado Hanami.", false),
            new Alt("É uma planta carnívora gigante que devora pequenos macacos nas selvas africanas.", true)
        }));
        l4.Add(new Q("O Mar Cáspio", new Alt[] {
            new Alt("Apesar de levar o nome de mar, é o maior corpo de água fechado do mundo, considerado um imenso lago.", false),
            new Alt("Fica situado entre a Europa e a Ásia, banhando países como Rússia, Cazaquistão e Irã.", false),
            new Alt("É uma lagoa de água doce potável com apenas cinco metros de largura total.", true)
        }));
        l4.Add(new Q("O Arquipélago da Indonésia", new Alt[] {
            new Alt("É o maior país arquipélago do mundo, formado por mais de dezessete mil ilhas tropicais.", false),
            new Alt("Abriga animais raros como o dragão-de-komodo e grandes florestas habitadas por orangotangos.", false),
            new Alt("É um país sem mar localizado bem no meio das montanhas frias da Europa Central.", true)
        }));
        l4.Add(new Q("O Dragão-de-Komodo", new Alt[] {
            new Alt("É a maior espécie de lagarto do mundo atual, podendo passar de três metros de comprimento na Indonésia.", false),
            new Alt("Possui saliva com bactérias e dentes afiados que usa para abater presas nas ilhas onde vive.", false),
            new Alt("Tem asas de couro e voa cuspindo labaredas de fogo pela boca como nas lendas.", true)
        }));
        l4.Add(new Q("A Cidade-Estado de Singapura", new Alt[] {
            new Alt("É uma moderna nação insular no Sudeste Asiático, famosa por sua limpeza, organização e jardins futuristas.", false),
            new Alt("O parque Gardens by the Bay possui gigantescas árvores artificiais cobertas por plantas vivas.", false),
            new Alt("É uma tribo de caçadores nômades que vivem em cabanas de palha sem eletricidade.", true)
        }));
        l4.Add(new Q("A Culinária Japonesa", new Alt[] {
            new Alt("Pratos tradicionais incluem o sushi com peixes frescos e algas, sashimis e sopas de lámen quentes.", false),
            new Alt("O arroz especial e o molho de soja (shoyu) são itens essenciais em quase todas as refeições.", false),
            new Alt("O prato principal da culinária japonesa é feijoada de feijão preto com farofa de mandioca.", true)
        }));
        l4.Add(new Q("As Especiarias da Índia", new Alt[] {
            new Alt("A Índia é historicamente famosa pelo cultivo e comércio de especiarias como pimenta, canela e açafrão.", false),
            new Alt("Essas especiarias aromáticas motivaram as Grandes Navegações europeias dos séculos XV e XVI.", false),
            new Alt("As especiarias indianas eram pedras de gelo trazidas de foguetes do espaço sideral.", true)
        }));
        l4.Add(new Q("O Bairro de Harajuku em Tóquio", new Alt[] {
            new Alt("É mundialmente famoso como o coração da cultura jovem, moda excêntrica e personagens de cosplay no Japão.", false),
            new Alt("Suas ruas são repletas de lojas de doces coloridos, crepes artesanais e roupas criativas.", false),
            new Alt("É uma mina de carvão industrial onde apenas tratores pesados podem trafegar.", true)
        }));

        l4.Add(new Q("A Mesquita Azul em Istambul", new Alt[] {
            new Alt("Famosa mesquita histórica na Turquia, conhecida por seus seis minaretes esguios e azulejos azuis no interior.", false),
            new Alt("Fica situada bem em frente à antiga basílica de Santa Sofia no centro histórico da cidade.", false),
            new Alt("Foi construída com blocos de gelo do Ártico e funciona como uma pista de patinação.", true)
        }));
        l4.Add(new Q("O Estreito de Malaca", new Alt[] {
            new Alt("É uma das rotas marítimas comerciais mais movimentadas e estratégicas do planeta, no Sudeste Asiático.", false),
            new Alt("Conecta as rotas do Oceano Índico às rotas do Oceano Pacífico entre a Malásia e a Indonésia.", false),
            new Alt("É um pequeno canal de natação infantil no jardim de uma casa em Paris.", true)
        }));
        l4.Add(new Q("A Cidade de Seul", new Alt[] {
            new Alt("Capital da Coreia do Sul, combina palácios reais da dinastia Joseon com arranha-céus futuristas.", false),
            new Alt("É um polo global de cultura pop moderna com a febre do K-pop e séries de televisão mundiais.", false),
            new Alt("É uma ilha no Caribe onde a língua nativa oficial falada por todos é o português.", true)
        }));
        l4.Add(new Q("Os Rios Tigre e Eufrates", new Alt[] {
            new Alt("Nascem nas montanhas da Turquia e correm pelo Oriente Médio até desaguar no Golfo Pérsico.", false),
            new Alt("Suas margens férteis abrigaram as primeiras civilizações da história na antiga Mesopotâmia.", false),
            new Alt("São rios de água salgada congelada que ficam localizados dentro do continente da Antártida.", true)
        }));
        l4.Add(new Q("A Torre de Xangai", new Alt[] {
            new Alt("É um dos arranha-céus mais altos e impressionantes do mundo, com formato espiral retorcido na China.", false),
            new Alt("Possui elevadores ultrarrápidos que sobem dezenas de andares em poucos segundos até o mirante.", false),
            new Alt("Foi esculpida em um único tronco de árvore oco por carpinteiros medievais.", true)
        }));
        l4.Add(new Q("O Monte Ararat", new Alt[] {
            new Alt("É um imponente vulcão adormecido com topo coberto de neve perpétua localizado no leste da Turquia.", false),
            new Alt("Segundo antigas tradições religiosas, foi na região de suas montanhas que a Arca de Noé teria repousado.", false),
            new Alt("É uma ilha tropical do Caribe cercada por palmeiras onde nunca nevou na história.", true)
        }));
        l4.Add(new Q("O Deserto da Arábia", new Alt[] {
            new Alt("Vasto deserto de dunas de areia dourada que ocupa a maior parte da Península Arábica.", false),
            new Alt("Abriga o Rub' al-Khali, considerado a maior área contínua de deserto de areia do planeta Terra.", false),
            new Alt("É uma floresta densa e fria onde cai neve durante todos os doze meses do ano.", true)
        }));
        l4.Add(new Q("A Ilha de Bali", new Alt[] {
            new Alt("Famosa ilha da Indonésia conhecida por seus templos hindus, terraços de arroz verdejantes e praias.", false),
            new Alt("É um dos destinos turísticos mais procurados da Ásia por sua rica cultura artística e danças.", false),
            new Alt("Fica localizada no Círculo Polar Ártico e é habitada apenas por ursos-polares brancos.", true)
        }));
        l4.Add(new Q("A Culinária Chinesa", new Alt[] {
            new Alt("Usa ingredientes frescos preparados em panelas woks redondas em alta temperatura de fogo.", false),
            new Alt("O uso de pauzinhos de madeira chamados hashis para se alimentar é uma tradição secular no país.", false),
            new Alt("As pessoas se alimentam exclusivamente engolindo pílulas plásticas com sabor de água morna.", true)
        }));
        l4.Add(new Q("O Rio Mekong", new Alt[] {
            new Alt("Grande rio do Sudeste Asiático que atravessa países como China, Laos, Tailândia e Vietnã.", false),
            new Alt("Suas águas sustentam milhões de pessoas com mercados flutuantes e grandes plantações de arroz.", false),
            new Alt("É um riacho raso que seca todo dia às duas da tarde para passagem de carros.", true)
        }));

        l4.Add(new Q("O Trem de Levitação Magnética (Maglev)", new Alt[] {
            new Alt("Em cidades como Xangai, na China, trens flutuam sobre os trilhos por magnetismo a mais de 400 km/h.", false),
            new Alt("Como não há atrito físico de rodas com o metal do trilho, o trem se move com extrema suavidade.", false),
            new Alt("O trem é puxado no ar por balões de aniversário amarrados na frente das locomotivas.", true)
        }));
        l4.Add(new Q("A Baía de Ha Long", new Alt[] {
            new Alt("Localizada no Vietnã, é famosa por milhares de ilhotas e pilares de pedra calcária que brotam do mar.", false),
            new Alt("É Patrimônio Mundial da UNESCO e os turistas navegam entre as ilhotas em barcos tradicionais.", false),
            new Alt("É uma pista de pouso de asfalto no meio do deserto onde não há uma gota d'água.", true)
        }));
        l4.Add(new Q("A Ilha de Phuket", new Alt[] {
            new Alt("É a maior ilha da Tailândia, banhada pelas águas mornas e claras do Mar de Andamão.", false),
            new Alt("Famosa por praias com falésias rochosas, templos com budas gigantes e mercados noturnos.", false),
            new Alt("É uma província congelada do Alasca cercada por blocos gigantescos de geleiras.", true)
        }));
        l4.Add(new Q("A Cidade de Varanasi", new Alt[] {
            new Alt("É uma das cidades continuamente habitadas mais antigas do mundo, sagrada para o hinduísmo na Índia.", false),
            new Alt("Suas escadarias à beira do Rio Ganges, chamadas ghats, recebem rituais e orações com fogo e flores.", false),
            new Alt("Foi fundada no ano de 2019 para funcionar como uma fábrica moderna de celulares.", true)
        }));
        l4.Add(new Q("O Palácio Imperial de Tóquio", new Alt[] {
            new Alt("É a residência oficial do Imperador do Japão, cercada por fossos de água e belos jardins históricos.", false),
            new Alt("Fica localizado no centro da capital sobre os terrenos do antigo e imponente Castelo de Edo.", false),
            new Alt("Foi construído com placas de papelão de caixas de sapato coladas com fita adesiva.", true)
        }));
        l4.Add(new Q("O Estádio Ninho de Pássaro", new Alt[] {
            new Alt("Famoso estádio olímpico em Pequim com estrutura externa de aço trançada parecida com um ninho de ave.", false),
            new Alt("Foi a sede das cerimônias de abertura e encerramento dos Jogos Olímpicos de 2008 e 2022.", false),
            new Alt("É um ninho de passarinho verdadeiro habitado por um canário gigante de cem metros.", true)
        }));
        l4.Add(new Q("A Cordilheira de Tian Shan", new Alt[] {
            new Alt("Grande sistema montanhoso da Ásia Central cujo nome na língua chinesa significa 'Montanhas Celestes'.", false),
            new Alt("Abriga picos nevados com mais de sete mil metros e profundos lagos alpinos de água cristalina.", false),
            new Alt("É uma praia de areia branca na costa do Brasil onde turistas jogam futevôlei.", true)
        }));
        l4.Add(new Q("O Templo do Pavilhão Dourado (Kinkaku-ji)", new Alt[] {
            new Alt("Famoso templo zen-budista em Kyoto, no Japão, cujos dois andares superiores são folheados a ouro puro.", false),
            new Alt("Fica situado à beira de um lago espelhado que reflete perfeitamente o brilho dourado do templo.", false),
            new Alt("Foi pintado com tinta guache escolar amarela que sai na água toda vez que chove.", true)
        }));
        l4.Add(new Q("A Caligrafia Shodo e Hanzi", new Alt[] {
            new Alt("A arte da caligrafia tradicional no Japão e na China usa pincéis finos e tinta preta de carvão mineral.", false),
            new Alt("Cada caractere ou ideograma pode representar uma ideia, palavra ou conceito completo da natureza.", false),
            new Alt("É desenhada usando canetinhas que apagam sozinhas após dez segundos no papel.", true)
        }));
        l4.Add(new Q("O Rio Jordão", new Alt[] {
            new Alt("É um rio histórico do Oriente Médio que corre pelo vale do Rift até desaguar nas águas do Mar Morto.", false),
            new Alt("Possui grande importância religiosa para cristãos e judeus, sendo citado em muitas passagens sagradas.", false),
            new Alt("É um rio de refrigerante de laranja gaseificado que corre dentro de uma fábrica.", true)
        }));

        l4.Add(new Q("O Jardim Yu Yuan em Xangai", new Alt[] {
            new Alt("Jardim clássico chinês construído no século XVI com pavilhões tradicionais, lagos de carpas e pedras ornamentais.", false),
            new Alt("Suas pontes em zigue-zague foram desenhadas segundo a tradição de que espíritos maus só andam em linha reta.", false),
            new Alt("É uma pista de skate de concreto construída para competições de patins de corrida.", true)
        }));
        l4.Add(new Q("A Cidade de Samarcanda", new Alt[] {
            new Alt("Histórica cidade no Uzbequistão que foi uma das principais paradas da lendária Rota da Seda.", false),
            new Alt("Famosa pela praça do Registan e monumentos com cúpulas imensas decoradas com azulejos azul-turquesa.", false),
            new Alt("É uma cidade submarina instalada dentro de um navio naufragado no Caribe.", true)
        }));
        l4.Add(new Q("As Ilhas Maldivas", new Alt[] {
            new Alt("Nação insular no Oceano Índico formada por mais de mil ilhas de corais com águas calmas e azul-turquesa.", false),
            new Alt("É o país com a menor altitude média do planeta, ficando apenas cerca de um metro e meio acima do mar.", false),
            new Alt("É uma enorme cordilheira com montanhas mais altas que o próprio Monte Everest.", true)
        }));
        l4.Add(new Q("O Museu do Futuro em Dubai", new Alt[] {
            new Alt("Edifício em formato de anel oval com fachada de aço decorada com caligrafia árabe que serve de janelas.", false),
            new Alt("Apresenta exposições interativas sobre tecnologia espacial, ecologia e inovações das próximas décadas.", false),
            new Alt("Foi construído por piratas vikings no ano 800 usando troncos de carvalho lascados.", true)
        }));
        l4.Add(new Q("A Montanha Huangshan", new Alt[] {
            new Alt("Cadeia montanhosa na China famosa por seus picos de granito pontudos envoltos por um mar de nuvens.", false),
            new Alt("Inspirou incontáveis pinturas clássicas chinesas ao longo de milênios com seus pinheiros retorcidos.", false),
            new Alt("É uma montanha artificial de papelão montada em um palco de teatro em Londres.", true)
        }));
        l4.Add(new Q("A Cúpula de Rocha em Jerusalém", new Alt[] {
            new Alt("Famoso monumento islâmico com uma cúpula dourada brilhante situado na Cidade Velha de Jerusalém.", false),
            new Alt("Seus muros são revestidos com belíssimos mosaicos de azulejos coloridos e inscrições religiosas.", false),
            new Alt("É uma estufa de tomates construída com plástico agrícola e canos de PVC modernos.", true)
        }));
        l4.Add(new Q("O Deserto de Wadi Rum", new Alt[] {
            new Alt("Vale desértico na Jordânia famoso por suas areias avermelhadas e imensos cânions de arenito maciço.", false),
            new Alt("É chamado de Vale da Lua e já serviu de cenário para vários filmes de ficção sobre o planeta Marte.", false),
            new Alt("É uma floresta pantanosa alagada onde vivem milhares de jacarés e araras-azuis.", true)
        }));
        l4.Add(new Q("A Torre de Tóquio", new Alt[] {
            new Alt("Torre de telecomunicações inspirada na Torre Eiffel francesa, pintada com as cores branco e laranja.", false),
            new Alt("Possui mirantes com chão de vidro de onde os visitantes observam a imensidão da capital japonesa.", false),
            new Alt("Foi esculpida em uma montanha de queijo e atrai milhares de ratos todos os dias.", true)
        }));
        l4.Add(new Q("O Lago Kawaguchi e o Monte Fuji", new Alt[] {
            new Alt("É um dos cinco lagos famosos que cercam o Monte Fuji, famoso por refletir o cume nevado em suas águas.", false),
            new Alt("Na primavera e no outono, a vista do lago cercado por folhas coloridas é uma das mais famosas do Japão.", false),
            new Alt("É uma poça de água salobra no meio do deserto do Saara onde não há montanhas.", true)
        }));
        l4.Add(new Q("O Tigre-de-Bengala na Índia", new Alt[] {
            new Alt("É um dos maiores felinos do planeta Terra e o animal símbolo nacional oficial da Índia.", false),
            new Alt("Vive em parques e reservas naturais protegidas como o Parque Nacional de Ranthambore.", false),
            new Alt("É um animal herbívoro de asas que se alimenta exclusivamente de néctar de flores.", true)
        }));

        // Continue with levels 5 and 6
        SaveLevels(levels, "temp_geo_levels_3_4.lua");
    }

    static void SaveLevels(Dictionary<int, List<Q>> levels, string path) {
        var sb = new StringBuilder();
        foreach (var kvp in levels) {
            if (kvp.Value.Count == 0) continue;
            sb.AppendLine(string.Format("\t[{0}] = {{", kvp.Key));
            sb.AppendLine("\t\tDados = {");
            for (int i = 0; i < kvp.Value.Count; i++) {
                var q = kvp.Value[i];
                sb.AppendLine("\t\t\t{");
                sb.AppendLine(string.Format("\t\t\t\tNome = \"{0}\",", Escape(q.Nome)));
                sb.AppendLine("\t\t\t\tAlternativas = {");
                foreach (var a in q.Alts) {
                    string fStr = a.F ? "true" : "false";
                    sb.AppendLine(string.Format("\t\t\t\t\t{{Texto = \"{0}\", Falsa = {1}}},", Escape(a.T), fStr));
                }
                sb.AppendLine("\t\t\t\t}");
                sb.AppendLine(i == kvp.Value.Count - 1 ? "\t\t\t}" : "\t\t\t},");
            }
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t},");
        }
        File.WriteAllText(path, sb.ToString(), new UTF8Encoding(false));
        Console.WriteLine(string.Format("Wrote {0} with {1} levels", path, levels.Count));
    }

    static string Escape(string s) {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}
