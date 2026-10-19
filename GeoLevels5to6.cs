using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class GeoLevels5to6 {
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
        levels[5] = new List<Q>();
        levels[6] = new List<Q>();

        // ==========================================
        // NIVEL 5: AMERICA DO SUL E NOSSOS VIZINHOS (50 Questoes)
        // ==========================================
        var l5 = levels[5];
        l5.Add(new Q("A Cidade de Machu Picchu", new Alt[] {
            new Alt("É uma antiga cidade de pedra construída pela civilização Inca no alto das montanhas do Peru.", false),
            new Alt("Foi redescoberta pelo arqueólogo Hiram Bingham em 1911 e é uma das Novas Maravilhas do Mundo.", false),
            new Alt("Fica localizada no litoral da Argentina, à beira de praias cheias de coqueiros tropicais.", true)
        }));
        l5.Add(new Q("A Geleira Perito Moreno", new Alt[] {
            new Alt("Fica localizada na Patagônia Argentina e é uma das geleiras mais acessíveis e famosas do mundo.", false),
            new Alt("Grandes blocos de gelo azul se desprendem de sua parede frontal caindo nas águas do Lago Argentino.", false),
            new Alt("É uma geleira quente feita de vapor de sauna onde turistas tomam banho de sol.", true)
        }));
        l5.Add(new Q("A Estrada da Morte na Bolívia", new Alt[] {
            new Alt("Famosa estrada estreita e sinuosa que desce dos Andes até a região de floresta dos Yungas.", false),
            new Alt("Possui precipícios verticais profundos e atrai ciclistas aventureiros de vários países do mundo.", false),
            new Alt("É uma rodovia subterrânea de oito pistas com ar-condicionado central e piso de vidro.", true)
        }));
        l5.Add(new Q("A Cidade de Ushuaia", new Alt[] {
            new Alt("Localizada no extremo sul da Argentina, é conhecida no mundo como 'A Cidade do Fim do Mundo'.", false),
            new Alt("É o principal ponto de partida para expedições turísticas e científicas rumo ao continente da Antártida.", false),
            new Alt("Fica localizada na linha do Equador e tem clima de selva tropical muito quente.", true)
        }));
        l5.Add(new Q("O Salar de Uyuni", new Alt[] {
            new Alt("É o maior deserto de sal do planeta Terra, localizado no altiplano da Bolívia.", false),
            new Alt("Abriga hotéis rústicos construídos com blocos maciços de sal retirados do próprio solo.", false),
            new Alt("É um pântano cheio de jacarés e piranhas que fica ao nível do mar no Brasil.", true)
        }));
        l5.Add(new Q("O Vulcão Cotopaxi", new Alt[] {
            new Alt("É um dos vulcões ativos mais altos do planeta, situado na Cordilheira dos Andes no Equador.", false),
            new Alt("Seu cone quase perfeito e cume nevado dominam a paisagem próxima à capital Quito.", false),
            new Alt("Fica localizado no centro da Europa, na fronteira entre a França e a Espanha.", true)
        }));
        l5.Add(new Q("A Ilha de Páscoa e o Chile", new Alt[] {
            new Alt("Embora fique a milhares de quilômetros de distância no Oceano Pacífico, pertence ao território do Chile.", false),
            new Alt("Os Moais gigantes foram esculpidos pelo povo nativo Rapa Nui em pedreiras de rocha vulcânica.", false),
            new Alt("Fica situada a apenas cinco minutos de caminhada a pé da praia de Ipanema.", true)
        }));
        l5.Add(new Q("O Deserto do Atacama no Chile", new Alt[] {
            new Alt("Apresenta paisagens surreais como o Vale da Lua, lagoas de sal com flamingos e gêiseres termais.", false),
            new Alt("Existem áreas do deserto onde não há registro meteorológico de chuvas há centenas de anos.", false),
            new Alt("É a floresta com o maior índice de tempestades de granizo e neve de todo o planeta.", true)
        }));
        l5.Add(new Q("As Lhamas e Alpacas", new Alt[] {
            new Alt("São mamíferos parentes dos camelos domesticados pelos povos andinos para transporte e obtenção de lã.", false),
            new Alt("Sua lã espessa e macia é usada há milênios para tecer ponchos e roupas quentes nos Andes.", false),
            new Alt("São peixes de águas profundas que nadam ao longo da costa do Oceano Atlântico.", true)
        }));
        l5.Add(new Q("O Condor-dos-Andes", new Alt[] {
            new Alt("É uma das maiores aves voadoras do planeta Terra, com envergadura de asas que passa de três metros.", false),
            new Alt("Usa correntes de ar quente para planar majestosamente sobre os picos nevados da Cordilheira dos Andes.", false),
            new Alt("É uma ave minúscula menor que um beija-flor que vive dentro de flores de orquídeas.", true)
        }));

        l5.Add(new Q("A Cidade de Buenos Aires", new Alt[] {
            new Alt("Capital da Argentina, conhecida pela famosa Casa Rosada, pelo Obelisco e pelo bairro colorido de La Boca.", false),
            new Alt("O tango é a dança e gênero musical tradicional que nasceu nas ruas e cafés da cidade.", false),
            new Alt("É uma cidadezinha rural no interior do Alasca que não possui transporte público.", true)
        }));
        l5.Add(new Q("O Rio da Prata", new Alt[] {
            new Alt("É o imenso estuário formado pelo encontro das águas dos rios Paraná e Uruguai com o mar.", false),
            new Alt("Separa as capitais Buenos Aires (Argentina) e Montevidéu (Uruguai), com travessias diárias de barco.", false),
            new Alt("É um rio de prata líquida pura onde barcos de madeira pegam fogo ao navegar.", true)
        }));
        l5.Add(new Q("A Cidade de Santiago do Chile", new Alt[] {
            new Alt("Capital do Chile, situada em um vale cercado pela vista deslumbrante dos picos nevados dos Andes.", false),
            new Alt("Abriga o Gran Torre Santiago, um dos arranha-céus mais altos de toda a América do Sul.", false),
            new Alt("É uma ilha caribenha onde a moeda oficial utilizada em todas as lojas é o iene.", true)
        }));
        l5.Add(new Q("O Lago Titicaca e os Incas", new Alt[] {
            new Alt("Segundo antigas lendas incas, foi das águas sagradas desse lago que nasceram os fundadores do Império Inca.", false),
            new Alt("A Ilha do Sol, dentro do lago, abriga dezenas de sítios arqueológicos e terraços agrícolas antigos.", false),
            new Alt("É uma lagoa de água mineral gasosa com sabor de morango no meio da Europa.", true)
        }));
        l5.Add(new Q("A Linha do Equador em Quito", new Alt[] {
            new Alt("O monumento da 'Mitad del Mundo' perto de Quito marca a linha que divide os hemisférios Norte e Sul.", false),
            new Alt("Turistas podem tirar fotos com um pé no Hemisfério Norte e outro pé no Hemisfério Sul ao mesmo tempo.", false),
            new Alt("A Linha do Equador é uma cerca elétrica real de arame farpado que divide os continentes.", true)
        }));
        l5.Add(new Q("O Estreito de Magalhães", new Alt[] {
            new Alt("Passagem marítima natural no extremo sul da América do Sul que liga o Oceano Atlântico ao Pacífico.", false),
            new Alt("Foi descoberto pelo navegador português Fernão de Magalhães em 1520 durante a primeira volta ao mundo.", false),
            new Alt("Fica localizado no interior da França e só pode ser cruzado por bicicletas esportivas.", true)
        }));
        l5.Add(new Q("O Cabo Horn", new Alt[] {
            new Alt("É o ponto mais ao sul do arquipélago da Terra do Fogo, famoso pelas águas tempestuosas e ventos fortes.", false),
            new Alt("Historicamente foi uma das rotas marítimas mais perigosas enfrentadas pelos navios a vela antigos.", false),
            new Alt("É uma praia de areia branca calma com temperatura de 40 graus onde ninguém se molha.", true)
        }));
        l5.Add(new Q("As Linhas de Nazca no Peru", new Alt[] {
            new Alt("São imensos geoglifos gravados no solo do deserto peruano representando animais como macacos e beija-flores.", false),
            new Alt("Seus traços gigantescos foram feitos pelo povo Nazca e só podem ser bem vistos de aviões voando alto.", false),
            new Alt("Foram pintadas com canetas esferográficas modernas por estudantes em uma feira escolar.", true)
        }));
        l5.Add(new Q("O Monte Aconcágua", new Alt[] {
            new Alt("Localizado na Argentina perto da fronteira chilena, é a montanha mais alta de todo o continente americano.", false),
            new Alt("Tem quase sete mil metros de altitude e atrai montanhistas experientes do mundo todo.", false),
            new Alt("É uma montanha oca de madeira compensada construída para filmar comerciais de TV.", true)
        }));
        l5.Add(new Q("A Cidade de Bogotá", new Alt[] {
            new Alt("Capital da Colômbia, localizada a mais de 2.600 metros de altitude em um planalto da Cordilheira dos Andes.", false),
            new Alt("O Museu do Ouro da cidade preserva a maior coleção de artefatos de ouro pré-colombianos do mundo.", false),
            new Alt("Fica situada em uma caverna submarina no fundo do Oceano Glacial Ártico.", true)
        }));

        l5.Add(new Q("A Culinária Peruana", new Alt[] {
            new Alt("É famosa mundialmente pelo ceviche, prato de peixe fresco marinado no suco de limão com cebola roxa.", false),
            new Alt("O Peru cultiva mais de três mil variedades diferentes de batatas nativas de várias cores e formas.", false),
            new Alt("Os peruanos se alimentam exclusivamente de queijo suíço derretido e pão francês.", true)
        }));
        l5.Add(new Q("A Represa de Itaipu", new Alt[] {
            new Alt("Construída no Rio Paraná na fronteira entre Brasil e Paraguai, é uma das maiores usinas hidrelétricas do mundo.", false),
            new Alt("É uma empresa binacional que fornece grande parte da energia elétrica consumida no Paraguai e no Brasil.", false),
            new Alt("Fica localizada no deserto australiano e gera energia a partir de cactos secos.", true)
        }));
        l5.Add(new Q("A Cidade de Montevidéu", new Alt[] {
            new Alt("Capital e maior cidade do Uruguai, famosa por sua longa orla à beira do Rio da Prata chamada de Rambla.", false),
            new Alt("O mate (chimarrão) é uma bebida tradicional consumida diariamente pelas pessoas nas ruas e praças.", false),
            new Alt("Fica situada no cume do Monte Everest e só é acessada por teleféricos espaciais.", true)
        }));
        l5.Add(new Q("A Bacia do Rio Orinoco", new Alt[] {
            new Alt("É uma das maiores bacias hidrográficas da América do Sul, cortando vastas planícies da Venezuela e Colômbia.", false),
            new Alt("Abriga grande diversidade de vida aquática como o peixe-boi, a lontra-gigante e o boto-do-orinoco.", false),
            new Alt("É um riacho de água com açúcar que corre dentro de um parque em Londres.", true)
        }));
        l5.Add(new Q("O Salto Ángel na Venezuela", new Alt[] {
            new Alt("Cachoeira mais alta da Terra, com quase mil metros de queda d'água no Parque Nacional de Canaima.", false),
            new Alt("As montanhas de topo plano de onde a água despenca são chamadas de tepuis e são antiquíssimas.", false),
            new Alt("A água cai dentro de um balde de plástico de lavar roupa no quintal de uma casa.", true)
        }));
        l5.Add(new Q("O Parque Nacional Torres del Paine", new Alt[] {
            new Alt("Famoso parque no sul do Chile conhecido por seus três picos gigantes de granito que parecem torres.", false),
            new Alt("Abriga geleiras cintilantes, lagos de cor azul-turquesa e manadas de guanacos selvagens.", false),
            new Alt("É uma praça de concreto no centro de Madri com brinquedos de madeira para crianças.", true)
        }));
        l5.Add(new Q("A Cidade de La Paz", new Alt[] {
            new Alt("Sede do governo da Bolívia, é a capital administrativa com a maior altitude de todo o planeta Terra.", false),
            new Alt("Possui a maior e mais moderna rede urbana de teleféricos do mundo, usada como transporte público diário.", false),
            new Alt("Fica localizada em uma plataforma de petróleo flutuante no Mar do Caribe.", true)
        }));
        l5.Add(new Q("O Canal de Beagle", new Alt[] {
            new Alt("Estreito marítimo na Terra do Fogo que separa a ilha principal de pequenas ilhas do extremo sul.", false),
            new Alt("Recebeu esse nome em homenagem ao navio HMS Beagle, que levou o cientista Charles Darwin na viagem.", false),
            new Alt("É uma piscina olímpica aquecida construída dentro de uma escola na cidade de Tóquio.", true)
        }));
        l5.Add(new Q("O Chaco Americano", new Alt[] {
            new Alt("Extensa região de planície semiárida com florestas de arbustos e espinhos entre Paraguai, Bolívia e Argentina.", false),
            new Alt("Abriga animais resistentes como o tatu-canastra, tamanduás-bandeira e onças-pintadas.", false),
            new Alt("É um oceano de água salgada onde navegam navios transatlânticos de luxo.", true)
        }));
        l5.Add(new Q("A Cidade de Cusco", new Alt[] {
            new Alt("Histórica cidade do Peru que foi a grandiosa capital sagrada de todo o Império Inca.", false),
            new Alt("Seus muros de pedra incas foram esculpidos com blocos gigantescos que se encaixam sem cimento.", false),
            new Alt("Foi construída no ano de 2021 com tijolos de plástico para funcionar como rodoviária.", true)
        }));

        l5.Add(new Q("O Arquipélago da Terra do Fogo", new Alt[] {
            new Alt("Grupo de ilhas no extremo sul da América do Sul dividido entre os territórios da Argentina e do Chile.", false),
            new Alt("Recebeu esse nome dos primeiros navegantes europeus ao avistarem as fogueiras acesas pelos povos indígenas.", false),
            new Alt("É um vulcão ativo coberto de lava fervente onde as pedras nunca se resfriam.", true)
        }));
        l5.Add(new Q("A Cordilheira Branca no Peru", new Alt[] {
            new Alt("Cadeia montanhosa nos Andes peruanos famosa por ter a maior concentração de geleiras tropicais do mundo.", false),
            new Alt("O monte Huascarán é o ponto mais alto de todo o território peruano, coberto de gelo e neve.", false),
            new Alt("É uma planície de areia quente onde as pessoas plantam cana-de-açúcar e melancia.", true)
        }));
        l5.Add(new Q("O Boto-Cor-de-Rosa", new Alt[] {
            new Alt("É a maior espécie de golfinho de água doce do mundo, vivendo nos rios das bacias Amazônica e do Orinoco.", false),
            new Alt("Possui o corpo flexível para manobrar com agilidade entre os troncos de árvores na floresta inundada.", false),
            new Alt("É um pássaro marinho que voa a cem quilômetros por hora em direção ao Polo Sul.", true)
        }));
        l5.Add(new Q("A Cidade de Medellín", new Alt[] {
            new Alt("Segunda maior cidade da Colômbia, conhecida como a Cidade da Eterna Primavera por seu clima ameno.", false),
            new Alt("Transformou sua mobilidade urbana com escadas rolantes ao ar livre e teleféricos nos morros.", false),
            new Alt("Fica localizada em uma balsa à deriva nas águas congeladas do Oceano Ártico.", true)
        }));
        l5.Add(new Q("O Vulcão Chimborazo", new Alt[] {
            new Alt("Fica no Equador e, devido ao formato bojudo da Terra na linha do Equador, seu cume é o ponto mais perto do espaço.", false),
            new Alt("Se medido a partir do centro do planeta Terra, seu topo fica mais distante que o cume do Everest.", false),
            new Alt("É uma colina baixa coberta de grama no jardim de um hotel na cidade de Londres.", true)
        }));
        l5.Add(new Q("A Culinária Argentina", new Alt[] {
            new Alt("O churrasco tradicional (asado) preparado na grelha e as empanadas de carne são ícones gastronômicos.", false),
            new Alt("O doce de leite argentino e os alfajores cobertos com chocolate são apreciados mundialmente.", false),
            new Alt("A refeição básica de todas as famílias argentinas é comer sopa de gelo ralado com açúcar.", true)
        }));
        l5.Add(new Q("A Cidade de Cartagena das Índias", new Alt[] {
            new Alt("Cidade histórica na costa caribenha da Colômbia cercada por imensas muralhas de pedra e fortes coloniais.", false),
            new Alt("Suas casas coloniais coloridas com varandas floridas são Patrimônio Mundial da UNESCO.", false),
            new Alt("Fica no meio do deserto da Namíbia na África onde nunca ninguém viu o mar.", true)
        }));
        l5.Add(new Q("O Pinguim-de-Magalhães", new Alt[] {
            new Alt("Espécie de pinguim que habita as costas frias do sul da Argentina e do Chile, nidificando em colônias.", false),
            new Alt("Durante o inverno migra para o norte em busca de águas mais mornas, chegando a praias do Brasil.", false),
            new Alt("É uma ave que voa pelo céu tão alto quanto um jato comercial de passageiros.", true)
        }));
        l5.Add(new Q("O Trem das Nuvens na Argentina", new Alt[] {
            new Alt("Famosa ferrovia de grande altitude na província de Salta que sobe os Andes a mais de 4.200 metros.", false),
            new Alt("Cruza viadutos metálicos impressionantes como o Viaduto La Polvorilla parecendo flutuar nas nuvens.", false),
            new Alt("É um trem que viaja no fundo do oceano em trilhos instalados em recifes de corais.", true)
        }));
        l5.Add(new Q("O Vale Sagrado dos Incas", new Alt[] {
            new Alt("Fértil vale do rio Urubamba no Peru pontilhado por aldeias tradicionais e imponentes fortalezas incas.", false),
            new Alt("Abriga as ruínas de Ollantaytambo e os curiosos terraços agrícolas circulares de Moray.", false),
            new Alt("É um túnel de metrô de cimento construído embaixo da cidade de Nova York.", true)
        }));

        l5.Add(new Q("A Floresta de Nuvens de Mindo", new Alt[] {
            new Alt("Reserva ecológica no Equador onde a umidade constante forma florestas envoltas em névoa cheias de orquídeas.", false),
            new Alt("É um dos melhores destinos do mundo para observação de aves, abrigando centenas de tipos de beija-flores.", false),
            new Alt("É uma praia de areia seca onde não cresce nenhuma árvore ou planta com flores.", true)
        }));
        l5.Add(new Q("A Ilha Solitária de Robinson Crusoé", new Alt[] {
            new Alt("Pertence ao arquipélago Juan Fernández no Chile, onde o marinheiro Alexander Selkirk viveu isolado por anos.", false),
            new Alt("A história real desse náufrago serviu de inspiração para o famoso livro clássico de Daniel Defoe.", false),
            new Alt("Fica situada no meio do rio Tietê na cidade de São Paulo, cercada de trânsito.", true)
        }));
        l5.Add(new Q("O Vinho e os Pampas", new Alt[] {
            new Alt("A região de Mendoza, na Argentina, é famosa mundialmente pela produção de vinhos nas encostas dos Andes.", false),
            new Alt("Os pampas são extensas planícies de pastagem onde os tradicionais gaúchos cuidam de rebanhos de gado.", false),
            new Alt("Nos pampas, a temperatura média é de oitenta graus e a terra é feita de carvão queimado.", true)
        }));
        l5.Add(new Q("O Parque Nacional Madidi na Bolívia", new Alt[] {
            new Alt("É uma das áreas protegidas com maior biodiversidade de plantas e animais de todo o planeta Terra.", false),
            new Alt("Estende-se desde montanhas nevadas dos Andes até as planícies de floresta tropical úmida da Amazônia.", false),
            new Alt("É um estacionamento de caminhões de asfalto no centro de uma cidade industrial.", true)
        }));
        l5.Add(new Q("As Salineras de Maras no Peru", new Alt[] {
            new Alt("São milhares de piscinas rasas em degraus nas encostas de uma montanha onde água salgada subterrânea evapora.", false),
            new Alt("O sal rosa é extraído artesanalmente pelas famílias locais desde a época anterior ao Império Inca.", false),
            new Alt("São piscinas olímpicas aquecidas construídas com ladrilhos azuis para campeonatos esportivos.", true)
        }));
        l5.Add(new Q("A Culinária Colombiana", new Alt[] {
            new Alt("Pratos como a Bandeja Paisa (com feijão, arroz, carne e abacate) e as arepas de milho são tradicionais.", false),
            new Alt("O café colombiano suave cultivado nas montanhas andinas é premiado internacionalmente por sua qualidade.", false),
            new Alt("O prato nacional obrigatório da Colômbia é comer folhas de pinheiro cruas no almoço.", true)
        }));
        l5.Add(new Q("A Cidade de Guayaquil", new Alt[] {
            new Alt("É a cidade mais populosa e o principal porto marítimo do Equador, banhada pelo rio Guayas.", false),
            new Alt("O parque Semánario é famoso por dezenas de iguanas mansas que vivem soltas entre as árvores e pedestres.", false),
            new Alt("Fica localizada dentro de uma geleira congelada no Círculo Polar Antártico.", true)
        }));
        l5.Add(new Q("O Parque Nacional dos Glaciares", new Alt[] {
            new Alt("Fica na Patagônia Argentina e preserva o maior manto de gelo continental fora da Antártida e Groenlândia.", false),
            new Alt("Abriga montanhas pontiagudas de granito famosas mundialmente como o Monte Fitz Roy e o Cerro Torre.", false),
            new Alt("É uma praia de dunas de areia quente onde as pessoas andam de camelo sob o sol forte.", true)
        }));
        l5.Add(new Q("A Ferrovia Central Andina", new Alt[] {
            new Alt("É uma das ferrovias de bitola padrão mais altas do mundo, cruzando túneis e pontes nos Andes peruanos.", false),
            new Alt("O trem sobe até quase 4.800 metros de altitude enfrentando curvas em zigue-zague desafiadoras.", false),
            new Alt("É uma linha de metrô subterrâneo que liga diretamente a América do Sul até a Europa.", true)
        }));
        l5.Add(new Q("A América do Sul e sua Diversidade", new Alt[] {
            new Alt("Abriga desde a maior floresta tropical e o rio mais volumoso até o deserto mais árido e a cordilheira mais longa.", false),
            new Alt("É composta por doze países independentes e o território ultramarino da Guiana Francesa.", false),
            new Alt("É um continente totalmente plano onde não existe nenhuma montanha, rio ou praia natural.", true)
        }));

        // ==========================================
        // NIVEL 6: O BRASIL E SUAS 5 REGIOES (50 Questoes)
        // ==========================================
        var l6 = levels[6];
        l6.Add(new Q("O Cristo Redentor no Rio de Janeiro", new Alt[] {
            new Alt("É uma estátua de trinta metros de altura instalada no topo do Morro do Corcovado no Rio de Janeiro.", false),
            new Alt("Foi eleita uma das Novas Sete Maravilhas do Mundo moderno e é um dos maiores cartões-postais do Brasil.", false),
            new Alt("Foi esculpida em um bloco de manteiga amarela e derrete todo verão ao meio-dia.", true)
        }));
        l6.Add(new Q("O Pão de Açúcar", new Alt[] {
            new Alt("É um monólito de rocha de granito à beira da Baía de Guanabara no Rio de Janeiro.", false),
            new Alt("O famoso teleférico de bondinho transporta passageiros entre os morros da Urca e do Pão de Açúcar.", false),
            new Alt("É um pão doce gigante assado por padeiros cariocas e colocado no morro para enfeitar.", true)
        }));
        l6.Add(new Q("A Capital Federal Brasília", new Alt[] {
            new Alt("Foi construída no Planalto Central para ser a nova capital do Brasil, inaugurada em 1960.", false),
            new Alt("Seu plano urbanístico foi projetado por Lúcio Costa em formato de avião e os palácios por Oscar Niemeyer.", false),
            new Alt("Fica localizada em uma ilha no meio do Oceano Pacífico e não possui prédios de governo.", true)
        }));
        l6.Add(new Q("O Encontro das Águas em Manaus", new Alt[] {
            new Alt("É o fenômeno onde as águas escuras do Rio Negro e as águas barrentas do Rio Solimões correm lado a lado sem se misturar.", false),
            new Alt("A diferença de velocidade, densidade e temperatura das águas impede que se misturem por quilômetros.", false),
            new Alt("As águas não se misturam porque operários colocaram uma placa de vidro transparente no meio do rio.", true)
        }));
        l6.Add(new Q("O Teatro Amazonas", new Alt[] {
            new Alt("É uma imponente casa de ópera inaugurada em 1896 em Manaus durante o ciclo da borracha na Amazônia.", false),
            new Alt("Sua cúpula externa é decorada com mais de 36 mil peças de cerâmica com as cores da bandeira brasileira.", false),
            new Alt("Foi construído com fardos de palha seca e funciona como celeiro de ovelhas no campo.", true)
        }));
        l6.Add(new Q("A Chapada Diamantina na Bahia", new Alt[] {
            new Alt("É uma região de serras e cânions no coração da Bahia famosa por cachoeiras monumentais e grutas.", false),
            new Alt("O Poço Encantado e o Poço Azul são famosos por suas águas subterrâneas de azul cristalino transparente.", false),
            new Alt("É um deserto de dunas de areia quente onde nunca nasceu nenhuma planta ou árvore.", true)
        }));
        l6.Add(new Q("O Pelourinho em Salvador", new Alt[] {
            new Alt("É o centro histórico de Salvador, na Bahia, famoso por seus casarões coloniais coloridos e igrejas barrocas.", false),
            new Alt("É o coração da cultura afro-brasileira, com o som marcante dos tambores do Olodum e a capoeira.", false),
            new Alt("É um bairro de arranha-céus futuristas de vidro espelhado construído em 2022.", true)
        }));
        l6.Add(new Q("O Arquipélago de Fernando de Noronha", new Alt[] {
            new Alt("É um arquipélago vulcânico brasileiro no Oceano Atlântico pertencente ao estado de Pernambuco.", false),
            new Alt("É famoso mundialmente por praias de águas claras, santuário de golfinhos-rotadores e tartarugas marinhas.", false),
            new Alt("Fica situado no interior do estado de Minas Gerais cercado por fazendas de café.", true)
        }));
        l6.Add(new Q("O Frevo de Pernambuco", new Alt[] {
            new Alt("É um ritmo musical e dança frenética tradicional do Carnaval de Recife e Olinda.", false),
            new Alt("Os dançarinos de frevo usam passos acrobáticos ágeis empunhando pequenas sombrinhas coloridas.", false),
            new Alt("É uma dança lenta que exige que as pessoas fiquem dormindo deitadas no chão da sala.", true)
        }));
        l6.Add(new Q("Os Lençóis Maranhenses", new Alt[] {
            new Alt("É um parque nacional no Maranhão formado por milhares de dunas de areia branca pontilhadas por lagoas de água doce.", false),
            new Alt("As lagoas cristalinas de água da chuva se formam entre as dunas durante a estação chuvosa do ano.", false),
            new Alt("São cobertores gigantescos de tecido costurados por artesãos e jogados na praia para secar.", true)
        }));

        l6.Add(new Q("O Rio São Francisco", new Alt[] {
            new Alt("Apelidado carinhosamente de 'Velho Chico', é um dos rios mais importantes e históricos do Brasil.", false),
            new Alt("Nasce na Serra da Canastra em Minas Gerais e atravessa o sertão nordestino até desaguar no mar.", false),
            new Alt("É um rio subterrâneo que corre por dentro de tubulações de plástico na Europa.", true)
        }));
        l6.Add(new Q("O Pantanal Mato-Grossense", new Alt[] {
            new Alt("É um dos melhores lugares do planeta para avistar vida selvagem como onças-pintadas, capivaras e araras.", false),
            new Alt("O tuiuiú é uma ave pernalta grande com pescoço vermelho que se tornou o símbolo do Pantanal.", false),
            new Alt("É uma montanha pontiaguda de cinco mil metros de altitude coberta por geleiras permanentes.", true)
        }));
        l6.Add(new Q("A Chapada dos Guimarães", new Alt[] {
            new Alt("Fica no Mato Grosso e é famosa por paredões de arenito alaranjado, mirantes grandiosos e cachoeiras.", false),
            new Alt("O Parque Nacional abriga o famoso Véu de Noiva, uma cachoeira que despenca de um desfiladeiro.", false),
            new Alt("É uma ilha no meio do Oceano Atlântico cercada por recifes de corais tropicais.", true)
        }));
        l6.Add(new Q("Bonito no Mato Grosso do Sul", new Alt[] {
            new Alt("É um polo mundial de ecoturismo famoso por rios de águas extremamente cristalinas cheios de peixes.", false),
            new Alt("A alta concentração de calcário na água decanta as impurezas e deixa os rios transparentes como aquários.", false),
            new Alt("É uma cidade industrial poluída onde é proibido qualquer pessoa tomar banho de rio.", true)
        }));
        l6.Add(new Q("A Avenida Paulista em São Paulo", new Alt[] {
            new Alt("É uma das avenidas mais famosas do Brasil e o principal centro financeiro e cultural da cidade de São Paulo.", false),
            new Alt("Abriga o Museu de Arte de São Paulo (MASP), famoso por seu vão livre sustentado por quatro pilares vermelhos.", false),
            new Alt("É uma estrada de terra batida no meio da selva onde só passam carroças puxadas por bois.", true)
        }));
        l6.Add(new Q("A Cidade de Ouro Preto", new Alt[] {
            new Alt("Histórica cidade de Minas Gerais famosa por suas ladeiras de paralelepípedo, casario colonial e igrejas barrocas.", false),
            new Alt("Foi o centro da corrida do ouro no século XVIII e preserva obras de arte esculpidas pelo mestre Aleijadinho.", false),
            new Alt("É uma plataforma flutuante no mar onde se extrai sal marinho para cozinhar.", true)
        }));
        l6.Add(new Q("A Culinária Mineira", new Alt[] {
            new Alt("Pratos tradicionais incluem o pão de queijo quentinho, feijão-tropeiro, tutu de feijão e queijo minas.", false),
            new Alt("As cozinhas mineiras tradicionais utilizam o fogão a lenha e panelas de ferro e pedra-sabão.", false),
            new Alt("A refeição básica de Minas Gerais é comer sopa de algas marinhas cruas com gelo moído.", true)
        }));
        l6.Add(new Q("As Serras Gaúchas", new Alt[] {
            new Alt("Região montanhosa no Rio Grande do Sul famosa pelo clima frio, arquitetura europeia e cultivo de maçãs e uvas.", false),
            new Alt("Cidades como Gramado e Canela atraem milhões de turistas com festivais de cinema e fábricas de chocolate.", false),
            new Alt("É uma região de clima de deserto árido onde as pessoas andam em camelos pelas dunas.", true)
        }));
        l6.Add(new Q("O Chimarrão Gaúcho", new Alt[] {
            new Alt("É a bebida tradicional do Rio Grande do Sul preparada com erva-mate servida em uma cuia com bomba metálica.", false),
            new Alt("É um símbolo de hospitalidade e amizade compartilhada em rodas de conversa entre os gaúchos.", false),
            new Alt("É um suco de melancia gelado servido com refrigerante e canudos plásticos descartáveis.", true)
        }));
        l6.Add(new Q("A Ilha de Santa Catarina (Florianópolis)", new Alt[] {
            new Alt("Capital de Santa Catarina, famosa por suas dezenas de praias procuradas para o surfe e lagoas charmosas.", false),
            new Alt("A histórica Ponte Hercílio Luz é uma ponte pênsil que se tornou o maior cartão-postal da cidade.", false),
            new Alt("Fica localizada nas margens do Rio Nilo no continente da África.", true)
        }));

        l6.Add(new Q("A Floresta Nacional dos Carajás", new Alt[] {
            new Alt("Fica no estado do Pará e abriga uma das maiores jazidas de minério de ferro de alta pureza do planeta.", false),
            new Alt("A extração de minerais convive com áreas de preservação ambiental da rica floresta amazônica.", false),
            new Alt("É uma praia de areia dourada onde turistas internacionais praticam mergulho em corais.", true)
        }));
        l6.Add(new Q("O Festival Folclórico de Parintins", new Alt[] {
            new Alt("Famosa festa folclórica do Amazonas onde os bois Garantido (vermelho) e Caprichoso (azul) duelam em arena.", false),
            new Alt("Apresenta toadas musicais animadas, lendas indígenas e grandiosas alegorias no Bumbódromo.", false),
            new Alt("É um campeonato de futebol jogado no gelo por jogadores de patins na Europa.", true)
        }));
        l6.Add(new Q("O Círio de Nazaré em Belém", new Alt[] {
            new Alt("É uma das maiores procissões religiosas do mundo, reunindo milhões de fiéis nas ruas de Belém do Pará.", false),
            new Alt("A corda do Círio é um dos símbolos mais marcantes onde os devotos disputam um espaço para segurar com fé.", false),
            new Alt("É uma corrida de carros de Fórmula 1 disputada em uma pista de asfalto veloz.", true)
        }));
        l6.Add(new Q("A Culinária Paraense", new Alt[] {
            new Alt("Usa ingredientes únicos da Amazônia como o açaí tradicional, peixes de rio, tucupi e o jambu que amortece a boca.", false),
            new Alt("Pratos como o pato no tucupi e o tacacá servido quente em cuias são patrimônios da culinária do Pará.", false),
            new Alt("Consiste em comer hambúrgueres industriais com queijo processado em bandejas plásticas.", true)
        }));
        l6.Add(new Q("O Parque Nacional da Serra da Capivara", new Alt[] {
            new Alt("Fica no Piauí e abriga a maior e mais antiga concentração de pinturas rupestres pré-históricas das Américas.", false),
            new Alt("A arqueóloga Niède Guidon liderou pesquisas no local comprovando a antiguidade do homem nas Américas.", false),
            new Alt("Fica no centro de Londres e foi construído por reis ingleses no século passado.", true)
        }));
        l6.Add(new Q("O Delta do Parnaíba", new Alt[] {
            new Alt("É o único delta em mar aberto das Américas, localizado na divisa entre os estados do Piauí e Maranhão.", false),
            new Alt("O rio se divide em vários braços de água formando um arquipélago de ilhas, mangues e dunas.", false),
            new Alt("É uma cachoeira subterrânea de cinquenta metros localizada dentro de uma mina de carvão.", true)
        }));
        l6.Add(new Q("A Cidade de Olinda", new Alt[] {
            new Alt("Histórica cidade de Pernambuco famosa por suas ladeiras floridas, casario colonial e igrejas com vista para o mar.", false),
            new Alt("Seu Carnaval é mundialmente conhecido pelo desfile de bonecos gigantes de quatro metros pelas ruas.", false),
            new Alt("É uma cidadezinha moderna construída com tendas de lona no Polo Sul.", true)
        }));
        l6.Add(new Q("O Farol da Barra em Salvador", new Alt[] {
            new Alt("Fica situado no Forte de Santo Antônio da Barra, sendo um dos faróis mais antigos do continente americano.", false),
            new Alt("Marca a entrada da Baía de Todos-os-Santos e é um dos locais mais concorridos para assistir ao pôr do sol.", false),
            new Alt("É uma antena parabólica de transmissão de televisão instalada no teto de um shopping.", true)
        }));
        l6.Add(new Q("O Parque Estadual do Jalapão", new Alt[] {
            new Alt("Fica no estado do Tocantins e é famoso por fervedouros de águas cristalinas onde a pressão impede o banhista de afundar.", false),
            new Alt("Possui dunas de areia dourada, cachoeiras e o artesanato tradicional feito com o capim-dourado.", false),
            new Alt("É uma fábrica de computadores e celulares no centro financeiro de Nova York.", true)
        }));
        l6.Add(new Q("A Cidade de Goiânia", new Alt[] {
            new Alt("É a capital do estado de Goiás, planejada e construída na década de 1930 com belos prédios em estilo Art Déco.", false),
            new Alt("É conhecida por sua grande quantidade de parques públicos arborizados e pela forte cultura sertaneja.", false),
            new Alt("É uma ilha no meio do Oceano Índico onde não existem carros nem ruas asfaltadas.", true)
        }));

        l6.Add(new Q("O Mercado Municipal de São Paulo (Mercadão)", new Alt[] {
            new Alt("Famoso mercado histórico no centro de São Paulo conhecido por seus vitrais coloridos e variedade de frutas raras.", false),
            new Alt("O sanduíche clássico de mortadela e o pastel de bacalhau são atrações gastronômicas apreciadas por turistas.", false),
            new Alt("É uma fábrica de automóveis pesados onde operários montam motores a diesel.", true)
        }));
        l6.Add(new Q("A Cidade de Santos e o Maior Porto", new Alt[] {
            new Alt("Fica no litoral paulista e abriga o maior porto da América Latina, por onde passa grande parte do café e grãos.", false),
            new Alt("Possui o maior jardim de orla de praia do mundo em extensão, registrado no livro dos recordes.", false),
            new Alt("Fica situada a quatro mil metros de altitude no topo da Cordilheira dos Andes.", true)
        }));
        l6.Add(new Q("A Serra dos Órgãos em Teresópolis", new Alt[] {
            new Alt("Parque Nacional no Rio de Janeiro famoso pelo pico rochoso chamado Dedo de Deus que parece apontar para o céu.", false),
            new Alt("É um paraíso para montanhistas e praticantes de trilhas com vistas espetaculares da Mata Atlântica.", false),
            new Alt("É um lago subterrâneo sem oxigênio localizado no centro da crosta terrestre.", true)
        }));
        l6.Add(new Q("A Cidade de Tiradentes", new Alt[] {
            new Alt("Histórica cidade de Minas Gerais com ruas de pedra calçada e igrejas antigas dedicadas a Santo Antônio.", false),
            new Alt("O passeio de trem a vapor chamado Maria Fumaça liga Tiradentes à vizinha cidade de São João del-Rei.", false),
            new Alt("É uma metrópole de cinquenta milhões de habitantes com arranha-céus de cem andares.", true)
        }));
        l6.Add(new Q("A Cidade de Curitiba", new Alt[] {
            new Alt("Capital do Paraná, reconhecida internacionalmente pelo planejamento urbano, parques verdes e transporte de ônibus canaleta.", false),
            new Alt("A estufa metálica de vidro do Jardim Botânico de Curitiba é o principal cartão-postal da cidade.", false),
            new Alt("Fica localizada nas dunas de areia do deserto do Saara no norte da África.", true)
        }));
        l6.Add(new Q("A Estrada de Ferro Curitiba-Morretes", new Alt[] {
            new Alt("Histórica ferrovia que desce a Serra do Mar paranaense cruzando pontes e viadutos arrojados no meio da mata atlântica.", false),
            new Alt("O Viaduto do Carvalho parece fazer o trem flutuar no ar sobre o precipício das montanhas.", false),
            new Alt("É uma ferrovia que corre em círculos dentro de uma sala de brinquedos fechada.", true)
        }));
        l6.Add(new Q("As Ruínas de São Miguel das Missões", new Alt[] {
            new Alt("Ficam no Rio Grande do Sul e preservam vestígios monumentais das antigas missões jesuíticas com os povos guaranis.", false),
            new Alt("As ruínas da grande igreja de pedra são Patrimônio Cultural da Humanidade protegido pela UNESCO.", false),
            new Alt("Foram construídas em 2020 para funcionar como shopping de eletrônicos no litoral.", true)
        }));
        l6.Add(new Q("O Cânion do Itaimbezinho", new Alt[] {
            new Alt("Fica no Parque Nacional dos Aparados da Serra, na divisa entre Rio Grande do Sul e Santa Catarina.", false),
            new Alt("Possui paredões de rocha basáltica verticais com mais de setecentos metros de profundidade e cachoeiras.", false),
            new Alt("Foi escavado por crianças em uma caixa de areia durante o recreio da escola.", true)
        }));
        l6.Add(new Q("A Dança das Fitas e o Fandango", new Alt[] {
            new Alt("São danças tradicionais do folclore do Sul do Brasil, marcadas por passos coordenados e música de viola e gaita.", false),
            new Alt("Na dança das fitas, os dançarinos trançam e destrançam fitas coloridas presas ao topo de um mastro central.", false),
            new Alt("É uma competição de artes marciais com espadas de aço travada no alto de telhados.", true)
        }));
        l6.Add(new Q("O Vale dos Vinhedos em Bento Gonçalves", new Alt[] {
            new Alt("Região gaúcha colonizada por imigrantes italianos famosa pelas colinas cultivadas com parreirais de uvas.", false),
            new Alt("Preserva tradições gastronômicas italianas com queijos, massas caseiras, polenta e sucos de uva artesanais.", false),
            new Alt("É uma plantação de arroz no meio de um pântano habitado por jacarés selvagens.", true)
        }));

        l6.Add(new Q("A Ilha do Marajó", new Alt[] {
            new Alt("Localizada no Pará, é a maior ilha fluviomarinha do mundo, banhada pelas águas do Rio Amazonas e do Oceano Atlântico.", false),
            new Alt("É famosa por seus rebanhos de búfalos que andam pelas ruas e pela cerâmica marajoara ancestral.", false),
            new Alt("É uma geleira coberta por neve perpétua no meio do oceano Ártico.", true)
        }));
        l6.Add(new Q("O Parque Nacional de Anavilhanas", new Alt[] {
            new Alt("Fica no Rio Negro, no Amazonas, formando um dos maiores arquipélagos fluviais de água doce do mundo com centenas de ilhas.", false),
            new Alt("Na época das cheias, a floresta de igapó fica submersa e os barcos navegam por entre as copas das árvores.", false),
            new Alt("É um campo de dunas de areia seca onde não passa nenhuma gota de água.", true)
        }));
        l6.Add(new Q("O Pico da Neblina", new Alt[] {
            new Alt("Localizado na Serra do Imeri, no estado do Amazonas, é o ponto mais alto de todo o território brasileiro.", false),
            new Alt("Tem quase três mil metros de altitude e fica em uma área protegida próxima à fronteira com a Venezuela.", false),
            new Alt("Fica localizado no litoral do Rio de Janeiro bem em frente à praia de Copacabana.", true)
        }));
        l6.Add(new Q("A Cidade de Belém e o Ver-o-Peso", new Alt[] {
            new Alt("O mercado Ver-o-Peso é uma feira histórica à beira da baía famosa pela venda de peixes frescos, ervas e frutas amazônicas.", false),
            new Alt("A cidade é repleta de mangueiras centenárias que fornecem sombra agradável contra o calor equatorial.", false),
            new Alt("É uma cidade construída em cima de uma balsa à deriva nas águas da Antártida.", true)
        }));
        l6.Add(new Q("A Rota das Emoções no Nordeste", new Alt[] {
            new Alt("É um famoso roteiro turístico que une os Lençóis Maranhenses, o Delta do Parnaíba e as praias de Jericoacoara.", false),
            new Alt("Atravessa três estados do Nordeste brasileiro com paisagens que misturam dunas, manguezais e lagoas.", false),
            new Alt("É uma linha de metrô subterrâneo que liga o Brasil até o continente da Europa.", true)
        }));
        l6.Add(new Q("A Praia de Jericoacoara no Ceará", new Alt[] {
            new Alt("Famosa vila de pescadores com ruas de areia cercada por dunas douradas e a célebre formação rochosa da Pedra Furada.", false),
            new Alt("A Duna do Pôr do Sol é o ponto de encontro diário onde centenas de pessoas assistem ao sol descer no mar.", false),
            new Alt("É uma estação de esqui alpina no alto de uma montanha congelada na Suíça.", true)
        }));
        l6.Add(new Q("O Bairro da Liberdade em São Paulo", new Alt[] {
            new Alt("É o maior reduto da comunidade japonesa e oriental fora do Japão, com lanternas suzuran vermelhas nas ruas.", false),
            new Alt("Aos fins de semana, a feira da praça da Liberdade atrai multidões com comidas típicas asiáticas e artesanato.", false),
            new Alt("É um povoado indígena isolado no meio da selva amazônica onde não há eletricidade.", true)
        }));
        l6.Add(new Q("As Cidades Históricas de Minas Gerais", new Alt[] {
            new Alt("Cidades como Mariana, Congonhas, Diamantina e Tiradentes preservam o ciclo do ouro e dos diamantes do Brasil colonial.", false),
            new Alt("Em Congonhas, os doze profetas esculpidos em pedra-sabão por Aleijadinho decoram o adro do santuário.", false),
            new Alt("Foram construídas em 2015 por robôs impressos em 3D para competições esportivas.", true)
        }));
        l6.Add(new Q("O Parque Nacional de São Joaquim", new Alt[] {
            new Alt("Fica na serra catarinense e é uma das regiões mais frias do Brasil, onde a neve costuma cair durante o inverno.", false),
            new Alt("A Pedra Furada é uma impressionante janela natural de rocha que se abre para os cânions da serra.", false),
            new Alt("É uma praia de águas quentes equatoriais com recifes cheios de tubarões-baleia.", true)
        }));
        l6.Add(new Q("O Brasil e sua Extensão Continental", new Alt[] {
            new Alt("É o quinto maior país do mundo em área, abrangendo três fusos horários e fazendo fronteira com dez países vizinhos.", false),
            new Alt("Possui mais de sete mil quilômetros de litoral banhado pelas águas mornas do Oceano Atlântico.", false),
            new Alt("É um pequeno país insular no Oceano Pacífico com tamanho menor que a cidade do Rio de Janeiro.", true)
        }));

        SaveLevels(levels, "temp_geo_levels_5_6.lua");
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
