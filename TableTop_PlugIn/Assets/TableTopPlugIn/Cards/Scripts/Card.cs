using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData data;
    // Aqu� referencias a UI, etc.
    public void Initialize(CardData d)
    {
        data = d;
        // Actualizar sprite, texto, etc.
    }
    
}
