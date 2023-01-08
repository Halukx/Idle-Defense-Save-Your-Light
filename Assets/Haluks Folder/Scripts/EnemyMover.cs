using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMover : MonoBehaviour
{
    public GameObject targetPos;
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
    private void Update()
    {
        if (GameManager.GameIsOver==false)
        EnemyMovement();
    }
    public void EnemyMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, enemySpeed * Time.deltaTime);
    }
}
