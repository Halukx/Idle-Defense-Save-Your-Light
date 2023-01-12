using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet Instance { get; private set; }
    Rigidbody2D rb;
    public static float bulletSpeed=1.5f;
    public static float bulletDamage;
    public float playerDamage_;
    public Vector2 targetPosition;



    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        bulletDamage= Damage.playerDamage;
    }
    private void Update()
    {
        if(EnemyRadar.ClosestEnemy!=null)
        {
            targetPosition = EnemyRadar.ClosestEnemy.transform.position;
            rb.velocity = (EnemyRadar.ClosestEnemy.transform.position - transform.position).normalized * bulletSpeed;
            Vector2 direction = targetPosition - (Vector2)transform.position;
            direction.Normalize();
        }
        //BAZEN ÇARPIÞMALAR ALGILANMIYOR O ÇÖZÜLECEK
        //transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }
    private void OnEnable()
    {
        bulletDamage = Damage.enemyDamage;
        playerDamage_ = Damage.playerDamage;
        if (EnemyRadar.ClosestEnemy != null)
        {
            gameObject.transform.position = EnemyRadar.enemyRadar.playerPos.transform.position;
        }
    }
}
