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
                enemyHP = this.enemyHP2;
                //enemyHP -= collider.gameObject.GetComponent<Bullet>().playerDamage_;
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
