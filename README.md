# Corredor da Mentira

Projeto Roblox preservado como place do Studio e organizado em fontes Luau para revisão e sincronização com Rojo. O nome vem do pacote de entrega existente e dos arquivos de place do projeto. O mapa v4 foi copiado para `place/`; os arquivos originais em `outputs/` e `work/` foram mantidos no local.

## Estrutura

```text
Corredor da Mentira/
├── default.project.json
├── place/
│   └── Corredor_da_Mentira_tentativas_atualizado_v4.rbxl
├── src/
│   ├── MapScripts/
│   │   └── GoServerScript.lua
│   ├── ReplicatedStorage/
│   │   └── QuizConfig.lua
│   ├── ServerScriptService/
│   │   ├── LeaderboardService.server.lua
│   │   └── QuizServerService.server.lua
│   ├── ServerStorage/
│   │   └── QuizBancoQuestoes.lua
│   └── StarterPlayerScripts/
│       ├── LeaderboardVisibilityController.client.lua
│       └── QuizClientController.client.lua
├── .gitignore
├── LICENSE
└── README.md
```

`Workspace` e `StarterGui` não são reconstruídos pelo Rojo: eles vêm do place binário. Isso preserva o mapa e suas interfaces. O projeto Rojo mapeia apenas as quatro áreas de código indicadas em `default.project.json`, e cada serviço usa `$ignoreUnknownInstances: false` para manter objetos existentes que não estão representados nos arquivos. `GoServerScript.lua` é vinculado a uma peça/modelo do veículo no mapa; por isso fica versionado em `src/MapScripts`, mas fora do mapeamento automático.

## Abrir e sincronizar no Roblox Studio

