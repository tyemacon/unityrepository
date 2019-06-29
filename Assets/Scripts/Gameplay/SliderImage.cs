using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderImage : MonoBehaviour
{
    private void Update()
    {
        if (FindObjectOfType<LevelController>().TimerDone())
        {
            GetComponent<Animator>().SetTrigger("timerOff");
        }
    }
}
