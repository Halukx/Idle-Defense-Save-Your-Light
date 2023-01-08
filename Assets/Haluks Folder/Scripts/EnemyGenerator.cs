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


    private void Awake()
    {
        Instance = this;
    }

    public void EnemySpawnPositions()
    {
        if (GameManager.GameIsOver==false)
        {
            for (int i = 0; i < 90; i++)
            {
                float a = i * Mathf.PI * 2f / 90;
                Vector3 spawnPoint = new Vector3(Mathf.Sin(a) * widthScale, Mathf.Cos(a) * heightScale);
                spawnPoint += transform.position;
                spawnPoints.Add(spawnPoint);
            }
        }
    }
}

