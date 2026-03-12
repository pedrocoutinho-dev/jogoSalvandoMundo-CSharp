using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script principal do Personagem: Controla movimento, animações e coleta de lixo.
public class NewBehaviourScript : MonoBehaviour
{
    private Animator playerAnim;   // Referência para controlar as trocas de animação (Idle, Walk)
    private Rigidbody2D rbPlayer; // Referência para a física do Unity (movimentação por velocidade)
    
    public float speed; // Velocidade de movimento configurável no Inspector
    
    // Contadores de lixo para cada tipo de fase/objetivo
    public int lixo = 5;
    public int lixo2 = 5;
    public int lixo3 = 10;

    void Start()
    {
        // Inicializa os componentes buscando-os no próprio objeto do Player
        playerAnim = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Chamamos a movimentação no Update para garantir uma resposta rápida aos comandos do teclado
        MovePlayer();
    }

    void MovePlayer()
    {
        // Captura as teclas direcionais (Setas ou WASD)
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        float verticalMoviment = Input.GetAxisRaw("Vertical");

        // Aplica velocidade ao Rigidbody2D. 
        // Usar a velocidade do Rigidbody é melhor para evitar que o player atravesse paredes.
        rbPlayer.velocity = new Vector2(horizontalMoviment * speed, verticalMoviment * speed);

        // --- LÓGICA DE ANIMAÇÃO ---
        
        // Verifica se há movimento horizontal para ativar a animação de caminhada lateral
        if (horizontalMoviment != 0)
        {
            playerAnim.SetBool("Walk", true);
        }
        else
        {
            playerAnim.SetBool("Walk", false);
        }

        // Verifica movimento vertical para ativar a animação de caminhada frontal/costas
        if (verticalMoviment != 0)
        {
            playerAnim.SetBool("Walk2", true);
        }
        else
        {
            playerAnim.SetBool("Walk2", false);
        }
    }

    // Método chamado quando o Player encosta em um objeto configurado como "Is Trigger"
    void OnTriggerEnter2D(Collider2D other)
    {
        // SISTEMA DE COLETA: Verifica a Tag do objeto colidido
        
        // Coleta do Lixo Tipo 1
        if (other.CompareTag("lixo")) 
        {
            Destroy(other.gameObject); // Remove o lixo do cenário
            lixo--; // Diminui a contagem necessária
            Debug.Log("Lixo tipo 1 restante: " + lixo);

            if (lixo == -5) // Condição específica de vitória para este tipo
            {
                SceneManager.LoadScene("Fase1.5"); 
            }
        }

        // Coleta do Lixo Tipo 2
        if (other.CompareTag("lixo2")) 
        {
            Destroy(other.gameObject);
            lixo2--;
            Debug.Log("Lixo tipo 2 restante: " + lixo2); 

            if (lixo2 == 0) 
            {
                SceneManager.LoadScene("Fase2.5");
            }  
        }

        // Coleta do Lixo Tipo 3
        if (other.CompareTag("lixo3"))
        {
            Destroy(other.gameObject);
            lixo3--;
            Debug.Log("Lixo tipo 3 restante: " + lixo3);

            if (lixo3 == -5)
            {
                SceneManager.LoadScene("Fase3.5");
            }
        }
    }
}
