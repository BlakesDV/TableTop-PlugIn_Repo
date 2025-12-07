using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class DiceManager : MonoBehaviour
{
    public List<DiceController> diceList = new List<DiceController>();

    public float throwForce = 8f;
    public float torqueForce = 10f;

    public void ThrowAll()
    {
        foreach (var dice in diceList)
            dice.Throw(throwForce, torqueForce);

        StartCoroutine(GetResultsAfterAllStop());
    }

    private IEnumerator GetResultsAfterAllStop()
    {
        yield return new WaitUntil(() => diceList.All(d => d.HasStopped));

        foreach (var dice in diceList)
        {
            Debug.Log($"{dice.diceData.diceName}: {dice.FinalValue}");
        }
    }
}
