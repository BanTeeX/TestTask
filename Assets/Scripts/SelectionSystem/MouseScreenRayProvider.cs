using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
{
	public Ray2D CreateRay()
	{
		Vector3 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 origin2D = new Vector2(origin.x, origin.y);
		return new Ray2D(origin2D, Vector2.zero);
	}
}
