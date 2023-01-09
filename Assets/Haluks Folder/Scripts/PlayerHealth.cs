using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    public float playerHP = 3;
    public float playerMaxHP = 3;
    public static float healthRegenAmount = 0.02f;

    private void Awake()
    {
        Instance= this;
    }

    private void Start()
    {
        playerHP = UpgradeManager.instance.playerHP;
        InvokeRepeating("HealthRegen", 0, 1.5f);
    }
    private void Update()
    {
        Debug.Log(playerHP);
    }

    public void HealthRegen()
    {
        if (playerHP<playerMaxHP)
        {
            playerHP += healthRegenAmount;
        }
    }
}
