using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    void Update()
    {
        if (EnemyRadar.ClosestEnemy != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, EnemyRadar.ClosestEnemy.transform.position, 2f * Time.deltaTime);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            EnemyRadar.ClosestEnemy = null;
            Debug.Log("Destroy gameobject bullte");
        }
    }
}
