using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FoodSelector : MonoBehaviour
{
    public static FoodSelector Instance;

    [Header("Referências")]
    public GameObject panel;
    public Image selectedFoodImage;
    public GameObject leftArrow;
    public GameObject rightArrow;

    [HideInInspector]
    public DragComida currentDraggableFood; // referência para a comida arrastável atual

    private List<Sprite> foods = new List<Sprite>();
    private int currentIndex = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        if (panel != null)
            panel.SetActive(false);
    }

    // Adiciona novo alimento
    public void AddFood(Sprite food)
    {
        if (food == null) return;

        // Adiciona à lista
        foods.Add(food);
        currentIndex = foods.Count - 1; // seleciona o recém-adicionado

        // Atualiza painel
        panel.SetActive(true);
        selectedFoodImage.enabled = true;
        selectedFoodImage.sprite = food;

        AtualizarSetas();
    }

    // Remove o alimento atual (quando comido)
    public void RemoveCurrentFood()
    {
        if (foods.Count == 0) return;

        // Reset da comida arrastável
        if (currentDraggableFood != null)
        {
            currentDraggableFood.ResetPosition();
            currentDraggableFood = null;
        }

        foods.RemoveAt(currentIndex);

        if (foods.Count > 0)
        {
            // Ajusta índice e mostra próximo alimento
            currentIndex = Mathf.Clamp(currentIndex, 0, foods.Count - 1);
            ShowFood();
        }
        else
        {
            // Lista vazia → esconde painel
            selectedFoodImage.sprite = null;
            selectedFoodImage.enabled = false;
            panel.SetActive(false);
        }

        AtualizarSetas();
    }

    public void NextFood()
    {
        if (foods.Count <= 1) return;
        currentIndex = (currentIndex + 1) % foods.Count;
        ShowFood();
    }

    public void PreviousFood()
    {
        if (foods.Count <= 1) return;
        currentIndex = (currentIndex - 1 + foods.Count) % foods.Count;
        ShowFood();
    }

    private void ShowFood()
    {
        if (foods.Count == 0) return;

        selectedFoodImage.enabled = true;
        selectedFoodImage.sprite = foods[currentIndex];
        AtualizarSetas();
    }

    private void AtualizarSetas()
    {
        bool mostrar = foods.Count > 1;
        leftArrow.SetActive(mostrar);
        rightArrow.SetActive(mostrar);
    }

    public Sprite GetSelectedFood()
    {
        if (foods.Count == 0 || currentIndex < 0) return null;
        return foods[currentIndex];
    }
}
