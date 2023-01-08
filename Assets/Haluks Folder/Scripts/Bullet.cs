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
        rb = GetComponent<Rigidbody2D>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        bulletDamage= Damage.playerDamage;
    }
    private void Update()
    {
        targetPosition = EnemyRadar.ClosestEnemy.transform.position;
        rb.velocity = (EnemyRadar.ClosestEnemy.transform.position - transform.position).normalized * bulletSpeed;
        Vector2 direction = targetPosition - (Vector2)transform.position;
        direction.Normalize();
        
        float moveSpeed = 1f;
        //BAZEN ÇARPIÞMALAR ALGILANMIYOR O ÇÖZÜLECEK
        //transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
=======
        if (collision.tag=="Enemy")
        {
            //EnemyRadar.ClosestEnemy.enemyHP -= playerDamage_;
            //collision.GetComponent<EnemyHealth>().enemyHP -= playerDamage_;
            gameObject.SetActive(false);
        }
        
>>>>>>> parent of 36a7ca4 (SOME PROBLEMS FIXED)
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
