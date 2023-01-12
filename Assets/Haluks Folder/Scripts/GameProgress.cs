using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public int killCounter;
    public float killToNextWave=5;
    public float waveToNextLevel=10;
    public int waveCounter=1;
    public int levelCounter=1;
    public int spawnRateCounter=0;
    public TextMeshProUGUI levelCounterText;
    public TextMeshProUGUI coinCounterText; 
    public TextMeshProUGUI CurrentHP;
    public Text DamagePrice;
    public Text AttackSpeedPrice;
    public Text RadarPrice;
    public Text MaxHPPrice;
    public Text HPRegenPrice;
    public TextMeshProUGUI MaxHPText;
    public TextMeshProUGUI damageText;

    private void Start()
    {
        levelCounterText.text = levelCounter.ToString();
        if (PlayerPrefs.HasKey("killCounter"))
        {
            killCounter = PlayerPrefs.GetInt("killCounter");
        }
        if (PlayerPrefs.HasKey("waveCounter"))
        {
            waveCounter = PlayerPrefs.GetInt("waveCounter");
        }
        if (PlayerPrefs.HasKey("spawnRateCounter"))
        {
            spawnRateCounter = PlayerPrefs.GetInt("spawnRateCounter");
        }
        
        DamagePriceUpdate();
        AttackSpeedPriceUpdate();
        RadarPriceUpdate();
        MaxHPPriceUpdate();
        HPRegenPriceUpdate();
    }
    private void Update()
    {
        MaxHPText.text = PlayerHealth.playerMaxHP.ToString("F2");
        CurrentHP.text = PlayerHealth.playerHP.ToString("F2");
        damageText.text = Damage.playerDamage.ToString();
        coinCounterText.text = Mathf.FloorToInt(GameData.Instance.Coin).ToString() ;
        if (killCounter>=killToNextWave) //Wave Up
        {
            KillToNextWaveIncreaser();
            waveCounter++;
            ObjectPoolEditor.spawnRate = (ObjectPoolEditor.spawnRate - UpgradeManager.instance.spawnRateIncreaseAmount); //deðiþken
            if (spawnRateCounter < 25)
            {
                UpgradeManager.instance.spawnRateIncreaseAmount = 0.015f;
            }
            else if (spawnRateCounter >= 25 && spawnRateCounter < 100)
            {
                UpgradeManager.instance.spawnRateIncreaseAmount = 0.01f;
            }
            else
            {
                UpgradeManager.instance.spawnRateIncreaseAmount = 0.005f;
            }
                CoinIncreaseMultiplier();
            //UpgradeManager.instance.EnemyHPIncrease();
            UpgradeManager.instance.EnemyHPIncrease();
            spawnRateCounter++;
            PlayerPrefs.SetFloat("SpawnRate", ObjectPoolEditor.spawnRate);
            PlayerPrefs.SetFloat("waveCounter", waveCounter);
        }
        if (waveCounter>=waveToNextLevel) //Level Up
        {
            WaveToNextLevelIncreaser();
            levelCounter++;
            levelCounterText.text = levelCounter.ToString();
            UpgradeManager.instance.enemyHPIncreaseAmount *= 1.07f;
            PlayerPrefs.SetFloat("levelCounter", levelCounter);
        }
    }


    public void KillToNextWaveIncreaser()
    {
        killToNextWave=killToNextWave*1.07f;
        killCounter = 0;
        if (waveCounter%70==0)
        {
            killToNextWave = 31.51f;
        }
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
    public void DamagePriceUpdate()
    {
        DamagePrice.text = UpgradeManager.instance.damagePrice.ToString("F2");
    }
    public void AttackSpeedPriceUpdate()
    {
        AttackSpeedPrice.text = UpgradeManager.instance.speedPrice.ToString("F2");
    }
    public void RadarPriceUpdate()
    {
        RadarPrice.text = UpgradeManager.instance.radarPrice.ToString("F2");
    }
    public void MaxHPPriceUpdate()
    {
        MaxHPPrice.text = UpgradeManager.instance.hpPrice.ToString("F2");
    }
    public void HPRegenPriceUpdate()
    {
        HPRegenPrice.text = UpgradeManager.instance.hpRegenPrice.ToString("F2");
    }
}