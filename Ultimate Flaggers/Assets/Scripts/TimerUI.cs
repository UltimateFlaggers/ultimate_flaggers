using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    // Start is called before the first frame update

    private bool isGoal = false;

    private Text timerText;

    private Course course;

    [SerializeField]
    private GameObject courseObject;

    


    void Start()
    {
        course = courseObject.GetComponent<Course>();
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (course.goalTime.ContainsKey(CommonData.MyPlayerID))
		{
            isGoal = true;
            timerText.text = course.goalTime[CommonData.MyPlayerID].ToString();
		}

        if (!isGoal)
		{
            timerText.text = course.elapsedTime.ToString();
        }
        

    }
}
