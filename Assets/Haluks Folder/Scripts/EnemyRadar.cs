using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyRadar : MonoBehaviour
{
    private GameObject[] MultipleEnemies;
    public static EnemyHealth ClosestEnemy;
    public List<EnemyHealth> EnemyHealths=new List<EnemyHealth>();
    public Transform playerPos;

    int bulletIndex;
    
    public static float startSpeed=1f;
    private float ShootCooldown;
    public static EnemyRadar enemyRadar { get; private set; }
    
    //[SerializeField] public GameObject BulletPrefab;

    private void Awake()
    {
        enemyRadar = this;
    }

    private void Start()
    {
        ClosestEnemy = null;
        ShootCooldown = startSpeed;
    }

    private void Update()
    {
        ShootCooldown -= Time.deltaTime;
        GetClosestEnemy();
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            var offset = -90f;
            Vector2 direction = collision.transform.position - transform.parent.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, rotation, 13 * Time.deltaTime);




            if (EnemyHealths.Count > 0 && GetClosestEnemy() != null)
            {
                ClosestEnemy = GetClosestEnemy();
            }
            if (ShootCooldown < 0 && ClosestEnemy != null)
            {
                ShootCooldown = startSpeed;
                Attack();
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FarEnemy")
        {
            collision.gameObject.tag = "Enemy";
        }
    }

    public EnemyHealth GetClosestEnemy()
    {
        
        MultipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float ClosestDistance = Mathf.Infinity;
        EnemyHealth trans = null;
        foreach (EnemyHealth go in EnemyHealths)
        {
            if (go.tag == "Enemy")
            {
                float CurrentDistance;
                CurrentDistance = Vector2.Distance(transform.position, go.transform.position);
                if (CurrentDistance < ClosestDistance)
                {
                    ClosestDistance = CurrentDistance;
                    trans = go;
                }
            }
        }
        return trans;
    }

    public void Attack()
    {
        Debug.Log("Your Damage " + Damage.playerDamage);
        Debug.Log("Your Attack Speed:" + startSpeed);
        if (ClosestEnemy.enemyHP2 <= 0)
        {
            EnemyHealths.Remove(ClosestEnemy);
            ClosestEnemy = null;
        }
        else
        {
                //var newBullet = Instantiate(Bullet, playerPos.transform.position, Quaternion.identity);
                //newBullet.transform.parent = null;
            BulletObjectPool.instance.bulletObjects[bulletIndex].SetActive(true);
            bulletIndex++;
            ClosestEnemy.enemyHP2 -= Damage.playerDamage;
                if (bulletIndex >= 20)
                    {
                        bulletIndex = 0;
                    }
        }
    }
}
