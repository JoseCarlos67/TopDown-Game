using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
	[SerializeField] private SpriteRenderer _spriteRenderer;
	[SerializeField] private Sprite _hole;
	[SerializeField] private Sprite _carrote;
	[SerializeField] private int _digAmount;
	
	private int _initialDigAmout;
	
	private void Start()
	{
		_initialDigAmout = _digAmount;
	}
	
	public void OnHit()
	{
		_digAmount--;
		
		if(_digAmount <= _initialDigAmout / 2)
		{
			_spriteRenderer.sprite = _hole;
		}
	}
	
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Dig"))
		{
			OnHit();
		}
	}
}
