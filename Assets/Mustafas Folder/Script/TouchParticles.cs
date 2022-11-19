using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchParticles : MonoBehaviour
{   
    public ParticleSystem yeap;
    public float distFromCam = 10; //distance of the emitter from the camera
    
    private void Start()
    {
        yeap.Pause();
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distFromCam));
            yeap.transform.position = pos;
            yeap.Play();
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            waiter();
            yeap.Pause();
        }
        
    }

    void StartCoroutine(Func<IEnumerator> wait)
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);    
    }
}

