using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
	[Header("Settings")]
	public float dialogueRange;
	public LayerMask playerLayer;
	
	public DialogueSettings dialogueSettings;
	
	private bool _playerHit;
	private List<string> _sentences = new();
	private List<string> _actorName = new();
	private List<Sprite> _actorSprite = new();
	
	void Start()
	{
		GetDialogueData();
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.E) && _playerHit)
		{
			DialogueControl.instance.Speech(_sentences.ToArray(), _actorName.ToArray(), _actorSprite.ToArray());
		}
	}

	void FixedUpdate()
	{
		ShowDialogue();
	}
	
	void GetDialogueData()
	{
		for(int i = 0; i < dialogueSettings.dialogue.Count; i++)	
		{
			_actorName.Add(dialogueSettings.dialogue[i].actorName);
			_actorSprite.Add(dialogueSettings.dialogue[i].actorSprite);
			

			switch(DialogueControl.instance.idiom)
			{
				case DialogueControl.Idiom.pr_br:
					_sentences.Add(dialogueSettings.dialogue[i].sentence.portuguese);
					break;
					
				case DialogueControl.Idiom.eng:
					_sentences.Add(dialogueSettings.dialogue[i].sentence.english);
					break;
					
				case DialogueControl.Idiom.spa:
					_sentences.Add(dialogueSettings.dialogue[i].sentence.spanish);
					break;
			}
		}
	}

	public void ShowDialogue()
	{
		Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
		
		if(hit != null)
		{
			_playerHit = true;
		} else 
		{
			_playerHit = false;
		}
	}
	
	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, dialogueRange);
	}

}
