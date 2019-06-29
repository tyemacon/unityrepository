using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float moveSpeed = 1f;
    [SerializeField] float damage = 100;

    [SerializeField] bool doesRotate = true;

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();
        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }



   }
}
