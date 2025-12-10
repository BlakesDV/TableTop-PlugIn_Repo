using UnityEngine;
using System.Collections.Generic;

public class BoardGraph : MonoBehaviour
{
    [Header("Tiles")]
    [SerializeField] public List<Tile> allTiles = new List<Tile>();

    [Header("Linked List")]
    [SerializeField] public Tile head;
    [SerializeField] public Tile tail;

    [Header("Settings")]
    public bool loopLinkedList = true;

    public void BuildGraph(Tile[,] grid, int width, int height)
    {
        allTiles.Clear();
        head = null;
        tail = null;

        for (int x = 0; x < width; x++)
        {
            if (x % 2 == 0)
            {
                for (int y = 0; y < height; y++)
                    AddTile(grid, x, y);
            }
            else
            {
                for (int y = height - 1; y >= 0; y--)
                    AddTile(grid, x, y);
            }
        }

        BuildLinkedList();

        Debug.Log($"[BoardGraph] Graph construido. Total tiles: {allTiles.Count}");
    }

    private void AddTile(Tile[,] grid, int x, int y)
    {
        Tile t = grid[x, y];
        if (t == null) return;

        allTiles.Add(t);
        t.neighbors.Clear();

        // Vecinos 4 direcciones
        TryAddNeighbor(t, grid, x + 1, y);
        TryAddNeighbor(t, grid, x - 1, y);
        TryAddNeighbor(t, grid, x, y + 1);
        TryAddNeighbor(t, grid, x, y - 1);
    }

    private void TryAddNeighbor(Tile t, Tile[,] grid, int x, int y)
    {
        int width = grid.GetLength(0);
        int height = grid.GetLength(1);

        if (x < 0 || y < 0 || x >= width || y >= height) return;

        Tile neighbor = grid[x, y];
        if (neighbor != null && !t.neighbors.Contains(neighbor))
            t.neighbors.Add(neighbor);
    }

    private void BuildLinkedList()
    {
        if (allTiles.Count == 0) return;

        head = allTiles[0];
        tail = allTiles[allTiles.Count - 1];

        for (int i = 0; i < allTiles.Count; i++)
        {
            Tile current = allTiles[i];
            Tile next = (i < allTiles.Count - 1) ? allTiles[i + 1] : null;
            Tile prev = (i > 0) ? allTiles[i - 1] : null;

            current.next = next;
            current.prev = prev;
        }

        if (loopLinkedList)
        {
            head.prev = tail;
            tail.next = head;
        }
    }
}
