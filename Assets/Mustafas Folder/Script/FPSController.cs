using UnityEngine;

public class FPSController : MonoBehaviour
{
    // FPS sabitleme de�eri (�rne�in, 60 FPS)
    public int targetFrameRate = 60;

    void Start()
    {
        // FPS'leri hedef de�ere ayarla
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
}
