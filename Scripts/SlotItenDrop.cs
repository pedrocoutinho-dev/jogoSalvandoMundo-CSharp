using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Enumerações para categorizar os tipos de lixo e lixeiras de forma organizada.
public enum TipoLixeira
{
    Papel, Plastico, Metal, Organico, Vidro
}

public enum TipoLixo
{
    Papel, Plastico, Metal, Organico, Vidro
}

// Este script é o responsável por gerenciar o "depósito" do item na lixeira (Slot).
// Ele implementa IDropHandler para reagir quando um objeto é solto sobre ele.
public class SlotItenDrop : MonoBehaviour, IDropHandler
{
    // Define qual tipo de lixo este slot específico aceita (configurável via Unity Editor).
    public TipoLixo tipoLixeira;

    // Estado para saber se o último item depositado foi o correto.
    public bool lixoCorreto = false;

    // Variáveis Estáticas: O contador é compartilhado entre todos os slots da cena.
    public static int itensColocados = 0; 
    public static int totalItens = 5; // Meta de itens para completar a fase.

    // Método principal chamado pela Unity quando o jogador solta um objeto de UI aqui.
    public void OnDrop(PointerEventData eventData)
    {
        // Verifica se realmente há um objeto sendo arrastado.
        if (eventData != null)
        {
            // Obtém a referência do objeto que foi solto (o lixo).
            GameObject lixo = eventData.pointerDrag.gameObject;
            
            // Acessa o script DragDrop do lixo para identificar o seu tipo.
            DragDrop dragDrop = lixo.GetComponent<DragDrop>();

            // LÓGICA DE VALIDAÇÃO: O tipo do lixo arrastado é igual ao aceito por esta lixeira?
            if (dragDrop.tipoLixo == tipoLixeira)
            {
                // ACERTO:
                lixoCorreto = true;
                itensColocados++; // Incrementa o progresso global da fase.
                Debug.Log("Lixo correto! Progresso: " + itensColocados + "/" + totalItens);

                // Verificação de Vitória: Se atingiu o total, avança de fase.
                if (itensColocados == totalItens)
                {
                    Debug.Log("Parabéns! Fase concluída.");
                    SceneManager.LoadScene("PassouFase");
                }
            }
            else
            {
                // ERRO: O jogador tentou reciclar no local errado.
                Debug.Log("Lixo errado! Redirecionando para tela de derrota.");
                lixoCorreto = false;
                SceneManager.LoadScene("CenaPerdeu");
            }

            // SNAP EFFECT: Faz o lixo "grudar" exatamente no centro da lixeira ao ser solto.
            // Isso dá um polimento visual profissional para a interface.
            lixo.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
