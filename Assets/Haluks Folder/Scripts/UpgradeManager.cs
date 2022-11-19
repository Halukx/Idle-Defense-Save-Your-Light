using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance { get; private set; }
    [Header("Upgrades")]
    //EditorGUILayout.HelpBox("U can change Attack attributes.", MessageType.Info);
    [ReadOnlyVariable] public string info = "U can change Attack attributes.";
    public float damageIncreaseAmount;
    public float shootSpeedIncreaseAmount;
    [Space(25)]
    [Header("Enemy Spawn Rate")]
    [ReadOnlyVariable] public string _info = "U can change spawn rate settings.";
    public float spawnRate = 1f;
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


    private void Awake()
    {
        instance = this;
    }

    public void DamageIncrease()
    {
        if (GameData.Instance.Coin>=damagePrice)
        {
            Damage.playerDamage += damageIncreaseAmount;
            GameData.Instance.Coin-=damagePrice;
            damagePrice *= 1.23f;
            PlayerPrefs.SetFloat("Coin",GameData.Instance.Coin);
            PlayerPrefs.SetFloat("PlayerDamage",Damage.playerDamage);
        }
    }
    public void AttackSpeedIncrease()
    {
        if (GameData.Instance.Coin>=speedPrice)
        {
            EnemyRadar.startSpeed -= shootSpeedIncreaseAmount;
            GameData.Instance.Coin -= speedPrice;
            speedPrice *= 1.23f;
            PlayerPrefs.SetFloat("Coin", GameData.Instance.Coin);
            PlayerPrefs.SetFloat("AttackSpeed", EnemyRadar.startSpeed);
        }
    }
}
