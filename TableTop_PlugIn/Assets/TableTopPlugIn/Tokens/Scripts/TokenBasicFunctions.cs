using UnityEngine;
using System.Collections;

public class TokenBasicFunctions : MonoBehaviour
{
    [Header("References")]
    public BoardGraph boardGraph;
    public float heightOffset = 0.5f;
    public float moveSpeed = 5f;

    [HideInInspector] public Tile currentTile;
    private bool isMoving = false;

    void Start()
    {
        // Inicializar en el head del BoardGraph si existe
        if (boardGraph != null && boardGraph.head != null)
        {
            SnapToTile(boardGraph.head);
        }
    }

    public void SnapToTile(Tile tile)
    {
        if (tile == null)
        {
            Debug.LogError("No se puede asignar null a currentTile.");
            return;
        }

        currentTile = tile;
        transform.position = tile.transform.position + Vector3.up * heightOffset;
    }

    #region Movimiento por índice (lista ligada)
    public void MoveStepsByIndex(int steps)
    {
        if (currentTile == null)
        {
            Debug.LogError("Token no tiene currentTile asignado. No puede moverse.");
            return;
        }

        if (!isMoving)
            StartCoroutine(MoveStepsByIndexCoroutine(steps));
    }

    private IEnumerator MoveStepsByIndexCoroutine(int steps)
    {
        isMoving = true;

        for (int i = 0; i < steps; i++)
        {
            if (currentTile.next == null)
            {
                Debug.Log("Token alcanzó el final del tablero.");
                break;
            }

            Tile nextTile = currentTile.next;
            yield return MoveToTile(nextTile);
            currentTile = nextTile;
        }

        isMoving = false;
    }

    private IEnumerator MoveToTile(Tile tile)
    {
        Vector3 start = transform.position;
        Vector3 end = tile.transform.position + Vector3.up * heightOffset;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
    }
    #endregion
}
