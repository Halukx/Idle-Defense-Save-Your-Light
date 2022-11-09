using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRate : MonoBehaviour
{
    public static SpawnRate Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }
    
}
