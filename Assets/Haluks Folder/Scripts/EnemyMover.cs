using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMover : MonoBehaviour
{
    public GameObject target;
    private void Update()
    {
        EnemyMovement();
    }
    public void EnemyMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 1f * Time.deltaTime);
    }
}
