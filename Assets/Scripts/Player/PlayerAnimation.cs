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
		OnCutting();
	}
	
	#region Movement
		void OnMove()
		{
			if(_player.Direction.sqrMagnitude > 0)
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
			
			if(_player.Direction.x > 0)
			{
				transform.eulerAngles = new Vector2(0, 0);
			}
			
			if(_player.Direction.x < 0)
			{
				transform.eulerAngles = new Vector2(0, 180);
			}
		}
		
		void OnRun()
		{
			if(_player.IsRunning)
			{
				_animator.SetInteger("transition", 2);
			}
		}
	#endregion
	
	#region Actions
		void OnCutting()
		{
			if(_player.IsCutting)
			{
				_animator.SetInteger("transition", 3);
			}
		}
	
	#endregion

}
