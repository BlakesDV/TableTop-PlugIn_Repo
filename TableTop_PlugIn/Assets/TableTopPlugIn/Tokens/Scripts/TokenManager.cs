using UnityEngine;
using System.Collections;

public class TokenManager : MonoBehaviour
{
    [Header("References")]
    public TokenBasicFunctions token;
    public BoardGraph boardGraph;
    public DiceController dice;

    [Header("Dice Settings")]
    public float throwForce = 8f;
    public float torqueForce = 10f;

    public void RollDiceAndMoveTokenUI()
    {
        if (token == null || dice == null || boardGraph == null)
        {
            Debug.LogWarning("Token, dado o BoardGraph no asignado.");
            return;
        }

        StartCoroutine(RollAndMoveCoroutine());
    }

    private IEnumerator RollAndMoveCoroutine()
    {
        dice.Throw(throwForce, torqueForce);
        yield return new WaitUntil(() => dice.HasStopped);
        if (token.currentTile == null)
        {
            token.SnapToTile(boardGraph.head);
        }
        token.MoveStepsByIndex(dice.FinalValue);

        Debug.Log($"Token {token.name} avanza {dice.FinalValue} pasos según el dado {dice.diceData.diceName}.");
    }
}
