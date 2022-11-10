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
    [SerializeField] float damageIncreaseAmount;
    [SerializeField] float shootSpeedIncreaseAmount;
    [Space(25)]
    [Header("Enemy Spawn Rate")]
    [ReadOnlyVariable] public string _info = "U can change spawn rate settings.";
    public float spawnRate=1f;
    public float SpawnRateIncreaseAmount;
    [Space(25)]
    [Header("Hp Settings")]
    public float playerHP;
    


    private void Awake()
    {
        instance = this;
    }
    public void DamageIncrease()
    {
        Damage.playerDamage += damageIncreaseAmount;
    }
    public void AttackSpeedIncrease()
    {
        EnemyRadar.startSpeed -= shootSpeedIncreaseAmount;
    }

    private void Update()
    {
        Debug.Log(EnemyRadar.startSpeed);
    }

}
