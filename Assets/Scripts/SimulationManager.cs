using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SimulationManager : MonoBehaviour
{
	public UnityEvent<Actor> onInstanceCreate;

	[SerializeField]
	private int _boardWidth;
	[SerializeField]
	private int _boardHeight;
	[SerializeField]
	[Range(2.0f, 10.0f)]
	private float _spawnTime;
	[SerializeField]
	private int _maxAmountOfInstances;
	[SerializeField]
	private GameObject _instancePrefab;
	[SerializeField]
	private GameObject _boardPrefab;
	private int _currentAmountOfInstances;
	private int _amountOfCreatedInstances = 0;
	private float _xLeftSpawnRange;
	private float _xRightSpawnRange;
	private float _yUpSpawnRange;
	private float _yDownSpawnRange;

	private void Awake()
	{
		Instantiate(_boardPrefab).transform.localScale = new Vector3(_boardWidth, _boardHeight, 1.0f);
		_xLeftSpawnRange = (float)_boardWidth / -2 + _instancePrefab.transform.localScale.x;
		_xRightSpawnRange = (float)_boardWidth / 2 - _instancePrefab.transform.localScale.x;
		_yUpSpawnRange = (float)_boardHeight / 2 - _instancePrefab.transform.localScale.y;
		_yDownSpawnRange = (float)_boardHeight / -2 + _instancePrefab.transform.localScale.y;
		StartCoroutine(SpawnCoroutine());
	}

	private void SpawnInstance()
	{
		if (_currentAmountOfInstances >= _maxAmountOfInstances)
		{
			return;
		}
		Vector2 spawnPosition = new Vector2(Random.Range(_xLeftSpawnRange, _xRightSpawnRange), Random.Range(_yDownSpawnRange, _yUpSpawnRange));
		_amountOfCreatedInstances++;
		Actor createdActor = Instantiate(_instancePrefab, spawnPosition, Quaternion.identity).GetComponent<Actor>();
		createdActor.actorName = "Actor " + _amountOfCreatedInstances;
		createdActor.onDestroy.AddListener(OnInstanceDestroy);
		_currentAmountOfInstances++;
		onInstanceCreate.Invoke(createdActor);
	}

	private IEnumerator SpawnCoroutine()
	{
		while (true)
		{
			SpawnInstance();
			yield return new WaitForSeconds(_spawnTime);
		}
	}

	private void OnInstanceDestroy()
	{
		_currentAmountOfInstances--;
	}
}
