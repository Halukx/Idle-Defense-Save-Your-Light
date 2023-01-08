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
<<<<<<< HEAD
<<<<<<< HEAD
        
=======
        spawnInterval = SpawnRate.Instance.spawnRate;
>>>>>>> parent of 8c1c52f (Shop menu and death screen added)
=======
        if(GameManager.GameIsOver==false)
        spawnInterval = SpawnRate.Instance.spawnRate;
>>>>>>> parent of 36a7ca4 (SOME PROBLEMS FIXED)
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
