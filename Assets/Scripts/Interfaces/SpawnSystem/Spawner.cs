using UnityEngine;

public interface ISpawner<T>
{
	T SpawnInstance(Vector3 position);
}
