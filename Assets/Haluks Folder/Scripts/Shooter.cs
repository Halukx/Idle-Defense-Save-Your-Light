using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shooter : EnemyRadar
{

    

    private void Update()
    {
        
    }

    public IEnumerator Shooting()
    {
        yield return new WaitForSeconds(2f);
        
    }
}
