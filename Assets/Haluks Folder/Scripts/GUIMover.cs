using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIMover : MonoBehaviour
{
    public float minX = -1; // minimum x value for the random position
    public float maxX = 1; // maximum x value for the random position
    public float minY = -1; // minimum y value for the random position
    public float maxY = 1; // maximum y value for the random position

    void Update()
    {
        // generate a random position within the defined range
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 randomPosition = new Vector2(transform.localPosition.x + randomX, transform.localPosition.y + randomY);

        // update the object's position
        transform.localPosition = randomPosition;
    }
}
