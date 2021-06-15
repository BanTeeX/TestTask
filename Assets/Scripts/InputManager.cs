using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
	public UnityEvent onMouseLeftClick;

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			onMouseLeftClick.Invoke();
		}
	}
}
