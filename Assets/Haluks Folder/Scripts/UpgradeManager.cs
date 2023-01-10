using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float hpRegenIncreaseAmount;
    [Space(25)]
    [Header("Enemy Spawn Rate")]
    [ReadOnlyVariable] public string _info = "U can change spawn rate settings.";
    public float _spawnRate = 1f;
    public float spawnRateIncreaseAmount;
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
    public float hpRegenPrice;
    [Space(25)]
    [Header("Other Upgrades")]
    public float doubleDamageChance = 0.3f;

    float damageCounter = 0;
    float radarCounter=0;
    float attackSpeedCounter = 0;
    float hpCounter = 0;
    float hpRegenCounter = 0;

    public void DefaultValue()
    {
        damageIncreaseAmount = 0.4f;
        shootSpeedIncreaseAmount = 0.1f;
        hpIncreaseAmount = 0.5f;
        coinIncreaseMultiplier = 1.00329f;
        damagePrice = 62;
        speedPrice = 78;
        coinIncreaseAmount = 1.1f;
        radarPrice = 150f;
        hpPrice = 75;
        spawnRateIncreaseAmount = -0.02f;
        enemyHPIncreaseAmount = 0.4f;
        hpRegenPrice = 50;
        hpRegenIncreaseAmount = 0.02f;
    }
    public void LoadValues()
    {
        if (PlayerPrefs.HasKey("hpRegenCounter"))
        {
            hpRegenCounter = PlayerPrefs.GetFloat("hpRegenCounter");
        }
        if (PlayerPrefs.HasKey("hpCounter"))
        {
            hpCounter = PlayerPrefs.GetFloat("hpCounter");
        }
        if (PlayerPrefs.HasKey("attackSpeedCounter"))
        {
            attackSpeedCounter = PlayerPrefs.GetFloat("attackSpeedCounter");
        }
        if (PlayerPrefs.HasKey("damageCounter"))
        {
            damageCounter = PlayerPrefs.GetFloat("damageCounter");
        }
        if (PlayerPrefs.HasKey("radarCounter"))
        {
            radarCounter = PlayerPrefs.GetFloat("radarCounter");
        }
        if (PlayerPrefs.HasKey("hpRegenIncreaseAmount"))
        {
            hpRegenIncreaseAmount = PlayerPrefs.GetFloat("hpRegenIncreaseAmount");
        }
        if (PlayerPrefs.HasKey("spawnRateIncreaseAmount"))
        {
            spawnRateIncreaseAmount = PlayerPrefs.GetFloat("spawnRateIncreaseAmount");
        }
        if (PlayerPrefs.HasKey("enemyHPIncreaseAmount"))
        {
            enemyHPIncreaseAmount = PlayerPrefs.GetFloat("enemyHPIncreaseAmount");
        }
        if (PlayerPrefs.HasKey("hpRegenPrice"))
        {
            hpRegenPrice = PlayerPrefs.GetFloat("hpRegenPrice");
        }
        if (PlayerPrefs.HasKey("coinIncreaseAmount"))
        {
            coinIncreaseAmount = PlayerPrefs.GetFloat("coinIncreaseAmount");
        }
        if (PlayerPrefs.HasKey("coinIncreaseMultiplier"))
        {
            coinIncreaseMultiplier = PlayerPrefs.GetFloat("coinIncreaseAmount");
        }
        if (PlayerPrefs.HasKey("hpIncreaseAmount"))
        {
            hpIncreaseAmount = PlayerPrefs.GetFloat("hpIncreaseAmount");
        }
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

    private void Update()
    {
        //GameData.Instance.Coin = 9999f;
    }
    public void DamageIncrease()
    {
        if (GameData.Instance.Coin >= damagePrice)
        {
            damageCounter++;
            PlayerPrefs.SetFloat("damageCounter", damageCounter);
            Damage.playerDamage += damageIncreaseAmount;
            GameData.Instance.Coin -= damagePrice;
            if (damageCounter < 11)
                damagePrice *= 1.0437f;
            else
                damagePrice *= 1.011f;
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
            attackSpeedCounter++;
            PlayerPrefs.SetFloat("attackSpeedCounter", attackSpeedCounter);
            EnemyRadar.startSpeed -= shootSpeedIncreaseAmount;
            GameData.Instance.Coin -= speedPrice;
            if (attackSpeedCounter < 15)
                speedPrice *= 1.1f;
            else
                speedPrice *= 1.03f;
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
            radarCounter++;
            PlayerPrefs.SetFloat("radarCounter", radarCounter);
            RadarforRadius.GetComponent<CircleCollider2D>().radius = RadarforRadius.GetComponent<CircleCollider2D>().radius + 0.03f;
            if (radarCounter < 15)
                radarPrice *= 1.1f;
            else
                radarPrice *= 1.03f;
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
            hpCounter++;
            PlayerHealth.Instance.playerMaxHP += hpIncreaseAmount;
            GameData.Instance.Coin -= hpPrice;
            if (hpCounter < 19)
                hpPrice *= 1.00358f;
            else
                hpPrice *= 1.0013f;
            hpPrice *= 1.23f;
            PlayerPrefs.SetFloat("Coin", GameData.Instance.Coin);
            PlayerPrefs.SetFloat("PlayerMaxHP", PlayerHealth.Instance.playerMaxHP);
            PlayerPrefs.SetFloat("hpPrice", hpPrice);
            hpPrice = PlayerPrefs.GetFloat("hpPrice");
        }
    }
    public void HPRegenIncrease()
    {
        if (GameData.Instance.Coin>= hpRegenPrice)
        {
            hpRegenCounter++;
            PlayerHealth.healthRegenAmount += hpRegenIncreaseAmount;
            GameData.Instance.Coin -= hpRegenPrice;
            if (hpRegenCounter < 16)
                hpRegenPrice *= 1.23f;
            else
                hpRegenPrice = 1.012f;
            PlayerPrefs.SetFloat("Coin", GameData.Instance.Coin);
            PlayerPrefs.SetFloat("HealthRegenAmount", PlayerHealth.healthRegenAmount);
            PlayerPrefs.SetFloat("hpRegenPrice", hpRegenPrice);
            hpPrice = PlayerPrefs.GetFloat("hpRegenPrice");
        }
    }
    public void EnemyHPIncrease()
    {
        //EnemyHealth.enemyHP += enemyHPIncreaseAmount;
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        EnemyObjectPool enemyObjectPool = FindObjectOfType<EnemyObjectPool>();
        foreach (var item in enemyObjectPool.pooledObjects)
        {
            item.enemyHP += enemyHPIncreaseAmount;
            item.enemyHP2 = item.enemyHP;
        }
    }
}