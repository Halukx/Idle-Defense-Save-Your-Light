using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] public GameObject Enemy1;
    [SerializeField] public GameObject Enemy2;

    public static EnemyGenerator Instance { get; private set; }
    public int widthScale = 3;
    public float heightScale = 4;
    public static List<Vector2> spawnPoints = new List<Vector2>();

    //public static float spawnRate=1f;
    public float _spawnRateInspector;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
    }
    private void Update()
    {
        //spawnRate = _spawnRateInspector;
        //Debug.Log(spawnRate);
    }

    public void EnemySpawnPositions()
    {
        for (int i = 0; i < 90; i++)
        {
            float a = i * Mathf.PI * 2f / 90;
            Vector3 spawnPoint = new Vector3(Mathf.Sin(a) * widthScale, Mathf.Cos(a) * heightScale);
            spawnPoint += transform.position;
            spawnPoints.Add(spawnPoint);
        }
        
    }
<<<<<<< HEAD
<<<<<<< HEAD
=======

    IEnumerator SpawnEnemy()
    {
        Instantiate(Enemy1, spawnPoints[Random.Range(1, 88)], Quaternion.identity);
        yield return new WaitForSeconds(SpawnRate.Instance.spawnRate);
    }
    
    
>>>>>>> parent of 8c1c52f (Shop menu and death screen added)
=======

    IEnumerator SpawnEnemy()
    {
        if (GameManager.GameIsOver == false)
        {
            Instantiate(Enemy1, spawnPoints[Random.Range(1, 88)], Quaternion.identity);
            yield return new WaitForSeconds(SpawnRate.Instance.spawnRate);
        }
    }
    
    
>>>>>>> parent of 36a7ca4 (SOME PROBLEMS FIXED)
}

