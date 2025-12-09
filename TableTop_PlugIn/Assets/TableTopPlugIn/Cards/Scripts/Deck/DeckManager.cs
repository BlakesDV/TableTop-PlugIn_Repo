using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DeckManager : MonoBehaviour
{
    public DeckData deckData;
    private Queue<CardData> deckQueue;

    void Start()
    {
        ResetDeck();
    }

    public void ResetDeck()
    {
        deckQueue = new Queue<CardData>(deckData.cards.OrderBy(c => Random.value));
    }

    public CardData Draw()
    {
        if (deckQueue.Count == 0)
            ResetDeck();

        return deckQueue.Dequeue();
    }
}
