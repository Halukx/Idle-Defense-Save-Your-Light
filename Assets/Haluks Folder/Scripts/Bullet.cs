using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        if (EnemyRadar.ClosestEnemy!=null)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = (EnemyRadar.ClosestEnemy.transform.position - transform.position).normalized*2f;
        }
    }
}
