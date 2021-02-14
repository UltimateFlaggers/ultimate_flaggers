using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    public string playerId;
    public string playerName;

    public const int invincibleFrame = 100;

    private int invincibleFrameCount;

    public PlayerStatus status;

    private RigidbodyFirstPersonController controller;

    public GameObject attackPrefab;


    public Player()
	{
        playerId = System.Guid.NewGuid().ToString("N").Substring(0, 8)
            + DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }


    // Start is called before the first frame update
    void Start()
    {
        playerName = CommonData.MyPlayerName;
        controller = GetComponent<RigidbodyFirstPersonController>();
        status = new PlayerStatus();
        invincibleFrameCount = invincibleFrame;
        if (controller == null) return;
        SetPlayerStatus();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
		{
            var attackObject = Instantiate(attackPrefab, transform.position, transform.rotation);
            attackObject.transform.Find("Collider").gameObject.GetComponent<AttackObject>().SetPlayerID(playerId);
   //         for (var i = 0; i < attackObject.transform.childCount;  i++)
			//{
   //             var childObj = attackObject.transform.GetChild(i).gameObject;
   //             if (childObj.name == "Collider")
			//	{
   //                 childObj.GetComponent<AttackObject>().SetPlayerID(playerId);
   //                 break;
   //             }
   //         }
        }

        if (invincibleFrameCount >= 0)
		{
            invincibleFrameCount--;
        }
    }

    
    private void SetPlayerStatus()
	{
        controller.movementSettings.ForwardSpeed = status.forwardSpeed;
        controller.movementSettings.BackwardSpeed = status.backwardSpeed;
        controller.movementSettings.JumpForce = status.jumpForce;
        controller.movementSettings.RunMultiplier = status.runMultiplier;
        controller.movementSettings.StrafeSpeed = status.StrafeSpeed;
    }


    public void Hit(GameObject player, Action<GameObject> hitEvent)
    {
        if (invincibleFrameCount <= 0)
		{
            hitEvent(player);
            invincibleFrameCount = invincibleFrame;
        }
	}
}
