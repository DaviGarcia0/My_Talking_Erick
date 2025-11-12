using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Card firstCard;
    private Card secondCard;

    public float delay = 1f;
    private int matchesFound = 0;
    private int totalPairs;
    private bool isChecking = false; // bloqueia novas seleções enquanto checamos

    private void Start()
    {
        totalPairs = FindObjectsOfType<Card>().Length / 2;
    }

    public void CardRevealed(Card card)
    {
        // Proteções:
        if (isChecking) return;                    // estamos checando, ignora clicks
        if (card == null) return;
        if (firstCard == null)
        {
            firstCard = card;
            return;
        }

        // evita clicar no mesmo card duas vezes
        if (card == firstCard) return;

        // se já temos a primeira carta, pega a segunda e checa
        secondCard = card;
        StartCoroutine(CheckMatch());
    }

    private IEnumerator CheckMatch()
    {
        isChecking = true;
        yield return new WaitForSeconds(delay);

        // segurança: se qualquer um for nulo, reset e saia
        if (firstCard == null || secondCard == null)
        {
            firstCard = null;
            secondCard = null;
            isChecking = false;
            yield break;
        }

        // compara ids
        if (firstCard.cardId == secondCard.cardId)
        {
            // par correto: desativa visualmente ou faça outra ação
            firstCard.gameObject.SetActive(false);
            secondCard.gameObject.SetActive(false);

            matchesFound++;
            if (matchesFound >= totalPairs)
            {
                Debug.Log("🎉 Você ganhou!");
                // aqui pode abrir painel de vitória, som etc.
            }
        }
        else
        {
            // não é par: vira de volta
            firstCard.ShowBack();
            secondCard.ShowBack();
        }

        // reseta estado
        firstCard = null;
        secondCard = null;
        isChecking = false;
    }

    public void VoltarParaCenaPrincipal()
    {
        SceneManager.LoadScene("Quarto");
    }
}
