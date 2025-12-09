using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CardEffects : MonoBehaviour
{
    public List<CardEffectPair> effects;

    private Dictionary<string, ICardEffects> lookup;

    void Awake()
    {
        lookup = effects.ToDictionary(e => e.id, e => e.effect as ICardEffects);
    }

    public ICardEffects GetEffect(string id)
    {
        return lookup[id];
    }
}

[System.Serializable]
public class CardEffectPair
{
    public string id;
    public ScriptableObject effect;
}
