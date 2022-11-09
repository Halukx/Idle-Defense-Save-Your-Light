using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMover : MonoBehaviour
{
    public GameObject targetPos;

    private void Update()
    {
        EnemyMovement();
    }
    public void EnemyMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 0.4f * Time.deltaTime);
    }
}
