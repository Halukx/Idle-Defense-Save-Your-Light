using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Enemy")
        {
            PlayerManager.TakeDamage();
            if (PlayerHealth.Instance.playerHP<=0)
            {
                Debug.Log("öldün !!!!!!!!");
            }
        }
    }
}
