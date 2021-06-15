using UnityEngine.Events;

public interface IInstanceSelectionRespone
{
	void RemoveListenerFromOnSelectionDestroy(UnityAction action);
	void AddListenerToOnSelectionDestroy(UnityAction action);
	void Deselect();
	void Select();
}
