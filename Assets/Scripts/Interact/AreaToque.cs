using UnityEngine;
using UnityEngine.EventSystems;

public class AreaToque : MonoBehaviour, IPointerClickHandler
{
    public string animacao; // Nome da animação no Animator
    private PersonagemAnimacao personagem;

    void Start()
    {
        personagem = FindObjectOfType<PersonagemAnimacao>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (personagem != null)
            personagem.TocarAnimacao(animacao);
    }
}
