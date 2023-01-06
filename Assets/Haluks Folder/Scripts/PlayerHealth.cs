using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }
    private void Awake()
    {
        Instance= this;
    }
    private void Start()
    {
        playerHP = UpgradeManager.instance.playerHP;
    }
    public float playerHP=3;
    private void Update()
    {
        
        Debug.Log("Your hp: " + playerHP);
    }
}
