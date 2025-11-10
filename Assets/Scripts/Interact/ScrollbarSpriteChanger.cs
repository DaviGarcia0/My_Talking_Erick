using UnityEngine;
using UnityEngine.UI;

public class ScrollbarSpriteChanger : MonoBehaviour
{
    public Scrollbar scrollbar;     // A scrollbar que você quer monitorar
    public Image handleImage;       // A imagem do handle (botão que arrasta)
    public Sprite sprite0;          // Sprite para 0%
    public Sprite sprite50;         // Sprite para 50%
    public Sprite sprite100;        // Sprite para 100%

    void Start()
    {
        // Atualiza o sprite no início
        UpdateHandleSprite(scrollbar.value);

        // Adiciona listener para mudar o sprite sempre que o valor mudar
        scrollbar.onValueChanged.AddListener(UpdateHandleSprite);
    }

    void UpdateHandleSprite(float value)
    {
        if (value <= 0.01f)             // perto de 0%
            handleImage.sprite = sprite0;
        else if (value >= 0.99f)        // perto de 100%
            handleImage.sprite = sprite100;
        else
            handleImage.sprite = sprite50; // entre 0 e 100% (50%)
    }
}
