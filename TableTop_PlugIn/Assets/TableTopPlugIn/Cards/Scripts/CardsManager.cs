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
    [SerializeField] private float spacing = 150f;

    public event Action<Card> OnCardDrawn;

    public void Initialize()
    {
        foreach (Card card in hand)
        {
            if (card != null)
                Destroy(card.gameObject);
        }

        hand.Clear();
        discardPile.Clear();
        deck.Clear();
        deck.AddRange(deckData);
        ShuffleDeck();
        int initialHandCount = 5;
        for (int i = 0; i < initialHandCount; i++)
        {
            DrawCard();
        }
        UpdateHandPositions();

        Debug.Log(" Mazo inicializado con {deck.Count} cartas restantes.");
    }

    public void Reset()
    {
        foreach (Card card in hand)
        {
            if (card != null)
                Destroy(card.gameObject);
        }

        hand.Clear();
        deck.Clear();
        discardPile.Clear();
        deck.AddRange(deckData);
        ShuffleDeck();
        Debug.Log("El mazo ha sido reiniciado.");
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int rnd = UnityEngine.Random.Range(i, deck.Count);
            var temp = deck[i];
            deck[i] = deck[rnd];
            deck[rnd] = temp;
        }
    }
    public void InitializeDraw() { deck.Clear(); deck.AddRange(deckData); ShuffleDeck(); }
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
    public void UpdateHandPositions()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            RectTransform rect = hand[i].GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(i * spacing, 0);
        }
    }
    public CardData DrawCardData()
    {
        Card drawnCard = DrawCard();
        if (drawnCard != null)
            return drawnCard.data;
        return null;
    }
}
