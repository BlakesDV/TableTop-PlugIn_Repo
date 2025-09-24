using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tabletop/CardData")]

public class CardData : ScriptableObject
{
    [Header("Informaci�n b�sica")]
    public string cardName;
    public Sprite artwork;
    [TextArea] public string description;

    [Header("Estad�sticas")]
    public int attack;
    public int defense;
    public int cost;
}
