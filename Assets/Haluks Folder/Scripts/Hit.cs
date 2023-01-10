using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && GameManager.GameIsOver == false)
        {
            PlayerManager.TakeDamage();
            if (PlayerHealth.Instance.playerHP<=0)
            {
                GameManager.GameIsOver = true;
                GameManager.DeathScene();
            }
        }
    }
}
