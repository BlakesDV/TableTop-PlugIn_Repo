using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tabletop/CardData")]

public class CardData : ScriptableObject
{
    [Header("Información básica")]
    public string cardName;
    public Sprite artwork;
    [TextArea] public string description;

    [Header("Estadísticas")]
    public int attack;
    public int defense;
    public int cost;
}
