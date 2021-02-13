using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course : MonoBehaviour
{
    public StartingPlace startingPlace;

    public GoalPlace goalPlace;

    public Dictionary<string, GameObject> players;

    public GameObject playerPrefab;

    public List<Vector3> characterPos;



    // Start is called before the first frame update
    void Start()
    {
        startingPlace = new StartingPlace();
        goalPlace = new GoalPlace();
        players = new Dictionary<string, GameObject>();
        var player = new Player();
        CommonData.MyPlayerID = player.PlayerID;
        player.PlayerName = CommonData.MyPlayerName;
        players.Add(player.PlayerID, Instantiate(playerPrefab, characterPos[0], Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
