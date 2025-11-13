using UnityEngine;

public class HideFoodSelector : MonoBehaviour
{
    public GameObject FoodPanel;
    public GameObject DrinksPanel;
    public FoodSelector foodSelector;

    void Update()
    {
        if (foodSelector == null) return;

        bool algumPainelAberto =
            (FoodPanel != null && FoodPanel.activeSelf) ||
            (DrinksPanel != null && DrinksPanel.activeSelf);

        if (algumPainelAberto)
        {
            if (foodSelector.panel.activeSelf)
                foodSelector.panel.SetActive(false);
        }
        else
        {
            if (!foodSelector.panel.activeSelf && foodSelector.GetSelectedFood() != null)
            {
                foodSelector.panel.SetActive(true);
            }
        }
    }
}
