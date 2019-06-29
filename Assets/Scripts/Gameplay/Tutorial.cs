using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] infoBoxes;
    [SerializeField] Button nextTipButton;
    [SerializeField] Animator timer;
    int currentTip = 0;


    bool toggle = true;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameTimer>().IsInTutorial();
        timer.enabled = false;
        if (infoBoxes != null)
        {
            foreach(GameObject infoBox in infoBoxes)
            {
                infoBox.SetActive(false);
            }
        }
    }

    public void NextTip()
    {
        if(currentTip == infoBoxes.Length - 1)
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (currentTip == 0)
        {
            infoBoxes[infoBoxes.Length - 1].SetActive(false);
        }
        else
        {
            infoBoxes[currentTip - 1].SetActive(false);
        }

        infoBoxes[currentTip].SetActive(true);

        if (currentTip == infoBoxes.Length - 1)
        {
            currentTip = 0;
        }
        else
        {
            currentTip++;
            if(currentTip == infoBoxes.Length - 1)
            {
                nextTipButton.GetComponentInChildren<Text>().text = "Let's Go!";
            }
        }
    }
}
