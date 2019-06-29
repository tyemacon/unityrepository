using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] int numberOfAttackers = 0;
    [SerializeField] float timeToLoad = 2f;
    bool levelTimerFinished = false;

    private void Start()
    {
        if (winLabel)
        {
            winLabel.SetActive(false);
        }
    }

    public bool TimerDone()
    {
        return levelTimerFinished;
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            if (this)
            {
                StartCoroutine(HandleWinCondition());
            }
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(timeToLoad);
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnersArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnersArray)
        {
            spawner.StopSpawning();
        }
    }
}
