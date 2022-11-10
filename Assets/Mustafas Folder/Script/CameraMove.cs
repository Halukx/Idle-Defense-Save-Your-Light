using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float speed;
    float acceleration;
    float maxspeed;

    bool movement = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
        acceleration = 0.05f;
        maxspeed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(movement)
        {
            movecamera();
        }
        
    }

    void movecamera()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime;
        if(speed > maxspeed)
        {
            speed = maxspeed;
        }
    }
}
