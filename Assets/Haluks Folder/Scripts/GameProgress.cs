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
    public TextMeshProUGUI levelCounterText;
    public TextMeshProUGUI coinCounterText; 

    private void Start()
    {
        levelCounterText.text = levelCounter.ToString();
    }
    private void Update()
    {
        coinCounterText.text = Mathf.FloorToInt(GameData.Instance.Coin).ToString() ;
        if (killCounter>=killToNextWave) //Wave Up
        {
            KillToNextWaveIncreaser();
            waveCounter++;
            ObjectPoolEditor.spawnRate = (ObjectPoolEditor.spawnRate - UpgradeManager.instance.SpawnRateIncreaseAmount); //deðiþken
            CoinIncreaseMultiplier();
            //UpgradeManager.instance.EnemyHPIncrease();
            UpgradeManager.instance.enemyHPIncreaseAmount *= 1.07f;
        }
        if (waveCounter>=waveToNextLevel) //Level Up
        {
            WaveToNextLevelIncreaser();
            levelCounter++;
            levelCounterText.text = levelCounter.ToString();
        }
    }


    public void KillToNextWaveIncreaser()
    {
        killToNextWave=killToNextWave++;
        killCounter = 0;
    }
    public void WaveToNextLevelIncreaser()
    {
        waveToNextLevel += 0.34f;
        killCounter = 0;
        waveCounter = 0;
    }
    public void CoinIncreaseMultiplier()
    {
        UpgradeManager.instance.coinIncreaseAmount *= UpgradeManager.instance.coinIncreaseMultiplier;
    }
}