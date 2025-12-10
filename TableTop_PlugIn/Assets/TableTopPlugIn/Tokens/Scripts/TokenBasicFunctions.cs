using UnityEngine;
using System.Collections;

public class TokenBasicFunctions : MonoBehaviour
{
    public BoardGenerator boardGenerator;
    public int posX = 0;
    public int posY = 0;
    public float heightOffset = 0.5f;
    public float moveSpeed = 5f;
    public Vector2Int gridPosition;

    private bool isMoving = false;

    void Start()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        GameObject tile = boardGenerator.GetTileAt(posX, posY);
        if (tile != null)
            transform.position = tile.transform.position + Vector3.up * heightOffset;
    }

    public void MoveSteps(int steps, Vector2 direction)
    {
        if (!isMoving)
            StartCoroutine(MoveCoroutine(steps, direction));
    }

    private IEnumerator MoveCoroutine(int steps, Vector2 direction)
    {
        isMoving = true;

        for (int i = 0; i < steps; i++)
        {
            int targetX = posX + (int)direction.x;
            int targetY = posY + (int)direction.y;

            GameObject tile = boardGenerator.GetTileAt(targetX, targetY);

            if (tile == null)
            {
                Debug.Log("No se puede avanzar más en esa dirección.");
                break;
            }

            Vector3 startPos = transform.position;
            Vector3 endPos = tile.transform.position + Vector3.up * heightOffset;
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime * moveSpeed;
                transform.position = Vector3.Lerp(startPos, endPos, t);
                yield return null;
            }

            posX = targetX;
            posY = targetY;
        }

        isMoving = false;
    }
}
