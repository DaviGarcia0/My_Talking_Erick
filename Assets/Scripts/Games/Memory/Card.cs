using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public int cardId;
    public Sprite frontImage;
    public Sprite backImage;

    private Image image;
    private GameController controller;
    private bool isFlipped = false;

    private void Awake()
    {
        // Garante que sempre há um Image (mesmo que o prefab tenha sido alterado)
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("❌ Nenhum componente Image encontrado no prefab da carta!");
        }

        controller = FindObjectOfType<GameController>();
        if (controller == null)
        {
            Debug.LogError("❌ Nenhum GameController encontrado na cena!");
        }
    }

    private void Start()
    {
        ShowBack(); // começa virado pra baixo
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isFlipped)
        {
            ShowFront();
            controller.CardRevealed(this);
        }
    }

    public void ShowFront()
    {
        if (image == null) return;

        image.sprite = frontImage;
        isFlipped = true;
    }

    public void ShowBack()
    {
        if (image == null) return;

        image.sprite = backImage;
        isFlipped = false;
    }
}
