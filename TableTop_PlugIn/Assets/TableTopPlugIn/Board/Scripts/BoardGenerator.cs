using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [Header("Board Size")]
    public int width = 5;
    public int height = 5;
    public float tileSize = 1f;

    [Header("Prefabs")]
    public GameObject[] randomTilePrefabs;
    public GameObject[] loopTilePrefabs;
    public GameObject[] orderedTilePrefabs;
    public GameObject[,] boardTiles;

    public Transform boardParent;

    public Tile[,] TileGrid { get; private set; }
    public BoardGraph boardGraph;

    public void GenerateRandomBoard()
    {
        ClearBoard();

        TileGrid = new Tile[width, height];

        Vector3 startPos = transform.position -
            new Vector3((width - 1) * tileSize / 2f, 0, (height - 1) * tileSize / 2f);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject prefab = randomTilePrefabs[Random.Range(0, randomTilePrefabs.Length)];
                Vector3 pos = startPos + new Vector3(x * tileSize, 0, y * tileSize);

                GameObject obj = Instantiate(prefab, pos, Quaternion.identity, boardParent);
                obj.name = $"Tile_{x}_{y}";

                TileGrid[x, y] = obj.GetComponent<Tile>();
            }
        }
    }

    public void GenerateLoopBoard()
    {
        ClearBoard();
        TileGrid = new Tile[width, height];

        Vector3 startPos = transform.position -
            new Vector3((width - 1) * tileSize / 2f, 0, (height - 1) * tileSize / 2f);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                bool isBorder = x == 0 || y == 0 || x == width - 1 || y == height - 1;

                if (!isBorder)
                    continue;

                GameObject prefab = loopTilePrefabs[Random.Range(0, loopTilePrefabs.Length)];
                Vector3 pos = startPos + new Vector3(x * tileSize, 0, y * tileSize);

                GameObject obj = Instantiate(prefab, pos, Quaternion.identity, boardParent);
                obj.name = $"Tile_{x}_{y}";

                TileGrid[x, y] = obj.GetComponent<Tile>();
            }
        }
    }

    public void GenerateOrderedBoard()
    {
        ClearBoard();
        TileGrid = new Tile[width, height];

        Vector3 startPos = transform.position -
            new Vector3((width - 1) * tileSize / 2f, 0, (height - 1) * tileSize / 2f);

        int index = 0;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (index >= orderedTilePrefabs.Length) index = 0;

                GameObject prefab = orderedTilePrefabs[index++];
                Vector3 pos = startPos + new Vector3(x * tileSize, 0, y * tileSize);

                GameObject obj = Instantiate(prefab, pos, Quaternion.identity, boardParent);
                obj.name = $"Tile_{x}_{y}";

                TileGrid[x, y] = obj.GetComponent<Tile>();
            }
        }
    }

    public void ClearBoard()
    {
        if (boardParent == null) boardParent = transform;

        for (int i = boardParent.childCount - 1; i >= 0; i--)
            Object.DestroyImmediate(boardParent.GetChild(i).gameObject);

        TileGrid = null;
    }
    public GameObject GetTileAt(int x, int y) 
    { 
        if (boardTiles == null) 
            return null; 
        if (x < 0 || y < 0 || x >= width || y >= height) 
            return null; 
        return boardTiles[x, y]; 
    }
    public Vector3 GetTilePosition(int x, int y) 
    { 
        GameObject tile = GetTileAt(x, y); 
        return tile != null ? tile.transform.position : Vector3.zero; 
    }
    public Tile GetTileAtIndex(int index)
    {
        if (boardGraph == null || boardGraph.allTiles.Count == 0)
            return null;

        if (index < 0 || index >= boardGraph.allTiles.Count)
            return null;

        return boardGraph.allTiles[index];
    }
    public Vector3 GetTilePosition(int index)
    {
        Tile tile = GetTileAtIndex(index);
        return tile != null ? tile.transform.position : Vector3.zero;
    }
}
