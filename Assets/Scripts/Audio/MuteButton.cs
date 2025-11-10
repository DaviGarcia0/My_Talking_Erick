using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Toggle muteToggle;       // O botão booleano (Toggle)
    public Scrollbar volumeScrollbar; // A scrollbar de volume

    private float previousVolume;   // Guarda o volume antes de mutar

    void Start()
    {
        // Carrega volume salvo ou usa 1 como padrão
        if (PlayerPrefs.HasKey("Volume"))
            previousVolume = PlayerPrefs.GetFloat("Volume");
        else
            previousVolume = 1f;

        // Inicializa o volume global
        AudioListener.volume = previousVolume;

        // Inicializa estado do mute
        if (PlayerPrefs.HasKey("Muted"))
            muteToggle.isOn = PlayerPrefs.GetInt("Muted") == 1 ? true : false;

        ApplyMute(muteToggle.isOn);

        // Adiciona listeners
        muteToggle.onValueChanged.AddListener(ApplyMute);
        volumeScrollbar.onValueChanged.AddListener(UpdateVolume);
    }

    void ApplyMute(bool isMuted)
    {
        if (isMuted)
        {
            // Guarda o volume atual antes de mutar
            previousVolume = volumeScrollbar.value;
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = previousVolume;
        }

        // Salva estado do mute
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    void UpdateVolume(float value)
    {
        // Se estiver mutado, não altera o volume
        if (!muteToggle.isOn)
        {
            previousVolume = value;
            AudioListener.volume = value;
            PlayerPrefs.SetFloat("Volume", value);
        }
    }
}
