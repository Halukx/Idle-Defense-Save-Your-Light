using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMover : MonoBehaviour
{
    public GameObject targetPos;
<<<<<<< HEAD
    public static float enemySpeed=0.4f;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("EnemySpeed"))
        {
            enemySpeed = 0.4f;
            PlayerPrefs.SetFloat("EnemySpeed", enemySpeed);
        }
        else
        {
            enemySpeed = PlayerPrefs.GetFloat("EnemySpeed");
        }
    }
=======

>>>>>>> parent of 36a7ca4 (SOME PROBLEMS FIXED)
    private void Update()
    {
        EnemyMovement();
    }
    public void EnemyMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 0.4f * Time.deltaTime);
    }
}
