using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy1 : MonoBehaviour
{
    public float HP = 10;
    public GameObject target;
    private void Start()
    {
        
    }
    private void Update()
    {
        EnemyMovement();
    }


    void EnemyMovement()
    {
        
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,2f*Time.deltaTime);
    }
}
