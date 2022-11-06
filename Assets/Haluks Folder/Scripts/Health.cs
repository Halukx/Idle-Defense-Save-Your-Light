using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP ;
    public float HP2;
    
    
    void Start()
    {
        HP = 10 + GameProgress.waveCounter * 1.1f * GameProgress.levelCounter;
        HP2 = HP;
        EnemyRadar.enemyRadar.EnemyHealths.Add(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (EnemyRadar.ClosestEnemy != null)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                HP2 -= Damage._damage;
                Destroy(collision.gameObject);
                if (HP2 <= 0)
                {
                    Debug.Log("sadas");
                    Destroy(gameObject);
                    EnemyRadar.enemyRadar.EnemyHealths.Remove(this);
                    GameProgress.killCounter++;
                    ProgressBar.IncrementSlider();
                    EnemyRadar.ClosestEnemy = null;
                }
            }
        }
    }
}
