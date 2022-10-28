using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMover : Enemy1
{
    void EnemyMovement()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 2f * Time.deltaTime);
    }
}
