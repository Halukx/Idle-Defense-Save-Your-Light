using System.Collections.Generic;
using UnityEngine;

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
    
    [SerializeField] public GameObject Bullet;

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
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            if (EnemyHealths.Count > 0 && GetClosestEnemy() != null)
            {
                ClosestEnemy = GetClosestEnemy();
            }
            if (ShootCooldown<0 && ClosestEnemy !=null)
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
        if (ClosestEnemy.enemyHP <= 0)
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
            ClosestEnemy.enemyHP -= Damage.playerDamage;
            if (bulletIndex>=20)
            {
                bulletIndex = 0;
            }
        }
    }
}
