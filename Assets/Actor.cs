using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Actor : MonoBehaviour
{
	public UnityEvent onDestroy;

	[SerializeField]
	private float _speed;
	[SerializeField]
	private int _life;
	private Vector2 _direction;
	private Rigidbody2D _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_direction = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward) * Vector2.up;
		_rigidbody.velocity = _direction * _speed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		_direction = Vector2.Reflect(_direction, collision.GetContact(0).normal);
		_rigidbody.velocity = _direction * _speed;
		if (collision.collider.CompareTag("Actor"))
		{
			_life--;
		}
		if (_life <= 0)
		{
			onDestroy.Invoke();
			Destroy(gameObject);
		}
	}
}
