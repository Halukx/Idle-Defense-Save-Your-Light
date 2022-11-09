using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEditor : MonoBehaviour
{

    [SerializeField] private float spawnInterval = 1f;

    [SerializeField] private EnemyObjectPool objectPool = null;

    private void Start()
    {
        EnemyGenerator.Instance.EnemySpawnPositions();
        StartCoroutine(nameof(SpawnRoutine));
    }


    private IEnumerator SpawnRoutine()
    {
        while (true)
        {

            var obj = objectPool.GetPooledObject();
            obj.transform.position = EnemyGenerator.spawnPoints[Random.Range(1, 88)];//new Vector3(10,10,1);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
