using UnityEngine;

public class AbrirPainelGeladeira : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject selectorPanel;   // o painel da geladeira (com botões Comida e Bebida)
    public GameObject painelComidas;   // painel da cozinha (comidas)
    public GameObject painelBebidas;   // painel da geladeira (bebidas)

    public void AbrirSelector()
    {
        selectorPanel.SetActive(true);
    }

    public void FecharSelector()
    {
        selectorPanel.SetActive(false);
    }

    public void AbrirComidas()
    {
        selectorPanel.SetActive(false);
        painelComidas.SetActive(true);
    }

    public void AbrirBebidas()
    {
        selectorPanel.SetActive(false);
        painelBebidas.SetActive(true);
    }
}
