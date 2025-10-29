using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    #region References
    [SerializeField] private RandomBoardGenerator boardGenerator;
    [SerializeField] private Button createButton;
    [SerializeField] private Button clearButton;
    #endregion

    void Start()
    {
        if (createButton != null)
            createButton.onClick.AddListener(OnGenerateBoard);

        if (clearButton != null)
            clearButton.onClick.AddListener(OnClearBoard);
    }

    public void OnGenerateBoard()
    {
        if (boardGenerator != null)
        {
            boardGenerator.GenerateBoard();
            Debug.Log("Tablero generado desde BoardManager");
        }
        else
        {
            Debug.LogWarning("No hay ProceduralBoardGenerator asignado al BoardManager.");
        }
    }

    public void OnClearBoard()
    {
        boardGenerator.ClearBoard();
    }
}
