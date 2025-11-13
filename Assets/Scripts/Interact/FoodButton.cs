using UnityEngine;
using UnityEngine.UI;

public class FoodButton : MonoBehaviour
{
    public Sprite foodSprite;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (FoodSelector.Instance != null)
                FoodSelector.Instance.AddFood(foodSprite);
        });
    }
}
