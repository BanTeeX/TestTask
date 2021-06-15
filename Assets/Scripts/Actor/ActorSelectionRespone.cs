using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class ActorSelectionRespone : MonoBehaviour, IInstanceSelectionRespone
{
	[SerializeField] private Color _baseColor;
	[SerializeField] private Color _selectionColor;
	private SpriteRenderer _spriteRenderer;
	private UnityEvent _onSelectionDestroy = new UnityEvent();

	public void Select() => _spriteRenderer.color = _selectionColor;

	public void Deselect() => _spriteRenderer.color = _baseColor;

	private void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();

	private void OnDestroy() => _onSelectionDestroy.Invoke();

	public void AddListenerToOnSelectionDestroy(UnityAction action) => _onSelectionDestroy.AddListener(action);

	public void RemoveListenerFromOnSelectionDestroy(UnityAction action) => _onSelectionDestroy.RemoveListener(action);
}
