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
    private void OnTriggerStay2D(Collider2D collider)
    {
        //if (EnemyRadar.ClosestEnemy != null)
        {
            if (collider.gameObject.tag == "Bullet")
            {
                collider.gameObject.SetActive(false);
                enemyHP -= collider.GetComponent<Bullet>().playerDamage_;
                Debug.Log("enemy hp: "+enemyHP);
                if (enemyHP <= 0)
                {
                    gameObject.tag = "FarEnemy";
                    //EnemyRadar.enemyRadar.EnemyHealths.Remove(this);
                    GameProgress.Instance.killCounter++;
                    ProgressBar.IncrementSlider();
                    EnemyRadar.ClosestEnemy = null;
                    GameData.Instance.Coin += UpgradeManager.instance.coinIncreaseAmount;
                    PlayerPrefs.SetFloat("Coin",GameData.Instance.Coin);
                    gameObject.SetActive(false);
                }
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
