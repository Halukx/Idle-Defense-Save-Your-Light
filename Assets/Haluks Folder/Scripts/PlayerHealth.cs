using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    public float playerHP;
    public float playerMaxHP;
    public static float healthRegenAmount;

    private void Awake()
    {
        Instance= this;
    }

    private void Start()
    {
        playerHP = UpgradeManager.instance.playerHP;
        InvokeRepeating("HealthRegen", 1.5f, 1.5f);
    }
    private void Update()
    {
        Debug.Log(playerHP);
    }

    public void HealthRegen()
    {
        if (playerHP<playerMaxHP && GameManager.gameOverUI==false)
        {
            playerHP += healthRegenAmount;
        }
    }
}
