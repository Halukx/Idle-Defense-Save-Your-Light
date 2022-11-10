using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public static float bulletSpeed=1f;
    public float bulletDamage;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy")
        {
            gameObject.SetActive(false);
            EnemyRadar.ClosestEnemy.enemyHP2 -= bulletDamage;
        }
        
    }
    private void OnEnable()
    {
        bulletDamage = Damage.playerDamage;
        if (EnemyRadar.ClosestEnemy != null)
        {
            gameObject.transform.position = EnemyRadar.enemyRadar.playerPos.transform.position;
            rb.velocity = (EnemyRadar.ClosestEnemy.transform.position - transform.position).normalized * bulletSpeed;
        }
    }
}
