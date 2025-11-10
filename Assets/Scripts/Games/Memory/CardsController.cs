using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsController : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    [SerializeField] Transform gridTransform;
    [SerializeField] Sprite[] sprites;

    private List<Sprite> spritePairs;

    private void Start()
    {
        PrepareSprites();
        CreateCards();
    }




    private void PrepareSprites()
    {
        spritePairs = new List<Sprite>();

        for(int i = 0; i < sprites.Length; i++)
        {
            spritePairs.Add(spritePairs[i]);
            spritePairs.Add(spritePairs[i]);
        }
        ShufflesSprites(spritePairs);
    }

    void CreateCards()
    {
        for(int i = 0; i < spritePairs.Count; i++)
        {
            Card card = Instantiate(cardPrefab, gridTransform);
            card.SetIconSprite(spritePairs[i]);
        }
    }

    void ShufflesSprites(List<Sprite> spriteList)
    {
        for(int i = spriteList.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            Sprite temp = spriteList[i];
            spriteList[i] = spriteList[randomIndex];
            spriteList[randomIndex] = temp;
        }
    }
}
