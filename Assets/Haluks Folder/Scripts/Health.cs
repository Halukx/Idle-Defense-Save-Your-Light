using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP;
    public float HP2;
    
    void Start()
    {
        HP2= HP;
        EnemyRadar.enemyRadar.EnemyHealths.Add(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (EnemyRadar.ClosestEnemy != null)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                HP2 -= EnemyRadar.enemyRadar.damage._damage;
                Destroy(collision.gameObject);
                if (HP2<=0)
                {
                    Destroy(gameObject);
                    EnemyRadar.enemyRadar.EnemyHealths.Remove(this);
                }
            }
        }
    }
}
