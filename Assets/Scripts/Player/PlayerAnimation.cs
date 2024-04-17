using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	private Player _player;
	private Animator _animator;
	
	private void Start()
	{
		_player = GetComponent<Player>();
		_animator = GetComponent<Animator>();
	}
	
	private void Update()
	{
		OnMove();
		OnRun();
	}
	
	#region Movement
		void OnMove()
		{
			if(_player.direction.sqrMagnitude > 0)
			{
				if(_player.IsRolling)
				{
					_animator.SetTrigger("isRoll");
				} else 
				{
					_animator.SetInteger("transition", 1);
				}
				
			} else 
			{
				_animator.SetInteger("transition", 0);
			}
			
			if(_player.direction.x > 0)
			{
				transform.eulerAngles = new Vector2(0, 0);
			}
			
			if(_player.direction.x < 0)
			{
				transform.eulerAngles = new Vector2(0, 180);
			}
		}
		
		void OnRun()
		{
			if(_player.isRunning)
			{
				_animator.SetInteger("transition", 2);
			}
		}
	#endregion
	
}
