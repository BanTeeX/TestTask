using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IPointOnBoardProvider))]
[RequireComponent(typeof(ISpawner<Actor>))]
public class ActorSpawnIntervalSystem : MonoBehaviour, ISpawnSystem
{
	[SerializeField] private float _minSpawnTime;
	[SerializeField] private float _maxSpawnTime;
	[SerializeField] private int _maxAmountOfInstances;
	private IPointOnBoardProvider _pointProvider;
	private ISpawner<Actor> _spawner;
	private int _currentAmountOfInstances = 0;

	public void StartSpawning()
	{
		StartCoroutine(SpawnCoroutine());
	}

	private void Awake()
	{
		_pointProvider = GetComponent<IPointOnBoardProvider>();
		_spawner = GetComponent<ISpawner<Actor>>();
	}

	private IEnumerator SpawnCoroutine()
	{
		while (true)
		{
			if (_currentAmountOfInstances < _maxAmountOfInstances)
			{
				Actor actor = _spawner.SpawnInstance(_pointProvider.GetPoint());
				actor.onDeath.AddListener(OnInstanceDestroy);
				_currentAmountOfInstances++;
			}
			yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
		}
	}

	private void OnInstanceDestroy(Actor instance)
	{
		_currentAmountOfInstances--;
	}
}
