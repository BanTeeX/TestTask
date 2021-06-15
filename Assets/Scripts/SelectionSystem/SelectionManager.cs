using UnityEngine;

[RequireComponent(typeof(ISelector))]
[RequireComponent(typeof(IRayProvider))]
public class SelectionManager : MonoBehaviour
{
    private ISelector _selector;
    private IRayProvider _rayProvider;

    public void Select() => _selector.Check(_rayProvider.CreateRay());

	private void Awake()
	{
		_selector = GetComponent<ISelector>();
		_rayProvider = GetComponent<IRayProvider>();
	}
}
