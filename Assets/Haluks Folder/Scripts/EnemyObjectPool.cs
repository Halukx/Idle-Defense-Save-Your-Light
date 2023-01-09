using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    public Queue<EnemyHealth> pooledObjects;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;

    private void Start()
    {
        pooledObjects = new Queue<EnemyHealth>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.gameObject.SetActive(false);

            pooledObjects.Enqueue(obj.GetComponent<EnemyHealth>());
        }
        foreach (var item in pooledObjects)
        {
            item.enabled = true;
        }
    }

    public GameObject GetPooledObject()
    {
        EnemyHealth obj = pooledObjects.Dequeue();
        if (GameManager.GameIsOver==false)
        {
            
            obj.tag = "FarEnemy";
            obj.gameObject.SetActive(true);

            pooledObjects.Enqueue(obj);

           
        }
        return obj.gameObject;
    }
}