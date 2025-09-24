using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameManager : MonoBehaviour
{
    
    public interface IManager
    {
        void Initialize();
        void Reset();
    }
    public CardsManager cardManager;

    #region Unity Methods

    public void Start()
    {
        
    }

    #endregion

    #region CardFunctions
    public void SetupGame()
    {
        cardManager.Initialize();
        // if (config.useCards) cardManager.Initialize();
    }

    public void PlayerDrawsCard()
    {
        Card c = cardManager.DrawCard();
        if (c != null)
        {
            Debug.Log("Jugador dibujó: " + c.data.cardName);
        }
    }
    #endregion
}
