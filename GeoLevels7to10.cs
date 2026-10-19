using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class GeoLevels7to10 {
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
        for (int i = 7; i <= 10; i++) levels[i] = new List<Q>();

        // ==========================================
        // NIVEL 7: ÁFRICA MAJESTOSA (50 Questões)
        // ==========================================
        var l7 = levels[7];
        l7.Add(new Q("O Rio Nilo", new Alt[] {
            new Alt("É um dos rios mais longos do mundo e foi fundamental para o surgimento do Antigo Egito.", false),
            new Alt("Deságua no Mar Mediterrâneo através de um gigantesco e fértil delta de canais.", false),
            new Alt("É um rio de águas congeladas onde os pinguins patinam e constroem iglus no inverno.", true)
        }));
        l7.Add(new Q("O Deserto do Saara", new Alt[] {
            new Alt("É o maior deserto quente do planeta Terra, cobrindo grande parte do norte da África.", false),
            new Alt("Possui dunas de areia gigantescas que podem ultrapassar cento e cinquenta metros de altura.", false),
            new Alt("É totalmente coberto por florestas de pinheiros e neva forte durante todos os meses.", true)
        }));
        l7.Add(new Q("O Monte Kilimanjaro", new Alt[] {
            new Alt("Localizado na Tanzânia, é o ponto mais alto de todo o continente africano.", false),
            new Alt("É um vulcão adormecido com picos nevados mesmo ficando perto da linha do Equador.", false),
            new Alt("É uma torre de ferro construída para os turistas subirem de elevador panorâmico.", true)
        }));
        l7.Add(new Q("As Cataratas Vitória (Victoria Falls)", new Alt[] {
            new Alt("Ficam na fronteira entre a Zâmbia e o Zimbábue, no caudaloso rio Zambeze.", false),
            new Alt("Sua cortina de água forma uma névoa impressionante chamada localmente de 'Fumaça do Trovão'.", false),
            new Alt("Foram desligadas por falta de pilhas no começo do século vinte e nunca mais fluíram.", true)
        }));
        l7.Add(new Q("A Ilha de Madagascar", new Alt[] {
            new Alt("É a maior ilha da África e a quarta maior ilha do planeta Terra no Oceano Índico.", false),
            new Alt("Abriga animais exclusivos no mundo, como várias espécies de lêmures e árvores embaúbas baobás.", false),
            new Alt("É um país habitado apenas por robôs eletrônicos que não precisam de comida.", true)
        }));
        l7.Add(new Q("As Árvores Baobás", new Alt[] {
            new Alt("São árvores africanas icônicas com troncos gigantescos capazes de armazenar muita água.", false),
            new Alt("Alguns baobás podem viver por mais de mil anos e parecem ter raízes viradas para o céu.", false),
            new Alt("Produzem sorvete de baunilha pronto em suas folhas todas as manhãs de calor.", true)
        }));
        l7.Add(new Q("O Canal de Suez", new Alt[] {
            new Alt("É uma hidrovia artificial no Egito que conecta o Mar Mediterrâneo ao Mar Vermelho.", false),
            new Alt("Permite que navios cargueiros viagem entre a Europa e a Ásia sem contornar toda a África.", false),
            new Alt("É um túnel subterrâneo feito de vidro onde tubarões servem de motor para os barcos.", true)
        }));
        l7.Add(new Q("O Deserto do Namibe", new Alt[] {
            new Alt("Fica no sudoeste da África e é considerado o deserto mais antigo de todo o planeta.", false),
            new Alt("Encontra diretamente as ondas do Oceano Atlântico em uma paisagem espetacular de dunas.", false),
            new Alt("Fica no Polo Norte e possui cidades submarinas habitadas por baleias cantoras.", true)
        }));
        l7.Add(new Q("O Parque Nacional Serengeti", new Alt[] {
            new Alt("Fica na Tanzânia e é famoso pela grande migração anual de milhões de gnus e zebras.", false),
            new Alt("É uma vasta savana protegida repleta de leões, leopardos, elefantes e girafas.", false),
            new Alt("É um parque temático artificial onde todos os animais são feitos de plástico e metal.", true)
        }));
        l7.Add(new Q("A Cratera de Ngorongoro", new Alt[] {
            new Alt("É uma imensa caldeira vulcânica intacta que abriga milhares de animais selvagens.", false),
            new Alt("Funciona como um refúgio natural fechado para rinocerontes, leões e flamingos.", false),
            new Alt("Foi aberta por um meteoro de ouro no ano 2015 e serve como pista de corrida de foguetes.", true)
        }));
        l7.Add(new Q("O Cabo da Boa Esperança", new Alt[] {
            new Alt("Fica na ponta sul da África do Sul, ponto marcante das rotas dos antigos navegadores.", false),
            new Alt("Ficou historicamente conhecido como Cabo das Tormentas por conta do mar bravo.", false),
            new Alt("É uma ponte de madeira que liga a África diretamente à Austrália a pé.", true)
        }));
        l7.Add(new Q("A Cidade do Cabo (Cape Town)", new Alt[] {
            new Alt("É uma das cidades mais conhecidas da África do Sul, situada aos pés da famosa Table Mountain.", false),
            new Alt("Abriga praias famosas onde colônias de pinguins-africanos vivem livres na areia.", false),
            new Alt("Fica no meio do deserto do Saara e só pode ser alcançada em lombo de camelo.", true)
        }));
        l7.Add(new Q("A Table Mountain (Montanha da Mesa)", new Alt[] {
            new Alt("É uma montanha imponente com o topo incrivelmente plano que domina a paisagem da Cidade do Cabo.", false),
            new Alt("As nuvens brancas que cobrem seu topo com frequência são chamadas de 'toalha de mesa'.", false),
            new Alt("É uma mesa de madeira gigante fabricada por gigantes medievais para banquetes reais.", true)
        }));
        l7.Add(new Q("A Grande Fenda Africana (Rift Valley)", new Alt[] {
            new Alt("É uma enorme falha geológica que se estende por milhares de quilômetros no leste da África.", false),
            new Alt("Nela surgiram vários lagos profundos e vulcões ativos e o continente está se dividindo devagar.", false),
            new Alt("Foi cavada à mão com pás por operários em menos de um final de semana.", true)
        }));
        l7.Add(new Q("O Lago Vitória", new Alt[] {
            new Alt("É o maior lago da África e o segundo maior lago de água doce do mundo em área.", false),
            new Alt("Suas margens são compartilhadas por Uganda, Quênia e Tanzânia.", false),
            new Alt("É uma piscina olímpica aquecida construída no topo de uma torre em Joanesburgo.", true)
        }));
        l7.Add(new Q("O Lago Tanganica", new Alt[] {
            new Alt("É o segundo lago mais profundo do mundo e um dos mais longos de água doce.", false),
            new Alt("Abriga centenas de espécies coloridas de peixes ciclídeos que só existem em suas águas.", false),
            new Alt("Não tem água líquida, sendo preenchido por areia dourada e pedras preciosas.", true)
        }));
        l7.Add(new Q("O Rio Congo", new Alt[] {
            new Alt("É o rio mais profundo do mundo, atingindo mais de 220 metros de profundidade em trechos.", false),
            new Alt("Atravessa a segunda maior floresta tropical do planeta, a Bacia do Congo.", false),
            new Alt("Seca completamente todo domingo à tarde para os barcos descansarem na lama.", true)
        }));
        l7.Add(new Q("A Floresta do Congo", new Alt[] {
            new Alt("É uma gigantesca floresta tropical úmida rica em biodiversidade no centro da África.", false),
            new Alt("É o lar dos gorilas-das-montanhas, chimpanzés e dos raros animais chamados ocapis.", false),
            new Alt("É uma floresta de cactos gigantes no meio de um deserto de sal sem nenhuma árvore.", true)
        }));
        l7.Add(new Q("O Deserto do Calaári", new Alt[] {
            new Alt("É uma vasta região arenosa semiárida que se estende por Botsuana, Namíbia e África do Sul.", false),
            new Alt("Possui areias avermelhadas e é o território tradicional do povo indígena San.", false),
            new Alt("É famoso por suas geleiras infinitas onde ursos-polares caçam focas árticas.", true)
        }));
        l7.Add(new Q("O Delta do Okavango", new Alt[] {
            new Alt("É um dos maiores deltas interiores do mundo, cujas águas deságuam no meio da terra e secam.", false),
            new Alt("Cria um oásis verdejante sazonal espetacular no meio do árido Calaári atraindo milhares de animais.", false),
            new Alt("É um canal artificial feito de concreto armado ligando Tóquio a Nova York.", true)
        }));
        l7.Add(new Q("O Povo Massai", new Alt[] {
            new Alt("É um grupo étnico tradicional que vive nas savanas do Quênia e da Tanzânia.", false),
            new Alt("São famosos por suas túnicas vermelhas vibrantes e suas danças tradicionais de saltos altos.", false),
            new Alt("Vivem no subsolo em cavernas submarinas sem nunca ver a luz do sol.", true)
        }));
        l7.Add(new Q("A Cidade de Marraquexe", new Alt[] {
            new Alt("É uma cidade histórica lendária do Marrocos, famosa por suas construções em tons avermelhados.", false),
            new Alt("Sua praça central, Jemaa el-Fna, reúne contadores de histórias, músicos e mercados de especiarias.", false),
            new Alt("É uma base espacial de lançamento de foguetes para o planeta Saturno.", true)
        }));
        l7.Add(new Q("O Estreito de Gibraltar", new Alt[] {
            new Alt("É o canal de água que separa o continente europeu (Espanha) do africano (Marrocos).", false),
            new Alt("No seu ponto mais estreito, a distância entre a Europa e a África é de apenas 14 quilômetros.", false),
            new Alt("Separa o Brasil da Argentina por uma distância de dez mil quilômetros oceânicos.", true)
        }));
        l7.Add(new Q("As Pirâmides de Gizé", new Alt[] {
            new Alt("Ficam nos arredores do Cairo, capital do Egito, erguidas há mais de quatro mil anos.", false),
            new Alt("A Grande Pirâmide de Quéops é a única maravilha do mundo antigo ainda de pé.", false),
            new Alt("Foram esculpidas no ano 2010 usando blocos coloridos de brinquedo de plástico.", true)
        }));
        l7.Add(new Q("A Grande Esfinge de Gizé", new Alt[] {
            new Alt("É uma estátua monumental de pedra com corpo de leão e cabeça humana de faraó.", false),
            new Alt("Fica guardando o complexo das pirâmides no planalto de Gizé no Egito.", false),
            new Alt("É um robô gigante que anda pelas ruas buzinando como um ônibus escolar.", true)
        }));
        l7.Add(new Q("O Rio Níger", new Alt[] {
            new Alt("É o terceiro maior rio da África e a principal hidrovia da África Ocidental.", false),
            new Alt("Faz uma curva curiosa em forma de bumerangue atravessando terras férteis e desertos.", false),
            new Alt("Nasce na Austrália e deságua no Oceano Pacífico perto da Antártida.", true)
        }));
        l7.Add(new Q("O Chifre da África", new Alt[] {
            new Alt("É uma grande península no leste africano formada por países como Somália, Etiópia e Djibuti.", false),
            new Alt("Tem esse apelido porque o formato da costa no mapa lembra a ponta do chifre de um rinoceronte.", false),
            new Alt("É uma montanha de marfim onde vivem unicórnios mágicos voadores.", true)
        }));
        l7.Add(new Q("As Ruínas de Cartago", new Alt[] {
            new Alt("Ficam localizadas na atual Tunísia e foram o centro de um dos maiores impérios do Mediterrâneo.", false),
            new Alt("Lutaram guerras lendárias contra a Roma Antiga com os elefantes do general Aníbal.", false),
            new Alt("Eram castelos espaciais que flutuavam no céu movidos a vento solar.", true)
        }));
        l7.Add(new Q("As Pirâmides de Méroe", new Alt[] {
            new Alt("Ficam no Sudão e foram erguidas pelos reis e rainhas do antigo Reino de Cuxe.", false),
            new Alt("O Sudão possui mais pirâmides no total do que o próprio Egito, embora sejam mais estreitas.", false),
            new Alt("Foram feitas de marshmallows gigantes e comida desidratada para cosmonautas.", true)
        }));
        l7.Add(new Q("A Depressão de Danakil", new Alt[] {
            new Alt("Fica na Etiópia e é um dos lugares mais quentes e geologicamente ativos da Terra.", false),
            new Alt("Possui fontes termais coloridas de enxofre em verde neon, amarelo e lagos de lava viva.", false),
            new Alt("É uma geleira coberta de neve eterna onde se realizam campeonatos de esqui nórdico.", true)
        }));
        l7.Add(new Q("O Rio Zambeze", new Alt[] {
            new Alt("É o quarto maior rio da África e deságua no Oceano Índico em Moçambique.", false),
            new Alt("É famoso por suas corredeiras espetaculares e pelas imensas Cataratas Vitória.", false),
            new Alt("Corre rio acima subindo as montanhas sem nunca derramar uma gota no mar.", true)
        }));
        l7.Add(new Q("O Parque Kruger", new Alt[] {
            new Alt("É a maior reserva florestal e de safári da África do Sul, com rica fauna selvagem.", false),
            new Alt("É um dos melhores locais do mundo para avistar os 'Big Five': leão, leopardo, elefante, rinoceronte e búfalo.", false),
            new Alt("Só permite a entrada de dinossauros domesticados com coleira e focinheira.", true)
        }));
        l7.Add(new Q("A Ilha de Zanzibar", new Alt[] {
            new Alt("É um arquipélago histórico da Tanzânia famoso por praias de águas turquesas e especiarias como cravo.", false),
            new Alt("Sua parte histórica chamada Cidade de Pedra (Stone Town) é Patrimônio Mundial da UNESCO.", false),
            new Alt("É uma fábrica flutuante de sorvetes localizada no meio do Polo Sul.", true)
        }));
        l7.Add(new Q("Os Oásis do Deserto", new Alt[] {
            new Alt("São áreas férteis isoladas no meio de desertos onde há fontes de água subterrânea.", false),
            new Alt("Permitem a vegetação de tamareiras e serviam de pontos de descanso para caravanas de camelos.", false),
            new Alt("São hologramas criados por satélites para enganar os viajantes cansados.", true)
        }));
        l7.Add(new Q("O Camelo Dromedário", new Alt[] {
            new Alt("É um animal incrivelmente adaptado aos desertos africanos que possui apenas uma corcova.", false),
            new Alt("Armazena gordura na corcova para obter energia e pode passar dias sem beber água.", false),
            new Alt("Possui asas de penas e viaja voando pelos céus acima das tempestades de areia.", true)
        }));
        l7.Add(new Q("O Flamingo Rosa", new Alt[] {
            new Alt("São aves pernaltas abundantes em lagos alcalinos da África, como o Lago Nakuru no Quênia.", false),
            new Alt("Sua coloração rosada vem da alimentação rica em carotenoides de pequenos crustáceos e algas.", false),
            new Alt("Nascem brilhando no escuro porque comem baterias recarregáveis nos ninhos.", true)
        }));
        l7.Add(new Q("O Chita (Guepardo)", new Alt[] {
            new Alt("É o mamífero terrestre mais veloz do mundo, habitando as savanas da África.", false),
            new Alt("Pode atingir mais de 100 km/h em arrancadas curtas graças ao corpo aerodinâmico.", false),
            new Alt("Consegue correr tão rápido que viaja de volta para a época dos dinossauros.", true)
        }));
        l7.Add(new Q("O Vale dos Reis", new Alt[] {
            new Alt("É uma garganta rochosa no Egito onde faraós foram sepultados em tumbas secretas na rocha.", false),
            new Alt("Lá foi encontrada a tumba intacta do famoso jovem rei Tutancâmon com tesouros de ouro.", false),
            new Alt("É um circuito de montanha-russa moderna inaugurado em Tóquio para crianças.", true)
        }));
        l7.Add(new Q("O Rio Orange", new Alt[] {
            new Alt("É o rio mais longo da África do Sul, desaguando no Oceano Atlântico.", false),
            new Alt("Suas águas são vitais para a agricultura e irrigação das regiões áridas do país.", false),
            new Alt("É feito de refrigerante de laranja gaseificado que jorra das pedras vulcânicas.", true)
        }));
        l7.Add(new Q("As Florestas de Madagascar", new Alt[] {
            new Alt("Abrigam animais únicos no mundo como o camaleão-pantera e o bizarro aie-aie.", false),
            new Alt("Mais de 80% das plantas e animais dessa ilha não existem em nenhum outro lugar da Terra.", false),
            new Alt("São povoadas por ursos polares que se alimentam de cactos gigantes e melancias.", true)
        }));
        l7.Add(new Q("O Estreito de Moçambique", new Alt[] {
            new Alt("É o braço do Oceano Índico que separa a grande ilha de Madagascar do continente africano.", false),
            new Alt("Tem correntes marítimas quentes importantes para a navegação do hemisfério sul.", false),
            new Alt("É um riacho de trinta centímetros de largura que qualquer pessoa atravessa pulando.", true)
        }));
        l7.Add(new Q("O Povo Bérbere", new Alt[] {
            new Alt("É um povo indígena milenar originário do norte da África e das montanhas do Atlas.", false),
            new Alt("Possuem língua, cultura e tradições ricas de tecelagem de tapetes e música.", false),
            new Alt("Vieram do planeta Marte em discos voadores durante a Idade Média.", true)
        }));
        l7.Add(new Q("As Montanhas do Atlas", new Alt[] {
            new Alt("São uma grande cordilheira montanhosa no noroeste da África que corta o Marrocos, Argélia e Tunísia.", false),
            new Alt("Separam a costa úmida do Mediterrâneo da vastidão árida do Deserto do Saara.", false),
            new Alt("Foram esculpidas no século vinte para formar a estátua de um único gigante adormecido.", true)
        }));
        l7.Add(new Q("O Lago Chade", new Alt[] {
            new Alt("É um lago histórico e vital na África Central compartilhado por quatro países.", false),
            new Alt("Sua área encolheu drasticamente nas últimas décadas devido a secas e uso da água.", false),
            new Alt("É uma represa artificial construída no polo norte para abastecer trenós do Papai Noel.", true)
        }));
        l7.Add(new Q("O Cairo", new Alt[] {
            new Alt("É a capital do Egito e uma das maiores e mais populosas metrópoles de toda a África.", false),
            new Alt("Fica localizada nas margens do histórico Rio Nilo, perto das famosas pirâmides.", false),
            new Alt("Fica localizada dentro de uma caverna gelada na Patagônia chilena.", true)
        }));
        l7.Add(new Q("O Elefante Africano", new Alt[] {
            new Alt("É o maior mamífero terrestre vivo do planeta Terra, com orelhas gigantes em formato de leque.", false),
            new Alt("Usa a tromba flexível tanto para respirar e pegar alimentos quanto para tomar banho de água.", false),
            new Alt("Pesa menos de meio quilo e cabe na palma da mão de uma criança pequena.", true)
        }));
        l7.Add(new Q("O Rinoceronte Africano", new Alt[] {
            new Alt("Possui chifres feitos de queratina, a mesma substância das unhas e cabelos humanos.", false),
            new Alt("É uma espécie rigorosamente protegida em parques contra caçadores ilegais.", false),
            new Alt("Bota ovos gigantes com casca de metal nas copas das árvores mais altas.", true)
        }));
        l7.Add(new Q("A Zebra", new Alt[] {
            new Alt("Cada zebra possui um padrão de listras pretas e brancas totalmente único no corpo, como uma digital.", false),
            new Alt("As listras ajudam a confundir predadores em movimento e repelem insetos picadores.", false),
            new Alt("As zebras são cavalos que os fazendeiros pintam com tinta branca todo mês.", true)
        }));
        l7.Add(new Q("O Hipopótamo", new Alt[] {
            new Alt("Passa a maior parte do dia submerso em rios e lagos para manter a pele fresca e hidratada.", false),
            new Alt("Apesar de herbívoro e pesado, é um dos animais mais rápidos na água e territorialistas da África.", false),
            new Alt("Voa em bandos durante o inverno para passar as férias nas praias da Europa.", true)
        }));
        l7.Add(new Q("O Continente Africano", new Alt[] {
            new Alt("É o segundo continente mais populoso e o segundo maior em extensão territorial da Terra.", false),
            new Alt("É o único continente do mundo que é cortado tanto pelo Meridiano de Greenwich quanto pelo Equador.", false),
            new Alt("Possui apenas duas cidades no total e não tem nenhum mar ou oceano por perto.", true)
        }));

        // ==========================================
        // NIVEL 8: AMÉRICA DO NORTE E CARIBE (50 Questões)
        // ==========================================
        var l8 = levels[8];
        l8.Add(new Q("O Grand Canyon", new Alt[] {
            new Alt("É um cânion colossal no estado do Arizona (EUA) esculpido pelas águas do Rio Colorado.", false),
            new Alt("Suas paredes revelam milhões de anos de camadas de rochas com cores vermelhas e laranjas.", false),
            new Alt("Foi aberto por máquinas escavadeiras elétricas durante o ano de 2018.", true)
        }));
        l8.Add(new Q("As Cataratas do Niágara", new Alt[] {
            new Alt("Ficam na fronteira entre os Estados Unidos e o Canadá com um volume gigantesco de água.", false),
            new Alt("São formadas por três quedas espetaculares, incluindo a famosa Ferradura (Horseshoe Falls).", false),
            new Alt("São cataratas artificiais onde jorra suco de uva durante os fins de semana.", true)
        }));
        l8.Add(new Q("A Estátua da Liberdade", new Alt[] {
            new Alt("Fica na entrada do porto de Nova York e foi um presente da França para os Estados Unidos.", false),
            new Alt("É revestida por placas de cobre que oxidaram com o tempo, ganhando a cor verde-clara.", false),
            new Alt("Foi talhada em um bloco maciço de gelo do Alasca que nunca derrete.", true)
        }));
        l8.Add(new Q("O Parque Nacional de Yellowstone", new Alt[] {
            new Alt("Foi o primeiro parque nacional do mundo, famoso por gêiseres quentes e fontes termais coloridas.", false),
            new Alt("Abriga o famoso gêiser 'Old Faithful', que esguicha água fervente em intervalos regulares.", false),
            new Alt("Fica localizado na Lua e só pode ser visitado por astronautas da NASA.", true)
        }));
        l8.Add(new Q("A Grand Prismatic Spring", new Alt[] {
            new Alt("É a maior fonte termal dos Estados Unidos, localizada no parque de Yellowstone.", false),
            new Alt("Possui anéis de cores brilhantes em arco-íris causados por bactérias amantes do calor.", false),
            new Alt("É uma poça de tinta para impressora que derramou de um caminhão em 1950.", true)
        }));
        l8.Add(new Q("As Montanhas Rochosas (Rocky Mountains)", new Alt[] {
            new Alt("São uma imensa cordilheira que se estende por milhares de quilômetros do Canadá aos Estados Unidos.", false),
            new Alt("Abrigam picos nevados, ursos-pardos, alces imponentes e florestas de pinheiros.", false),
            new Alt("São montanhas infláveis instaladas pelo governo para servir de pula-pula.", true)
        }));
        l8.Add(new Q("O Monte Denali (Monte McKinley)", new Alt[] {
            new Alt("Fica no estado do Alasca e é o ponto mais alto de toda a América do Norte.", false),
            new Alt("Seu pico é coberto por geleiras eternas e suporta temperaturas extremamente frias.", false),
            new Alt("É uma pirâmide dourada construída por piratas caribenhos no meio do oceano.", true)
        }));
        l8.Add(new Q("O Estado do Alasca", new Alt[] {
            new Alt("É o maior estado em área dos Estados Unidos, separado geograficamente pelo Canadá.", false),
            new Alt("Foi comprado pelos Estados Unidos do Império Russo no ano de 1867.", false),
            new Alt("Fica situado no coração da América do Sul, fazendo fronteira com o Uruguai.", true)
        }));
        l8.Add(new Q("A Península da Flórida", new Alt[] {
            new Alt("É uma península ensolarada no sudeste dos Estados Unidos cercada pelo Golfo do México e o Atlântico.", false),
            new Alt("Abriga o Cabo Canaveral, de onde partem os principais foguetes espaciais norte-americanos.", false),
            new Alt("É uma geleira ártica onde trenós puxados por renas são o único meio de transporte.", true)
        }));
        l8.Add(new Q("Os Everglades da Flórida", new Alt[] {
            new Alt("São um ecossistema único de pântanos e pradarias inundadas no sul da Flórida.", false),
            new Alt("São o único lugar da Terra onde jacarés (alligators) e crocodilos vivem lado a lado.", false),
            new Alt("São uma cadeia de vulcões ativos de onde escorre lava quente sem parar.", true)
        }));
        l8.Add(new Q("O Vale da Morte (Death Valley)", new Alt[] {
            new Alt("Fica na Califórnia e é um dos locais mais quentes e secos de todo o planeta Terra.", false),
            new Alt("Sua bacia de Badwater fica a 86 metros abaixo do nível do mar, o ponto mais baixo da América do Norte.", false),
            new Alt("É uma pista de patinação no gelo aberta todos os dias para os pinguins.", true)
        }));
        l8.Add(new Q("As Sequoias Gigantes", new Alt[] {
            new Alt("Crescem na Califórnia e estão entre os maiores e mais velhos seres vivos do planeta.", false),
            new Alt("A árvore General Sherman é a maior do mundo em volume de tronco de madeira.", false),
            new Alt("São cogumelos mágicos que brotam e murcham em menos de vinte minutos.", true)
        }));
        l8.Add(new Q("A Falha de San Andreas", new Alt[] {
            new Alt("É uma falha geológica famosa que corta o estado da Califórnia de norte a sul.", false),
            new Alt("Marca o encontro entre duas placas tectônicas (Pacífico e Norte-Americana), gerando terremotos.", false),
            new Alt("É um tobogã de água construído para ligar Los Angeles a São Francisco.", true)
        }));
        l8.Add(new Q("A Ponte Golden Gate", new Alt[] {
            new Alt("É a famosa ponte pênsil na cor laranja internacional que cruza a baía de São Francisco.", false),
            new Alt("É frequentemente cercada por um nevoeiro costeiro denso e característico da região.", false),
            new Alt("Foi feita inteiramente de ouro maciço com diamantes cravados nos postes.", true)
        }));
        l8.Add(new Q("O Rio Mississippi", new Alt[] {
            new Alt("É o rio mais longo e volumoso dos Estados Unidos, cortando o país de norte a sul.", false),
            new Alt("Deságua em um grande delta no Golfo do México, perto da cidade de Nova Orleans.", false),
            new Alt("É um cano subterrâneo de esgoto construído para esvaziar o Oceano Pacífico.", true)
        }));
        l8.Add(new Q("Os Grandes Lagos da América do Norte", new Alt[] {
            new Alt("São cinco lagos gigantescos de água doce na fronteira entre os Estados Unidos e o Canadá.", false),
            new Alt("Incluem os lagos Superior, Michigan, Huron, Erie e Ontário, contendo muita água doce do mundo.", false),
            new Alt("São piscinas termais salgadas cheias de tubarões brancos e golfinhos fluviais.", true)
        }));
        l8.Add(new Q("A Ilha da Groenlândia", new Alt[] {
            new Alt("É a maior ilha do planeta Terra, coberta em grande parte por uma imensa calota de gelo.", false),
            new Alt("É um território autônomo pertencente politicamente ao Reino da Dinamarca.", false),
            new Alt("Fica no mar do Caribe e tem clima tropical quente cheio de coqueiros e bananas.", true)
        }));
        l8.Add(new Q("As Pirâmides de Teotihuacan", new Alt[] {
            new Alt("Ficam no México e incluem a gigantesca Pirâmide do Sol e a Pirâmide da Lua.", false),
            new Alt("Foram erguidas por uma civilização antiga misteriosa muito antes dos Astecas chegarem.", false),
            new Alt("Foram erguidas no ano 2005 para servir como armazém de milho enlatado.", true)
        }));
        l8.Add(new Q("A Cidade de Chichén Itzá", new Alt[] {
            new Alt("É uma cidade arqueológica maia no México com a imponente pirâmide de Kukulcán (El Castillo).", false),
            new Alt("Foi eleita uma das Novas Sete Maravilhas do Mundo Moderno pela sua genial arquitetura.", false),
            new Alt("Fica debaixo da água no Polo Norte habitada por baleias jubarte.", true)
        }));
        l8.Add(new Q("Os Cenotes do México", new Alt[] {
            new Alt("São poços naturais profundos de água doce cristalina formados pelo desabamento de rochas calcárias.", false),
            new Alt("Eram considerados portais sagrados pelos antigos maias na Península de Iucatã.", false),
            new Alt("São buracos perfurados para guardar naves espaciais alienígenas modernas.", true)
        }));
        l8.Add(new Q("O Vulcão Popocatépetl", new Alt[] {
            new Alt("É um imponente vulcão ativo no México situado perto da Cidade do México.", false),
            new Alt("Seu nome na língua náuatle significa 'Montanha que Solta Fumaça'.", false),
            new Alt("Solta fumaça colorida e bolhas de sabão perfumadas em dias de festa.", true)
        }));
        l8.Add(new Q("A Cidade do México", new Alt[] {
            new Alt("É a capital do México, uma das maiores e mais populosas cidades de todo o continente americano.", false),
            new Alt("Foi construída sobre as ruínas da antiga capital asteca chamada Tenochtitlán, em um lago seco.", false),
            new Alt("Fica localizada em uma plataforma no meio do Oceano Atlântico Norte.", true)
        }));
        l8.Add(new Q("O Canal do Panamá", new Alt[] {
            new Alt("É um canal artificial no Panamá que conecta o Oceano Atlântico ao Oceano Pacífico.", false),
            new Alt("Utiliza um engenhoso sistema de eclusas que sobem e descem os navios de um lado para o outro.", false),
            new Alt("É uma rodovia subterrânea asfaltada onde caminhões viajam debaixo d'água.", true)
        }));
        l8.Add(new Q("O Mar do Caribe", new Alt[] {
            new Alt("É um mar tropical famoso por suas águas mornas, cristalinas e ilhas paradisíacas.", false),
            new Alt("Possui o segundo maior recife de corais do planeta, a Barreira de Corais Mesoamericana.", false),
            new Alt("É um mar gelado coberto de icebergs onde só vivem focas e leões-marinhos árticos.", true)
        }));
        l8.Add(new Q("A Ilha de Cuba", new Alt[] {
            new Alt("É a maior ilha do Caribe, famosa por sua música, praias e charmosos carros clássicos antigos.", false),
            new Alt("Sua capital histórica é a cidade de Havana, com arquitetura colonial colorida.", false),
            new Alt("É uma geleira flutuante desabitada perto do Polo Sul terrestre.", true)
        }));
        l8.Add(new Q("A Ilha de Porto Rico", new Alt[] {
            new Alt("É uma ilha no Caribe famosa pela floresta tropical de El Yunque e praias bioluminescentes.", false),
            new Alt("É o lar do pequeno sapinho cantarolador chamado Coquí, símbolo da ilha.", false),
            new Alt("Fica congelada dez meses por ano com tempestades de gelo constantes.", true)
        }));
        l8.Add(new Q("A Ilha de Jamaica", new Alt[] {
            new Alt("É uma ilha caribenha montanhosa famosa por sua cultura do reggae e velocistas olímpicos.", false),
            new Alt("Sua capital é a cidade de Kingston, localizada ao pé das Montanhas Azuis (Blue Mountains).", false),
            new Alt("Fica localizada no mar Báltico ao norte da Suécia e Finlândia.", true)
        }));
        l8.Add(new Q("A Ilha das Bahamas", new Alt[] {
            new Alt("É um arquipélago com mais de 700 ilhas e ilhotas no Oceano Atlântico norte caribenho.", false),
            new Alt("Tem uma famosa praia onde simpáticos porquinhos selvagens nadam no mar cristalino com turistas.", false),
            new Alt("É uma ilha rochosa vulcânica onde chove lava ardente todos os dias.", true)
        }));
        l8.Add(new Q("O Great Blue Hole (Grande Buraco Azul)", new Alt[] {
            new Alt("É um gigantesco sumidouro submarino na costa de Belize com mais de trezentos metros de largura.", false),
            new Alt("Possui águas azuis escuras profundas e cavernas com estalagmites gigantes exploradas por mergulhadores.", false),
            new Alt("É uma poça de tinta azul deixada por pintores submarinos no ano 2000.", true)
        }));
        l8.Add(new Q("A Costa Rica e a Biodiversidade", new Alt[] {
            new Alt("É um pequeno país da América Central famoso por proteger grande parte de suas florestas em parques.", false),
            new Alt("Abriga preguiças, sapos-de-olhos-vermelhos, araras e o majestoso pássaro quetzal.", false),
            new Alt("Destruiu todas as suas árvores para construir apenas estacionamentos de carros.", true)
        }));
        l8.Add(new Q("O Rio Grande (Rio Bravo)", new Alt[] {
            new Alt("É o rio que forma grande parte da fronteira natural entre os Estados Unidos e o México.", false),
            new Alt("Nasce nas Montanhas Rochosas e corre até desaguar no Golfo do México.", false),
            new Alt("Deságua nas geleiras do Alasca e corre apenas dentro de cavernas geladas.", true)
        }));
        l8.Add(new Q("A Fossa de Porto Rico", new Alt[] {
            new Alt("É o ponto mais profundo de todo o Oceano Atlântico, superando 8.300 metros de profundidade.", false),
            new Alt("Fica localizada na divisa entre o Mar do Caribe e o Oceano Atlântico aberto.", false),
            new Alt("É uma montanha altíssima com pico de neve mais alta que o Everest.", true)
        }));
        l8.Add(new Q("O Lago Nicarágua", new Alt[] {
            new Alt("É o maior lago de água doce da América Central, abrigando várias ilhas e vulcões.", false),
            new Alt("É famoso por abrigar tubarões-touro que sobem rios e adaptam-se à sua água doce.", false),
            new Alt("É uma represa de plástico construída para treinar golfinhos astronautas.", true)
        }));
        l8.Add(new Q("As Montanhas Apalaches", new Alt[] {
            new Alt("São uma antiga cadeia de montanhas no leste da América do Norte cobertas de ricas florestas.", false),
            new Alt("São muito mais baixas e arredondadas que as Rochosas por terem sofrido erosão por centenas de milhões de anos.", false),
            new Alt("Surgiram de repente no ano passado após a passagem de um cometa no céu.", true)
        }));
        l8.Add(new Q("O Rio Hudson", new Alt[] {
            new Alt("É um rio histórico dos Estados Unidos que corre pelo estado de Nova York até o mar.", false),
            new Alt("Passa ao lado da Ilha de Manhattan e deságua na baía onde fica a Estátua da Liberdade.", false),
            new Alt("É um rio subterrâneo que atravessa a crosta terrestre até chegar ao Japão.", true)
        }));
        l8.Add(new Q("A Ilha de Manhattan", new Alt[] {
            new Alt("É uma ilha no coração da cidade de Nova York cercada pelos rios Hudson, East e Harlem.", false),
            new Alt("Abriga o famoso parque arborizado Central Park cercado por arranha-céus imponentes.", false),
            new Alt("É um vulcão ativo que cospe pedras incandescentes sobre os pedestres.", true)
        }));
        l8.Add(new Q("O Central Park", new Alt[] {
            new Alt("É um gigantesco parque urbano no meio de Nova York com lagos, pistas de patinação e jardins.", false),
            new Alt("Foi projetado no século dezenove para garantir uma área verde no crescimento da cidade.", false),
            new Alt("É um parque de brinquedos feito no topo da asa de um grande avião militar.", true)
        }));
        l8.Add(new Q("O Monumento de Mount Rushmore", new Alt[] {
            new Alt("É uma escultura colossal nas rochas de Dakota do Sul com os rostos de quatro presidentes dos EUA.", false),
            new Alt("Mostra os rostos esculpidos de George Washington, Thomas Jefferson, Theodore Roosevelt e Abraham Lincoln.", false),
            new Alt("Mostra os rostos dos quatro principais jogadores da seleção brasileira de futebol.", true)
        }));
        l8.Add(new Q("O Lago Louise no Canadá", new Alt[] {
            new Alt("Fica no Parque Nacional de Banff, nas Montanhas Rochosas canadenses.", false),
            new Alt("Tem uma cor azul-turquesa esmeralda deslumbrante provocada pela luz do sol sobre o pó de rocha glacial.", false),
            new Alt("Sua água é quente como sopa fervente e cheira a café com leite pela manhã.", true)
        }));
        l8.Add(new Q("As Auroras Boreais no Canadá", new Alt[] {
            new Alt("No norte do Canadá é muito comum observar luzes coloridas dançando no céu noturno.", false),
            new Alt("Acontecendo quando partículas do vento solar colidem com o campo magnético e a atmosfera da Terra.", false),
            new Alt("São lâmpadas de led gigantes instaladas no topo dos pinheiros pelos guardas-florestais.", true)
        }));
        l8.Add(new Q("A Baía de Fundy no Canadá", new Alt[] {
            new Alt("Fica na costa leste do Canadá e tem as marés mais altas de todo o planeta Terra.", false),
            new Alt("A diferença entre a maré baixa e a maré alta pode ultrapassar dezesseis metros de altura de água.", false),
            new Alt("Não tem água salgada, sendo uma imensa banheira de sabão com espuma de morango.", true)
        }));
        l8.Add(new Q("O Vulcão Arenal", new Alt[] {
            new Alt("É um vulcão com formato cônico perfeito localizado na Costa Rica cercado por florestas.", false),
            new Alt("Em seus arredores existem muitas termas de água quente aquecidas pela atividade geotérmica.", false),
            new Alt("Foi construído com tijolos de argila por crianças escoteiras em um acampamento.", true)
        }));
        l8.Add(new Q("O Deserto de Sonora", new Alt[] {
            new Alt("Fica no noroeste do México e sudoeste dos EUA, lar do famoso cacto saguaro gigante.", false),
            new Alt("Os cactos saguaro podem crescer por mais de duzentos anos e atingir doze metros de altura.", false),
            new Alt("É um pântano cheio de nenúfares gigantes onde chove vinte e quatro horas por dia.", true)
        }));
        l8.Add(new Q("A Península de Baja California", new Alt[] {
            new Alt("É uma longa península mexicana que separa o Oceano Pacífico do Golfo da Califórnia.", false),
            new Alt("Suas lagoas e baías são refúgios anuais de baleias-cinzentas que viajam para ter filhotes.", false),
            new Alt("É uma ponte de metal que liga a América do Norte diretamente ao continente europeu.", true)
        }));
        l8.Add(new Q("O Estreito de Bering", new Alt[] {
            new Alt("Separa o Alasca (América do Norte) da Sibéria (Ásia) por cerca de 82 quilômetros de água.", false),
            new Alt("Cientistas acreditam que os primeiros seres humanos chegaram à América cruzando esse estreito congelado.", false),
            new Alt("Separa a cidade de Brasília do estado do Rio de Janeiro por um oceano de lava.", true)
        }));
        l8.Add(new Q("A Floresta Boreal (Taiga Canadense)", new Alt[] {
            new Alt("Cobre grande parte do território canadense com milhões de coníferas e pinheiros adaptados ao frio.", false),
            new Alt("É habitada por lobos cinzentos, ursos, linces, castores e alces majestosos.", false),
            new Alt("É uma plantação de bananeiras onde macacos tropicais colhem cocos o ano inteiro.", true)
        }));
        l8.Add(new Q("O Urso Polar no Ártico Norte-Americano", new Alt[] {
            new Alt("Vive no norte do Alasca e no Ártico canadense, dependendo do gelo marinho para caçar focas.", false),
            new Alt("Sua pele sob o pelo branco é preta para absorver melhor o calor dos raios de sol.", false),
            new Alt("Mora em castelos subterrâneos aquecidos no meio das praias tropicais do Caribe.", true)
        }));
        l8.Add(new Q("O Castor Canadense", new Alt[] {
            new Alt("É um roedor semi-aquático famoso por construir represas de galhos e troncos de árvores nos rios.", false),
            new Alt("Suas represas criam novos pântanos e lagoas que ajudam muitas outras espécies na natureza.", false),
            new Alt("Derruba árvores usando machados de metal e serras elétricas a gasolina.", true)
        }));
        l8.Add(new Q("O Búfalo (Bisão-Americano)", new Alt[] {
            new Alt("É o maior mamífero terrestre da América do Norte, habitando pradarias e parques nacionais.", false),
            new Alt("Possui uma grossa pelagem de inverno e uma corcova forte que ajuda a empurrar a neve para pastar.", false),
            new Alt("Tem penas verdes nas costas e bota ovos listrados no alto de montanhas rochosas.", true)
        }));
        l8.Add(new Q("O Arquipélago do Havaí", new Alt[] {
            new Alt("É um conjunto de ilhas vulcânicas no meio do Oceano Pacífico pertencente aos Estados Unidos.", false),
            new Alt("Possui o vulcão Kilauea, um dos vulcões mais ativos e estudados de todo o planeta.", false),
            new Alt("Fica localizado no Mar Mediterrâneo entre a Itália e a Grécia.", true)
        }));

        // ==========================================
        // NIVEL 9: OCEANIA E ILHAS DO MUNDO (50 Questões)
        // ==========================================
        var l9 = levels[9];
        l9.Add(new Q("A Grande Barreira de Corais", new Alt[] {
            new Alt("Fica na costa da Austrália e é a maior estrutura viva do planeta Terra, visível até do espaço.", false),
            new Alt("É composta por bilhões de pequenos organismos de corais que abrigam peixes e tartarugas.", false),
            new Alt("Foi construída com cimento e tijolos por pedreiros australianos nos anos 1990.", true)
        }));
        l9.Add(new Q("O Monte Uluru (Ayers Rock)", new Alt[] {
            new Alt("É um gigantesco monólito de arenito avermelhado no centro desértico da Austrália.", false),
            new Alt("É um local sagrado para os povos aborígenes australianos da região.", false),
            new Alt("É uma estátua de bronze oca que toca música quando bate vento forte.", true)
        }));
        l9.Add(new Q("A Casa da Ópera de Sydney", new Alt[] {
            new Alt("É um dos edifícios mais famosos do mundo, com teto em formato de conchas ou velas brancas de barco.", false),
            new Alt("Fica debruçada sobre a baía de Sydney, na Austrália, inaugurada em 1973.", false),
            new Alt("É um iglu feito de blocos de gelo do Polo Sul que precisa de geladeiras para não sumir.", true)
        }));
        l9.Add(new Q("O Canguru Australiano", new Alt[] {
            new Alt("É o maior marsupial do planeta Terra, nativo e símbolo nacional da Austrália.", false),
            new Alt("Carrega seus filhotes dentro de uma bolsa na barriga chamada marsúpio.", false),
            new Alt("Locomove-se usando patins de rodinhas e voa como pássaro entre as árvores.", true)
        }));
        l9.Add(new Q("O Coala", new Alt[] {
            new Alt("É um marsupial arbóreo fofo da Austrália que se alimenta quase exclusivamente de folhas de eucalipto.", false),
            new Alt("Passa até vinte horas por dia dormindo nos galhos para economizar energia da digestão.", false),
            new Alt("É um peixe predador feroz que nada nos oceanos profundos caçando tubarões.", true)
        }));
        l9.Add(new Q("O Ornitorrinco", new Alt[] {
            new Alt("É um dos animais mais curiosos do mundo: mamífero semiaquático que põe ovos e tem bico de pato.", false),
            new Alt("Possui ferrões venenosos nas patas traseiras dos machos e nada fechando olhos e ouvidos.", false),
            new Alt("É um dinossauro voador gigante com asas cobertas de escamas e respira fogo.", true)
        }));
        l9.Add(new Q("O Demônio-da-Tasmânia", new Alt[] {
            new Alt("É um mamífero marsupial carnívoro nativo da ilha da Tasmânia, ao sul da Austrália.", false),
            new Alt("Tem uma mordida proporcionalmente fortíssima capaz de quebrar ossos e solta um grito assustador.", false),
            new Alt("Gira como um furacão furando o chão de concreto como no desenho animado da TV.", true)
        }));
        l9.Add(new Q("O Outback Australiano", new Alt[] {
            new Alt("É a vasta região interior árida e semiárida avermelhada que cobre quase toda a Austrália.", false),
            new Alt("Possui densidade populacional muito baixa e abriga vida selvagem resistente ao calor.", false),
            new Alt("É uma floresta úmida pantanosa onde chove neve o ano todo sem trégua.", true)
        }));
        l9.Add(new Q("A Nova Zelândia", new Alt[] {
            new Alt("É um país insular formado principalmente pela Ilha do Norte e pela Ilha do Sul no Pacífico.", false),
            new Alt("Possui fiordes impressionantes, montanhas nevadas e vulcões ativos de tirar o fôlego.", false),
            new Alt("Fica localizada no Mar do Caribe ao lado da ilha de Cuba e da Jamaica.", true)
        }));
        l9.Add(new Q("O Pássaro Kiwi", new Alt[] {
            new Alt("É uma ave nativa da Nova Zelândia que não voa, tem penas que parecem pelos e bico longo com narinas na ponta.", false),
            new Alt("É o símbolo e apelido afetuoso pelo qual os próprios neozelandeses são conhecidos no mundo.", false),
            new Alt("É uma fruta mágica que cria pernas à noite e sai correndo pela casa.", true)
        }));
        l9.Add(new Q("O Povo Maori", new Alt[] {
            new Alt("São os habitantes polinésios indígenas originários da Nova Zelândia.", false),
            new Alt("São famosos por sua rica cultura artística, tatuagens faciais (Ta Moko) e a dança cerimonial Haka.", false),
            new Alt("Chegaram à Terra em discos voadores durante o século vinte e um.", true)
        }));
        l9.Add(new Q("A Dança Haka", new Alt[] {
            new Alt("É uma dança cerimonial tradicional maori com batidas fortes nos pés, caretas e cantos vigorosos.", false),
            new Alt("É apresentada mundialmente pela famosa seleção neozelandesa de rugby (os All Blacks) antes dos jogos.", false),
            new Alt("É uma cantiga de ninar suave tocada ao violino para bebês recém-nascidos dormirem.", true)
        }));
        l9.Add(new Q("O Fiorde Milford Sound", new Alt[] {
            new Alt("Fica na Ilha do Sul da Nova Zelândia, esculpido por antigas geleiras gigantescas.", false),
            new Alt("Possui penhascos verticais que sobem direto da água do mar com cachoeiras que caem centenas de metros.", false),
            new Alt("Foi esculpido em gesso por arquitetos gregos no ano passado em um parque temático.", true)
        }));
        l9.Add(new Q("Os Gêiseres de Rotorua", new Alt[] {
            new Alt("Ficam na Ilha do Norte da Nova Zelândia, famosa por piscinas de lama borbulhante e gêiseres termais.", false),
            new Alt("O gêiser Pohutu esguicha água fervente até trinta metros no ar várias vezes ao dia.", false),
            new Alt("Esguicham limonada gelada açucarada para os turistas beberem de canudinho.", true)
        }));
        l9.Add(new Q("A Ilha de Páscoa (Rapa Nui)", new Alt[] {
            new Alt("É uma ilha vulcânica isolada no Pacífico chileno famosa pelas colossais estátuas de pedra (Moais).", false),
            new Alt("Os Moais foram esculpidos pelo povo nativo Rapa Nui a partir de rochas vulcânicas de pedreiras.", false),
            new Alt("É uma fábrica flutuante onde coelhos de verdade produzem ovos de chocolate comerciais.", true)
        }));
        l9.Add(new Q("As Estátuas Moais", new Alt[] {
            new Alt("São cabeças e torsos gigantescos de pedra talhados e posicionados em plataformas de frente para o interior da ilha.", false),
            new Alt("Muitas possuem corpos inteiros enterrados sob o solo com inscrições nas costas.", false),
            new Alt("Foram feitas de borracha sintética e colocadas lá para servirem de bóias salva-vidas.", true)
        }));
        l9.Add(new Q("A Ilha de Fiji", new Alt[] {
            new Alt("É uma nação insular do Pacífico Sul composta por mais de trezentas ilhas tropicais paradisíacas.", false),
            new Alt("Famosa por praias de areia branca, recifes de corais vibrantes e a cordial hospitalidade local.", false),
            new Alt("Fica localizada no Oceano Ártico coberta por geleiras de trinta metros de neve.", true)
        }));
        l9.Add(new Q("A Polinésia Francesa e Bora Bora", new Alt[] {
            new Alt("É um conjunto de ilhas no Pacífico famoso por atóis com lagoas de águas turquesas cristalinas.", false),
            new Alt("Bora Bora é cercada por um anel de recifes e um vulcão extinto no centro (Monte Otemanu).", false),
            new Alt("Fica situada no meio do deserto do Saara entre dunas de areia seca.", true)
        }));
        l9.Add(new Q("O Atol de Coral", new Alt[] {
            new Alt("É uma ilha oceânica em formato de anel circular de recife de coral que envolve uma lagoa no meio.", false),
            new Alt("Forma-se ao longo de milhões de anos conforme um antigo vulcão submarino afunda no oceano.", false),
            new Alt("É uma rosquinha doce de confeitaria que caiu na água e aumentou de tamanho.", true)
        }));
        l9.Add(new Q("A Ilha de Galápagos", new Alt[] {
            new Alt("Fica no Oceano Pacífico e pertence ao Equador, famosa por sua vida selvagem intocada e única.", false),
            new Alt("Serviu de inspiração crucial para os estudos de evolução biológica do cientista Charles Darwin.", false),
            new Alt("É uma base subterrânea habitada exclusivamente por pinguins mecânicos robóticos.", true)
        }));
        l9.Add(new Q("As Tartarugas-Gigantes de Galápagos", new Alt[] {
            new Alt("Podem pesar mais de quatrocentos quilos e viver mais de cem a cento e cinquenta anos na natureza.", false),
            new Alt("Possuem carapaças imensas que variam de formato de acordo com a vegetação de cada ilha onde vivem.", false),
            new Alt("São velozes como carros de Fórmula 1 e saltam de paraquedas de árvores.", true)
        }));
        l9.Add(new Q("As Iguanas-Marinhas de Galápagos", new Alt[] {
            new Alt("São os únicos lagartos do mundo que mergulham no oceano para se alimentar de algas nas rochas.", false),
            new Alt("Expelem o excesso de sal ingerido através de espirros especiais pelas narinas.", false),
            new Alt("Têm asas de morcego e voam pelos ares cantando como papagaios falantes.", true)
        }));
        l9.Add(new Q("A Ilha de Bali", new Alt[] {
            new Alt("É uma famosa ilha paradisíaca da Indonésia com templos hindus, terraços de arroz verdes e praias famosas.", false),
            new Alt("Possui uma rica tradição cultural de danças balinesas com trajes dourados e música gamelão.", false),
            new Alt("Fica perto da Antártida e toda a sua população mora dentro de iglus de gelo.", true)
        }));
        l9.Add(new Q("O Dragão-de-Komodo", new Alt[] {
            new Alt("É a maior espécie de lagarto existente no mundo, habitando ilhas da Indonésia como Komodo.", false),
            new Alt("Pode passar de três metros de comprimento e possui olfato aguçadíssimo através de sua língua bifurcada.", false),
            new Alt("Cospe labaredas de fogo pela boca e guarda potes de ouro no fundo de cavernas.", true)
        }));
        l9.Add(new Q("A Ilha de Papua-Nova Guiné", new Alt[] {
            new Alt("É a segunda maior ilha do planeta Terra em área, dividida entre a Indonésia e o país Papua-Nova Guiné.", false),
            new Alt("Possui imensas florestas montanhosas onde se falam centenas de línguas indígenas diferentes.", false),
            new Alt("É uma placa de isopor gigante colocada na água para turistas pegarem sol.", true)
        }));
        l9.Add(new Q("As Aves-do-Paraíso", new Alt[] {
            new Alt("Vivem principalmente nas florestas de Papua-Nova Guiné e no norte da Austrália.", false),
            new Alt("Os machos exibem plumagens coloridas espetaculares e danças acrobáticas para impressionar as fêmeas.", false),
            new Alt("São pássaros feitos de metal que funcionam com controle remoto e baterias solares.", true)
        }));
        l9.Add(new Q("A Ilha de Samoa", new Alt[] {
            new Alt("É uma nação polinésia do Pacífico Sul conhecida por suas praias vulcânicas, cascatas e tradição familiar Fa'a Samoa.", false),
            new Alt("O escritor escocês Robert Louis Stevenson viveu e foi sepultado no alto de uma de suas montanhas.", false),
            new Alt("Fica localizada dentro do Lago Titicaca, entre a Bolívia e o Peru.", true)
        }));
        l9.Add(new Q("O Ponto Nemo", new Alt[] {
            new Alt("É o polo oceânico de inacessibilidade, o ponto mais distante de qualquer terra firme em todo o planeta.", false),
            new Alt("Fica no sul do Oceano Pacífico e os seres humanos mais próximos com frequência são os astronautas da ISS.", false),
            new Alt("É um shopping center aquático com lojas e lanchonetes construído sobre corais.", true)
        }));
        l9.Add(new Q("O Atol das Rocas", new Alt[] {
            new Alt("É o único atol de coral existente em todo o Oceano Atlântico Sul, pertencente ao Brasil.", false),
            new Alt("É uma reserva biológica intocada no Rio Grande do Norte que protege milhares de aves marinhas e tartarugas.", false),
            new Alt("Possui uma metrópole futurista com prédios de cem andares e metrô subterrâneo.", true)
        }));
        l9.Add(new Q("O Arquipélago de Fernando de Noronha", new Alt[] {
            new Alt("É um santuário ecológico vulcânico brasileiro no Atlântico famoso pela Praia do Sancho e golfinhos-rotadores.", false),
            new Alt("É Patrimônio Natural Mundial pela UNESCO e tem limites estritos no número de visitantes diários.", false),
            new Alt("Fica no meio do Rio Amazonas e as pessoas chegam lá pegando o metrô de Manaus.", true)
        }));
        l9.Add(new Q("A Ilha de Trindade", new Alt[] {
            new Alt("É uma remota ilha vulcânica brasileira no Oceano Atlântico a mais de 1.100 km da costa do Espírito Santo.", false),
            new Alt("Abriga um posto oceanográfico mantido pela Marinha do Brasil e é berçário de tartarugas-verdes.", false),
            new Alt("É habitada por dinossauros herbívoros gigantes que nadam até Vitória todo domingo.", true)
        }));
        l9.Add(new Q("A Ilha de Creta", new Alt[] {
            new Alt("É a maior das ilhas da Grécia no Mar Mediterrâneo, berço da lendária civilização minoica.", false),
            new Alt("Na mitologia grega, era a ilha que abrigava o famoso labirinto do terrível Minotauro.", false),
            new Alt("Fica no Oceano Glacial Ártico e é cercada por campos de neve e gelo o ano todo.", true)
        }));
        l9.Add(new Q("A Ilha da Islândia", new Alt[] {
            new Alt("É conhecida como a terra do fogo e do gelo por reunir vulcões ativos e imensas geleiras lado a lado.", false),
            new Alt("Usa energia geotérmica do subsolo vulcânico para aquecer casas e gerar eletricidade limpa para o país.", false),
            new Alt("É um deserto tropical de areia amarela onde crescem florestas de coqueiros gigantes.", true)
        }));
        l9.Add(new Q("A Ilha da Sicília", new Alt[] {
            new Alt("É a maior ilha do Mar Mediterrâneo, situada bem na 'ponta da bota' da península da Itália.", false),
            new Alt("Abriga o Monte Etna, o vulcão ativo mais alto de todo o continente europeu.", false),
            new Alt("É uma ilha artificial de papelão flutuando sobre uma piscina de hotel em Paris.", true)
        }));
        l9.Add(new Q("A Ilha de Chipre", new Alt[] {
            new Alt("É uma grande ilha no leste do Mar Mediterrâneo com rica história grega e turca.", false),
            new Alt("Na mitologia antiga, acreditava-se que Afrodite, deusa da beleza, havia nascido de suas espumas marinhas.", false),
            new Alt("Fica localizada no meio do Polo Sul e é cercada de pinguins imperadores.", true)
        }));
        l9.Add(new Q("O Arquipélago de Svalbard", new Alt[] {
            new Alt("É um território norueguês no Oceano Glacial Ártico muito próximo do Polo Norte.", false),
            new Alt("Abriga o Silo Global de Sementes, que guarda milhões de sementes agrícolas do mundo em caso de catástrofes.", false),
            new Alt("É um balneário de praia tropical com parque aquático aquecido ao ar livre.", true)
        }));
        l9.Add(new Q("A Ilha de Santa Helena", new Alt[] {
            new Alt("É uma ilha vulcânica extremamente remota e isolada no meio do Oceano Atlântico Sul.", false),
            new Alt("Ficou famosa na história como o local de exílio final e morte do imperador francês Napoleão Bonaparte.", false),
            new Alt("É a capital econômica do Japão com os trens-bala mais velozes do planeta.", true)
        }));
        l9.Add(new Q("A Ilha de Manhattan e suas Pontes", new Alt[] {
            new Alt("É conectada ao restante de Nova York por pontes famosas como a Ponte do Brooklyn e túneis sob a água.", false),
            new Alt("É o centro financeiro mundial onde fica a famosa rua Wall Street e a bolsa de valores.", false),
            new Alt("Afunda cinco metros toda noite e precisa de cordas para ser puxada de volta de manhã.", true)
        }));
        l9.Add(new Q("A Ilha Grande no Rio de Janeiro", new Alt[] {
            new Alt("É uma famosa ilha cercada pela Mata Atlântica protegida e praias de água verde como Lopes Mendes.", false),
            new Alt("Não é permitida a circulação de carros comuns na ilha, mantendo trilhas e natureza preservadas.", false),
            new Alt("Possui uma pista de pouso internacional para jatos espaciais comerciais.", true)
        }));
        l9.Add(new Q("A Ilha de Marajó", new Alt[] {
            new Alt("Localizada no Pará, é a maior ilha fluviomarinha do mundo, banhada pelo Rio Amazonas e pelo Atlântico.", false),
            new Alt("É famosa pela criação de búfalos que andam pelas ruas e servem de patrulha para a polícia militar.", false),
            new Alt("Fica coberta de neve durante o mês de julho e os moradores constroem bonecos de gelo.", true)
        }));
        l9.Add(new Q("A Ilha do Bananal", new Alt[] {
            new Alt("Fica no estado do Tocantins e é a maior ilha fluvial (cercada apenas por rios de água doce) do planeta.", false),
            new Alt("É cercada pelas águas dos rios Araguaia e Javaés e abriga aldeias indígenas Carajás.", false),
            new Alt("É uma ilha de plástico flutuante no porto de Santos feita de garrafas pet recicladas.", true)
        }));
        l9.Add(new Q("A Ilha de Santorini", new Alt[] {
            new Alt("É uma ilha grega formada na caldeira de um vulcão marinho colossal que explodiu na antiguidade.", false),
            new Alt("É mundialmente famosa por suas casas brancas com cúpulas de igreja pintadas de azul no alto de falésias.", false),
            new Alt("É feita de queijo parmesão ralado e derrete quando o sol esquenta ao meio-dia.", true)
        }));
        l9.Add(new Q("A Ilha de Bornéu", new Alt[] {
            new Alt("É a terceira maior ilha do planeta, dividida entre três países: Indonésia, Malásia e Brunei.", false),
            new Alt("Possui uma das florestas tropicais mais antigas da Terra e é o lar do inteligente orangotango.", false),
            new Alt("Não possui árvores, sendo uma planície de mármore branco polido sem animais.", true)
        }));
        l9.Add(new Q("O Orangotango de Bornéu e Sumatra", new Alt[] {
            new Alt("É um grande primata arborícola de pelos alaranjados avermelhados que passa o dia no topo das árvores.", false),
            new Alt("Constrói ninhos novos de folhas e galhos nas copas das árvores toda noite para dormir.", false),
            new Alt("Mora no fundo de rios respirando por brânquias como as sardinhas e os bacalhaus.", true)
        }));
        l9.Add(new Q("A Micronésia e Melanésia", new Alt[] {
            new Alt("São duas das grandes regiões geográficas em que se divide a Oceania no Oceano Pacífico.", false),
            new Alt("Compreendem milhares de pequenas ilhas, recifes e ricas culturas navegadoras antigas.", false),
            new Alt("São dois países vizinhos localizados no meio da Floresta Amazônica brasileira.", true)
        }));
        l9.Add(new Q("A Ilha de Tuvalu", new Alt[] {
            new Alt("É um pequeno país formado por atóis de coral muito baixos no Oceano Pacífico.", false),
            new Alt("É uma das nações mais ameaçadas do mundo pela subida do nível dos mares decorrente do clima.", false),
            new Alt("Fica no topo da montanha mais alta dos Alpes suíços a quatro mil metros de altitude.", true)
        }));
        l9.Add(new Q("O Tubarão-Baleia nas Ilhas do Pacífico", new Alt[] {
            new Alt("É o maior peixe existente nos oceanos da Terra, podendo atingir mais de doze metros de comprimento.", false),
            new Alt("Apesar do tamanho colossal, é totalmente inofensivo para humanos, alimentando-se apenas de plâncton.", false),
            new Alt("Pula nas praias e corre atrás de cachorros e banhistas na areia seca.", true)
        }));
        l9.Add(new Q("A Cidade de Melbourne", new Alt[] {
            new Alt("É a segunda cidade mais populosa da Austrália, conhecida por sua cena cultural, bondes e esportes.", false),
            new Alt("Fica no estado de Victoria, perto da foz do rio Yarra, com clima que muda várias vezes ao dia.", false),
            new Alt("Fica nas selvas da Colômbia e só pode ser acessada de canoa a remo indígena.", true)
        }));
        l9.Add(new Q("O Estreito de Torres", new Alt[] {
            new Alt("É o braço de mar que separa o extremo norte da Austrália da ilha de Papua-Nova Guiné.", false),
            new Alt("É repleto de recifes de corais, ilhotas e tem navegação histórica de povos nativos navegadores.", false),
            new Alt("É uma esteira rolante mecânica instalada para transportar mercadorias pela fronteira.", true)
        }));
        l9.Add(new Q("A Oceania", new Alt[] {
            new Alt("É o menor continente do mundo em extensão de terras emersas, mas espalhado por um imenso oceano.", false),
            new Alt("É quase inteiramente cercada pelas águas do Oceano Pacífico e do Oceano Índico.", false),
            new Alt("É um continente coberto por gelo de dois quilômetros de espessura habitado por ursos polares.", true)
        }));

        // ==========================================
        // NIVEL 10: RECORDES E EXTREMOS DO PLANETA (50 Questões)
        // ==========================================
        var l10 = levels[10];
        l10.Add(new Q("O Monte Everest", new Alt[] {
            new Alt("Localizado na cordilheira do Himalaia, é o ponto mais alto da superfície do planeta Terra (8.848 m).", false),
            new Alt("Fica na fronteira entre o Nepal e a região autônoma do Tibete na China.", false),
            new Alt("Pode ser escalado em dez minutos por qualquer pessoa descendo por uma escada rolante.", true)
        }));
        l10.Add(new Q("A Fossa das Marianas", new Alt[] {
            new Alt("É o ponto mais profundo conhecido de todos os oceanos da Terra, no Oceano Pacífico.", false),
            new Alt("Atinge quase 11.000 metros de profundidade no local chamado Depressão Challenger.", false),
            new Alt("É uma montanha vulcânica que sobe até tocar a órbita da Lua todas as noites.", true)
        }));
        l10.Add(new Q("A Antártida e o Frio Extremo", new Alt[] {
            new Alt("É o continente mais frio, mais seco e com os ventos mais fortes de todo o planeta Terra.", false),
            new Alt("Na estação russa Vostok foi registrada a temperatura recorde de quase noventa graus negativos (-89,2 °C).", false),
            new Alt("É uma floresta tropical onde as pessoas nadam de calção de banho nos fins de semana.", true)
        }));
        l10.Add(new Q("O Deserto do Atacama", new Alt[] {
            new Alt("Localizado no Chile, é considerado o deserto não-polar mais árido e seco de todo o mundo.", false),
            new Alt("Por ter céu limpo e seco quase o ano todo, abriga os maiores observatórios astronômicos do mundo.", false),
            new Alt("Chove nele todos os dias sem parar desde o início da criação do mundo.", true)
        }));
        l10.Add(new Q("A Cidade Mais Quente Registrada (Vale da Morte)", new Alt[] {
            new Alt("No Vale da Morte (EUA) foi registrada uma das maiores temperaturas do ar da história: 56,7 °C.", false),
            new Alt("O calor intenso na bacia é gerado pelo relevo afundado cercado por montanhas que prendem o ar quente.", false),
            new Alt("As pessoas esquiam no gelo durante o meio-dia usando patins de neve térmica.", true)
        }));
        l10.Add(new Q("A Cidade de Oymyakon", new Alt[] {
            new Alt("Fica na Sibéria, Rússia, e é considerada a localidade habitada permanentemente mais fria da Terra.", false),
            new Alt("As temperaturas no inverno com frequência caem abaixo de cinquenta graus negativos (-50 °C).", false),
            new Alt("Fica no Equador e tem plantações de cana-de-açúcar e abacaxi o ano inteiro.", true)
        }));
        l10.Add(new Q("O Vulcão Mauna Kea", new Alt[] {
            new Alt("Fica no Havaí e, se medido desde sua base no fundo do oceano até o topo, é a montanha mais alta da Terra (mais de 10.000 m).", false),
            new Alt("Seu cume acima das nuvens abriga alguns dos mais avançados telescópios ópticos do planeta.", false),
            new Alt("É uma pirâmide oca de ouro feita por astronautas norte-americanos em 1969.", true)
        }));
        l10.Add(new Q("O Vulcão Chimborazo", new Alt[] {
            new Alt("Fica no Equador e seu cume é o ponto da superfície da Terra mais próximo do espaço e das estrelas.", false),
            new Alt("Isso ocorre porque a Terra não é uma esfera perfeita, sendo mais larga na linha do Equador.", false),
            new Alt("Fica submerso no meio do rio Tietê em São Paulo sem ninguém perceber.", true)
        }));
        l10.Add(new Q("O Salar de Uyuni", new Alt[] {
            new Alt("Fica na Bolívia e é a maior planície de sal contínua de todo o planeta Terra.", false),
            new Alt("Durante o período das chuvas, uma fina lâmina de água transforma o salar no maior espelho natural do mundo.", false),
            new Alt("É feito de açúcar mascavo e os turistas comem o chão com colheres de sobremesa.", true)
        }));
        l10.Add(new Q("O Mar Morto", new Alt[] {
            new Alt("É o ponto em terra firme mais baixo do planeta, a mais de 430 metros abaixo do nível do mar.", false),
            new Alt("Sua água é quase dez vezes mais salgada que os oceanos normais, fazendo os banhistas flutuarem sem esforço.", false),
            new Alt("É uma piscina de refrigerante com gás onde peixes dourados gigantes cantam ópera.", true)
        }));
        l10.Add(new Q("O Salto Ángel (Kerepakupai Merú)", new Alt[] {
            new Alt("Fica na Venezuela e é a cachoeira ininterrupta mais alta do mundo, com quase mil metros de queda (979 m).", false),
            new Alt("Cai do alto do imponente platô rochoso de montanha plana chamado Auyan Tepui.", false),
            new Alt("Cai de um cano de pia de cozinha instalado no telhado de um prédio em Caracas.", true)
        }));
        l10.Add(new Q("O Rio Amazonas e a Vazão Recorde", new Alt[] {
            new Alt("É o rio com o maior volume de água e a maior bacia hidrográfica de todo o planeta Terra.", false),
            new Alt("Despeja tanta água doce no oceano que representa cerca de vinte por cento de toda a água fluvial que chega aos mares.", false),
            new Alt("Seca totalmente todo ano e as pessoas atravessam a pé andando sobre areia seca.", true)
        }));
        l10.Add(new Q("O Lago Baikal", new Alt[] {
            new Alt("Localizado na Sibéria (Rússia), é o lago mais profundo do mundo (1.642 m) e o mais antigo da Terra.", false),
            new Alt("Contém cerca de vinte por cento de toda a água doce líquida superficial do planeta Terra.", false),
            new Alt("É uma poça d'água de vinte centímetros de profundidade que evapora no almoço.", true)
        }));
        l10.Add(new Q("A Floresta Amazônica", new Alt[] {
            new Alt("É a maior floresta tropical do mundo, abrigando uma em cada dez espécies conhecidas do planeta.", false),
            new Alt("Produz os chamados 'rios voadores', imensos fluxos de vapor d'água na atmosfera que levam chuva a várias regiões.", false),
            new Alt("É feita de árvores artificiais de plástico que nunca precisam de água ou sol.", true)
        }));
        l10.Add(new Q("O Lugar Mais Chuvoso da Terra (Mawsynram)", new Alt[] {
            new Alt("Fica na Índia e detém o recorde de lugar habitado com maior média anual de chuvas do mundo.", false),
            new Alt("As chuvas intensas são causadas pelas monções que trazem umidade do Oceano Índico contra o Himalaia.", false),
            new Alt("Nunca viu uma única gota de chuva cair em toda a sua história registrada.", true)
        }));
        l10.Add(new Q("A Cidade Mais Alta do Mundo (La Rinconada)", new Alt[] {
            new Alt("Fica nos Andes do Peru a mais de 5.100 metros de altitude, cercada por geleiras permanentes.", false),
            new Alt("O ar lá é muito rarefeito e a vida exige grande aclimatação física por falta de oxigênio.", false),
            new Alt("Fica na praia ao nível do mar e os moradores surfam nas ondas todos os dias.", true)
        }));
        l10.Add(new Q("A Geleira Lambert", new Alt[] {
            new Alt("Fica na Antártida e é a maior geleira em extensão do planeta Terra, com mais de 400 km de comprimento.", false),
            new Alt("Drena cerca de oito por cento de toda a calota de gelo antártica rumo ao oceano.", false),
            new Alt("Derrete totalmente todo mês de janeiro e vira uma plantação de melancias.", true)
        }));
        l10.Add(new Q("O Ponto Mais Longe da Terra (Polo da Inacessibilidade Eurasiático)", new Alt[] {
            new Alt("Fica no noroeste da China e é o ponto em terra firme mais distante de qualquer oceano do mundo (mais de 2.500 km).", false),
            new Alt("Fica perto da bacia de Dzungaria, cercado por desertos e montanhas imensas.", false),
            new Alt("É uma ilhota de areia no meio da praia de Copacabana no Rio de Janeiro.", true)
        }));
        l10.Add(new Q("O Maior País do Mundo (Rússia)", new Alt[] {
            new Alt("É o país com a maior área territorial do planeta, cobrindo mais de dezessete milhões de quilômetros quadrados.", false),
            new Alt("Estende-se por dois continentes (Europa e Ásia) e possui onze fusos horários diferentes.", false),
            new Alt("É tão pequeno que cabe inteiro dentro de uma quadra de basquete comum.", true)
        }));
        l10.Add(new Q("O Menor País do Mundo (Vaticano)", new Alt[] {
            new Alt("Com menos de meio quilômetro quadrado de área, é o menor Estado soberano do planeta Terra.", false),
            new Alt("Fica totalmente situado como um enclave dentro da cidade de Roma, capital da Itália.", false),
            new Alt("É maior que a América do Sul inteira e tem três milhões de quilômetros de ferrovias.", true)
        }));
        l10.Add(new Q("A Maior Ilha do Mundo (Groenlândia)", new Alt[] {
            new Alt("Com mais de dois milhões de quilômetros quadrados, é a maior ilha que não é considerada continente.", false),
            new Alt("Cerca de oitenta por cento de sua superfície é coberta por uma calota de gelo com quilômetros de espessura.", false),
            new Alt("É uma jangada de bambu construída por pescadores do litoral da Bahia.", true)
        }));
        l10.Add(new Q("O Maior Oceano da Terra (Pacífico)", new Alt[] {
            new Alt("Cobre mais de um terço de toda a superfície da Terra, sendo maior que todas as terras emersas somadas.", false),
            new Alt("Abriga o famoso Círculo de Fogo, onde ocorrem a maioria dos terremotos e vulcões do mundo.", false),
            new Alt("Foi cavado no ano 1980 para servir de piscina de treinamento olímpico.", true)
        }));
        l10.Add(new Q("O Menor Oceano da Terra (Glacial Ártico)", new Alt[] {
            new Alt("Cerca o Polo Norte e é o menor e mais raso dos oceanos do planeta Terra.", false),
            new Alt("Grande parte de sua superfície fica congelada durante o ano todo sob uma camada de banquisa de gelo marinho.", false),
            new Alt("Fica no meio do deserto do Saara entre camelos e oásis de água morna.", true)
        }));
        l10.Add(new Q("O Rio Mais Curto do Mundo (Rio Roe)", new Alt[] {
            new Alt("Fica em Montana (EUA) e tem apenas cerca de 61 metros de comprimento antes de desaguar no Rio Missouri.", false),
            new Alt("Foi registrado no livro dos recordes Guinness por seu trajeto extremamente pequeno e caudaloso.", false),
            new Alt("Dá três voltas completas ao redor da Terra antes de sumir no espaço sideral.", true)
        }));
        l10.Add(new Q("O Lago Mais Alto Navegável (Lago Titicaca)", new Alt[] {
            new Alt("Fica na cordilheira dos Andes entre o Peru e a Bolívia a mais de 3.810 metros de altitude.", false),
            new Alt("É o maior lago da América do Sul em volume d'água e berço sagrado de mitos dos Incas.", false),
            new Alt("Fica dentro de um vulcão de fogo na Lua e não possui água líquida.", true)
        }));
        l10.Add(new Q("A Árvore Mais Alta do Mundo (Hyperion)", new Alt[] {
            new Alt("É uma sequoia-costeira na Califórnia (EUA) que mede mais de 115 metros de altura.", false),
            new Alt("Sua localização exata na floresta é mantida em segredo para proteger suas raízes de pisoteamento.", false),
            new Alt("É um bonsai que cresce dentro de uma xícara de chá na mesa da cozinha.", true)
        }));
        l10.Add(new Q("A Árvore Mais Velha Conhecida (Matusalém)", new Alt[] {
            new Alt("É um pinheiro da espécie bristlecone nas montanhas da Califórnia com quase 4.800 anos de idade.", false),
            new Alt("Já estava viva e germinando quando os egípcios construíam as primeiras grandes pirâmides.", false),
            new Alt("Foi plantada por astronautas que voltaram do futuro em uma máquina do tempo.", true)
        }));
        l10.Add(new Q("O Animal Mais Barulhento (Cachalote e Baleia-Azul)", new Alt[] {
            new Alt("A baleia-azul emite cantos de baixa frequência que podem viajar por centenas de quilômetros pelos oceanos.", false),
            new Alt("Os estalos de ecolocalização do cachalote podem ultrapassar 230 decibéis de potência na água.", false),
            new Alt("O animal mais barulhento do mundo é o bicho-preguiça quando boceja no galho.", true)
        }));
        l10.Add(new Q("O Maior Animal de Todos os Tempos (Baleia-Azul)", new Alt[] {
            new Alt("Pode atingir trinta metros de comprimento e pesar até duzentas toneladas, maior que qualquer dinossauro já existido.", false),
            new Alt("Apenas a sua língua pode pesar tanto quanto um elefante adulto inteiro.", false),
            new Alt("Mora em poças de chuva na rua e come grama com as formigas do jardim.", true)
        }));
        l10.Add(new Q("O Relâmpago Mais Frequente (Relâmpago do Catatumbo)", new Alt[] {
            new Alt("Ocorre no Lago de Maracaibo, na Venezuela, gerando milhares de raios quase trezentas noites por ano.", false),
            new Alt("É o local da Terra com a maior concentração de descargas elétricas atmosféricas do planeta.", false),
            new Alt("Os raios são lâmpadas incandescentes que pescadores acendem para ler jornal.", true)
        }));
        l10.Add(new Q("O Lago Boiling Lake (Lago Fervente)", new Alt[] {
            new Alt("Fica na ilha caribenha de Dominica e é uma fumarola inundada onde a água borbulha como sopa fervente.", false),
            new Alt("As bordas atingem temperaturas de quase noventa graus Celsius e o centro não pode ser medido.", false),
            new Alt("É uma pista de patinação no gelo usada para campeonatos de hóquei ártico.", true)
        }));
        l10.Add(new Q("O Vulcão Kilauea", new Alt[] {
            new Alt("Localizado na ilha do Havaí, é um dos vulcões em atividade mais contínua e produtiva da Terra moderna.", false),
            new Alt("Sua lava basáltica muito fluida escorre para o oceano, criando novas terras de rocha negra.", false),
            new Alt("Solta sorvete de morango e pipoca doce quando entra em erupção no verão.", true)
        }));
        l10.Add(new Q("A Depressão de Afar e o Triângulo de Afar", new Alt[] {
            new Alt("No leste da África, é o único lugar da Terra onde três placas tectônicas estão se separando em terra firme.", false),
            new Alt("No futuro geológico de milhões de anos, as águas do Mar Vermelho inundarão o vale criando um novo oceano.", false),
            new Alt("Foi construída em formato triangular por trabalhadores para pouso de helicópteros.", true)
        }));
        l10.Add(new Q("O Cânion Mais Profundo do Mundo (Yarlung Tsangpo)", new Alt[] {
            new Alt("Localizado no Tibete (China), atinge mais de seis mil metros de profundidade em alguns trechos.", false),
            new Alt("É muito mais profundo que o Grand Canyon americano e contorna montanhas nevadas monumentais.", false),
            new Alt("Foi escavado com colheres de sopa por soldados da Primeira Guerra Mundial.", true)
        }));
        l10.Add(new Q("A Maior Caverna do Mundo (Hang Son Doong)", new Alt[] {
            new Alt("Fica no Vietnã e tem galerias tão colossais que possuem sua própria selva interior, rio e nuvens de nevoeiro.", false),
            new Alt("Uma aeronave de passageiros Boeing 747 poderia voar confortavelmente dentro de seus maiores salões.", false),
            new Alt("É uma gaveta de armário que cabe apenas dois pares de meias dobradas.", true)
        }));
        l10.Add(new Q("O Mar Mais Salgado Natural (Lago Don Juan)", new Alt[] {
            new Alt("É um pequeno lago na Antártida com água tão salgada que não congela nem a cinquenta graus negativos (-50 °C).", false),
            new Alt("Tem mais de quarenta por cento de salinidade em sua composição líquida densa.", false),
            new Alt("É uma garrafa térmica esquecida por um explorador que continuou cheia de café.", true)
        }));
        l10.Add(new Q("O Geleira Perito Moreno", new Alt[] {
            new Alt("Fica na Patagônia Argentina e é uma das poucas geleiras do mundo que mantém equilíbrio de gelo estável.", false),
            new Alt("Bloqueia um braço do Lago Argentino periodicamente até a pressão romper a ponte de gelo com estrondo épico.", false),
            new Alt("Fica situada no meio do calor escaldante do deserto de Dubai.", true)
        }));
        l10.Add(new Q("O Deserto Branco de Lençóis Maranhenses", new Alt[] {
            new Alt("Fica no Brasil e é único no mundo por reunir dunas de areia branca intercaladas por lagoas de água doce cristalina.", false),
            new Alt("As lagoas se enchem com as chuvas do primeiro semestre e abrigam peixes e turistas.", false),
            new Alt("É um campo de farinha de trigo plantado por padeiros do século dezoito.", true)
        }));
        l10.Add(new Q("A Fossa de Java (Sunda)", new Alt[] {
            new Alt("É o ponto mais profundo do Oceano Índico, ultrapassando sete mil e setecentos metros de profundidade.", false),
            new Alt("Fica ao sul do arquipélago indonésio em uma zona de forte convergência de placas e tsunamis.", false),
            new Alt("É uma montanha de areia no centro de Londres onde as pessoas sobem de escada rolante.", true)
        }));
        l10.Add(new Q("O Arquipélago de Tristão da Cunha", new Alt[] {
            new Alt("É considerado o arquipélago habitado permanentemente mais isolado do planeta Terra no Atlântico Sul.", false),
            new Alt("A terra habitada mais próxima fica a mais de 2.400 quilômetros de distância (África do Sul).", false),
            new Alt("Tem pontes de pedestres de madeira ligando as casas diretamente a Copacabana.", true)
        }));
        l10.Add(new Q("A Maior Floresta de Coníferas (Taiga)", new Alt[] {
            new Alt("É o maior bioma terrestre da Terra em área contínua, estendendo-se pela Rússia, Canadá e Escandinávia.", false),
            new Alt("Armazena imensas quantidades de carbono no solo congelado e nas árvores de pinheiros.", false),
            new Alt("É uma plantação de árvores de algodão-doce comestíveis protegidas por guardas florestais.", true)
        }));
        l10.Add(new Q("A Floresta Fóssil de Gilboa", new Alt[] {
            new Alt("Fica no estado de Nova York e preserva restos petrificados de uma das florestas mais antigas conhecidas na Terra (380 mi anos).", false),
            new Alt("Existiu muito antes do surgimento dos primeiros dinossauros no planeta.", false),
            new Alt("Foi plantada no ano 2002 por robôs que vieram do planeta Júpiter.", true)
        }));
        l10.Add(new Q("O Rio Subterrâneo de Porto Princesa", new Alt[] {
            new Alt("Fica nas Filipinas e é um dos rios subterrâneos navegáveis mais longos do mundo, desembocando no mar.", false),
            new Alt("Atravessa uma imensa caverna calcária repleta de estalactites e morcegos nativos protegidos.", false),
            new Alt("É um duto de ventilação de metrô que foi esquecido ligado com a torneira aberta.", true)
        }));
        l10.Add(new Q("O Vulcão Tambora", new Alt[] {
            new Alt("Sua erupção colossal na Indonésia em 1815 foi a mais violenta e mortal registrada na história moderna da humanidade.", false),
            new Alt("Lançou tanta cinza na atmosfera que o ano seguinte (1816) ficou conhecido no mundo como 'o ano sem verão'.", false),
            new Alt("Lançou confete e serpentina de papel que cobriram o céu de todo o Brasil.", true)
        }));
        l10.Add(new Q("O Krakatoa", new Alt[] {
            new Alt("É um vulcão lendário entre as ilhas de Java e Sumatra cuja explosão em 1883 gerou tsunamis gigantescos.", false),
            new Alt("O som da explosão foi tão ensurdecedor que foi ouvido a quase cinco mil quilômetros de distância.", false),
            new Alt("Era um relógio despertador gigante feito para acordar o presidente dos Estados Unidos.", true)
        }));
        l10.Add(new Q("A Geleira de Siachen", new Alt[] {
            new Alt("Fica na cordilheira de Caracórum no Himalaia, sendo a mais longa geleira em região não-polar do mundo (76 km).", false),
            new Alt("Fica a mais de 5.400 metros de altitude em uma região fronteiriça disputada e congelante.", false),
            new Alt("É um freezer de sorvete instalado no pátio de uma escola primária da Índia.", true)
        }));
        l10.Add(new Q("O Fogo Eterno de Baba Gurgur", new Alt[] {
            new Alt("É um campo de chamas naturais no Iraque que queima sem parar há milhares de anos devido ao gás no subsolo.", false),
            new Alt("Já era citado por historiadores da Grécia Antiga como uma fogueira sagrada que nunca se apaga.", false),
            new Alt("São lâmpadas fluorescentes colocadas em 1999 por operários de uma obra abandonada.", true)
        }));
        l10.Add(new Q("As Montanhas Zhangjiajie", new Alt[] {
            new Alt("Ficam na China e são famosas por seus pilares colossais de arenito e quartzo que parecem flutuar na névoa.", false),
            new Alt("Inspiraram os cenários das montanhas flutuantes de Pandora no famoso filme Avatar.", false),
            new Alt("São prédios de apartamentos comerciais modernos construídos no ano passado.", true)
        }));
        l10.Add(new Q("A Caverna dos Cristais Gigantes (Naica)", new Alt[] {
            new Alt("Fica no México e abriga os maiores cristais naturais de gipsita do mundo, alguns com mais de onze metros de comprimento.", false),
            new Alt("O ambiente é extremamente quente e úmido (mais de 50 °C), exigindo roupas especiais de refrigeração para entrar.", false),
            new Alt("Os cristais são feitos de plástico e foram colocados lá para filmar uma festa infantil.", true)
        }));
        l10.Add(new Q("O Planeta Terra", new Alt[] {
            new Alt("É o terceiro planeta a partir do Sol e o único corpo celeste conhecido até hoje a abrigar vida confirmada.", false),
            new Alt("Cerca de setenta e um por cento de sua superfície é coberta por água líquida em oceanos e mares.", false),
            new Alt("É perfeitamente quadrado como um dado de jogos de tabuleiro e tem seis cantos afiados.", true)
        }));

        // Write to temp_geo_levels_7_10.lua
        var sb = new StringBuilder();
        for (int lvl = 7; lvl <= 10; lvl++) {
            sb.AppendLine(string.Format("    [{0}] = {{", lvl));
            sb.AppendLine("        Dados = {");
            foreach (var q in levels[lvl]) {
                sb.AppendLine("            {");
                sb.AppendLine(string.Format("                Nome = \"{0}\",", Escape(q.Nome)));
                sb.AppendLine("                Alternativas = {");
                foreach (var a in q.Alts) {
                    sb.AppendLine(string.Format("                    {{ Texto = \"{0}\", Falsa = {1} }},", Escape(a.T), a.F ? "true" : "false"));
                }
                sb.AppendLine("                }");
                sb.AppendLine("            },");
            }
            sb.AppendLine("        }");
            sb.AppendLine("    },");
        }

        File.WriteAllText("temp_geo_levels_7_10.lua", sb.ToString(), Encoding.UTF8);
        Console.WriteLine("Wrote temp_geo_levels_7_10.lua with 4 levels (200 questions)");
    }

    static string Escape(string s) {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}
