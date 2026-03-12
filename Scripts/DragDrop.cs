using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Esse script gerencia a lógica de arrastar e soltar os objetos de lixo na UI.
// Implementamos as interfaces do Unity EventSystems para capturar cliques e movimentos do mouse/toque.
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // Variáveis para identificar qual o tipo de lixo esse objeto representa
    public TipoLixo tipoLixo;
    public LixoType lixoType;
    public TypeLixo typeLixo;
    public string lixo;
    
    // Referência ao componente de posição da UI (essencial para mover o objeto na tela)
    public RectTransform rectTransform;

    // Referências ao Canvas e ao CanvasGroup para controle de renderização e física da UI
    [SerializeField] private Canvas canvas;
    [SerializeField] private CanvasGroup canvasGroup;

    // O Awake roda assim que o script é carregado, antes do jogo começar
    public void Awake()
    {
        // Pegamos os componentes automaticamente para não ter que arrastar manualmente no Inspector
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Detecta quando o usuário clica no objeto
    public void OnPointerDown (PointerEventData eventData)
    {
        Debug.Log("mouse precionou o objeto");
    }  

    // Executado no momento exato em que o arraste começa
    public void OnBeginDrag (PointerEventData eventData)
    {
        // Desabilitamos o 'blocksRaycasts' para que o mouse "atravesse" o objeto enquanto arrastamos.
        // Isso é necessário para que a lixeira consiga detectar que o lixo foi solto em cima dela.
        canvasGroup.blocksRaycasts = false;
    }

    // Executado quando o usuário solta o botão do mouse
    public void OnEndDrag(PointerEventData evenData)
    {
        // Reativamos a detecção de raios para que o objeto possa ser clicado novamente
        canvasGroup.blocksRaycasts = true;
    }

    // Executado a cada frame enquanto o objeto está sendo arrastado
    public void OnDrag (PointerEventData eventData)
    {
        // Atualiza a posição do objeto com base no movimento do mouse (delta).
        // Dividimos pelo 'scaleFactor' para que a velocidade do arraste seja a mesma em qualquer resolução de tela.
