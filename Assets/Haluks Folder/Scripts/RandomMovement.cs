using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float minSpeed = 1.0f;
    public float maxSpeed = 5.0f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Her frame i�in rastgele bir h�z ve y�n belirle
        float speed = Random.Range(minSpeed, maxSpeed);
        Vector2 direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));

        //Nesnenin h�z�n� ve y�n�n� g�ncelle
        rb2d.velocity = direction * speed;
    }
}