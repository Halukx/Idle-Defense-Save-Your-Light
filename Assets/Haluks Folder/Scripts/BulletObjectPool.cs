using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    public static BulletObjectPool instance { get; private set; }
    [SerializeField] GameObject bulletPrefab;
    public List<GameObject> bulletObjects = new List<GameObject>();
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < 20; i++)
        {
            GameObject go = Instantiate(bulletPrefab);  
            bulletObjects.Add(go);
            go.SetActive(false);
        }
    }
}
