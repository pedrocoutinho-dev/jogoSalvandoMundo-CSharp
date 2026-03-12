using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

// Classe simples para identificar o objeto. 
// O 'id' vai servir como uma "chave" para saber qual lixo é qual.
public class Item : MonoBehaviour
{
    public int id; 
}

// Classe que gerencia a lógica de "Drop" (soltar) e progresso da fase.
public class DropFase : MonoBehaviour
{
    [Header("Configurações dos Itens")]
    public GameObject[] itens; // Lista de objetos que podem ser arrastados
    public Transform[] locaisCorretos; // Os pontos de destino (ex: as lixeiras)
    
    [Header("Interface e Progresso")]
    public GameObject avisoErro; // Painel ou texto que aparece quando erra o local
    public int itensColocados = 0; // Contador para saber quantos acertos o jogador já fez
    public int totalItens = 3; // Meta de acertos para vencer a fase

    void Start()
    {
        // No início, garantimos que o aviso de erro esteja escondido
        if(avisoErro != null) avisoErro.SetActive(false);
    }

    void Update()
    {
        // Verificação constante: se o contador atingiu o total, o jogador venceu
        if (itensColocados == totalItens)
        {
            Debug.Log("Fase Concluída!");
            // Aqui podemos chamar SceneManager.LoadScene para ir para o próximo nível
        }
    }

    // Método principal que será chamado quando o item for solto em uma área de drop
    public void VerificarItem(GameObject item)
    {
        // Percorremos o array de locais corretos para validar a jogada
        for (int i = 0; i < locaisCorretos.Length; i++)
        {
            // Verificamos se o local está vazio (childCount == 0) 
            // e se o ID do item bate com o índice do local correto
            if (locaisCorretos[i].childCount == 0 && item.GetComponent<Item>().id == i)
            {
                // Sucesso: O item vira "filho" do local correto para ficar encaixado
                item.transform.SetParent(locaisCorretos[i]);
                item.transform.localPosition = Vector3.zero; // Centraliza o item no local
                
                itensColocados++;
                avisoErro.SetActive(false); // Garante que o erro suma se ele acertar agora
                return; // Sai do método pois já achou o lugar certo
            }
        }

        // Se o loop terminar e não entrar no 'if' acima, significa que o local é errado
        avisoErro.SetActive(true); 
    }
}
