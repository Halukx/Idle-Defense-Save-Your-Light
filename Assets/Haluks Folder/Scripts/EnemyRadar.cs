using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyRadar  : MonoBehaviour
{

    public static EnemyRadar enemyRadar { get; private set; }


    public static EnemyRadar Instance { get; private set; }
    private GameObject[] MultipleEnemies;
    public static EnemyHealth ClosestEnemy;
    public List<EnemyHealth> EnemyHealths=new List<EnemyHealth>();
    public Transform playerPos;
    public GameObject Player;

    int bulletIndex;
    
    public static float startSpeed=2f;
    private float ShootCooldown;
    
    
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
        if (GameManager.GameIsOver == false)
        {
            ShootCooldown -= Time.deltaTime;
            GetClosestEnemy();
            PlayerRotate();
        }
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
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
            BulletObjectPool.instance.bulletObjects[bulletIndex].SetActive(true);
            bulletIndex++;
            ClosestEnemy.enemyHP2 -= Bullet.Instance.playerDamage_;
                if (bulletIndex >= 20)
                    {
                        bulletIndex = 0;
                    }
        }
    }
    public void PlayerRotate()
    {
        if (ClosestEnemy!=null)
        {

            // Hedef nesnenin pozisyonunu ve kendi pozisyonunu al
            Vector3 targetPosition = ClosestEnemy.transform.position;
            Vector3 selfPosition = playerPos.transform.position;
            
            // Ýki nesnenin pozisyonlarý arasýndaki yön vektörünü al
            Vector3 direction = targetPosition - selfPosition;

            // Yön vektörünü y radians cinsinden döndür
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Döndürülecek nesnenin geçerli açýsýný al
            Quaternion rotation = transform.rotation;

            // Geçerli açýyý yön vektörü açýsýna doðru döndür
            rotation = Quaternion.RotateTowards(rotation, Quaternion.Euler(0f, 0f, angle-90), 1333 * Time.deltaTime);

            // Nesnenin açýsýný güncelle
            playerPos.transform.rotation = rotation;
        }
    }
}
