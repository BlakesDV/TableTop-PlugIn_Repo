using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Deck", menuName = "Monopoly/Deck Data")]
public class DeckData : ScriptableObject
{
    public List<CardData> cards;
}
