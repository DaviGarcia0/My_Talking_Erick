using UnityEngine;
using System;
using System.Collections;

public class VoiceRepeater : MonoBehaviour
{
    [Header("Componente de áudio")]
    public AudioSource audioSource;

    private string nomeDispositivo;
    private bool gravando = false;

    // Eventos para controlar animações
    public Action OnAudioStart;
    public Action OnAudioEnd;

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

    // Retorna se o microfone está gravando
    public bool GravandoAtivo() => gravando;

    // Alterna entre iniciar e parar a gravação
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

        audioSource.clip = Microphone.Start(nomeDispositivo, false, 10, 44100);

        while (!(Microphone.GetPosition(nomeDispositivo) > 0))
            yield return null;

        Debug.Log("Gravando...");
    }

    private void PararGravacao()
    {
        if (!gravando) return;

        gravando = false;

        int length = Microphone.GetPosition(nomeDispositivo);
        Microphone.End(nomeDispositivo);

        if (length <= 0)
        {
            Debug.LogWarning("Nenhum som foi capturado!");
            return;
        }

        float[] samples = new float[length * audioSource.clip.channels];
        audioSource.clip.GetData(samples, 0);

        AudioClip novoClip = AudioClip.Create("GravacaoReal", length, audioSource.clip.channels, audioSource.clip.frequency, false);
        novoClip.SetData(samples, 0);

        audioSource.clip = novoClip;
        audioSource.loop = false;

        // ✅ Dispara evento de início da reprodução
        OnAudioStart?.Invoke();

        audioSource.Play();

        // ✅ Coroutine para disparar evento quando terminar
        StartCoroutine(AudioTerminou(novoClip.length));

        Debug.Log($"⏹️ Reproduzindo áudio de {novoClip.length:F2} segundos");
    }

    private IEnumerator AudioTerminou(float duracao)
    {
        yield return new WaitForSeconds(duracao);
        OnAudioEnd?.Invoke();
    }
}
