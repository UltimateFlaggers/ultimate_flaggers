using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string PlayerID { get; set; }
    public string PlayerName { get; set; }

    public Player()
	{
        PlayerID = System.Guid.NewGuid().ToString("N").Substring(0, 8)
            + DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerName = CommonData.MyPlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
