using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(IInstanceSelectionRespone))]
public class Actor : MonoBehaviour
{
	public int life;
	[HideInInspector] public string actorName;

	[SerializeField] private float _speed;
	private Vector2 _direction;
	private Rigidbody2D _rigidbody;
	private IInstanceSelectionRespone _selectRespone;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_selectRespone = GetComponent<IInstanceSelectionRespone>();
		_direction = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward) * Vector2.up;
		_rigidbody.velocity = _direction * _speed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		_direction = Vector2.Reflect(_direction, collision.GetContact(0).normal);
		_rigidbody.velocity = _direction * _speed;

		if (collision.collider.GetComponent<Actor>() != null)
		{
			life--;
			onValueChange.Invoke(this);
		}

		if (life <= 0) Destroy(gameObject);
	}

	private void OnDestroy()
	{
		onDeath.Invoke(this);
		onValueChange.Invoke(null);
	}

	[HideInInspector] public UnityEvent<Actor> onDeath;
	[HideInInspector] public UnityEvent<Actor> onValueChange;
}
