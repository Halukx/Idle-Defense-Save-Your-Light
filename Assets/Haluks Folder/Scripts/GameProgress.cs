using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameProgress : MonoBehaviour
{

    public static int killCounter;
    public static int killToNextWave=5;
    public static float waveToNextLevel=10;
    public static int waveCounter=1;
    public static int levelCounter=1;
    [SerializeField] public TextMeshProUGUI levelCounterText;

    private void Start()
    {
        //levelCounterText=GetComponent<TextMeshProUGUI>();
        levelCounterText.text = levelCounter.ToString();
    }
    private void Update()
    {
        Debug.Log("wave counter:" + waveCounter);
        Debug.Log("level counter " + levelCounter);
        Debug.Log("kill counter: " + killCounter);
        if (killCounter==killToNextWave)
        {
            killToNextWaveIncreaser();
            waveCounter++;
        }
        if (waveCounter>=waveToNextLevel)
        {
            waveToNextLevelIncreaser();
            levelCounter++;
            levelCounterText.text = levelCounter.ToString();
        }
    }


    public void killToNextWaveIncreaser()
    {
        killToNextWave++ ;
        killCounter = 0;
        
    }
    public void waveToNextLevelIncreaser()
    {
        waveToNextLevel += 0.34f;
        killCounter = 0;
        waveCounter = 0;


    }
}
