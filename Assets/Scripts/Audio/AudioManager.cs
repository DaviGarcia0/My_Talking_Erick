using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Range(0f, 1f)]
    public float masterVolume = 1f; // volume global

    private void Awake()
    {
        // Garante que só exista um AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // não destrói ao trocar de cena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Função para alterar o volume
    public void SetVolume(float value)
    {
        masterVolume = value;
        AudioListener.volume = masterVolume; // altera volume global do jogo
        PlayerPrefs.SetFloat("Volume", masterVolume); // salva a preferência
    }

    private void Start()
    {
        // Carrega volume salvo
        if (PlayerPrefs.HasKey("Volume"))
        {
            SetVolume(PlayerPrefs.GetFloat("Volume"));
        }
        else
        {
            SetVolume(masterVolume); // valor padrão
        }
    }
}
