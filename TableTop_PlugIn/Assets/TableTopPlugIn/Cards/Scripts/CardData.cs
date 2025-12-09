using UnityEngine;

public enum CardCategory { Chance, CommunityChest, Custom }

[CreateAssetMenu(fileName = "Card", menuName = "Monopoly/Card Data")]
public class CardData : ScriptableObject
{
    public string cardName;
    [TextArea] public string description;

    public CardCategory category;
    public string effectId;

    public int steps;
    public float floatValue;
    public string nameCard;
    public bool flag;

    public Sprite artwork;
}
