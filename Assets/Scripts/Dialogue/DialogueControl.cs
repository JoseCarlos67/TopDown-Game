using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
	[System.Serializable]
	public enum Idiom
	{
		pr_br,
		eng,
		spa
	}
	
	public Idiom idiom;

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
	private string[] _names;
	private Sprite[] _sprites;
	
	public static DialogueControl instance;

    public bool IsShowing { get => _isShowing; set => _isShowing = value; }

    private void Awake()
	{
		instance = this;
	}
	
	IEnumerator TypeSentence()
	{
		foreach(char letter in _sentences[_index].ToCharArray())
		{
			speechText.text += letter;
			actorNameText.text = _names[_index];
			actorSprite.sprite = _sprites[_index];
			yield return new WaitForSeconds(typingSpeed);
		}
	}
	
	public void Speech(string[] text, string[] actorName, Sprite[] actorSprite)
	{
		if(!IsShowing)
		{
			dialogueObj.SetActive(true);
			_sentences = text;
			_names = actorName;
			_sprites = actorSprite;
			StartCoroutine(TypeSentence());
			IsShowing = true;
		}
	}
	
	public void NextSentence()
	{
		if(speechText.text == _sentences[_index])
		{
			if(_index < _sentences.Length - 1)
			{
				_index++;
				speechText.text = "";
				StartCoroutine(TypeSentence());
			} else
			{
				speechText.text = "";
				_index = 0;
				dialogueObj.SetActive(false);
				_sentences = null;
				IsShowing = false;
			}
		}
	}
}
