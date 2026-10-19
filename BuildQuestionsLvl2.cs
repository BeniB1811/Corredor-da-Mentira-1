using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class BuildQuestionsLvl2 {
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

        // GEOGRAFIA NIVEL 2 (50 Questoes - Natureza, Vulcoes, Relevos, Biomas, Rios e Fenomenos)
        geoQ.Add(new Q("Os Vulcões", new Alt[] {
            new Alt("São aberturas na crosta terrestre por onde sobem magma quente, cinzas e gases.", false),
            new Alt("Quando o magma atinge a superfície da Terra e escorre, passa a ser chamado de lava.", false),
            new Alt("Quando entram em erupção, os vulcões cospem blocos maciços de gelo congelado.", true)
        }));
        geoQ.Add(new Q("Círculo de Fogo do Pacífico", new Alt[] {
            new Alt("É uma vasta região ao redor do Oceano Pacífico com grande concentração de vulcões ativos.", false),
            new Alt("Nessa área ocorrem a maioria dos terremotos mais intensos registrados no planeta Terra.", false),
            new Alt("É uma aliança gigante de metal dourado que flutua suspensa na atmosfera terrestre.", true)
        }));
        geoQ.Add(new Q("Os Terremotos", new Alt[] {
            new Alt("São tremores da crosta provocados pelo movimento brusco e atrito entre placas tectônicas.", false),
            new Alt("A intensidade e energia liberada pelos terremotos costumam ser medidas na escala Richter.", false),
            new Alt("Acontecem exclusivamente quando rebanhos de elefantes pulam ao mesmo tempo no chão.", true)
        }));
        geoQ.Add(new Q("Os Tsunamis", new Alt[] {
            new Alt("São ondas gigantescas formadas no oceano após terremotos submarinos ou erupções vulcânicas.", false),
            new Alt("Podem atravessar oceanos inteiros em alta velocidade e invadir cidades litorâneas.", false),
            new Alt("São pequenas bolhas de sabão coloridas que flutuam calmamente na beira da praia.", true)
        }));
        geoQ.Add(new Q("Placas Tectônicas", new Alt[] {
            new Alt("São grandes blocos rochosos semirrígidos que formam a camada sólida externa da Terra.", false),
            new Alt("Movem-se muito lentamente ao longo de milhões de anos sobre o manto pastoso do planeta.", false),
            new Alt("São folhas finas de aço parafusadas no fundo do mar por operários humanos.", true)
        }));
        geoQ.Add(new Q("O Rio Amazonas", new Alt[] {
            new Alt("É o rio mais caudaloso do planeta Terra, despejando o maior volume de água doce no oceano.", false),
            new Alt("Nasce na Cordilheira dos Andes e corre em direção ao leste até desaguar no Oceano Atlântico.", false),
            new Alt("É um pequeno riacho de água salgada localizado no centro do continente europeu.", true)
        }));
        geoQ.Add(new Q("O Rio Nilo", new Alt[] {
            new Alt("É um dos rios mais compridos e históricos do mundo, atravessando vários países da África.", false),
            new Alt("Suas águas deságuam no Mar Mediterrâneo, formando um grande e fértil delta de terra.", false),
            new Alt("É um rio que seca por completo todos os domingos e segundas-feiras do ano.", true)
        }));
        geoQ.Add(new Q("Cataratas do Iguaçu", new Alt[] {
            new Alt("São um conjunto impressionante de centenas de quedas d'água entre o Brasil e a Argentina.", false),
            new Alt("Ficam localizadas dentro do Parque Nacional do Iguaçu, cercadas por rica mata atlântica.", false),
            new Alt("Ficam localizadas no meio das dunas de areia seca do deserto do Saara.", true)
        }));
        geoQ.Add(new Q("Cataratas do Niágara", new Alt[] {
            new Alt("Ficam situadas na fronteira entre o estado de Nova York (EUA) e a província de Ontário (Canadá).", false),
            new Alt("Possuem grande volume d'água e são famosas no mundo inteiro por passeios de barco.", false),
            new Alt("Suas águas correm ao contrário, subindo pelas montanhas até atingir as nuvens do céu.", true)
        }));
        geoQ.Add(new Q("Cordilheira dos Andes", new Alt[] {
            new Alt("É a mais longa cadeia de montanhas contínua do planeta, estendendo-se por toda a América do Sul.", false),
            new Alt("Abriga picos nevados imponentes como o monte Aconcágua e lagos em grandes altitudes.", false),
            new Alt("Fica situada bem no centro plano do continente insular da Austrália.", true)
        }));

        geoQ.Add(new Q("Cordilheira do Himalaia", new Alt[] {
            new Alt("É a cadeia montanhosa mais alta do planeta Terra, situada no continente da Ásia.", false),
            new Alt("Surgiu do choque constante entre a placa tectônica da Índia e a placa da Eurásia.", false),
            new Alt("É uma vasta planície costeira ao nível do mar coberta por praias quentes.", true)
        }));
        geoQ.Add(new Q("O Monte Everest", new Alt[] {
            new Alt("É a montanha com a maior altitude da Terra, com seu pico a mais de 8.800 metros do mar.", false),
            new Alt("Fica localizado na fronteira entre o Nepal e a China, enfrentando nevascas rigorosas.", false),
            new Alt("Possui piscinas térmicas naturais de água morna onde banhistas nadam no seu topo.", true)
        }));
        geoQ.Add(new Q("O Grand Canyon", new Alt[] {
            new Alt("É um imenso desfiladeiro esculpido ao longo de milhões de anos pelas águas do Rio Colorado.", false),
            new Alt("Suas encostas exibem camadas coloridas de rochas antigas no estado do Arizona, nos EUA.", false),
            new Alt("Foi escavado por pás de plástico de brinquedo durante as férias de uma única semana.", true)
        }));
        geoQ.Add(new Q("Deserto do Saara", new Alt[] {
            new Alt("É o maior deserto quente do planeta Terra, cobrindo grande parte do norte da África.", false),
            new Alt("Apresenta dias extremamente quentes e noites com temperaturas consideravelmente baixas.", false),
            new Alt("É uma floresta densa e úmida onde cai chuva torrencial todas as manhãs do ano.", true)
        }));
        geoQ.Add(new Q("Deserto do Atacama", new Alt[] {
            new Alt("É considerado o deserto não polar mais árido e seco de todo o planeta Terra.", false),
            new Alt("Seu céu limpo e seco faz dele um dos melhores lugares do mundo para observar estrelas.", false),
            new Alt("Sofre com tempestades diárias de chuva que inundam todas as suas cidades.", true)
        }));
        geoQ.Add(new Q("Os Oásis", new Alt[] {
            new Alt("São áreas férteis com fontes naturais de água doce que brotam no meio de regiões desérticas.", false),
            new Alt("Permitem o cultivo de palmeiras como tamareiras e servem de abrigo para viajantes e animais.", false),
            new Alt("São ilusões mágicas que desaparecem no ar quando qualquer pessoa se aproxima deles.", true)
        }));
        geoQ.Add(new Q("Floresta Amazônica", new Alt[] {
            new Alt("É a maior floresta tropical do mundo, abrigando milhões de espécies de plantas e animais.", false),
            new Alt("Ajuda a regular as chuvas de grande parte da América do Sul com seus rios voadores de vapor.", false),
            new Alt("É formada exclusivamente por pinheiros finos cobertos por camadas de neve o ano inteiro.", true)
        }));
        geoQ.Add(new Q("Bioma Tundra", new Alt[] {
            new Alt("É um bioma muito frio localizado nas regiões polares do extremo norte do planeta Terra.", false),
            new Alt("Possui vegetação rasteira de musgos e liquens porque o solo profundo fica sempre congelado.", false),
            new Alt("É famoso no mundo por suas plantações naturais de bananas, melancias e coqueiros.", true)
        }));
        geoQ.Add(new Q("Bioma Taiga (Floresta Boreal)", new Alt[] {
            new Alt("É uma vasta floresta de coníferas e pinheiros adaptados a invernos longos e rigorosos.", false),
            new Alt("Forma um grande cinturão verde em países do hemisfério norte como Canadá e Rússia.", false),
            new Alt("É a região mais quente da Terra onde a temperatura nunca cai abaixo de 40 graus.", true)
        }));
        geoQ.Add(new Q("As Savanas", new Alt[] {
            new Alt("São biomas formados por gramíneas e árvores esparsas de troncos tortuosos e resistentes.", false),
            new Alt("Na África, abrigam grandes manadas de animais herbívoros como zebras, gnus e girafas.", false),
            new Alt("Ficam completamente submersas sob cem metros de água do mar durante todos os meses.", true)
        }));

        geoQ.Add(new Q("O Cerrado Brasileiro", new Alt[] {
            new Alt("É a savana mais rica em biodiversidade do mundo, situada principalmente no centro do Brasil.", false),
            new Alt("É conhecido como o berço das águas por abrigar as nascentes de importantes rios brasileiros.", false),
            new Alt("Fica congelado sob dez metros de neve durante todas as estações do ano.", true)
        }));
        geoQ.Add(new Q("A Caatinga", new Alt[] {
            new Alt("É um bioma que só existe no Brasil, cobrindo grande parte do interior da Região Nordeste.", false),
            new Alt("Plantas como o mandacaru armazenam água em seu caule para sobreviver a períodos de seca.", false),
            new Alt("É uma floresta pantanosa e gelada onde moram pinguins e focas polares.", true)
        }));
        geoQ.Add(new Q("O Pantanal", new Alt[] {
            new Alt("É a maior planície de inundação contínua do planeta, localizada no Centro-Oeste brasileiro.", false),
            new Alt("Na época das cheias, grande parte das terras fica coberta por águas rasas repletas de peixes.", false),
            new Alt("Fica situado no cume das montanhas mais altas da Cordilheira do Himalaia.", true)
        }));
        geoQ.Add(new Q("A Mata Atlântica", new Alt[] {
            new Alt("É uma floresta tropical brasileira que originalmente acompanhava quase todo o litoral do país.", false),
            new Alt("Abriga espécies raras e ameaçadas de extinção como o mico-leão-dourado e o pau-brasil.", false),
            new Alt("É um deserto seco de dunas de areia onde não cresce nenhuma árvore nativa.", true)
        }));
        geoQ.Add(new Q("Os Manguezais", new Alt[] {
            new Alt("São ecossistemas costeiros que funcionam como berçários naturais para caranguejos e peixes.", false),
            new Alt("As árvores do mangue possuem raízes aéreas que se fixam em solos lodosos e salobros.", false),
            new Alt("Ficam situados nos topos pontudos de montanhas com neves eternas.", true)
        }));
        geoQ.Add(new Q("Recifes de Corais", new Alt[] {
            new Alt("São estruturas submarinas coloridas formadas por colônias de pequenos animais marinhos.", false),
            new Alt("Fornecem abrigo e alimento para milhares de espécies de peixes, tartarugas e polvos.", false),
            new Alt("São blocos de plástico descartável fabricados em fábricas de brinquedos modernos.", true)
        }));
        geoQ.Add(new Q("Grande Barreira de Corais", new Alt[] {
            new Alt("É a maior estrutura construída por seres vivos do planeta, localizada no litoral da Austrália.", false),
            new Alt("É tão imensa e vistosa que pode ser vista por astronautas a partir do espaço sideral.", false),
            new Alt("É uma muralha de cimento e tijolos construída por humanos para impedir a maré.", true)
        }));
        geoQ.Add(new Q("O Mar Morto", new Alt[] {
            new Alt("É um grande lago no Oriente Médio com concentração de sal quase dez vezes maior que o oceano.", false),
            new Alt("A alta densidade da água muito salgada faz as pessoas boiarem naturalmente sem afundar.", false),
            new Alt("É o oceano mais profundo da Terra onde vivem tubarões gigantes e baleias assassinas.", true)
        }));
        geoQ.Add(new Q("O Mar Mediterrâneo", new Alt[] {
            new Alt("É um mar quase fechado que fica posicionado entre o sul da Europa e o norte da África.", false),
            new Alt("Está ligado ao Oceano Atlântico por meio da passagem estreita do Estreito de Gibraltar.", false),
            new Alt("Fica localizado no centro da Antártida, completamente coberto por ursos polares.", true)
        }));
        geoQ.Add(new Q("O Ciclo da Água", new Alt[] {
            new Alt("A água líquida dos rios e mares evapora com o calor do Sol e sobe para o ar como vapor.", false),
            new Alt("Nas alturas mais frias, o vapor condensa formando nuvens que voltam como chuva para o solo.", false),
            new Alt("Toda a água da chuva no planeta vem de torneiras gigantes instaladas na superfície da Lua.", true)
        }));

        geoQ.Add(new Q("A Evaporação", new Alt[] {
            new Alt("É a transformação da água líquida em vapor de água invisível provocada pelo aumento do calor.", false),
            new Alt("Ocorre constantemente na superfície dos oceanos, lagos, rios e até na roupa do varal.", false),
            new Alt("Ocorre quando a água da jarra é colocada no congelador e vira cubos de gelo sólido.", true)
        }));
        geoQ.Add(new Q("A Condensação", new Alt[] {
            new Alt("Ocorre quando o vapor de água invisível se resfria e volta a ser gotículas líquidas de água.", false),
            new Alt("É o processo físico fundamental responsável pelo surgimento e crescimento das nuvens no céu.", false),
            new Alt("Faz a água líquida ferver instantaneamente a mil graus como chamas de fogo.", true)
        }));
        geoQ.Add(new Q("A Precipitação", new Alt[] {
            new Alt("É o retorno da água das nuvens para a superfície da Terra na forma líquida de chuva.", false),
            new Alt("Quando a temperatura do ar nas nuvens está muito baixa, a água pode cair como neve ou granizo.", false),
            new Alt("É quando a água sobe das plantas direto para o espaço sem passar pelo ar.", true)
        }));
        geoQ.Add(new Q("O Lençol Freático", new Alt[] {
            new Alt("É uma camada subterrânea onde a água das chuvas fica acumulada entre grãos de terra e rochas.", false),
            new Alt("Alimenta nascentes de rios naturais e permite a perfuração de poços de água doce límpida.", false),
            new Alt("É um lençol de tecido de algodão estendido sobre as árvores para proteger da poeira.", true)
        }));
        geoQ.Add(new Q("Geleiras e Icebergs", new Alt[] {
            new Alt("Geleiras são massas espessas de neve acumulada que se movem muito lentamente pela montanha.", false),
            new Alt("A maior parte do volume e tamanho de um iceberg flutuante fica escondida embaixo da água.", false),
            new Alt("Os icebergs são formados por blocos de água doce fervente que soltam fumaça quente.", true)
        }));
        geoQ.Add(new Q("O Fenômeno do Arco-Íris", new Alt[] {
            new Alt("Surge quando raios de luz solar atravessam gotículas de chuva suspensas no ar da atmosfera.", false),
            new Alt("A refração e reflexão da luz decompõem o raio solar em uma faixa de sete cores principais.", false),
            new Alt("Só consegue aparecer no meio da noite escura sem nenhuma gota de umidade no ar.", true)
        }));
        geoQ.Add(new Q("A Aurora Boreal", new Alt[] {
            new Alt("É um espetáculo de luzes brilhantes e onduladas que surgem no céu perto do Polo Norte.", false),
            new Alt("Ocorre pelo choque de partículas carregadas do vento solar com gases da alta atmosfera.", false),
            new Alt("É produzida por holofotes elétricos ligados em gramados de campos de futebol à noite.", true)
        }));
        geoQ.Add(new Q("Furacões e Tufões", new Alt[] {
            new Alt("São imensos sistemas de tempestades giratórias com ventos muito velozes e fortes chuvas.", false),
            new Alt("Geralmente se formam sobre águas oceânicas mornas em regiões de clima tropical e subtropical.", false),
            new Alt("Formam-se espontaneamente dentro de garrafas plásticas de refrigerante tampadas na gaveta.", true)
        }));
        geoQ.Add(new Q("Os Tornados", new Alt[] {
            new Alt("São colunas de ar giratórias com formato de funil que descem de nuvens escuras até tocar o solo.", false),
            new Alt("Apesar de terem tamanho menor que furacões, seus ventos pontuais podem ser extremamente destrutivos.", false),
            new Alt("São brisas leves e calmas que não conseguem mover nem uma folha seca de árvore.", true)
        }));
        geoQ.Add(new Q("As Marés Oceânicas", new Alt[] {
            new Alt("São movimentos diários de subida e descida do nível das águas do mar ao longo das praias.", false),
            new Alt("Acontecem principalmente pela atração gravitacional que a Lua e o Sol exercem sobre a Terra.", false),
            new Alt("Acontecem porque cardumes de sardinhas começam a bater suas nadadeiras todas juntas.", true)
        }));

        geoQ.Add(new Q("Camadas da Terra", new Alt[] {
            new Alt("O planeta é formado pela Crosta rochosa na superfície, pelo Manto quente e pelo Núcleo no centro.", false),
            new Alt("A crosta terrestre onde vivemos é a camada mais fina de todas as três divisões do planeta.", false),
            new Alt("O interior da Terra é completamente oco e recheado de queijo derretido no centro.", true)
        }));
        geoQ.Add(new Q("O Núcleo da Terra", new Alt[] {
            new Alt("Fica localizado no centro do nosso planeta, formado predominantemente por ferro e níquel.", false),
            new Alt("Possui temperaturas e pressões altíssimas que podem atingir níveis comparáveis à superfície do Sol.", false),
            new Alt("É uma enorme bola de neve congelada com temperatura de dez graus negativos.", true)
        }));
        geoQ.Add(new Q("Rochas e Minerais", new Alt[] {
            new Alt("As rochas são formadas pela união natural e sólida de um ou mais tipos de minerais.", false),
            new Alt("Dividem-se em rochas magmáticas (vulcânicas), sedimentares (camadas) e metamórficas.", false),
            new Alt("Nascem como maçãs penduradas em galhos de árvores frutíferas no quintal.", true)
        }));
        geoQ.Add(new Q("Estalactites e Estalagmites", new Alt[] {
            new Alt("São formações rochosas pontudas encontradas no interior de cavernas de rochas calcárias.", false),
            new Alt("As estalactites crescem de cima para baixo no teto, e as estalagmites sobem a partir do chão.", false),
            new Alt("São esculturas talhadas em madeira verde por famílias de castores selvagens.", true)
        }));
        geoQ.Add(new Q("Os Cânions", new Alt[] {
            new Alt("São vales profundos com encostas de rocha quase verticais formados pela erosão de rios antigos.", false),
            new Alt("O Parque Nacional de Aparados da Serra abriga cânions gigantescos no sul do Brasil.", false),
            new Alt("Surgem da noite para o dia após uma garoa passageira de cinco minutos no campo.", true)
        }));
        geoQ.Add(new Q("Planícies e Planaltos", new Alt[] {
            new Alt("Planícies são terrenos planos de baixa altitude onde predomina o depósito de sedimentos.", false),
            new Alt("Planaltos são terrenos mais elevados onde o desgaste e a erosão superam o acúmulo de terra.", false),
            new Alt("As montanhas mais altas da Terra têm altitudes menores que as praias de areia do mar.", true)
        }));
        geoQ.Add(new Q("Aquífero Guarani", new Alt[] {
            new Alt("É um dos maiores reservatórios naturais de água doce subterrânea de todo o planeta Terra.", false),
            new Alt("Estende-se por baixo do solo de vários estados do Brasil, do Paraguai, Uruguai e Argentina.", false),
            new Alt("É uma enorme poça de água salgada localizada no topo de um vulcão na Austrália.", true)
        }));
        geoQ.Add(new Q("Erosão do Solo", new Alt[] {
            new Alt("É o processo natural de desgaste e transporte de terra e rochas causado por vento e chuvas.", false),
            new Alt("O desmatamento acelera a erosão porque as raízes das plantas deixam de segurar a terra firme.", false),
            new Alt("É a criação mágica e espontânea de barras de ouro puro no meio de hortas caseiras.", true)
        }));
        geoQ.Add(new Q("Mata Ciliar e Rios", new Alt[] {
            new Alt("É a vegetação nativa que cresce nas margens de rios e córregos, parecida com cílios nos olhos.", false),
            new Alt("Protege os rios contra o assoreamento de terra e preserva a pureza da água para os animais.", false),
            new Alt("Jogar lixo e pneus velhos nas margens ajuda a alimentar as plantas aquáticas do rio.", true)
        }));
        geoQ.Add(new Q("Polo Norte e Polo Sul", new Alt[] {
            new Alt("O Polo Norte é formado por gelo flutuante no Oceano Ártico, sem uma massa de terra por baixo.", false),
            new Alt("O Polo Sul é um continente de rochas (a Antártida) coberto por uma espessa camada de geleiras.", false),
            new Alt("Ambos os polos possuem praias de areia dourada quente onde crescem coqueirais tropicais.", true)
        }));

        // HISTORIA NIVEL 2 (50 Questoes - Egito Antigo, Faraos, Piramides, Mumias, Nilo e Civilizacoes dos Rios)
        hisQ.Add(new Q("O Rio Nilo no Egito Antigo", new Alt[] {
            new Alt("Suas cheias periódicas deixavam uma camada de lodo escuro e fértil nas margens para plantar.", false),
            new Alt("O historiador grego Heródoto chamou a civilização egípcia de uma dádiva do Rio Nilo.", false),
            new Alt("Era um rio de lava de vulcão fervente por onde barcos de madeira não podiam navegar.", true)
        }));
        hisQ.Add(new Q("Os Faraós", new Alt[] {
            new Alt("Eram os governantes supremos do Egito, considerados também representantes vivos dos deuses.", false),
            new Alt("Usavam coroas especiais e cetros dourados como símbolos de sua autoridade real e militar.", false),
            new Alt("Eram escolhidos pelo povo por meio de votação eletrônica em urnas a cada dois anos.", true)
        }));
        hisQ.Add(new Q("As Pirâmides de Gizé", new Alt[] {
            new Alt("Foram construídas como túmulos grandiosos de pedra para guardar os corpos e tesouros dos faraós.", false),
            new Alt("A Grande Pirâmide foi construída para o faraó Quéops há mais de quatro mil anos.", false),
            new Alt("Foram levantadas usando guindastes elétricos modernos e caminhões caçamba a diesel.", true)
        }));
        hisQ.Add(new Q("A Grande Esfinge", new Alt[] {
            new Alt("É uma monumental escultura em pedra com corpo de leão deitado e cabeça humana com touca real.", false),
            new Alt("Foi esculpida próxima às pirâmides de Gizé para servir de guardiã espiritual da necrópole.", false),
            new Alt("Possui asas de avião supersônico e uma cabeça feita de circuitos de computador modernos.", true)
        }));
        hisQ.Add(new Q("A Mumificação", new Alt[] {
            new Alt("Era um ritual sagrado para preservar o corpo dos mortos usando sal natrão, resinas e linho.", false),
            new Alt("Acreditavam que o espírito precisava reconhecer o corpo preservado para viver no além.", false),
            new Alt("Consistia em mergulhar o corpo em caldas de chocolate quente com granulados de doce.", true)
        }));
        hisQ.Add(new Q("Os Sarcófagos", new Alt[] {
            new Alt("Eram caixões de pedra ou madeira ricamente pintados com símbolos protetores e o rosto do morto.", false),
            new Alt("Protegiam a múmia e podiam ser colocados um dentro do outro como caixas especiais.", false),
            new Alt("Eram caixas de papelão amassado que eram jogadas na lixeira do palácio após o velório.", true)
        }));
        hisQ.Add(new Q("Os Vasos Canópicos", new Alt[] {
            new Alt("Eram quatro recipientes com tampas esculpidas em cabeças de deuses para guardar órgãos internos.", false),
            new Alt("Guardavam o fígado, os pulmões, o estômago e os intestinos que eram retirados do corpo.", false),
            new Alt("Eram xícaras de porcelana moderna usadas para servir café com leite aos sacerdotes.", true)
        }));
        hisQ.Add(new Q("Os Hieróglifos", new Alt[] {
            new Alt("Eram a escrita sagrada egípcia composta por centenas de figuras de pássaros, olhos e símbolos.", false),
            new Alt("Eram gravados em paredes de templos de pedra, túmulos de reis e folhas compridas de papiro.", false),
            new Alt("Eram compostos por letras em inglês digitadas em teclados sem fio modernos.", true)
        }));
        hisQ.Add(new Q("O Papel Papiro", new Alt[] {
            new Alt("Era feito a partir das hastes de uma planta aquática que crescia em abundância no Rio Nilo.", false),
            new Alt("As tiras da planta eram prensadas e secas, criando uma das primeiras folhas de escrita da história.", false),
            new Alt("Era um tipo de plástico transparente sintético fabricado com derivados de petróleo.", true)
        }));
        hisQ.Add(new Q("A Pedra de Roseta", new Alt[] {
            new Alt("Foi um bloco de pedra negro achado com um mesmo decreto escrito em grego e hieróglifos.", false),
            new Alt("Permitiu ao pesquisador Champollion decifrar pela primeira vez os hieróglifos egípcios antigos.", false),
            new Alt("Era um aparelho celular antigo de pedra que transmitia músicas populares pelo rádio.", true)
        }));

        hisQ.Add(new Q("O Faraó Tutancâmon", new Alt[] {
            new Alt("Ficou famoso como o faraó menino porque assumiu o trono do Egito com apenas nove anos de idade.", false),
            new Alt("Sua tumba foi descoberta quase intacta no Vale dos Reis, contendo uma máscara de ouro puro.", false),
            new Alt("Reinou por mais de cem anos e foi o inventor do primeiro automóvel a gasolina.", true)
        }));
        hisQ.Add(new Q("A Rainha Cleópatra", new Alt[] {
            new Alt("Foi uma governante famosa do Egito Antigo, reconhecida por sua inteligência e habilidades políticas.", false),
            new Alt("Falava vários idiomas e fez alianças históricas com grandes líderes romanos da sua época.", false),
            new Alt("Foi uma astronauta pioneira que viajou em um foguete para dar uma volta na Lua.", true)
        }));
        hisQ.Add(new Q("O Faraó Ramsés II", new Alt[] {
            new Alt("Foi um dos faraós que governou por mais tempo, liderando grandes batalhas e erguendo monumentos.", false),
            new Alt("Mandou construir os impressionantes templos esculpidos na rocha da montanha em Abu Simbel.", false),
            new Alt("Voava pelos céus do Egito pilotando um helicóptero de combate equipado com mísseis.", true)
        }));
        hisQ.Add(new Q("A Deusa Ísis", new Alt[] {
            new Alt("Era uma das deusas mais queridas do Egito, associada à magia, à cura e à proteção materna.", false),
            new Alt("Era esposa do deus Osíris e mãe do deus Hórus nas narrativas sagradas da mitologia egípcia.", false),
            new Alt("Era uma deusa com formato de guindaste de ferro que ajudava nas obras da cidade.", true)
        }));
        hisQ.Add(new Q("O Deus Rá", new Alt[] {
            new Alt("Era o deus egípcio do Sol, considerado uma das divindades criadoras mais poderosas do panteão.", false),
            new Alt("Os egípcios acreditavam que ele cruzava o céu diariamente em uma grande barca solar sagrada.", false),
            new Alt("Era o deus do gelo polar e da escuridão eterna que congelava o calor de todas as plantas.", true)
        }));
        hisQ.Add(new Q("O Deus Anúbis", new Alt[] {
            new Alt("Era representado como um homem com cabeça de chacal negro protetor dos mortos.", false),
            new Alt("Era o guardião do ritual de mumificação e pesava o coração das pessoas na balança divina.", false),
            new Alt("Tinha a cabeça de um periquito verde cantante que assobiava marchinhas nos templos.", true)
        }));
        hisQ.Add(new Q("O Deus Hórus", new Alt[] {
            new Alt("Era representado com a cabeça de um falcão vigilante e o famoso olho protetor de Hórus.", false),
            new Alt("O faraó no trono era visto pelos egípcios como a representação do próprio Hórus vivo na Terra.", false),
            new Alt("Era uma baleia de água doce que nadava de cabeça para baixo no fundo do Rio Nilo.", true)
        }));
        hisQ.Add(new Q("O Deus Osíris", new Alt[] {
            new Alt("Era o deus da vegetação, da ressurreição e o soberano do reino dos mortos na mitologia.", false),
            new Alt("Geralmente era desenhado com o corpo enfaixado como uma múmia e a pele na cor verde da vida.", false),
            new Alt("Era um monstro de fogo voador que devorava as plantações de trigo das margens do rio.", true)
        }));
        hisQ.Add(new Q("Os Gatos no Egito Antigo", new Alt[] {
            new Alt("Eram animais sagrados muito queridos que protegiam as casas e celeiros caçando ratos e cobras.", false),
            new Alt("Eram associados à deusa Bastet, protetora do lar e da alegria, e recebiam sepultamento digno.", false),
            new Alt("Eram estritamente proibidos em todo o território egípcio sob pena de prisão perpétua.", true)
        }));
        hisQ.Add(new Q("O Escaravelho Sagrado", new Alt[] {
            new Alt("Era um amuleto muito popular esculpido em pedras verdes ou azuis para trazer boa sorte e vida.", false),
            new Alt("Inspirado no besouro que rola bolas de terra, simbolizava o Sol nascendo a cada novo dia.", false),
            new Alt("Era um pássaro aquático migratório gigante com cauda de pavão emplumada de prata.", true)
        }));

        geoQ.ForEach(q => {}); hisQ.ForEach(q => {}); // keep compiler happy
        hisQ.Add(new Q("Maquiagem no Egito (Kohl)", new Alt[] {
            new Alt("Homens e mulheres pintavam o contorno dos olhos com pó mineral escuro misturado com óleos.", false),
            new Alt("A maquiagem escura ajudava a proteger os olhos contra o brilho excessivo do sol do deserto.", false),
            new Alt("A maquiagem dos egípcios era feita exclusivamente com graxa suja de motor de caminhão.", true)
        }));
        hisQ.Add(new Q("Barcos a Vela no Nilo", new Alt[] {
            new Alt("O Nilo funcionava como a principal estrada líquida do Egito para o transporte de cargas e pessoas.", false),
            new Alt("Usavam a correnteza da água para descer o rio e a força do vento nas velas para subir ao sul.", false),
            new Alt("Eram impulsionados por reatores nucleares submarinos que quebravam a barreira do som.", true)
        }));
        hisQ.Add(new Q("A Alimentação dos Egípcios", new Alt[] {
            new Alt("A dieta básica do povo incluía pães de cevada e trigo, cebolas, alho, lentilhas e peixe do rio.", false),
            new Alt("Frutas doces como figos, uvas e tâmaras eram apreciadas como sobremesas saudáveis no Egito.", false),
            new Alt("As famílias jantavam caixas de pizza congelada de micro-ondas todas as noites nos palácios.", true)
        }));
        hisQ.Add(new Q("A Cerveja dos Egípcios", new Alt[] {
            new Alt("Era uma bebida espessa e fermentada de grãos de cevada, considerada um alimento do dia a dia.", false),
            new Alt("Era rica em nutrientes e muitas vezes consumida porque era mais pura e segura que a água crua.", false),
            new Alt("Era servida em garrafas plásticas descartáveis com canudos de plástico coloridos.", true)
        }));
        hisQ.Add(new Q("O Ouro dos Faraós", new Alt[] {
            new Alt("O Egito possuía jazidas de ouro no deserto oriental e no sul, produzindo joias deslumbrantes.", false),
            new Alt("Os egípcios chamavam o ouro de carne dos deuses por seu brilho brilhante que não enferruja.", false),
            new Alt("As peças de ouro dos túmulos eram todas moldadas com massinha de modelar escolar comum.", true)
        }));
        hisQ.Add(new Q("Os Escribas Egípcios", new Alt[] {
            new Alt("Eram funcionários de grande prestígio que dominavam a complexa escrita e a contabilidade do reino.", false),
            new Alt("Registravam a quantidade de grãos colhidos nos armazéns reais, impostos e ordens do faraó.", false),
            new Alt("Eram robôs com inteligência artificial que imprimiam relatórios em impressoras a laser.", true)
        }));
        hisQ.Add(new Q("Escolas no Antigo Egito", new Alt[] {
            new Alt("As escolas funcionavam geralmente anexas aos templos religiosos para filhos de nobres e escribas.", false),
            new Alt("A maioria das crianças do campo aprendia a plantar, cuidar de animais ou fazer cerâmica com os pais.", false),
            new Alt("Todas as crianças do país usavam notebooks e tablets conectados ao Wi-Fi na sala de aula.", true)
        }));
        hisQ.Add(new Q("Brinquedos das Crianças", new Alt[] {
            new Alt("Crianças do Antigo Egito brincavam com bonecas de pano e madeira, piões e bolinhas de argila.", false),
            new Alt("Gostavam de nadar nas águas do rio e participar de corridas e jogos ao ar livre com amigos.", false),
            new Alt("Passavam o dia inteiro jogando videogames de aventura em televisores de tela plana de cinema.", true)
        }));
        hisQ.Add(new Q("O Tabuleiro de Senet", new Alt[] {
            new Alt("Era um dos jogos de tabuleiro mais famosos e antigos do Egito, com trinta casas em fileiras.", false),
            new Alt("Era praticado por pessoas comuns e pelos próprios faraós, que levavam tabuleiros aos túmulos.", false),
            new Alt("Era um aplicativo de celular com tela touch screen baixado em lojas de jogos virtuais.", true)
        }));
        hisQ.Add(new Q("Templos de Karnak e Luxor", new Alt[] {
            new Alt("Eram gigantescos complexos religiosos construídos com pedras maciças em homenagem ao deus Amon.", false),
            new Alt("Possuíam grandes avenidas de esfinges e colunas com mais de vinte metros cobertas de relevos.", false),
            new Alt("Foram montados exclusivamente com peças de plástico colorido de encaixe de brinquedo.", true)
        }));

        hisQ.Add(new Q("O Trabalho no Campo", new Alt[] {
            new Alt("Os camponeses trabalhavam no cultivo de grãos nas margens do Nilo e na colheita sob o sol quente.", false),
            new Alt("Durante a época em que o Nilo inundava os campos, muitos eram chamados para trabalhar nas obras reais.", false),
            new Alt("Os camponeses usavam tratores automáticos com piloto automático guiado por GPS moderno.", true)
        }));
        hisQ.Add(new Q("A Fértil Mesopotâmia", new Alt[] {
            new Alt("Era uma região histórica no Oriente Médio situada entre os vales dos rios Tigre e Eufrates.", false),
            new Alt("Seu solo fértil permitiu o surgimento de algumas das primeiras cidades da história da humanidade.", false),
            new Alt("Fica localizada bem no centro da densa Floresta Amazônica no norte do território do Brasil.", true)
        }));
        hisQ.Add(new Q("O Povo Sumério", new Alt[] {
            new Alt("Foi uma das civilizações mais antigas da Mesopotâmia, famosa pela invenção da escrita cuneiforme.", false),
            new Alt("Construíram canais de irrigação para controlar as águas dos rios e abastecer suas plantações.", false),
            new Alt("Inventaram o primeiro modelo de carro voador supersônico com motores elétricos.", true)
        }));
        hisQ.Add(new Q("A Escrita Cuneiforme", new Alt[] {
            new Alt("Era feita gravando símbolos com uma haste em forma de cunha sobre placas de barro úmido.", false),
            new Alt("Depois de gravadas, as tabuletas de argila secavam ao sol ou no forno para durar séculos.", false),
            new Alt("Era uma fonte digital de computador instalada em editores de texto modernos para imprimir.", true)
        }));
        hisQ.Add(new Q("Os Zigurates", new Alt[] {
            new Alt("Eram imponentes construções em formato de pirâmide de degraus erguidas nas cidades mesopotâmicas.", false),
            new Alt("No topo dessas torres ficava o templo sagrado dedicado ao deus protetor daquela cidade.", false),
            new Alt("Eram pistas de esqui no gelo cobertas de neve artificial para turistas esquiarem no verão.", true)
        }));
        hisQ.Add(new Q("A Cidade de Babilônia", new Alt[] {
            new Alt("Foi uma das capitais mais ricas e famosas do mundo antigo, repleta de muralhas e portões azuis.", false),
            new Alt("O Portão de Ishtar era uma das entradas mais bonitas da cidade, decorado com touros e dragões.", false),
            new Alt("Era uma minúscula tenda de pano montada em cima de um rochedo deserto no meio do oceano.", true)
        }));
        hisQ.Add(new Q("O Código de Hamurabi", new Alt[] {
            new Alt("Foi um dos códigos de leis escritas mais antigos da história, criado por um rei da Babilônia.", false),
            new Alt("Suas leis foram gravadas em um grande bloco de pedra escura para que todos conhecessem as regras.", false),
            new Alt("Foi escrito em páginas de caderno escolar com caneta marca-texto colorida e fita crepe.", true)
        }));
        hisQ.Add(new Q("Jardins Suspensos da Babilônia", new Alt[] {
            new Alt("Segundo lendas antigas, eram belos terraços com plantas e flores irrigadas no alto do palácio.", false),
            new Alt("Foram considerados por historiadores gregos como uma das Sete Maravilhas do Mundo Antigo.", false),
            new Alt("Eram canteiros de flores reais que flutuavam no ar amarrados a centenas de balões de gás hélio.", true)
        }));
        hisQ.Add(new Q("O Relógio de Sol", new Alt[] {
            new Alt("Foi um instrumento inventado por povos antigos para medir a passagem das horas pela sombra do Sol.", false),
            new Alt("Conforme a Terra girava, a sombra projetada por uma haste marcava as divisões do dia no solo.", false),
            new Alt("Possuía tela digital de vidro temperado conectada via Bluetooth a celulares modernos.", true)
        }));
        hisQ.Add(new Q("O Calendário de 365 Dias", new Alt[] {
            new Alt("Os egípcios criaram um calendário solar com 12 meses de 30 dias mais 5 dias dedicados aos deuses.", false),
            new Alt("O calendário era muito útil para saber a época exata da cheia do Rio Nilo e do plantio de trigo.", false),
            new Alt("Era um calendário curioso onde o ano inteiro tinha apenas quatro semanas de duração.", true)
        }));

        hisQ.Add(new Q("A Medicina Egípcia", new Alt[] {
            new Alt("Os médicos egípcios tratavam doentes com ervas, limpavam feridas com mel e imobilizavam fraturas.", false),
            new Alt("Graças à prática de mumificação, os egípcios aprenderam muito sobre a anatomia do corpo humano.", false),
            new Alt("Curavam doenças aplicando vacinas de nanotecnologia com robôs microscópicos nos pacientes.", true)
        }));
        hisQ.Add(new Q("Os Navegadores Fenícios", new Alt[] {
            new Alt("Eram marinheiros e comerciantes habilidosos que navegavam por todo o Mar Mediterrâneo.", false),
            new Alt("Criaram um alfabeto inovador baseado em sons que facilitou o comércio entre diferentes povos.", false),
            new Alt("Viajavam pelo fundo dos oceanos usando submarinos atômicos com radares de sonar modernos.", true)
        }));
        hisQ.Add(new Q("Rotas de Comércio Antigas", new Alt[] {
            new Alt("Povos antigos viajavam em caravanas pelo deserto para trocar azeite, cerâmicas, tecidos e incenso.", false),
            new Alt("Cidades como Tiro, Babilônia e Alexandria tornaram-se grandes mercados de encontro de mercadores.", false),
            new Alt("As mercadorias eram despachadas em aviões de carga supersônicos com entrega no mesmo dia.", true)
        }));
        hisQ.Add(new Q("A Barca Solar de Quéops", new Alt[] {
            new Alt("Era um grande barco de madeira de cedro desmontado e enterrado ao lado da Grande Pirâmide de Gizé.", false),
            new Alt("Foi construído para permitir ao faraó navegar pelo céu com os deuses após a vida terrena.", false),
            new Alt("Possuía turbinas a jato que soltavam labaredas de fogo azul para quebrar a velocidade do som.", true)
        }));
        hisQ.Add(new Q("As Bigas de Guerra", new Alt[] {
            new Alt("Eram carruagens leves de madeira puxadas por dois cavalos velozes, com um condutor e um arqueiro.", false),
            new Alt("Revolucionaram as batalhas no Oriente Médio e no Egito Antigo pela sua velocidade e mobilidade.", false),
            new Alt("Eram veículos blindados de metal pesado com esteiras de tanque e canhões automáticos.", true)
        }));
        hisQ.Add(new Q("Espelhos e Pentes Egípcios", new Alt[] {
            new Alt("Os egípcios fabricavam pentes finos de marfim ou madeira e espelhos de cobre ou bronze polido.", false),
            new Alt("A higiene diária era essencial, e nobres egípcios lavavam-se várias vezes ao dia e raspavam pelos.", false),
            new Alt("Usavam câmeras de celular com iluminação de anel de LED para verificar o visual no espelho.", true)
        }));
        hisQ.Add(new Q("A Cidade de Tebas", new Alt[] {
            new Alt("Foi uma das capitais mais importantes do Egito Antigo durante a época dos grandes impérios.", false),
            new Alt("Ficava no Alto Egito, perto dos grandes templos e da famosa necrópole do Vale dos Reis.", false),
            new Alt("Era uma cidade submarina instalada dentro de uma cúpula de vidro no fundo do oceano.", true)
        }));
        hisQ.Add(new Q("O Vale dos Reis", new Alt[] {
            new Alt("É um vale desértico onde faraós do Novo Império foram sepultados em tumbas cavadas na rocha.", false),
            new Alt("As tumbas eram escavadas no subterrâneo das montanhas para tentar esconder os tesouros de ladrões.", false),
            new Alt("Era um parque aquático moderno repleto de tobogãs coloridos e piscinas de ondas mecânicas.", true)
        }));
        hisQ.Add(new Q("Casas de Barro (Adobe)", new Alt[] {
            new Alt("A maioria das moradias egípcias era feita com tijolos de barro do Nilo misturados com palha seca.", false),
            new Alt("As paredes grossas de barro ajudavam a manter o interior das casas fresco no calor do deserto.", false),
            new Alt("Eram cabanas modernas feitas de folhas de isopor e janelas de vidro à prova de bala.", true)
        }));
        hisQ.Add(new Q("O Legado do Antigo Egito", new Alt[] {
            new Alt("O fascínio pelas pirâmides, pelas múmias e pelos templos do Egito atrai milhões de pessoas até hoje.", false),
            new Alt("Seus conhecimentos de geometria, irrigação, arte e astronomia influenciaram muitas civilizações.", false),
            new Alt("O Egito Antigo nunca existiu na realidade e foi uma história inventada para um desenho animado.", true)
        }));

        Console.WriteLine(string.Format("Geo Lvl 2 Q count: {0}, His Lvl 2 Q count: {1}", geoQ.Count, hisQ.Count));
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

        // Find line indices for [2] = { ... } in Geografia and [2] = { ... } in Historia
        int geoLvl2Start = -1, geoLvl3Start = -1;
        int hisStart = -1, hisLvl2Start = -1, hisLvl3Start = -1;

        for (int i = 0; i < lines.Length; i++) {
            string trimmed = lines[i].Trim();
            if (geoLvl2Start == -1 && trimmed == "[2] = {") {
                geoLvl2Start = i;
            } else if (geoLvl2Start != -1 && geoLvl3Start == -1 && trimmed == "[3] = {") {
                geoLvl3Start = i;
            } else if (trimmed.Contains("[\"História\"] = {") || trimmed.Contains("[\"Histria\"] = {")) {
                hisStart = i;
            } else if (hisStart != -1 && hisLvl2Start == -1 && trimmed == "[2] = {") {
                hisLvl2Start = i;
            } else if (hisLvl2Start != -1 && hisLvl3Start == -1 && trimmed == "[3] = {") {
                hisLvl3Start = i;
            }
        }

        Console.WriteLine(string.Format("geoLvl2Start: {0}, geoLvl3Start: {1}, hisLvl2Start: {2}, hisLvl3Start: {3}", geoLvl2Start, geoLvl3Start, hisLvl2Start, hisLvl3Start));

        var sbOut = new StringBuilder();

        // Part 1: from 0 up to geoLvl2Start (the "[2] = {" line)
        for (int i = 0; i <= geoLvl2Start; i++) {
            sbOut.AppendLine(lines[i]);
        }

        // Insert new Geo Level 2
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

        // Part 2: from geoLvl3Start up to hisLvl2Start
        for (int i = geoLvl3Start; i <= hisLvl2Start; i++) {
            sbOut.AppendLine(lines[i]);
        }

        // Insert new His Level 2
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

        // Part 3: from hisLvl3Start to end
        for (int i = hisLvl3Start; i < lines.Length; i++) {
            sbOut.AppendLine(lines[i]);
        }

        File.WriteAllText(originalFile, sbOut.ToString(), new UTF8Encoding(false));
        Console.WriteLine(string.Format("SUCCESS: Updated {0} successfully with UTF-8 no BOM!", originalFile));
    }

    static string Escape(string s) {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}
