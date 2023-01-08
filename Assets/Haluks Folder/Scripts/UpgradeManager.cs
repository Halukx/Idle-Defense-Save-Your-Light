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
    [Space(25)]
    [Header("Enemy Spawn Rate")]
    [ReadOnlyVariable] public string _info = "U can change spawn rate settings.";
    public float _spawnRate = 1f;
    public float SpawnRateIncreaseAmount;
    [Space(25)]
    [Header("Hp Settings")]
    public float playerHP;
    [Space(25)]
    [Header("Shop")]
    public float damagePrice = 5;
    public float speedPrice = 5;
    public float coinIncreaseAmount = 1;
    public float coinIncreaseMultiplier = 1.1f;
    public float radarPrice = 60f;
    public float doubleDamagePrice = 50f;
    [Space(25)]
    [Header("Other Upgrades")]
    public float doubleDamageChance = 0.3f;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SpawnRate.Instance.spawnRate = _spawnRate;
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
        }
    }
    /*public void SpawnRateIncrease()
    {
        if (GameData.Instance.Coin >= speedPrice)
        {
            SpawnRate.Instance.spawnRate -= SpawnRateIncreaseAmount;
            GameData.Instance.Coin -= speedPrice;
            speedPrice *= 1.23f;
            PlayerPrefs.SetFloat("Coin", GameData.Instance.Coin);
            PlayerPrefs.SetFloat("SpawnRate", SpawnRate.Instance.spawnRate);
        }
    }*/
    public void RadarIncrease()
    {
        if (GameData.Instance.Coin>=radarPrice)
        {
            RadarforRadius.GetComponent<CircleCollider2D>().radius = RadarforRadius.GetComponent<CircleCollider2D>().radius + 0.03f;
            radarPrice *= 1.29f;
            GameData.Instance.Coin -= radarPrice;
            PlayerPrefs.SetFloat("Coin", GameData.Instance.Coin);
            PlayerPrefs.SetFloat("RadarRadius", RadarforRadius.GetComponent<CircleCollider2D>().radius);
        }
    }
    

}