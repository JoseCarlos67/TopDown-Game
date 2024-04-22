using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	public float speed;
	private int _index;
	private float _initialSpeed;
	public List<Transform> paths = new();
	
	private Animator _animator;
	
	void Start()
	{
		_initialSpeed = speed;
		_animator = GetComponent<Animator>();
	}

	void Update()
	{
		if(DialogueControl.instance.IsShowing)
		{
			speed = 0f;
			_animator.SetBool("isWalking", false);
		} else 
		{
			speed = _initialSpeed;
			_animator.SetBool("isWalking", true);
		}
	
		transform.position = Vector2.MoveTowards(transform.position, paths[_index].position, speed * Time.deltaTime);
		
		if(Vector2.Distance(transform.position, paths[_index].position) < 0.1f)
		{
			if(_index < paths.Count - 1)
			{
				//_index++;
				_index = Random.Range(0, paths.Count);
			} else 
			{
				_index = 0;
			}
		}
		
		Vector2 direction = paths[_index].position - transform.position;
		
		if(direction.x > 0)
		{
			transform.eulerAngles = new Vector2(0, 0);
		}
		
		if(direction.x < 0)
		{
			transform.eulerAngles = new Vector2(0, 180);
		}
	}
}
