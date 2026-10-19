using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class BuildFullGeografia {
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
        for (int i = 0; i <= 10; i++) levels[i] = new List<Q>();

        // NIVEL 0 (Tutorial)
        levels[0].Add(new Q("Brasil", new Alt[] {
            new Alt("Conhecido pela culinária diversificada e seu famoso prato: Feijoada.", false),
            new Alt("Possui a maior floresta tropical úmida do mundo.", false),
            new Alt("Tem fortes ações vulcânicas em seu território atual.", true)
        }));

        // NIVEL 1 (50 Questoes - Paises, Capitais e Curiosidades)
        var l1 = levels[1];
        l1.Add(new Q("Alemanha", new Alt[] {
            new Alt("É o país com a famosa rede de rodovias de alta velocidade chamada Autobahn.", false),
            new Alt("O primeiro livro impresso no Ocidente com tipos móveis (Bíblia de Gutenberg) foi feito lá.", false),
            new Alt("É o único país da Europa que não tem nenhuma saída para o mar.", true)
        }));
        l1.Add(new Q("França", new Alt[] {
            new Alt("A famosa Torre Eiffel fica localizada em Paris, sua capital.", false),
            new Alt("É um dos países mais visitados por turistas de todo o mundo.", false),
            new Alt("É o único país do continente europeu que possui duas capitais oficiais ao mesmo tempo.", true)
        }));
        l1.Add(new Q("Espanha", new Alt[] {
            new Alt("Está localizada na Península Ibérica, no sudoeste da Europa.", false),
            new Alt("É famosa pela animada festa tradicional de La Tomatina, com guerra de tomates.", false),
            new Alt("É o único país do planeta inteiro onde as pessoas falam a língua espanhola.", true)
        }));
        l1.Add(new Q("Itália", new Alt[] {
            new Alt("O antigo e histórico Coliseu fica localizado em sua capital, Roma.", false),
            new Alt("Seu mapa no globo terrestre tem o formato famoso de uma bota.", false),
            new Alt("Fica localizada no meio do Oceano Pacífico e não possui montanhas.", true)
        }));
        l1.Add(new Q("Portugal", new Alt[] {
            new Alt("Lisboa é a sua capital e foi o ponto de partida de grandes navegações históricas.", false),
            new Alt("O português é a língua oficial falada pelo seu povo.", false),
            new Alt("Faz fronteira terrestre direta com a França e com a Alemanha.", true)
        }));
        l1.Add(new Q("Japão", new Alt[] {
            new Alt("É um país insular formado por milhares de ilhas no Oceano Pacífico.", false),
            new Alt("O Monte Fuji é um vulcão sagrado e o ponto mais alto do país.", false),
            new Alt("Fica localizado no continente africano, bem perto do deserto do Saara.", true)
        }));
        l1.Add(new Q("Estados Unidos", new Alt[] {
            new Alt("Sua capital federal é a cidade de Washington, D.C.", false),
            new Alt("A famosa Estátua da Liberdade fica situada na cidade de Nova York.", false),
            new Alt("O país é composto por apenas dez estados em todo o seu território.", true)
        }));
        l1.Add(new Q("Canadá", new Alt[] {
            new Alt("É o segundo maior país do mundo em extensão territorial total.", false),
            new Alt("A folha de bordo vermelha é o símbolo nacional estampado em sua bandeira.", false),
            new Alt("Possui clima quente e desértico durante todos os meses do ano.", true)
        }));
        l1.Add(new Q("México", new Alt[] {
            new Alt("Abriga antigas e famosas pirâmides construídas pelos povos maia e asteca.", false),
            new Alt("Sua culinária tradicional inclui pratos típicos como tacos e guacamole.", false),
            new Alt("Está localizado no continente da América do Sul, ao lado do Brasil.", true)
        }));
        l1.Add(new Q("Argentina", new Alt[] {
            new Alt("É um país vizinho do Brasil situado na América do Sul.", false),
            new Alt("A região sul da Patagônia possui montanhas nevadas e geleiras grandiosas.", false),
            new Alt("O idioma oficial falado em todo o país é a língua portuguesa.", true)
        }));

        l1.Add(new Q("Austrália", new Alt[] {
            new Alt("É famosa por sua fauna única no mundo, abrigando cangurus e coalas.", false),
            new Alt("É ao mesmo tempo um país e a maior massa de terra do continente da Oceania.", false),
            new Alt("Seu território é totalmente congelado e coberto por geleiras permanentes.", true)
        }));
        l1.Add(new Q("Egito", new Alt[] {
            new Alt("O Rio Nilo, um dos mais longos do mundo, atravessa o país de ponta a ponta.", false),
            new Alt("Abriga as históricas e monumentais Pirâmides de Gizé e a Grande Esfinge.", false),
            new Alt("Está localizado no continente da Europa, fazendo fronteira com a Alemanha.", true)
        }));
        l1.Add(new Q("China", new Alt[] {
            new Alt("Abriga a Grande Muralha, uma imensa fortificação de pedra construída há séculos.", false),
            new Alt("O urso-panda gigante é um animal nativo de suas florestas de bambu.", false),
            new Alt("Sua capital oficial é a cidade de Tóquio.", true)
        }));
        l1.Add(new Q("Reino Unido", new Alt[] {
            new Alt("A torre do relógio Big Ben e o Palácio de Buckingham ficam em Londres.", false),
            new Alt("É formado pela união de Inglaterra, Escócia, País de Gales e Irlanda do Norte.", false),
            new Alt("Está conectado à África por uma grande ponte terrestre de rodovias.", true)
        }));
        l1.Add(new Q("Rússia", new Alt[] {
            new Alt("É o maior país do planeta Terra em extensão de área territorial.", false),
            new Alt("Seu vasto território se estende por dois continentes: a Europa e a Ásia.", false),
            new Alt("Por ser muito quente, nunca cai neve em nenhuma parte do seu território.", true)
        }));
        l1.Add(new Q("Brasil", new Alt[] {
            new Alt("É o maior país da América do Sul e o quinto maior do mundo em área.", false),
            new Alt("Abriga a maior parte da Floresta Amazônica e da bacia do Rio Amazonas.", false),
            new Alt("A atual capital federal do país é a cidade litorânea do Rio de Janeiro.", true)
        }));
        l1.Add(new Q("Índia", new Alt[] {
            new Alt("O imponente Taj Mahal é um dos monumentos mais famosos do mundo construído lá.", false),
            new Alt("O tigre-de-bengala é um dos animais mais representativos de suas florestas.", false),
            new Alt("Fica localizada na América Central, entre o Oceano Atlântico e o Caribe.", true)
        }));
        l1.Add(new Q("Grécia", new Alt[] {
            new Alt("Foi o berço do surgimento dos Jogos Olímpicos na antiguidade clássica.", false),
            new Alt("Possui milhares de ilhas banhadas pelo azul do Mar Mediterrâneo.", false),
            new Alt("Faz fronteira terrestre com o Brasil e divide a Bacia Amazônica.", true)
        }));
        l1.Add(new Q("Chile", new Alt[] {
            new Alt("É um país longo e estreito espremido entre o Oceano Pacífico e as montanhas.", false),
            new Alt("A Cordilheira dos Andes se estende ao longo de toda a sua fronteira oriental.", false),
            new Alt("Possui fronteira terrestre direta e contínua com o território do Brasil.", true)
        }));
        l1.Add(new Q("Peru", new Alt[] {
            new Alt("Abriga a antiga e impressionante cidade histórica de pedra de Machu Picchu.", false),
            new Alt("A civilização Inca desenvolveu seu grande império nessa região montanhosa.", false),
            new Alt("É um país completamente plano que não possui nenhuma montanha ou floresta.", true)
        }));

        l1.Add(new Q("África do Sul", new Alt[] {
            new Alt("Possui três capitais oficiais que dividem as funções do governo.", false),
            new Alt("Seus parques nacionais preservam animais como leões, girafas e rinocerontes.", false),
            new Alt("Fica localizada no hemisfério norte, bem próxima ao Polo Norte.", true)
        }));
        l1.Add(new Q("Noruega", new Alt[] {
            new Alt("É famosa no mundo inteiro por seus fiordes, vales profundos esculpidos por geleiras.", false),
            new Alt("No verão do extremo norte do país, o Sol quase não se põe durante a noite.", false),
            new Alt("Fica localizada bem no centro do deserto de areia do Saara.", true)
        }));
        l1.Add(new Q("Suíça", new Alt[] {
            new Alt("É famosa mundialmente pela cadeia de montanhas dos Alpes e seus queijos e chocolates.", false),
            new Alt("Não possui nenhuma costa banhada pelo mar, sendo cercada por outros países.", false),
            new Alt("É o país com a maior população do planeta Terra, com mais de dois bilhões de pessoas.", true)
        }));
        l1.Add(new Q("Países Baixos (Holanda)", new Alt[] {
            new Alt("É muito conhecida pelos tradicionais moinhos de vento e vastos campos de tulipas.", false),
            new Alt("Sua capital, Amsterdã, possui dezenas de canais de água navegáveis.", false),
            new Alt("É o país que possui as montanhas e picos mais altos do planeta Terra.", true)
        }));
        l1.Add(new Q("Nova Zelândia", new Alt[] {
            new Alt("É formada principalmente por duas grandes ilhas, a Ilha Norte e a Ilha Sul.", false),
            new Alt("O kiwi é uma curiosa ave símbolo nacional que não voa e tem bico longo.", false),
            new Alt("Faz fronteira terrestre direta com os Estados Unidos e com o Canadá.", true)
        }));
        l1.Add(new Q("Coreia do Sul", new Alt[] {
            new Alt("Sua vibrante capital é a moderna cidade metropolitana de Seul.", false),
            new Alt("É uma potência mundial na criação de tecnologias, celulares e jogos eletrônicos.", false),
            new Alt("Fica situada no continente americano, logo abaixo da linha do Equador.", true)
        }));
        l1.Add(new Q("Colômbia", new Alt[] {
            new Alt("É um dos maiores e mais famosos produtores de café de qualidade do planeta.", false),
            new Alt("Tem litoral banhado tanto pelo Oceano Pacífico quanto pelo Mar do Caribe.", false),
            new Alt("A moeda oficial utilizada em todas as suas compras é o Euro.", true)
        }));
        l1.Add(new Q("Uruguai", new Alt[] {
            new Alt("Faz fronteira ao norte diretamente com o estado brasileiro do Rio Grande do Sul.", false),
            new Alt("Montevidéu é a capital e a cidade mais populosa do território uruguaio.", false),
            new Alt("Possui vulcões gigantescos que entram em erupção de lava todos os anos.", true)
        }));
        l1.Add(new Q("Arábia Saudita", new Alt[] {
            new Alt("Grande parte do seu território é ocupada por desertos quentes de areia e dunas.", false),
            new Alt("É um dos maiores países produtores e exportadores de petróleo do planeta.", false),
            new Alt("Possui centenas de rios naturais de água doce caudalosos que nunca secam.", true)
        }));
        l1.Add(new Q("Turquia", new Alt[] {
            new Alt("A histórica cidade de Istambul possui uma parte na Europa e outra na Ásia.", false),
            new Alt("É famosa por seus bazares cheios de especiarias coloridas e tapetes artesanais.", false),
            new Alt("Fica situada no continente gelado da Antártida, rodeada de blocos de gelo.", true)
        }));

        l1.Add(new Q("Madagascar", new Alt[] {
            new Alt("É uma enorme ilha localizada no Oceano Índico, próxima à costa sudeste da África.", false),
            new Alt("É o lar natural de dezenas de espécies de lêmures e árvores gigantes chamadas baobás.", false),
            new Alt("É uma ilha coberta por neve constante localizada no Círculo Polar Ártico.", true)
        }));
        l1.Add(new Q("Irlanda", new Alt[] {
            new Alt("É apelidada de Ilha Esmeralda devido à sua paisagem verdejante de campos e colinas.", false),
            new Alt("O trevo de três folhas é um dos símbolos tradicionais mais populares do país.", false),
            new Alt("Está localizada no meio da América Central, cercada por florestas tropicais secas.", true)
        }));
        l1.Add(new Q("Suécia", new Alt[] {
            new Alt("É um país nórdico na Europa conhecido por suas florestas e milhares de lagos limpos.", false),
            new Alt("Estocolmo é a sua capital, construída sobre várias ilhas conectadas por pontes.", false),
            new Alt("Possui clima de selva tropical com temperaturas que chegam a 50 graus no inverno.", true)
        }));
        l1.Add(new Q("Finlândia", new Alt[] {
            new Alt("A região da Lapônia, no norte do país, é famosa mundialmente como a terra do Papai Noel.", false),
            new Alt("Possui dezenas de milhares de lagos de água doce cristalina espalhados pelo território.", false),
            new Alt("Fica localizada bem no centro do deserto da Austrália.", true)
        }));
        l1.Add(new Q("Dinamarca", new Alt[] {
            new Alt("Copenhague é a sua bela capital conhecida por ciclovias e canais à beira-mar.", false),
            new Alt("É a terra onde nasceram os famosos brinquedos de montar de blocos de Lego.", false),
            new Alt("Faz divisa terrestre direta com a Argentina e o Uruguai na América do Sul.", true)
        }));
        l1.Add(new Q("Islândia", new Alt[] {
            new Alt("É uma ilha no Atlântico Norte famosa pela mistura de geleiras frias e vulcões ativos.", false),
            new Alt("Possui gêiseres impressionantes, que são fontes naturais de água quente que jorram do solo.", false),
            new Alt("É o país mais seco e arenoso do mundo, sem nenhuma gota de gelo em seu solo.", true)
        }));
        l1.Add(new Q("Marrocos", new Alt[] {
            new Alt("Fica localizado no norte da África, bem pertinho do continente europeu.", false),
            new Alt("Possui cidades históricas conhecidas por construções de barro e mercados de temperos.", false),
            new Alt("Sua capital nacional é a cidade sul-americana de Buenos Aires.", true)
        }));
        l1.Add(new Q("Tailândia", new Alt[] {
            new Alt("É um país do Sudeste Asiático famoso por templos budistas dourados e praias tropicais.", false),
            new Alt("O elefante-asiático é considerado um animal sagrado e histórico na cultura tailandesa.", false),
            new Alt("Faz fronteira terrestre com os Estados Unidos e o Canadá.", true)
        }));
        l1.Add(new Q("Quênia", new Alt[] {
            new Alt("Suas savanas abrigam grandes migrações de gnus, zebras e animais selvagens.", false),
            new Alt("Fica localizado na porção oriental do continente africano, banhado pelo Oceano Índico.", false),
            new Alt("O solo do país fica completamente congelado e coberto de gelo o ano todo.", true)
        }));
        l1.Add(new Q("Equador", new Alt[] {
            new Alt("Seu nome faz homenagem à Linha do Equador imaginária que passa pelo seu território.", false),
            new Alt("As famosas Ilhas Galápagos, ricas em tartarugas gigantes, pertencem ao seu país.", false),
            new Alt("É o maior país do mundo em área territorial, superando a Rússia e a China.", true)
        }));

        l1.Add(new Q("Bolívia", new Alt[] {
            new Alt("Abriga o impressionante Salar de Uyuni, o maior deserto de sal do planeta Terra.", false),
            new Alt("É um país da América do Sul que não possui saída costeira para nenhum oceano.", false),
            new Alt("Possui milhares de quilômetros de praias tropicais banhadas pelo Oceano Atlântico.", true)
        }));
        l1.Add(new Q("Paraguai", new Alt[] {
            new Alt("Divide com o Brasil a Usina Hidrelétrica de Itaipu, uma das maiores do planeta.", false),
            new Alt("Assim como a Bolívia, é um país sul-americano que não tem saída para o mar.", false),
            new Alt("O japonês é a única língua oficial falada por todos os seus habitantes.", true)
        }));
        l1.Add(new Q("Panamá", new Alt[] {
            new Alt("Abriga o Canal do Panamá, que liga diretamente os oceanos Atlântico e Pacífico.", false),
            new Alt("É uma faixa estreita de terra que une a América do Norte à América do Sul.", false),
            new Alt("Fica localizado no continente asiático, entre a China e o Japão.", true)
        }));
        l1.Add(new Q("Cuba", new Alt[] {
            new Alt("É a maior ilha localizada nas águas quentes do Mar do Caribe.", false),
            new Alt("Havana é a sua capital histórica, conhecida pela arquitetura colonial e carros clássicos.", false),
            new Alt("Fica localizada no meio do Oceano Índico, ao lado da ilha de Madagascar.", true)
        }));
        l1.Add(new Q("Jamaica", new Alt[] {
            new Alt("É uma ilha caribenha famosa no mundo por sua rica cultura musical e praias claras.", false),
            new Alt("O velocista Usain Bolt, o homem mais rápido do mundo, nasceu nesse país.", false),
            new Alt("É o país mais frio do continente americano, com tempestades de neve diárias.", true)
        }));
        l1.Add(new Q("Áustria", new Alt[] {
            new Alt("Fica no coração da Europa e é cercada pelas imponentes montanhas dos Alpes.", false),
            new Alt("Viena, sua capital, é mundialmente reconhecida pela história da música clássica e palácios.", false),
            new Alt("É uma ilha no Caribe cercada por recifes de corais e coqueiros tropicais.", true)
        }));
        l1.Add(new Q("Bélgica", new Alt[] {
            new Alt("É famosa mundialmente pela produção artesanal de chocolates finos e deliciosos waffles.", false),
            new Alt("Bruxelas é a capital do país e abriga a sede da União Europeia.", false),
            new Alt("A única língua falada em todo o país é o russo moderno.", true)
        }));
        l1.Add(new Q("Polônia", new Alt[] {
            new Alt("É um país da Europa Central com litoral banhado pelas águas do Mar Báltico.", false),
            new Alt("Sua capital é Varsóvia, uma cidade que reconstruiu seus belos monumentos históricos.", false),
            new Alt("Divide fronteira terrestre contínua com a Austrália e o Japão.", true)
        }));
        l1.Add(new Q("Filipinas", new Alt[] {
            new Alt("É um arquipélago tropical composto por mais de 7 mil ilhas no Oceano Pacífico.", false),
            new Alt("Manila é a sua movimentada capital com grande herança histórica espanhola e asiática.", false),
            new Alt("Fica localizada dentro do Círculo Polar Ártico, coberta por icebergs.", true)
        }));
        l1.Add(new Q("Costa Rica", new Alt[] {
            new Alt("É famosa por suas florestas tropicais preservadas e riquíssima biodiversidade de animais.", false),
            new Alt("Está localizada na América Central e possui praias no Pacífico e no Caribe.", false),
            new Alt("É um deserto de areia seco onde não cresce nenhuma árvore ou planta.", true)
        }));

        // NIVEL 2 (50 Questoes - Maravilhas Naturais, Vulcoes Extremos, Fossas, Cavernas e Biomas)
        // Substituindo chuva/evaporacao por maravilhas da Terra reais conforme feedback
        var l2 = levels[2];
        l2.Add(new Q("O Vulcão Vesúvio", new Alt[] {
            new Alt("É um famoso vulcão ativo na Itália que soterrou a antiga cidade romana de Pompeia.", false),
            new Alt("Fica situado perto da cidade moderna de Nápoles e é monitorado constantemente por cientistas.", false),
            new Alt("É um vulcão submarino que expele cubos de gelo azul congelado a cada cinco minutos.", true)
        }));
        l2.Add(new Q("O Vulcão Krakatoa", new Alt[] {
            new Alt("Fica na Indonésia e sua gigantesca explosão histórica em 1883 foi ouvida a milhares de quilômetros.", false),
            new Alt("A erupção causou ondas de tsunamis impressionantes no Oceano Índico e mudou o pôr do sol mundial.", false),
            new Alt("Fica no meio do deserto do Saara cercado por camelos e pirâmides egípcias antigas.", true)
        }));
        l2.Add(new Q("O Vulcão Etna", new Alt[] {
            new Alt("Localizado na ilha da Sicília, na Itália, é um dos vulcões mais ativos de todo o continente europeu.", false),
            new Alt("Costuma entrar em erupção expelindo rios incandescentes de lava e nuvens de cinzas no céu.", false),
            new Alt("Fica localizado no continente da América do Sul bem ao lado da cidade de São Paulo.", true)
        }));
        l2.Add(new Q("A Fossa das Marianas", new Alt[] {
            new Alt("É o local mais profundo de todos os oceanos da Terra, atingindo quase 11 mil metros abaixo do mar.", false),
            new Alt("Fica no Oceano Pacífico e abriga criaturas marinhas muito curiosas adaptadas à escuridão total.", false),
            new Alt("É um pico montanhoso nevado onde turistas sobem a pé para esquiar no verão.", true)
        }));
        l2.Add(new Q("Círculo de Fogo do Pacífico", new Alt[] {
            new Alt("É uma vasta região ao redor do Oceano Pacífico com grande concentração de vulcões ativos.", false),
            new Alt("Nessa área ocorrem a maioria dos terremotos mais intensos registrados no planeta Terra.", false),
            new Alt("É uma aliança gigante de metal dourado que flutua suspensa na atmosfera terrestre.", true)
        }));
        l2.Add(new Q("Os Terremotos", new Alt[] {
            new Alt("São tremores da crosta provocados pelo movimento brusco e atrito entre placas tectônicas.", false),
            new Alt("A intensidade e energia liberada pelos terremotos costumam ser medidas na escala Richter.", false),
            new Alt("Acontecem exclusivamente quando rebanhos de elefantes pulam ao mesmo tempo no chão.", true)
        }));
        l2.Add(new Q("Os Tsunamis", new Alt[] {
            new Alt("São ondas gigantescas formadas no oceano após terremotos submarinos ou erupções vulcânicas.", false),
            new Alt("Podem atravessar oceanos inteiros em alta velocidade e invadir cidades litorâneas.", false),
            new Alt("São pequenas bolhas de sabão coloridas que flutuam calmamente na beira da praia.", true)
        }));
        l2.Add(new Q("Placas Tectônicas", new Alt[] {
            new Alt("São grandes blocos rochosos semirrígidos que formam a camada sólida externa da Terra.", false),
            new Alt("Movem-se muito lentamente ao longo de milhões de anos sobre o manto pastoso do planeta.", false),
            new Alt("São folhas finas de aço parafusadas no fundo do mar por operários humanos.", true)
        }));
        l2.Add(new Q("O Rio Amazonas", new Alt[] {
            new Alt("É o rio mais caudaloso do planeta Terra, despejando o maior volume de água doce no oceano.", false),
            new Alt("Nasce na Cordilheira dos Andes e corre em direção ao leste até desaguar no Oceano Atlântico.", false),
            new Alt("É um pequeno riacho de água salgada localizado no centro do continente europeu.", true)
        }));
        l2.Add(new Q("O Rio Nilo", new Alt[] {
            new Alt("É um dos rios mais compridos e históricos do mundo, atravessando vários países da África.", false),
            new Alt("Suas águas deságuam no Mar Mediterrâneo, formando um grande e fértil delta de terra.", false),
            new Alt("É um rio que seca por completo todos os domingos e segundas-feiras do ano.", true)
        }));

        l2.Add(new Q("Cataratas do Iguaçu", new Alt[] {
            new Alt("São um conjunto impressionante de centenas de quedas d'água entre o Brasil e a Argentina.", false),
            new Alt("Ficam localizadas dentro do Parque Nacional do Iguaçu, cercadas por rica mata atlântica.", false),
            new Alt("Ficam localizadas no meio das dunas de areia seca do deserto do Saara.", true)
        }));
        l2.Add(new Q("Cataratas do Niágara", new Alt[] {
            new Alt("Ficam situadas na fronteira entre o estado de Nova York (EUA) e a província de Ontário (Canadá).", false),
            new Alt("Possuem grande volume d'água e são famosas no mundo inteiro por passeios de barco.", false),
            new Alt("Suas águas correm ao contrário, subindo pelas montanhas até atingir as nuvens do céu.", true)
        }));
        l2.Add(new Q("Catarata Salto Ángel", new Alt[] {
            new Alt("É a mais alta queda d'água ininterrupta do mundo, com quase mil metros de altura na Venezuela.", false),
            new Alt("Despenca do topo de uma imponente montanha de topo plano chamada Auyantepui na selva.", false),
            new Alt("Fica localizada dentro de um shopping center fechado no centro de Paris.", true)
        }));
        l2.Add(new Q("Cordilheira dos Andes", new Alt[] {
            new Alt("É a mais longa cadeia de montanhas contínua do planeta, estendendo-se por toda a América do Sul.", false),
            new Alt("Abriga picos nevados imponentes como o monte Aconcágua e lagos em grandes altitudes.", false),
            new Alt("Fica situada bem no centro plano do continente insular da Austrália.", true)
        }));
        l2.Add(new Q("Cordilheira do Himalaia", new Alt[] {
            new Alt("É a cadeia montanhosa mais alta do planeta Terra, situada no continente da Ásia.", false),
            new Alt("Surgiu do choque constante entre a placa tectônica da Índia e a placa da Eurásia.", false),
            new Alt("É uma vasta planície costeira ao nível do mar coberta por praias quentes.", true)
        }));
        l2.Add(new Q("O Monte Everest", new Alt[] {
            new Alt("É a montanha com a maior altitude da Terra, com seu pico a mais de 8.800 metros do mar.", false),
            new Alt("Fica localizado na fronteira entre o Nepal e a China, enfrentando nevascas rigorosas.", false),
            new Alt("Possui piscinas térmicas naturais de água morna onde banhistas nadam no seu topo.", true)
        }));
        l2.Add(new Q("O Grand Canyon", new Alt[] {
            new Alt("É um imenso desfiladeiro esculpido ao longo de milhões de anos pelas águas do Rio Colorado.", false),
            new Alt("Suas encostas exibem camadas coloridas de rochas antigas no estado do Arizona, nos EUA.", false),
            new Alt("Foi escavado por pás de plástico de brinquedo durante as férias de uma única semana.", true)
        }));
        l2.Add(new Q("Deserto do Saara", new Alt[] {
            new Alt("É o maior deserto quente do planeta Terra, cobrindo grande parte do norte da África.", false),
            new Alt("Apresenta dias extremamente quentes e noites com temperaturas consideravelmente baixas.", false),
            new Alt("É uma floresta densa e úmida onde cai chuva torrencial todas as manhãs do ano.", true)
        }));
        l2.Add(new Q("Deserto do Atacama", new Alt[] {
            new Alt("É considerado o deserto não polar mais árido e seco de todo o planeta Terra.", false),
            new Alt("Seu céu limpo e seco faz dele um dos melhores lugares do mundo para observar estrelas.", false),
            new Alt("Sofre com tempestades diárias de chuva que inundam todas as suas cidades.", true)
        }));
        l2.Add(new Q("O Salar de Uyuni", new Alt[] {
            new Alt("É a maior planície de sal do mundo, localizada na Bolívia a mais de 3.600 metros de altitude.", false),
            new Alt("Na época das chuvas, uma fina camada de água transforma o deserto em um espelho gigante do céu.", false),
            new Alt("É um deserto feito inteiramente de açúcar refinado doce para confeitar bolos.", true)
        }));

        l2.Add(new Q("Os Oásis", new Alt[] {
            new Alt("São áreas férteis com fontes naturais de água doce que brotam no meio de regiões desérticas.", false),
            new Alt("Permitem o cultivo de palmeiras como tamareiras e servem de abrigo para viajantes e animais.", false),
            new Alt("São ilusões mágicas que desaparecem no ar quando qualquer pessoa se aproxima deles.", true)
        }));
        l2.Add(new Q("Floresta Amazônica", new Alt[] {
            new Alt("É a maior floresta tropical do mundo, abrigando milhões de espécies de plantas e animais.", false),
            new Alt("Ajuda a regular as chuvas de grande parte da América do Sul com seus rios voadores de vapor.", false),
            new Alt("É formada exclusivamente por pinheiros finos cobertos por camadas de neve o ano inteiro.", true)
        }));
        l2.Add(new Q("A Caverna dos Cristais Gigantes", new Alt[] {
            new Alt("Fica localizada em Naica, no México, contendo alguns dos maiores cristais naturais do mundo.", false),
            new Alt("Seus cristais de gipsita chegam a mais de dez metros de comprimento em um ambiente quente.", false),
            new Alt("Foi construída artificialmente com lâmpadas fluorescentes e espelhos para um filme.", true)
        }));
        l2.Add(new Q("O Mar Morto", new Alt[] {
            new Alt("É um grande lago no Oriente Médio com concentração de sal quase dez vezes maior que o oceano.", false),
            new Alt("A alta densidade da água muito salgada faz as pessoas boiarem naturalmente sem afundar.", false),
            new Alt("É o oceano mais profundo da Terra onde vivem tubarões gigantes e baleias assassinas.", true)
        }));
        l2.Add(new Q("A Grande Barreira de Corais", new Alt[] {
            new Alt("É a maior estrutura construída por seres vivos do planeta, localizada no litoral da Austrália.", false),
            new Alt("É tão imensa e vistosa que pode ser vista por astronautas a partir do espaço sideral.", false),
            new Alt("É uma muralha de cimento e tijolos construída por humanos para impedir a maré.", true)
        }));
        l2.Add(new Q("O Lago Baikal", new Alt[] {
            new Alt("Localizado na Rússia, é o lago de água doce mais profundo e mais antigo de todo o planeta.", false),
            new Alt("Contém cerca de vinte por cento de toda a água doce líquida descongelada da superfície terrestre.", false),
            new Alt("É um lago de água com gás artificial engarrafada vendido em pequenos copos de plástico.", true)
        }));
        l2.Add(new Q("Monte Kilimanjaro", new Alt[] {
            new Alt("É a montanha mais alta de todo o continente africano, localizada na Tanzânia.", false),
            new Alt("É um vulcão isolado que possui o topo coberto por geleiras permanentes apesar de estar nos trópicos.", false),
            new Alt("Fica no meio do Oceano Atlântico e só pode ser escalado usando equipamentos de mergulho.", true)
        }));
        l2.Add(new Q("Gêiseres da Islândia", new Alt[] {
            new Alt("São fontes de água subterrânea fervente aquecidas por rochas vulcânicas que explodem para o ar.", false),
            new Alt("O termo mundial 'gêiser' se originou do nome da famosa fonte Geysir localizada na Islândia.", false),
            new Alt("São jatos de tinta azul que pintam as nuvens do céu de cinco em cinco minutos.", true)
        }));
        l2.Add(new Q("O Lago Titicaca", new Alt[] {
            new Alt("É o lago navegável mais alto do mundo, situado na fronteira montanhosa entre Peru e Bolívia.", false),
            new Alt("Povos tradicionais como os Uros vivem em ilhas artificiais flutuantes feitas de junco totora.", false),
            new Alt("É um lago subterrâneo sem oxigênio localizado no centro do núcleo da Terra.", true)
        }));
        l2.Add(new Q("A Ilha de Páscoa (Rapa Nui)", new Alt[] {
            new Alt("É uma das ilhas mais isoladas do mundo, localizada no meio do sul do Oceano Pacífico.", false),
            new Alt("É mundialmente famosa pelas centenas de estátuas gigantes de pedra vulcânica chamadas Moais.", false),
            new Alt("Está ligada ao continente americano por uma ponte rodoviária de apenas dois metros.", true)
        }));

        l2.Add(new Q("O Deserto de Gobi", new Alt[] {
            new Alt("É um imenso deserto frio localizado entre a China e a Mongólia no continente da Ásia.", false),
            new Alt("Famoso mundialmente por abrigar importantes sítios arqueológicos com ovos fósseis de dinossauros.", false),
            new Alt("É uma floresta de manguezal alagada onde vivem golfinhos cor-de-rosa nadadores.", true)
        }));
        l2.Add(new Q("O Arquipélago de Galápagos", new Alt[] {
            new Alt("É um conjunto de ilhas vulcânicas pertencentes ao Equador famosas por animais exclusivos.", false),
            new Alt("Abriga tartarugas gigantes terrestres e iguanas-marinhas que nadam no mar em busca de algas.", false),
            new Alt("Fica localizado no Oceano Glacial Ártico congelado sob placas permanentes de gelo.", true)
        }));
        l2.Add(new Q("A Floresta de Pedra de Shilin", new Alt[] {
            new Alt("Fica na China e é um conjunto impressionante de formações rochosas pontudas de calcário.", false),
            new Alt("As rochas altas e esguias parecem árvores de pedra que brotam diretamente do chão.", false),
            new Alt("As pedras foram esculpidas em madeira de carvalho por carpinteiros franceses medievais.", true)
        }));
        l2.Add(new Q("O Poço de Darvaza (Porta do Inferno)", new Alt[] {
            new Alt("É uma cratera de gás natural no Turcomenistão que queima chamas ininterruptamente há décadas.", false),
            new Alt("Geólogos atearam fogo ao gás vazado em 1971 esperando que apagasse, mas o fogo nunca cessou.", false),
            new Alt("É uma piscina de gelo líquido com água congelada onde pinguins tomam banho.", true)
        }));
        l2.Add(new Q("A Calçada dos Gigantes", new Alt[] {
            new Alt("Fica na Irlanda do Norte, formada por cerca de 40 mil colunas hexagonais perfeitas de basalto.", false),
            new Alt("Surgiu do resfriamento rápido de lava vulcânica há milhões de anos, gerando colunas geométricas.", false),
            new Alt("Foi construída com peças plásticas de brinquedo coladas com cola branca escolar.", true)
        }));
        l2.Add(new Q("O Cenote Sagrado", new Alt[] {
            new Alt("Cenotes são grandes poços e cavernas naturais com piscinas de água doce transparente no México.", false),
            new Alt("Eram considerados portais sagrados para o mundo espiritual pelos antigos povos maias da região.", false),
            new Alt("São crateras de meteoros cheias de gasolina pura que explodem a cada trovão.", true)
        }));
        l2.Add(new Q("As Colinas de Chocolate", new Alt[] {
            new Alt("São mais de mil colinas cônicas e arredondadas na ilha de Bohol, nas Filipinas.", false),
            new Alt("Na época seca, a vegetação das colinas fica marrom, dando a aparência de bombons de chocolate.", false),
            new Alt("São feitas inteiramente de chocolate ao leite comestível com recheio de brigadeiro.", true)
        }));
        l2.Add(new Q("Monte Fuji", new Alt[] {
            new Alt("É um vulcão ativo com cone quase simétrico perfeito e o ponto mais alto de todo o Japão.", false),
            new Alt("Seu cume coberto de neve é um dos símbolos culturais e paisagísticos mais famosos do mundo.", false),
            new Alt("Fica localizado bem no meio do deserto do Atacama no território chileno.", true)
        }));
        l2.Add(new Q("O Estreito de Gibraltar", new Alt[] {
            new Alt("É a passagem marítima estreita que separa o continente da Europa do continente da África.", false),
            new Alt("Liga as águas abertas do Oceano Atlântico às águas mornas do interior do Mar Mediterrâneo.", false),
            new Alt("É uma cachoeira vertical no meio da cidade de Nova York onde passam submarinos.", true)
        }));
        l2.Add(new Q("O Canal de Suez", new Alt[] {
            new Alt("É um canal artificial navegável no Egito que liga diretamente o Mar Mediterrâneo ao Mar Vermelho.", false),
            new Alt("Permite que navios cargueiros viagem entre a Europa e a Ásia sem ter que contornar a África.", false),
            new Alt("Foi construído por piratas vikings usando machados de pedra no ano de 1400.", true)
        }));

        l2.Add(new Q("O Vulcão Mauna Kea", new Alt[] {
            new Alt("Fica no Havaí e, se medido desde a sua base no fundo do oceano, é mais alto que o Everest.", false),
            new Alt("Seu topo abriga alguns dos maiores e mais modernos telescópios astronômicos do planeta Terra.", false),
            new Alt("Fica localizado no centro da Europa, na fronteira entre a Suíça e a Áustria.", true)
        }));
        l2.Add(new Q("A Groenlândia", new Alt[] {
            new Alt("É a maior ilha do planeta Terra, com mais de oitenta por cento do solo coberto por calota de gelo.", false),
            new Alt("Apesar de pertencer politicamente ao reino da Dinamarca, fica geograficamente na América do Norte.", false),
            new Alt("É um deserto de dunas de areia seca onde a temperatura média é de 45 graus positivos.", true)
        }));
        l2.Add(new Q("O Vulcão Tambora", new Alt[] {
            new Alt("Sua colossal erupção na Indonésia em 1815 foi a mais violenta registrada na história recente da Terra.", false),
            new Alt("Lançou tantas cinzas na estratosfera que o ano de 1816 ficou conhecido como 'o ano sem verão'.", false),
            new Alt("É um pequeno vulcão de brinquedo feito com vinagre e bicarbonato em feiras de ciências.", true)
        }));
        l2.Add(new Q("O Lago Maracaibo", new Alt[] {
            new Alt("Fica na Venezuela e é conhecido como o lugar do planeta com a maior frequência de raios e relâmpagos.", false),
            new Alt("O fenômeno do Relâmpago do Catatumbo produz tempestades elétricas brilhantes quase toda noite.", false),
            new Alt("É um lago totalmente seco onde nunca caiu um pingo de chuva ou raio na história.", true)
        }));
        l2.Add(new Q("A Floresta Negra", new Alt[] {
            new Alt("É uma cordilheira montanhosa densamente arborizada localizada no sudoeste da Alemanha.", false),
            new Alt("É famosa pelas lendas dos contos dos Irmãos Grimm e pelo nascimento do rio Danúbio.", false),
            new Alt("É uma floresta de árvores pretas feitas de carvão mineral queimado na França.", true)
        }));
        l2.Add(new Q("Os Fiordes da Noruega", new Alt[] {
            new Alt("São imensos vales rochosos esculpidos por antigas geleiras e inundados pelas águas do mar.", false),
            new Alt("Criam canais de água calma cercados por paredões de montanhas altas e cachoeiras verticais.", false),
            new Alt("São canais artificiais cavados por retroescavadeiras modernas para corridas de lancha.", true)
        }));
        l2.Add(new Q("A Garganta do Salto do Tigre", new Alt[] {
            new Alt("É um dos desfiladeiros de rio mais profundos e dramáticos do mundo, localizado na China.", false),
            new Alt("As águas turbulentas do rio Jinsha passam espremidas entre montanhas com milhares de metros de altura.", false),
            new Alt("É uma gaiola gigante onde vivem milhares de tigres-de-bengala adestrados em circos.", true)
        }));
        l2.Add(new Q("O Atol de Bikini", new Alt[] {
            new Alt("É um atol de corais em formato de anel localizado nas Ilhas Marshall no Oceano Pacífico.", false),
            new Alt("Serviu de inspiração para a criação da Fenda do Biquíni no desenho animado Bob Esponja.", false),
            new Alt("Fica situado no centro de uma geleira congelada no continente da Antártida.", true)
        }));
        l2.Add(new Q("O Rio Yangtzé", new Alt[] {
            new Alt("É o rio mais longo de todo o continente asiático e o terceiro mais longo do planeta Terra.", false),
            new Alt("Abriga a Usina de Três Gargantas, a maior usina hidrelétrica em capacidade instalada do mundo.", false),
            new Alt("É um pequeno riacho raso que corre dentro de um shopping center na capital da Austrália.", true)
        }));
        l2.Add(new Q("O Vulcão Popocatépetl", new Alt[] {
            new Alt("É um imponente vulcão ativo no México cujo nome na língua asteca significa 'montanha que fumega'.", false),
            new Alt("Fica próximo à Cidade do México e solta com frequência grandes colunas de fumaça e cinzas.", false),
            new Alt("Fica situado no centro do Pólo Sul e expele picolés de fruta congelados pelo topo.", true)
        }));

        Console.WriteLine(string.Format("Geo Lvl 0: {0}, Lvl 1: {1}, Lvl 2: {2}", levels[0].Count, levels[1].Count, levels[2].Count));

        // Let's output to temp_geo_part1.txt
        SaveGeoLevels(levels, "temp_geo_part1.lua");
    }

    static void SaveGeoLevels(Dictionary<int, List<Q>> levels, string path) {
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
        Console.WriteLine(string.Format("Wrote {0}", path));
    }

    static string Escape(string s) {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}
