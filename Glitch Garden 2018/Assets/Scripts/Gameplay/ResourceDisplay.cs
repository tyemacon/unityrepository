using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] int rupees = 100;
    [SerializeField] int life = 100;
    [SerializeField] Text rupeeText;
    [SerializeField] Text lifeText;

    void Start()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        lifeText.text = life.ToString();
        rupeeText.text = rupees.ToString();
    }

    public bool SubtractFromResources(int costOfDefender)
    {
        if(rupees < costOfDefender)
        {
            Debug.Log("Costs too much!");
            return false;
        }
        rupees -= costOfDefender;
        UpdateDisplay();
        return true;
    }

    public void AddToResources(int resourceAmount)
    {
        rupees += resourceAmount;
        UpdateDisplay();
    }

    public void SubtractFromLife(int damageFromDefender)
    {
        bool gameOver = false;
        life -= damageFromDefender;
        if(life <= 0)
        {
            life = 0;
            gameOver = true;
        }
        UpdateDisplay();
        if (gameOver)
        {
            FindObjectOfType<LevelLoader>().LoadGameOver();
        }
    }

}
