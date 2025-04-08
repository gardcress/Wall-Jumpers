using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public string gameSceneName = "MenuScene";

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
