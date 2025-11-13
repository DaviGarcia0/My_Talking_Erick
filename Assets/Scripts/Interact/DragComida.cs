using UnityEngine;
using UnityEngine.EventSystems;

public class DragComida : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private PersonagemAnimacao personagem;
    private Vector2 startPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        personagem = FindObjectOfType<PersonagemAnimacao>();
        startPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;

        if (personagem != null)
            personagem.AbrirBoca();

        // Atualiza referência no FoodSelector
        FoodSelector.Instance.currentDraggableFood = this;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (personagem != null)
            personagem.FecharBoca();

        // Volta à posição inicial se não foi comida
        if (gameObject.activeSelf)
            ResetPosition();
    }

    // Reset completo da comida
    public void ResetPosition()
    {
        rectTransform.anchoredPosition = startPosition;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        gameObject.SetActive(true);
    }
}
