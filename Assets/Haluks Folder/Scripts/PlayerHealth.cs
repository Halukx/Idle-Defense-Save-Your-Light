using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }
    private void Awake()
    {
        Instance= this;
        
    }
    public float playerHP=3;
}
