using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Actor : MonoBehaviour
{
	[HideInInspector]
	public UnityEvent onDestroy;
	[HideInInspector]
	public UnityEvent<Actor> onClick;
	public int life;
	public string actorName;

	[SerializeField]
	private float _speed;
	private Vector2 _direction;
	private Rigidbody2D _rigidbody;
	private SpriteRenderer _spriteRenderer;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_direction = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), Vector3.forward) * Vector2.up;
		_rigidbody.velocity = _direction * _speed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		_direction = Vector2.Reflect(_direction, collision.GetContact(0).normal);
		_rigidbody.velocity = _direction * _speed;
		if (collision.collider.CompareTag("Actor"))
		{
			life--;
		}
		if (life <= 0)
		{
			onDestroy.Invoke();
			Destroy(gameObject);
		}
	}

	private void OnMouseDown()
	{
		onClick.Invoke(this);
	}

	public void Select()
	{
		_spriteRenderer.color = Color.black;
	}

	public void Unselect()
	{
		_spriteRenderer.color = Color.white;
	}
}
