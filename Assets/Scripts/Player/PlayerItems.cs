using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
	[SerializeField] private int _totalWood;
	[SerializeField] private int _currentWater;
	private int _waterLimit = 50;

	public int TotalWood { get => _totalWood; set => _totalWood = value; }
	public int TotalWater { get => _currentWater; }
	
	public void WaterLimit(int water)
	{
		if(_currentWater < _waterLimit)
		{
			_currentWater += water;
		}
	}
}
