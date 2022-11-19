using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    [Header("Coin Balance")]
    public float Coin;

    private void Awake()
    {
        Instance= this;
    }
    private void Start()
    {
        CoinGetSet();
        DamageIncreaseGetSet();
        DamageGetSet();
        AttackSpeedGetSet();
        LevelGetSet();
    }


    public void CoinGetSet()
    {
        if (PlayerPrefs.HasKey("Coin"))
        {
            Coin = PlayerPrefs.GetFloat("Coin");
        }
        else
        {
            PlayerPrefs.SetFloat("Coin", Coin);
        }
    }
    public void DamageIncreaseGetSet()
    {
        if (PlayerPrefs.HasKey("DamageIncreaseAmount"))
        {
            UpgradeManager.instance.damageIncreaseAmount = PlayerPrefs.GetFloat("DamageIncreaseAmount");
        }
        else
        {
            PlayerPrefs.SetFloat("DamageIncreaseAmount", UpgradeManager.instance.damageIncreaseAmount);
        }
    }

    public void AttackSpeedGetSet()
    {
        if (PlayerPrefs.HasKey("AttackSpeed"))
        {
            EnemyRadar.startSpeed = PlayerPrefs.GetFloat("AttackSpeed");
        }
        else
        {
            PlayerPrefs.GetFloat("AttackSpeed",EnemyRadar.startSpeed);
        }
    }    
    public void DamageGetSet()
    {
        if (PlayerPrefs.HasKey("PlayerDamage"))
        {
            Damage.playerDamage = PlayerPrefs.GetFloat("PlayerDamage");
        }
        else
        {
            PlayerPrefs.SetFloat("PlayerDamage",Damage.playerDamage);
        }
        if (PlayerPrefs.HasKey("EnemyDamage"))
        {
            Damage.enemyDamage = PlayerPrefs.GetFloat("EnemyDamage");
        }
        else
        {
            PlayerPrefs.SetFloat("EnemyDamage",Damage.enemyDamage);
        }
    }
    public void LevelGetSet()
    {
        if (PlayerPrefs.HasKey("LevelData"))
        {
            GameProgress.Instance.levelCounter = PlayerPrefs.GetInt("LevelData");
        }
        else
        {
            PlayerPrefs.SetInt("LevelData", GameProgress.Instance.levelCounter);
        }
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
