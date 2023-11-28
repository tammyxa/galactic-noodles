using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayableObject;
using static PlayerInput;

public class DialogueTrigger : PlayableObject, IInteractable {

	public Dialogue dialogue;

	private DialogueManager dManager;

	DialogueTrigger()
	{
		this.OnInteract = _interact;
	}

	public void Interact ()
	{
		dManager = FindObjectOfType<DialogueManager>();
		dManager.StartDialogue(dialogue);
	}

	void _interact(PlayerInput player)
	{
		if (player.interacting != null) return;
		dManager.DisplayNextSentence();
	}

}