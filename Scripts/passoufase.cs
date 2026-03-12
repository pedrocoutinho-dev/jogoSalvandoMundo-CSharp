using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script utilitário para gerenciar a transição de cenas após o sucesso em uma fase.
// Ele é ideal para ser anexado a botões de "Próxima Fase" ou "Continuar".
public class passoufase : MonoBehaviour
{
    // Método público que permite carregar qualquer cena passando o nome como parâmetro.
    // Dica de Dev: No Unity Editor, você pode configurar o botão 'On Click' e 
    // digitar o nome da cena destino diretamente no campo de texto.
    public void LoadScenes(string cena)
    {
        // Log para confirmar no console qual cena o sistema está tentando carregar.
        // Útil para identificar erros de digitação nos nomes das cenas.
        Debug.Log("Sucesso detectado! Transicionando para a cena: " + cena);

        // O SceneManager descarrega a fase atual e carrega a nova, liberando memória.
        SceneManager.LoadScene(cena);
    }
}
