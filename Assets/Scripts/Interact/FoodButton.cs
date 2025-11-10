using UnityEngine;
using UnityEngine.UI;

public class FoodButton : MonoBehaviour
{
    public Sprite foodSprite;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            FoodSelector.Instance.AddFood(foodSprite);
        });
    }
}
