using UnityEngine;

[RequireComponent(typeof(RectangleBoard))]
public class RandomPointProviderForRectBoard : MonoBehaviour, IPointOnBoardProvider
{
	private RectangleBoard _board;

	private void Awake()
	{
		_board = GetComponent<RectangleBoard>();
	}

	public Vector3 GetPoint()
	{
		float _x = (float)_board.BoardWidth / 2;
		float _y = (float)_board.BoardHeight / 2;
		return new Vector3(Random.Range(-_x, _x), Random.Range(-_y, _y), 0);
	}
}
