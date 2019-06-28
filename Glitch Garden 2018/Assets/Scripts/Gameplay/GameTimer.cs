using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time in SECONDS")]
    [SerializeField] float levelTime = 10f;
    [SerializeField] bool triggeredLevelFinished = false;
    bool inTutorial = false;

    public void IsInTutorial()
    {
        inTutorial = true;
    }

    public void IsOutOfTutorial()
    {
        inTutorial = false;
    }

    void Update()
    {
        if (!triggeredLevelFinished && !inTutorial)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
            bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
            if (timerFinished)
            {
                triggeredLevelFinished = true;
                FindObjectOfType<LevelController>().LevelTimerFinished();
            }
        }
    }
}
