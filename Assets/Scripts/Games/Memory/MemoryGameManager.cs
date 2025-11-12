using System.Collections.Generic;
using UnityEngine;

public class MemoryGameManager : MonoBehaviour
{
    [Header("Referências")]
    public GameObject cardPrefab;
    public Transform gridParent;

    [Header("Cartas e pares")]
    public List<Sprite> cardFrontImages; // imagens dos pares (cada elemento = 1 par)
    public Sprite backImage;             // verso comum

    [Header("Configurações")]
    public int numberOfPairs = 4;        // quantos pares (deve ser <= cardFrontImages.Count)

    private void Start()
    {
        GenerateCards();
    }

    void GenerateCards()
    {
        // limpa o grid
        foreach (Transform child in gridParent)
            Destroy(child.gameObject);

        // validação básica
        if (numberOfPairs > cardFrontImages.Count)
        {
            Debug.LogError("numberOfPairs maior que cardFrontImages.Count");
            numberOfPairs = cardFrontImages.Count;
        }

        // Cria lista de objetos (sprite + id) duplicados para formar pares
        List<CardData> cardDatas = new List<CardData>();
        for (int i = 0; i < numberOfPairs; i++)
        {
            CardData a = new CardData { sprite = cardFrontImages[i], id = i };
            CardData b = new CardData { sprite = cardFrontImages[i], id = i };
            cardDatas.Add(a);
            cardDatas.Add(b);
        }

        // Embaralha (Fisher-Yates)
        for (int i = 0; i < cardDatas.Count; i++)
        {
            int rnd = Random.Range(i, cardDatas.Count);
            CardData tmp = cardDatas[i];
            cardDatas[i] = cardDatas[rnd];
            cardDatas[rnd] = tmp;
        }

        // Instancia no Grid e configura cada Card com sprite e id
        foreach (CardData data in cardDatas)
        {
            GameObject newCard = Instantiate(cardPrefab, gridParent);
            Card cardScript = newCard.GetComponent<Card>();
            if (cardScript == null)
            {
                Debug.LogError("Prefab não contém o script Card!");
                continue;
            }
            cardScript.cardId = data.id;
            cardScript.frontImage = data.sprite;
            cardScript.backImage = backImage;
            // garante que o cartão inicie no estado de "verso" (se o Card.cs depender disso)
            cardScript.ShowBack();
        }
    }

    // classe auxiliar para parear sprite + id
    private class CardData
    {
        public Sprite sprite;
        public int id;
    }
}
