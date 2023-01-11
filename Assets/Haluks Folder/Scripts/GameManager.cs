using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public static GameObject gameOverUI;
    private void Start()
    {
        gameOverUI.SetActive(false);
    }
    private void Awake()
    {
        gameOverUI = GameObject.FindGameObjectWithTag("DeadPanel");
    }

    //after dead
    public static void DeathScene()
    {
        gameOverUI.SetActive(true);
    }
    public void Restart()
    {
        GameIsOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        GameIsOver = false;
        SceneManager.LoadScene("MainNew");
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
