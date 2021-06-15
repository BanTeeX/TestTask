using UnityEngine;

public interface ISelector
{
	void Check(Ray2D ray);
	void OnSelectionDestroy();
}
