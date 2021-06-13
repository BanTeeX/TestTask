using TMPro;
using UnityEngine;

public class ActorInfoUI : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _actorNameText;
	[SerializeField]
	private TMP_Text _actorLifeText;
	private Actor _currentActor = null;

	public void AddSelfToClickEvent(Actor actor) => actor.onClick.AddListener(ActorSelection);

	private void ActorSelection(Actor actor)
	{
		if (_currentActor == actor)
		{
			UnselectActor();
		}
		else
		{
			if (_currentActor != null)
			{
				UnselectActor();
			}
			SelectActor(actor);
		}
		PrintActorInformation();
	}

	private void SelectActor(Actor actor)
	{
		_currentActor = actor;
		_currentActor.Select();
		_currentActor.onValueChange.AddListener(PrintActorInformation);
		_currentActor.onDestroy.AddListener(OnDestroyCurrentActor);
	}

	private void UnselectActor()
	{
		_currentActor.Unselect();
		_currentActor.onValueChange.RemoveListener(PrintActorInformation);
		_currentActor.onDestroy.RemoveListener(OnDestroyCurrentActor);
		_currentActor = null;
	}

	private void PrintActorInformation()
	{
		if (_currentActor == null)
		{
			_actorNameText.text = "n/d";
			_actorLifeText.text = "n/d";
		}
		else
		{
			_actorNameText.text = _currentActor.actorName;
			_actorLifeText.text = _currentActor.life.ToString();
		}
	}

	private void OnDestroyCurrentActor()
	{
		UnselectActor();
		PrintActorInformation();
	}
}
