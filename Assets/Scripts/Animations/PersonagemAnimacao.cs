using UnityEngine;

public class PersonagemAnimacao : MonoBehaviour
{
    public Animator animator;
    private bool bocaAberta = false;

    void Update()
    {
        animator.SetBool("BocaAberta", bocaAberta);
    }

    public void AbrirBoca()
    {
        bocaAberta = true;
    }

    public void FecharBoca()
    {
        bocaAberta = false;
    }
}
