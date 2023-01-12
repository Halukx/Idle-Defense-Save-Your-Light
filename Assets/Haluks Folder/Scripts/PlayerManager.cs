using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; private set; }
    


    private void Awake()
    {
        instance = this;
    }
    public static float takeDamageCooldown = 1f;
    public static  float _takeDamageCooldown;
    private void Start()
    {
        _takeDamageCooldown = takeDamageCooldown;
    }
    private void Update()
    {
        takeDamageCooldown-=Time.deltaTime;
    }
    public static void TakeDamage()
    {
        if (takeDamageCooldown < 0)
        {
            PlayerHealth.playerHP -= Damage.enemyDamage;
            takeDamageCooldown = _takeDamageCooldown;
            Debug.Log(PlayerHealth.playerHP);
        }
    }
}
