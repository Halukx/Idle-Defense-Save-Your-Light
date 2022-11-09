using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] public float bulletSpeed;
    private void Start()
    {
        if (EnemyRadar.ClosestEnemy!=null)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = (EnemyRadar.ClosestEnemy.transform.position - transform.position).normalized*bulletSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy")
        {
            Destroy(gameObject);
        }
    }
}
