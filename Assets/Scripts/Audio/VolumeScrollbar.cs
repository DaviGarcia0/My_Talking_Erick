using UnityEngine;
using UnityEngine.UI;

public class VolumeScrollbar : MonoBehaviour
{
    public Scrollbar scrollbar;

    private void Start()
    {
        // Inicializa o scrollbar com o valor atual do volume
        scrollbar.value = AudioManager.instance.masterVolume;

        // Adiciona listener
        scrollbar.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float value)
    {
        AudioManager.instance.SetVolume(value);
    }
}
