using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] public GameObject Enemy1;
    [SerializeField] public GameObject Enemy2;
    public static int widthScale = 6;
    public static float heightScale = 8;
    public List<Vector2> spawnPoints = new List<Vector2>();

    private void Start()
    {
        InvokeRepeating("EnemySpawner",1,2f);
    }

    void EnemySpawner()
    {
        for (int i = 1; i < 90; i++)
        {
            float a = i * Mathf.PI * 2f / 90;
            Vector2 spawnPoint = new Vector2(Mathf.Sin(a) * widthScale, Mathf.Cos(a) * heightScale);
            spawnPoints.Add(spawnPoint);
        }
        Instantiate(Enemy1, spawnPoints[Random.Range(0, 91)], Quaternion.identity);
    }
    
}

