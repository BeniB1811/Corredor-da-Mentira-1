using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class BuildQuestions {
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
        var geoQ = new List<Q>();
        var hisQ = new List<Q>();

        // GEOGRAFIA NIVEL 1 (50 Questoes - Paises, Continentes, Oceanos, Curiosidades do Planeta)
        geoQ.Add(new Q("Alemanha", new Alt[] {
            new Alt("É o país com a famosa rede de rodovias de alta velocidade chamada Autobahn.", false),
            new Alt("O primeiro livro impresso no Ocidente com tipos móveis (Bíblia de Gutenberg) foi feito lá.", false),
            new Alt("É o único país da Europa que não tem nenhuma saída para o mar.", true)
        }));
        geoQ.Add(new Q("França", new Alt[] {
            new Alt("A famosa Torre Eiffel fica localizada em Paris, sua capital.", false),
            new Alt("É um dos países mais visitados por turistas de todo o mundo.", false),
            new Alt("É o único país do continente europeu que possui duas capitais oficiais ao mesmo tempo.", true)
        }));
        geoQ.Add(new Q("Espanha", new Alt[] {
            new Alt("Está localizada na Península Ibérica, no sudoeste da Europa.", false),
            new Alt("É famosa pela animada festa tradicional de La Tomatina, com guerra de tomates.", false),
            new Alt("É o único país do planeta inteiro onde as pessoas falam a língua espanhola.", true)
        }));
        geoQ.Add(new Q("Itália", new Alt[] {
            new Alt("O antigo e histórico Coliseu fica localizado em sua capital, Roma.", false),
            new Alt("Seu mapa no globo terrestre tem o formato famoso de uma bota.", false),
            new Alt("Fica localizada no meio do Oceano Pacífico e não possui montanhas.", true)
        }));
        geoQ.Add(new Q("Portugal", new Alt[] {
            new Alt("Lisboa é a sua capital e foi o ponto de partida de grandes navegações históricas.", false),
            new Alt("O português é a língua oficial falada pelo seu povo.", false),
            new Alt("Faz fronteira terrestre direta com a França e com a Alemanha.", true)
        }));
        geoQ.Add(new Q("Japão", new Alt[] {
            new Alt("É um país insular formado por milhares de ilhas no Oceano Pacífico.", false),
            new Alt("O Monte Fuji é um vulcão sagrado e o ponto mais alto do país.", false),
            new Alt("Fica localizado no continente africano, bem perto do deserto do Saara.", true)
        }));
        geoQ.Add(new Q("Estados Unidos", new Alt[] {
            new Alt("Sua capital federal é a cidade de Washington, D.C.", false),
            new Alt("A famosa Estátua da Liberdade fica situada na cidade de Nova York.", false),
            new Alt("O país é composto por apenas dez estados em todo o seu território.", true)
        }));
        geoQ.Add(new Q("Canadá", new Alt[] {
            new Alt("É o segundo maior país do mundo em extensão territorial total.", false),
            new Alt("A folha de bordo vermelha é o símbolo nacional estampado em sua bandeira.", false),
            new Alt("Possui clima quente e desértico durante todos os meses do ano.", true)
        }));
        geoQ.Add(new Q("México", new Alt[] {
            new Alt("Abriga antigas e famosas pirâmides construídas pelos povos maia e asteca.", false),
            new Alt("Sua culinária tradicional inclui pratos típicos como tacos e guacamole.", false),
            new Alt("Está localizado no continente da América do Sul, ao lado do Brasil.", true)
        }));
        geoQ.Add(new Q("Argentina", new Alt[] {
            new Alt("É um país vizinho do Brasil situado na América do Sul.", false),
            new Alt("A região sul da Patagônia possui montanhas nevadas e geleiras grandiosas.", false),
            new Alt("O idioma oficial falado em todo o país é a língua portuguesa.", true)
        }));

        geoQ.Add(new Q("Austrália", new Alt[] {
            new Alt("É famosa por sua fauna única no mundo, abrigando cangurus e coalas.", false),
            new Alt("É ao mesmo tempo um país e a maior massa de terra do continente da Oceania.", false),
            new Alt("Seu território é totalmente congelado e coberto por geleiras permanentes.", true)
        }));
        geoQ.Add(new Q("Egito", new Alt[] {
            new Alt("O Rio Nilo, um dos mais longos do mundo, atravessa o país de ponta a ponta.", false),
            new Alt("Abriga as históricas e monumentais Pirâmides de Gizé e a Grande Esfinge.", false),
            new Alt("Está localizado no continente da Europa, fazendo fronteira com a Alemanha.", true)
        }));
        geoQ.Add(new Q("China", new Alt[] {
            new Alt("Abriga a Grande Muralha, uma imensa fortificação de pedra construída há séculos.", false),
            new Alt("O urso-panda gigante é um animal nativo de suas florestas de bambu.", false),
            new Alt("Sua capital oficial é a cidade de Tóquio.", true)
        }));
        geoQ.Add(new Q("Reino Unido", new Alt[] {
            new Alt("A torre do relógio Big Ben e o Palácio de Buckingham ficam em Londres.", false),
            new Alt("É formado pela união de Inglaterra, Escócia, País de Gales e Irlanda do Norte.", false),
            new Alt("Está conectado à África por uma grande ponte terrestre de rodovias.", true)
        }));
        geoQ.Add(new Q("Rússia", new Alt[] {
            new Alt("É o maior país do planeta Terra em extensão de área territorial.", false),
            new Alt("Seu vasto território se estende por dois continentes: a Europa e a Ásia.", false),
            new Alt("Por ser muito quente, nunca cai neve em nenhuma parte do seu território.", true)
        }));
        geoQ.Add(new Q("Brasil", new Alt[] {
            new Alt("É o maior país da América do Sul e o quinto maior do mundo em área.", false),
            new Alt("Abriga a maior parte da Floresta Amazônica e da bacia do Rio Amazonas.", false),
            new Alt("A atual capital federal do país é a cidade litorânea do Rio de Janeiro.", true)
        }));
        geoQ.Add(new Q("Índia", new Alt[] {
            new Alt("O imponente Taj Mahal é um dos monumentos mais famosos do mundo construído lá.", false),
            new Alt("O tigre-de-bengala é um dos animais mais representativos de suas florestas.", false),
            new Alt("Fica localizada na América Central, entre o Oceano Atlântico e o Caribe.", true)
        }));
        geoQ.Add(new Q("Grécia", new Alt[] {
            new Alt("Foi o berço do surgimento dos Jogos Olímpicos na antiguidade clássica.", false),
            new Alt("Possui milhares de ilhas banhadas pelo azul do Mar Mediterrâneo.", false),
            new Alt("Faz fronteira terrestre com o Brasil e divide a Bacia Amazônica.", true)
        }));
        geoQ.Add(new Q("Chile", new Alt[] {
            new Alt("É um país longo e estreito espremido entre o Oceano Pacífico e as montanhas.", false),
            new Alt("A Cordilheira dos Andes se estende ao longo de toda a sua fronteira oriental.", false),
            new Alt("Possui fronteira terrestre direta e contínua com o território do Brasil.", true)
        }));
        geoQ.Add(new Q("Peru", new Alt[] {
            new Alt("Abriga a antiga e impressionante cidade histórica de pedra de Machu Picchu.", false),
            new Alt("A civilização Inca desenvolveu seu grande império nessa região montanhosa.", false),
            new Alt("É um país completamente plano que não possui nenhuma montanha ou floresta.", true)
        }));

        geoQ.Add(new Q("África do Sul", new Alt[] {
            new Alt("Possui três capitais oficiais que dividem as funções do governo.", false),
            new Alt("Seus parques nacionais preservam animais como leões, girafas e rinocerontes.", false),
            new Alt("Fica localizada no hemisfério norte, bem próxima ao Polo Norte.", true)
        }));
        geoQ.Add(new Q("Noruega", new Alt[] {
            new Alt("É famosa no mundo inteiro por seus fiordes, vales profundos esculpidos por geleiras.", false),
            new Alt("No verão do extremo norte do país, o Sol quase não se põe durante a noite.", false),
            new Alt("Fica localizada bem no centro do deserto de areia do Saara.", true)
        }));
        geoQ.Add(new Q("Suíça", new Alt[] {
            new Alt("É famosa mundialmente pela cadeia de montanhas dos Alpes e seus queijos e chocolates.", false),
            new Alt("Não possui nenhuma costa banhada pelo mar, sendo cercada por outros países.", false),
            new Alt("É o país com a maior população do planeta Terra, com mais de dois bilhões de pessoas.", true)
        }));
        geoQ.Add(new Q("Países Baixos (Holanda)", new Alt[] {
            new Alt("É muito conhecida pelos tradicionais moinhos de vento e vastos campos de tulipas.", false),
            new Alt("Sua capital, Amsterdã, possui dezenas de canais de água navegáveis.", false),
            new Alt("É o país que possui as montanhas e picos mais altos do planeta Terra.", true)
        }));
        geoQ.Add(new Q("Nova Zelândia", new Alt[] {
            new Alt("É formada principalmente por duas grandes ilhas, a Ilha Norte e a Ilha Sul.", false),
            new Alt("O kiwi é uma curiosa ave símbolo nacional que não voa e tem bico longo.", false),
            new Alt("Faz fronteira terrestre direta com os Estados Unidos e com o Canadá.", true)
        }));
        geoQ.Add(new Q("Coreia do Sul", new Alt[] {
            new Alt("Sua vibrante capital é a moderna cidade metropolitana de Seul.", false),
            new Alt("É uma potência mundial na criação de tecnologias, celulares e jogos eletrônicos.", false),
            new Alt("Fica situada no continente americano, logo abaixo da linha do Equador.", true)
        }));
        geoQ.Add(new Q("Colômbia", new Alt[] {
            new Alt("É um dos maiores e mais famosos produtores de café de qualidade do planeta.", false),
            new Alt("Tem litoral banhado tanto pelo Oceano Pacífico quanto pelo Mar do Caribe.", false),
            new Alt("A moeda oficial utilizada em todas as suas compras é o Euro.", true)
        }));
        geoQ.Add(new Q("Uruguai", new Alt[] {
            new Alt("Faz fronteira ao norte diretamente com o estado brasileiro do Rio Grande do Sul.", false),
            new Alt("Montevidéu é a capital e a cidade mais populosa do território uruguaio.", false),
            new Alt("Possui vulcões gigantescos que entram em erupção de lava todos os anos.", true)
        }));
        geoQ.Add(new Q("Arábia Saudita", new Alt[] {
            new Alt("Grande parte do seu território é ocupada por desertos quentes de areia e dunas.", false),
            new Alt("É um dos maiores países produtores e exportadores de petróleo do planeta.", false),
            new Alt("Possui centenas de rios naturais de água doce caudalosos que nunca secam.", true)
        }));
        geoQ.Add(new Q("Turquia", new Alt[] {
            new Alt("A histórica cidade de Istambul possui uma parte na Europa e outra na Ásia.", false),
            new Alt("É famosa por seus bazares cheios de especiarias coloridas e tapetes artesanais.", false),
            new Alt("Fica situada no continente gelado da Antártida, rodeada de blocos de gelo.", true)
        }));

        geoQ.Add(new Q("Madagascar", new Alt[] {
            new Alt("É uma enorme ilha localizada no Oceano Índico, próxima à costa sudeste da África.", false),
            new Alt("É o lar natural de dezenas de espécies de lêmures e árvores gigantes chamadas baobás.", false),
            new Alt("É uma ilha coberta por neve constante localizada no Círculo Polar Ártico.", true)
        }));
        geoQ.Add(new Q("Irlanda", new Alt[] {
            new Alt("É apelidada de Ilha Esmeralda devido à sua paisagem verdejante de campos e colinas.", false),
            new Alt("O trevo de três folhas é um dos símbolos tradicionais mais populares do país.", false),
            new Alt("Está localizada no meio da América Central, cercada por florestas tropicais secas.", true)
        }));
        geoQ.Add(new Q("Suécia", new Alt[] {
            new Alt("É um país nórdico na Europa conhecido por suas florestas e milhares de lagos limpos.", false),
            new Alt("Estocolmo é a sua capital, construída sobre várias ilhas conectadas por pontes.", false),
            new Alt("Possui clima de selva tropical com temperaturas que chegam a 50 graus no inverno.", true)
        }));
        geoQ.Add(new Q("Finlândia", new Alt[] {
            new Alt("A região da Lapônia, no norte do país, é famosa mundialmente como a terra do Papai Noel.", false),
            new Alt("Possui dezenas de milhares de lagos de água doce cristalina espalhados pelo território.", false),
            new Alt("Fica localizada bem no centro do deserto da Austrália.", true)
        }));
        geoQ.Add(new Q("Dinamarca", new Alt[] {
            new Alt("Copenhague é a sua bela capital conhecida por ciclovias e canais à beira-mar.", false),
            new Alt("É a terra onde nasceram os famosos brinquedos de montar de blocos de Lego.", false),
            new Alt("Faz divisa terrestre direta com a Argentina e o Uruguai na América do Sul.", true)
        }));
        geoQ.Add(new Q("Islândia", new Alt[] {
            new Alt("É uma ilha no Atlântico Norte famosa pela mistura de geleiras frias e vulcões ativos.", false),
            new Alt("Possui gêiseres impressionantes, que são fontes naturais de água quente que jorram do solo.", false),
            new Alt("É o país mais seco e arenoso do mundo, sem nenhuma gota de gelo em seu solo.", true)
        }));
        geoQ.Add(new Q("Marrocos", new Alt[] {
            new Alt("Fica localizado no norte da África, bem pertinho do continente europeu.", false),
            new Alt("Possui cidades históricas conhecidas por construções de barro e mercados de temperos.", false),
            new Alt("Sua capital nacional é a cidade sul-americana de Buenos Aires.", true)
        }));
        geoQ.Add(new Q("Tailândia", new Alt[] {
            new Alt("É um país do Sudeste Asiático famoso por templos budistas dourados e praias tropicais.", false),
            new Alt("O elefante-asiático é considerado um animal sagrado e histórico na cultura tailandesa.", false),
            new Alt("Faz fronteira terrestre com os Estados Unidos e o Canadá.", true)
        }));
        geoQ.Add(new Q("Quênia", new Alt[] {
            new Alt("Suas savanas abrigam grandes migrações de gnus, zebras e animais selvagens.", false),
            new Alt("Fica localizado na porção oriental do continente africano, banhado pelo Oceano Índico.", false),
            new Alt("O solo do país fica completamente congelado e coberto de gelo o ano todo.", true)
        }));
        geoQ.Add(new Q("Equador", new Alt[] {
            new Alt("Seu nome faz homenagem à Linha do Equador imaginária que passa pelo seu território.", false),
            new Alt("As famosas Ilhas Galápagos, ricas em tartarugas gigantes, pertencem ao seu país.", false),
            new Alt("É o maior país do mundo em área territorial, superando a Rússia e a China.", true)
        }));

        geoQ.Add(new Q("Bolívia", new Alt[] {
            new Alt("Abriga o impressionante Salar de Uyuni, o maior deserto de sal do planeta Terra.", false),
            new Alt("É um país da América do Sul que não possui saída costeira para nenhum oceano.", false),
            new Alt("Possui milhares de quilômetros de praias tropicais banhadas pelo Oceano Atlântico.", true)
        }));
        geoQ.Add(new Q("Paraguai", new Alt[] {
            new Alt("Divide com o Brasil a Usina Hidrelétrica de Itaipu, uma das maiores do planeta.", false),
            new Alt("Assim como a Bolívia, é um país sul-americano que não tem saída para o mar.", false),
            new Alt("O japonês é a única língua oficial falada por todos os seus habitantes.", true)
        }));
        geoQ.Add(new Q("Panamá", new Alt[] {
            new Alt("Abriga o Canal do Panamá, que liga diretamente os oceanos Atlântico e Pacífico.", false),
            new Alt("É uma faixa estreita de terra que une a América do Norte à América do Sul.", false),
            new Alt("Fica localizado no continente asiático, entre a China e o Japão.", true)
        }));
        geoQ.Add(new Q("Cuba", new Alt[] {
            new Alt("É a maior ilha localizada nas águas quentes do Mar do Caribe.", false),
            new Alt("Havana é a sua capital histórica, conhecida pela arquitetura colonial e carros clássicos.", false),
            new Alt("Fica localizada no meio do Oceano Índico, ao lado da ilha de Madagascar.", true)
        }));
        geoQ.Add(new Q("Jamaica", new Alt[] {
            new Alt("É uma ilha caribenha famosa no mundo por sua rica cultura musical e praias claras.", false),
            new Alt("O velocista Usain Bolt, o homem mais rápido do mundo, nasceu nesse país.", false),
            new Alt("É o país mais frio do continente americano, com tempestades de neve diárias.", true)
        }));
        geoQ.Add(new Q("Áustria", new Alt[] {
            new Alt("Fica no coração da Europa e é cercada pelas imponentes montanhas dos Alpes.", false),
            new Alt("Viena, sua capital, é mundialmente reconhecida pela história da música clássica e palácios.", false),
            new Alt("É uma ilha no Caribe cercada por recifes de corais e coqueiros tropicais.", true)
        }));
        geoQ.Add(new Q("Bélgica", new Alt[] {
            new Alt("É famosa mundialmente pela produção artesanal de chocolates finos e deliciosos waffles.", false),
            new Alt("Bruxelas é a capital do país e abriga a sede da União Europeia.", false),
            new Alt("A única língua falada em todo o país é o russo moderno.", true)
        }));
        geoQ.Add(new Q("Polônia", new Alt[] {
            new Alt("É um país da Europa Central com litoral banhado pelas águas do Mar Báltico.", false),
            new Alt("Sua capital é Varsóvia, uma cidade que reconstruiu seus belos monumentos históricos.", false),
            new Alt("Divide fronteira terrestre contínua com a Austrália e o Japão.", true)
        }));
        geoQ.Add(new Q("Filipinas", new Alt[] {
            new Alt("É um arquipélago tropical composto por mais de 7 mil ilhas no Oceano Pacífico.", false),
            new Alt("Manila é a sua movimentada capital com grande herança histórica espanhola e asiática.", false),
            new Alt("Fica localizada dentro do Círculo Polar Ártico, coberta por icebergs.", true)
        }));
        geoQ.Add(new Q("Costa Rica", new Alt[] {
            new Alt("É famosa por suas florestas tropicais preservadas e riquíssima biodiversidade de animais.", false),
            new Alt("Está localizada na América Central e possui praias no Pacífico e no Caribe.", false),
            new Alt("É um deserto de areia seco onde não cresce nenhuma árvore ou planta.", true)
        }));

        // HISTORIA NIVEL 1 (50 Questoes - Dinossauros, Fosseis, Pre-Historia e Primeiras Conquistas)
        hisQ.Add(new Q("Os Dinossauros", new Alt[] {
            new Alt("Viveram na Terra durante a Era Mesozoica, milhões de anos antes dos primeiros humanos.", false),
            new Alt("A maioria das espécies de dinossauros se reproduzia botando ovos com casca dura.", false),
            new Alt("Conviviam diariamente com os seres humanos nas cidades e andavam pelas ruas.", true)
        }));
        hisQ.Add(new Q("Período Paleolítico", new Alt[] {
            new Alt("Foi o período mais longo da história humana, também chamado de Idade da Pedra Lascada.", false),
            new Alt("Nessa época, os seres humanos aprenderam a produzir e controlar o fogo.", false),
            new Alt("As pessoas construíam arranha-céus e usavam eletricidade em suas casas de pedra.", true)
        }));
        hisQ.Add(new Q("Período Neolítico", new Alt[] {
            new Alt("Ficou conhecido pelo surgimento da agricultura e pelo cultivo dos primeiros alimentos.", false),
            new Alt("Os humanos desenvolveram a cerâmica para cozinhar e guardar grãos e líquidos.", false),
            new Alt("Foi a época histórica em que os seres humanos inventaram os primeiros computadores.", true)
        }));
        hisQ.Add(new Q("Idade dos Metais", new Alt[] {
            new Alt("Os seres humanos aprenderam a derreter e moldar metais como cobre, bronze e ferro.", false),
            new Alt("As ferramentas de metal tornaram as tarefas de plantar e construir muito mais fáceis.", false),
            new Alt("As ferramentas eram feitas exclusivamente de plástico moldado no calor.", true)
        }));
        hisQ.Add(new Q("Tiranossauro Rex", new Alt[] {
            new Alt("Era um predador carnívoro de grande porte que andava sobre duas fortes pernas traseiras.", false),
            new Alt("Suas mandíbulas possuíam dentes serrilhados que podiam esmagar ossos com facilidade.", false),
            new Alt("Possuía grandes asas cobertas de penas e voava sobre florestas em busca de comida.", true)
        }));
        hisQ.Add(new Q("Braquiossauro", new Alt[] {
            new Alt("Era um dinossauro herbívoro gigante com um pescoço muito comprido.", false),
            new Alt("Seu longo pescoço permitia alcançar as folhas mais frescas no topo das árvores altas.", false),
            new Alt("Era um predador ágil que caçava outros dinossauros no fundo de oceanos profundos.", true)
        }));
        hisQ.Add(new Q("Tricerátops", new Alt[] {
            new Alt("Tinha três chifres pontudos no rosto e uma grande gola óssea protetora no pescoço.", false),
            new Alt("Era um dinossauro herbívoro que se alimentava de plantas rasteiras e arbustos.", false),
            new Alt("Disparava raios de eletricidade pelos seus chifres para espantar inimigos.", true)
        }));
        hisQ.Add(new Q("Velociraptor", new Alt[] {
            new Alt("Era um dinossauro carnívoro veloz que possuía uma garra curva e afiada em cada pata.", false),
            new Alt("Estudos científicos modernos mostram que ele possuía penas cobrindo seu corpo.", false),
            new Alt("Era um gigante mais pesado que uma baleia-azul que se movia lentamente.", true)
        }));
        hisQ.Add(new Q("Estegossauro", new Alt[] {
            new Alt("Possuía duas fileiras de placas ósseas triangulares enfileiradas ao longo das costas.", false),
            new Alt("A ponta da sua cauda tinha quatro espinhos afiados usados para se defender de predadores.", false),
            new Alt("Possuía um cérebro gigante do tamanho de uma melancia com inteligência humana.", true)
        }));
        hisQ.Add(new Q("Pterossauros", new Alt[] {
            new Alt("Eram répteis voadores que dominaram os céus durante a mesma época dos dinossauros.", false),
            new Alt("Suas asas eram formadas por uma membrana de pele resistente presa a um dedo alongado.", false),
            new Alt("Eram pássaros modernos idênticos aos canários que viviam em gaiolas pré-históricas.", true)
        }));

        hisQ.Add(new Q("Espinossauro", new Alt[] {
            new Alt("Possuía uma enorme vela nas costas sustentada por espinhas ósseas alongadas.", false),
            new Alt("Seu focinho longo e dentes cônicos eram ideais para capturar grandes peixes na água.", false),
            new Alt("Vivia dentro de blocos de gelo no Polo Sul se alimentando de pinguins pré-históricos.", true)
        }));
        hisQ.Add(new Q("Fósseis", new Alt[] {
            new Alt("São restos ou vestígios de animais e plantas antigas preservados em camadas de rocha.", false),
            new Alt("Pegadas deixadas na lama que endureceu ao longo de milhões de anos também são fósseis.", false),
            new Alt("Qualquer osso se transforma em um fóssil de pedra após ficar dez minutos no quintal.", true)
        }));
        hisQ.Add(new Q("Paleontólogos", new Alt[] {
            new Alt("São os cientistas responsáveis por encontrar, escavar e estudar fósseis de seres do passado.", false),
            new Alt("Usam pincéis delicados e ferramentas finas para retirar fósseis da rocha sem quebrar.", false),
            new Alt("São profissionais treinados para consertar motores a jato de naves espaciais modernas.", true)
        }));
        hisQ.Add(new Q("Extinção dos Dinossauros", new Alt[] {
            new Alt("Aconteceu há cerca de 66 milhões de anos após o impacto de um grande asteroide na Terra.", false),
            new Alt("A poeira levantada pelo choque cobriu o Sol por meses, mudando o clima do planeta.", false),
            new Alt("Os dinossauros construíram foguetes e se mudaram em massa para o planeta Marte.", true)
        }));
        hisQ.Add(new Q("Era do Gelo", new Alt[] {
            new Alt("Foi um período da Terra em que temperaturas baixas cobriram vastas áreas com geleiras.", false),
            new Alt("Vários animais desenvolveram pelos grossos e camadas de gordura para sobreviver ao frio.", false),
            new Alt("Foi uma época em que o planeta Terra se transformou em uma panela de água fervente.", true)
        }));
        hisQ.Add(new Q("O Mamute", new Alt[] {
            new Alt("Era um parente pré-histórico dos elefantes coberto por uma espessa camada de pelos longos.", false),
            new Alt("Possuía presas de marfim curvadas que podiam ultrapassar três metros de comprimento.", false),
            new Alt("Passava o dia nas praias tropicais do Caribe nadando entre corais aquecidos.", true)
        }));
        hisQ.Add(new Q("Tigre-dentes-de-sabre", new Alt[] {
            new Alt("Era um poderoso felino pré-histórico famoso por seus dois dentes caninos compridos.", false),
            new Alt("Usava seus dentes longos e afiados para caçar presas grandes e pesadas na Era do Gelo.", false),
            new Alt("Era uma espécie de peixe de escamas verdes que nadava em rios amazônicos.", true)
        }));
        hisQ.Add(new Q("Preguiça-Gigante", new Alt[] {
            new Alt("Era um animal herbívoro pré-histórico enorme que viveu na América do Sul e no Brasil.", false),
            new Alt("Podia alcançar vários metros de altura quando se apoiava sobre as patas traseiras.", false),
            new Alt("Era menor que uma formiga e costumava viver dentro de troncos ocos de maçã.", true)
        }));
        hisQ.Add(new Q("Homens das Cavernas", new Alt[] {
            new Alt("Eram nossos ancestrais pré-históricos que usavam abrigos naturais contra o vento e frio.", false),
            new Alt("Viviam em pequenos grupos que cooperavam entre si para caçar e colher alimentos.", false),
            new Alt("Compravam suas cavernas em agências imobiliárias usando moedas de ouro de piratas.", true)
        }));
        hisQ.Add(new Q("Pinturas Rupestres", new Alt[] {
            new Alt("São desenhos gravados em paredes e tetos de cavernas por seres humanos pré-históricos.", false),
            new Alt("Costumavam representar animais como bisões, cavalos selvagens e cenas de caçadas.", false),
            new Alt("Eram feitas usando canetinhas hidrográficas coloridas e tintas acrílicas sintéticas.", true)
        }));

        hisQ.Add(new Q("Tinta Pré-Histórica", new Alt[] {
            new Alt("Era preparada misturando pós de minerais, argila colorida, carvão e gordura animal.", false),
            new Alt("Alguns desenhos foram feitos soprando tinta em pó ao redor da mão apoiada na rocha.", false),
            new Alt("Era comprada pronta em latas de tinta spray vendidas em armazéns antigos.", true)
        }));
        hisQ.Add(new Q("Descoberta do Fogo", new Alt[] {
            new Alt("Permitiu aos primeiros humanos cozinhar a carne dos alimentos e deixá-la mais macia.", false),
            new Alt("O calor das chamas ajudou a espantar predadores noturnos e a aquecer as noites frias.", false),
            new Alt("O fogo foi aceso pelos primeiros homens com caixas de fósforos de madeira modernas.", true)
        }));
        hisQ.Add(new Q("Pedra Lascada", new Alt[] {
            new Alt("Técnica em que uma pedra dura batia em outra para soltar lascas com bordas muito afiadas.", false),
            new Alt("As lascas de pedra eram usadas como raspadores para limpar couro e facas de corte.", false),
            new Alt("As pedras eram cortadas com aparelhos de laser elétricos de alta tecnologia.", true)
        }));
        hisQ.Add(new Q("Povos Nômades", new Alt[] {
            new Alt("Grupos que não tinham moradia fixa e mudavam de região quando os recursos acabavam.", false),
            new Alt("Seguiam as rotas dos animais para caçar e buscavam novos frutos e plantas da estação.", false),
            new Alt("Moravam no mesmo apartamento durante cinquenta anos sem sair para nenhum lugar.", true)
        }));
        hisQ.Add(new Q("Armas de Caça Primitivas", new Alt[] {
            new Alt("Lanças de madeira com pontas afiadas de pedra eram arremessadas contra animais de caça.", false),
            new Alt("O propulsor de lanças foi inventado para lançar os dardos com muito mais força e alcance.", false),
            new Alt("Eram espingardas automáticas equipadas com miras telescópicas de visão noturna.", true)
        }));
        hisQ.Add(new Q("Roupas na Pré-História", new Alt[] {
            new Alt("Eram feitas com peles e pelos de animais caçados, limpas e costuradas para dar abrigo.", false),
            new Alt("Eram essenciais para proteger os corpos do frio congelante e dos ventos nas caçadas.", false),
            new Alt("Eram confeccionadas com tecidos de náilon e fechadas por zíperes de metal inox.", true)
        }));
        hisQ.Add(new Q("Agulhas de Osso", new Alt[] {
            new Alt("Eram feitas polindo lascas finas de ossos de animais com um pequeno furo na extremidade.", false),
            new Alt("Permitiram passar tendões e tiras de couro para costurar roupas muito bem ajustadas.", false),
            new Alt("Eram fabricadas em aço inoxidável cirúrgico com baterias eletrônicas embutidas.", true)
        }));
        hisQ.Add(new Q("Arco e Flecha", new Alt[] {
            new Alt("Foi uma invenção revolucionária que permitiu aos caçadores atingir alvos rápidos de longe.", false),
            new Alt("Utilizava a força da madeira recurvada e a tensão de cordas feitas de fibras vegetais.", false),
            new Alt("Precisava de uma tomada elétrica conectada à parede para disparar suas flechas.", true)
        }));
        hisQ.Add(new Q("Origem da Agricultura", new Alt[] {
            new Alt("Os humanos perceberam que sementes caídas na terra brotavam e davam novas plantas.", false),
            new Alt("O plantio de grãos como trigo e cevada garantiu comida sem depender apenas da caça.", false),
            new Alt("Plantavam pedaços de plástico no solo esperando colher brinquedos prontos nas árvores.", true)
        }));
        hisQ.Add(new Q("Povos Sedentários", new Alt[] {
            new Alt("Ao aprender a plantar alimentos, as pessoas passaram a se fixar em um local permanente.", false),
            new Alt("Construíram as primeiras aldeias com moradias duradouras perto de rios e terras férteis.", false),
            new Alt("Viajavam toda semana em viagens de trem de alta velocidade para mudar de cidade.", true)
        }));

        hisQ.Add(new Q("Domesticação de Animais", new Alt[] {
            new Alt("Humanos começaram a cuidar de animais como cabras, ovelhas e vacas para obter leite e lã.", false),
            new Alt("A criação de rebanhos fornecia alimento regular sem o perigo das caçadas na floresta.", false),
            new Alt("Os primeiros povos domesticavam tiranossauros rex para carregar compras nas aldeias.", true)
        }));
        hisQ.Add(new Q("O Cão na Pré-História", new Alt[] {
            new Alt("O lobo foi o primeiro animal a ser domesticado, tornando-se o fiel amigo dos humanos.", false),
            new Alt("Cães primitivos ajudavam os caçadores a farejar presas e protegiam a aldeia durante a noite.", false),
            new Alt("O primeiro animal domesticado pela humanidade foi o tubarão-baleia dos oceanos.", true)
        }));
        hisQ.Add(new Q("A Cerâmica", new Alt[] {
            new Alt("Vasos e potes eram moldados em barro úmido e depois assados no fogo para endurecer.", false),
            new Alt("Permitiu cozinhar alimentos líquidos em sopas e estocar água e grãos por meses.", false),
            new Alt("Os primeiros potes de cerâmica eram moldados usando garrafas plásticas recicladas.", true)
        }));
        hisQ.Add(new Q("A Tecelagem", new Alt[] {
            new Alt("Aprenderam a trançar fios de lã animal e de fibras de plantas para criar os primeiros panos.", false),
            new Alt("Os tecidos leves tornaram as vestimentas muito mais confortáveis nos períodos mais quentes.", false),
            new Alt("Os tecidos eram produzidos em fábricas computadorizadas com robôs de alta precisão.", true)
        }));
        hisQ.Add(new Q("Primeiras Canoas", new Alt[] {
            new Alt("Eram feitas cavando o interior de troncos grossos de árvores com auxílio do fogo e raspadeiras.", false),
            new Alt("Facilitaram a travessia de rios largos e permitiram a pesca em águas mais fundas.", false),
            new Alt("Eram movidas por motores de popa a gasolina com turbinas submarinas de corrida.", true)
        }));
        hisQ.Add(new Q("A Invenção da Roda", new Alt[] {
            new Alt("Foi uma das invenções mais importantes, facilitando o transporte de cargas muito pesadas.", false),
            new Alt("As primeiras rodas eram discos maciços feitos de pedras esculpidas ou troncos de madeira.", false),
            new Alt("Possuíam pneus modernos de borracha sintética cheios de ar e calotas de liga leve.", true)
        }));
        hisQ.Add(new Q("Pedra Polida", new Alt[] {
            new Alt("Técnica em que as pedras eram friccionadas com areia e água até ficarem lisinhas e afiadas.", false),
            new Alt("Machados de pedra polida eram muito mais eficientes para cortar troncos de árvores.", false),
            new Alt("As pedras eram amaciadas usando amaciante de roupas e sabão em pó moderno.", true)
        }));
        hisQ.Add(new Q("O Metal Cobre", new Alt[] {
            new Alt("Foi um dos primeiros metais trabalhados pelos humanos por ser maleável e fácil de moldar.", false),
            new Alt("Podia ser martelado a frio ou derretido em fornos rústicos para criar ferramentas e pontas.", false),
            new Alt("O cobre brotava em árvores frutíferas e era colhido nos galhos como se fosse maçã.", true)
        }));
        hisQ.Add(new Q("A Descoberta do Bronze", new Alt[] {
            new Alt("Surgiu da mistura inteligente do cobre derretido com estanho, criando uma liga resistente.", false),
            new Alt("Ferramentas e armas de bronze eram bem mais duráveis e mantinham o corte por mais tempo.", false),
            new Alt("O bronze era recolhido no fundo das nuvens durante tempestades de chuva forte.", true)
        }));
        hisQ.Add(new Q("A Idade do Ferro", new Alt[] {
            new Alt("O ferro exigia fornos de alta temperatura para derreter, sendo o metal mais resistente da época.", false),
            new Alt("Permitiu criar arados mais fortes para cavar a terra e foices para a colheita dos campos.", false),
            new Alt("O ferro derretia espontaneamente quando era exposto a uma simples brisa de vento frio.", true)
        }));

        hisQ.Add(new Q("Casas Primitivas", new Alt[] {
            new Alt("Eram erguidas com armações de galhos de madeira, paredes de barro e teto de palha seca.", false),
            new Alt("Protegiam as famílias do sol forte, da chuva e das feras da natureza ao redor.", false),
            new Alt("Eram construídas com grandes placas de vidro blindado e ar-condicionado central.", true)
        }));
        hisQ.Add(new Q("O Escambo Primitivo", new Alt[] {
            new Alt("Era um sistema de comércio baseado na troca direta de mercadorias sem o uso de dinheiro.", false),
            new Alt("Quem tinha excesso de grãos de trigo podia trocar por potes de cerâmica ou carne de peixe.", false),
            new Alt("As compras das aldeias antigas eram pagas com cartões de crédito e Pix no celular.", true)
        }));
        hisQ.Add(new Q("Monumentos de Megálitos", new Alt[] {
            new Alt("Eram construções formadas por blocos gigantes de pedra colocados em pé pelos povos pré-históricos.", false),
            new Alt("Exigiam o esforço coordenado de dezenas ou centenas de pessoas puxando pedras sobre troncos.", false),
            new Alt("Os blocos eram erguidos por guindastes movidos a diesel de construção moderna.", true)
        }));
        hisQ.Add(new Q("Stonehenge", new Alt[] {
            new Alt("É um famoso monumento pré-histórico de pedras gigantes dispostas em círculos na Inglaterra.", false),
            new Alt("Pesquisadores acreditam que o monumento servia para observar os movimentos do Sol e da Lua.", false),
            new Alt("Foi construído no ano de 2015 para funcionar como um shopping center de jogos.", true)
        }));
        hisQ.Add(new Q("O Fóssil de Luzia", new Alt[] {
            new Alt("É o fóssil de esqueleto humano mais antigo já encontrado no território da América do Sul.", false),
            new Alt("Foi descoberto em uma caverna na região de Lagoa Santa, no estado de Minas Gerais no Brasil.", false),
            new Alt("Foi encontrado congelado dentro de um cubo de gelo artificial em um laboratório moderno.", true)
        }));
        hisQ.Add(new Q("Serra da Capivara", new Alt[] {
            new Alt("Parque Nacional no Piauí que abriga milhares de pinturas rupestres antiquíssimas no Brasil.", false),
            new Alt("É considerado um Patrimônio Cultural da Humanidade protegido pela UNESCO.", false),
            new Alt("Fica localizado no centro da Europa, cercado por montanhas dos Alpes suíços.", true)
        }));
        hisQ.Add(new Q("Megafauna no Brasil", new Alt[] {
            new Alt("Animais gigantes habitaram o território brasileiro pré-histórico há milhares de anos.", false),
            new Alt("O gliptodonte, parecido com um tatu do tamanho de um carro pequeno, viveu no Brasil.", false),
            new Alt("Dinossauros gigantes nadavam no mar de Copacabana durante o ano de 1950.", true)
        }));
        hisQ.Add(new Q("O Âmbar Pré-Histórico", new Alt[] {
            new Alt("É uma resina vegetal endurecida de árvores antigas que preservou insetos dentro dela.", false),
            new Alt("Permite aos cientistas observar pequenos detalhes de seres vivos de milhões de anos atrás.", false),
            new Alt("É uma geleia doce comestível que escorria espontaneamente do teto das cavernas.", true)
        }));
        hisQ.Add(new Q("Ninhos de Dinossauros", new Alt[] {
            new Alt("Fósseis mostram que muitas espécies colocavam ovos em ninhos circulares escavados na terra.", false),
            new Alt("Alguns dinossauros cuidavam dos filhotes após o nascimento, trazendo comida ao ninho.", false),
            new Alt("Filhotes de dinossauro nasciam de ovos já vestindo armaduras e capacetes de metal.", true)
        }));
        hisQ.Add(new Q("O Fim da Pré-História", new Alt[] {
            new Alt("A Pré-História termina oficialmente no momento em que a humanidade desenvolve a escrita.", false),
            new Alt("A escrita permitiu registrar leis, acontecimentos e histórias em tabuletas de argila.", false),
            new Alt("A Pré-História acabou quando todos os vulcões do planeta explodiram ao mesmo tempo.", true)
        }));

        Console.WriteLine(string.Format("Geo Q count: {0}, His Q count: {1}", geoQ.Count, hisQ.Count));
        if (geoQ.Count != 50 || hisQ.Count != 50) {
            Console.WriteLine("ERROR: Not 50 questions each!");
            return;
        }

        // Validate each question has 3 alternatives and exactly 1 Falsa=true
        foreach (var q in geoQ) {
            if (q.Alts.Length != 3) throw new Exception(string.Format("Geo {0} doesn't have 3 alts", q.Nome));
            int f = 0;
            foreach (var a in q.Alts) if (a.F) f++;
            if (f != 1) throw new Exception(string.Format("Geo {0} has {1} false alts", q.Nome, f));
        }
        foreach (var q in hisQ) {
            if (q.Alts.Length != 3) throw new Exception(string.Format("His {0} doesn't have 3 alts", q.Nome));
            int f = 0;
            foreach (var a in q.Alts) if (a.F) f++;
            if (f != 1) throw new Exception(string.Format("His {0} has {1} false alts", q.Nome, f));
        }

        // Read the original file
        string originalFile = "src/ServerStorage/QuizBancoQuestoes.lua";
        string[] lines = File.ReadAllLines(originalFile, Encoding.UTF8);

        // We need to replace lines between [1] = { ... } in Geografia and [1] = { ... } in Historia
        // Find line indices
        int geoLvl1Start = -1, geoLvl2Start = -1;
        int hisStart = -1, hisLvl1Start = -1, hisLvl2Start = -1;

        for (int i = 0; i < lines.Length; i++) {
            string trimmed = lines[i].Trim();
            if (geoLvl1Start == -1 && trimmed == "[1] = {") {
                geoLvl1Start = i;
            } else if (geoLvl1Start != -1 && geoLvl2Start == -1 && trimmed == "[2] = {") {
                geoLvl2Start = i;
            } else if (trimmed.Contains("[\"História\"] = {") || trimmed.Contains("[\"Histria\"] = {")) {
                hisStart = i;
            } else if (hisStart != -1 && hisLvl1Start == -1 && trimmed == "[1] = {") {
                hisLvl1Start = i;
            } else if (hisLvl1Start != -1 && hisLvl2Start == -1 && trimmed == "[2] = {") {
                hisLvl2Start = i;
            }
        }

        Console.WriteLine(string.Format("geoLvl1Start: {0}, geoLvl2Start: {1}, hisLvl1Start: {2}, hisLvl2Start: {3}", geoLvl1Start, geoLvl2Start, hisLvl1Start, hisLvl2Start));

        var sbOut = new StringBuilder();

        // Part 1: from 0 up to geoLvl1Start (the "[1] = {" line)
        for (int i = 0; i <= geoLvl1Start; i++) {
            sbOut.AppendLine(lines[i]);
        }

        // Insert new Geo Level 1
        sbOut.AppendLine("\t\tDados = {");
        for (int i = 0; i < geoQ.Count; i++) {
            var q = geoQ[i];
            sbOut.AppendLine("\t\t\t{");
            sbOut.AppendLine(string.Format("\t\t\t\tNome = \"{0}\",", Escape(q.Nome)));
            sbOut.AppendLine("\t\t\t\tAlternativas = {");
            foreach (var a in q.Alts) {
                string fStr = a.F ? "true" : "false";
                sbOut.AppendLine(string.Format("\t\t\t\t\t{{Texto = \"{0}\", Falsa = {1}}},", Escape(a.T), fStr));
            }
            sbOut.AppendLine("\t\t\t\t}");
            sbOut.AppendLine(i == geoQ.Count - 1 ? "\t\t\t}" : "\t\t\t},");
        }
        sbOut.AppendLine("\t\t}");
        sbOut.AppendLine("\t},");

        // Part 2: from geoLvl2Start up to hisLvl1Start
        for (int i = geoLvl2Start; i <= hisLvl1Start; i++) {
            sbOut.AppendLine(lines[i]);
        }

        // Insert new His Level 1
        sbOut.AppendLine("\t\tDados = {");
        for (int i = 0; i < hisQ.Count; i++) {
            var q = hisQ[i];
            sbOut.AppendLine("\t\t\t{");
            sbOut.AppendLine(string.Format("\t\t\t\tNome = \"{0}\",", Escape(q.Nome)));
            sbOut.AppendLine("\t\t\t\tAlternativas = {");
            foreach (var a in q.Alts) {
                string fStr = a.F ? "true" : "false";
                sbOut.AppendLine(string.Format("\t\t\t\t\t{{Texto = \"{0}\", Falsa = {1}}},", Escape(a.T), fStr));
            }
            sbOut.AppendLine("\t\t\t\t}");
            sbOut.AppendLine(i == hisQ.Count - 1 ? "\t\t\t}" : "\t\t\t},");
        }
        sbOut.AppendLine("\t\t}");
        sbOut.AppendLine("\t},");

        // Part 3: from hisLvl2Start to end
        for (int i = hisLvl2Start; i < lines.Length; i++) {
            sbOut.AppendLine(lines[i]);
        }

        File.WriteAllText(originalFile, sbOut.ToString(), new UTF8Encoding(false));
        Console.WriteLine(string.Format("SUCCESS: Updated {0} successfully with UTF-8 no BOM!", originalFile));
    }

    static string Escape(string s) {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}
