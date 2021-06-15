using TMPro;
using UnityEngine;

public class ActorInfoUI : MonoBehaviour, IInstanceInfoUI<Actor>
{
	[SerializeField] private TMP_Text _actorNameText;
	[SerializeField] private TMP_Text _actorLifeText;
	private Actor _instance;

	public void CheckIfActorClicked(IInstanceSelectionRespone selectionRespone)
	{
		if (selectionRespone == null)
		{
			PrintInstanceInformation(null);
		}
		else if (selectionRespone is ActorSelectionRespone)
		{
			_instance = (selectionRespone as ActorSelectionRespone).GetComponent<Actor>();
			_instance.onValueChange.AddListener(PrintInstanceInformation);
			PrintInstanceInformation(_instance);
		}
	}

	public void PrintInstanceInformation(Actor instance)
	{
		if (instance == null)
		{
			_actorNameText.text = "n/d";
			_actorLifeText.text = "n/d";
		}
		else
		{
			_actorNameText.text = instance.actorName;
			_actorLifeText.text = instance.life.ToString();
		}
	}
}
