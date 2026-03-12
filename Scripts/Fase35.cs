using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Enums para categorizar os tipos de lixo e lixeiras. 
// Isso evita o uso de "Magic Strings" (comparar textos manualmente), o que reduz erros de digitação.
public enum TypeLixeira
{
    Papel,
    Plastico,
    Metal,
    Organico,
    Vidro
}

public enum TypeLixo
{
    Papel,
    Plastico,
    Metal,
    Organico,
    Vidro
}

// Script responsável pela lógica de depósito na fase 3.5.
public class Fase35 : MonoBehaviour, IDropHandler
{
    // Define qual o tipo de lixo que esta lixeira específica aceita.
    public TypeLixo typeLixeira;

    // Flag para controle de validação do último item solto.
    public bool lixoCorreto = false;

    // Variáveis Estáticas para controle global da fase.
    // Como são estáticas, todas as instâncias das lixeiras olham para o mesmo contador.
    public static int itensColocados = 0; 
    public static int totalItens = 10; // Meta maior para a fase final.

    // Método disparado pela Unity ao soltar um objeto de UI sobre esta lixeira.
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null)
        {
            // Recupera o objeto que foi arrastado.
            GameObject lixo = eventData.pointerDrag.gameObject;
            
            // Acessa o script de controle de arraste do objeto para checar o seu tipo.
            DragDrop dragDrop = lixo.GetComponent<DragDrop>();

            // COMPARAÇÃO DE TIPOS: Verificamos se o item solto é do mesmo tipo da lixeira.
            if (dragDrop.typeLixo == typeLixeira)
            {
                // Sucesso: Incrementa o contador de progresso.
                lixoCorreto = true;
                itensColocados++;
                Debug.Log("Lixo correto! Itens colocados: " + itensColocados);

                // Verificação de Vitória: Checa se o jogador atingiu a meta da fase.
                if (itensColocados == totalItens)
                {
                    Debug.Log("Parabéns! Você venceu a Fase Final!");
                    // Reseta o contador estático para não bugar ao reiniciar o jogo ou voltar o menu.
                    itensColocados = 0; 
                    SceneManager.LoadScene("Fim");
                }
            }
            else
            {
                // Erro: O jogador falhou na separação.
                Debug.Log("Lixo errado!");
                lixoCorreto = false;
                
                // Reseta o contador para a próxima tentativa do jogador.
                itensColocados = 0; 
                SceneManager.LoadScene("CenaPerdeu 2");
            }

            // SNAP LOGIC: "Encaixa" visualmente o lixo na posição exata da lixeira após o drop.
            lixo.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
