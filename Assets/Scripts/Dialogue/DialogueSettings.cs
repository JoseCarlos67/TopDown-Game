using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue")]
public class DialogueSettings : ScriptableObject
{
	[Header("Settings")]
	public GameObject actor;
	
	[Header("Dialogue")]
	public string actorName;
	public Sprite actorSprite;
	public string sentence;
	
	public List<Sentences> dialogue = new();
}

[System.Serializable]
public class Sentences
{
	public string actorName;
	public Sprite actorSprite;
	public Languages sentence;
}

[System.Serializable]
public class Languages
{
	public string portuguese;
	public string english;
	public string spanish;
}

#if UNITY_EDITOR
	[CustomEditor(typeof(DialogueSettings))]
	public class BuilderEditor : Editor
	{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		DialogueSettings dialogueSetting = (DialogueSettings)target;
		Languages language = new();
		language.portuguese = dialogueSetting.sentence;
		
		Sentences sentence = new();
		sentence.actorName = dialogueSetting.actorName;
		sentence.actorSprite = dialogueSetting.actorSprite;
		sentence.sentence = language;
		
		if(GUILayout.Button("Create dialogue"))
		{
			if(dialogueSetting.sentence != "")
			{
				dialogueSetting.dialogue.Add(sentence);
				
				dialogueSetting.actorName = "";
				dialogueSetting.actorSprite = null;
				dialogueSetting.sentence = "";
			}
		}
	}
}
#endif
