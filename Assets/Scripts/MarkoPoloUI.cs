using System.Collections;
using TMPro;
using UnityEngine;

public class MarkoPoloUI : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _numbersText;
	[SerializeField]
	private TMP_Text _markoPoloText;

	public void StartNumbersCoroutine()
	{
		StopAllCoroutines();
		StartCoroutine(IncrementNumbers());
	}

	private IEnumerator IncrementNumbers()
	{
		for (int i = 1; i <= 100; i++)
		{
			_numbersText.text = i.ToString();
			_markoPoloText.text = "";
			if (i % 3 == 0)
			{
				_markoPoloText.text += "Marko";
			}
			if (i % 5 == 0)
			{
				_markoPoloText.text += "Polo";
			}
			yield return new WaitForSecondsRealtime(0.25f);
		}
	}
}
