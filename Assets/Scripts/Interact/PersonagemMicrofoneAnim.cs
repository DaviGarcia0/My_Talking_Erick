using UnityEngine;

public class PersonagemMicrofoneAnim : MonoBehaviour
{
    public Animator animator;
    public VoiceRepeater voiceRepeater;

    void Start()
    {
        // Garante que começa em Idle
        if (animator != null)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Falando", false);
            animator.SetBool("Ouvindo", false);
        }

        // Se o voiceRepeater não foi definido manualmente, tenta achar na cena
        if (voiceRepeater == null)
        {
            voiceRepeater = FindAnyObjectByType<VoiceRepeater>();
        }

        ConectarEventos();
    }

    void OnEnable()
    {
        // Reconecta sempre que o objeto for ativado (útil se mudar de cena)
        ConectarEventos();
    }

    void OnDisable()
    {
        // Evita múltiplos registros duplicados
        if (voiceRepeater != null)
        {
            voiceRepeater.OnAudioStart -= AoComecarAudio;
            voiceRepeater.OnAudioEnd -= AoTerminarAudio;
        }
    }

    private void ConectarEventos()
    {
        if (voiceRepeater == null) return;

        // Evita registrar o mesmo evento mais de uma vez
        voiceRepeater.OnAudioStart -= AoComecarAudio;
        voiceRepeater.OnAudioEnd -= AoTerminarAudio;

        voiceRepeater.OnAudioStart += AoComecarAudio;
        voiceRepeater.OnAudioEnd += AoTerminarAudio;
    }

    private void AoComecarAudio()
    {
        animator.SetBool("Falando", true);
        animator.SetBool("Idle", false);
    }

    private void AoTerminarAudio()
    {
        animator.SetBool("Falando", false);
        animator.SetBool("Idle", true);
    }

    void Update()
    {
        if (voiceRepeater == null || animator == null) return;

        animator.SetBool("Ouvindo", voiceRepeater.GravandoAtivo());

        if (!voiceRepeater.GravandoAtivo() && !animator.GetBool("Falando"))
        {
            animator.SetBool("Idle", true);
        }
    }
}
