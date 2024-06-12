using UnityEngine;

public class Tree : MonoBehaviour
{
	[SerializeField] private float _treeHealth;
	[SerializeField] private Animator _animator;
	[SerializeField] private GameObject _woodPrefab;
	[SerializeField] private int totalDropWood;
	[SerializeField] private ParticleSystem _leafs;
	
	private bool _isCut;
	
	public void OnHit()
	{
		_treeHealth--;
		_animator.SetTrigger("isHit");
		_leafs.Play();
		if(_treeHealth <= 0)
		{
			for(int i = 1; i <= totalDropWood; i++)
			{
				Instantiate(_woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 0.5f)), transform.rotation);
			}
			_animator.SetTrigger("cut");
			_isCut = true;
		}
	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Axe") && !_isCut)
		{
			OnHit();
		}
	}
}
