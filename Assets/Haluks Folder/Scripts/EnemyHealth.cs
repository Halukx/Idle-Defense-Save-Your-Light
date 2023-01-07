using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static float enemyHP ;
    public float enemyHP2;

    
    
    
    void Start()
    {
        //Time.fixedDeltaTime = 1 / 60;
        //enemyHP = 10 + GameProgress.Instance.waveCounter * 1.1f * GameProgress.Instance.levelCounter;

        if (!PlayerPrefs.HasKey("EnemyHP"))
        {
            enemyHP = 10f;
            PlayerPrefs.SetFloat("EnemyHP", enemyHP);
        }
        else
        {
            enemyHP = PlayerPrefs.GetFloat("EnemyHP");
        }

        enemyHP2 = enemyHP;
        EnemyRadar.enemyRadar.EnemyHealths.Add(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (EnemyRadar.ClosestEnemy != null)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                enemyHP -= collision.GetComponent<Bullet>().playerDamage_;
                Debug.Log("enemy hp: "+enemyHP);
                //gameObject.SetActive(false);
                //Destroy(collision);
                if (enemyHP <= 0)
                {
                    gameObject.tag = "FarEnemy";
                    EnemyRadar.enemyRadar.EnemyHealths.Remove(this);
                    GameProgress.Instance.killCounter++;
                    ProgressBar.IncrementSlider();
                    EnemyRadar.ClosestEnemy = null;
                    GameData.Instance.Coin += UpgradeManager.instance.coinIncreaseAmount;
                    PlayerPrefs.SetFloat("Coin",GameData.Instance.Coin);
                    gameObject.SetActive(false);
                }
                collision.gameObject.SetActive(false);
            }
            
        }
    }
    /*private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("EnemyHP"))
        {
            enemyHP = 10f;
            PlayerPrefs.SetFloat("EnemyHP", enemyHP);
        }
        else
        {
            enemyHP = PlayerPrefs.GetFloat("EnemyHP");
        }
        enemyHP2 = enemyHP;
        EnemyRadar.enemyRadar.EnemyHealths.Add(this);
    }*/

}
