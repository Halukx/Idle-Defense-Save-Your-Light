using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.7f; //duration of the shake effect
    public float shakeMagnitude = 0.3f; //magnitude of the shake effect
    public GameObject canvasUI;

    private float shakeTimer;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            shakeTimer = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake()
    {
        shakeTimer = shakeDuration;
    }
    public void EnableCanvas()
    {
        canvasUI.SetActive(true);
    }
}