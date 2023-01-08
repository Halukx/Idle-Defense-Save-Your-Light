using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinityBackground : MonoBehaviour
{
    public float scrollSpeed = 1f;
    private float offset;
    private Material mat;
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        offset += (Time.deltaTime * scrollSpeed);
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
