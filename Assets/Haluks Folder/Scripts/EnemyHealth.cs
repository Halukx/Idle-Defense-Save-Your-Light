using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHP=10 ;
    public float enemyHP2;

    [SerializeField] public GameObject particleSystem;

    float coinCounter = 1;

    void Awake()
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


    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if (EnemyRadar.ClosestEnemy != null)
            if (collider.gameObject.CompareTag("Bullet"))
            {
                //enemyHP = this.enemyHP2;
                enemyHP -= collider.gameObject.GetComponent<Bullet>().playerDamage_;
                Debug.Log("enemy hp: " + enemyHP + " damage: " + collider.gameObject.GetComponent<Bullet>().playerDamage_);
            
            
                collider.gameObject.SetActive(false);
            if (enemyHP <= 0)
            {
                Debug.Log("Düþmanýn caný: " + enemyHP);
                ExplotionEffect();
                gameObject.tag = "FarEnemy";
                //EnemyRadar.enemyRadar.EnemyHealths.Remove(this);
                GameProgress.Instance.killCounter++;
                ProgressBar.IncrementSlider();
                EnemyRadar.ClosestEnemy = null;
                coinCounter++;
                PlayerPrefs.SetFloat("coinCounter", coinCounter);
                PlayerPrefs.SetInt("killCounter", GameProgress.Instance.killCounter);
                if (coinCounter < 50)
                    UpgradeManager.instance.coinIncreaseMultiplier = 1.00329f;
                else if (coinCounter >= 50 && coinCounter < 100)
                    UpgradeManager.instance.coinIncreaseMultiplier = 1.0019f;
                else if (coinCounter >= 100 && coinCounter < 200)
                    UpgradeManager.instance.coinIncreaseMultiplier = 1.0002f;
                else if (coinCounter >= 200 && coinCounter < 500)
                    UpgradeManager.instance.coinIncreaseMultiplier = 1.000001f;
                else if (coinCounter >= 500 && coinCounter < 1000)
                    UpgradeManager.instance.coinIncreaseMultiplier = 1.00000002f;
                else
                    UpgradeManager.instance.coinIncreaseMultiplier = 1.00000000001f;
                GameData.Instance.Coin += UpgradeManager.instance.coinIncreaseAmount;
                PlayerPrefs.SetFloat("Coin", GameData.Instance.Coin);
                this.gameObject.SetActive(false);
            }
        }
    }
    // caný tekrar eski haline getir

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
    public void ExplotionEffect()
    {
        GameObject obj =Instantiate(particleSystem, gameObject.transform.position, Quaternion.identity);
        obj.GetComponent<ParticleSystem>().Play();
        Destroy(obj,2.5f);
    }
}
