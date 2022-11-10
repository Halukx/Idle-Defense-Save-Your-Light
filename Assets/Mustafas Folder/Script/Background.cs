using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float backgroundposition;
    float distance = 456f;
   
    void Start()
    {
        backgroundposition = transform.position.y;
    }

  
    void Update()
    {
        if (backgroundposition + distance < Camera.main.transform.position.y) ;
        {
            BackgroundPlacement();
        }
        
    }
    void BackgroundPlacement()
    {
        backgroundposition = +(distance * 2);
        Vector2 NewPosition = new Vector2(110, backgroundposition);
        transform.position = NewPosition;
    }
}
