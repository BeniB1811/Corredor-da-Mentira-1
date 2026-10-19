using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class HisLevels3to6 {
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
        for (int i = 3; i <= 6; i++) levels[i] = new List<Q>();

        // ==========================================
        // NIVEL 3: GRÉCIA E ROMA ANTIGA (50 Questões)
        // ==========================================
        var l3 = levels[3];
        l3.Add(new Q("Os Jogos Olímpicos Antigos", new Alt[] {
            new Alt("Nasceram na Grécia Antiga, na cidade de Olímpia, em homenagem ao deus Zeus.", false),
            new Alt("Durante a realização dos jogos, todas as guerras entre cidades gregas eram suspensas em trégua sagrada.", false),
            new Alt("Os atletas competiam usando patins elétricos e capacetes espaciais com luz neon.", true)
        }));
        l3.Add(new Q("A Coroa de Louros", new Alt[] {
            new Alt("Era o prêmio supremo dado aos grandes campeões esportivos na Grécia e generais vitoriosos em Roma.", false),
            new Alt("Simbolizava honra, glória eterna e respeito de todo o povo pelo vencedor.", false),
            new Alt("Era um chapéu de palhaça usado apenas para fazer o imperador rir no almoço.", true)
        }));
        l3.Add(new Q("A Cidade-Estado de Atenas", new Alt[] {
            new Alt("Ficou famosa mundialmente como o berço da filosofia, do teatro e da democracia antiga.", false),
            new Alt("Sua deusa protetora era Atena, a deusa da sabedoria e da estratégia de guerra.", false),
            new Alt("Foi construída dentro de um submarino nuclear no fundo do Oceano Atlântico.", true)
        }));
        l3.Add(new Q("A Cidade de Esparta", new Alt[] {
            new Alt("Era famosa por sua rígida disciplina militar onde meninos treinavam como soldados desde os 7 anos.", false),
            new Alt("Os guerreiros espartanos eram conhecidos por sua coragem e por seus pesados escudos de bronze.", false),
            new Alt("Proibia qualquer tipo de exercício físico e obrigava os soldados a dormir o dia todo.", true)
        }));
        l3.Add(new Q("A Batalha das Termópilas", new Alt[] {
            new Alt("O rei espartano Leônidas e seus trezentos soldados lendários lutaram bravamente contra um exército persa gigante.", false),
            new Alt("A batalha aconteceu em um desfiladeiro estreito entre montanhas rochosas e o mar.", false),
            new Alt("Foi uma partida amigável de videogame jogada em aparelhos portáteis com fone de ouvido.", true)
        }));
        l3.Add(new Q("O Partenon de Atenas", new Alt[] {
            new Alt("É um templo clássico magnífico de mármore construído no alto da Acrópole de Atenas.", false),
            new Alt("Dedicado à deusa Atena, possuía colunas dóricas perfeitamente alinhadas pelos arquitetos.", false),
            new Alt("Foi feito inteiramente de plástico descartável para servir de parque de pula-pula.", true)
        }));
        l3.Add(new Q("O Deus Zeus", new Alt[] {
            new Alt("Na mitologia grega, era considerado o rei dos deuses e senhor dos céus e dos trovões.", false),
            new Alt("Vivia com os principais deuses no cume místico do lendário Monte Olimpo.", false),
            new Alt("Era um pequeno hamster falante que vivia em uma gaiola de madeira em Esparta.", true)
        }));
        l3.Add(new Q("Poseidon e os Mares", new Alt[] {
            new Alt("Era o poderoso deus grego dos mares, dos cavalos e dos terremotos devastadores.", false),
            new Alt("Carregava sempre consigo um grande tridente mágico com o qual agitava as ondas marinhas.", false),
            new Alt("Tinha pavor de água salgada e só viajava pelo céu pendurado em balões coloridos.", true)
        }));
        l3.Add(new Q("Hércules (Héracles)", new Alt[] {
            new Alt("Era um herói mítico grego famoso por sua força monumental e coragem incomparável.", false),
            new Alt("Ficou célebre por cumprir com sucesso os Doze Trabalhos, enfrentando feras como o Leão de Nemeia.", false),
            new Alt("Era um mago que transformava seus inimigos em doces de abóbora usando uma varinha.", true)
        }));
        l3.Add(new Q("O Cavalo de Troia", new Alt[] {
            new Alt("Foi uma gigantesca armação de madeira usada pelos gregos para invadir a cidade fortificada de Troia.", false),
            new Alt("Soldados gregos ficaram escondidos na barriga oca do cavalo fingindo ser um presente de paz.", false),
            new Alt("Era um cavalo mecânico voador a jato movido por painéis solares espaciais.", true)
        }));
        l3.Add(new Q("O Filósofo Sócrates", new Alt[] {
            new Alt("Foi um dos maiores pensadores da Grécia Antiga, famoso por ensinar fazendo perguntas profundas.", false),
            new Alt("Caminhava pelas praças de Atenas conversando com os cidadãos e debatendo sobre a virtude.", false),
            new Alt("Foi o inventor do primeiro telefone celular com câmera digital do mundo.", true)
        }));
        l3.Add(new Q("O Coliseu de Roma", new Alt[] {
            new Alt("É um gigantesco anfiteatro oval de pedra inaugurado no coração de Roma pelo imperador Tito.", false),
            new Alt("Tinha capacidade para mais de cinquenta mil espectadores e recebia lutas de gladiadores e eventos.", false),
            new Alt("Era uma fábrica subterrânea de queijo minas frescal operada por robôs a vapor.", true)
        }));
        l3.Add(new Q("Os Gladiadores Romanos", new Alt[] {
            new Alt("Eram lutadores treinados que combatiam em arenas públicas usando espadas, tridentes e redes.", false),
            new Alt("Muitos eram escravos ou prisioneiros de guerra que buscavam ganhar fama e a liberdade (o rudiário).", false),
            new Alt("Lutavam atirando tortas de chantilly e buquês de flores uns nos outros para ganhar pontos.", true)
        }));
        l3.Add(new Q("Os Aquedutos Romanos", new Alt[] {
            new Alt("Eram impressionantes pontes de arcos de pedra que transportavam água fresca por quilômetros até as cidades.", false),
            new Alt("Usavam apenas a força da gravidade com uma leve inclinação contínua para fazer a água correr.", false),
            new Alt("Funcionavam bombeando refrigerante gasoso com bombas elétricas a motor diesel.", true)
        }));
        l3.Add(new Q("As Termas Romanas", new Alt[] {
            new Alt("Eram grandes banhos públicos aquecidos onde os romanos cuidavam da higiene e conversavam.", false),
            new Alt("Possuíam piscinas de água fria (frigidarium), morna (tepidarium) e quente (caldarium).", false),
            new Alt("Eram pistas de corrida onde os senadores disputavam ralis com carrinhos de rolimã.", true)
        }));
        l3.Add(new Q("Júlio César", new Alt[] {
            new Alt("Foi um brilhante general e estadista romano que conquistou a Gália e expandiu os domínios de Roma.", false),
            new Alt("Tornou-se ditador perpétuo de Roma antes de ser assassinado no Senado nos Idos de Março.", false),
            new Alt("Foi o primeiro astronauta a pisar na superfície do planeta Marte no ano 44 a.C.", true)
        }));
        l3.Add(new Q("O Imperador Augusto", new Alt[] {
            new Alt("Nascido Otávio, tornou-se o primeiro imperador da história do Império Romano.", false),
            new Alt("Inaugurou um longo período de paz e estabilidade conhecido como a 'Pax Romana'.", false),
            new Alt("Governava o império sentado no teto de um trem elétrico que andava pela Itália.", true)
        }));
        l3.Add(new Q("As Estradas Romanas", new Alt[] {
            new Alt("Roma construiu mais de oitenta mil quilômetros de estradas calçadas interligando todo o império.", false),
            new Alt("Permitiam que tropas marchassem rapidamente e mensageiros levassem correspondências com agilidade.", false),
            new Alt("Eram feitas de gelo escorregadio e os soldados viajavam montados em pinguins.", true)
        }));
        l3.Add(new Q("A Legião Romana", new Alt[] {
            new Alt("Era a principal divisão do poderoso exército romano, formada por milhares de soldados legionários disciplinados.", false),
            new Alt("Usavam a famosa couraça articulada (lorica segmentata), escudo retangular curvo (scutum) e dardo (pilum).", false),
            new Alt("Marchavam para o combate vestidos com pijamas listrados e descalços na lama.", true)
        }));
        l3.Add(new Q("A Formação Tartaruga (Testudo)", new Alt[] {
            new Alt("Era uma formação militar romana genial onde os legionários uniam seus escudos na frente e acima das cabeças.", false),
            new Alt("Protegia os soldados contra uma chuva de flechas e pedras arremessadas do alto de muralhas.", false),
            new Alt("Consistia em todos os soldados imitarem o som de tartarugas marinhas para assustar cavalos.", true)
        }));
        l3.Add(new Q("A Cidade de Pompeia", new Alt[] {
            new Alt("Era uma próspera cidade romana que foi subitamente soterrada pelas cinzas do vulcão Vesúvio em 79 d.C.", false),
            new Alt("As cinzas vulcânicas preservaram casas, afrescos, padarias e até alimentos por quase dois mil anos.", false),
            new Alt("Foi destruída pelo ataque de monstros gigantescos que saíram do centro da Terra.", true)
        }));
        l3.Add(new Q("O Circo Máximo de Roma", new Alt[] {
            new Alt("Era uma arena gigantesca projetada para as emocionantes corridas de bigas (carruagens puxadas por cavalos).", false),
            new Alt("Podia receber mais de cento e cinquenta mil torcedores animados nas arquibancadas.", false),
            new Alt("Era um picadeiro de palhaços onde equilibristas voavam amarrados em pipas de papel.", true)
        }));
        l3.Add(new Q("O Panteão de Roma", new Alt[] {
            new Alt("É um dos edifícios da Roma Antiga mais bem preservados do mundo, com uma cúpula de concreto colossal.", false),
            new Alt("Possui uma abertura circular no topo da cúpula chamada óculo que ilumina todo o interior com o sol.", false),
            new Alt("Foi erguido com blocos de isopor prensado colados com fita adesiva transparente.", true)
        }));
        l3.Add(new Q("A Loba Capitolina e a Fundação de Roma", new Alt[] {
            new Alt("Segundo a lenda mitológica romana, os irmãos gêmeos Rômulo e Remo foram amamentados por uma loba carinhosa.", false),
            new Alt("Rômulo teria traçado os primeiros limites da cidade de Roma no alto do monte Palatino.", false),
            new Alt("Roma foi fundada por um grupo de dinossauros que fugiram de um meteoro no espaço.", true)
        }));
        l3.Add(new Q("O Senado Romano", new Alt[] {
            new Alt("Era uma assembleia de líderes patrícios veteranos que debatia leis, finanças e relações com outros povos.", false),
            new Alt("Os senadores vestiam togas brancas com faixas púrpuras para demonstrar sua autoridade e respeito.", false),
            new Alt("Era formado apenas por crianças de três anos que decidiam o destino do império com desenhos.", true)
        }));
        l3.Add(new Q("A Língua Latina (Latim)", new Alt[] {
            new Alt("Era o idioma oficial falado pelos romanos antigos na península itálica e em todo o império.", false),
            new Alt("Deu origem às chamadas línguas românicas modernas, como o português, espanhol, francês e italiano.", false),
            new Alt("Era uma língua em que as pessoas só se comunicavam imitando o latido de cachorros bravos.", true)
        }));
        l3.Add(new Q("Os Algarismos Romanos", new Alt[] {
            new Alt("É um sistema de numeração que utiliza letras do alfabeto latino como I, V, X, L, C, D e M.", false),
            new Alt("Ainda hoje são usados em relógios clássicos, capítulos de livros e nomes de papas e reis.", false),
            new Alt("Foram inventados por computadores modernos no ano de 2010 para jogos digitais.", true)
        }));
        l3.Add(new Q("O Fórum Romano", new Alt[] {
            new Alt("Era o coração político, comercial e religioso da Roma Antiga, cercado por templos e basílicas.", false),
            new Alt("Nele aconteciam eleições, discursos públicos memoráveis e procissões triunfais de generais.", false),
            new Alt("Era um parque aquático exclusivo onde os imperadores nadavam com jacarés domesticados.", true)
        }));
        l3.Add(new Q("O Deus Marte", new Alt[] {
            new Alt("Na mitologia romana, era o deus da guerra e o guardião da agricultura do povo romano.", false),
            new Alt("O quarto planeta do Sistema Solar, de cor avermelhada, recebeu o seu nome em sua homenagem.", false),
            new Alt("Era um cozinheiro grego famoso por inventar o pudim de leite condensado.", true)
        }));
        l3.Add(new Q("A Deusa Vênus", new Alt[] {
            new Alt("Na mitologia romana, era a deusa do amor e da beleza, equivalente à Afrodite dos gregos.", false),
            new Alt("O segundo planeta a partir do Sol, o mais brilhante no céu noturno, foi batizado com seu nome.", false),
            new Alt("Era a deusa das máquinas de lavar roupa e das ferramentas de encanamento.", true)
        }));
        l3.Add(new Q("O Poeta Homero", new Alt[] {
            new Alt("Foi o autor atribuído de duas das maiores epopeias da literatura ocidental antiga: a Ilíada e a Odisseia.", false),
            new Alt("Suas histórias contavam a Guerra de Troia e a longa e perigosa viagem de retorno do herói Odisseu.", false),
            new Alt("Era um piloto de corrida que dirigia caminhões em pistas de motocross na Grécia.", true)
        }));
        l3.Add(new Q("O Cavalo de Alexandre, o Grande (Bucéfalo)", new Alt[] {
            new Alt("Bucéfalo era o lendário e feroz corcel negro domado pelo jovem príncipe Alexandre da Macedônia.", false),
            new Alt("Alexandre percebeu que o cavalo só tinha medo da própria sombra e virou sua cabeça para o Sol para acalmá-lo.", false),
            new Alt("Bucéfalo tinha rodinhas no lugar das patas e usava um sino de bicicleta no focinho.", true)
        }));
        l3.Add(new Q("Alexandre, o Grande", new Alt[] {
            new Alt("Tornou-se rei da Macedônia aos vinte anos e criou um dos maiores impérios do mundo antigo, até a Índia.", false),
            new Alt("Fundou mais de setenta cidades com seu nome, sendo a mais famosa Alexandria no litoral do Egito.", false),
            new Alt("Nunca saiu de seu quarto e passou a vida inteira jogando damas contra o próprio espelho.", true)
        }));
        l3.Add(new Q("A Biblioteca de Alexandria", new Alt[] {
            new Alt("Foi uma das maiores e mais famosas bibliotecas da Antiguidade, reunindo rolos de papiro do mundo conhecido.", false),
            new Alt("Atraía sábios, matemáticos e astrônomos de várias regiões para estudar ciências e literatura.", false),
            new Alt("Não tinha livros nem papiros, guardando apenas sacos de batatas e cebolas para o inverno.", true)
        }));
        l3.Add(new Q("O Matemático Arquimedes", new Alt[] {
            new Alt("Foi um brilhante cientista grego que descobriu o princípio do empuxo na água e inventou o parafuso de rosca.", false),
            new Alt("Ficou célebre pela exclamação 'Eureka!' ('descobri!' em grego) ao notar o nível da água subir na banheira.", false),
            new Alt("Inventou o telefone inteligente sem fio enquanto assistia televisão no sofá.", true)
        }));
        l3.Add(new Q("O Faraó Cleópatra", new Alt[] {
            new Alt("Foi a última governante ativa do Reino Ptolemaico no Egito antes de se tornar província romana.", false),
            new Alt("Era uma diplomata culta, poliglota talentosa e aliou-se a líderes romanos como César e Marco Antônio.", false),
            new Alt("Vivia no topo de uma árvore na floresta amazônica comendo bananas silvestres.", true)
        }));
        l3.Add(new Q("O Mito de Dédalo e Ícaro", new Alt[] {
            new Alt("Dédalo construiu asas com penas de aves presas com cera de abelha para escapar com seu filho da ilha de Creta.", false),
            new Alt("Ícaro desobedeceu ao pai, voou muito perto do calor do Sol, a cera derreteu e ele caiu no mar.", false),
            new Alt("Voaram usando um helicóptero a controle remoto comprado pela internet em uma promoção.", true)
        }));
        l3.Add(new Q("O Mito da Medusa", new Alt[] {
            new Alt("Na mitologia grega, era uma criatura com serpentes vivas no lugar dos cabelos.", false),
            new Alt("Qualquer pessoa que olhasse diretamente nos seus olhos se transformava imediatamente em estátua de pedra.", false),
            new Alt("Transformava as pessoas em sorvete de casquinha e torta de chocolate ao piscar os olhos.", true)
        }));
        l3.Add(new Q("A Toga Romana", new Alt[] {
            new Alt("Era uma longa vestimenta de lã branca envolta sobre o corpo, usada por cidadãos livres de Roma.", false),
            new Alt("Servia como símbolo oficial de status, dignidade e cidadania nos eventos públicos da República e Império.", false),
            new Alt("Era um casaco impermeável feito de borracha sintética com capuz de astronauta.", true)
        }));
        l3.Add(new Q("O Mosaico Romano", new Alt[] {
            new Alt("Eram impressionantes obras de arte no piso e nas paredes feitas com milhares de pequenas pedrinhas coloridas (tesselas).", false),
            new Alt("Retratavam animais, deuses mitológicos, cenas de caça e banquetes com rica riqueza de detalhes.", false),
            new Alt("Eram feitos de doces mastigáveis que os moradores arrancavam para comer de sobremesa.", true)
        }));
        l3.Add(new Q("O Deus Apolo", new Alt[] {
            new Alt("Era o deus grego e romano associado ao Sol, à música, à poesia, à luz e à medicina.", false),
            new Alt("Costumava ser retratado segurando uma lira de ouro, tocando belas melodias para os outros deuses.", false),
            new Alt("Era um boneco de neve que só conseguia viver dentro de freezers de sorvete.", true)
        }));
        l3.Add(new Q("O Deus Hermes (Mercúrio)", new Alt[] {
            new Alt("Era o veloz mensageiro dos deuses, protetor dos viajantes, dos comerciantes e dos atletas.", false),
            new Alt("Usava sandálias aladas douradas e um capacete com pequenas asas para voar rapidamente entre os mundos.", false),
            new Alt("Andava de patinete com motor a gasolina buzinando pelos corredores do céu.", true)
        }));
        l3.Add(new Q("A Esfinge de Tebas na Grécia", new Alt[] {
            new Alt("Na lenda grega de Édipo, era um monstro com corpo de leão e asas que bloqueava o caminho com enigmas.", false),
            new Alt("Perguntava: 'Qual animal anda de manhã com quatro patas, à tarde com duas e à noite com três?' (o ser humano).", false),
            new Alt("Pedia para os viajantes cantarem o hino do Flamengo para poderem atravessar a ponte.", true)
        }));
        l3.Add(new Q("O Deus Dionísio (Baco)", new Alt[] {
            new Alt("Era o deus grego da alegria, do teatro, da celebração e das plantações de uvas e parreiras.", false),
            new Alt("Foi em suas festividades teatrais que surgiram os primeiros atores e as tragédias e comédias clássicas.", false),
            new Alt("Era o deus dos robôs cibernéticos e das pilhas alcalinas descartáveis.", true)
        }));
        l3.Add(new Q("A Muralha de Adriano", new Alt[] {
            new Alt("Foi uma enorme fortificação de pedra construída pelo imperador romano Adriano no norte da Britânia (atual Reino Unido).", false),
            new Alt("Marcava o limite da fronteira noroeste do Império Romano contra invasões de tribos do norte.", false),
            new Alt("Foi erguida para impedir que dragões voadores roubassem as maçãs dos pomares romanos.", true)
        }));
        l3.Add(new Q("O Rio Tibre", new Alt[] {
            new Alt("É o histórico rio que atravessa a cidade de Roma, fundamental para o surgimento da civilização romana.", false),
            new Alt("Suas águas permitiam o transporte de mercadorias até o porto de Óstia, no Mar Tirreno.", false),
            new Alt("Era um rio feito inteiramente de azeite de oliva fervente onde ninguém conseguia navegar.", true)
        }));
        l3.Add(new Q("Os Centuriões Romanos", new Alt[] {
            new Alt("Eram oficiais de comando experientes e temidos no exército romano, responsáveis por liderar cem homens (uma centúria).", false),
            new Alt("Usavam uma crista de plumas ou crina de cavalo transversal no capacete para serem identificados na batalha.", false),
            new Alt("Comandavam as tropas de dentro de um tanque blindado com ar condicionado ligado.", true)
        }));
        l3.Add(new Q("O Veto dos Tribunos da Plebe", new Alt[] {
            new Alt("Em Roma, os tribunos da plebe tinham o poder extraordinário de gritar 'Veto!' ('eu proíbo!') contra leis injustas.", false),
            new Alt("Essa palavra em latim passou para os governos modernos para indicar a recusa de uma lei pelo presidente.", false),
            new Alt("Significava 'vamos todos almoçar agora' e encerrava as votações para comer pizza.", true)
        }));
        l3.Add(new Q("O Farol de Alexandria", new Alt[] {
            new Alt("Foi uma das Sete Maravilhas do Mundo Antigo, erguido na ilha de Faros para guiar navegadores até o porto.", false),
            new Alt("Utilizava um enorme espelho e uma fogueira no alto de uma torre de mais de cem metros de altura.", false),
            new Alt("Era uma lâmpada fluorescente ligada na tomada de um poste de madeira na calçada.", true)
        }));
        l3.Add(new Q("O Fim do Império Romano do Ocidente", new Alt[] {
            new Alt("Em 476 d.C., o último imperador de Roma (Rômulo Augusto) foi deposto, marcando o início da Idade Média.", false),
            new Alt("O império foi enfraquecido por crises econômicas internas e pela chegada de povos germânicos nas fronteiras.", false),
            new Alt("O império acabou porque todos os cidadãos romanos decidiram morar na Antártida em 1900.", true)
        }));

        // ==========================================
        // NIVEL 4: IDADE MÉDIA E CAVALEIROS (50 Questões)
        // ==========================================
        var l4 = levels[4];
        l4.Add(new Q("Os Castelos Medievais", new Alt[] {
            new Alt("Eram imponentes fortalezas de pedra construídas para proteger reis, nobres e camponeses em tempos de cerco.", false),
            new Alt("Possuíam torres de vigia altas, muralhas grossas e frestas estreitas para atirar flechas.", false),
            new Alt("Eram feitos de castelos de areia que desmanchavam quando caía uma garoa fina.", true)
        }));
        l4.Add(new Q("O Fosso do Castelo", new Alt[] {
            new Alt("Era uma vala profunda e larga cavada ao redor do castelo, frequentemente cheia de água.", false),
            new Alt("Dificultava a aproximação de escadas, torres de cerco e soldados inimigos até a base das muralhas.", false),
            new Alt("Era uma banheira de hidromassagem usada pelos reis para relaxar ouvindo música eletrônica.", true)
        }));
        l4.Add(new Q("A Ponte Levadiça", new Alt[] {
            new Alt("Era uma ponte móvel de madeira pesada sustentada por correntes de ferro na entrada principal do castelo.", false),
            new Alt("Podia ser rapidamente erguida de dentro da fortaleza para impedir a passagem de invasores sobre o fosso.", false),
            new Alt("Era feita de fatias de queijo prensado que eram comidas pelos soldados na hora do almoço.", true)
        }));
        l4.Add(new Q("A Torre de Menagem (Keep)", new Alt[] {
            new Alt("Era a torre central mais forte e mais alta de todo o castelo medieval, último refúgio dos defensores.", false),
            new Alt("Nela costumavam ficar os aposentos nobres, o depósito de provisões e armas de emergência.", false),
            new Alt("Era uma torre inflável de aniversário montada apenas nos fins de semana.", true)
        }));
        l4.Add(new Q("As Armaduras dos Cavaleiros", new Alt[] {
            new Alt("Eram feitas de placas de aço forjadas sob medida para proteger o cavaleiro de cortes e flechadas.", false),
            new Alt("Apesar de pesadas (cerca de 20 a 25 kg), eram articuladas permitindo ao guerreiro montar a cavalo.", false),
            new Alt("Eram feitas de folhas de papel machê e derretiam na primeira gota de chuva.", true)
        }));
        l4.Add(new Q("A Espada Longa Medieval", new Alt[] {
            new Alt("Era uma arma afiada forjada por ferreiros habilidosos que exigia grande técnica e equilíbrio para ser empunhada.", false),
            new Alt("Muitos cavaleiros davam nomes especiais às suas espadas queridas como símbolo de honra.", false),
            new Alt("Era uma espada de raio laser que emitia luz verde e zumbia no espaço sideral.", true)
        }));
        l4.Add(new Q("O Código de Cavalaria", new Alt[] {
            new Alt("Era um conjunto de regras de conduta moral que ensinava o cavaleiro a ser leal, corajoso e proteger os fracos.", false),
            new Alt("Exigia respeito às damas nobres, honra nas promessas feitas e bravura sem trapaças no campo de batalha.", false),
            new Alt("Ensinava que os cavaleiros deviam fugir correndo e chorando diante de qualquer perigo.", true)
        }));
        l4.Add(new Q("Os Torneios Medievais", new Alt[] {
            new Alt("Eram grandes festivais festivos onde cavaleiros exibiam sua perícia em justas com lanças e duelos amigáveis.", false),
            new Alt("Serviam como treino vigoroso para a guerra e como entretenimento popular com banquetes e menestréis.", false),
            new Alt("Eram campeonatos de futebol de botão disputados por reis dentro de bibliotecas silenciosas.", true)
        }));
        l4.Add(new Q("A Justa Medieval", new Alt[] {
            new Alt("Era a prova mais famosa do torneio, onde dois cavaleiros a cavalo avançavam com longas lanças de madeira.", false),
            new Alt("O objetivo principal era quebrar a lança no escudo do oponente ou desmontá-lo com técnica e impacto.", false),
            new Alt("Os cavaleiros disputavam a corrida montados em avestruzes usando pistolas de água.", true)
        }));
        l4.Add(new Q("A Cerimônia de Investidura", new Alt[] {
            new Alt("Era o ritual solene em que um jovem escudeiro era consagrado formalmente como cavaleiro.", false),
            new Alt("O senhor feudal tocava a lâmina espalmada de uma espada nos ombros do jovem ajoelhado.", false),
            new Alt("O jovem levava uma tortada de morango no nariz e saía correndo pelo pátio.", true)
        }));
        l4.Add(new Q("Os Escudeiros", new Alt[] {
            new Alt("Eram jovens aprendizes nobres que cuidavam das armas, do cavalo e da armadura de um cavaleiro experiente.", false),
            new Alt("Aprendiam esgrima, montaria, caça e boas maneiras até estarem prontos para serem armados cavaleiros.", false),
            new Alt("Eram pequenos cachorrinhos amestrados que andavam nas costas dos cavalos.", true)
        }));
        l4.Add(new Q("A Cota de Malha", new Alt[] {
            new Alt("Era uma armadura flexível tecida com milhares de pequenos anéis de ferro entrelaçados e rebitados.", false),
            new Alt("Oferecia excelente proteção contra golpes cortantes de espadas antes da armadura de placas completa.", false),
            new Alt("Era uma camisa de seda fina estampada com flores havaianas para ir à praia.", true)
        }));
        l4.Add(new Q("Os Arqueiros Medievais", new Alt[] {
            new Alt("Eram temidos nos campos de batalha por disparar flechas mortais a centenas de metros de distância.", false),
            new Alt("O arco longo inglês (longbow) era tão potente que podia perfurar cotas de malha e armaduras inimigas.", false),
            new Alt("Atiravam balões de chiclete mascado que grudavam na roupa dos soldados.", true)
        }));
        l4.Add(new Q("A Besta (Balestra)", new Alt[] {
            new Alt("Era uma arma mecânica potente com um arco montado sobre uma coronha de madeira que disparava virotes pesados.", false),
            new Alt("Disparava projéteis com enorme força de impacto e exigia menos treino muscular prolongado que o arco longo.", false),
            new Alt("Era um tipo de vassoura mágica usada pelos magos para voar sobre as nuvens.", true)
        }));
        l4.Add(new Q("A Catapulta e o Trabuco (Trebuchet)", new Alt[] {
            new Alt("Eram engenhosas máquinas de cerco gigantes que arremessavam enormes pedras contra as muralhas dos castelos.", false),
            new Alt("O trabuco usava o princípio da alavanca com um pesado contrapeso para lançar pedras a longas distâncias.", false),
            new Alt("Eram ventiladores gigantescos que sopravam ar fresco para refrescar os guerreiros no verão.", true)
        }));
        l4.Add(new Q("O Aríete de Cerco", new Alt[] {
            new Alt("Era um tronco de madeira maciço e reforçado com cabeça de ferro suspenso por cordas sob um teto protetor.", false),
            new Alt("Soldados balançavam o tronco repetidamente contra portões fortificados de castelos para arrombá-los.", false),
            new Alt("Era uma almofada de plumas macia usada para bater delicadamente nas portas pedindo licença.", true)
        }));
        l4.Add(new Q("Os Camponeses (Servos da Gleba)", new Alt[] {
            new Alt("Trabalhavam no campo de sol a sol plantando trigo, cevada e cuidando dos animais nos feudos.", false),
            new Alt("Entregavam parte de suas colheitas ao senhor feudal em troca de proteção militar em tempos de ataque.", false),
            new Alt("Viviam em luxuosos palácios de cristal com mordomos e carros elétricos próprios.", true)
        }));
        l4.Add(new Q("Os Ferreiros Medievais", new Alt[] {
            new Alt("Eram artesãos respeitados que aqueciam ferro na forja em brasa e martelavam na bigorna para moldar ferramentas e armas.", false),
            new Alt("Produziam desde ferraduras para cavalos e arados agrícolas até espadas afiadas e pontas de flecha.", false),
            new Alt("Moldavam roupas de lã usando agulhas de tricô de plástico na praça do castelo.", true)
        }));
        l4.Add(new Q("Os Menestréis e Trovadores", new Alt[] {
            new Alt("Eram músicos e poetas viajantes que iam de castelo em castelo cantando canções de amor, honra e aventuras.", false),
            new Alt("Tocavam alaúdes, flautas e harpas, animando banquetes reais e espalhando novidades pelo reino.", false),
            new Alt("Eram robôs cantores que funcionavam com pilhas e tocavam músicas em caixas de som bluetooth.", true)
        }));
        l4.Add(new Q("Os Monges Copistas", new Alt[] {
            new Alt("Viviam em mosteiros e passavam anos copiando à mão antigos manuscritos em pergaminho para preservar o saber.", false),
            new Alt("Decoravam as páginas com letras capitulares ornamentadas e desenhos de ouro chamados iluminuras.", false),
            new Alt("Imprimiam três mil livros por minuto usando impressoras a laser modernas coloridas.", true)
        }));
        l4.Add(new Q("O Pergaminho Medieval", new Alt[] {
            new Alt("Era o material de escrita mais nobre da época, feito a partir de peles tratadas de carneiro, cabra ou bezerro.", false),
            new Alt("Era resistente e duradouro, permitindo que livros e registros históricos sobrevivessem por séculos.", false),
            new Alt("Era uma tela digital sensível ao toque que recarregava a bateria ao sol.", true)
        }));
        l4.Add(new Q("As Iluminuras Medievais", new Alt[] {
            new Alt("Eram pinturas e ilustrações minuciosas feitas à mão nas margens e inícios de capítulos de livros manuscritos.", false),
            new Alt("Usavam tintas minerais coloridas e finíssimas folhas de ouro batido para fazer as páginas brilharem.", false),
            new Alt("Eram rabiscos feitos com giz de cera por crianças no fundo das salas de aula.", true)
        }));
        l4.Add(new Q("As Catedrais Góticas", new Alt[] {
            new Alt("Eram grandiosas igrejas de pedra caracterizadas por arcos ogivais pontiagudos, torres altíssimas e arcobotantes.", false),
            new Alt("Possuíam imensos vitrais coloridos que iluminavam o interior com feixes de luz mágica.", false),
            new Alt("Eram feitas de blocos de gelo do Polo Norte e precisavam ser reconstruídas a cada verão.", true)
        }));
        l4.Add(new Q("Os Vitrais Medievais", new Alt[] {
            new Alt("Eram janelas artísticas feitas com pedaços de vidro colorido unidos por tiras finas de chumbo.", false),
            new Alt("Contavam histórias bíblicas através de imagens para a população que, na maioria, não sabia ler.", false),
            new Alt("Eram espelhos planos normais onde os fiéis penteavam o cabelo antes da missa.", true)
        }));
        l4.Add(new Q("As Gárgulas", new Alt[] {
            new Alt("Eram esculturas de criaturas monstruosas ou mitológicas de pedra colocadas no alto de igrejas e castelos.", false),
            new Alt("Sua função prática era servir de calha para escoar a água da chuva longe das paredes do edifício.", false),
            new Alt("Eram estátuas vivas de verdade que comiam pombos e conversavam com os pedestres.", true)
        }));
        l4.Add(new Q("O Rei Artur e a Távola Redonda", new Alt[] {
            new Alt("É a famosa lenda medieval do rei nobre da Bretanha e seus leais cavaleiros em busca do Santo Graal.", false),
            new Alt("A mesa era redonda para que nenhum cavaleiro se sentasse na ponta, simbolizando igualdade entre eles.", false),
            new Alt("O rei Artur viajava pelo reino pilotando uma motocicleta com buzina estridente.", true)
        }));
        l4.Add(new Q("A Espada Excalibur", new Alt[] {
            new Alt("Na lenda arturiana, era a espada mística que só o legítimo rei da Inglaterra conseguiria retirar de uma pedra mágica.", false),
            new Alt("Dizia-se que sua lâmina brilhava intensamente e sua bainha protegia o portador contra sangramentos.", false),
            new Alt("Foi comprada pelo rei em um supermercado por cinco reais em uma liquidação.", true)
        }));
        l4.Add(new Q("O Mago Merlin", new Alt[] {
            new Alt("É o lendário conselheiro sábio e feiticeiro do rei Artur nas lendas da corte de Camelot.", false),
            new Alt("Muitas histórias contavam que ele conhecia os segredos da natureza, previa o futuro e compreendia as estrelas.", false),
            new Alt("Era um técnico de informática que consertava roteadores de internet no castelo.", true)
        }));
        l4.Add(new Q("Joana d'Arc", new Alt[] {
            new Alt("Foi uma jovem camponesa francesa heroica que liderou exércitos na Guerra dos Cem Anos contra a Inglaterra.", false),
            new Alt("Dizia ouvir vozes santas e inspirou as tropas francesas a libertar a cidade cercada de Orleans.", false),
            new Alt("Era uma pirata caribenha que navegava em galeões em busca de tesouros de ouro espanhóis.", true)
        }));
        l4.Add(new Q("A Guerra dos Cem Anos", new Alt[] {
            new Alt("Foi um longo conflito histórico que durou mais de um século entre os reinos da Inglaterra e da França.", false),
            new Alt("Ficou marcada por famosas batalhas campais como Crécy, Agincourt e pela bravura de Joana d'Arc.", false),
            new Alt("Durou apenas quinze minutos e foi resolvida com uma partida de cara ou coroa entre reis.", true)
        }));
        l4.Add(new Q("Os Falcoeiros Medievais", new Alt[] {
            new Alt("Praticavam a falcoaria, a nobre arte milenar de treinar aves de rapina (como falcões e gaviões) para a caça.", false),
            new Alt("As aves usavam caparões de couro nos olhos para ficarem calmas até o momento do voo de perseguição.", false),
            new Alt("Ensinavam os falcões a voar no céu segurando placas de trânsito para orientar cavalos.", true)
        }));
        l4.Add(new Q("O Banquete Medieval", new Alt[] {
            new Alt("Eram festas nababescas no salão principal do castelo onde se serviam carnes assadas, pães e tortas variadas.", false),
            new Alt("Na época as pessoas costumavam comer com as mãos e pequenas facas, antes da popularização do garfo de mesa.", false),
            new Alt("Todos os convidados sentavam no chão e comiam apenas hambúrguer congelado de micro-ondas.", true)
        }));
        l4.Add(new Q("O Arauto Medieval", new Alt[] {
            new Alt("Era o oficial encarregado de proclamar anúncios reais importantes pelas ruas ao som de toques de trombeta.", false),
            new Alt("Também conhecia a heráldica, identificando as famílias nobres pelos brasões e escudos de armas.", false),
            new Alt("Transmitia os comunicados enviando mensagens de texto pelo aplicativo do celular.", true)
        }));
        l4.Add(new Q("Os Brasões de Família (Heráldica)", new Alt[] {
            new Alt("Eram desenhos e símbolos únicos gravados em escudos e estandartes para identificar cavaleiros cobertos por armaduras.", false),
            new Alt("Usavam animais heráldicos como leões, águias e dragões para simbolizar bravura e linhagem.", false),
            new Alt("Eram códigos de barras eletrônicos lidos por scanners na porta dos castelos.", true)
        }));
        l4.Add(new Q("Os Samurais no Japão Medieval", new Alt[] {
            new Alt("Eram os guerreiros nobres e disciplinados do Japão antigo, mestres no combate com a afiada espada katana.", false),
            new Alt("Seguiam um rigoroso código moral de conduta, lealdade e honra incondicional chamado Bushido.", false),
            new Alt("Eram piratas ingleses que usavam perucas brancas e navegavam pelo Mar do Caribe.", true)
        }));
        l4.Add(new Q("A Espada Katana", new Alt[] {
            new Alt("Era a espada lendária dos samurais japoneses, forjada com lâmina curva de um único fio e precisão letal.", false),
            new Alt("O processo de forja envolvia dobrar e bater o aço centenas de vezes para garantir dureza e flexibilidade.", false),
            new Alt("Era feita de plástico flexível de brinquedo que apitava quando batia em alguém.", true)
        }));
        l4.Add(new Q("A Armadura Samurai", new Alt[] {
            new Alt("Era composta por pequenas placas de metal laqueadas unidas por cordões de seda colorida, muito leve e móvel.", false),
            new Alt("Incluía um impressionante capacete (kabuto) com máscaras faciais ferozes desenhadas para intimidar oponentes.", false),
            new Alt("Era feita de papelão ondulado impermeabilizado com fita crepe amarela.", true)
        }));
        l4.Add(new Q("O Shogun", new Alt[] {
            new Alt("Era o comandante militar supremo que exercia o verdadeiro poder político no Japão feudal por séculos.", false),
            new Alt("Governava o país em nome do imperador, mantendo o controle sobre os senhores de terras chamados daimiôs.", false),
            new Alt("Era o nome dado aos barcos a vela que pescavam camarão na costa australiana.", true)
        }));
        l4.Add(new Q("Os Castelos Japoneses", new Alt[] {
            new Alt("Possuíam imponentes bases inclinadas de pedra maciça encaixada e múltiplos telhados curvos de madeira e gesso branco.", false),
            new Alt("O famoso Castelo de Himeji é conhecido carinhosamente como o 'Castelo da Garça Branca' por sua beleza estonteante.", false),
            new Alt("Eram submarinos que navegavam submersos pelos rios de Tóquio protegendo pescadores.", true)
        }));
        l4.Add(new Q("Os Vikings", new Alt[] {
            new Alt("Eram bravos navegadores e guerreiros nórdicos da Escandinávia famosos por suas longas viagens marítimas.", false),
            new Alt("Navegavam em rápidos barcos a vela e remos chamados drakkars (barcos-dragão) que atingiam costas rasas.", false),
            new Alt("Viajavam pelos mares usando barcos a vapor com rodas gigantes e buzinas elétricas.", true)
        }));
        l4.Add(new Q("O Mito dos Capacetes Vikings", new Alt[] {
            new Alt("Os capacetes vikings verdadeiros de ferro eram simples e cônicos, sem chifres laterais que atrapalhariam a luta.", false),
            new Alt("A ideia de capacetes com chifres foi inventada no século dezenove por desenhistas de figurinos de óperas.", false),
            new Alt("Os guerreiros vikings usavam capacetes de chifres reais de rinocerontes gigantes no combate diário.", true)
        }));
        l4.Add(new Q("Os Drakkars Vikings", new Alt[] {
            new Alt("Eram barcos compridos e esguios com fundo quase chato que podiam navegar tanto em mares bravios quanto em rios rasos.", false),
            new Alt("Muitos possuíam a proa esculpida em formato de cabeças ferozes de dragões para afastar espíritos maus.", false),
            new Alt("Eram lanchas modernas equipadas com potentes motores de popa a gasolina.", true)
        }));
        l4.Add(new Q("Leif Erikson", new Alt[] {
            new Alt("Foi um explorador nórdico corajoso que navegou até a costa do atual Canadá cerca de 500 anos antes de Cristóvão Colombo.", false),
            new Alt("Batizou as terras férteis recém-encontradas na América do Norte de Vinland (Terra das Vinhas).", false),
            new Alt("Chegou à América voando em um foguete espacial com seu cachorro de estimação.", true)
        }));
        l4.Add(new Q("A Mitologia Nórdica e Thor", new Alt[] {
            new Alt("Thor era o poderoso deus nórdico dos trovões, das tempestades e da força física.", false),
            new Alt("Empunhava o temido martelo mágico Mjolnir, que voltava sempre para a sua mão após ser arremessado.", false),
            new Alt("Lutava usando uma frigideira de teflon e viajava montado em uma tartaruga lenta.", true)
        }));
        l4.Add(new Q("O Deus Odin", new Alt[] {
            new Alt("Na mitologia nórdica, era o Pai de Todos, deus da sabedoria, da guerra e da poesia mística.", false),
            new Alt("Cavalgava um corcel mágico de oito patas chamado Sleipnir e era acompanhado por dois corvos sábios.", false),
            new Alt("Era um piloto de corrida que vendia pneus novos na porta do palácio de Valhala.", true)
        }));
        l4.Add(new Q("A Peste Negra", new Alt[] {
            new Alt("Foi uma terrível epidemia que assolou a Europa no século catorze, causada por uma bactéria transmitida por pulgas de ratos.", false),
            new Alt("Reduziu cerca de um terço da população de várias regiões europeias alterando a história econômica do continente.", false),
            new Alt("Foi provocada pelo excesso de consumo de brigadeiro de panela e achocolatado em pó.", true)
        }));
        l4.Add(new Q("Os Médicos da Peste", new Alt[] {
            new Alt("Usavam compridos casacos impermeabilizados e máscaras sinistras com bico de pássaro longo.", false),
            new Alt("O bico da máscara era preenchido com ervas aromáticas aromáticas na tentativa de filtrar o mau ar das cidades.", false),
            new Alt("Eram palhaços de circo que divertiam as pessoas cantando marchinhas nas esquinas.", true)
        }));
        l4.Add(new Q("As Cruzadas Medievais", new Alt[] {
            new Alt("Foram expedições militares convocadas por papas e reis europeus com o objetivo de tomar o controle de Jerusalém (Terra Santa).", false),
            new Alt("Promoveram intenso contato cultural, comercial e científico entre a Europa e o rico Oriente Médio.", false),
            new Alt("Eram viagens escolares de férias para parques temáticos na Disney norte-americana.", true)
        }));
        l4.Add(new Q("A Ordem dos Cavaleiros Templários", new Alt[] {
            new Alt("Era uma famosa ordem militar cristã criada para proteger os peregrinos que viajavam para Jerusalém.", false),
            new Alt("Usavam mantos brancos estampados com uma distinta cruz vermelha e criaram um pioneiro sistema financeiro.", false),
            new Alt("Eram ilusionistas que faziam mágica com baralhos em feiras e praças da Europa.", true)
        }));
        l4.Add(new Q("A Magna Carta (1215)", new Alt[] {
            new Alt("Foi um histórico documento assinado pelo rei João Sem-Terra da Inglaterra na campina de Runnymede.", false),
            new Alt("Limitou os poderes absolutistas do rei, determinando que nem o monarca estava acima das leis do país.", false),
            new Alt("Foi uma carta de amor escrita por um soldado para uma princesa da ilha de Madagascar.", true)
        }));

        // ==========================================
        // NIVEL 5: GRANDES NAVEGAÇÕES E PIRATAS (50 Questões)
        // ==========================================
        var l5 = levels[5];
        l5.Add(new Q("As Caravelas Portuguesas", new Alt[] {
            new Alt("Eram navios ágeis e leves projetados pelos portugueses para viagens de exploração no oceano.", false),
            new Alt("Possuíam velas triangulares (latinas) que permitiam navegar até mesmo contra a direção do vento (bolinar).", false),
            new Alt("Eram navios movidos a pilhas elétricas com motores submarinos a propulsão nuclear.", true)
        }));
        l5.Add(new Q("As Naus", new Alt[] {
            new Alt("Eram navios mercantes muito maiores e mais pesados que as caravelas, ideais para transportar cargas volumosas.", false),
            new Alt("Possuíam altos castelos de proa e de popa armados com canhões para defender as rotas oceânicas.", false),
            new Alt("Eram lanchas de fibra de vidro usadas exclusivamente para esportes aquáticos de verão.", true)
        }));
        l5.Add(new Q("A Bússola Magnética", new Alt[] {
            new Alt("Foi um instrumento náutico revolucionário originário da China adotado com sucesso pelos navegadores europeus.", false),
            new Alt("Sua agulha imantada aponta sempre na direção do polo magnético da Terra, guiando os rumos no mar aberto.", false),
            new Alt("Era um despertador digital que tocava uma música alegre na hora de pescar peixes.", true)
        }));
        l5.Add(new Q("O Astrolábio e o Quadrante", new Alt[] {
            new Alt("Eram instrumentos náuticos usados para medir a altura do Sol e das estrelas acima da linha do horizonte.", false),
            new Alt("Permitiam que os pilotos calculassem a latitude exata de sua embarcação no meio do imenso oceano.", false),
            new Alt("Eram óculos de mergulho usados pelos marujos para caçar lagostas a cem metros de profundidade.", true)
        }));
        l5.Add(new Q("O Comércio de Especiarias", new Alt[] {
            new Alt("Temperos raros do Oriente como canela, noz-moscada, pimenta-do-reino e cravo-da-índia valiam ouro na Europa.", false),
            new Alt("Serviam para conservar alimentos em épocas sem geladeiras, dar sabor e preparar remédios e perfumes nobres.", false),
            new Alt("Eram pós mágicos usados para transformar pedras comuns em moedas de ouro maciço.", true)
        }));
        l5.Add(new Q("A Rota das Índias", new Alt[] {
            new Alt("Era o cobiçado caminho marítimo pelo sul da África que os portugueses buscaram para chegar aos mercados da Ásia.", false),
            new Alt("Permitia comprar especiarias diretamente na fonte sem pagar taxas abusivas aos mercadores intermediários.", false),
            new Alt("Era um túnel subterrâneo escavado sob o Oceano Atlântico para passar bondinhos de tração animal.", true)
        }));
        l5.Add(new Q("O Infante Dom Henrique", new Alt[] {
            new Alt("Foi o príncipe português que impulsionou os estudos marítimos e as expedições de navegação pelo Atlântico.", false),
            new Alt("Ficou historicamente conhecido como 'Henrique, o Navegador', incentivando a fundação do centro náutico de Sagres.", false),
            new Alt("Inventou o primeiro motor a jato para aviões de passageiros no porto de Lisboa.", true)
        }));
        l5.Add(new Q("Bartolomeu Dias e o Cabo das Tormentas", new Alt[] {
            new Alt("Em 1488, foi o primeiro capitão europeu a contornar o temido extremo sul do continente africano enfrentando mar bravo.", false),
            new Alt("O rei de Portugal rebatizou o local de Cabo da Boa Esperança pelo otimismo de alcançar a Índia.", false),
            new Alt("Afundou o navio na piscina de um hotel de luxo na cidade de Paris durante um cruzeiro.", true)
        }));
        l5.Add(new Q("Vasco da Gama", new Alt[] {
            new Alt("Foi o navegador português pioneiro que comandou com sucesso a primeira viagem marítima da Europa até Calecute, na Índia.", false),
            new Alt("Retornou a Lisboa com os porões dos navios repletos de valiosas especiarias orientais.", false),
            new Alt("Descobriu a cidade de Tóquio viajando montado em uma tartaruga voadora mágica.", true)
        }));
        l5.Add(new Q("Cristóvão Colombo (1492)", new Alt[] {
            new Alt("Navegador genovês a serviço da Coroa Espanhola que cruzou o Oceano Atlântico acreditando chegar à Ásia pelo oeste.", false),
            new Alt("Chegou a uma ilha das Bahamas em outubro de 1492 comandando as caravelas Santa Maria, Pinta e Niña.", false),
            new Alt("Viajou no tempo em um disco voador espacial e aterrissou na Lua antes dos dinossauros.", true)
        }));
        l5.Add(new Q("As Três Caravelas de Colombo", new Alt[] {
            new Alt("Ficaram famosas na história da humanidade com os nomes lendários de Santa Maria, Pinta e Niña.", false),
            new Alt("A Santa Maria era a maior das três embarcações (uma nau capitânia comandada pelo próprio Colombo).", false),
            new Alt("Eram três barquinhos de borracha infláveis movidos a pedalinhos de parque infantil.", true)
        }));
        l5.Add(new Q("O Tratado de Tordesilhas (1494)", new Alt[] {
            new Alt("Foi um acordo assinado entre Portugal e Espanha dividindo entre si as novas terras descobertas fora da Europa.", false),
            new Alt("Traçava uma linha imaginária a 370 léguas a oeste de Cabo Verde: o leste para Portugal e o oeste para a Espanha.", false),
            new Alt("Dividia o planeta Marte entre astronautas norte-americanos e cientistas russos.", true)
        }));
        l5.Add(new Q("Fernão de Magalhães", new Alt[] {
            new Alt("Capitão português a serviço da Espanha que liderou a primeira expedição a dar a volta ao mundo (circum-navegação).", false),
            new Alt("Encontrou o estreito navegável no sul da América do Sul que hoje leva o seu nome (Estreito de Magalhães).", false),
            new Alt("Completou a viagem ao redor do planeta em quarenta minutos dirigindo uma moto elétrica.", true)
        }));
        l5.Add(new Q("O Estreito de Magalhães", new Alt[] {
            new Alt("É uma passagem marítima perigosa e fria no extremo sul do continente americano conectando o Atlântico ao Pacífico.", false),
            new Alt("Foi superada pela expedição de Magalhães após meses de busca e enfrentamento de vendavais constantes.", false),
            new Alt("É um canal artificial feito de plástico construído no pátio de uma escola em Brasília.", true)
        }));
        l5.Add(new Q("O Oceano Pacífico e seu Nome", new Alt[] {
            new Alt("Quando a frota de Magalhães entrou em suas águas após o tempestuoso estreito, encontrou um mar calmo e sereno.", false),
            new Alt("Por causa dessa aparente tranquilidade inicial das águas, os marinheiros o batizaram de 'Mar Pacífico'.", false),
            new Alt("Recebeu esse nome em homenagem a um famoso cantor de rock que tocava guitarra no navio.", true)
        }));
        l5.Add(new Q("A Vida a Bordo das Caravelas", new Alt[] {
            new Alt("Os marinheiros passavam meses no mar enfrentando tempestades, calor sufocante e racionamento severo de água potável.", false),
            new Alt("Alimentavam-se de biscoitos de farinha secos e duros (muitas vezes com carunchos) e carnes salgadas em tonéis.", false),
            new Alt("Passavam o dia relaxando em banheiras com hidromassagem e pedindo lanches por aplicativo.", true)
        }));
        l5.Add(new Q("O Escorbuto", new Alt[] {
            new Alt("Era uma doença grave e comum entre marujos provocada pela falta prolongada de vitamina C fresca na dieta do mar.", false),
            new Alt("Causava sangramento nas gengivas, dentes moles e fraqueza, sendo mais tarde combatida com frutas cítricas como limão.", false),
            new Alt("Transformava os marinheiros em peixes dourados que saltavam da amurada para o mar.", true)
        }));
        l5.Add(new Q("O Monstro Marinho (Mitos do Mar Tenebroso)", new Alt[] {
            new Alt("Antes das viagens, muitos acreditavam que o Atlântico desconhecido era infestado de serpentes colossais e lulas gigantes.", false),
            new Alt("Acreditava-se até que a água perto da linha do Equador fervia e derretia a madeira dos cascos dos navios.", false),
            new Alt("Historiadores comprovaram que dragões de fogo verdadeiros queimavam navios no meio do mar diariamente.", true)
        }));
        l5.Add(new Q("O Kraken", new Alt[] {
            new Alt("É uma famosa criatura mitológica das lendas marinhas escandinavas descrita como uma lula ou polvo gigantesco.", false),
            new Alt("Dizia-se que seus tentáculos imensos eram capazes de abraçar caravelas inteiras e puxá-las para as profundezas.", false),
            new Alt("Era um simpático peixinho beta vermelho que os marinheiros alimentavam com migalhas de pão.", true)
        }));
        l5.Add(new Q("O Fogo de Santelmo", new Alt[] {
            new Alt("É um fenômeno elétrico luminoso natural que aparece nas pontas dos mastros dos navios durante tempestades no mar.", false),
            new Alt("Os marinheiros antigos viam essa luz azulada com veneração religiosa, como proteção do padroeiro dos marujos.", false),
            new Alt("Eram lanternas de pilha penduradas por piratas para encontrar moedas perdidas no convés.", true)
        }));
        l5.Add(new Q("A Era de Ouro da Pirataria", new Alt[] {
            new Alt("Ocorreu principalmente entre os séculos dezessete e dezoito nas rotas do Mar do Caribe e do Oceano Atlântico.", false),
            new Alt("Piratas atacavam galeões mercantes repletos de ouro, prata, especiarias e tecidos preciosos do Novo Mundo.", false),
            new Alt("Durou apenas dois dias e acabou porque todos os piratas preferiram virar motoristas de ônibus.", true)
        }));
        l5.Add(new Q("A Bandeira Pirata (Jolly Roger)", new Alt[] {
            new Alt("Era a famosa bandeira preta estampada com uma caveira branca sobre ossos ou espadas cruzadas.", false),
            new Alt("Servia para aterrorizar navios alvos à distância, exigindo sua rendição imediata sem combate armado.", false),
            new Alt("Era uma bandeira rosa com o desenho de um ursinho de pelúcia comendo sorvete de baunilha.", true)
        }));
        l5.Add(new Q("A Ilha de Tortuga", new Alt[] {
            new Alt("Fica situada na costa norte do Haiti e foi um dos esconderijos e bases operacionais de piratas mais célebres do Caribe.", false),
            new Alt("Tinha esse nome em francês porque seu contorno visto do mar lembrava o casco de uma grande tartaruga marinha.", false),
            new Alt("Fica localizada dentro de uma cratera de gelo no Polo Sul terrestre habitada por focas.", true)
        }));
        l5.Add(new Q("A Cidade de Port Royal", new Alt[] {
            new Alt("Localizada na Jamaica, ficou conhecida no século dezessete como a base comercial e refúgio favorito de bucaneiros e piratas.", false),
            new Alt("Grande parte da cidade afundou no mar após um devastador terremoto e tsunami no ano de 1692.", false),
            new Alt("Era uma estação espacial flutuante no céu que atirava raios laser contra navios invasores.", true)
        }));
        l5.Add(new Q("O Pirata Barba Negra (Edward Teach)", new Alt[] {
            new Alt("Foi um dos piratas mais temidos da história, famoso por sua longa barba negra trançada com laços de fita.", false),
            new Alt("Colocava mechas acesas de pavio sob o chapéu durante as batalhas, soltando fumaça assustadora ao redor do rosto.", false),
            new Alt("Nunca subiu em um barco e passou a vida inteira vendendo picolés em um circo infantil.", true)
        }));
        l5.Add(new Q("O Navio Vingança da Rainha Ana (Queen Anne's Revenge)", new Alt[] {
            new Alt("Foi o imponente navio capitânia do pirata Barba Negra, equipado com quarenta canhões de bordo pesados.", false),
            new Alt("Foi originalmente um navio francês capturado e modificado para ser uma máquina de combate veloz no mar.", false),
            new Alt("Era uma canoa de índio feita de casca de árvore que afundava com mais de dois tripulantes.", true)
        }));
        l5.Add(new Q("Os Corsários e a Carta de Corso", new Alt[] {
            new Alt("Eram capitães particulares autorizados legalmente por governos de reis a atacar navios de nações inimigas.", false),
            new Alt("Carregavam um documento oficial chamado Carta de Corso que legitimava a apreensão das cargas em nome da Coroa.", false),
            new Alt("Eram mágicos que viajavam pelo oceano em vassouras voadoras transformando navios em pombos.", true)
        }));
        l5.Add(new Q("Sir Francis Drake", new Alt[] {
            new Alt("Foi um famoso corsário inglês a serviço da Rainha Elizabeth I que saqueou ricas cidades coloniais espanholas.", false),
            new Alt("Completou a segunda viagem de circum-navegação do planeta a bordo de seu navio Golden Hind.", false),
            new Alt("Foi o criador do primeiro videogame portátil de bolso movido a energia eólica da história.", true)
        }));
        l5.Add(new Q("O Capitão William Kidd", new Alt[] {
            new Alt("Foi um capitão escocês que começou caçando piratas e acabou acusado de pirataria e condenado em Londres.", false),
            new Alt("A lenda de que teria enterrado um valioso tesouro em ilhas secretas inspirou histórias e caças ao tesouro por séculos.", false),
            new Alt("Era um astronauta aposentado que dava aulas de pilotagem de naves para extraterrestres.", true)
        }));
        l5.Add(new Q("As Mulheres Piratas: Anne Bonny e Mary Read", new Alt[] {
            new Alt("Foram duas célebres mulheres que se disfarçavam de marinheiros e lutaram bravamente a bordo de navios piratas no Caribe.", false),
            new Alt("Ficaram conhecidas por sua coragem extraordinária em batalha, empunhando pistolas e cutelos sem medo.", false),
            new Alt("Eram duas cantoras de ópera que nunca saíram de seus teatros elegantes na Áustria.", true)
        }));
        l5.Add(new Q("O Tapa-Olho Pirata", new Alt[] {
            new Alt("Muitos historiadores apontam que marujos usavam o tapa-olho para manter um olho sempre adaptado à escuridão do porão.", false),
            new Alt("Assim, ao descer às pressas sob o convés escuro em combate, bastava trocar o tapa-olho para enxergar de imediato.", false),
            new Alt("Era usado de enfeite para os piratas dormirem com um olho fechado e outro assistindo desenhos.", true)
        }));
        l5.Add(new Q("A Perna de Pau e o Gancho", new Alt[] {
            new Alt("Eram próteses rústicas de madeira e ferro usadas por marujos e piratas que perdiam membros por tiros de canhão ou gangrena.", false),
            new Alt("Tornaram-se símbolos visuais eternos da pirataria na literatura e no cinema clássico.", false),
            new Alt("Eram aparelhos eletrônicos com conexão wi-fi usados para navegar na internet em alto-mar.", true)
        }));
        l5.Add(new Q("O Papagaio no Ombro do Pirata", new Alt[] {
            new Alt("Papagaios e araras tropicais eram animais de estimação exóticos muito populares trazidos das florestas do Caribe e Américas.", false),
            new Alt("Eram coloridos, fáceis de alimentar em longas viagens marítimas e divertiam a tripulação repetindo palavras.", false),
            new Alt("Eram robôs espiões fabricados por governos modernos para vigiar as conversas dos piratas.", true)
        }));
        l5.Add(new Q("O Cutelo (Cutlass)", new Alt[] {
            new Alt("Era uma espada curta, larga e curva com guarda reforçada nas mãos, a arma branca favorita da vida no mar.", false),
            new Alt("Seu tamanho compacto era perfeito para o combate corpo a corpo violento nos conveses apinhados de marinheiros.", false),
            new Alt("Era uma régua de plástico flexível de escola usada para desenhar margens de cadernos.", true)
        }));
        l5.Add(new Q("As Pistolas de Pederneira (Flintlock)", new Alt[] {
            new Alt("Eram armas de fogo que usavam uma pedra de sílex para soltar faíscas e inflamar a pólvora na câmara de tiro.", false),
            new Alt("Como disparavam apenas um tiro antes de uma recarga demorada, muitos piratas carregavam várias pistolas no cinto.", false),
            new Alt("Disparavam água com sabão e bolinhas de gude coloridas para assustar pombos do mastro.", true)
        }));
        l5.Add(new Q("Os Canhões Navais", new Alt[] {
            new Alt("Eram peças pesadas de ferro fundido montadas sobre carretas de madeira nos conveses inferiores dos navios.", false),
            new Alt("Disparavam pesadas balas de ferro sólido ou correntes duplas projetadas para estraçalhar mastros e velas inimigas.", false),
            new Alt("Disparavam pizzas quentes embaladas em caixas de papelão para o almoço dos adversários.", true)
        }));
        l5.Add(new Q("O Motim a Bordo", new Alt[] {
            new Alt("Era a rebelião armada da tripulação marinheira contra o comando de seu capitão por abusos, fome ou injustiças.", false),
            new Alt("O mais famoso motim da história marítima ocorreu a bordo do navio inglês HMS Bounty no Pacífico em 1789.", false),
            new Alt("Era uma festa dançante onde o capitão e os marujos disputavam um troféu de dança de tango.", true)
        }));
        l5.Add(new Q("Andar na Prancha", new Alt[] {
            new Alt("É um castigo clássico e assustador retratado em livros onde prisioneiros eram forçados a caminhar sobre uma prancha até o mar.", false),
            new Alt("Apesar de muito célebre em romances de piratas como Peter Pan, na vida real histórica esse método era raramente usado.", false),
            new Alt("Era uma aula de surf de ondas gigantes ministrada obrigatoriamente por todos os piratas aos domingos.", true)
        }));
        l5.Add(new Q("O Código Pirata (Charta Partita)", new Alt[] {
            new Alt("Eram conjuntos de regras democráticas acordadas e assinadas por toda a tripulação pirata antes de cada viagem.", false),
            new Alt("Definiam a partilha justa dos tesouros saqueados, disciplina, proibições de brigas e indenizações por perda de membros.", false),
            new Alt("Exigiam que todos os marujos usassem gravata borboleta e fizessem reverência ao cozinheiro.", true)
        }));
        l5.Add(new Q("O Galeão Espanhol", new Alt[] {
            new Alt("Era um navio de guerra e carga de grande porte fortemente armado com canhões múltiplos em vários conveses.", false),
            new Alt("Transportava as valiosas frotas da prata e do ouro das colônias da América até os cofres do rei na Espanha.", false),
            new Alt("Era feito de chocolate meio amargo crocante e precisava navegar apenas em águas geladas.", true)
        }));
        l5.Add(new Q("A Garrafa de Rum", new Alt[] {
            new Alt("Era uma bebida alcoólica destilada muito comum e barata feita a partir do melaço da cana-de-açúcar das plantações caribenhas.", false),
            new Alt("Os marinheiros recebiam uma ração diária misturada com água e suco de limão (chamada de grog) para evitar doenças.", false),
            new Alt("Era um refrigerante gaseificado com sabor de chiclete de morango inventado em Londres.", true)
        }));
        l5.Add(new Q("O Canto dos Marinheiros (Sea Shanty)", new Alt[] {
            new Alt("Eram canções rítmicas e enérgicas cantadas em coro pelos marinheiros para coordenar tarefas pesadas a bordo.", false),
            new Alt("Ajudavam a manter o ritmo perfeito ao puxar cordas pesadas das velas ou girar o pesado cabrestante da âncora.", false),
            new Alt("Eram sussurros silenciosos feitos de boca fechada para ninguém escutar a letra da música.", true)
        }));
        l5.Add(new Q("O Baú do Tesouro", new Alt[] {
            new Alt("Eram baús de madeira reforçados com tiras e fechos de ferro usados para guardar pertences valiosos e moedas.", false),
            new Alt("A ideia de enterrar baús com mapas marcados com 'X' foi popularizada pelo famoso livro 'A Ilha do Tesouro'.", false),
            new Alt("Eram caixas plásticas de ferramentas com fechaduras eletrônicas acionadas por biometria facial.", true)
        }));
        l5.Add(new Q("Os Dobrões e Reais de Oito", new Alt[] {
            new Alt("Eram famosas moedas de ouro e prata cunhadas pelo Império Espanhol que circulavam como dinheiro mundial na época.", false),
            new Alt("Eram o principal e mais cobiçado prêmio procurado por corsários e piratas ao atacar galeões espanhóis.", false),
            new Alt("Eram fichas plásticas coloridas usadas exclusivamente para jogar fliperama no shopping.", true)
        }));
        l5.Add(new Q("O Navio Fantasma Holandês Voador (Flying Dutchman)", new Alt[] {
            new Alt("É a mais célebre lenda do folclore marítimo sobre um navio fantasma condenado a navegar para sempre sem nunca aportar.", false),
            new Alt("Diz a lenda que avistar sua silhueta brilhando na névoa em noites de tempestade era presságio de terrível azar.", false),
            new Alt("Era uma nave espacial intergaláctica pilotada por patos de borracha usando óculos de sol.", true)
        }));
        l5.Add(new Q("A Ampulheta de Marinheiro", new Alt[] {
            new Alt("Era um relógio de areia de vidro usado nos navios antigos para medir a passagem do tempo em turnos de quatro horas.", false),
            new Alt("A cada meia hora a ampulheta era virada e um grumete badalava o sino do navio para alertar a tripulação de vigia.", false),
            new Alt("Funcionava com uma pilha pequena no fundo e tinha ponteiros digitais que brilhavam no escuro.", true)
        }));
        l5.Add(new Q("O Barômetro no Mar", new Alt[] {
            new Alt("Instrumento que mede a pressão do ar, permitindo aos navegadores prever com antecedência tempestades violentas no horizonte.", false),
            new Alt("Uma queda súbita e rápida na coluna de mercúrio indicava a chegada iminente de um furacão ou vendaval perigoso.", false),
            new Alt("Media a temperatura da água da torneira para preparar o chá da tarde do capitão.", true)
        }));
        l5.Add(new Q("A Roda de Leme (Timão)", new Alt[] {
            new Alt("Era o mecanismo de madeira com raios salientes que o timoneiro girava no convés para direcionar o leme do navio.", false),
            new Alt("Permitia manter o curso com precisão navegando pelas rotas marítimas traçadas nas cartas náuticas.", false),
            new Alt("Era uma pizza gigante que os marujos assavam no forno e dividiam com a tripulação.", true)
        }));
        l5.Add(new Q("O Diário de Bordo (Logbook)", new Alt[] {
            new Alt("Era o caderno oficial onde o capitão e o piloto registravam diariamente posições, ventos, distâncias e ocorrências do mar.", false),
            new Alt("Servia como prova legal perante a Coroa e como base para aperfeiçoar os mapas náuticos de futuras viagens.", false),
            new Alt("Era um álbum de figurinhas de futebol que os marinheiros colavam antes de dormir.", true)
        }));
        l5.Add(new Q("O Legado das Grandes Navegações", new Alt[] {
            new Alt("Conectou pela primeira vez os quatro cantos do globo em uma rede contínua de comércio, povos e trocas culturais.", false),
            new Alt("Expandiu dramaticamente o conhecimento geográfico, botânico, astronômico e cartográfico da humanidade.", false),
            new Alt("Fez com que todos os mares do mundo secassem completamente até virarem pistas de rali.", true)
        }));

        // ==========================================
        // NIVEL 6: CHEGADA AO BRASIL E POVOS INDÍGENAS (50 Questões)
        // ==========================================
        var l6 = levels[6];
        l6.Add(new Q("A Frota de Pedro Álvares Cabral", new Alt[] {
            new Alt("Partiu de Lisboa em março de 1500 comandando uma grande expedição de treze embarcações e cerca de 1.500 homens.", false),
            new Alt("O objetivo oficial era consolidar a rota de comércio com as Índias contornando a costa africana.", false),
            new Alt("A frota era formada por dez aviões a jato supersônicos pilotados por astronautas experientes.", true)
        }));
        l6.Add(new Q("O Monte Pascoal", new Alt[] {
            new Alt("Foi o primeiro ponto de terra firme brasileiro avistado pela frota portuguesa no dia 22 de abril de 1500.", false),
            new Alt("Recebeu esse nome porque a chegada aconteceu na semana das celebrações da Páscoa cristã.", false),
            new Alt("É uma pirâmide egípcia de pedra construída no topo de um prédio no centro de São Paulo.", true)
        }));
        l6.Add(new Q("A Chegada em Porto Seguro", new Alt[] {
            new Alt("A frota ancorou em uma enseada abrigada no atual litoral do estado da Bahia, batizada de Porto Seguro.", false),
            new Alt("Lá ocorreram os primeiros contatos pacíficos e curiosos entre portugueses e os povos indígenas nativos.", false),
            new Alt("Cabral chegou pegando um voo comercial e hospedou-se em um resort de luxo com praia privada.", true)
        }));
        l6.Add(new Q("A Carta de Pero Vaz de Caminha", new Alt[] {
            new Alt("Foi o relato detalhado escrito pelo escrivão da frota ao rei Dom Manuel I narrando a nova terra e seus povos.", false),
            new Alt("É considerada a 'certidão de nascimento' escrita do Brasil, descrevendo a exuberante natureza e a primeira missa.", false),
            new Alt("Foi uma mensagem de correio de voz enviada por aplicativo de mensagens de celular no ano 1500.", true)
        }));
        l6.Add(new Q("A Primeira Missa no Brasil", new Alt[] {
            new Alt("Foi celebrada pelo frei Henrique de Coimbra no ilhéu de Coroa Vermelha no dia 26 de abril de 1500.", false),
            new Alt("Os marinheiros ergueram uma grande cruz de madeira na praia, observados com curiosidade por grupos indígenas.", false),
            new Alt("Foi transmitida ao vivo pela televisão em rede nacional com efeitos especiais em 3D.", true)
        }));
        l6.Add(new Q("O Primeiro Nome: Ilha de Vera Cruz", new Alt[] {
            new Alt("Inicialmente, Cabral e os navegadores pensaram que haviam chegado a uma grande ilha, batizando-a de Ilha de Vera Cruz.", false),
            new Alt("Mais tarde, ao perceberem a imensidão continental da terra firme, mudaram o nome para Terra de Santa Cruz.", false),
            new Alt("O primeiro nome oficial dado à terra foi Planeta Gelado dos Pinguins Voadores.", true)
        }));
        l6.Add(new Q("A Origem do Nome Brasil", new Alt[] {
            new Alt("O país recebeu o nome 'Brasil' devido à abundante árvore pau-brasil, cuja madeira produzia uma valiosa tinta vermelha cor de brasa.", false),
            new Alt("A resina cor de brasa da árvore era extremamente cobiçada na Europa para tingir tecidos nobres de reis e nobres.", false),
            new Alt("O nome foi criado em homenagem ao inventor da bicicleta amarela de corrida no século dezenove.", true)
        }));
        l6.Add(new Q("A Árvore Pau-Brasil (Paubrasilia echinata)", new Alt[] {
            new Alt("Possui uma madeira densa e espinhosa com tronco avermelhado escuro no cerne, nativa da Mata Atlântica.", false),
            new Alt("Foi tão intensamente explorada no primeiro século de colonização que quase foi extinta das florestas litorâneas.", false),
            new Alt("É uma árvore que dá frutas em formato de moedas de chocolate prontas para comer.", true)
        }));
        l6.Add(new Q("O Povo Tupinambá", new Alt[] {
            new Alt("Era um dos principais grupos indígenas do tronco linguístico tupi que habitava grande parte do litoral brasileiro.", false),
            new Alt("Viviam em grandes aldeias fortificadas por paliçadas de madeira e eram exímios canoeiros e guerreiros valentes.", false),
            new Alt("Moravam em iglus de gelo e caçavam morsas e focas nas praias quentes da Bahia.", true)
        }));
        l6.Add(new Q("O Tronco Linguístico Tupi-Guarani", new Alt[] {
            new Alt("Era uma família linguística rica falada por diversas tribos indígenas que se espalhavam pelo litoral e interior.", false),
            new Alt("Deu origem a centenas de palavras que usamos no português moderno, como 'pipoca', 'maracujá', 'abacaxi' e 'jacaré'.", false),
            new Alt("Era uma língua em que ninguém falava, apenas batiam tampas de panela para se comunicar.", true)
        }));
        l6.Add(new Q("As Malocas e Tabas Indígenas", new Alt[] {
            new Alt("A taba era a aldeia circular, e a maloca (ou oca) era a grande habitação comunitária feita de madeira e palha de palmeira.", false),
            new Alt("Várias famílias aparentadas viviam juntas sob o mesmo teto, dormindo em redes confortáveis de algodão ou fibras.", false),
            new Alt("Eram prédios de apartamentos de trinta andares com elevadores panorâmicos e portaria vinte e quatro horas.", true)
        }));
        l6.Add(new Q("A Rede de Dormir", new Alt[] {
            new Alt("Foi uma invenção genial dos povos indígenas brasileiros feita com fios de algodão trançados ou fibras de tucum.", false),
            new Alt("Mantinha a pessoa suspensa longe da umidade do chão, de insetos rastejantes e animais peçonhentos durante o sono.", false),
            new Alt("Foi trazida de Marte pelos astronautas durante a missão Apollo para acampar na praia.", true)
        }));
        l6.Add(new Q("O Escambo do Pau-Brasil", new Alt[] {
            new Alt("Era o sistema inicial de trocas comerciais onde os indígenas cortavam e carregavam toras de madeira até as caravelas.", false),
            new Alt("Em troca do trabalho, recebiam ferramentas de metal como machados, facas, tecidos, espelhos e apitos de ferro.", false),
            new Alt("Os portugueses pagavam os indígenas depositando bitcoins em contas bancárias digitais.", true)
        }));
        l6.Add(new Q("As Feitorias no Litoral", new Alt[] {
            new Alt("Eram postos fortificados de madeira estabelecidos ao longo da costa para armazenar toras de pau-brasil e proteger o comércio.", false),
            new Alt("Serviam de entrepostos provisórios para as frotas que vinham de Portugal recolher madeira e abastecer mantimentos.", false),
            new Alt("Eram shopping centers com lojas de roupas de grife e praças de alimentação com fast food.", true)
        }));
        l6.Add(new Q("A Agricultura Indígena da Mandioca", new Alt[] {
            new Alt("A mandioca (ou aipim/macaxeira) era a base alimentar fundamental dos povos originários do território brasileiro.", false),
            new Alt("Desenvolveram técnicas engenhosas para ralar a raiz, prensar e retirar o caldo tóxico (tipiti), fazendo farinhas e beijus.", false),
            new Alt("A mandioca era importada da Antártida congelada em blocos de gelo marinho.", true)
        }));
        l6.Add(new Q("O Tipiti", new Alt[] {
            new Alt("É um tubo trançado de palha de jacitara inventado pelos indígenas para espremer a massa ralada da mandioca-brava.", false),
            new Alt("Ao ser esticado nas pontas com pesos, espreme eficientemente o veneno ácido da raiz, tornando-a segura para o consumo.", false),
            new Alt("Era um par de fones de ouvido sem fio usado pelos pajés para ouvir transmissões de rádio.", true)
        }));
        l6.Add(new Q("O Pajé e o Xamanismo", new Alt[] {
            new Alt("O pajé era o líder espiritual, curandeiro e guardião das tradições ancestrais e dos mitos sagrados da aldeia.", false),
            new Alt("Possuía profundo conhecimento de ervas medicinais da floresta, raízes, rezas e cantos rituais de cura.", false),
            new Alt("Era um robô cibernético programado em linguagem de computador moderna.", true)
        }));
        l6.Add(new Q("O Cacique (Tuxaua)", new Alt[] {
            new Alt("Era o chefe político e militar da aldeia indígena, respeitado por sua sabedoria, generosidade e habilidade de liderança.", false),
            new Alt("Liderava guerreiros em tempos de conflito e organizava a comunidade, ouvindo o conselho dos anciãos respeitados.", false),
            new Alt("Era coroado com uma coroa de ouro e diamantes e usava um cetro mágico de conto de fadas.", true)
        }));
        l6.Add(new Q("A Pintura Corporal com Urucum e Jenipapo", new Alt[] {
            new Alt("Os indígenas usavam tintas naturais: o urucum fornecia o vermelho vibrante e o jenipapo a tinta preta escura indelével.", false),
            new Alt("Os desenhos geométricos na pele identificavam a tribo, estado civil, celebrações, luto e serviam como repelente natural.", false),
            new Alt("Pintavam o corpo usando tinta guache escolar lavável comprada em papelarias do bairro.", true)
        }));
        l6.Add(new Q("A Arte Plumária Indígena", new Alt[] {
            new Alt("É a requintada confecção de diademas (cocares), brincos, braceletes e mantos feitos com penas coloridas de araras e tucanos.", false),
            new Alt("Os adornos de penas eram usados em grandes cerimônias rituais, ritos de passagem e festas de dança da aldeia.", false),
            new Alt("Eram feitos colando folhas de jornal velho dobradas com fita adesiva transparente.", true)
        }));
        l6.Add(new Q("O Arco e Flecha Indígena", new Alt[] {
            new Alt("Eram fabricados com madeiras nobres e flexíveis e cordas feitas de fibras vegetais resistentes como o tucum.", false),
            new Alt("As flechas tinham pontas de osso, dente de peixe ou madeira endurecida ao fogo para caça de animais e pesca.", false),
            new Alt("Eram equipados com miras a laser de longo alcance e carregador automático de baterias.", true)
        }));
        l6.Add(new Q("A Canoa de Casca de Árvore e Tronco Inteiro", new Alt[] {
            new Alt("Os indígenas escavavam troncos grossos de árvores usando fogo controlado e raspadores para criar canoas compridas.", false),
            new Alt("Eram embarcações extremamente leves e velozes, perfeitas para navegar rios rasos com corredeiras e lagoas do litoral.", false),
            new Alt("Eram lanchas de ferro a motor turbo com assentos de couro e ar-condicionado de fábrica.", true)
        }));
        l6.Add(new Q("A Cerâmica Marajoara", new Alt[] {
            new Alt("Floresceu na Ilha de Marajó (Pará) muito antes da chegada dos europeus, com peças de cerâmica de riqueza ímpar.", false),
            new Alt("Destacava-se por urnas funerárias e vasos ricamente decorados com padrões geométricos e relevos labirínticos.", false),
            new Alt("Eram pratos de plástico descartáveis fabricados em fábricas industriais automáticas.", true)
        }));
        l6.Add(new Q("A Cerâmica de Santarém (Tapajônica)", new Alt[] {
            new Alt("Desenvolvida pelos povos tapajônicos no Pará, é famosa por vasos esculturais decorados com animais e figuras humanas.", false),
            new Alt("Demonstrava altíssimo grau de complexidade artística e domínio refinado da queima e modelagem da argila.", false),
            new Alt("Era feita esculpindo pneus de borracha reciclados recolhidos nas rodovias.", true)
        }));
        l6.Add(new Q("As Expedições Guarda-Costas", new Alt[] {
            new Alt("Comandadas por capitães como Cristóvão Jacques, patrulhavam a costa para expulsar corsários franceses que roubavam pau-brasil.", false),
            new Alt("A França não reconhecia o Tratado de Tordesilhas e negociava madeira diretamente com tribos indígenas aliadas.", false),
            new Alt("Eram passeios de barco com música ao vivo promovidos para turistas estrangeiros tirarem fotos.", true)
        }));
        l6.Add(new Q("Martim Afonso de Sousa (1530)", new Alt[] {
            new Alt("Liderou a primeira expedição colonizadora oficial enviada por Portugal para ocupar e defender o território brasileiro.", false),
            new Alt("Trouxe mudas de cana-de-açúcar, gado, sementes, ferramentas e fundou o primeiro engenho de açúcar do país.", false),
            new Alt("Chegou pilotando um helicóptero de resgate para inaugurar um shopping center em São Paulo.", true)
        }));
        l6.Add(new Q("A Fundação de São Vicente (1532)", new Alt[] {
            new Alt("Localizada no litoral paulista, foi a primeira vila oficial fundada pelos colonizadores portugueses no Brasil.", false),
            new Alt("Criou a primeira câmara municipal, instalou o primeiro pelourinho e o primeiro tribunal de justiça da colônia.", false),
            new Alt("Foi fundada no alto da cordilheira do Himalaia cercada por montanhas de neve perpétua.", true)
        }));
        l6.Add(new Q("As Capitanias Hereditárias (1534)", new Alt[] {
            new Alt("O rei Dom João III dividiu o litoral brasileiro em quinze grandes faixas de terra doadas a capitães donatários nobres.", false),
            new Alt("Os donatários tinham a missão de colonizar, cultivar a terra e defender a capitania com seus próprios recursos.", false),
            new Alt("Eram ilhas flutuantes feitas de isopor que navegavam de um lado para o outro do oceano.", true)
        }));
        l6.Add(new Q("O Sucesso de Pernambuco e São Vicente", new Alt[] {
            new Alt("Foram as duas únicas capitanias hereditárias que prosperaram economicamente no início da colonização.", false),
            new Alt("O sucesso se deveu principalmente ao solo fértil de massapê e ao florescimento do cultivo da cana-de-açúcar.", false),
            new Alt("Prosperaram porque exportavam computadores portáteis e celulares para outros países.", true)
        }));
        l6.Add(new Q("O Solo de Massapê", new Alt[] {
            new Alt("É uma terra escura, argilosa, úmida e extraordinariamente fértil encontrada na Zona da Mata do Nordeste brasileiro.", false),
            new Alt("Era ideal para as raízes da cana-de-açúcar, permitindo canaviais verdejantes e colheitas doces abundantes.", false),
            new Alt("É uma areia branca de deserto onde nenhuma semente ou planta consegue germinar.", true)
        }));
        l6.Add(new Q("Os Primeiros Engenhos de Açúcar", new Alt[] {
            new Alt("Eram grandes complexos agrícolas e industriais formados pelo canavial, casa-grande, senzala e a moenda de cana.", false),
            new Alt("A moenda esmagava a cana com cilindros movidos a tração animal (bois) ou pela força da água de rodas d'água.", false),
            new Alt("Eram laboratórios subterrâneos ultramodernos operados por inteligência artificial computadorizada.", true)
        }));
        l6.Add(new Q("A Casa das Caldeiras e Casa de Purgar", new Alt[] {
            new Alt("Eram as etapas industriais do engenho onde o caldo da cana era fervido em tachos de cobre até virar melaço espesso.", false),
            new Alt("Na casa de purgar, o melaço escorria em formas de barro em formato de cone para secar e clarear o pão de açúcar.", false),
            new Alt("Eram salas de cinema com ar condicionado onde os operários assistiam filmes de animação.", true)
        }));
        l6.Add(new Q("O Pão de Açúcar (Origem do Formato)", new Alt[] {
            new Alt("O açúcar seco desenformado saía em formato de cone ou sino pontiagudo chamado tradicionalmente de 'pão de açúcar'.", false),
            new Alt("O famoso morro do Pão de Açúcar no Rio de Janeiro recebeu esse nome pela semelhança marcante com essas formas de barro.", false),
            new Alt("O nome surgiu porque padeiros coloniais faziam pão francês em formato de montanhas na cozinha.", true)
        }));
        l6.Add(new Q("Tomé de Sousa e o Governo-Geral (1549)", new Alt[] {
            new Alt("Foi o primeiro Governador-Geral enviado pela Coroa Portuguesa para centralizar e organizar a administração da colônia.", false),
            new Alt("Chegou com colonos, soldados, padres jesuítas e a ordem de construir uma capital forte e protegida.", false),
            new Alt("Chegou sozinho de bicicleta vindo de Roma para dar aulas de patinação no gelo na praia.", true)
        }));
        l6.Add(new Q("A Fundação de Salvador (1549)", new Alt[] {
            new Alt("Fundada por Tomé de Sousa na Baía de Todos-os-Santos, foi a primeira capital oficial e centro administrativo do Brasil.", false),
            new Alt("Foi planejada em dois níveis: a Cidade Alta (para defesa militar e governo) e a Cidade Baixa (para o porto e comércio).", false),
            new Alt("Foi erguida no coração da Floresta Amazônica perto da fronteira com o Peru.", true)
        }));
        l6.Add(new Q("Os Padres Jesuítas no Brasil", new Alt[] {
            new Alt("Membros da Companhia de Jesus, como o padre Manuel da Nóbrega, vieram para catequizar e educar na colônia.", false),
            new Alt("Fundaram os primeiros colégios, aldeamentos missionários e aprenderam a língua tupi para ensinar e pregar.", false),
            new Alt("Eram mágicos de circo itinerante que faziam shows de malabarismo para vender vassouras.", true)
        }));
        l6.Add(new Q("O Padre José de Anchieta", new Alt[] {
            new Alt("Ficou célebre por escrever a primeira gramática da língua tupi mais falada na costa, facilitando a comunicação.", false),
            new Alt("Foi um dos fundadores do Colégio de São Paulo de Piratininga em 1554, que deu origem à metrópole de São Paulo.", false),
            new Alt("Foi o primeiro piloto brasileiro de Fórmula 1 e venceu o Grande Prêmio de Mônaco.", true)
        }));
        l6.Add(new Q("A Fundação de São Paulo (1554)", new Alt[] {
            new Alt("Nasceu em torno de um modesto colégio de taipa de pilão fundado por jesuítas no alto da colina entre os rios Tamanduateí e Anhangabaú.", false),
            new Alt("O local foi escolhido no planalto de Piratininga pelo clima agradável e por ficar perto de aldeias do cacique Tibiriçá.", false),
            new Alt("Foi construída no fundo do mar por mergulhadores equipados com tanques de oxigênio.", true)
        }));
        l6.Add(new Q("A Taipa de Pilão", new Alt[] {
            new Alt("Era uma técnica de construção rústica colonial onde terra úmida, argila e cascalho eram socados com pilões entre tábuas.", false),
            new Alt("Criava paredes grossas, resistentes e com excelente isolamento térmico para as construções coloniais.", false),
            new Alt("Era uma massa feita de sorvete de baunilha e calda de morango que endurecia ao sol.", true)
        }));
        l6.Add(new Q("A Invasão Francesa no Rio de Janeiro (França Antártica)", new Alt[] {
            new Alt("Em 1555, franceses comandados por Nicolas Durand de Villegagnon invadiram a Baía de Guanabara fundando a França Antártica.", false),
            new Alt("Ergueram o Forte Coligny em uma ilha da baía e aliaram-se a grupos indígenas tamoios contra os portugueses.", false),
            new Alt("Construíram a Torre Eiffel de metal no meio da praia de Ipanema para atrair turistas europeus.", true)
        }));
        l6.Add(new Q("Estácio de Sá e a Fundação do Rio de Janeiro (1565)", new Alt[] {
            new Alt("Foi o capitão português que fundou a cidade de São Sebastião do Rio de Janeiro aos pés do morro Cara de Cão.", false),
            new Alt("Liderou a base militar portuguesa para combater e expulsar definitivamente os invasores franceses da baía.", false),
            new Alt("Foi um cantor sertanejo famoso que gravou o primeiro disco de vinil no porto de Santos.", true)
        }));
        l6.Add(new Q("A Confederação dos Tamoios", new Alt[] {
            new Alt("Foi uma poderosa aliança de nações indígenas tupinambás que se uniram contra a escravização imposta pelos colonizadores.", false),
            new Alt("Lutaram guerras ferozes no litoral de São Paulo e Rio de Janeiro, aliando-se estrategicamente aos franceses.", false),
            new Alt("Era uma liga de futebol amador fundada para disputar campeonatos nos fins de semana.", true)
        }));
        l6.Add(new Q("O Curupira", new Alt[] {
            new Alt("É um mítico ser lendário do folclore indígena com cabelos vermelhos de fogo e pés virados para trás.", false),
            new Alt("Seus passos invertidos enganam caçadores mal-intencionados que tentam persegui-lo, protegendo os animais da mata.", false),
            new Alt("É um robô com asas metálicas que anda de patinete elétrico nas avenidas de Brasília.", true)
        }));
        l6.Add(new Q("O Boto-Cor-de-Rosa", new Alt[] {
            new Alt("É um mamífero aquático fluvial nativo dos rios da bacia amazônica que nada com habilidade entre árvores inundadas.", false),
            new Alt("No rico folclore amazônico, diz a lenda que ele se transforma em um belo rapaz de chapéu branco em noites de festa junina.", false),
            new Alt("É uma espécie de tubarão gigante de água salgada que voa no céu caçando gaivotas.", true)
        }));
        l6.Add(new Q("A Vitória-Régia", new Alt[] {
            new Alt("É uma planta aquática colossal nativa da Amazônia com folhas circulares gigantescas com bordas levantadas.", false),
            new Alt("Possui uma bela flor noturna aromática que abre branca e muda para tons rosados no dia seguinte.", false),
            new Alt("É um barco salva-vidas inflável de borracha fabricado pela Marinha do Brasil.", true)
        }));
        l6.Add(new Q("A Lenda do Guaraná", new Alt[] {
            new Alt("É uma lenda indígena dos povos Sateré-Mawé que explica a origem do fruto do guaraná como olhos de um jovem querido plantados na terra.", false),
            new Alt("Os frutos maduros do guaraná abertos lembram de fato perfeitamente o formato e brilho de olhos humanos.", false),
            new Alt("Conta que o guaraná nasceu de uma garrafa pet de refrigerante esquecida no meio da selva.", true)
        }));
        l6.Add(new Q("O Boitatá", new Alt[] {
            new Alt("No folclore de origem indígena, é uma gigantesca serpente luminosa de fogo que desliza pelas matas e rios.", false),
            new Alt("Protege as florestas e os animais contra incêndios criminosos e contra caçadores que destroem a natureza.", false),
            new Alt("É um trenzinho elétrico infantil de parque que toca música alegre ao dar a volta nos trilhos.", true)
        }));
        l6.Add(new Q("O Iara (Mãe-d'Água)", new Alt[] {
            new Alt("Na mitologia amazônica, é uma linda sereia de cabelos longos que vive nas águas dos rios caudalosos.", false),
            new Alt("Com seu canto suave e hipnótico, atrai pescadores e navegantes para o fundo das águas escuras.", false),
            new Alt("É uma piloto de helicóptero que patrulha as praias cariocas resgatando banhistas.", true)
        }));
        l6.Add(new Q("A Sabedoria das Plantas Medicinais Indígenas", new Alt[] {
            new Alt("Os povos originários descobriram propriedades curativas de milhares de plantas, como a copaíba, o andiroba e o jaborandi.", false),
            new Alt("Esse imenso conhecimento botânico tradicional foi herdado e aproveitado pela medicina e farmácia de todo o mundo.", false),
            new Alt("Os indígenas acreditavam que todas as plantas da mata eram venenosas e nunca usavam nenhuma folha.", true)
        }));
        l6.Add(new Q("A Diversidade Indígena Hoje no Brasil", new Alt[] {
            new Alt("O Brasil contemporâneo abriga mais de trezentos povos indígenas diferentes falando mais de duzentas línguas vivas.", false),
            new Alt("Possuem ricas identidades culturais, tradições, costumes próprios e terras demarcadas protegidas pela Constituição.", false),
            new Alt("Todos os indígenas desapareceram do território nacional no ano de 1600 sem deixar descendentes.", true)
        }));

        // Write to temp_his_levels_3_6.lua
        var sb = new StringBuilder();
        for (int lvl = 3; lvl <= 6; lvl++) {
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

        File.WriteAllText("temp_his_levels_3_6.lua", sb.ToString(), Encoding.UTF8);
        Console.WriteLine("Wrote temp_his_levels_3_6.lua with 4 levels (200 questions)");
    }

    static string Escape(string s) {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}
