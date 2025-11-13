using UnityEngine;
using TMPro; // Import necessário para TextMeshPro
using System.Collections;

public class PainelDormirController : MonoBehaviour
{
    public CanvasGroup painel;           // CanvasGroup do PainelDormir
    public TextMeshProUGUI tempoTexto;   // Texto que mostra a contagem regressiva
    public float fadeDuration = 0.5f;
    public float tempoExibicao = 10f;

    private Coroutine mostrarCoroutine;

    void Start()
    {
        // Garantir que o painel começa invisível
        painel.alpha = 0;
        painel.gameObject.SetActive(false);
    }

    // Chame este método ao clicar na área
    public void MostrarPainel()
{
    // Ativa o painel antes de iniciar coroutine
    painel.gameObject.SetActive(true);
    painel.alpha = 0f; // começa invisível para fade-in

    if (mostrarCoroutine != null)
        StopCoroutine(mostrarCoroutine);

    mostrarCoroutine = StartCoroutine(MostrarPainelCoroutine());
}

    private IEnumerator MostrarPainelCoroutine()
    {
        painel.gameObject.SetActive(true);

        // Fade-in
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            painel.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }
        painel.alpha = 1f;

        // Contagem regressiva
        float tempoRestante = tempoExibicao;
        while (tempoRestante > 0)
        {
            tempoTexto.text = "Aguarde " + Mathf.CeilToInt(tempoRestante) + " segundos";
            tempoRestante -= Time.deltaTime;
            yield return null;
        }

        // Fade-out
        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            painel.alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            yield return null;
        }
        painel.alpha = 0f;
        painel.gameObject.SetActive(false);
    }
}
