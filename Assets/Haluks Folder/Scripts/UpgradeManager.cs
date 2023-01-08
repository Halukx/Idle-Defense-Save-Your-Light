using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance { get; private set; }

    public GameObject RadarforRadius;

    [Header("Upgrades")]
    //EditorGUILayout.HelpBox("U can change Attack attributes.", MessageType.Info);
    [ReadOnlyVariable] public string info = "U can change Attack attributes.";
    public float damageIncreaseAmount;
    public float shootSpeedIncreaseAmount;
    public float hpIncreaseAmount;
    public float coinIncreaseAmount;
    [Space(25)]
    [Header("Enemy Spawn Rate")]
    [ReadOnlyVariable] public string _info = "U can change spawn rate settings.";
    public float _spawnRate = 1f;
    public float SpawnRateIncreaseAmount;
    public float enemyHPIncreaseAmount=1.17f;
    [Space(25)]
    [Header("Hp Settings")]
    public float playerHP;
    [Space(25)]
    [Header("Shop")]
    public float damagePrice;
    public float speedPrice;
    public float coinIncreaseMultiplier;
    public float radarPrice;
    public float doubleDamagePrice;
    public float hpPrice;
    [Space(25)]
    [Header("Other Upgrades")]
    public float doubleDamageChance = 0.3f;

    public void DefaultValue()
    {
        damageIncreaseAmount = 0.5f;
        shootSpeedIncreaseAmount = 0.02f;
        hpIncreaseAmount = 0.5f;
        coinIncreaseAmount = 1;
        damagePrice = 30;
        speedPrice = 78;
        coinIncreaseAmount = 1.1f;
        radarPrice = 60f;
        hpPrice = 75;
        SpawnRateIncreaseAmount = -0.02f;
        coinIncreaseAmount = 1;
        enemyHPIncreaseAmount = 0.4f;
    }
    public void LoadValues()
    {
        if (PlayerPrefs.HasKey("damagePrice"))
        {
            damagePrice = PlayerPrefs.GetFloat("damagePrice");
        }
        if (PlayerPrefs.HasKey("speedPrice"))
        {
            speedPrice = PlayerPrefs.GetFloat("speedPrice");
        }
        if (PlayerPrefs.HasKey("radarPrice"))
        {
            radarPrice = PlayerPrefs.GetFloat("radarPrice");
        }
        if (PlayerPrefs.HasKey("hpPrice"))
        {
            hpPrice = PlayerPrefs.GetFloat("hpPrice");
        }
    }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        DefaultValue();
        LoadValues();
        ObjectPoolEditor.spawnRate = _spawnRate;
    }

    
    public void DamageIncrease()
    {
        if (GameData.Instance.Coin >= damagePrice)
        {
            Damage.playerDamage += damageIncreaseAmount;
            GameData.Instance.Coin -= damagePrice;
            damagePrice *= 1.23f;
            PlayerPrefs.SetFloat("Coin", GameData.Instance.Coin);
            PlayerPrefs.SetFloat("PlayerDamage", Damage.playerDamage);
            PlayerPrefs.SetFloat("damagePrice", damagePrice);
            damagePrice = PlayerPrefs.GetFloat("damagePrice");
        }
    }
    public void AttackSpeedIncrease()
    {
        if (GameData.Instance.Coin >= speedPrice)
        {
            EnemyRadar.startSpeed -= shootSpeedIncreaseAmount;
            GameData.Instance.Coin -= speedPrice;
            speedPrice *= 1.23f;
            PlayerPrefs.SetFloat("Coin", GameData.Instance.Coin);
            PlayerPrefs.SetFloat("AttackSpeed", EnemyRadar.startSpeed);
            PlayerPrefs.SetFloat("speedPrice", speedPrice);
            speedPrice = PlayerPrefs.GetFloat("speedPrice");
        }
    }
    public void RadarIncrease()
    {
        if (GameData.Instance.Coin>=radarPrice)
        {
            RadarforRadius.GetComponent<CircleCollider2D>().radius = RadarforRadius.GetComponent<CircleCollider2D>().radius + 0.03f;
            radarPrice *= 1.29f;
            GameData.Instance.Coin -= radarPrice;
            PlayerPrefs.SetFloat("Coin", GameData.Instance.Coin);
            PlayerPrefs.SetFloat("RadarRadius", RadarforRadius.GetComponent<CircleCollider2D>().radius);
            PlayerPrefs.SetFloat("radarPrice", radarPrice);
            radarPrice = PlayerPrefs.GetFloat("radarPrice");
        }
    }
    public void HPIncrease()
    {
        if (GameData.Instance.Coin >= hpPrice)
        {
            PlayerHealth.Instance.playerMaxHP += hpIncreaseAmount;
            GameData.Instance.Coin -= hpPrice;
            hpPrice *= 1.23f;
            PlayerPrefs.SetFloat("Coin", GameData.Instance.Coin);
            PlayerPrefs.SetFloat("PlayerMaxHP", PlayerHealth.Instance.playerMaxHP);
            PlayerPrefs.SetFloat("hpPrice", hpPrice);
            hpPrice = PlayerPrefs.GetFloat("hpPrice");
        }
    }
    public void EnemyHPIncrease()
    {
        EnemyHealth.enemyHP += enemyHPIncreaseAmount;
    }
}