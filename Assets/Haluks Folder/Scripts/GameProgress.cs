using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public int killCounter;
    public int killToNextWave=5;
    public float waveToNextLevel=10;
    public int waveCounter=1;
    public int levelCounter=1;
    [SerializeField] public TextMeshProUGUI levelCounterText;

    private void Start()
    {
        levelCounterText.text = levelCounter.ToString();
    }
    private void Update()
    {
        //Debug.Log("wave counter:" + waveCounter);
        //Debug.Log("level counter " + levelCounter);
        //Debug.Log("kill counter: " + killCounter);
        if (killCounter==killToNextWave)
        {
            killToNextWaveIncreaser();
            waveCounter++;
            SpawnRate.spawnRate = SpawnRate.spawnRate*0.991f; //deðiþken
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
