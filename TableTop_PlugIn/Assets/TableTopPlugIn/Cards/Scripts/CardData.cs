using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tabletop/CardData")]

public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite artwork;
    [TextArea] public string description;

    public int steps;
    public int attack;
    public int defense;
    public int cost;
}
