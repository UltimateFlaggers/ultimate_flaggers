using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CircleAttack : MonoBehaviour, IAttackEvent
{
	public int activeFrame = 60;

	public int force = 500;

	public int GetAttackFrame()
	{
		return activeFrame;
	}


	public void AttackFunction(GameObject playerObject)
	{
		var rigit = playerObject.GetComponent<Rigidbody>();
		Debug.Log("hitEvent" + playerObject.GetComponent<Player>().playerId + "Mass: " + rigit.mass);
		

		rigit.AddForce(transform.up * force);
	}
}
