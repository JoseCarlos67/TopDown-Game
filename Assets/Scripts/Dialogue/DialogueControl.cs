using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
	[Header("Components")]
	public GameObject dialogueObj;
	public Image actorSprite;
	public Text speechText;
	public Text actorNameText;
	
	[Header("Settings")]
	public float typingSpeed;
	
	// Variaveis de controle
	private bool _isShowing;
	private int _index;
	private string[] _sentences;

	void Start()
	{
		
	}

	void Update()
	{
		
	}
	
	IEnumerator TypeSentence()
	{
		foreach(char letter in _sentences[_index].ToCharArray())
		{
			speechText.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
	}
	
	public void Speech(string[] text)
	{
		if(!_isShowing)
		{
			dialogueObj.SetActive(true);
			_sentences = text;
			StartCoroutine(TypeSentence());
			_isShowing = true;
		}
	}
}
