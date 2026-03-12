using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Este script atua como um controlador de estado da fase.
// Ele garante que o progresso do jogador seja reiniciado corretamente ao carregar a cena.
public class GerenciadorDeCenas : MonoBehaviour
{
    // O método Start é chamado assim que a cena é carregada e o objeto é ativado.
    void Start()
    {
        // RESET DE ESTADO: Como 'itensColocados' é uma variável static em SlotItenDrop,
        // ela não zera sozinha ao mudar de cena. Precisamos fazer isso manualmente aqui.
        SlotItenDrop.itensColocados = 0;

        // CONFIGURAÇÃO DINÂMICA: Definimos a meta de itens para esta cena específica.
        // Isso permite reutilizar o código em fases com dificuldades diferentes (ex: 5 itens, 10 itens).
        SlotItenDrop.totalItens = 5;
        
        Debug.Log("Gerenciador: Progresso resetado. Meta da fase: " + SlotItenDrop.totalItens);
    }

    // O Update está vazio para poupar processamento, já que a configuração só precisa ocorrer uma vez no início.
    void Update()
    {
        
    }
}
