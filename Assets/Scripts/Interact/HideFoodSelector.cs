using UnityEngine;

public class HideFoodSelector : MonoBehaviour
{
    public GameObject FoodPanel;
    public GameObject DrinksPanel;
    public GameObject FoodSelector;

    void Update()
    {
        // Se algum dos painéis estiver ativo, esconde o FoodSelector
        if ((FoodPanel != null && FoodPanel.activeSelf) || 
            (DrinksPanel != null && DrinksPanel.activeSelf))
        {
            FoodSelector.SetActive(false);
        }
        else
        {
            FoodSelector.SetActive(true);
        }
    }
}
