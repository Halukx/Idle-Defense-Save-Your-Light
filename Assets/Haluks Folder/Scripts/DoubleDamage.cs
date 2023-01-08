using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : MonoBehaviour
{
    public float changePoint;
    private void OnEnable()
    {
        changePoint=Random.Range(0,1f);
        
    }
    
}
