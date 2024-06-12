using System.Security;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _runSpeed;
	[SerializeField] private float _initialSpeed;
	
	private Rigidbody2D _rigidbody2D;
	private PlayerItems _playerItems;
	
	private Vector2 _direction;
	private bool _isRunning;
	private bool _isRolling;
	private bool _isCutting;
	private bool _isDigging;
	private bool _isWatering;
	[SerializeField]private int _handlingObj;
	
	public Vector2 Direction { get => _direction; set => _direction = value; }
	public bool IsRunning { get => _isRunning; set => _isRunning = value; }
	public bool IsRolling { get => _isRolling; set => _isRolling = value; }
	public bool IsCutting { get => _isCutting; set => _isCutting = value; }
	public bool IsDigging { get => _isDigging; set => _isDigging = value; }
	public bool IsWatering { get => _isWatering; set => _isWatering = value; }

	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_playerItems = GetComponent<PlayerItems>();
		_initialSpeed = _speed;
	}
	
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			_handlingObj = 1;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			_handlingObj = 2;
		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			_handlingObj = 3;
		}
	
		OnInput();
		OnRun();
		OnRoll();
		OnCutting();
		OnDigging();
		OnWatering();
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
	
	#region Actions
		void OnCutting()
		{
			if(_handlingObj == 1)
			{
				if(Input.GetMouseButtonDown(0))
				{
					IsCutting = true;
					_speed = 0;
				} 
				if(Input.GetMouseButtonUp(0)) 
				{
					IsCutting = false;
					_speed = _initialSpeed;
				}
			}
		}
		
		void OnDigging()
		{
			if(_handlingObj == 2)
			{
				if(Input.GetMouseButtonDown(0))
				{
					IsDigging = true;
					_speed = 0;
				} 
				if(Input.GetMouseButtonUp(0)) 
				{
					IsDigging = false;
					_speed = _initialSpeed;
				}
			}
		}
		
		void OnWatering()
		{
			if(_handlingObj == 3){
				if(_handlingObj == 3)
				{
					if(Input.GetMouseButtonDown(0) && _playerItems.TotalWater > 0)
					{
						
						IsWatering = true;
						_speed = 0;
					}
					if(Input.GetMouseButtonUp(0) || _playerItems.TotalWater < 0) 
					{
						IsWatering = false;
						_speed = _initialSpeed;
					}
					if(IsWatering) {
						_playerItems.TotalWater -= 0.001f;
					}
				}
			}
		}
	
	#endregion
}
