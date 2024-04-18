using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
	[Header("Settings")]
	public float dialogueRange;
	public LayerMask playerLayer;

	void Start()
	{
		
	}

	void FixedUpdate()
	{
		ShowDialogue();
	}

	public void ShowDialogue()
	{
		Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
		
		if(hit != null)
		{
			Debug.Log("Player na are de colisao");
		} else 
		{
			
		}
	}
	
	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, dialogueRange);
	}

}
