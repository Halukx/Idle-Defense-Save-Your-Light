using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    public static Slider slider;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    private void Update()
    {
        SliderMaxValue();
        IncrementSlider();
    }

    public static void IncrementSlider()
    {
        slider.value=GameProgress.killCounter;
    }
    public void SliderMaxValue()
    {
        slider.maxValue = GameProgress.killToNextWave;
    }
}
