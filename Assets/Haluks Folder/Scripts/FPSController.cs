using UnityEngine;

public class FPSController : MonoBehaviour
{
    // FPS sabitleme deðeri (örneðin, 60 FPS)
    public int targetFrameRate = 60;

    void Start()
    {
        // FPS'leri hedef deðere ayarla
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
}
