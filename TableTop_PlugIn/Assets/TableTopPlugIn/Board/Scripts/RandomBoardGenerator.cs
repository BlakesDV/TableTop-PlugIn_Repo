using UnityEngine;

public class RandomBoardGenerator : MonoBehaviour
{
    [SerializeField] private int width = 5;
    [SerializeField] private int height = 5;
    [SerializeField] private float tileSize = 1f;

    [SerializeField] private GameObject[] tilePrefabs;

    [SerializeField] private Transform boardParent;

    private GameObject[,] boardTiles;

    void Start()
    {
       // GenerateBoard();
    }

    public void GenerateBoard()
    {
        if (tilePrefabs == null || tilePrefabs.Length == 0)
        {
            Debug.LogWarning("No hay prefabs asignados para las fichas del tablero.");
            return;
        }

        boardTiles = new GameObject[width, height];

        Vector3 startPos = transform.position - new Vector3((width - 1) * tileSize / 2f, 0, (height - 1) * tileSize / 2f);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject prefab = tilePrefabs[Random.Range(0, tilePrefabs.Length)];

                Vector3 pos = startPos + new Vector3(x * tileSize, 0f, y * tileSize);

                GameObject tile = Instantiate(prefab, pos, Quaternion.identity, boardParent ? boardParent : transform);
                tile.name = $"Tile_{x}_{y}";

                boardTiles[x, y] = tile;
            }
        }

        Debug.Log(" Tablero generado: {width}x{height} fichas.");
    }

    public void ClearBoard()
    {
        if (boardTiles == null) return;

        foreach (GameObject tile in boardTiles)
        {
            if (tile != null)
                Destroy(tile);
        }

        Transform parent = boardParent != null ? boardParent : transform;
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.GetChild(i).gameObject);
        }

        boardTiles = null;

        Debug.Log(" Tablero eliminado correctamente en modo Play.");
    }

    public GameObject GetTileAt(int x, int y)
    {
        if (boardTiles == null) return null;
        if (x < 0 || y < 0 || x >= width || y >= height) return null;
        return boardTiles[x, y];
    }
    public Vector3 GetTilePosition(int x, int y)
    {
        GameObject tile = GetTileAt(x, y);
        return tile != null ? tile.transform.position : Vector3.zero;
    }
}
