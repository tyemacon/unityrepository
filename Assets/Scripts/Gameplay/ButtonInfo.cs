using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    Text infoText;
    Image backdrop;

    private void Start()
    {
        infoText = this.GetComponentInChildren<Text>();
        backdrop = this.GetComponentInChildren<Image>();

        infoText.enabled = false;
        backdrop.enabled = false;

        Defender defender = GetComponent<DefenderButton>().GetDefender();
        string defenderInfo = defender.GetDefenderInfo();
        string defenderCost = defender.GetDefenderCost().ToString();
        string defenderHealth = defender.GetDefenderHealth();

        infoText.text = defenderInfo + "\nCost: " + defenderCost + "\nHealth: " + defenderHealth;
    }

    private void OnMouseOver()
    {
        infoText.enabled = true;
        backdrop.enabled = true;
    }

    private void OnMouseExit()
    {
        infoText.enabled = false;
        backdrop.enabled = false;
    }

}
