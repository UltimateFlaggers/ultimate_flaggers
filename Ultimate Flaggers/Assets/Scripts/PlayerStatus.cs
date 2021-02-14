using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class PlayerStatus : MonoBehaviour
{
	[SerializeField]
	public int hp = 100;

	[SerializeField]
	public int forwardSpeed = 8;

	[SerializeField]
	public int backwardSpeed = 8;

	[SerializeField]
	public int StrafeSpeed = 2;

	[SerializeField]
	public int jumpForce = 100;

	[SerializeField]
	public float runMultiplier = 2;

	public bool IsDead { get { return hp <= 0; } }



	public PlayerStatus()
	{
		
	}

	private void Start()
	{

	}
}