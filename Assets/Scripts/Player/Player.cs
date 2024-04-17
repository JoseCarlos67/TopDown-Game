using System.Security;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _runSpeed;
	[SerializeField] private float _initialSpeed;
	
	private Rigidbody2D _rigidbody2D;
	
	private Vector2 _direction;
	private bool _isRunning;
	private bool _isRolling;
	
	public Vector2 direction { get => _direction; set => _direction = value; }
	public bool isRunning { get => _isRunning; set => _isRunning = value; }
	public bool IsRolling { get => _isRolling; set => _isRolling = value; }

	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_initialSpeed = _speed;
	}
	
	private void Update()
	{
		OnInput();
		OnRun();
		OnRoll();
	}
	
	private void FixedUpdate()
	{
		OnMove();
	}
	
	#region Movement
		void OnInput()
		{
			_direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		}
		
		void OnMove(){
			_rigidbody2D.MovePosition(_rigidbody2D.position + _speed * Time.fixedDeltaTime * _direction);
		}
		
		void OnRun()
		{
			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				_speed = _runSpeed;
				_isRunning = true;
			}
			if(Input.GetKeyUp(KeyCode.LeftShift))
			{
				_speed = _initialSpeed;
				_isRunning = false;
			}
		}
		
		void OnRoll()
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				_isRolling = true;
			} else 
			{
				_isRolling = false;
			}
			
		}
		
	#endregion
}