using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObject : MonoBehaviour
{
    public string playerId;

    public IAttackEvent attackEvent;

    public bool isAttackActive = false;

    private int activeFrame;
    private int frameCount;


    // Start is called before the first frame update
    void Start()
    {
        attackEvent = GetComponent<IAttackEvent>();
        isAttackActive = true;
        activeFrame = attackEvent.GetAttackFrame();
        frameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttackActive)
		{
            frameCount++;
            if (activeFrame == frameCount)
			{
                Destroy(gameObject);
			}
		}
    }


	private void OnTriggerEnter(Collider other)
	{
		var layerName = LayerMask.LayerToName(other.gameObject.layer);
		if (layerName == "player")
		{
            var player = other.gameObject.GetComponent<Player>();
            if (player.playerId == playerId) return;
            player.Hit(other.gameObject, attackEvent.AttackFunction);
		}
	}


    public void SetPlayerID(string playerId)
	{
        this.playerId = playerId;
	}
}
