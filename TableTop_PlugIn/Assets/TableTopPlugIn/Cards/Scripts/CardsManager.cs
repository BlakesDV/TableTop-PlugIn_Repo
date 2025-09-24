using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CoreGameManager;

public class CardsManager : MonoBehaviour, IManager
{
    // Adaptado con ayuda de ChatGPT (2025)

    [SerializeField] private List<CardData> deckData;

    private List<CardData> deck = new List<CardData>();
    private List<CardData> discardPile = new List<CardData>();

    private List<Card> hand = new List<Card>();

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform handAreaParent;

    public event Action<Card> OnCardDrawn;

    public void Initialize()
    {
        deck.Clear();
        deck.AddRange(deckData);
        ShuffleDeck();
    }

    public void Reset()
    {
        deck.Clear();
        discardPile.Clear();
        hand.Clear();
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int rnd = UnityEngine.Random.Range(i, deck.Count);
            var temp = deck[i];
            deck[i] = deck[rnd];
            deck[rnd] = temp;
        }
    }

    public Card DrawCard()
    {
        if (deck.Count == 0)
        {
            deck.AddRange(discardPile);
            discardPile.Clear();
            ShuffleDeck();
        }
        if (deck.Count == 0)
            return null;

        CardData drawnData = deck[0];
        deck.RemoveAt(0);

        GameObject go = Instantiate(cardPrefab, handAreaParent);
        Card cardComponent = go.GetComponent<Card>();
        cardComponent.Initialize(drawnData);

        hand.Add(cardComponent);
        OnCardDrawn?.Invoke(cardComponent);

        return cardComponent;
    }

    public void Discard(Card card)
    {
        if (hand.Remove(card))
        {
            discardPile.Add(card.data);
            Destroy(card.gameObject);
        }
    }
}
