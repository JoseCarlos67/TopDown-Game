using UnityEngine;

public class Water : MonoBehaviour
{
	[SerializeField] private bool _detectingPlayer;
	private PlayerItems _playerItems;

	void Start()
	{
		_playerItems = FindObjectOfType<PlayerItems>();
	}

	void Update()
	{
		if(_detectingPlayer && Input.GetKeyDown(KeyCode.E))
		{
			_playerItems.WaterLimit(10); // Quantidade de agua
		}
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			_detectingPlayer = true;
		}
	}
	
	private void OntriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			_detectingPlayer = false;
		}
	}
	
}
