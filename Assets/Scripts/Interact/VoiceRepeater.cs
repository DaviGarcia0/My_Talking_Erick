using UnityEngine;
using System.Collections;

public class VoiceRepeater : MonoBehaviour
{
    public AudioSource audioSource;
    private string nomeDispositivo;
    private bool gravando = false;

    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            nomeDispositivo = Microphone.devices[0];
            Debug.Log("Microfone disponível: " + nomeDispositivo);
        }
        else
        {
            Debug.LogWarning("Nenhum microfone encontrado!");
        }
    }

    public void AlternarGravacao()
    {
        if (!gravando)
            StartCoroutine(IniciarGravacao());
        else
            PararGravacao();
    }

    private IEnumerator IniciarGravacao()
    {
        if (nomeDispositivo == null)
        {
            Debug.LogWarning("Nenhum microfone disponível!");
            yield break;
        }

        Debug.Log("🎤 Iniciando gravação...");
        gravando = true;

        // Inicia a gravação com duração máxima de 10 segundos (você pode aumentar)
        audioSource.clip = Microphone.Start(nomeDispositivo, false, 10, 44100);

        // Espera o microfone começar
        while (!(Microphone.GetPosition(nomeDispositivo) > 0))
            yield return null;

        Debug.Log("Gravando...");
    }

    private void PararGravacao()
    {
        if (!gravando) return;

        gravando = false;
        Microphone.End(nomeDispositivo);

        Debug.Log("⏹️ Parou de gravar. Pronto para reproduzir.");
        Debug.Log($"Duração capturada: {audioSource.clip.length:F2} segundos");

        if (audioSource.clip != null && audioSource.clip.length > 0.1f)
        {
            audioSource.loop = false;
            audioSource.Stop();
            audioSource.PlayOneShot(audioSource.clip);
            Debug.Log("🔊 Reproduzindo o áudio gravado...");
        }
        else
        {
            Debug.LogWarning("Nenhum som foi capturado (áudio vazio).");
        }
    }
}
