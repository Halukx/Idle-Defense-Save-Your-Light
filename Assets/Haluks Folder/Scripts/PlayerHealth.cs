using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }
    public static float playerMaxHP;
    public static float healthRegenAmount = 5f;
    public float time1 = 0f;
    public float time2 = 1.5f;
    public static float playerHP;

    private void Awake()
    {
        Instance= this;
    }

    private void Start()
    {
        InvokeRepeating("HealthRegen", 1.5f, 1.5f);
        if (PlayerPrefs.HasKey("playerMaxHP"))
        {
            playerMaxHP = PlayerPrefs.GetFloat("playerMaxHP");
        }
    }
    private void Update()
    {
        Debug.Log(playerHP) ;
    }

    public void HealthRegen()
    {
        if (playerHP<playerMaxHP && GameManager.gameOverUI==true)
        {
            playerHP += healthRegenAmount;
            Debug.Log("health regen");
        }
    }
}
