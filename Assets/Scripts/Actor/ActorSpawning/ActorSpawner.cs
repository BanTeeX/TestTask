using UnityEngine;

public class ActorSpawner : MonoBehaviour, ISpawner<Actor>
{
	[SerializeField] private Actor _instancePrefab;
	private int _amountOfCreatedInstances = 0;

	public Actor SpawnInstance(Vector3 position)
	{
		Actor createdInstance = Instantiate(_instancePrefab, position, Quaternion.identity);
		_amountOfCreatedInstances++;
		createdInstance.actorName = "Actor " + _amountOfCreatedInstances;
		return createdInstance;
	}
}
