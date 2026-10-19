using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class HisLevels7to10 {
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
        // NIVEL 7: BRASIL COLÔNIA E IMPÉRIO (50 Questões)
        // ==========================================
        var l7 = levels[7];
        l7.Add(new Q("Os Bandeirantes Paulistas", new Alt[] {
            new Alt("Eram expedicionários que partiam de São Paulo e desbravavam o interior do Brasil em busca de ouro, pedras e indígenas.", false),
            new Alt("Suas longas expedições terrestres e fluviais ajudaram a expandir as fronteiras além dos limites de Tordesilhas.", false),
            new Alt("Viajavam pelo sertão dirigindo ônibus elétricos modernos com ar-condicionado.", true)
        }));
        l7.Add(new Q("A Descoberta do Ouro em Minas Gerais", new Alt[] {
            new Alt("No final do século dezessete, bandeirantes encontraram ricas jazidas de ouro nos rios e montanhas da região de Minas Gerais.", false),
            new Alt("A descoberta atraiu milhares de pessoas de Portugal e de outras partes do Brasil na chamada 'Febre do Ouro'.", false),
            new Alt("O ouro brotava do chão já em formato de medalhas olímpicas prontas com fita.", true)
        }));
        l7.Add(new Q("A Cidade de Ouro Preto (Vila Rica)", new Alt[] {
            new Alt("Foi o centro econômico do Ciclo do Ouro brasileiro, famosa por suas igrejas barrocas e ladeiras de pedra.", false),
            new Alt("Originalmente chamava-se Vila Rica e o ouro encontrado no rio tinha uma camada escura de óxido de ferro.", false),
            new Alt("Foi construída inteiramente com blocos de gelo polar no alto de uma geleira.", true)
        }));
        l7.Add(new Q("O Barroco Mineiro e Aleijadinho", new Alt[] {
            new Alt("Antônio Francisco Lisboa, o Aleijadinho, foi um genial escultor e arquiteto barroco de Minas Gerais.", false),
            new Alt("Mesmo sofrendo com uma doença deformante nas mãos, esculpiu em pedra-sabão e madeira obras-primas como os Doze Profetas.", false),
            new Alt("Pintava quadros utilizando tinta invisível que só aparecia quando colocada no freezer.", true)
        }));
        l7.Add(new Q("O Santuário de Bom Jesus de Matosinhos", new Alt[] {
            new Alt("Fica em Congonhas (Minas Gerais) e abriga as célebres estátuas dos Doze Profetas esculpidas por Aleijadinho.", false),
            new Alt("É considerado uma das maiores obras-primas da arte barroca colonial no mundo, tombado pela UNESCO.", false),
            new Alt("É um parque aquático infantil com toboáguas de borracha e piscinas de bolinhas.", true)
        }));
        l7.Add(new Q("O Imposto do Quinto e as Casas de Fundição", new Alt[] {
            new Alt("A Coroa Portuguesa cobrava um imposto de 20% (um quinto) de todo o ouro extraído na colônia do Brasil.", false),
            new Alt("Nas Casas de Fundição, o ouro era transformado em barras carimbadas com o selo real oficial de Portugal.", false),
            new Alt("O imposto era pago com pirulitos de morango e balas de goma entregues aos fiscais.", true)
        }));
        l7.Add(new Q("O Ouro em Pó e o Santo do Pau Oco", new Alt[] {
            new Alt("Para fugir da cobrança do pesado imposto real, algumas pessoas escondiam ouro em pó dentro de imagens ocas de santos.", false),
            new Alt("Essa prática clandestina da época do ouro deu origem à famosa expressão popular brasileira 'santo do pau oco'.", false),
            new Alt("As imagens de santos eram robôs falantes que voavam carregando moedas de prata.", true)
        }));
        l7.Add(new Q("A Estrada Real", new Alt[] {
            new Alt("Era a rede oficial de caminhos abertos pela Coroa Portuguesa para transportar ouro e diamantes até os portos do litoral.", false),
            new Alt("Ligava cidades como Diamantina e Ouro Preto ao porto de Paraty e, mais tarde, diretamente à cidade do Rio de Janeiro.", false),
            new Alt("Era uma pista de corrida de Fórmula 1 asfaltada com asfalto preto moderno.", true)
        }));
        l7.Add(new Q("A Inconfidência Mineira (1789)", new Alt[] {
            new Alt("Foi uma conspiração separatista liderada por intelectuais, padres, poetas e militares contra o domínio e impostos portugueses.", false),
            new Alt("Inspirava-se nos ideais iluministas de liberdade e na recente independência das colônias dos Estados Unidos.", false),
            new Alt("Foi uma disputa esportiva de lançamento de dardo e corrida de sacos entre cidades.", true)
        }));
        l7.Add(new Q("Tiradentes (Joaquim José da Silva Xavier)", new Alt[] {
            new Alt("Era alferes de cavalaria e ficou conhecido pelo apelido de Tiradentes por exercer informalmente a odontologia da época.", false),
            new Alt("Foi o único membro da Inconfidência Mineira condenado à morte, tornando-se o mártir e patrono cívico da nação brasileira.", false),
            new Alt("Foi um imperador de Roma que construiu o Coliseu com pedras do fundo do oceano.", true)
        }));
        l7.Add(new Q("O Feriado de 21 de Abril", new Alt[] {
            new Alt("É o feriado nacional brasileiro em homenagem a Tiradentes, data em que ele foi executado no Rio de Janeiro em 1792.", false),
            new Alt("Também coincide com a data de fundação da capital federal Brasília, inaugurada no ano de 1960.", false),
            new Alt("Comemora o aniversário da invenção da roda de bicicleta por astronautas da Lua.", true)
        }));
        l7.Add(new Q("A Vinda da Família Real Portuguesa (1808)", new Alt[] {
            new Alt("O príncipe regente Dom João e toda a corte portuguesa fugiram de Lisboa para o Brasil protegidos por navios ingleses.", false),
            new Alt("A fuga ocorreu porque as tropas francesas do imperador Napoleão Bonaparte estavam invadindo o território português.", false),
            new Alt("A corte viajou para o Brasil voando em um tapete mágico gigante com cem tripulantes.", true)
        }));
        l7.Add(new Q("A Abertura dos Portos às Nações Amigas (1808)", new Alt[] {
            new Alt("Assim que chegou a Salvador, Dom João assinou a carta régia abrindo os portos brasileiros ao comércio internacional direto.", false),
            new Alt("Esse ato histórico encerrou séculos de exclusivismo colonial português sobre as mercadorias que entravam e saíam do Brasil.", false),
            new Alt("Proibia qualquer navio do mundo de encostar nas praias do litoral brasileiro para sempre.", true)
        }));
        l7.Add(new Q("A Chegada da Corte ao Rio de Janeiro", new Alt[] {
            new Alt("O Rio de Janeiro transformou-se na sede oficial da corte portuguesa e na capital provisória de todo o Império Português.", false),
            new Alt("A cidade passou por rápida modernização, ganhando chafarizes, iluminação pública, calçamento e novas residências.", false),
            new Alt("A corte morou dentro de submarinos ancorados na Baía de Guanabara sem pisar na terra.", true)
        }));
        l7.Add(new Q("A Fundação do Jardim Botânico do Rio de Janeiro", new Alt[] {
            new Alt("Foi criado por Dom João VI em 1808 com o objetivo de aclimatar espécies vegetais exóticas trazidas do Oriente.", false),
            new Alt("É famoso por suas majestosas aleias de palmeiras-imperiais centenárias e rica coleção de orquídeas e vitórias-régias.", false),
            new Alt("Foi um zoológico subterrâneo onde viviam apenas leões brancos de brinquedo.", true)
        }));
        l7.Add(new Q("O Banco do Brasil e a Imprensa Régia", new Alt[] {
            new Alt("Dom João VI fundou o Banco do Brasil em 1808, o primeiro banco oficial da história brasileira.", false),
            new Alt("Criou também a Imprensa Régia, permitindo pela primeira vez a impressão de livros e do primeiro jornal oficial na colônia.", false),
            new Alt("O Banco do Brasil foi inaugurado para distribuir moedas de chocolate para os pescadores.", true)
        }));
        l7.Add(new Q("A Elevação a Reino Unido (1815)", new Alt[] {
            new Alt("O Brasil deixou formalmente de ser apenas uma colônia e foi elevado à condição de 'Reino Unido a Portugal e Algarves'.", false),
            new Alt("Com essa medida de Dom João, o território brasileiro passou a ter igualdade jurídica e política com a metrópole portuguesa.", false),
            new Alt("O Brasil foi transformado em uma pequena província subordinada à ilha de Madagascar.", true)
        }));
        l7.Add(new Q("O Retorno de Dom João VI a Portugal (1821)", new Alt[] {
            new Alt("Pressionado pela Revolução Liberal do Porto, Dom João VI teve que retornar a Lisboa para manter o trono português.", false),
            new Alt("Deixou seu jovem filho Dom Pedro de Alcântara no Brasil como Príncipe Regente para administrar o país.", false),
            new Alt("Voltou para Portugal remando sozinho em uma pequena prancha de stand-up paddle.", true)
        }));
        l7.Add(new Q("O Dia do Fico (9 de Janeiro de 1822)", new Alt[] {
            new Alt("As cortes portuguesas exigiram o retorno imediato do príncipe Dom Pedro a Lisboa para subordinar o Brasil novamente.", false),
            new Alt("Diante de petições do povo brasileiro, Dom Pedro declarou: 'Se é para o bem de todos e felicidade geral da Nação, digo ao povo que fico!'.", false),
            new Alt("Dom Pedro anunciou que estava indo embora morar no Polo Norte com os ursos polares.", true)
        }));
        l7.Add(new Q("A Princesa Leopoldina e o Conselho de Estado", new Alt[] {
            new Alt("Arquiduquesa austríaca e esposa de Dom Pedro, teve papel decisivo na independência ao presidir o Conselho de Estado.", false),
            new Alt("Assinou a declaração e enviou cartas urgentes ao marido alertando que a ruptura com Portugal não podia mais esperar.", false),
            new Alt("Era uma cantora de ópera que passava o dia cozinhando biscoitos na cozinha imperial.", true)
        }));
        l7.Add(new Q("O Grito do Ipiranga (7 de Setembro de 1822)", new Alt[] {
            new Alt("Às margens do riacho do Ipiranga, em São Paulo, o príncipe Dom Pedro ergueu a espada e proclamou a Independência do Brasil.", false),
            new Alt("Com o histórico brado 'Independência ou Morte!', o Brasil rompeu definitivamente os laços coloniais com Portugal.", false),
            new Alt("Dom Pedro deu um grito de socorro porque seu cavalo havia tropeçado em uma melancia.", true)
        }));
        l7.Add(new Q("A Coroação de Dom Pedro I", new Alt[] {
            new Alt("Em dezembro de 1822, Dom Pedro foi aclamado e coroado como o primeiro Imperador Constitucional e Defensor Perpétuo do Brasil.", false),
            new Alt("O Brasil tornou-se uma monarquia independente, fato singular entre as novas nações da América Latina.", false),
            new Alt("Dom Pedro foi coroado usando uma cartola de mágico com um coelho branco na cabeça.", true)
        }));
        l7.Add(new Q("A Primeira Constituição Brasileira (1824)", new Alt[] {
            new Alt("Foi outorgada por Dom Pedro I em 1824, estabelecendo as bases jurídicas e o sistema monárquico imperial brasileiro.", false),
            new Alt("Criou uma estrutura de quatro poderes: Executivo, Legislativo, Judiciário e o exclusivo Poder Moderador.", false),
            new Alt("Era um livro de receitas de doces coloniais com ilustrações coloridas de frutas.", true)
        }));
        l7.Add(new Q("O Poder Moderador", new Alt[] {
            new Alt("Era o quarto poder privativo do imperador previsto na Constituição de 1824 para manter o equilíbrio entre os demais poderes.", false),
            new Alt("Permitia ao imperador nomear ministros, dissolver o Parlamento em crises e convocar novas eleições gerais.", false),
            new Alt("Era um botão eletrônico que o imperador apertava para desligar as luzes da cidade.", true)
        }));
        l7.Add(new Q("A Abdicação de Dom Pedro I (1831)", new Alt[] {
            new Alt("Após conflitos políticos crescentes com a elite brasileira e a morte de seu pai em Portugal, Dom Pedro I abdicou do trono.", false),
            new Alt("Deixou o trono brasileiro para seu pequeno filho Dom Pedro de Alcântara, de apenas cinco anos de idade, e partiu para a Europa.", false),
            new Alt("Abdicou do trono para ser jogador de futebol profissional no exterior.", true)
        }));
        l7.Add(new Q("O Período Regencial (1831-1840)", new Alt[] {
            new Alt("Como o herdeiro legítimo Dom Pedro II era menor de idade, o Brasil foi governado por regentes eleitos durante quase dez anos.", false),
            new Alt("Foi uma década marcada por intensos debates políticos e revoltas provinciais armadas em várias partes do país.", false),
            new Alt("O Brasil foi governado por um computador inteligente instalado no Palácio Imperial.", true)
        }));
        l7.Add(new Q("A Guerra dos Farrapos (Revolução Farroupilha)", new Alt[] {
            new Alt("Foi o mais longo conflito armado provincial do período regencial, ocorrido no Rio Grande do Sul entre 1835 e 1845.", false),
            new Alt("Os estancieiros gaúchos revoltaram-se contra os altos impostos sobre o charque nacional proclamando repúblicas no sul.", false),
            new Alt("Foi uma guerra disputada jogando balões de água fria durante o verão em Porto Alegre.", true)
        }));
        l7.Add(new Q("A Cabanagem no Grão-Pará", new Alt[] {
            new Alt("Foi uma grande revolta popular em 1835 liderada por ribeirinhos e indígenas que viviam em choupanas e cabanas nas margens dos rios.", false),
            new Alt("Os cabanos chegaram a tomar o poder e ocupar a capital Belém, exigindo melhores condições de vida e direitos.", false),
            new Alt("Foi uma feira de artesanato onde os artesãos vendiam cabanas de madeira em miniatura.", true)
        }));
        l7.Add(new Q("O Golpe da Maioridade (1840)", new Alt[] {
            new Alt("Para conter as rebeliões provinciais e unificar o país, os políticos anteciparam a maioridade de Dom Pedro II aos 14 anos.", false),
            new Alt("O jovem imperador assumiu oficialmente o governo do Brasil, dando início ao Segundo Reinado que durou quase cinquenta anos.", false),
            new Alt("Foi uma partida de xadrez disputada em praça pública que definiu o novo presidente da República.", true)
        }));
        l7.Add(new Q("Dom Pedro II", new Alt[] {
            new Alt("Foi o segundo e último monarca do Império do Brasil, governando o país com moderação por quase meio século (1840-1889).", false),
            new Alt("Era um homem culto, apaixonado por ciências, astronomia, fotografia, viagens e correspondia-se com grandes sábios do mundo.", false),
            new Alt("Era um guerreiro que lutava montado em um rinoceronte com capacete de ferro.", true)
        }));
        l7.Add(new Q("A Cidade de Petrópolis", new Alt[] {
            new Alt("Localizada na serra fluminense, foi fundada por Dom Pedro II para ser a residência de verão da família imperial brasileira.", false),
            new Alt("O Palácio Imperial de Petrópolis abriga hoje o rico Museu Imperial com a coroa de diamantes e móveis da época.", false),
            new Alt("Fica no meio do deserto do Saara cercada por pirâmides de areia dourada.", true)
        }));
        l7.Add(new Q("A Coroa de Dom Pedro II", new Alt[] {
            new Alt("Foi confeccionada em ouro cinzelado com centenas de diamantes brilhantes e pérolas naturais magníficas.", false),
            new Alt("Pesa quase dois quilos e é exibida como uma das peças centrais do acervo histórico do Museu Imperial em Petrópolis.", false),
            new Alt("Foi feita de papel cartão prateado colado com fita adesiva para uma peça de teatro.", true)
        }));
        l7.Add(new Q("O Ciclo do Café", new Alt[] {
            new Alt("O café tornou-se o principal produto de exportação da economia do Império brasileiro durante o século dezenove.", false),
            new Alt("As grandes fazendas cafeeiras espalharam-se pelo Vale do Paraíba e, mais tarde, pelo fértil Oeste Paulista de terra roxa.", false),
            new Alt("O café era colhido de árvores submarinas que cresciam no fundo da Baía de Santos.", true)
        }));
        l7.Add(new Q("A Terra Roxa Paulista", new Alt[] {
            new Alt("É um solo avermelhado escuro extraordinariamente fértil de origem vulcânica basáltica no interior de São Paulo.", false),
            new Alt("O nome 'roxa' veio da pronúncia dos imigrantes italianos da palavra 'rossa' (que significa vermelha em italiano).", false),
            new Alt("É uma terra feita de plástico moído que brilha no escuro como lâmpadas neon.", true)
        }));
        l7.Add(new Q("O Barão de Mauá (Irineu Evangelista de Sousa)", new Alt[] {
            new Alt("Foi o pioneiro da modernização e da industrialização do Brasil no século dezenove, investindo em ferrovias e telégrafos.", false),
            new Alt("Construiu a primeira ferrovia do país (a Estrada de Ferro Mauá no Rio de Janeiro) e a iluminação a gás da capital.", false),
            new Alt("Inventou a máquina de fazer algodão-doce com sabor de tutti-frutti no cais do porto.", true)
        }));
        l7.Add(new Q("A Primeira Ferrovia Brasileira (1854)", new Alt[] {
            new Alt("Inaugurada em 1854 pelo Barão de Mauá com a presença de Dom Pedro II, ligava a Baía de Guanabara à serra de Petrópolis.", false),
            new Alt("A primeira locomotiva a vapor brasileira que puxava os vagões foi carinhosamente batizada de 'Baroneza'.", false),
            new Alt("Tinha trilhos feitos de madeira de balsa flutuando sobre uma piscina de óleo.", true)
        }));
        l7.Add(new Q("A Locomotiva Baroneza", new Alt[] {
            new Alt("É a mais antiga locomotiva a vapor preservada no Brasil, construída na Inglaterra sob encomenda de Mauá.", false),
            new Alt("Atualmente é uma relíquia histórica preservada em museu ferroviário como patrimônio cultural nacional.", false),
            new Alt("Era movida por uma equipe de hamsters correndo dentro de rodinhas de arame.", true)
        }));
        l7.Add(new Q("A Guerra do Paraguai (1864-1870)", new Alt[] {
            new Alt("Foi o maior e mais sangrento conflito militar armado interestatal já ocorrido na história da América do Sul.", false),
            new Alt("O Brasil aliou-se à Argentina e ao Uruguai formando a Tríplice Aliança contra as forças paraguaias de Solano López.", false),
            new Alt("Foi uma disputa de corrida de cavalos de madeira no pátio do Palácio Imperial.", true)
        }));
        l7.Add(new Q("Os Voluntários da Pátria", new Alt[] {
            new Alt("Eram corpos militares formados por voluntários civis de todas as províncias brasileiras para lutar na Guerra do Paraguai.", false),
            new Alt("Muitos negros e homens livres alistaram-se recebendo fardas especiais e a promessa de liberdade ou pensões.", false),
            new Alt("Eram robôs soldados importados do Japão equipados com espadas elétricas.", true)
        }));
        l7.Add(new Q("O Duque de Caxias (Luís Alves de Lima e Silva)", new Alt[] {
            new Alt("Foi o principal comandante militar do Exército Brasileiro no Segundo Reinado e patrono histórico do Exército.", false),
            new Alt("Comandou as tropas brasileiras na fase decisiva da Guerra do Paraguai, ficando conhecido como 'O Pacificador'.", false),
            new Alt("Era um trapezista de circo que viajava pelo mundo fazendo acrobacias aéreas.", true)
        }));
        l7.Add(new Q("A Luta Abolicionista", new Alt[] {
            new Alt("Foi o grandioso movimento cívico e popular que lutou pelo fim total da escravidão no território brasileiro.", false),
            new Alt("Teve líderes e oradores brilhantes como Joaquim Nabuco, o advogado José do Patrocínio e o engenheiro negro André Rebouças.", false),
            new Alt("Foi um clube de leitura que se reunia para inventar histórias de ficção científica.", true)
        }));
        l7.Add(new Q("O Poeta Castro Alves", new Alt[] {
            new Alt("Ficou célebre como o 'Poeta dos Escravos' por seus versos líricos e inflamados denunciando a crueldade da escravidão.", false),
            new Alt("Seu famoso poema 'O Navio Negreiro' retrata com pungência a tragédia da travessia dos navios negreiros no Atlântico.", false),
            new Alt("Escreveu o primeiro manual técnico de montagem de computadores portáteis em São Paulo.", true)
        }));
        l7.Add(new Q("A Lei Eusébio de Queirós (1850)", new Alt[] {
            new Alt("Foi a lei imperial que proibiu definitivamente o tráfico atlântico de escravizados africanos para os portos do Brasil.", false),
            new Alt("Fez com que os capitais antes investidos no tráfico fossem direcionados para bancos, ferrovias e indústrias nascentes.", false),
            new Alt("Obrigou todos os cidadãos brasileiros a tomar banho de mar três vezes por semana.", true)
        }));
        l7.Add(new Q("A Lei do Ventre Livre (1871)", new Alt[] {
            new Alt("Determinava que a partir daquela data todos os filhos de mulheres escravizadas nascidos no Brasil seriam considerados livres.", false),
            new Alt("Foi um marco crucial da marcha gradual que conduziu o país ao término definitivo do regime de escravidão.", false),
            new Alt("Declarava que todos os bebês nascidos no Brasil ganhavam uma bicicleta de fábrica.", true)
        }));
        l7.Add(new Q("A Lei dos Sexagenários (1885)", new Alt[] {
            new Alt("Concedia a liberdade aos escravizados que completassem sessenta anos de idade no território brasileiro.", false),
            new Alt("Apesar de restritiva, foi mais um passo legal do movimento abolicionista na desmontagem da escravidão.", false),
            new Alt("Exigia que pessoas com mais de sessenta anos disputassem corridas de obstáculos para se aposentar.", true)
        }));
        l7.Add(new Q("A Princesa Isabel", new Alt[] {
            new Alt("Era a herdeira do trono imperial brasileiro e assumiu a regência do Império durante viagens de Dom Pedro II ao exterior.", false),
            new Alt("Ficou conhecida como 'A Redentora' por sancionar e assinar as históricas leis do Ventre Livre e a Lei Áurea.", false),
            new Alt("Foi uma pirata caribenha que comandava um galeão negro com bandeira de caveira.", true)
        }));
        l7.Add(new Q("A Lei Áurea (13 de Maio de 1888)", new Alt[] {
            new Alt("Assinada pela Princesa Isabel com uma pena de ouro ofertada pelo povo, aboliu total e definitivamente a escravidão no Brasil.", false),
            new Alt("O Brasil foi a última nação independente das Américas a extinguir oficialmente o regime de trabalho escravo.", false),
            new Alt("Foi uma lei que estabeleceu que todas as moedas de dinheiro deviam ser banhadas a chocolate.", true)
        }));
        l7.Add(new Q("A Proclamação da República (15 de Novembro de 1889)", new Alt[] {
            new Alt("Militares liderados pelo Marechal Deodoro da Fonseca marcharam até o Ministério da Guerra depondo o gabinete imperial.", false),
            new Alt("O marechal proclamou a República no Brasil na Praça da Aclamação (atual Praça da República) no Rio de Janeiro.", false),
            new Alt("A República foi proclamada durante uma partida de vôlei de praia em Copacabana.", true)
        }));
        l7.Add(new Q("O Marechal Deodoro da Fonseca", new Alt[] {
            new Alt("Foi o prestigiado militar veterano que liderou o movimento de 15 de novembro e tornou-se o primeiro Presidente do Brasil.", false),
            new Alt("Chefiou o Governo Provisório republicano até a promulgação da primeira Constituição Republicana em 1891.", false),
            new Alt("Foi um piloto de corrida de kart que venceu três mundiais de Fórmula 1.", true)
        }));
        l7.Add(new Q("A Nova Bandeira Republicana do Brasil", new Alt[] {
            new Alt("Apresentada em novembro de 1889, preservou o losango amarelo no fundo verde do império com uma esfera azul celeste estrelada.", false),
            new Alt("Traz a faixa branca com o lema positivista 'Ordem e Progresso' e as constelações vistas no céu do Rio no dia da proclamação.", false),
            new Alt("Tem o desenho de um papagaio verde segurando um prato de arroz com feijão no meio.", true)
        }));

        // ==========================================
        // NIVEL 8: REVOLUÇÃO INDUSTRIAL E GRANDES INVENÇÕES (50 Questões)
        // ==========================================
        var l8 = levels[8];
        l8.Add(new Q("A Máquina a Vapor de James Watt", new Alt[] {
            new Alt("Aperfeiçoada pelo inventor escocês James Watt, transformou o calor da água fervente em energia mecânica contínua.", false),
            new Alt("Foi o verdadeiro motor propulsor da Revolução Industrial, acionando teares, bombas de minas e fábricas inteiras.", false),
            new Alt("Funcionava com baterias de celular recarregáveis conectadas na tomada.", true)
        }));
        l8.Add(new Q("A Revolução Industrial na Inglaterra", new Alt[] {
            new Alt("Começou no século dezoito na Grã-Bretanha com o surgimento de grandes fábricas têxteis movidas a carvão mineral.", false),
            new Alt("Transformou o trabalho manual artesanal doméstico em produção em massa acelerada com máquinas operárias.", false),
            new Alt("Aconteceu porque todos os artesãos ingleses decidiram morar dentro de cavernas frias.", true)
        }));
        l8.Add(new Q("O Carvão Mineral", new Alt[] {
            new Alt("Era o combustível fóssil essencial queimado nas fornalhas para ferver água e produzir vapor para mover máquinas a vapor.", false),
            new Alt("Sua extração em minas subterrâneas profundas expandiu enormemente as redes de transporte de trens e navios.", false),
            new Alt("Era um tipo de doce de alcaçuz preto que os operários comiam no café da manhã.", true)
        }));
        l8.Add(new Q("O Tear Mecânico", new Alt[] {
            new Alt("Inventado por Edmund Cartwright, automatizou a tecelagem de fios de algodão em tecidos de forma ultrarrápida.", false),
            new Alt("Multiplicou por dezenas de vezes a produção diária de tecidos e roupas baratas nas fábricas inglesas.", false),
            new Alt("Era uma máquina de fazer pipoca doce que apitava quando a panela esquentava.", true)
        }));
        l8.Add(new Q("A Locomotiva a Vapor (O Trem de Ferro)", new Alt[] {
            new Alt("Criada por engenheiros como George Stephenson com sua famosa locomotiva 'Rocket' no início do século dezenove.", false),
            new Alt("Permitiu transportar toneladas de mercadorias e centenas de passageiros por terra com velocidade nunca antes vista.", false),
            new Alt("Era puxada por uma parelha de duzentos pombos-correios voando com cordas.", true)
        }));
        l8.Add(new Q("A Locomotiva Rocket de Stephenson", new Alt[] {
            new Alt("Venceu os históricos testes de Rainhill em 1829 ao atingir a impressionante velocidade de quase 50 km/h para a época.", false),
            new Alt("Seu design inovador com caldeira multitubular serviu de modelo mecânico para todas as locomotivas seguintes.", false),
            new Alt("Era um foguete espacial que decolou rumo à Lua no século dezenove com seu piloto.", true)
        }));
        l8.Add(new Q("O Navio a Vapor", new Alt[] {
            new Alt("Pioneiramente demonstrado por Robert Fulton com o navio Clermont em 1807 no rio Hudson (EUA).", false),
            new Alt("Liberou a navegação marítima e fluvial da dependência dos ventos inconstantes, encurtando viagens oceânicas.", false),
            new Alt("Afundava propositalmente até o fundo do oceano para os passageiros dormirem com peixes.", true)
        }));
        l8.Add(new Q("A Hélice Marítima", new Alt[] {
            new Alt("Substituiu as pesadas e vulneráveis rodas de pás laterais dos navios a vapor por um propulsor submerso na popa.", false),
            new Alt("Garantiu muito maior eficiência, velocidade e segurança mecânica para viagens em mares bravios abertos.", false),
            new Alt("Era um ventilador de teto comum amarrado no mastro do navio para soprar as velas.", true)
        }));
        l8.Add(new Q("O Telégrafo Elétrico de Samuel Morse", new Alt[] {
            new Alt("Permitiu transmitir mensagens escritas instantâneas por fios condutores elétricos ao longo de centenas de quilômetros.", false),
            new Alt("Revolucionou a comunicação mundial de jornais, governos e estradas de ferro no século dezenove.", false),
            new Alt("Transmitia fotografias coloridas e vídeos em alta definição pela televisão aberta.", true)
        }));
        l8.Add(new Q("O Código Morse", new Alt[] {
            new Alt("É um sistema de comunicação engenhoso que representa letras e números através de pontos curtos e traços longos.", false),
            new Alt("O sinal de socorro internacional mais conhecido no mundo em código Morse é o SOS (... --- ...).", false),
            new Alt("Era uma coreografia de dança de sapateado inventada para apresentações de circo.", true)
        }));
        l8.Add(new Q("O Cabo Submarino Transatlântico", new Alt[] {
            new Alt("Foi uma façanha monumental de engenharia que estendeu cabos telegráficos no fundo do oceano ligando Europa à América.", false),
            new Alt("Permitiu que notícias que antes levavam semanas em caravelas chegassem em poucos minutos de um continente a outro.", false),
            new Alt("Foi instalado por astronautas da NASA usando naves espaciais submarinas.", true)
        }));
        l8.Add(new Q("O Telefone de Alexander Graham Bell (1876)", new Alt[] {
            new Alt("Aparelho capaz de converter ondas sonoras da voz humana em impulsos elétricos transmitidos por fios em tempo real.", false),
            new Alt("A primeira frase falada ao telefone por Bell foi para seu assistente: 'Senhor Watson, venha cá, eu preciso do senhor!'.", false),
            new Alt("Funcionava sem fios enviando pensamentos telepáticos através de cristais mágicos.", true)
        }));
        l8.Add(new Q("Thomas Edison e a Lâmpada Incandescente (1879)", new Alt[] {
            new Alt("Aperfeiçoou uma lâmpada elétrica prática e duradoura com filamento de carbono no vácuo de uma ampola de vidro.", false),
            new Alt("Iluminou cidades e casas com eletricidade limpa, substituindo as perigosas lâmpadas de óleo e gás de rua.", false),
            new Alt("Inventou uma lâmpada que funcionava à base de fogueira de lenha dentro de uma caixa de papelão.", true)
        }));
        l8.Add(new Q("O Fonógrafo de Thomas Edison", new Alt[] {
            new Alt("Foi o primeiro aparelho capaz de gravar mecanicamente o som e reproduzir a voz humana gravada em um cilindro.", false),
            new Alt("A primeira gravação de áudio feita por Edison foi a rima infantil inglesa 'Mary Had a Little Lamb'.", false),
            new Alt("Era um rádio relógio digital que despertava as pessoas com alertas de aplicativo.", true)
        }));
        l8.Add(new Q("Nikola Tesla e a Corrente Alternada", new Alt[] {
            new Alt("Genial cientista que desenvolveu o sistema de eletricidade por corrente alternada (AC) usado em todo o mundo moderno.", false),
            new Alt("Permitiu transportar energia elétrica em altíssima voltagem por longas distâncias com perdas mínimas de potência.", false),
            new Alt("Defendia que toda eletricidade devia ser gerada com pilhas de limão espetadas com garfos.", true)
        }));
        l8.Add(new Q("A Fotografia e Joseph Nicéphore Niépce", new Alt[] {
            new Alt("Registrou a primeira fotografia permanente da história em 1826, capturando a vista de sua janela em uma placa de estanho.", false),
            new Alt("A exposição da placa à luz do Sol levou mais de oito horas seguidas para fixar a imagem nítida.", false),
            new Alt("Tirou uma selfie instantânea com um smartphone conectado ao aplicativo de fotos.", true)
        }));
        l8.Add(new Q("O Daguerreótipo de Louis Daguerre", new Alt[] {
            new Alt("Foi o primeiro processo fotográfico prático comercializado, fixando imagens detalhadas sobre placas de cobre prateadas.", false),
            new Alt("O imperador brasileiro Dom Pedro II foi um dos primeiros fotógrafos amadores da América Latina a comprar um daguerreótipo.", false),
            new Alt("Era uma impressora 3D que imprimia estátuas de bronze maciço em segundos.", true)
        }));
        l8.Add(new Q("Os Irmãos Lumière e o Cinema (1895)", new Alt[] {
            new Alt("Auguste e Louis Lumière inventaram o Cinematógrafo em Paris, uma câmera e projetor de filmes pioneiro.", false),
            new Alt("Exibiram o célebre curta-metragem da chegada de um trem à estação de La Ciotat, assustando o público na plateia.", false),
            new Alt("Inventaram o videogame com óculos de realidade virtual para computadores modernos.", true)
        }));
        l8.Add(new Q("O Cinema Mudo", new Alt[] {
            new Alt("Nas primeiras décadas do cinema, os filmes não tinham som sincronizado e usavam legendas explicativas na tela.", false),
            new Alt("As exibições nas salas de cinema eram acompanhadas ao vivo por pianistas ou pequenas orquestras tocando na sala.", false),
            new Alt("Eram filmes gravados em fita cassete moderna exibidos em aparelhos de DVD.", true)
        }));
        l8.Add(new Q("Charlie Chaplin e Carlitos", new Alt[] {
            new Alt("Foi um dos maiores gênios cômicos do cinema mudo, criador do imortal personagem 'O Vagabundo' (The Tramp).", false),
            new Alt("Famoso por seu bigodinho característico, chapéu-coco preto, bengala de junco e passinhos desajeitados e engraçados.", false),
            new Alt("Era um astronauta que apresentava o telejornal matutino em rede de satélite.", true)
        }));
        l8.Add(new Q("A Bicicleta Antiga de Roda Alta (Penny-Farthing)", new Alt[] {
            new Alt("Tinha uma roda dianteira colossal e uma roda traseira minúscula, popular na Europa no final do século dezenove.", false),
            new Alt("Como os pedais eram fixados diretamente no eixo da roda dianteira, quanto maior a roda, mais distância percorria a cada pedalada.", false),
            new Alt("Tinha asas de avião e voava sobre os prédios para fugir do trânsito da cidade.", true)
        }));
        l8.Add(new Q("A Bicicleta Moderna de Segurança (Safety Bicycle)", new Alt[] {
            new Alt("Introduziu duas rodas de mesmo tamanho, quadro tubular triangular e tração por corrente ligada à roda traseira.", false),
            new Alt("Os pneus de borracha infláveis inventados por John Boyd Dunlop tornaram o passeio infinitamente mais suave e seguro.", false),
            new Alt("Era movida por um pequeno reator nuclear instalado debaixo do selim de couro.", true)
        }));
        l8.Add(new Q("Karl Benz e o Primeiro Automóvel a Gasolina (1886)", new Alt[] {
            new Alt("Karl Benz patenteou na Alemanha o Benz Patent-Motorwagen, amplamente considerado o primeiro carro a gasolina moderno.", false),
            new Alt("Possuía três rodas com raios de arame, motor de combustão interna traseiro de um cilindro e alavanca no lugar do volante.", false),
            new Alt("Era um carro voador supersônico que viajava a mil quilômetros por hora no céu.", true)
        }));
        l8.Add(new Q("A Primeira Viagem de Carro de Bertha Benz", new Alt[] {
            new Alt("Bertha Benz, esposa de Karl Benz, realizou a primeira viagem longa de automóvel da história (cerca de 100 km) sem avisar o marido.", false),
            new Alt("Usou um grampo de cabelo para desentupir o cano de combustível e comprou benzina de farmácia para abastecer no caminho.", false),
            new Alt("Viajou de navio cruzeiro com o carro guardado em uma mala de roupas dobradas.", true)
        }));
        l8.Add(new Q("Henry Ford e a Linha de Montagem Móvel", new Alt[] {
            new Alt("Revolucionou a indústria automobilística mundial introduzindo a esteira rolante mecânica de produção em série em 1913.", false),
            new Alt("Com a fabricação rápida e barata do famoso Ford Bigode (Modelo T), tornou os carros acessíveis para a classe trabalhadora.", false),
            new Alt("Fabricava carros manualmente com peças esculpidas em madeira de pinho na praia.", true)
        }));
        l8.Add(new Q("O Ford Modelo T (Ford Bigode)", new Alt[] {
            new Alt("Foi o primeiro automóvel produzido em massa acessível a milhões de famílias ao redor do planeta.", false),
            new Alt("Henry Ford declarou a célebre frase: 'O cliente pode ter o carro da cor que quiser, desde que seja preto!'.", false),
            new Alt("Era um carro conversível que andava debaixo d'água no fundo de lagoas.", true)
        }));
        l8.Add(new Q("O Dirigível Zeppelin", new Alt[] {
            new Alt("Foi uma colossal aeronave rígida de passageiros projetada pelo conde alemão Ferdinand von Zeppelin no início do século vinte.", false),
            new Alt("Sua imensa estrutura leve de alumínio era preenchida com bolsas de gás mais leve que o ar e impulsionada por motores a hélice.", false),
            new Alt("Era um balão de festa de aniversário de borracha cheio de água da torneira.", true)
        }));
        l8.Add(new Q("O Graf Zeppelin e as Viagens ao Brasil", new Alt[] {
            new Alt("O gigante dirigível alemão realizou viagens transatlânticas regulares de luxo entre a Europa e o Brasil na década de 1930.", false),
            new Alt("Pousava no histórico hangar de dirigíveis de Santa Cruz, na cidade do Rio de Janeiro.", false),
            new Alt("Pousava no topo do Corcovado equilibrado sobre o braço do Cristo Redentor.", true)
        }));
        l8.Add(new Q("Santos Dumont e o Balão Dirigível N° 6 (1901)", new Alt[] {
            new Alt("O brilhante inventor brasileiro Alberto Santos Dumont contornou a Torre Eiffel em Paris a bordo de seu dirigível N° 6.", false),
            new Alt("Ganhou o prestigioso prêmio Deutsch de la Meurthe, provando perante o mundo que o ar podia ser dirigido e controlado com motor.", false),
            new Alt("Contornou a Torre Eiffel voando com uma asa delta feita de folhas de bananeira.", true)
        }));
        l8.Add(new Q("Santos Dumont e o 14-Bis (1906)", new Alt[] {
            new Alt("Realizou o primeiro voo homologado da história de um aparelho mais pesado que o ar decolando pelos próprios meios em Paris.", false),
            new Alt("No Campo de Bagatelle perante a comissão oficial do Aeroclube da França, o 14-Bis voou cerca de 60 metros sem rampas ou catapultas.", false),
            new Alt("Decolou empurrado por um foguete espacial conectado a uma usina elétrica moderna.", true)
        }));
        l8.Add(new Q("O Monoplano Demoiselle de Santos Dumont", new Alt[] {
            new Alt("Foi uma das aeronaves mais leves, práticas e elegantes da pioneira era da aviação, feita com bambu e seda japonesa.", false),
            new Alt("Santos Dumont não patenteou a invenção, publicando os desenhos técnicos gratuitamente para que todos pudessem construir.", false),
            new Alt("Pesava mais de cinquenta toneladas e precisava de seis motores de caminhão a diesel.", true)
        }));
        l8.Add(new Q("O Relógio de Pulso de Santos Dumont", new Alt[] {
            new Alt("Santos Dumont pediu ao amigo joalheiro Louis Cartier um relógio preso ao pulso para cronometrar voos sem soltar os comandos.", false),
            new Alt("Essa criação histórica ajudou a popularizar definitivamente o relógio de pulso masculino em todo o mundo.", false),
            new Alt("Era um relógio de parede de cuco que Santos Dumont amarrava na perna com cordas.", true)
        }));
        l8.Add(new Q("O Rádio e Guglielmo Marconi", new Alt[] {
            new Alt("Pioneiro nas transmissões telegráficas sem fio por meio de ondas eletromagnéticas de rádio pelo ar.", false),
            new Alt("Em 1901 conseguiu transmitir com sucesso o primeiro sinal de rádio sem fio através do Oceano Atlântico.", false),
            new Alt("Transmitia programas de culinária através de latas amarradas por barbantes grossos.", true)
        }));
        l8.Add(new Q("A Primeira Transmissão de Rádio no Brasil (1922)", new Alt[] {
            new Alt("Ocorreu no Rio de Janeiro durante as celebrações do centenário da Independência, com discurso do presidente Epitácio Pessoa.", false),
            new Alt("Um transmissor instalado no alto do morro do Corcovado emitiu músicas e transmissões captadas em alto-falantes da cidade.", false),
            new Alt("Foi transmitida através de espelhos refletores que piscavam em código binário.", true)
        }));
        l8.Add(new Q("A Máquina de Escrever", new Alt[] {
            new Alt("Aparelho mecânico pioneiro que imprimia letras e caracteres em folhas de papel ao bater tipos de chumbo sobre fita entintada.", false),
            new Alt("A disposição de teclas 'QWERTY' criada para evitar que as hastes mecânicas travassem é usada até hoje nos teclados de celular.", false),
            new Alt("Funcionava com uma caneta hidrográfica mágica acionada por comando de voz.", true)
        }));
        l8.Add(new Q("A Máquina de Costura de Isaac Singer", new Alt[] {
            new Alt("Aperfeiçoou a máquina de costura prática operada por pedal mecânico com agulha de ponta furada de movimento reto.", false),
            new Alt("Transformou a fabricação doméstica e fabril de roupas, acelerando o trabalho de alfaiates e costureiras.", false),
            new Alt("Costurava roupas usando fita adesiva escolar e cola branca de papel.", true)
        }));
        l8.Add(new Q("A Vacina e Edward Jenner", new Alt[] {
            new Alt("Em 1796, desenvolveu a primeira vacina com sucesso no mundo, descobrindo imunização contra a perigosa varíola humana.", false),
            new Alt("O termo 'vacina' deriva do latim 'vaccinus' (relativo à vaca), porque usava o vírus da varíola bovina para imunizar.", false),
            new Alt("Inventou uma vacina que transformava as pessoas em pássaros cantores na floresta.", true)
        }));
        l8.Add(new Q("Louis Pasteur e a Pasteurização", new Alt[] {
            new Alt("Brilhante cientista francês que descobriu que micróbios e bactérias causam doenças infecciosas e fermentação.", false),
            new Alt("Criou o método de pasteurização, aquecendo líquidos como o leite para eliminar bactérias nocivas antes do consumo seguro.", false),
            new Alt("Acreditava que todos os micróbios eram pedrinhas que caíam da Lua durante a chuva.", true)
        }));
        l8.Add(new Q("A Penicilina e Alexander Fleming (1928)", new Alt[] {
            new Alt("O cientista escocês Alexander Fleming notou por acaso que um fungo (Penicillium) destruía colônias de bactérias em sua placa de laboratório.", false),
            new Alt("Foi o primeiro antibiótico eficaz da história, salvando milhões de vidas humanas contra infecções bacterianas graves.", false),
            new Alt("Era um tipo de xampu infantil usado para lavar cabelos cacheados.", true)
        }));
        l8.Add(new Q("O Raio X e Wilhelm Röntgen (1895)", new Alt[] {
            new Alt("Descobriu acidentalmente uma radiação invisível capaz de atravessar tecidos moles e revelar os ossos do corpo humano.", false),
            new Alt("A primeira radiografia médica da história mostrou os ossos da mão de sua esposa com o anel de casamento no dedo.", false),
            new Alt("Era uma lanterna de brinquedo que projetava desenhos de super-heróis na parede.", true)
        }));
        l8.Add(new Q("A Pilha Elétrica de Alessandro Volta (1800)", new Alt[] {
            new Alt("Construiu a primeira bateria elétrica da história empilhando discos alternados de cobre e zinco separados por feltro com água salgada.", false),
            new Alt("A unidade de potencial elétrico 'Volt' foi batizada em todo o mundo em sua justa e perpétua homenagem científica.", false),
            new Alt("Era uma bateria feita de fatias de pão de forma torradas no forno elétrico.", true)
        }));
        l8.Add(new Q("O Motor Elétrico de Michael Faraday", new Alt[] {
            new Alt("Descobriu o princípio da indução eletromagnética em 1831, provando que um ímã em movimento gera corrente elétrica em um fio.", false),
            new Alt("Suas pesquisas fundamentaram o surgimento de todos os motores elétricos e geradores de usinas modernos da humanidade.", false),
            new Alt("Inventou um motor que funcionava à base de suco de laranja natural e gelo moído.", true)
        }));
        l8.Add(new Q("O Submarino Militar (O Turtle de Bushnell)", new Alt[] {
            new Alt("O 'Turtle' construído em 1775 durante a Guerra de Independência Americana foi o primeiro submarino militar usado em combate.", false),
            new Alt("Tinha formato de bolota de madeira operado por um único piloto que girava manivelas de hélice manualmente.", false),
            new Alt("Era feito de queijo provolone e navegava impulsionado por cardumes de peixes-palhaço.", true)
        }));
        l8.Add(new Q("A Ponte Pênsil de Cabos de Aço (Ponte do Brooklyn)", new Alt[] {
            new Alt("Inaugurada em 1883 ligando Manhattan ao Brooklyn, foi uma das maiores obras de engenharia civil do século dezenove.", false),
            new Alt("Utilizou pela primeira vez gigantescos cabos trançados de aço de alta resistência para suspender o imenso vão central.", false),
            new Alt("Foi suspensa por milhares de balões de gás hélio coloridos amarrados nas vigas.", true)
        }));
        l8.Add(new Q("O Elevador Seguro de Elisha Otis (1853)", new Alt[] {
            new Alt("Inventou um engenhoso freio de segurança automático que travava a cabine do elevador imediatamente se os cabos de tração se partissem.", false),
            new Alt("Sua invenção revolucionária permitiu a construção dos primeiros edifícios arranha-céus modernos nas grandes cidades.", false),
            new Alt("Era uma cesta de piquenique puxada para cima por macacos adestrados.", true)
        }));
        l8.Add(new Q("O Concreto Armado", new Alt[] {
            new Alt("Combinação de concreto com armaduras internas de barras de ferro ou aço, inventada e patenteada no século dezenove.", false),
            new Alt("Permitiu construir pontes, viadutos, represas e prédios altíssimos com enorme resistência à tração e compressão.", false),
            new Alt("Era uma massa feita de purê de batatas com queijo ralado seco.", true)
        }));
        l8.Add(new Q("A Canal do Panamá e sua Construção", new Alt[] {
            new Alt("Aberta oficialmente em 1914, é uma das maiores façanhas da engenharia humana, encurtando viagens entre oceanos em milhares de quilômetros.", false),
            new Alt("Utiliza um monumental sistema de eclusas com portas de aço gigantes que sobem e descem navios como elevadores aquáticos.", false),
            new Alt("Foi cavada por formigas operárias que carregavam grãos de terra nas costas.", true)
        }));
        l8.Add(new Q("A Borracha Vulcanizada de Charles Goodyear", new Alt[] {
            new Alt("Descobriu acidentalmente que aquecer borracha natural com enxofre tornava o material elástico, resistente ao calor e durável.", false),
            new Alt("Esse processo patenteado de vulcanização viabilizou a fabricação moderna de pneus, solas de sapatos e mangueiras industriais.", false),
            new Alt("Transformou a borracha em um doce mastigável vendido em saquinhos plásticos.", true)
        }));
        l8.Add(new Q("A Dinamite de Alfred Nobel (1867)", new Alt[] {
            new Alt("O químico sueco Alfred Nobel estabilizou a perigosa nitroglicerina líquida misturando-a com terra siliciosa absorvente.", false),
            new Alt("Permitiu abrir túneis de ferrovias em montanhas rochosas com segurança e sua fortuna financiou a criação do Prêmio Nobel.", false),
            new Alt("Era uma vela aromática de aniversário usada para cantar parabéns em festas.", true)
        }));
        l8.Add(new Q("O Prêmio Nobel", new Alt[] {
            new Alt("Criado pelo testamento de Alfred Nobel, premia anualmente desde 1901 indivíduos que prestam grandes benefícios à humanidade.", false),
            new Alt("Reconhece avanços notáveis nas áreas de Física, Química, Medicina, Literatura e na causa nobre da Paz Mundial.", false),
            new Alt("É um troféu de plástico dado para quem vence corridas de carrinho de rolimã na rua.", true)
        }));

        // ==========================================
        // NIVEL 9: SÉCULO XX E CORRIDA ESPACIAL (50 Questões)
        // ==========================================
        var l9 = levels[9];
        l9.Add(new Q("O Naufrágio do Titanic (1912)", new Alt[] {
            new Alt("O colossal transatlântico britânico considerado insubmersível colidiu com um iceberg em sua viagem inaugural pelo Atlântico Norte.", false),
            new Alt("O navio transportava mais de duas mil pessoas e afundou nas águas geladas da madrugada por falta de botes suficientes para todos.", false),
            new Alt("O Titanic afundou porque foi atacado por um bando de pterodáctilos voadores gigantes.", true)
        }));
        l9.Add(new Q("A Primeira Guerra Mundial (1914-1918)", new Alt[] {
            new Alt("Foi um devastador conflito global centrado na Europa que envolveu as maiores potências militares de sua época.", false),
            new Alt("Ficou historicamente marcada pela dura guerra de trincheiras e pelo uso pioneiro de aviões, tanques e gases em combate.", false),
            new Alt("Foi uma guerra disputada exclusivamente por partidas de videogame eletrônico no sofá.", true)
        }));
        l9.Add(new Q("Os Primeiros Tanques de Guerra", new Alt[] {
            new Alt("Desenvolvidos pelo exército britânico na Primeira Guerra Mundial com esteiras de lagarta para cruzar trincheiras de lama e arame.", false),
            new Alt("Receberam o codinome secreto 'tanque' (caixa de água) para despistar os espiões inimigos durante a sua fabricação.", false),
            new Alt("Eram feitos de papelão dobrado com janelas de vidro comum de janela residencial.", true)
        }));
        l9.Add(new Q("A Aviação na Primeira Guerra Mundial", new Alt[] {
            new Alt("Os biplanos e triplanos de madeira e lona foram usados inicialmente para reconhecimento e depois em combates aéreos ferozes.", false),
            new Alt("Pilotos ases do ar habilidosos como o lendário 'Barão Vermelho' tornaram-se mundialmente famosos por suas manobras acrobáticas.", false),
            new Alt("Os aviões eram lançados ao ar por estilingues de borracha presos em postes de luz.", true)
        }));
        l9.Add(new Q("A Gripe Espanhola de 1918", new Alt[] {
            new Alt("Foi uma das mais mortíferas pandemias da história humana, causada por uma cepa do vírus influenza que infectou milhões no mundo.", false),
            new Alt("Apesar do nome 'espanhola', a imprensa da Espanha foi apenas a primeira a noticiar a crise abertamente sem censura de guerra.", false),
            new Alt("Era uma doença causada por comer muita paella com azeite de oliva espanhol.", true)
        }));
        l9.Add(new Q("A Travessia do Atlântico por Charles Lindbergh (1927)", new Alt[] {
            new Alt("Foi o primeiro piloto a realizar um voo solo e sem escalas cruzando o Oceano Atlântico de Nova York até Paris.", false),
            new Alt("Pilotou seu monoplano 'Spirit of St. Louis' por mais de 33 horas contínuas em uma proeza aeronáutica que comoveu o planeta.", false),
            new Alt("Cruzou o oceano voando montado nas costas de uma gaivota branca adestrada.", true)
        }));
        l9.Add(new Q("A Grande Depressão de 1929", new Alt[] {
            new Alt("Começou com o violento colapso da Bolsa de Valores de Nova York em outubro de 1929 ('Quinta-Feira Negra').", false),
            new Alt("Provocou fechamento em massa de fábricas, falências de bancos e desemprego generalizado em dezenas de países do mundo.", false),
            new Alt("Foi um dia em que todas as lojas do mundo distribuíram brinquedos de graça para crianças.", true)
        }));
        l9.Add(new Q("A Segunda Guerra Mundial (1939-1945)", new Alt[] {
            new Alt("Foi o maior, mais letal e mais destrutivo conflito bélico de toda a história humana, opondo os Aliados e as potências do Eixo.", false),
            new Alt("Terminou em 1945 com a derrota total do nazifascismo na Europa e a capitulação do Império Japonês no Pacífico.", false),
            new Alt("Foi um torneio mundial de queimada disputado em uma quadra poliesportiva de Londres.", true)
        }));
        l9.Add(new Q("O Dia D e a Batalha da Normandia (1944)", new Alt[] {
            new Alt("Foi a colossal operação de desembarque naval e aéreo aliada nas praias da Normandia (França) para libertar a Europa ocupada.", false),
            new Alt("Milhares de navios de guerra, lanchas de desembarque e aviões participaram da maior invasão anfíbia já vista na história.", false),
            new Alt("Os soldados desembarcaram nas praias usando pranchas de bodyboard e toalhas de banho.", true)
        }));
        l9.Add(new Q("A Força Expedicionária Brasileira (FEB) na Segunda Guerra", new Alt[] {
            new Alt("O Brasil foi o único país independente da América do Sul a enviar tropas combatentes de infantaria e aviação para os campos europeus.", false),
            new Alt("Mais de 25 mil 'pracinhas' brasileiros lutaram bravamente no front da Itália, conquistando batalhas célebres como Monte Castelo.", false),
            new Alt("Os pracinhas brasileiros foram enviados à Europa para dar aulas de samba para os soldados aliados.", true)
        }));
        l9.Add(new Q("O Símbolo da Cobra Fumando", new Alt[] {
            new Alt("Era o lema e distintivo oficial da Força Expedicionária Brasileira: um escudo verde com uma cobra verde fumando cachimbo.", false),
            new Alt("Nasceu como resposta patriótica à frase popular da época que dizia ser 'mais fácil uma cobra fumar do que o Brasil entrar na guerra'.", false),
            new Alt("Foi criado porque os soldados brasileiros criavam cobras cascavéis dentro dos capacetes de aço.", true)
        }));
        l9.Add(new Q("O Grupo de Aviação de Caça do Brasil (1° GAvCa)", new Alt[] {
            new Alt("Pilotando os poderosos caças norte-americanos P-47 Thunderbolt nos céus da Itália, realizaram centenas de missões de ataque.", false),
            new Alt("Ficaram mundialmente famosos pelo grito de guerra empolgante 'Senta a Púa!' e pelo distintivo do avestruz guerreiro.", false),
            new Alt("Pilotavam balões infláveis movidos a pedalinhos que lançavam bexigas d'água.", true)
        }));
        l9.Add(new Q("A Criação da ONU (Organização das Nações Unidas)", new Alt[] {
            new Alt("Fundada em 1945 em São Francisco após o término da Segunda Guerra Mundial para manter a paz e a segurança internacional.", false),
            new Alt("Reúne quase todos os países soberanos do planeta com a missão de resolver conflitos por meio do diálogo e cooperação diplomática.", false),
            new Alt("É uma empresa multinacional privada que fábrica refrigerantes de cola e batatas fritas.", true)
        }));
        l9.Add(new Q("A Declaração Universal dos Direitos Humanos (1948)", new Alt[] {
            new Alt("Proclamada pela Assembleia Geral da ONU em Paris, estabelece direitos fundamentais inalienáveis a todos os seres humanos.", false),
            new Alt("Declara solenemente que todos os seres humanos nascem livres e iguais em dignidade e em direitos perante a lei.", false),
            new Alt("Exige que todas as crianças do mundo comam brócolis cozido no almoço de domingo.", true)
        }));
        l9.Add(new Q("A Guerra Fria", new Alt[] {
            new Alt("Foi o longo período de tensão geopolítica, ideológica e tecnológica entre os Estados Unidos e a União Soviética (1947-1991).", false),
            new Alt("Ficou conhecida como 'guerra fria' porque as duas superpotências nucleares nunca se enfrentaram diretamente em guerra militar total.", false),
            new Alt("Foi uma guerra disputada jogando bolas de neve congelada durante tempestades polares.", true)
        }));
        l9.Add(new Q("A Corrida Espacial", new Alt[] {
            new Alt("Foi a emocionante disputa tecnológica e científica entre Estados Unidos e União Soviética para alcançar conquistas no espaço sideral.", false),
            new Alt("Impulsionou investimentos monumentais em foguetes de longo alcance, telecomunicações, satélites, robótica e eletrônica de ponta.", false),
            new Alt("Era uma gincana de parque onde crianças corriam vestidas com fantasias de alienígenas.", true)
        }));
        l9.Add(new Q("O Satélite Sputnik 1 (1957)", new Alt[] {
            new Alt("Lançado com sucesso pela União Soviética em 4 de outubro de 1957, foi o primeiro satélite artificial a orbitar o planeta Terra.", false),
            new Alt("Era uma esfera prateada polida de metal com quatro antenas de rádio que emitia os célebres bips captados em todo o mundo.", false),
            new Alt("Era uma bola de futebol oficial autografada por jogadores soviéticos lançada por um canhão.", true)
        }));
        l9.Add(new Q("A Cadela Laika (1957)", new Alt[] {
            new Alt("Foi uma corajosa cadelinha resgatada das ruas de Moscou que se tornou o primeiro ser vivo terrestre a orbitar o espaço a bordo do Sputnik 2.", false),
            new Alt("Sua histórica missão pioneira provou aos cientistas espaciais que um organismo vivo podia suportar a ausência de gravidade.", false),
            new Alt("Era uma gata persa de coleira dourada que pilotava o foguete usando as patinhas.", true)
        }));
        l9.Add(new Q("Yuri Gagarin e o Primeiro Homem no Espaço (1961)", new Alt[] {
            new Alt("O cosmonauta soviético Yuri Gagarin tornou-se em 12 de abril de 1961 o primeiro ser humano a viajar pelo espaço sideral.", false),
            new Alt("A bordo de sua espaçonave Vostok 1, deu uma volta completa na órbita da Terra e proferiu a célebre frase: 'A Terra é azul!'.", false),
            new Alt("Chegou ao espaço voando pendurado em cem bexigas de festa amarradas na cintura.", true)
        }));
        l9.Add(new Q("Alan Shepard e a Resposta Americana", new Alt[] {
            new Alt("Menos de um mês após Gagarin, Alan Shepard tornou-se o primeiro astronauta norte-americano a ser lançado ao espaço em voo suborbital.", false),
            new Alt("Anos mais tarde, comandou a missão Apollo 14 pousando na Lua, onde ficou célebre por dar tacadas de golfe na poeira lunar.", false),
            new Alt("Viajou para o espaço nadando de costas dentro de uma cápsula cheia de água mineral.", true)
        }));
        l9.Add(new Q("O Discurso do Presidente John F. Kennedy (1962)", new Alt[] {
            new Alt("Fez um histórico e vibrante discurso na Universidade Rice lançando a meta de enviar astronautas à Lua antes do final da década de 60.", false),
            new Alt("Afirmou corajosamente: 'Escolhemos ir para a Lua não porque é fácil, mas sim porque é difícil!'.", false),
            new Alt("Prometeu que os Estados Unidos iam construir um cinema drive-in de carros na superfície do Sol.", true)
        }));
        l9.Add(new Q("O Foguete Saturn V", new Alt[] {
            new Alt("É o mais poderoso e colossal foguete lançado com sucesso operacional da história humana, erguendo-se a 111 metros de altura.", false),
            new Alt("Seus cinco gigantescos motores F-1 do primeiro estágio consumiam toneladas de querosene e oxigênio líquido por segundo na decolagem.", false),
            new Alt("Era feito de madeira compensada e utilizava pólvora de bombinha junina para subir.", true)
        }));
        l9.Add(new Q("A Missão Apollo 11 (1969)", new Alt[] {
            new Alt("Foi a lendária missão espacial da NASA que levou os primeiros seres humanos a pousar com segurança na superfície da Lua.", false),
            new Alt("A tripulação heroica era composta pelos astronautas Neil Armstrong, Buzz Aldrin e Michael Collins.", false),
            new Alt("Chegou à Lua em uma carruagem mágica puxada por seis cavalos brancos alados.", true)
        }));
        l9.Add(new Q("O Pouso na Lua com a Eagle (20 de Julho de 1969)", new Alt[] {
            new Alt("O módulo lunar 'Eagle' tocou com sucesso a superfície cinzenta da Lua na região conhecida como o Mar da Tranquilidade.", false),
            new Alt("Neil Armstrong anunciou pelo rádio para o controle da missão em Houston: 'Houston, aqui Base da Tranquilidade. A Águia pousou!'.", false),
            new Alt("O módulo capotou em um lago de suco de maracujá borbulhante e afundou na lama.", true)
        }));
        l9.Add(new Q("Neil Armstrong e o Primeiro Passo Humano na Lua", new Alt[] {
            new Alt("Desceu pela escada do módulo lunar e colocou pela primeira vez a bota de um ser humano no solo de outro corpo celeste.", false),
            new Alt("Transmitiu ao vivo para centenas de milhões de pessoas na Terra a imortal frase: 'Um pequeno passo para o homem, um salto gigantesco para a humanidade'.", false),
            new Alt("Pisou na Lua e disse: 'Que pena, esqueci a chave da porta de casa lá na Terra!'.", true)
        }));
        l9.Add(new Q("Buzz Aldrin e a Magnífica Desolação", new Alt[] {
            new Alt("Foi o segundo homem a pisar no solo da Lua, descrevendo a paisagem silenciosa e monocromática como uma 'magnífica desolação'.", false),
            new Alt("Fincaram a bandeira norte-americana com uma haste horizontal para que ficasse aberta no vácuo sem vento da Lua.", false),
            new Alt("Abriu uma lanchonete na Lua para vender cachorro-quente para outros astronautas.", true)
        }));
        l9.Add(new Q("Michael Collins no Módulo de Comando Columbia", new Alt[] {
            new Alt("Enquanto Armstrong e Aldrin exploravam o solo lunar, Collins permaneceu sozinho em órbita pilotando o módulo de comando Columbia.", false),
            new Alt("Ao passar pelo lado oculto da Lua, ficava totalmente incomunicável com a Terra, sendo considerado o homem mais solitário do universo.", false),
            new Alt("Dormiu a viagem inteira enrolado em um edredom de plumas sem pilotar nada.", true)
        }));
        l9.Add(new Q("O Traje Espacial dos Astronautas da Apollo (A7L)", new Alt[] {
            new Alt("Era uma verdadeira espaçonave pessoal com múltiplas camadas protetoras contra o vácuo, micrometeoritos e temperaturas extremas.", false),
            new Alt("Possuía mochila de suporte à vida que fornecia oxigênio, pressurização, água de refrigeração e rádio de comunicação.", false),
            new Alt("Era um calção de banho comum e óculos escuros de praia comprados em uma loja de conveniência.", true)
        }));
        l9.Add(new Q("A Gravidade na Lua", new Alt[] {
            new Alt("A gravidade na superfície da Lua é cerca de seis vezes mais fraca que a gravidade na superfície do planeta Terra.", false),
            new Alt("Isso permitia que os astronautas carregando pesados trajes espaciais dessem pulos compridos e saltitantes como cangurus.", false),
            new Alt("A gravidade lunar é tão forte que os astronautas ficam grudados no chão sem conseguir levantar a cabeça.", true)
        }));
        l9.Add(new Q("As Amostras de Rochas Lunares", new Alt[] {
            new Alt("As seis missões Apollo que pousaram na Lua trouxeram de volta à Terra mais de 380 quilos de rochas e poeira lunar (regolito).", false),
            new Alt("As amostras continuam sendo estudadas em laboratórios do mundo todo, revelando segredos sobre a formação do Sistema Solar.", false),
            new Alt("As rochas eram fatias de queijo suíço que derreteram assim que chegaram ao calor do laboratório.", true)
        }));
        l9.Add(new Q("O Rover Lunar (O Carro da Lua)", new Alt[] {
            new Alt("Foi um jipe lunar elétrico de quatro rodas estreado na missão Apollo 15 que permitiu aos astronautas explorar crateras distantes.", false),
            new Alt("Tinha pneus especiais feitos de malha de arame de aço trançada com travas de titânio para não furar na poeira afiada.", false),
            new Alt("Era um caminhão a diesel que soltava fumaça preta pelos escapamentos no vácuo da Lua.", true)
        }));
        l9.Add(new Q("A Missão Apollo 13 e a Frase Famosa", new Alt[] {
            new Alt("Um tanque de oxigênio explodiu a caminho da Lua, ameaçando a vida dos três astronautas a bordo no meio do espaço.", false),
            new Alt("Em uma impressionante operação de resgate em equipe com os engenheiros de Houston, a tripulação conseguiu retornar em segurança à Terra.", false),
            new Alt("Os astronautas desceram do foguete e foram andando até a estação espacial mais próxima pedir carona.", true)
        }));
        l9.Add(new Q("A Primeira Estação Espacial: Salyut 1 (1971)", new Alt[] {
            new Alt("Lançada pela União Soviética, foi a pioneira estação espacial orbital habitável da história colocada em órbita da Terra.", false),
            new Alt("Permitiu aos cosmonautas viver e conduzir experimentos científicos em gravidade zero por semanas consecutivas.", false),
            new Alt("Era uma casa de madeira com telhado colonial flutuando entre as nuvens de chuva.", true)
        }));
        l9.Add(new Q("A Estação Espacial Skylab (1973)", new Alt[] {
            new Alt("Foi a primeira estação espacial colocada em órbita pelos Estados Unidos, construída a partir do terceiro estágio de um foguete Saturn V.", false),
            new Alt("Possuía amplo espaço interno onde tripulações de astronautas realizaram observações solares e estudos de adaptação biológica ao espaço.", false),
            new Alt("Era um parque aquático orbital com toboágua de duzentos metros flutuando no vácuo.", true)
        }));
        l9.Add(new Q("A Missão Conjunta Apollo-Soyuz (1975)", new Alt[] {
            new Alt("Foi o histórico aperto de mãos no espaço entre astronautas norte-americanos e cosmonautas soviéticos acoplando suas naves em órbita.", false),
            new Alt("Simbolizou um marcante momento de distensão pacífica e cooperação científica internacional no auge da Guerra Fria.", false),
            new Alt("Foi uma batalha onde as naves disputaram um campeonato de tiro ao alvo contra asteroides.", true)
        }));
        l9.Add(new Q("As Sondas Voyager 1 e 2 (1977)", new Alt[] {
            new Alt("Foram lançadas pela NASA para estudar os planetas gigantes gasosos do Sistema Solar: Júpiter, Saturno, Urano e Netuno.", false),
            new Alt("A Voyager 1 é atualmente o objeto construído pela humanidade mais distante da Terra, navegando pelo espaço interestelar aberto.", false),
            new Alt("Eram dois carros esportivos vermelhos dirigidos por astronautas com macacão de corrida.", true)
        }));
        l9.Add(new Q("O Disco de Ouro das Sondas Voyager", new Alt[] {
            new Alt("Cada sonda Voyager carrega um disco de cobre folheado a ouro com saudações em 55 línguas, sons da Terra e músicas do mundo.", false),
            new Alt("Foi concebido pelo astrônomo Carl Sagan como uma mensagem em uma garrafa cósmica para possíveis civilizações extraterrestres.", false),
            new Alt("Era uma pizza congelada gigante de queijo colocada para atrair marcianos famintos.", true)
        }));
        l9.Add(new Q("O Pálido Ponto Azul (Pale Blue Dot)", new Alt[] {
            new Alt("É a famosa fotografia da Terra tirada pela sonda Voyager 1 em 1990 a mais de seis bilhões de quilômetros de distância.", false),
            new Alt("A Terra aparece como um pequenino e frágil ponto azul claro brilhando no meio de um feixe de luz solar difusa.", false),
            new Alt("Mostra a Terra quadrada como uma caixa de sapatos iluminada por lanternas de pilha.", true)
        }));
        l9.Add(new Q("O Ônibus Espacial da NASA (Space Shuttle)", new Alt[] {
            new Alt("Foi a primeira espaçonave orbital reutilizável da história, decolando como foguete e pousando planando como avião em pista.", false),
            new Alt("Realizou mais de 130 missões históricas entre 1981 e 2011, lançando satélites e construindo a estação espacial.", false),
            new Alt("Era um ônibus urbano comum com catraca de moedas que subia aos céus puxado por cabos de aço.", true)
        }));
        l9.Add(new Q("O Braço Robótico Canadarm", new Alt[] {
            new Alt("Era um braço mecânico articulado de alta precisão instalado na baía de carga dos ônibus espaciais pela Agência Espacial Canadense.", false),
            new Alt("Permitia aos astronautas capturar satélites em órbita, inspecionar escudos térmicos e montar módulos espaciais pesados.", false),
            new Alt("Era uma colher de pau gigante usada para misturar a sopa dos astronautas na cozinha.", true)
        }));
        l9.Add(new Q("O Telescópio Espacial Hubble (1990)", new Alt[] {
            new Alt("Lançado em órbita pelo ônibus espacial Discovery, revolucionou a astronomia ao fotografar o cosmos livre da atmosfera da Terra.", false),
            new Alt("Descobriu galáxias primordiais distantes, buracos negros supermassivos e ajudou a calcular com precisão a idade do universo.", false),
            new Alt("Era um óculo de brinquedo com lentes de plástico montado na ponta de uma vassoura.", true)
        }));
        l9.Add(new Q("A Missão de Reparo do Hubble (1993)", new Alt[] {
            new Alt("Logo após o lançamento, descobriu-se uma minúscula imperfeição no espelho do Hubble que deixava as imagens levemente borradas.", false),
            new Alt("Uma equipe de astronautas em caminhada espacial instalou com sucesso instrumentos corretivos óticos ('óculos' para o telescópio).", false),
            new Alt("Os astronautas limparam o espelho usando sabão em pó e esfregão de pia no espaço.", true)
        }));
        l9.Add(new Q("A Estação Espacial Mir (1986-2001)", new Alt[] {
            new Alt("Foi a pioneira e duradoura estação espacial modular soviética e russa que operou em órbita por quinze anos consecutivos.", false),
            new Alt("Recebeu dezenas de cosmonautas e astronautas de várias nacionalidades, quebrando recordes de permanência humana no espaço.", false),
            new Alt("Era uma barraca de camping de lona montada na cauda de um cometa de gelo.", true)
        }));
        l9.Add(new Q("Valeri Polyakov e o Recorde no Espaço", new Alt[] {
            new Alt("O médico cosmonauta russo Valeri Polyakov passou mais de 437 dias consecutivos a bordo da estação Mir entre 1994 e 1995.", false),
            new Alt("Permanece até hoje como a mais longa permanência contínua de um único ser humano no espaço sem voltar à Terra.", false),
            new Alt("Passou os 437 dias jogando futebol de botão contra extraterrestres verdes amigáveis.", true)
        }));
        l9.Add(new Q("O Primeiro Satélite Brasileiro: SCD-1 (1993)", new Alt[] {
            new Alt("O Satélite de Coleta de Dados 1 foi o primeiro satélite construído pelo Instituto Nacional de Pesquisas Espaciais (INPE).", false),
            new Alt("Coleta e retransmite dados ambientais e meteorológicos de rios e florestas por todo o território brasileiro há décadas.", false),
            new Alt("Foi lançado ao espaço amarrado em um papagaio de papel na praia de Copacabana.", true)
        }));
        l9.Add(new Q("A Queda do Muro de Berlim (1989)", new Alt[] {
            new Alt("O Muro de Berlim, que dividiu a capital alemã durante décadas da Guerra Fria, foi derrubado em festa popular em novembro de 1989.", false),
            new Alt("Marcou o colapso simbólico das divisões da Guerra Fria e abriu caminho para a histórica reunificação da Alemanha.", false),
            new Alt("O muro foi derrubado pelo pouso de uma nave alienígena gigante com três chaminés.", true)
        }));
        l9.Add(new Q("A Dissolução da União Soviética (1991)", new Alt[] {
            new Alt("Em dezembro de 1991, a bandeira soviética foi arriada no Kremlin em Moscou, marcando o encerramento formal da URSS.", false),
            new Alt("O evento assinalou o fim definitivo da era da Guerra Fria e a independência soberana de quinze repúblicas, incluindo a Rússia.", false),
            new Alt("A União Soviética foi comprada inteira por uma rede de lojas de brinquedos americana.", true)
        }));
        l9.Add(new Q("O Satélite Sino-Brasileiro CBERS", new Alt[] {
            new Alt("É o pioneiro programa de cooperação científica aeroespacial entre o Brasil e a China para desenvolvimento de satélites de observação da Terra.", false),
            new Alt("Fornece imagens em alta resolução fundamentais para monitorar queimadas, desmatamento amazônico e safras agrícolas.", false),
            new Alt("É um satélite feito para transmitir desenhos animados em mandarim para escolas do Brasil.", true)
        }));
        l9.Add(new Q("A Sonda Pathfinder e o Rover Sojourner em Marte (1997)", new Alt[] {
            new Alt("O Sojourner foi o primeiro jipe robótico com rodas a explorar com sucesso a superfície avermelhada de outro planeta (Marte).", false),
            new Alt("Tinha o tamanho de um forno de micro-ondas e analisou a composição de rochas marcianas como a famosa pedra 'Yogi'.", false),
            new Alt("Era um patinete elétrico pilotado por um macaco astronauta usando óculos de proteção.", true)
        }));
        l9.Add(new Q("O Legado Espacial do Século XX", new Alt[] {
            new Alt("A conquista espacial transformou o cotidiano na Terra gerando o GPS, telecomunicações por satélite, painéis solares e tecidos térmicos.", false),
            new Alt("Expandiu a consciência da humanidade sobre a preciosidade de nosso planeta e a necessidade urgente de preservar nosso lar comum.", false),
            new Alt("Provou que o universo inteiro é feito de massa de modelar colorida que não acaba nunca.", true)
        }));

        // ==========================================
        // NIVEL 10: ERA MODERNA E FUTURO ESPACIAL (50 Questões)
        // ==========================================
        var l10 = levels[10];
        l10.Add(new Q("O Primeiro Computador Eletrônico (ENIAC - 1946)", new Alt[] {
            new Alt("O ENIAC foi um dos primeiros computadores digitais eletrônicos de grande escala, ocupando uma sala de mais de 160 metros quadrados.", false),
            new Alt("Pesava cerca de trinta toneladas e usava quase dezoito mil válvulas eletrônicas que esquentavam como lâmpadas acesas.", false),
            new Alt("Cabia na palma da mão de uma criança e funcionava com uma bateria de relógio de pulso.", true)
        }));
        l10.Add(new Q("A Invenção do Transistor (1947)", new Alt[] {
            new Alt("Criado nos Laboratórios Bell, substituiu as frágeis e volumosas válvulas de vidro no controle e amplificação de sinais elétricos.", false),
            new Alt("Permitiu a miniaturização dos circuitos eletrônicos, tornando viável a criação dos computadores modernos e celulares.", false),
            new Alt("Era uma guloseima doce mastigável vendida em saquinhos plásticos na entrada de cinemas.", true)
        }));
        l10.Add(new Q("O Microprocessador (O Chip de Silício)", new Alt[] {
            new Alt("Reúne milhões (e hoje bilhões) de transistores microscópicos em uma única pastilha minúscula de silício purificado.", false),
            new Alt("Funciona como o verdadeiro 'cérebro' eletrônico dos computadores, videogames modernos e smartphones contemporâneos.", false),
            new Alt("É feito de massa de pão de queijo assada e precisa ser trocado toda semana.", true)
        }));
        l10.Add(new Q("O Surgimento da Internet (ARPANET)", new Alt[] {
            new Alt("Nasceu no final da década de 1960 como ARPANET, um projeto de comunicação em rede de computadores financiado nos Estados Unidos.", false),
            new Alt("Evoluiu para a gigantesca rede mundial de computadores interligada que conecta bilhões de pessoas pelo planeta.", false),
            new Alt("Foi criada por navegadores vikings no século dez usando cabos de cipó trançados.", true)
        }));
        l10.Add(new Q("A World Wide Web (WWW) e Tim Berners-Lee (1989)", new Alt[] {
            new Alt("O cientista britânico Tim Berners-Lee inventou a World Wide Web no laboratório CERN para facilitar o compartilhamento de páginas online.", false),
            new Alt("Criou o primeiro navegador web, o protocolo HTTP, a linguagem HTML de sites e os hiperlinks clicáveis da internet.", false),
            new Alt("Inventou o primeiro aparelho de televisão analógica preto e branco a vapor.", true)
        }));
        l10.Add(new Q("O Primeiro E-mail da História (1971)", new Alt[] {
            new Alt("Ray Tomlinson enviou a primeira mensagem de correio eletrônico entre dois computadores situados lado a lado na mesma sala.", false),
            new Alt("Foi ele quem escolheu o célebre símbolo da arroba (@) no teclado para separar o nome do usuário da máquina de destino.", false),
            new Alt("A primeira mensagem foi uma carta em pergaminho amarrada na pata de um pombo-correio.", true)
        }));
        l10.Add(new Q("Os Videogames Clássicos: Pong (1972)", new Alt[] {
            new Alt("Criado pela empresa Atari, foi o primeiro videogame arcade de enorme sucesso comercial da história dos jogos eletrônicos.", false),
            new Alt("Simulava uma partida simples de tênis de mesa na tela com duas barrinhas brancas rebatendo um quadradinho pixelado.", false),
            new Alt("Era um jogo de realidade virtual em alta definição 8K com hologramas tridimensionais.", true)
        }));
        l10.Add(new Q("O Jogo Space Invaders (1978)", new Alt[] {
            new Alt("Foi um dos jogos de fliperama mais influentes de todos os tempos, onde o jogador controlava um canhão defendendo a Terra de alienígenas.", false),
            new Alt("As fileiras de monstros desciam pela tela ao som de uma batida musical acelerada que aumentava a tensão do jogador.", false),
            new Alt("Era um jogo de tabuleiro de madeira disputado rolando dados de argila na grama.", true)
        }));
        l10.Add(new Q("O Personagem Pac-Man (1980)", new Alt[] {
            new Alt("Criado no Japão por Toru Iwatani, o simpático círculo amarelo comendo pastilhas e fugindo de fantasmas em labirintos tornou-se um ícone pop.", false),
            new Alt("O criador revelou que o design visual característico do Pac-Man foi inspirado no formato de uma pizza com uma fatia retirada.", false),
            new Alt("Pac-Man era um monstro de gelo polar que atirava bolas de neve em ursos pardos.", true)
        }));
        l10.Add(new Q("O Console Atari 2600", new Alt[] {
            new Alt("Popularizou os videogames domésticos nas salas de estar nos anos 70 e 80 através de cartuchos plásticos intercambiáveis.", false),
            new Alt("Possuía um icônico acabamento frontal imitando madeira nobre e o famoso controle joystick com um botão vermelho.", false),
            new Alt("Era uma máquina de costura a pedal usada para remendar calças jeans de operários.", true)
        }));
        l10.Add(new Q("Super Mario Bros. (1985) e Shigeru Miyamoto", new Alt[] {
            new Alt("Genial clássico da Nintendo que redefiniu o gênero de plataformas, com o encanador Mario pulando sobre canos no Reino dos Cogumelos.", false),
            new Alt("Mario ganhou bigode e boné porque nos consoles de 8 bits antigos era muito difícil desenhar boca e cabelo com poucos pixels.", false),
            new Alt("Mario era um pirata francês que navegava em canoas pelo oceano Atlântico.", true)
        }));
        l10.Add(new Q("O Jogo Tetris (1984)", new Alt[] {
            new Alt("Criado pelo engenheiro russo Alexey Pajitnov, é um lendário jogo de quebra-cabeça onde peças geométricas caem e devem formar linhas completas.", false),
            new Alt("Tornou-se um fenômeno cultural global absoluto ao ser vendido junto com o primeiro videogame portátil Game Boy da Nintendo.", false),
            new Alt("Era uma competição de levantamento de pedras gigantescas ao ar livre na montanha.", true)
        }));
        l10.Add(new Q("O Console Portátil Game Boy (1989)", new Alt[] {
            new Alt("Revolucionou a história dos jogos eletrônicos permitindo jogar cartuchos em qualquer lugar com quatro pilhas pequenas duradouras.", false),
            new Alt("Sua tela monocromática esverdeada de cristal líquido e carcaça cinza ultrarresistente tornaram-no um dos maiores sucessos mundiais.", false),
            new Alt("Pesava duzentos quilos e precisava ser transportado dentro de um caminhão guincho.", true)
        }));
        l10.Add(new Q("Sonic the Hedgehog (1991)", new Alt[] {
            new Alt("O veloz ouriço azul criado pela Sega tornou-se o mascote rival da Nintendo nos anos dourados dos videogames de 16 bits.", false),
            new Alt("Ficou célebre por suas corridas vertiginosas em loopings espirais e por coletar anéis dourados protegendo os animais de Robotnik.", false),
            new Alt("Sonic era uma tartaruga marinha vagarosa que só andava nadando no fundo do oceano.", true)
        }));
        l10.Add(new Q("A Chegada dos Gráficos em 3D (PlayStation e Nintendo 64)", new Alt[] {
            new Alt("Em meados dos anos 1990, os videogames migraram dos sprites bidimensionais planos para mundos tridimensionais poligonais com câmeras livres.", false),
            new Alt("Jogos marcantes como Super Mario 64 revolucionaram o movimento analógico e a sensação de imersão espacial dos jogadores.", false),
            new Alt("Os jogos deixaram de ser digitais e passaram a ser encenados por fantoches de pano em teatros.", true)
        }));
        l10.Add(new Q("A Evolução das Mídias de Jogos (Do Cartucho ao Download)", new Alt[] {
            new Alt("Os videogames evoluíram de cartuchos com chips para CDs, DVDs, Blu-rays e modernas lojas de distribuição digital pela internet.", false),
            new Alt("Permitiu jogos gigantescos com trilhas sonoras orquestradas completas, dublagens em cinema e atualizações online constantes.", false),
            new Alt("Hoje em dia os videogames modernos só funcionam inserindo fitas de áudio cassete enroladas com lápis.", true)
        }));
        l10.Add(new Q("O Primeiro Telefone Celular Móvel (1973)", new Alt[] {
            new Alt("Martin Cooper, engenheiro da Motorola, fez a primeira chamada pública de um celular portátil na rua em Nova York usando o protótipo DynaTAC.", false),
            new Alt("O aparelho pesava mais de um quilo, demorava dez horas para carregar na tomada e a bateria durava cerca de trinta minutos de conversa.", false),
            new Alt("O primeiro celular era um chapéu de palha com dois alto-falantes de corneta em cima.", true)
        }));
        l10.Add(new Q("A Chegada do Smartphone Moderno (2007)", new Alt[] {
            new Alt("Com o lançamento pioneiro do iPhone pela Apple, os celulares integraram tela de toque multitouch, navegação web real e aplicativos múltiplos.", false),
            new Alt("Transformou o celular em um poderoso computador de bolso com câmera de fotos de alta resolução, mapas GPS e internet móvel.", false),
            new Alt("Os smartphones modernos só funcionam conectando um telefone de disco a manivela na parede.", true)
        }));
        l10.Add(new Q("O Sistema de GPS (Sistema de Posicionamento Global)", new Alt[] {
            new Alt("Constelação de mais de trinta satélites em órbita da Terra que enviam sinais de rádio permitindo a qualquer receptor calcular sua posição exata.", false),
            new Alt("É a tecnologia essencial por trás dos mapas de rotas em celulares, navegação aérea de aviões comerciais e resgates de navios no mar.", false),
            new Alt("Funciona com espelhos refletores apontados do topo de montanhas com fumaça colorida.", true)
        }));
        l10.Add(new Q("A Estação Espacial Internacional (ISS)", new Alt[] {
            new Alt("É o maior laboratório científico orbital já construído no espaço, com módulos montados em órbita por 15 países parceiros desde 1998.", false),
            new Alt("Viaja ao redor da Terra a quase vinte e oito mil quilômetros por hora, completando uma volta inteira no planeta a cada noventa minutos.", false),
            new Alt("Fica ancorada no topo do Monte Everest por uma corrente de aço de três quilômetros.", true)
        }));
        l10.Add(new Q("A Vida a Bordo da Estação Espacial Internacional", new Alt[] {
            new Alt("Os astronautas vivem em ambiente de microgravidade, flutuando pelos corredores e dormindo em sacos de dormir amarrados nas paredes.", false),
            new Alt("Precisam fazer exercícios físicos vigorosos em esteiras e bicicletas ergométricas todos os dias para não perder massa óssea e muscular.", false),
            new Alt("Os astronautas tomam banho de banheira com patinhos de borracha flutuando na água.", true)
        }));
        l10.Add(new Q("A Cúpula de Janelas da ISS (Cupola)", new Alt[] {
            new Alt("É um módulo com sete grandes janelas panorâmicas de vidro blindado que oferece uma visão deslumbrante de 360 graus da Terra lá embaixo.", false),
            new Alt("É o local favorito dos astronautas para observar auroras boreais, furacões e fotografar as belezas naturais do nosso planeta azul.", false),
            new Alt("É uma varanda aberta sem vidro onde os astronautas saem de bermuda para tomar sol.", true)
        }));
        l10.Add(new Q("O Primeiro Astronauta Brasileiro (Marcos Pontes - 2006)", new Alt[] {
            new Alt("O engenheiro da Força Aérea Marcos Pontes viajou ao espaço na Missão Centenário a bordo da nave russa Soyuz TMA-8 rumo à ISS.", false),
            new Alt("A missão homenageou os cem anos do voo pioneiro do 14-Bis de Santos Dumont, realizando experimentos científicos no espaço.", false),
            new Alt("Viajou para o espaço pilotando um planador feito de folhas de jornal coladas com goma.", true)
        }));
        l10.Add(new Q("A Missão Cassini-Huygens em Saturno", new Alt[] {
            new Alt("Explorou com riqueza espetacular o planeta dos anéis Saturno e suas luas misteriosas por mais de uma década em órbita.", false),
            new Alt("A sonda Huygens pousou na superfície alaranjada de Titã, revelando lagos e mares de metano líquido e dunas de hidrocarbonetos.", false),
            new Alt("Descobriu que os anéis de Saturno são feitos de rodelas de cebola empanada gigante.", true)
        }));
        l10.Add(new Q("A Lua Encélado de Saturno e seus Gêiseres", new Alt[] {
            new Alt("A sonda Cassini descobriu gêiseres de vapor d'água e gelo esguichando de fendas no polo sul da pequena lua gelada Encélado.", false),
            new Alt("Cientistas comprovaram que ela abriga um vasto oceano subterrâneo de água líquida salgada com fontes hidrotermais propícias à vida.", false),
            new Alt("É uma bola de sorvete de coco que derrete quando passa perto de uma lâmpada acesa.", true)
        }));
        l10.Add(new Q("A Sonda New Horizons e o Planeta Anão Plutão (2015)", new Alt[] {
            new Alt("Viajou em altíssima velocidade pelo Sistema Solar por quase dez anos até fazer a primeira passagem próxima da história por Plutão.", false),
            new Alt("Fotografou com nitidez impressionante montanhas de gelo de água de três mil metros e uma imensa planície em formato de coração (Tombaugh Regio).", false),
            new Alt("Descobriu que Plutão é uma lâmpada fluorescente ligada no céu noturno sem superfície.", true)
        }));
        l10.Add(new Q("O Rover Curiosity em Marte (2012)", new Alt[] {
            new Alt("É um laboratório robótico com rodas do tamanho de um carro utilitário que pousou na cratera Gale usando um inovador guindaste aéreo (sky crane).", false),
            new Alt("Descobriu evidências químicas irrefutáveis de que Marte possuía no passado antigo rios e lagos de água doce com condições para vida microbiana.", false),
            new Alt("Pousou em Marte descendo de paraquedas amarrado em quatro cachorrinhos adestrados.", true)
        }));
        l10.Add(new Q("O Rover Perseverance em Marte (2020)", new Alt[] {
            new Alt("Pousou na cratera Jezero em Marte com instrumentos científicos de última geração para buscar sinais de antiga vida microbiana fóssil.", false),
            new Alt("Perfura rochas marcianas guardando amostras em tubos de titânio selados para serem resgatadas por uma missão futura à Terra.", false),
            new Alt("É um robô com pernas de pau que joga vôlei de areia contra outros robôs na poeira marciana.", true)
        }));
        l10.Add(new Q("O Helicóptero Ingenuity em Marte", new Alt[] {
            new Alt("Foi o primeiro veículo aéreo a realizar um voo a motor controlado em outro planeta, voando na atmosfera cem vezes mais rarefeita de Marte.", false),
            new Alt("Com rotores duplos de fibra de carbono que giram a 2.400 rotações por minuto, realizou dezenas de voos espetaculares guiando o rover.", false),
            new Alt("Voava usando asas de penas de ganso que batiam ao vento gerado por um ventilador.", true)
        }));
        l10.Add(new Q("O Telescópio Espacial James Webb (2021)", new Alt[] {
            new Alt("É o maior, mais poderoso e mais complexo telescópio de astronomia infravermelha já construído e lançado pela humanidade.", false),
            new Alt("Possui um monumental espelho dourado segmentado de 6,5 metros e um escudo solar do tamanho de uma quadra de tênis.", false),
            new Alt("Fica instalado no quintal de uma casa no litoral de Santos apontado para o céu.", true)
        }));
        l10.Add(new Q("A Posição do James Webb (Ponto Lagrange L2)", new Alt[] {
            new Alt("Opera em órbita ao redor do Ponto de Lagrange L2, a cerca de 1,5 milhão de quilômetros de distância além da órbita da Lua.", false),
            new Alt("Nessa posição estável e congelante, o escudo térmico bloqueia permanentemente a luz e o calor da Terra, do Sol e da Lua juntos.", false),
            new Alt("Fica colado no teto do quarto de um cientista preso com fita dupla-face.", true)
        }));
        l10.Add(new Q("As Descobertas do Telescópio James Webb", new Alt[] {
            new Alt("Enxergou as mais antigas galáxias formadas logo após o Big Bang e detectou vapor d'água e moléculas na atmosfera de exoplanetas.", false),
            new Alt("Suas imagens espetaculares de nebulosas e berçários de estrelas revelam detalhes nunca antes vistos no universo profundo.", false),
            new Alt("Provou que todas as estrelas do céu são lâmpadas de led piscando em uma árvore gigante.", true)
        }));
        l10.Add(new Q("Os Foguetes Reutilizáveis da SpaceX (Falcon 9)", new Alt[] {
            new Alt("Revolucionaram a astronáutica moderna conseguindo pousar o primeiro estágio do foguete de pé sobre balsas oceânicas ou em terra.", false),
            new Alt("Permitem reutilizar o mesmo motor e estrutura metálica dezenas de vezes, barateando radicalmente o custo de enviar cargas ao espaço.", false),
            new Alt("Pousam em piscinas de bolinhas plásticas de restaurantes infantis na Flórida.", true)
        }));
        l10.Add(new Q("A Nave Starship", new Alt[] {
            new Alt("É o maior e mais potente veículo de lançamento e espaçonave totalmente reutilizável em desenvolvimento para levar cargas e pessoas à Lua e Marte.", false),
            new Alt("Feita com revestimento de aço inoxidável brilhante e decolando com mais de trinta motores Raptor a metano e oxigênio líquido.", false),
            new Alt("É uma canoa de madeira de balsa que navega flutuando sobre as ondas de rios rasos.", true)
        }));
        l10.Add(new Q("O Programa Artemis da NASA", new Alt[] {
            new Alt("É a missão internacional liderada pela NASA para levar a próxima geração de astronautas de volta à superfície da Lua.", false),
            new Alt("Planeja pousar astronautas no Polo Sul lunar, onde crateras em sombra permanente abrigam valiosos depósitos de gelo de água.", false),
            new Alt("Tem como objetivo construir um parque de diversões inflável na superfície do Sol.", true)
        }));
        l10.Add(new Q("A Estação Lunar Gateway", new Alt[] {
            new Alt("Será uma futura pequena estação espacial construída em órbita ao redor da Lua em parceria com agências internacionais.", false),
            new Alt("Servirá de ponto de apoio intermediário para descidas de astronautas à superfície lunar e para futuras missões a Marte.", false),
            new Alt("É um shopping center com praça de alimentação construído flutuando no mar de Santos.", true)
        }));
        l10.Add(new Q("O Desvio de Asteroide com a Missão DART (2022)", new Alt[] {
            new Alt("Foi o primeiro teste bem-sucedido de defesa planetária, colidindo intencionalmente uma espaçonave contra o asteroide Dimorphos.", false),
            new Alt("A força do impacto cinético alterou com sucesso a órbita do asteroide, provando que podemos proteger a Terra de futuras colisões cósmicas.", false),
            new Alt("A nave desceu com astronautas segurando cordas que puxaram o asteroide com as mãos.", true)
        }));
        l10.Add(new Q("A Exploração dos Exoplanetas", new Alt[] {
            new Alt("Telescópios espaciais como Kepler e TESS descobriram mais de cinco mil planetas orbitando outras estrelas na nossa galáxia.", false),
            new Alt("Muitos ficam na chamada 'zona habitável', onde a distância da estrela permite temperaturas para água líquida na superfície.", false),
            new Alt("Todos os planetas fora do Sistema Solar são feitos de queijo derretido com calda de morango.", true)
        }));
        l10.Add(new Q("O Telescópio Espacial Roman (Nancy Grace Roman)", new Alt[] {
            new Alt("Futuro telescópio da NASA projetado para estudar energia escura, matéria escura e fotografar exoplanetas com visão cem vezes mais ampla que o Hubble.", false),
            new Alt("Homenageia a astrônoma Nancy Grace Roman, conhecida como a 'mãe do telescópio espacial Hubble'.", false),
            new Alt("Será um submarino militar colocado no fundo da Baía de Guanabara para caçar peixes.", true)
        }));
        l10.Add(new Q("A Inteligência Artificial Moderna (IA)", new Alt[] {
            new Alt("Sistemas computacionais avançados de aprendizado de máquina capazes de reconhecer imagens, processar línguas naturais e analisar dados complexos.", false),
            new Alt("São ferramentas revolucionárias que auxiliam cientistas na descoberta de novos remédios, previsão do tempo e tradução automática.", false),
            new Alt("São pequenos duendes de histórias infantis que vivem dentro dos monitores de computador.", true)
        }));
        l10.Add(new Q("A Computação Quântica", new Alt[] {
            new Alt("Utiliza princípios da mecânica quântica com qubits para processar cálculos hipercomplexos que levariam milhares de anos em computadores comuns.", false),
            new Alt("Pode revolucionar a química quântica, a criptografia, a criação de baterias eficientes e o design de novos materiais tecnológicos.", false),
            new Alt("É um tipo de máquina de lavar roupas inteligente com centrifugação a laser.", true)
        }));
        l10.Add(new Q("Os Drones e Carros Autônomos", new Alt[] {
            new Alt("Utilizam câmeras, sensores de radar e inteligência artificial para navegar e desviar de obstáculos com precisão sem piloto humano a bordo.", false),
            new Alt("São amplamente empregados no mapeamento topográfico, entregas médicas de emergência e na agricultura de precisão.", false),
            new Alt("Funcionam sendo puxados por fios invisíveis amarrados na cauda de aviões de carreira.", true)
        }));
        l10.Add(new Q("A Energia Solar Fotovoltaica e Eólica", new Alt[] {
            new Alt("Fontes limpas e renováveis que transformam a luz do Sol em células de silício e o sopro dos ventos em pás de turbinas em eletricidade verde.", false),
            new Alt("Crescem aceleradamente em todo o planeta para combater as mudanças climáticas e substituir combustíveis fósseis poluentes.", false),
            new Alt("Funcionam queimando pneus velhos de caminhão dentro de grandes fornalhas a carvão.", true)
        }));
        l10.Add(new Q("A Impressão 3D e a Manufatura Aditiva", new Alt[] {
            new Alt("Cria objetos tridimensionais camada por camada a partir de modelos digitais de computador usando plásticos, resinas ou metais.", false),
            new Alt("É utilizada na medicina para próteses anatômicas personalizadas e já é testada na ISS para fabricar ferramentas no espaço.", false),
            new Alt("É uma caneta esferográfica comum que escreve em cadernos de caligrafia escolar.", true)
        }));
        l10.Add(new Q("A Realidade Virtual e Realidade Aumentada", new Alt[] {
            new Alt("A realidade virtual imerge o usuário em ambientes 3D simulados por computador através de óculos especiais com sensores de movimento.", false),
            new Alt("A realidade aumentada sobrepõe elementos digitais interativos sobre a visão do mundo real, como em jogos e cirurgias guiadas.", false),
            new Alt("São quadros de parede estáticos pintados a óleo que nunca mudam de posição.", true)
        }));
        l10.Add(new Q("A Internet por Satélites em Órbita Baixa (Constelações LEO)", new Alt[] {
            new Alt("Milhares de pequenos satélites orbitando a algumas centenas de quilômetros da Terra levam internet de alta velocidade a áreas remotas.", false),
            new Alt("Permitem que escolas isoladas em florestas, barcos em alto-mar e comunidades rurais conectem-se à rede mundial de computadores.", false),
            new Alt("Funcionam ligando fios telefônicos de cobre esticados do chão até a Lua.", true)
        }));
        l10.Add(new Q("O Futuro dos Voos Tripulados a Marte", new Alt[] {
            new Alt("É uma das maiores ambições da ciência espacial contemporânea: enviar expedições de astronautas humanos para explorar o Planeta Vermelho.", false),
            new Alt("Envolve desafios monumentais de blindagem contra radiação cósmica, viagens de meses e cultivo de alimentos em habitats fechados.", false),
            new Alt("Será uma viagem rápida de cinco minutos pegando o metrô subterrâneo da cidade de São Paulo.", true)
        }));
        l10.Add(new Q("A Busca por Vida Fora da Terra (Astrobiologia)", new Alt[] {
            new Alt("Campo científico interdisciplinar que estuda a origem, evolução e distribuição de vida potencial no cosmos.", false),
            new Alt("Foca na busca de bioassinaturas químicas nas luas oceânicas de Júpiter e Saturno e em atmosferas de planetas distantes.", false),
            new Alt("Afirma com certeza científica que alienígenas moram disfarçados dentro de fornos de micro-ondas.", true)
        }));
        l10.Add(new Q("O Telescópio Espacial Nancy Grace Roman", new Alt[] {
            new Alt("Terá um campo de visão cem vezes maior que o do telescópio Hubble, mapeando bilhões de galáxias com rapidez inédita.", false),
            new Alt("Carregará um instrumento coronógrafo pioneiro para bloquear a luz ofuscante de estrelas e fotografar planetas vizinhos.", false),
            new Alt("Será montado no capô de um táxi comum em Nova York para fotografar o trânsito.", true)
        }));
        l10.Add(new Q("A Viagem da Humanidade pelo Conhecimento", new Alt[] {
            new Alt("Desde as primeiras ferramentas de pedra na Pré-História até as sondas nos confins do universo, a curiosidade move a evolução humana.", false),
            new Alt("A ciência, a educação, a cooperação pacífica e a preservação do nosso planeta são os maiores tesouros para as futuras gerações.", false),
            new Alt("A história da humanidade acabou completamente no ano passado e ninguém mais inventará nada novo.", true)
        }));

        // Write to temp_his_levels_7_10.lua
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

        File.WriteAllText("temp_his_levels_7_10.lua", sb.ToString(), Encoding.UTF8);
        Console.WriteLine("Wrote temp_his_levels_7_10.lua with 4 levels (200 questions)");
    }

    static string Escape(string s) {
        return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
    }
}
