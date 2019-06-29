using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{

    [SerializeField] string defenderInfo;
    [SerializeField] string defenderhealth;
    [SerializeField] int defenderCost;

    public void AddToResources(int rupees)
    {
        FindObjectOfType<ResourceDisplay>().AddToResources(rupees);
    }

    public string GetDefenderInfo()
    {
        return defenderInfo;
    }

    public int GetDefenderCost()
    {
        return defenderCost;
    }

    public string GetDefenderHealth()
    {
        return defenderhealth;
    }
}
