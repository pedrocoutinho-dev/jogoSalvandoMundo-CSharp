using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Este script é um utilitário de sistema para garantir a integridade dos dados.
// Ele limpa todos os contadores globais (static) toda vez que o jogo ou a fase reinicia.
public class ResetGame : MonoBehaviour
{
    // O Start roda uma única vez quando o objeto entra na cena.
    void Start()
    {
        // RESET TOTAL: Como as variáveis são estáticas, elas sobrevivem à troca de cenas.
        // Aqui garantimos que todos os contadores de todas as fases voltem a zero.
        SlotItenDrop.itensColocados = 0;
        Fase25.itensColocados = 0;
        Fase35.itensColocados = 0;
        
        Debug.Log("Sistema: Todos os contadores globais foram zerados no Start.");
    }

    // O Update está vazio para não gastar processamento desnecessário.
    void Update()
    {
        
    }

    // O OnEnable roda toda vez que o objeto é ativado (útil se você desativar/ativar o GameHandler).
    void OnEnable()
    {
        // Reforço do reset para garantir que, se o objeto for reativado, os dados estejam limpos.
        SlotItenDrop.itensColocados = 0;
        Debug.Log("Sistema: Contador de itens resetado via OnEnable.");
    }
}
