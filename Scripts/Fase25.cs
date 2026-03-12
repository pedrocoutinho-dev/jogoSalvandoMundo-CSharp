using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Usei Enums para facilitar a leitura. Em vez de números (0, 1, 2), 
// usamos nomes reais, o que evita muitos erros de lógica no Inspector.
public enum LixeiraType
{
    Papel,
    Plastico,
    Metal,
    Organico,
    Vidro
}

public enum LixoType
{
    Papel,
    Plastico,
    Metal,
    Organico,
    Vidro
}

// Script que controla a colisão e o depósito do lixo na fase 2.
// Implementamos IDropHandler para detectar quando algo é "soltado" em cima deste objeto.
public class Fase25 : MonoBehaviour, IDropHandler
{
    // Define qual o tipo desta lixeira específica (configurado no Unity Editor)
    public LixoType lixeiraType;

    // Flag para controle interno da lixeira
    public bool lixoCorreto = false;

    // Variáveis Estáticas: Elas pertencem à classe, não ao objeto. 
    // Isso permite que todas as lixeiras compartilhem o mesmo contador de itens.
    public static int itensColocados = 0; 
    public static int totalItens = 5; 

    // Este método é chamado automaticamente pela Unity quando soltamos o mouse/dedo
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null)
        {
            // Pegamos o objeto que estava sendo arrastado (o lixo)
            GameObject lixo = eventData.pointerDrag.gameObject;
            
            // Acessamos o script DragDrop que está no lixo para ler o tipo dele
            DragDrop dragDrop = lixo.GetComponent<DragDrop>();

            // LÓGICA DE VALIDAÇÃO: Comparando o tipo do lixo com o tipo da lixeira
            if (dragDrop.lixoType == lixeiraType)
            {
                // Se acertou:
                lixoCorreto = true;
                itensColocados++; // Incrementa o contador global de acertos
                Debug.Log("Lixo correto! Total de acertos: " + itensColocados);

                // Checa se atingiu a meta de vitória da fase
                if (itensColocados == totalItens)
                {
                    Debug.Log("Vitória! Carregando próxima fase...");
                    SceneManager.LoadScene("PassouFase2");
                    
                    // Dica: Seria bom resetar o 'itensColocados' aqui para a próxima fase não começar somada!
                }
            }
            else
            {
                // Se errou:
                Debug.Log("Lixo errado! O jogador perdeu.");
                lixoCorreto = false;
                
                // Reinicia ou manda para a tela de Game Over imediatamente
                SceneManager.LoadScene("CenaPerdeu 1");
            }

            // Garante que o objeto de lixo "encaixe" visualmente na lixeira ao ser solto
            lixo.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
