using UnityEngine;

public class Wood : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _timeMove;

	[SerializeField] private float _timeCount;

	void Update()
	{
		_timeCount += Time.deltaTime;
		
		if(_timeCount < _timeMove)
		{
			transform.Translate(Vector2.right * _speed * Time.deltaTime);
		}
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			collision.GetComponent<PlayerItems>().TotalWood++;
			Destroy(gameObject);
		}
	}
}
