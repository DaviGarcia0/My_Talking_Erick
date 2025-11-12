using UnityEngine;
using UnityEngine.EventSystems;

public class DragComida : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private PersonagemAnimacao personagem;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        personagem = FindObjectOfType<PersonagemAnimacao>(); // Acha o personagem na cena
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // Deixa semi-transparente
        canvasGroup.blocksRaycasts = false;

        if (personagem != null)
            personagem.AbrirBoca(); // 👄 Abre a boca
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
            personagem.FecharBoca(); // 😶 Fecha a boca
    }
}
