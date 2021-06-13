using TMPro;
using UnityEngine;

public class ActorInfoUI : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _actorNameText;
	[SerializeField]
	private TMP_Text _actorLifeText;
	private Actor _currentActor = null;

	public void AddSelfToClickEvent(Actor actor) => actor.onClick.AddListener(PrintActorInformation);

	private void PrintActorInformation(Actor actor)
	{
		if (_currentActor == actor)
		{
			_currentActor.Unselect();
			_currentActor = null;
			_actorNameText.text = "n/d";
			_actorLifeText.text = "n/d";
		}
		else
		{
			if (_currentActor != null)
			{
				_currentActor.Unselect();
			}
			_currentActor = actor;
			_currentActor.Select();
			_actorNameText.text = _currentActor.actorName;
			_actorLifeText.text = _currentActor.life.ToString();
		}
	}
}
