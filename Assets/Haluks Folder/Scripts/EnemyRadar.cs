using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    private GameObject[] MultipleEnemies;
    public Transform ClosestEnemy;
    public bool EnemyContact;


    private void Start()
    {
        ClosestEnemy = null;
        EnemyContact = false;
    }

    private void Update()
    {
        
    }

    private void Attack()
    {
        if (EnemyContact)
        {
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger =! true && collision.CompareTag("Enemy"))
        {
            if (ClosestEnemy != null)
            {
                ClosestEnemy.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
            }
            ClosestEnemy = GetClosestEnemy();
            ClosestEnemy.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.7f, 0, 1);
            EnemyContact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger = !true && collision.CompareTag("Enemy"))
        {
            EnemyContact = false;
            ClosestEnemy.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }


    private void OnDestroy()
    {
        if (ClosestEnemy != null)
        {
            ClosestEnemy.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
        }
    }

    public Transform GetClosestEnemy()
    {
        MultipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float ClosestDistance = Mathf.Infinity;
        Transform trans = null;


        foreach (GameObject go in MultipleEnemies)
        {
            float CurrentDistance;
            CurrentDistance = Vector3.Distance(transform.position,go.transform.position);
            if (CurrentDistance<ClosestDistance)
            {
                ClosestDistance = CurrentDistance;
                trans = go.transform;
            }
        }
        return trans;
    }
}
