using UnityEngine;

public class PersonagemAnimacao : MonoBehaviour
{
    public Animator animator;
    private bool bocaAberta = false;

    void Update()
    {
        animator.SetBool("BocaAberta", bocaAberta);
    }

    public void AbrirBoca() => bocaAberta = true;
    public void FecharBoca() => bocaAberta = false;
    public void TapaCabeca() => animator.SetTrigger("TapaCabeca");
    public void TapaMao() => animator.SetTrigger("TapaMao");
    public void TapaPerna() => animator.SetTrigger("TapaPerna");
    public void TapaMaoEsquerda() => animator.SetTrigger("TapaMaoEsquerda");
    public void TapaPernaDireita() => animator.SetTrigger("TapaPernaDireita");

    public void TocarAnimacao(string nome)
    {
        animator.SetTrigger(nome);
    }

    // 🔹 Toca a animação de comer e remove a comida
    public void Comer()
    {
        animator.SetTrigger("Comer");
        FecharBoca();

        // Espera a animação terminar pra limpar a comida atual
        Invoke(nameof(FinalizarComer), 1.2f); // Ajuste o tempo se a animação for mais longa
    }

    private void FinalizarComer()
    {
        // Verifica se o FoodSelector existe
        if (FoodSelector.Instance != null)
        {
            FoodSelector.Instance.RemoveCurrentFood();
        }
    }
}
