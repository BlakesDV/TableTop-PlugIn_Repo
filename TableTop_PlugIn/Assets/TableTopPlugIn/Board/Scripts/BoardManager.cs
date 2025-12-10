using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public BoardGenerator boardGenerator;
    public BoardGraph boardGraph;

    public void CreateRandomBoard()
    {
        boardGenerator.GenerateRandomBoard();
        boardGraph.BuildGraph(
            boardGenerator.TileGrid,
            boardGenerator.width,
            boardGenerator.height
        );
    }

    public void CreateLoopBoard()
    {
        boardGenerator.GenerateLoopBoard();
        boardGraph.BuildGraph(
            boardGenerator.TileGrid,
            boardGenerator.width,
            boardGenerator.height
        );
    }

    public void CreateOrderedBoard()
    {
        boardGenerator.GenerateOrderedBoard();
        boardGraph.BuildGraph(
            boardGenerator.TileGrid,
            boardGenerator.width,
            boardGenerator.height
        );
    }

    public void ClearBoard()
    {
        boardGenerator.ClearBoard();
        boardGraph.allTiles.Clear();
        boardGraph.head = null;
        boardGraph.tail = null;
    }
}
