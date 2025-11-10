using UnityEngine;
using UnityEngine.UI;

public class MicrofoneToggle : MonoBehaviour
{
    public Image botaoImagem;     // Arraste o componente Image do botão
    public Sprite micDesligado;   // Sprite inicial (microfone desligado)
    public Sprite micLigado;      // Sprite quando clicado (microfone ligado)

    private bool microfoneAtivo = false;

    void Start()
    {
        // Garante que começa com o microfone desligado
        botaoImagem.sprite = micDesligado;
    }

    public void AoClicar()
    {
        microfoneAtivo = !microfoneAtivo;

        // Troca o sprite conforme o estado
        botaoImagem.sprite = microfoneAtivo ? micLigado : micDesligado;
    }
}
