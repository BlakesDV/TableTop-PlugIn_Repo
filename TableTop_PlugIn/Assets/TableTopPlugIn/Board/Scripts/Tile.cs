using UnityEngine;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
    [SerializeField] public List<Tile> neighbors = new List<Tile>();
    [SerializeField] public Tile next;
    [SerializeField] public Tile prev;
}
