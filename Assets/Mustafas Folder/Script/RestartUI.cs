using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartUI : MonoBehaviour
{
    public GameObject RestartCanvas;
    private void Start()
    {
        RestartCanvas.SetActive(false);
    }
    public void No()
    {
        RestartCanvas.SetActive(false);
    }
    public void Yes()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RestartButton()
    {
        RestartCanvas.SetActive(true);
    }
}
