using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FoodSelector : MonoBehaviour
{
    public static FoodSelector Instance;

    [Header("Referências")]
    public Image selectedFoodImage;
    public GameObject panel;

    [Header("Setas de navegação")]
    public GameObject leftArrow;
    public GameObject rightArrow;

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

        // Mostra o item e atualiza setas
        ShowFood(food);
    }

    public void ShowFood(Sprite food)
    {
        panel.SetActive(true);
        isVisible = true;

        if (food != null)
        {
            selectedFoodImage.sprite = food;
            selectedFoodImage.enabled = true;
            currentIndex = foods.IndexOf(food);
        }
        else
        {
            selectedFoodImage.sprite = null;
            selectedFoodImage.enabled = false;
            currentIndex = -1;
        }

        AtualizarSetas();
    }

    public void NextFood()
    {
        if (!isVisible || foods.Count <= 1) return;

        currentIndex++;
        if (currentIndex >= foods.Count) currentIndex = 0;

        UpdateImage();
    }

    public void PreviousFood()
    {
        if (!isVisible || foods.Count <= 1) return;

        currentIndex--;
        if (currentIndex < 0) currentIndex = foods.Count - 1;

        UpdateImage();
    }

    private void UpdateImage()
    {
        if (currentIndex >= 0 && currentIndex < foods.Count && foods[currentIndex] != null)
        {
            selectedFoodImage.sprite = foods[currentIndex];
            selectedFoodImage.enabled = true;
        }
        else
        {
            selectedFoodImage.sprite = null;
            selectedFoodImage.enabled = false;
        }

        AtualizarSetas();
    }

    private void AtualizarSetas()
    {
        // Mostra setas **só se houver pelo menos um item selecionado**
        bool mostrarSetas = foods.Count > 0 && selectedFoodImage.sprite != null;
        leftArrow.SetActive(mostrarSetas);
        rightArrow.SetActive(mostrarSetas);
    }

    public void HideSelector()
    {
        isVisible = false;
        panel.SetActive(false);
        selectedFoodImage.sprite = null;
        selectedFoodImage.enabled = false;
        foods.Clear();

        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
    }
}
