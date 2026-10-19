using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class HisLevels1to2 {
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
        var his1 = new List<Q>();
        var his2 = new List<Q>();

        // Level 1
        his1.Add(new Q("Os Dinossauros", new Alt[] {
            new Alt("Viveram na Terra durante a Era Mesozoica, milhões de anos antes dos primeiros humanos.", false),
            new Alt("A maioria das espécies de dinossauros se reproduzia botando ovos com casca dura.", false),
            new Alt("Conviviam diariamente com os seres humanos nas cidades e andavam pelas ruas.", true)
        }));
        his1.Add(new Q("Período Paleolítico", new Alt[] {
            new Alt("Foi o período mais longo da história humana, também chamado de Idade da Pedra Lascada.", false),
            new Alt("Nessa época, os seres humanos aprenderam a produzir e controlar o fogo.", false),
            new Alt("As pessoas construíam arranha-céus e usavam eletricidade em suas casas de pedra.", true)
        }));
        his1.Add(new Q("Período Neolítico", new Alt[] {
            new Alt("Ficou conhecido pelo surgimento da agricultura e pelo cultivo dos primeiros alimentos.", false),
            new Alt("Os humanos desenvolveram a cerâmica para cozinhar e guardar grãos e líquidos.", false),
            new Alt("Foi a época histórica em que os seres humanos inventaram os primeiros computadores.", true)
        }));
        his1.Add(new Q("Idade dos Metais", new Alt[] {
            new Alt("Os seres humanos aprenderam a derreter e moldar metais como cobre, bronze e ferro.", false),
            new Alt("As ferramentas de metal tornaram as tarefas de plantar e construir muito mais fáceis.", false),
            new Alt("As ferramentas eram feitas exclusivamente de plástico moldado no calor.", true)
        }));
        his1.Add(new Q("Tiranossauro Rex", new Alt[] {
            new Alt("Era um predador carnívoro de grande porte que andava sobre duas fortes pernas traseiras.", false),
            new Alt("Suas mandíbulas possuíam dentes serrilhados que podiam esmagar ossos com facilidade.", false),
            new Alt("Possuía grandes asas cobertas de penas e voava sobre florestas em busca de comida.", true)
        }));
        his1.Add(new Q("Braquiossauro", new Alt[] {
            new Alt("Era um dinossauro herbívoro gigante com um pescoço muito comprido.", false),
            new Alt("Seu longo pescoço permitia alcançar as folhas mais frescas no topo das árvores altas.", false),
            new Alt("Era um predador ágil que caçava outros dinossauros no fundo de oceanos profundos.", true)
        }));
        his1.Add(new Q("Tricerátops", new Alt[] {
            new Alt("Tinha três chifres pontudos no rosto e uma grande gola óssea protetora no pescoço.", false),
            new Alt("Era um dinossauro herbívoro que se alimentava de plantas rasteiras e arbustos.", false),
            new Alt("Disparava raios de eletricidade pelos seus chifres para espantar inimigos.", true)
        }));
        his1.Add(new Q("Velociraptor", new Alt[] {
            new Alt("Era um dinossauro carnívoro veloz que possuía uma garra curva e afiada em cada pata.", false),
            new Alt("Estudos científicos modernos mostram que ele possuía penas cobrindo seu corpo.", false),
            new Alt("Era um gigante mais pesado que uma baleia-azul que se movia lentamente.", true)
        }));
        his1.Add(new Q("Estegossauro", new Alt[] {
            new Alt("Possuía duas fileiras de placas ósseas triangulares enfileiradas ao longo das costas.", false),
            new Alt("A ponta da sua cauda tinha quatro espinhos afiados usados para se defender de predadores.", false),
            new Alt("Possuía um cérebro gigante do tamanho de uma melancia com inteligência humana.", true)
        }));
        his1.Add(new Q("Pterossauros", new Alt[] {
            new Alt("Eram répteis voadores que dominaram os céus durante a mesma época dos dinossauros.", false),
            new Alt("Suas asas eram formadas por uma membrana de pele resistente presa a um dedo alongado.", false),
            new Alt("Eram pássaros modernos idênticos aos canários que viviam em gaiolas pré-históricas.", true)
        }));

        his1.Add(new Q("Espinossauro", new Alt[] {
            new Alt("Possuía uma enorme vela nas costas sustentada por espinhas ósseas alongadas.", false),
            new Alt("Seu focinho longo e dentes cônicos eram ideais para capturar grandes peixes na água.", false),
            new Alt("Vivia dentro de blocos de gelo no Polo Sul se alimentando de pinguins pré-históricos.", true)
        }));
        his1.Add(new Q("Fósseis", new Alt[] {
            new Alt("São restos ou vestígios de animais e plantas antigas preservados em camadas de rocha.", false),
            new Alt("Pegadas deixadas na lama que endureceu ao longo de milhões de anos também são fósseis.", false),
            new Alt("Qualquer osso se transforma em um fóssil de pedra após ficar dez minutos no quintal.", true)
        }));
        his1.Add(new Q("Paleontólogos", new Alt[] {
            new Alt("São os cientistas responsáveis por encontrar, escavar e estudar fósseis de seres do passado.", false),
            new Alt("Usam pincéis delicados e ferramentas finas para retirar fósseis da rocha sem quebrar.", false),
            new Alt("São profissionais treinados para consertar motores a jato de naves espaciais modernas.", true)
        }));
        his1.Add(new Q("Extinção dos Dinossauros", new Alt[] {
            new Alt("Aconteceu há cerca de 66 milhões de anos após o impacto de um grande asteroide na Terra.", false),
            new Alt("A poeira levantada pelo choque cobriu o Sol por meses, mudando o clima do planeta.", false),
            new Alt("Os dinossauros construíram foguetes e se mudaram em massa para o planeta Marte.", true)
        }));
        his1.Add(new Q("Era do Gelo", new Alt[] {
            new Alt("Foi um período da Terra em que temperaturas baixas cobriram vastas áreas com geleiras.", false),
            new Alt("Vários animais desenvolveram pelos grossos e camadas de gordura para sobreviver ao frio.", false),
            new Alt("Foi uma época em que o planeta Terra se transformou em uma panela de água fervente.", true)
        }));
        his1.Add(new Q("O Mamute", new Alt[] {
            new Alt("Era um parente pré-histórico dos elefantes coberto por uma espessa camada de pelos longos.", false),
            new Alt("Possuía presas de marfim curvadas que podiam ultrapassar três metros de comprimento.", false),
            new Alt("Passava o dia nas praias tropicais do Caribe nadando entre corais aquecidos.", true)
        }));
        his1.Add(new Q("Tigre-dentes-de-sabre", new Alt[] {
            new Alt("Era um poderoso felino pré-histórico famoso por seus dois dentes caninos compridos.", false),
            new Alt("Usava seus dentes longos e afiados para caçar presas grandes e pesadas na Era do Gelo.", false),
            new Alt("Era uma espécie de peixe de escamas verdes que nadava em rios amazônicos.", true)
        }));
        his1.Add(new Q("Preguiça-Gigante", new Alt[] {
            new Alt("Era um animal herbívoro pré-histórico enorme que viveu na América do Sul e no Brasil.", false),
            new Alt("Podia alcançar vários metros de altura quando se apoiava sobre as patas traseiras.", false),
            new Alt("Era menor que uma formiga e costumava viver dentro de troncos ocos de maçã.", true)
        }));
        his1.Add(new Q("Homens das Cavernas", new Alt[] {
            new Alt("Eram nossos ancestrais pré-históricos que usavam abrigos naturais contra o vento e frio.", false),
            new Alt("Viviam em pequenos grupos que cooperavam entre si para caçar e colher alimentos.", false),
            new Alt("Compravam suas cavernas em agências imobiliárias usando moedas de ouro de piratas.", true)
        }));
        his1.Add(new Q("Pinturas Rupestres", new Alt[] {
            new Alt("São desenhos gravados em paredes e tetos de cavernas por seres humanos pré-históricos.", false),
            new Alt("Costumavam representar animais como bisões, cavalos selvagens e cenas de caçadas.", false),
            new Alt("Eram feitas usando canetinhas hidrográficas coloridas e tintas acrílicas sintéticas.", true)
        }));

        his1.Add(new Q("Tinta Pré-Histórica", new Alt[] {
            new Alt("Era preparada misturando pós de minerais, argila colorida, carvão e gordura animal.", false),
            new Alt("Alguns desenhos foram feitos soprando tinta em pó ao redor da mão apoiada na rocha.", false),
            new Alt("Era comprada pronta em latas de tinta spray vendidas em armazéns antigos.", true)
        }));
        his1.Add(new Q("Descoberta do Fogo", new Alt[] {
            new Alt("Permitiu aos primeiros humanos cozinhar a carne dos alimentos e deixá-la mais macia.", false),
            new Alt("O calor das chamas ajudou a espantar predadores noturnos e a aquecer as noites frias.", false),
            new Alt("O fogo foi aceso pelos primeiros homens com caixas de fósforos de madeira modernas.", true)
        }));
        his1.Add(new Q("Pedra Lascada", new Alt[] {
            new Alt("Técnica em que uma pedra dura batia em outra para soltar lascas com bordas muito afiadas.", false),
            new Alt("As lascas de pedra eram usadas como raspadores para limpar couro e facas de corte.", false),
            new Alt("As pedras eram cortadas com aparelhos de laser elétricos de alta tecnologia.", true)
        }));
        his1.Add(new Q("Povos Nômades", new Alt[] {
            new Alt("Grupos que não tinham moradia fixa e mudavam de região quando os recursos acabavam.", false),
            new Alt("Seguiam as rotas dos animais para caçar e buscavam novos frutos e plantas da estação.", false),
            new Alt("Moravam no mesmo apartamento durante cinquenta anos sem sair para nenhum lugar.", true)
        }));
        his1.Add(new Q("Armas de Caça Primitivas", new Alt[] {
            new Alt("Lanças de madeira com pontas afiadas de pedra eram arremessadas contra animais de caça.", false),
            new Alt("O propulsor de lanças foi inventado para lançar os dardos com muito mais força e alcance.", false),
            new Alt("Eram espingardas automáticas equipadas com miras telescópicas de visão noturna.", true)
        }));
        his1.Add(new Q("Roupas na Pré-História", new Alt[] {
            new Alt("Eram feitas com peles e pelos de animais caçados, limpas e costuradas para dar abrigo.", false),
            new Alt("Eram essenciais para proteger os corpos do frio congelante e dos ventos nas caçadas.", false),
            new Alt("Eram confeccionadas com tecidos de náilon e fechadas por zíperes de metal inox.", true)
        }));
        his1.Add(new Q("Agulhas de Osso", new Alt[] {
            new Alt("Eram feitas polindo lascas finas de ossos de animais com um pequeno furo na extremidade.", false),
            new Alt("Permitiram passar tendões e tiras de couro para costurar roupas muito bem ajustadas.", false),
            new Alt("Eram fabricadas em aço inoxidável cirúrgico com baterias eletrônicas embutidas.", true)
        }));
        his1.Add(new Q("Arco e Flecha", new Alt[] {
            new Alt("Foi uma invenção revolucionária que permitiu aos caçadores atingir alvos rápidos de longe.", false),
            new Alt("Utilizava a força da madeira recurvada e a tensão de cordas feitas de fibras vegetais.", false),
            new Alt("Precisava de uma tomada elétrica conectada à parede para disparar suas flechas.", true)
        }));
        his1.Add(new Q("Origem da Agricultura", new Alt[] {
            new Alt("Os humanos perceberam que sementes caídas na terra brotavam e davam novas plantas.", false),
            new Alt("O plantio de grãos como trigo e cevada garantiu comida sem depender apenas da caça.", false),
            new Alt("Plantavam pedaços de plástico no solo esperando colher brinquedos prontos nas árvores.", true)
        }));
        his1.Add(new Q("Povos Sedentários", new Alt[] {
            new Alt("Ao aprender a plantar alimentos, as pessoas passaram a se fixar em um local permanente.", false),
            new Alt("Construíram as primeiras aldeias com moradias duradouras perto de rios e terras férteis.", false),
            new Alt("Viajavam toda semana em viagens de trem de alta velocidade para mudar de cidade.", true)
        }));

        his1.Add(new Q("Domesticação de Animais", new Alt[] {
            new Alt("Humanos começaram a cuidar de animais como cabras, ovelhas e vacas para obter leite e lã.", false),
            new Alt("A criação de rebanhos fornecia alimento regular sem o perigo das caçadas na floresta.", false),
            new Alt("Os primeiros povos domesticavam tiranossauros rex para carregar compras nas aldeias.", true)
        }));
        his1.Add(new Q("O Cão na Pré-História", new Alt[] {
            new Alt("O lobo foi o primeiro animal a ser domesticado, tornando-se o fiel amigo dos humanos.", false),
            new Alt("Cães primitivos ajudavam os caçadores a farejar presas e protegiam a aldeia durante a noite.", false),
            new Alt("O primeiro animal domesticado pela humanidade foi o tubarão-baleia dos oceanos.", true)
        }));
        his1.Add(new Q("A Cerâmica", new Alt[] {
            new Alt("Vasos e potes eram moldados em barro úmido e depois assados no fogo para endurecer.", false),
            new Alt("Permitiu cozinhar alimentos líquidos em sopas e estocar água e grãos por meses.", false),
            new Alt("Os primeiros potes de cerâmica eram moldados usando garrafas plásticas recicladas.", true)
        }));
        his1.Add(new Q("A Tecelagem", new Alt[] {
            new Alt("Aprenderam a trançar fios de lã animal e de fibras de plantas para criar os primeiros panos.", false),
            new Alt("Os tecidos leves tornaram as vestimentas muito mais confortáveis nos períodos mais quentes.", false),
            new Alt("Os tecidos eram produzidos em fábricas computadorizadas com robôs de alta precisão.", true)
        }));
        his1.Add(new Q("Primeiras Canoas", new Alt[] {
            new Alt("Eram feitas cavando o interior de troncos grossos de árvores com auxílio do fogo e raspadeiras.", false),
            new Alt("Facilitaram a travessia de rios largos e permitiram a pesca em águas mais fundas.", false),
            new Alt("Eram movidas por motores de popa a gasolina com turbinas submarinas de corrida.", true)
        }));
        his1.Add(new Q("A Invenção da Roda", new Alt[] {
            new Alt("Foi uma das invenções mais importantes, facilitando o transporte de cargas muito pesadas.", false),
            new Alt("As primeiras rodas eram discos maciços feitos de pedras esculpidas ou troncos de madeira.", false),
            new Alt("Possuíam pneus modernos de borracha sintética cheios de ar e calotas de liga leve.", true)
        }));
        his1.Add(new Q("Pedra Polida", new Alt[] {
            new Alt("Técnica em que as pedras eram friccionadas com areia e água até ficarem lisinhas e afiadas.", false),
            new Alt("Machados de pedra polida eram muito mais eficientes para cortar troncos de árvores.", false),
            new Alt("As pedras eram amaciadas usando amaciante de roupas e sabão em pó moderno.", true)
        }));
        his1.Add(new Q("O Metal Cobre", new Alt[] {
            new Alt("Foi um dos primeiros metais trabalhados pelos humanos por ser maleável e fácil de moldar.", false),
            new Alt("Podia ser martelado a frio ou derretido em fornos rústicos para criar ferramentas e pontas.", false),
            new Alt("O cobre brotava em árvores frutíferas e era colhido nos galhos como se fosse maçã.", true)
        }));
        his1.Add(new Q("A Descoberta do Bronze", new Alt[] {
            new Alt("Surgiu da mistura inteligente do cobre derretido com estanho, criando uma liga resistente.", false),
            new Alt("Ferramentas e armas de bronze eram bem mais duráveis e mantinham o corte por mais tempo.", false),
            new Alt("O bronze era recolhido no fundo das nuvens durante tempestades de chuva forte.", true)
        }));
        his1.Add(new Q("A Idade do Ferro", new Alt[] {
            new Alt("O ferro exigia fornos de alta temperatura para derreter, sendo o metal mais resistente da época.", false),
            new Alt("Permitiu criar arados mais fortes para cavar a terra e foices para a colheita dos campos.", false),
            new Alt("O ferro derretia espontaneamente quando era exposto a uma simples brisa de vento frio.", true)
        }));

        his1.Add(new Q("Casas Primitivas", new Alt[] {
            new Alt("Eram erguidas com armações de galhos de madeira, paredes de barro e teto de palha seca.", false),
            new Alt("Protegiam as famílias do sol forte, da chuva e das feras da natureza ao redor.", false),
            new Alt("Eram construídas com grandes placas de vidro blindado e ar-condicionado central.", true)
        }));
        his1.Add(new Q("O Escambo Primitivo", new Alt[] {
            new Alt("Era um sistema de comércio baseado na troca direta de mercadorias sem o uso de dinheiro.", false),
            new Alt("Quem tinha excesso de grãos de trigo podia trocar por potes de cerâmica ou carne de peixe.", false),
            new Alt("As compras das aldeias antigas eram pagas com cartões de crédito e Pix no celular.", true)
        }));
        his1.Add(new Q("Monumentos de Megálitos", new Alt[] {
            new Alt("Eram construções formadas por blocos gigantes de pedra colocados em pé pelos povos pré-históricos.", false),
            new Alt("Exigiam o esforço coordenado de dezenas ou centenas de pessoas puxando pedras sobre troncos.", false),
            new Alt("Os blocos eram erguidos por guindastes movidos a diesel de construção moderna.", true)
        }));
        his1.Add(new Q("Stonehenge", new Alt[] {
            new Alt("É um famoso monumento pré-histórico de pedras gigantes dispostas em círculos na Inglaterra.", false),
            new Alt("Pesquisadores acreditam que o monumento servia para observar os movimentos do Sol e da Lua.", false),
            new Alt("Foi construído no ano de 2015 para funcionar como um shopping center de jogos.", true)
        }));
        his1.Add(new Q("O Fóssil de Luzia", new Alt[] {
            new Alt("É o fóssil de esqueleto humano mais antigo já encontrado no território da América do Sul.", false),
            new Alt("Foi descoberto em uma caverna na região de Lagoa Santa, no estado de Minas Gerais no Brasil.", false),
            new Alt("Foi encontrado congelado dentro de um cubo de gelo artificial em um laboratório moderno.", true)
        }));
        his1.Add(new Q("Serra da Capivara", new Alt[] {
            new Alt("Parque Nacional no Piauí que abriga milhares de pinturas rupestres antiquíssimas no Brasil.", false),
            new Alt("É considerado um Patrimônio Cultural da Humanidade protegido pela UNESCO.", false),
            new Alt("Fica localizado no centro da Europa, cercado por montanhas dos Alpes suíços.", true)
        }));
        his1.Add(new Q("Megafauna no Brasil", new Alt[] {
            new Alt("Animais gigantes habitaram o território brasileiro pré-histórico há milhares de anos.", false),
            new Alt("O gliptodonte, parecido com um tatu do tamanho de um carro pequeno, viveu no Brasil.", false),
            new Alt("Dinossauros gigantes nadavam no mar de Copacabana durante o ano de 1950.", true)
        }));
        his1.Add(new Q("O Âmbar Pré-Histórico", new Alt[] {
            new Alt("É uma resina vegetal endurecida de árvores antigas que preservou insetos dentro dela.", false),
            new Alt("Permite aos cientistas observar pequenos detalhes de seres vivos de milhões de anos atrás.", false),
            new Alt("É uma geleia doce comestível que escorria espontaneamente do teto das cavernas.", true)
        }));
        his1.Add(new Q("Ninhos de Dinossauros", new Alt[] {
            new Alt("Fósseis mostram que muitas espécies colocavam ovos em ninhos circulares escavados na terra.", false),
            new Alt("Alguns dinossauros cuidavam dos filhotes após o nascimento, trazendo comida ao ninho.", false),
            new Alt("Filhotes de dinossauro nasciam de ovos já vestindo armaduras e capacetes de metal.", true)
        }));
        his1.Add(new Q("O Fim da Pré-História", new Alt[] {
            new Alt("A Pré-História termina oficialmente no momento em que a humanidade desenvolve a escrita.", false),
            new Alt("A escrita permitiu registrar leis, acontecimentos e histórias em tabuletas de argila.", false),
            new Alt("A Pré-História acabou quando todos os vulcões do planeta explodiram ao mesmo tempo.", true)
        }));

        // Level 2
        his2.Add(new Q("O Rio Nilo no Egito Antigo", new Alt[] {
            new Alt("Suas cheias periódicas deixavam uma camada de lodo escuro e fértil nas margens para plantar.", false),
            new Alt("O historiador grego Heródoto chamou a civilização egípcia de uma dádiva do Rio Nilo.", false),
            new Alt("Era um rio de lava de vulcão fervente por onde barcos de madeira não podiam navegar.", true)
        }));
        his2.Add(new Q("Os Faraós", new Alt[] {
            new Alt("Eram os governantes supremos do Egito, considerados também representantes vivos dos deuses.", false),
            new Alt("Usavam coroas especiais e cetros dourados como símbolos de sua autoridade real e militar.", false),
            new Alt("Eram escolhidos pelo povo por meio de votação eletrônica em urnas a cada dois anos.", true)
        }));
        his2.Add(new Q("As Pirâmides de Gizé", new Alt[] {
            new Alt("Foram construídas como túmulos grandiosos de pedra para guardar os corpos e tesouros dos faraós.", false),
            new Alt("A Grande Pirâmide foi construída para o faraó Quéops há mais de quatro mil anos.", false),
            new Alt("Foram levantadas usando guindastes elétricos modernos e caminhões caçamba a diesel.", true)
        }));
        his2.Add(new Q("A Grande Esfinge", new Alt[] {
            new Alt("É uma monumental escultura em pedra com corpo de leão deitado e cabeça humana com touca real.", false),
            new Alt("Foi esculpida próxima às pirâmides de Gizé para servir de guardiã espiritual da necrópole.", false),
            new Alt("Possui asas de avião supersônico e uma cabeça feita de circuitos de computador modernos.", true)
        }));
        his2.Add(new Q("A Mumificação", new Alt[] {
            new Alt("Era um ritual sagrado para preservar o corpo dos mortos usando sal natrão, resinas e linho.", false),
            new Alt("Acreditavam que o espírito precisava reconhecer o corpo preservado para viver no além.", false),
            new Alt("Consistia em mergulhar o corpo em caldas de chocolate quente com granulados de doce.", true)
        }));
        his2.Add(new Q("Os Sarcófagos", new Alt[] {
            new Alt("Eram caixões de pedra ou madeira ricamente pintados com símbolos protetores e o rosto do morto.", false),
            new Alt("Protegiam a múmia e podiam ser colocados um dentro do outro como caixas especiais.", false),
            new Alt("Eram caixas de papelão amassado que eram jogadas na lixeira do palácio após o velório.", true)
        }));
        his2.Add(new Q("Os Vasos Canópicos", new Alt[] {
            new Alt("Eram quatro recipientes com tampas esculpidas em cabeças de deuses para guardar órgãos internos.", false),
            new Alt("Guardavam o fígado, os pulmões, o estômago e os intestinos que eram retirados do corpo.", false),
            new Alt("Eram xícaras de porcelana moderna usadas para servir café com leite aos sacerdotes.", true)
        }));
        his2.Add(new Q("Os Hieróglifos", new Alt[] {
            new Alt("Eram a escrita sagrada egípcia composta por centenas de figuras de pássaros, olhos e símbolos.", false),
            new Alt("Eram gravados em paredes de templos de pedra, túmulos de reis e folhas compridas de papiro.", false),
            new Alt("Eram compostos por letras em inglês digitadas em teclados sem fio modernos.", true)
        }));
        his2.Add(new Q("O Papel Papiro", new Alt[] {
            new Alt("Era feito a partir das hastes de uma planta aquática que crescia em abundância no Rio Nilo.", false),
            new Alt("As tiras da planta eram prensadas e secas, criando uma das primeiras folhas de escrita da história.", false),
            new Alt("Era um tipo de plástico transparente sintético fabricado com derivados de petróleo.", true)
        }));
        his2.Add(new Q("A Pedra de Roseta", new Alt[] {
            new Alt("Foi um bloco de pedra negro achado com um mesmo decreto escrito em grego e hieróglifos.", false),
            new Alt("Permitiu ao pesquisador Champollion decifrar pela primeira vez os hieróglifos egípcios antigos.", false),
            new Alt("Era um aparelho celular antigo de pedra que transmitia músicas populares pelo rádio.", true)
        }));

        his2.Add(new Q("O Faraó Tutancâmon", new Alt[] {
            new Alt("Ficou famoso como o faraó menino porque assumiu o trono do Egito com apenas nove anos de idade.", false),
            new Alt("Sua tumba foi descoberta quase intacta no Vale dos Reis, contendo uma máscara de ouro puro.", false),
            new Alt("Reinou por mais de cem anos e foi o inventor do primeiro automóvel a gasolina.", true)
        }));
        his2.Add(new Q("A Rainha Cleópatra", new Alt[] {
            new Alt("Foi uma governante famosa do Egito Antigo, reconhecida por sua inteligência e habilidades políticas.", false),
            new Alt("Falava vários idiomas e fez alianças históricas com grandes líderes romanos da sua época.", false),
            new Alt("Foi uma astronauta pioneira que viajou em um foguete para dar uma volta na Lua.", true)
        }));
        his2.Add(new Q("O Faraó Ramsés II", new Alt[] {
            new Alt("Foi um dos faraós que governou por mais tempo, liderando grandes batalhas e erguendo monumentos.", false),
            new Alt("Mandou construir os impressionantes templos esculpidos na rocha da montanha em Abu Simbel.", false),
            new Alt("Voava pelos céus do Egito pilotando um helicóptero de combate equipado com mísseis.", true)
        }));
        his2.Add(new Q("A Deusa Ísis", new Alt[] {
            new Alt("Era uma das deusas mais queridas do Egito, associada à magia, à cura e à proteção materna.", false),
            new Alt("Era esposa do deus Osíris e mãe do deus Hórus nas narrativas sagradas da mitologia egípcia.", false),
            new Alt("Era uma deusa com formato de guindaste de ferro que ajudava nas obras da cidade.", true)
        }));
        his2.Add(new Q("O Deus Rá", new Alt[] {
            new Alt("Era o deus egípcio do Sol, considerado uma das divindades criadoras mais poderosas do panteão.", false),
            new Alt("Os egípcios acreditavam que ele cruzava o céu diariamente em uma grande barca solar sagrada.", false),
            new Alt("Era o deus do gelo polar e da escuridão eterna que congelava o calor de todas as plantas.", true)
        }));
        his2.Add(new Q("O Deus Anúbis", new Alt[] {
            new Alt("Era representado como um homem com cabeça de chacal negro protetor dos mortos.", false),
            new Alt("Era o guardião do ritual de mumificação e pesava o coração das pessoas na balança divina.", false),
            new Alt("Tinha a cabeça de um periquito verde cantante que assobiava marchinhas nos templos.", true)
        }));
        his2.Add(new Q("O Deus Hórus", new Alt[] {
            new Alt("Era representado com a cabeça de um falcão vigilante e o famoso olho protetor de Hórus.", false),
            new Alt("O faraó no trono era visto pelos egípcios como a representação do próprio Hórus vivo na Terra.", false),
            new Alt("Era uma baleia de água doce que nadava de cabeça para baixo no fundo do Rio Nilo.", true)
        }));
        his2.Add(new Q("O Deus Osíris", new Alt[] {
            new Alt("Era o deus da vegetação, da ressurreição e o soberano do reino dos mortos na mitologia.", false),
            new Alt("Geralmente era desenhado com o corpo enfaixado como uma múmia e a pele na cor verde da vida.", false),
            new Alt("Era um monstro de fogo voador que devorava as plantações de trigo das margens do rio.", true)
        }));
        his2.Add(new Q("Os Gatos no Egito Antigo", new Alt[] {
            new Alt("Eram animais sagrados muito queridos que protegiam as casas e celeiros caçando ratos e cobras.", false),
            new Alt("Eram associados à deusa Bastet, protetora do lar e da alegria, e recebiam sepultamento digno.", false),
            new Alt("Eram estritamente proibidos em todo o território egípcio sob pena de prisão perpétua.", true)
        }));
        his2.Add(new Q("O Escaravelho Sagrado", new Alt[] {
            new Alt("Era um amuleto muito popular esculpido em pedras verdes ou azuis para trazer boa sorte e vida.", false),
            new Alt("Inspirado no besouro que rola bolas de terra, simbolizava o Sol nascendo a cada novo dia.", false),
            new Alt("Era um pássaro aquático migratório gigante com cauda de pavão emplumada de prata.", true)
        }));

        his2.Add(new Q("Maquiagem no Egito (Kohl)", new Alt[] {
            new Alt("Homens e mulheres pintavam o contorno dos olhos com pó mineral escuro misturado com óleos.", false),
            new Alt("A maquiagem escura ajudava a proteger os olhos contra o brilho excessivo do sol do deserto.", false),
            new Alt("A maquiagem dos egípcios era feita exclusivamente com graxa suja de motor de caminhão.", true)
        }));
        his2.Add(new Q("Barcos a Vela no Nilo", new Alt[] {
            new Alt("O Nilo funcionava como a principal estrada líquida do Egito para o transporte de cargas e pessoas.", false),
            new Alt("Usavam a correnteza da água para descer o rio e a força do vento nas velas para subir ao sul.", false),
            new Alt("Eram impulsionados por reatores nucleares submarinos que quebravam a barreira do som.", true)
        }));
        his2.Add(new Q("A Alimentação dos Egípcios", new Alt[] {
            new Alt("A dieta básica do povo incluía pães de cevada e trigo, cebolas, alho, lentilhas e peixe do rio.", false),
            new Alt("Frutas doces como figos, uvas e tâmaras eram apreciadas como sobremesas saudáveis no Egito.", false),
            new Alt("As famílias jantavam caixas de pizza congelada de micro-ondas todas as noites nos palácios.", true)
        }));
        his2.Add(new Q("A Cerveja dos Egípcios", new Alt[] {
            new Alt("Era uma bebida espessa e fermentada de grãos de cevada, considerada um alimento do dia a dia.", false),
            new Alt("Era rica em nutrientes e muitas vezes consumida porque era mais pura e segura que a água crua.", false),
            new Alt("Era servida em garrafas plásticas descartáveis com canudos de plástico coloridos.", true)
        }));
        his2.Add(new Q("O Ouro dos Faraós", new Alt[] {
            new Alt("O Egito possuía jazidas de ouro no deserto oriental e no sul, produzindo joias deslumbrantes.", false),
            new Alt("Os egípcios chamavam o ouro de carne dos deuses por seu brilho brilhante que não enferruja.", false),
            new Alt("As peças de ouro dos túmulos eram todas moldadas com massinha de modelar escolar comum.", true)
        }));
        his2.Add(new Q("Os Escribas Egípcios", new Alt[] {
            new Alt("Eram funcionários de grande prestígio que dominavam a complexa escrita e a contabilidade do reino.", false),
            new Alt("Registravam a quantidade de grãos colhidos nos armazéns reais, impostos e ordens do faraó.", false),
            new Alt("Eram robôs com inteligência artificial que imprimiam relatórios em impressoras a laser.", true)
        }));
        his2.Add(new Q("Escolas no Antigo Egito", new Alt[] {
            new Alt("As escolas funcionavam geralmente anexas aos templos religiosos para filhos de nobres e escribas.", false),
            new Alt("A maioria das crianças do campo aprendia a plantar, cuidar de animais ou fazer cerâmica com os pais.", false),
            new Alt("Todas as crianças do país usavam notebooks e tablets conectados ao Wi-Fi na sala de aula.", true)
        }));
        his2.Add(new Q("Brinquedos das Crianças", new Alt[] {
            new Alt("Crianças do Antigo Egito brincavam com bonecas de pano e madeira, piões e bolinhas de argila.", false),
            new Alt("Gostavam de nadar nas águas do rio e participar de corridas e jogos ao ar livre com amigos.", false),
            new Alt("Passavam o dia inteiro jogando videogames de aventura em televisores de tela plana de cinema.", true)
        }));
        his2.Add(new Q("O Tabuleiro de Senet", new Alt[] {
            new Alt("Era um dos jogos de tabuleiro mais famosos e antigos do Egito, com trinta casas em fileiras.", false),
            new Alt("Era praticado por pessoas comuns e pelos próprios faraós, que levavam tabuleiros aos túmulos.", false),
            new Alt("Era um aplicativo de celular com tela touch screen baixado em lojas de jogos virtuais.", true)
        }));
        his2.Add(new Q("Templos de Karnak e Luxor", new Alt[] {
            new Alt("Eram gigantescos complexos religiosos construídos com pedras maciças em homenagem ao deus Amon.", false),
            new Alt("Possuíam grandes avenidas de esfinges e colunas com mais de vinte metros cobertas de relevos.", false),
            new Alt("Foram montados exclusivamente com peças de plástico colorido de encaixe de brinquedo.", true)
        }));

        his2.Add(new Q("O Trabalho no Campo", new Alt[] {
            new Alt("Os camponeses trabalhavam no cultivo de grãos nas margens do Nilo e na colheita sob o sol quente.", false),
            new Alt("Durante a época em que o Nilo inundava os campos, muitos eram chamados para trabalhar nas obras reais.", false),
            new Alt("Os camponeses usavam tratores automáticos com piloto automático guiado por GPS moderno.", true)
        }));
        his2.Add(new Q("A Fértil Mesopotâmia", new Alt[] {
            new Alt("Era uma região histórica no Oriente Médio situada entre os vales dos rios Tigre e Eufrates.", false),
            new Alt("Seu solo fértil permitiu o surgimento de algumas das primeiras cidades da história da humanidade.", false),
            new Alt("Fica localizada bem no centro da densa Floresta Amazônica no norte do território do Brasil.", true)
        }));
        his2.Add(new Q("O Povo Sumério", new Alt[] {
            new Alt("Foi uma das civilizações mais antigas da Mesopotâmia, famosa pela invenção da escrita cuneiforme.", false),
            new Alt("Construíram canais de irrigação para controlar as águas dos rios e abastecer suas plantações.", false),
            new Alt("Inventaram o primeiro modelo de carro voador supersônico com motores elétricos.", true)
        }));
        his2.Add(new Q("A Escrita Cuneiforme", new Alt[] {
            new Alt("Era feita gravando símbolos com uma haste em forma de cunha sobre placas de barro úmido.", false),
            new Alt("Depois de gravadas, as tabuletas de argila secavam ao sol ou no forno para durar séculos.", false),
            new Alt("Era uma fonte digital de computador instalada em editores de texto modernos para imprimir.", true)
        }));
        his2.Add(new Q("Os Zigurates", new Alt[] {
            new Alt("Eram imponentes construções em formato de pirâmide de degraus erguidas nas cidades mesopotâmicas.", false),
            new Alt("No topo dessas torres ficava o templo sagrado dedicado ao deus protetor daquela cidade.", false),
            new Alt("Eram pistas de esqui no gelo cobertas de neve artificial para turistas esquiarem no verão.", true)
        }));
        his2.Add(new Q("A Cidade de Babilônia", new Alt[] {
            new Alt("Foi uma das capitais mais ricas e famosas do mundo antigo, repleta de muralhas e portões azuis.", false),
            new Alt("O Portão de Ishtar era uma das entradas mais bonitas da cidade, decorado com touros e dragões.", false),
            new Alt("Era uma minúscula tenda de pano montada em cima de um rochedo deserto no meio do oceano.", true)
        }));
        his2.Add(new Q("O Código de Hamurabi", new Alt[] {
            new Alt("Foi um dos códigos de leis escritas mais antigos da história, criado por um rei da Babilônia.", false),
            new Alt("Suas leis foram gravadas em um grande bloco de pedra escura para que todos conhecessem as regras.", false),
            new Alt("Foi escrito em páginas de caderno escolar com caneta marca-texto colorida e fita crepe.", true)
        }));
        his2.Add(new Q("Jardins Suspensos da Babilônia", new Alt[] {
            new Alt("Segundo lendas antigas, eram belos terraços com plantas e flores irrigadas no alto do palácio.", false),
            new Alt("Foram considerados por historiadores gregos como uma das Sete Maravilhas do Mundo Antigo.", false),
            new Alt("Eram canteiros de flores reais que flutuavam no ar amarrados a centenas de balões de gás hélio.", true)
        }));
        his2.Add(new Q("O Relógio de Sol", new Alt[] {
            new Alt("Foi um instrumento inventado por povos antigos para medir a passagem das horas pela sombra do Sol.", false),
            new Alt("Conforme a Terra girava, a sombra projetada por uma haste marcava as divisões do dia no solo.", false),
            new Alt("Possuía tela digital de vidro temperado conectada via Bluetooth a celulares modernos.", true)
        }));
        his2.Add(new Q("O Calendário de 365 Dias", new Alt[] {
            new Alt("Os egípcios criaram um calendário solar com 12 meses de 30 dias mais 5 dias dedicados aos deuses.", false),
            new Alt("O calendário era muito útil para saber a época exata da cheia do Rio Nilo e do plantio de trigo.", false),
            new Alt("Era um calendário curioso onde o ano inteiro tinha apenas quatro semanas de duração.", true)
        }));

        his2.Add(new Q("A Medicina Egípcia", new Alt[] {
            new Alt("Os médicos egípcios tratavam doentes com ervas, limpavam feridas com mel e imobilizavam fraturas.", false),
            new Alt("Graças à prática de mumificação, os egípcios aprenderam muito sobre a anatomia do corpo humano.", false),
            new Alt("Curavam doenças aplicando vacinas de nanotecnologia com robôs microscópicos nos pacientes.", true)
        }));
        his2.Add(new Q("Os Navegadores Fenícios", new Alt[] {
            new Alt("Eram marinheiros e comerciantes habilidosos que navegavam por todo o Mar Mediterrâneo.", false),
            new Alt("Criaram um alfabeto inovador baseado em sons que facilitou o comércio entre diferentes povos.", false),
            new Alt("Viajavam pelo fundo dos oceanos usando submarinos atômicos com radares de sonar modernos.", true)
        }));
        his2.Add(new Q("Rotas de Comércio Antigas", new Alt[] {
            new Alt("Povos antigos viajavam em caravanas pelo deserto para trocar azeite, cerâmicas, tecidos e incenso.", false),
            new Alt("Cidades como Tiro, Babilônia e Alexandria tornaram-se grandes mercados de encontro de mercadores.", false),
            new Alt("As mercadorias eram despachadas em aviões de carga supersônicos com entrega no mesmo dia.", true)
        }));
        his2.Add(new Q("A Barca Solar de Quéops", new Alt[] {
            new Alt("Era um grande barco de madeira de cedro desmontado e enterrado ao lado da Grande Pirâmide de Gizé.", false),
            new Alt("Foi construído para permitir ao faraó navegar pelo céu com os deuses após a vida terrena.", false),
            new Alt("Possuía turbinas a jato que soltavam labaredas de fogo azul para quebrar a velocidade do som.", true)
        }));
        his2.Add(new Q("As Bigas de Guerra", new Alt[] {
            new Alt("Eram carruagens leves de madeira puxadas por dois cavalos velozes, com um condutor e um arqueiro.", false),
            new Alt("Revolucionaram as batalhas no Oriente Médio e no Egito Antigo pela sua velocidade e mobilidade.", false),
            new Alt("Eram veículos blindados de metal pesado com esteiras de tanque e canhões automáticos.", true)
        }));
        his2.Add(new Q("Espelhos e Pentes Egípcios", new Alt[] {
            new Alt("Os egípcios fabricavam pentes finos de marfim ou madeira e espelhos de cobre ou bronze polido.", false),
            new Alt("A higiene diária era essencial, e nobres egípcios lavavam-se várias vezes ao dia e raspavam pelos.", false),
            new Alt("Usavam câmeras de celular com iluminação de anel de LED para verificar o visual no espelho.", true)
        }));
        his2.Add(new Q("A Cidade de Tebas", new Alt[] {
            new Alt("Foi uma das capitais mais importantes do Egito Antigo durante a época dos grandes impérios.", false),
            new Alt("Ficava no Alto Egito, perto dos grandes templos e da famosa necrópole do Vale dos Reis.", false),
            new Alt("Era uma cidade submarina instalada dentro de uma cúpula de vidro no fundo do oceano.", true)
        }));
        his2.Add(new Q("O Vale dos Reis", new Alt[] {
            new Alt("É um vale desértico onde faraós do Novo Império foram sepultados em tumbas cavadas na rocha.", false),
            new Alt("As tumbas eram escavadas no subterrâneo das montanhas para tentar esconder os tesouros de ladrões.", false),
            new Alt("Era um parque aquático moderno repleto de tobogãs coloridos e piscinas de ondas mecânicas.", true)
        }));
        his2.Add(new Q("Casas de Barro (Adobe)", new Alt[] {
            new Alt("A maioria das moradias egípcias era feita com tijolos de barro do Nilo misturados com palha seca.", false),
            new Alt("As paredes grossas de barro ajudavam a manter o interior das casas fresco no calor do deserto.", false),
            new Alt("Eram cabanas modernas feitas de folhas de isopor e janelas de vidro à prova de bala.", true)
        }));
        his2.Add(new Q("O Legado do Antigo Egito", new Alt[] {
            new Alt("O fascínio pelas pirâmides, pelas múmias e pelos templos do Egito atrai milhões de pessoas até hoje.", false),
            new Alt("Seus conhecimentos de geometria, irrigação, arte e astronomia influenciaram muitas civilizações.", false),
            new Alt("O Egito Antigo nunca existiu na realidade e foi uma história inventada para um desenho animado.", true)
        }));

        var sbOut = new StringBuilder();
        var levels = new Dictionary<int, List<Q>> { { 1, his1 }, { 2, his2 } };
        for (int lvl = 1; lvl <= 2; lvl++) {
            sbOut.AppendLine(string.Format("    [{0}] = {{", lvl));
            sbOut.AppendLine("        Dados = {");
            foreach (var q in levels[lvl]) {
                sbOut.AppendLine("            {");
                sbOut.AppendLine(string.Format("                Nome = \"{0}\",", Escape(q.Nome)));
                sbOut.AppendLine("                Alternativas = {");
                foreach (var a in q.Alts) {
                    sbOut.AppendLine(string.Format("                    {{ Texto = \"{0}\", Falsa = {1} }},", Escape(a.T), a.F ? "true" : "false"));
                }
                sbOut.AppendLine("                }");
                sbOut.AppendLine("            },");
            }
            sbOut.AppendLine("        }");
            sbOut.AppendLine("    },");
        }
        File.WriteAllText("temp_his_levels_1_2.lua", sbOut.ToString(), Encoding.UTF8);
        Console.WriteLine("Wrote temp_his_levels_1_2.lua successfully");
    }

    static string Escape(string s) {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}
