using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script responsável por controlar as ações dos botões do Menu Principal.
// Ele serve como uma ponte entre a Interface (UI) e o motor de cenas do Unity.
public class Menu : MonoBehaviour
{
    // Método público para carregar qualquer cena pelo nome.
    // Usar um parâmetro 'string' permite que esse mesmo método seja usado por vários botões,
    // bastando digitar o nome da fase no Inspector do botão (On Click).
    public void LoadScenes(string cena)
    {
        Debug.Log("Carregando cena: " + cena);
        SceneManager.LoadScene(cena);
    }

    // Método para fechar o jogo.
    public void Quit()
    {
        Debug.Log("O jogador saiu do jogo.");
        
        // No Editor da Unity o Quit() não fecha a janela, por isso o Debug acima é importante.
        // Em um build real (.exe ou .apk), ele encerra o processo completamente.
        Application.Quit(); 
    }
}
