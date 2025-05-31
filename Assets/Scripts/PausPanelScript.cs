using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausPanelScript : MonoBehaviour
{
    public static bool isPaused { get; private set; } = false;
    public GameObject PausMenu;

    public void Pause ()
    {
        isPaused = true;
        PausMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue ()
    {
        PausMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public string gameSceneName = "MenuScene";

    public void StartGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(gameSceneName);
    }

}
