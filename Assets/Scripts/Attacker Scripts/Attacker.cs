using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] float currentSpeed;
    [SerializeField] int scoreDeduction;
    GameObject currentTarget;
    LevelController levelController;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
        levelController.AttackerSpawned();
    }

    private void OnDestroy()
    {
        levelController.AttackerKilled();
    }

    void Update()
    {
        Move();
        UpdateAnimationState();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if(health != null)
        {
            health.DealDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
            
    }

    public int GetScoreDeduction()
    {
        return scoreDeduction;
    }

}

