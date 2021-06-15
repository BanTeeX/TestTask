using UnityEngine;

[RequireComponent(typeof(IBoard))]
[RequireComponent(typeof(ISpawnSystem))]
public class SimulationManager : MonoBehaviour
{
	private IBoard _board;
	private ISpawnSystem _spawnSystem;

	private void Awake()
	{
		_board = GetComponent<IBoard>();
		_spawnSystem = GetComponent<ISpawnSystem>();
	}

	private void Start()
	{
		_board.InstantiateBoard();
		_spawnSystem.StartSpawning();
	}
}
