# 🌍 Jogo: Salvando o Mundo - Reciclagem Educativa

Este é um projeto desenvolvido em **Unity** com a linguagem **C#**, focado em educação ambiental. O objetivo do jogo é ensinar jogadores sobre a coleta seletiva de forma lúdica, utilizando mecânicas de *Drag and Drop* (arrastar e soltar) e exploração de cenário.

## 🚀 Tecnologias Utilizadas
* **Engine:** Unity 2021.x (ou a versão que você usou)
* **Linguagem:** C# (C-Sharp)
* **Sistema de UI:** Unity EventSystems
* **Física:** Rigidbody2D e BoxCollider2D

## 🎮 Mecânicas do Jogo
* **Movimentação Top-Down:** O jogador explora o cenário para coletar resíduos espalhados.
* **Sistema de Reciclagem:** Interface interativa onde o jogador deve identificar o tipo de lixo (Papel, Plástico, Metal, Vidro, Orgânico) e arrastá-lo para a lixeira correspondente.
* **Validação de Estados:** O jogo utiliza variáveis estáticas para monitorar o progresso global e garantir que todas as metas de coleta sejam batidas antes de avançar de fase.

## 🛠️ Desafios Técnicos Superados
Durante o desenvolvimento, foquei em boas práticas de programação, como:
1.  **Uso de Enums:** Para garantir que a comparação entre tipos de lixo e lixeiras fosse segura e livre de erros de digitação.
2.  **Gerenciamento de Cenas:** Implementação de um fluxo lógico entre Menu, Fases, Telas de Vitória e Game Over.
3.  **Singleton/Static Pattern:** Utilização de variáveis estáticas para contagem de pontuação entre múltiplos objetos de UI.
4.  **Reset de Estado:** Criação de scripts específicos para limpar dados da memória ao reiniciar o jogo, evitando bugs de persistência.

## 📁 Estrutura de Scripts
* `DragDrop.cs`: Gerencia a física da UI e o arraste dos itens.
* `SlotItenDrop.cs`: Valida se o item solto corresponde ao tipo da lixeira.
* `PlayerController.cs`: Controla a movimentação e as animações do personagem.
*
