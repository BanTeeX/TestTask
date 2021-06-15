using UnityEngine;

public class RectangleBoard : MonoBehaviour, IBoard
{
	[SerializeField] private GameObject _bordersPrefab;
	[SerializeField] private int _boardWidth;
	[SerializeField] private int _boardHeight;

	public int BoardWidth { get => _boardWidth; private set => _boardWidth = value; }
	public int BoardHeight { get => _boardHeight; private set => _boardHeight = value; }

	public GameObject InstantiateBoard()
	{
		GameObject board = Instantiate(_bordersPrefab);
		board.transform.localScale = new Vector3(BoardWidth, BoardHeight, 1.0f);
		return board;
	}
}
