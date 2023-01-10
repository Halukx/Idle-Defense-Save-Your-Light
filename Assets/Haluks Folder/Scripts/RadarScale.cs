using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarScale : MonoBehaviour
{
    private void Update()
    {
        transform.localScale = new Vector3(gameObject.GetComponentInParent<CircleCollider2D>().radius, gameObject.GetComponentInParent<CircleCollider2D>().radius, gameObject.GetComponentInParent<CircleCollider2D>().radius);
        //PlayerPrefs.DeleteAll();
    }
}
