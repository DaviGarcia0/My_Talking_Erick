using UnityEngine;

public class AbrirPainel : MonoBehaviour
{
    public GameObject painel;           // O painel que abre
    public GameObject[] botoesDeFundo;  // Todos os botões que devem sumir

    public void Abrir()
    {
        painel.SetActive(true);

        // Desativa todos os botões de fundo
        foreach (GameObject botao in botoesDeFundo)
        {
            botao.SetActive(false);
        }
    }

    public void Fechar()
    {
        painel.SetActive(false);

        // Reativa os botões
        foreach (GameObject botao in botoesDeFundo)
        {
            botao.SetActive(true);
        }
    }
}
