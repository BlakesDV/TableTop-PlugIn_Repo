using UnityEngine;

[CreateAssetMenu(fileName = "DiceData", menuName = "Dice/DiceData")]
public class DiceData : ScriptableObject
{
    public string diceName = "D6";
    public int[] faceValues;
}
