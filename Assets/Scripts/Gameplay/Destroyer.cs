using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        if (attacker)
        {

            FindObjectOfType<ResourceDisplay>().SubtractFromLife(attacker.GetScoreDeduction());
        }

        Destroy(collision.gameObject);
    }
}
