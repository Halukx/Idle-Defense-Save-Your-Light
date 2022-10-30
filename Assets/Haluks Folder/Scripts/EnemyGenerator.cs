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
        EnemySpawner();
        InvokeRepeating("Spawn", 1,2f);
    }

    void EnemySpawner()
    {
        for (int i = 0; i < 90; i++)
        {
            float a = i * Mathf.PI * 2f / 90;
            Vector2 spawnPoint = new Vector2(Mathf.Sin(a) * widthScale, Mathf.Cos(a) * heightScale);
            spawnPoints.Add(spawnPoint);
        }
        
    }
    void Spawn()
    {
        Instantiate(Enemy1, spawnPoints[Random.Range(1,88)], Quaternion.identity);
    }
    
    
}

