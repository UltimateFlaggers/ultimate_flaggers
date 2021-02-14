using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPlace : MonoBehaviour
{
    public Dictionary<string, float> goalTime;


	private void Start()
	{
		goalTime = new Dictionary<string, float>();
	}

	private void OnTriggerEnter(Collider other)
	{
		var layerName = LayerMask.LayerToName(other.gameObject.layer);
		if (layerName == "player")
		{
			var playerId = other.gameObject.GetComponent<Player>().PlayerID;
			if (!goalTime.ContainsKey(playerId))
			{
				goalTime.Add(playerId, Time.time);
			}
		}
	}
}
