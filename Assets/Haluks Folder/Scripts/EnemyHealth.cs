using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHP ;
    public float enemyHP2;

    
    
    
    void Start()
    {
        enemyHP = 10 + GameProgress.Instance.waveCounter * 1.1f * GameProgress.Instance.levelCounter;
        enemyHP2 = enemyHP;
        EnemyRadar.enemyRadar.EnemyHealths.Add(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (EnemyRadar.ClosestEnemy != null)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                enemyHP2 -= Damage.playerDamage;
                //gameObject.SetActive(false);
                //Destroy(collision);
                if (enemyHP2 <= 0)
                {
                    Debug.Log("sadas");
                    gameObject.SetActive(false);
                    EnemyRadar.enemyRadar.EnemyHealths.Remove(this);
                    GameProgress.Instance.killCounter++;
                    ProgressBar.IncrementSlider();
                    EnemyRadar.ClosestEnemy = null;
                }
            }
        }
    }
}
