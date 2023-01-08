using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
<<<<<<< HEAD
    private void OnTriggerStay2D(Collider2D collider)
=======

    private void OnTriggerEnter2D(Collider2D collision)
>>>>>>> parent of 36a7ca4 (SOME PROBLEMS FIXED)
    {
        //if (EnemyRadar.ClosestEnemy != null)
        {
            if (collider.gameObject.tag == "Bullet")
            {
<<<<<<< HEAD
                collider.gameObject.SetActive(false);
                enemyHP -= collider.GetComponent<Bullet>().playerDamage_;
                Debug.Log("enemy hp: "+enemyHP);
                if (enemyHP <= 0)
                {
                    gameObject.tag = "FarEnemy";
                    //EnemyRadar.enemyRadar.EnemyHealths.Remove(this);
=======
                enemyHP -= collision.GetComponent<Bullet>().playerDamage_;
                //gameObject.SetActive(false);
                //Destroy(collision);
                if (enemyHP <= 0)
                {
                    gameObject.tag = "FarEnemy";
                    gameObject.SetActive(false);
                    EnemyRadar.enemyRadar.EnemyHealths.Remove(this);
>>>>>>> parent of 36a7ca4 (SOME PROBLEMS FIXED)
                    GameProgress.Instance.killCounter++;
                    ProgressBar.IncrementSlider();
                    EnemyRadar.ClosestEnemy = null;
                    GameData.Instance.Coin += UpgradeManager.instance.coinIncreaseAmount;
                    PlayerPrefs.SetFloat("Coin",GameData.Instance.Coin);
                }
            }
        }
    }

}
