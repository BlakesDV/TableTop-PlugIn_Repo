using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private CardsManager cardManager;
    public TokenManager currentPlayer;
    public interface IManager
    {
        void Initialize();
        void Reset();
    }

    #region Unity Methods

    public void Start()
    {
        
    }

    #endregion Unity Methods

    #region CardButtons

    public void DrawChanceCard()
    {
        cardManager.DrawAndExecute(cardManager.chanceDeck, currentPlayer, this);
    }
    public void OnDrawCardButton()
    {
        cardManager.DrawCard();
    }

    #endregion CardButtons

    #region CardFunctions
    public void SetupGame()
    {
        cardManager.Initialize();
    }

    public void PlayerDrawsCard()
    {
        Card c = cardManager.DrawCard();
        if (c != null)
        {
            Debug.Log("Jugador dibujó: " + c.data.cardName);
        }
    }
    #endregion CardFunctions
}
