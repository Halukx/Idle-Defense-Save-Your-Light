using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public Queue<GameObject> pooledObjects;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;

    private void Awake()
    {
        pooledObjects = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);

            pooledObjects.Enqueue(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject obj = pooledObjects.Dequeue();
        obj.tag = "FarEnemy";
        obj.SetActive(true);

        pooledObjects.Enqueue(obj);

        return obj;
    }
}