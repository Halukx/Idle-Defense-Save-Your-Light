using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    private GameObject[] MultipleEnemies;
    public static Health ClosestEnemy;
    public List<Health> EnemyHealths=new List<Health>();

    public float ShootSpeed = 2f;
    private float ShootCooldown=0F;
    

    

    public static EnemyRadar enemyRadar;
    
    [SerializeField] public GameObject Bullet;

    private void Awake()
    {
        enemyRadar = this;
    }

    private void Start()
    {
        ClosestEnemy = null;
    }

    private void Update()
    {
        if (EnemyHealths.Count > 0 && GetClosestEnemy() != null)
        {
            ClosestEnemy = GetClosestEnemy();
        }
        ShootCooldown += Time.deltaTime;
    }
    
    private void Attack()
    {
        if (ClosestEnemy.HP<=0)
        {
            EnemyHealths.Remove(ClosestEnemy);
        }
        else
        {
            var newBullet = Instantiate(Bullet, new Vector3(0, 0, 0), Quaternion.identity);
            newBullet.transform.parent = null;
            ClosestEnemy.HP -= Damage._damage;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            if (ShootCooldown>=ShootSpeed)
            {
                Attack();
                ShootCooldown = 0;
            }
            
        }
    }

    public Health GetClosestEnemy()
    {
        
        MultipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float ClosestDistance = Mathf.Infinity;
        Health trans = null;
        foreach (Health go in EnemyHealths)
        {
            float CurrentDistance;
            CurrentDistance = Vector2.Distance(transform.position,go.transform.position);
            if (CurrentDistance<ClosestDistance)
            {
                ClosestDistance = CurrentDistance;
                trans = go;
            }
        }
        return trans;
    }
}
