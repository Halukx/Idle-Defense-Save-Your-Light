using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet Instance { get; private set; }
    Rigidbody2D rb;
    public static float bulletSpeed=1f;
    public static float bulletDamage;
    public float playerDamage_;



    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();}

    private void Start()
    {
        //playerDamage_ = Damage.playerDamage ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy")
        {
            //EnemyRadar.ClosestEnemy.enemyHP -= playerDamage_;
            //collision.GetComponent<EnemyHealth>().enemyHP -= playerDamage_;
            gameObject.SetActive(false);
        }
        
    }
    private void OnEnable()
    {
        bulletDamage = Damage.enemyDamage;
        playerDamage_ = Damage.playerDamage;
        if (EnemyRadar.ClosestEnemy != null)
        {
            gameObject.transform.position = EnemyRadar.enemyRadar.playerPos.transform.position;
            rb.velocity = (EnemyRadar.ClosestEnemy.transform.position - transform.position).normalized * bulletSpeed;
        }
    }
}
