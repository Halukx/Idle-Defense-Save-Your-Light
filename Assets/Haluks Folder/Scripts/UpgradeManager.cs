using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public static UpgradeManager instance { get; private set; }

    [SerializeField] float damageIncreaseAmount;
    [SerializeField] float shootSpeedIncreaseAmount;
    public float spawnRateIncreaseAmount;
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
