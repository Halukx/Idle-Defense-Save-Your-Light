using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    private GameObject[] MultipleEnemies;
    public static Transform ClosestEnemy;

    
    [SerializeField] public GameObject Bullet;


    private void Start()
    {
        ClosestEnemy = null;

    }

    private void Update()
    {
        Debug.Log(GetClosestEnemy());
        
    }

    private void Attack()
    {

            var newBullet = Instantiate(Bullet, new Vector3(0, 0, 0), Quaternion.identity);
            newBullet.transform.parent = null;

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("giriyor");
        if ( collision.CompareTag("Enemy"))
        {
            
            ClosestEnemy = GetClosestEnemy();

            Debug.Log("sadsad");
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            Invoke("Attack", 0.01f);
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
