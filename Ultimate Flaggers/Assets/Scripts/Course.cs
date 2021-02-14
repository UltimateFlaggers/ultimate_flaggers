using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course : MonoBehaviour
{
    [SerializeField]
    private GameObject goalObject;

    [SerializeField]
    private GameObject startingGate;

    [SerializeField]
    public GameObject playerPrefab;

    [SerializeField]
    public List<Vector3> characterPos;


    private Dictionary<string, GameObject> players;

    private bool isStarted = false;

    private float startTime;
    public float elapsedTime { get; private set; }

    public Dictionary<string, float> goalTime;




    // Start is called before the first frame update
    void Start()
    {
        players = new Dictionary<string, GameObject>();
        goalTime = new Dictionary<string, float>();
        SetPlayerPrefab(0);
        startTime = Time.time;
        isStarted = false;
    }


    public void SetPlayerPrefab(int index)
	{
        var playerObject = Instantiate(playerPrefab, characterPos[0], Quaternion.identity);
        var player = playerObject.GetComponent<Player>();
        CommonData.MyPlayerID = player.PlayerID;
        CommonData.MyPlayerName = player.PlayerName;
        players.Add(player.PlayerID, playerObject);

    }


    public void SetEnemyPrefab(int index)
	{
        var enemy = new Player();
        players.Add(enemy.PlayerID, Instantiate(playerPrefab, characterPos[1], Quaternion.identity));
	}


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
		{
            startingGate.SetActive(false);
            startTime = Time.time;
            isStarted = true;
            goalTime = goalObject.GetComponent<GoalPlace>().goalTime;
		}

        if (isStarted)
		{
            elapsedTime = Time.time - startTime;
        }
    }
}
