using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }
    private void Awake()
    {
        Instance= this;
<<<<<<< HEAD
    }
    private void Start()
    {
        playerHP = UpgradeManager.instance.playerHP;
=======
        
>>>>>>> parent of 8c1c52f (Shop menu and death screen added)
    }
    public float playerHP=3;
    private void Update()
    {
        playerHP=UpgradeManager.instance.playerHP;
    }
}
