using UnityEngine;
using UnityEngine.Events;

public class RayCastBasedSelector : MonoBehaviour, ISelector
{
	private IInstanceSelectionRespone _currentSelection;

	public void Check(Ray2D ray)
	{
		RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
		if (hit.collider != null)
		{
			IInstanceSelectionRespone newSelection = hit.transform.GetComponent<IInstanceSelectionRespone>();
			if (newSelection != null)
			{
				if (_currentSelection == null)
				{
					_currentSelection = newSelection;
					_currentSelection.AddListenerToOnSelectionDestroy(OnSelectionDestroy);
					_currentSelection.Select();
					onInstanceClick.Invoke(_currentSelection);
				}
				else if (newSelection == _currentSelection)
				{
					_currentSelection.RemoveListenerFromOnSelectionDestroy(OnSelectionDestroy);
					_currentSelection.Deselect();
					_currentSelection = null;
					onInstanceClick.Invoke(null);
				}
				else
				{
					_currentSelection.RemoveListenerFromOnSelectionDestroy(OnSelectionDestroy);
					_currentSelection.Deselect();
					_currentSelection = newSelection;
					_currentSelection.AddListenerToOnSelectionDestroy(OnSelectionDestroy);
					_currentSelection.Select();
					onInstanceClick.Invoke(_currentSelection);
				}
			}
		}
	}

	public void OnSelectionDestroy() => _currentSelection = null;

	public UnityEvent<IInstanceSelectionRespone> onInstanceClick;
}
