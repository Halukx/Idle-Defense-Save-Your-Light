using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] public GameObject Enemy1;
    [SerializeField] public GameObject Enemy2;

    public static EnemyGenerator Instance;
    public int widthScale = 3;
    public float heightScale = 4;
    public static List<Vector2> spawnPoints = new List<Vector2>();

    public float spawnRate;
    [SerializeField] public float _spawnRateInspector;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
    }
    private void Update()
    {
        spawnRate = _spawnRateInspector;
    }

    public void EnemySpawnPositions()
    {
        for (int i = 0; i < 90; i++)
        {
            float a = i * Mathf.PI * 2f / 90;
            Vector2 spawnPoint = new Vector2(Mathf.Sin(a) * widthScale, Mathf.Cos(a) * heightScale);
            spawnPoints.Add(spawnPoint);
        }
        
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(Enemy1, spawnPoints[Random.Range(1, 88)], Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);
    }
    
    
}

