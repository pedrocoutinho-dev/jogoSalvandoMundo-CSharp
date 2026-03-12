using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

// Este script é anexado individualmente a cada objeto de lixo (Item).
// Ele serve para identificar o objeto e disparar a lógica de verificação.
public class item : MonoBehaviour
{
    // O 'id' é a identidade do item. 
    // Exemplo: id 0 pode ser Papel, id 1 pode ser Plástico. 
    // Esse número deve bater com o índice do local correto no DropFase.
    public int id; 

    // O método OnMouseDown é chamado automaticamente pela Unity quando o jogador
    // clica com o mouse (ou toca na tela) sobre o colisor (Collider) deste objeto.
    void OnMouseDown()
    {
        // COMUNICAÇÃO ENTRE SCRIPTS:
        // Aqui, o próprio item "pede" para o componente DropFase verificar se ele está no lugar certo.
        // O 'gameObject' passa a referência de si mesmo para que o gerente saiba quem foi clicado.
        GetComponent<DropFase>().VerificarItem(gameObject);
        
        Debug.Log("Item clicado! ID: " + id + ". Enviando para verificação...");
    }
}
