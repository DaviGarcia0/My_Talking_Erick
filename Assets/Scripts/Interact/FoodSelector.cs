using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FoodSelector : MonoBehaviour
{
    public static FoodSelector Instance;

    [Header("Referências")]
    public Image selectedFoodImage;
    public GameObject panel;

    [Header("Lista de comidas selecionadas")]
    public List<Sprite> foods = new List<Sprite>();

    private int currentIndex = -1;
    private bool isVisible = false;

    void Awake()
    {
        Instance = this;
        HideSelector();
    }

    public void AddFood(Sprite food)
    {
        if (food == null) return;

        // Evita adicionar duplicado
        if (!foods.Contains(food))
            foods.Add(food);

        ShowFood(food);
    }

    public void ShowFood(Sprite food)
    {
        if (food == null) return;

        panel.SetActive(true);
        selectedFoodImage.sprite = food;
        currentIndex = foods.IndexOf(food);
        isVisible = true;
    }

    public void NextFood()
    {
        if (!isVisible || foods.Count <= 1) return;

        currentIndex++;
        if (currentIndex >= foods.Count) currentIndex = 0;
        selectedFoodImage.sprite = foods[currentIndex];
    }

    public void PreviousFood()
    {
        if (!isVisible || foods.Count <= 1) return;

        currentIndex--;
        if (currentIndex < 0) currentIndex = foods.Count - 1;
        selectedFoodImage.sprite = foods[currentIndex];
    }

    public void HideSelector()
    {
        isVisible = false;
        panel.SetActive(false);
        selectedFoodImage.sprite = null;
        foods.Clear(); // limpa lista quando fecha o painel
    }
}
