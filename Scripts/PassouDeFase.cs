using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script responsável por gerenciar a transição vitoriosa entre níveis.
// Ele permite que o jogador avance no jogo após completar os objetivos da fase atual.
public class PassouDeFase : MonoBehaviour
{
    // Método público que recebe o nome da próxima cena como texto (string).
    // Dica de Dev: Usar o nome da cena permite que este mesmo script funcione
    // para passar da Fase 1 para a 2, da 2 para a 3, e assim por diante.
    public void LoadScenes(string cena)
    {
        // Registro no console para facilitar o Debug durante os testes no Unity Editor.
        Debug.Log("Sucesso! Carregando a próxima etapa: " + cena);
        
        // Chama o motor de cenas do Unity para descarregar a fase atual e carregar a nova.
        SceneManager.LoadScene(cena);
    }
}
