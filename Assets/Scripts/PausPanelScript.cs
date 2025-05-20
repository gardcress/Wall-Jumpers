using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausPanelScript : MonoBehaviour
{

    public GameObject PausMenu;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause ()
    {
        PausMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue ()
    {
        PausMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public string gameSceneName = "MenuScene";

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameSceneName);
    }

}
