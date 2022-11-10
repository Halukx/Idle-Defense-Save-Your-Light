using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEditor : MonoBehaviour
{

    [SerializeField] public float spawnInterval;

    [SerializeField] private EnemyObjectPool objectPool = null;

    private void Start()
    {
        EnemyGenerator.Instance.EnemySpawnPositions();
        StartCoroutine(nameof(SpawnRoutineEnemy));
    }
    private void Update()
    {
        spawnInterval = EnemyGenerator.spawnRate;
    }

    private IEnumerator SpawnRoutineEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            var obj = objectPool.GetPooledObject();
            obj.transform.position = EnemyGenerator.spawnPoints[Random.Range(1, 88)];//new Vector3(10,10,1);
            
        }
    }
}
