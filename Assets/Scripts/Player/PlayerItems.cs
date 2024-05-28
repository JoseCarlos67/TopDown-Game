using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
	[SerializeField] private int _totalWood;

    public int TotalWood { get => _totalWood; set => _totalWood = value; }
}
