using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerPrefabs;
    [SerializeField] float maxTime = 5f;
    [SerializeField] float minTime = 0f;


    bool spawn = true;

    private void Start()
    {
        StartSpawners();
    }

    public void StartSpawners()
    {
        StartCoroutine(StartSpawning());
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void Spawn(Attacker attackerPrefab)
    {
        Attacker attacker = Instantiate(attackerPrefab,
           transform.position, transform.rotation) as Attacker;
        attacker.transform.parent = transform;
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackerPrefabs.Length);
        Spawn(attackerPrefabs[attackerIndex]);
    }

    IEnumerator StartSpawning()
    {
        do
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            SpawnAttacker();
        }
        while (spawn);
    }
}