1. Abra `place/Corredor_da_Mentira_tentativas_atualizado_v4.rbxl` no Studio. Se for editar a geometria, use **Save As** para criar uma cópia de trabalho e só substitua o arquivo versionado depois de revisar a mudança.
2. Instale a CLI e o plugin do Rojo seguindo o [guia oficial de instalação](https://rojo.space/docs/v7/getting-started/installation/).
3. No terminal, dentro desta pasta do projeto, execute `rojo serve default.project.json`.
4. No Studio, conecte o plugin Rojo ao servidor local. As fontes de `ReplicatedStorage`, `ServerScriptService`, `ServerStorage` e `StarterPlayerScripts` serão sincronizadas; `Workspace`, o mapa e as GUIs não serão substituídos pela configuração.

O CLI Rojo não estava instalado neste ambiente, então o arquivo de projeto foi preparado e validado como JSON, mas a conexão ao plugin não foi executada. A sincronização deve ser feita primeiro em uma cópia do place para conferir a árvore resultante no Explorer.

## Objetos necessários no Explorer

| Caminho | Classe/configuração | Observação |
|---|---|---|
| `ReplicatedStorage.QuizConfig` | `ModuleScript` | Código gerenciado pelo Rojo. |
| `ReplicatedStorage.QuizRemotes` | `Folder` | `QuizServerService` cria os `RemoteEvent` e `RemoteFunction` necessários. |
| `ServerScriptService.QuizServerService` | `Script` | Valida questões, progresso, pontos, tentativas, reset e acesso às recompensas. |
| `ServerScriptService.LeaderboardService` | `Script` | Cria o painel físico e ordena o placar do servidor atual. |
| `ServerStorage.QuizBancoQuestoes` | `ModuleScript` | Mantém perguntas e gabarito fora da replicação para clientes. |
| `StarterPlayer.StarterPlayerScripts.QuizClientController` | `LocalScript` | HUD, cronômetros, respostas e botão de reset personalizado. |
| `StarterPlayer.StarterPlayerScripts.LeaderboardVisibilityController` | `LocalScript` | Oculta o painel localmente quando uma parede bloqueia a linha de visão. |
| `StarterGui.ScreenGui` | `ScreenGui`, `ResetOnSpawn = false` | Contém `Frame das perguntas`, `Pergunta`, `Fechar`, `Resposta 1`, `Resposta 2` e `Resposta 3`. |
| `Workspace` botões de questão | `BasePart` + `ProximityPrompt` | Nomes exatos: `Botão de Interação das Perguntas de Geografia nivel 0` a `10` e `Botão de Interação das Perguntas de História nivel 1` a `10`. |
| `Workspace.Teleport Portals` | Modelos `PortalBlue` e `PortalRed` | Precisam conter `BlueTeleport`, `RedTeleport`, `RedArrive` e `BlueArrive`. Defina `IsRewardGate = true` no `PortalBlue.BlueTeleport`. |
| `Workspace` botão de reset físico | `BasePart` chamado `Botão de resetar pontos` | Opcional para o reset de tela; quando presente, o servidor configura prompt e clique. |
| Veículo preservado no mapa | Script `GoServerScript` junto ao controle atual | O pai do script é a peça com o `ClickDetector` `CD`; mantenha o template `GoPlayer` associado. Para atualizar, copie `src/MapScripts/GoServerScript.lua` para o Script existente, sem movê-lo. |

`LeaderboardParede`, `LeaderboardPhysicalFrame` e a interface de superfície são criados/configurados por `LeaderboardService` durante a execução; não crie outra cópia manual. O painel usa a posição registrada no script e é visível através de linha de visão a qualquer distância. A leaderboard classifica o servidor atual por acertos e, em empate, pelo menor tempo de conclusão; não persiste entre servidores.

## Regras mantidas

- O servidor embaralha questões e alternativas sem separar a alternativa falsa do gabarito, valida cada resposta e sempre avança após uma resposta válida, certa ou errada.
- Depois do último caderno de Geografia, o jogador segue para História; ao concluir História, volta ao primeiro caderno de Geografia.
- Todos os jogadores conectados que ainda estão no tutorial precisam concluí-lo antes do início comum da rodada; há uma preparação de 2 segundos. O servidor sincroniza os horários. A cada reset manual ou reinício automático abaixo de 15/20, a tentativa/rodada individual, os acertos e os dois relógios desse jogador reiniciam; o prazo dos demais não muda.
- O cronômetro grande mede o tempo decorrido da tentativa em `mm:ss.mmm`; a linha menor mostra a rodada individual e o tempo restante no mesmo formato. Ao chegar a 15 acertos, o servidor congela os dois valores e mantém o resultado até um reset manual. O jogador ainda pode responder às questões restantes e aumentar os acertos, mas o tempo da leaderboard continua sendo o tempo em que atingiu 15. A coluna `Acertos` em `leaderstats` mostra `X/20` ao abrir a lista com Tab.
- A entrada no lado das recompensas exige 15 ou mais acertos na tentativa atual; a saída é livre. Mesmo quando o prazo da rodada termina, acertos e tempo congelados permanecem até o jogador resetar. Pontos e acesso não são aceitos do cliente como autoridade.
- O cliente usa `GuiButton.Activated` para respostas e reset, com feedback visual de toque. O botão de reset personalizado substitui o controle padrão de reset do Roblox, que não oferece a mesma personalização de uma interface comum.

## Revisão e validação

- O place v4 foi copiado sem alterar o original; o hash SHA-256 da cópia foi comparado ao arquivo fonte.
- Os seis scripts ativos foram copiados de `work`; normalizei somente a linha em branco extra no fim dos arquivos. O banco de questões veio do pacote de entrega.
- O arquivo JSON do Rojo e a presença dos caminhos configurados foram validados localmente. O CLI do Rojo não está instalado, então não foi possível verificar a conexão de sincronização.
- O Roblox Studio já estava com o place v4 em uma sessão Play. Confirmei visualmente o HUD, o painel e os dois cronômetros na sessão existente; não interrompi nem alterei essa sessão para repetir os fluxos de tutorial, reset e portão.
- Não executei uma nova sessão multiplayer nem o emulador móvel durante esta preparação. O README do pacote anterior registra testes anteriores de controles touch, portão e layout; esses testes não foram repetidos nesta revisão.

## Referências

- [Roblox: locais e tipos de Scripts](https://create.roblox.com/docs/scripting/locations)
- [Roblox: modelo de dados](https://create.roblox.com/docs/projects/data-model)
- [Rojo v7: formato de projeto](https://rojo.space/docs/v7/project-format/)
- [Rojo v7: sincronização](https://rojo.space/docs/v7/sync-details/)
