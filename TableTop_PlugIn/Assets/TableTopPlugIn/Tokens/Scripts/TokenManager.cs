using UnityEngine;

public class TokenManager : MonoBehaviour
{
    public TokenBasicFunctions[] tokens;
    public RandomBoardGenerator boardGenerator;
    public CardsManager cardsManager;

    public void MoveToken(TokenBasicFunctions token, int steps, Vector2 direction)
    {
        token.MoveSteps(steps, direction);
    }

    public void MoveRandomToken()
    {
        if (tokens.Length == 0) return;

        TokenBasicFunctions token = tokens[Random.Range(0, tokens.Length)];
        int steps = Random.Range(1, 7);

        Vector2[] dirs = new Vector2[]
        {
            Vector2.up,    // Norte
            Vector2.down,  // Sur
            Vector2.left,  // Oeste
            Vector2.right  // Este
        };
        Vector2 dir = dirs[Random.Range(0, dirs.Length)];

        MoveToken(token, steps, dir);
        Debug.Log($"Token {token.name} avanza {steps} pasos hacia {dir}");
    }
    public void MoveTokenByCard(TokenBasicFunctions token)
    {
        CardData drawnCard = cardsManager.DrawCardData();
        if (drawnCard == null)
        {
            Debug.LogWarning("No hay cartas disponibles.");
            return;
        }

        int steps = drawnCard.steps;
        Debug.Log($"Carta sacada: {drawnCard.cardName} -> mover {steps} pasos");
        Vector2[] dirs = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        Vector2 dir = dirs[Random.Range(0, dirs.Length)];

        token.MoveSteps(steps, dir);
    }
}
