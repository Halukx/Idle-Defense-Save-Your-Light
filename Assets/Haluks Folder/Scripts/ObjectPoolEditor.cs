using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEditor : MonoBehaviour
{


    [SerializeField] private EnemyObjectPool objectPool = null;
    public static float spawnRate;

    private void Start()
    {
        EnemyGenerator.Instance.EnemySpawnPositions();
        if (!PlayerPrefs.HasKey("SpawnRate"))
        {
            spawnRate = 3f;
            PlayerPrefs.SetFloat("SpawnRate", spawnRate);
        }
        else
        {
            spawnRate = PlayerPrefs.GetFloat("SpawnRate");
        }
        StartCoroutine(SpawnRoutineEnemy());
    }
    private void Update()   
    {
        
    }

    private IEnumerator SpawnRoutineEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            var obj = objectPool.GetPooledObject();
            obj.transform.position = EnemyGenerator.spawnPoints[Random.Range(1, 88)];
        }
    }
}