using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public string gameSceneName = "GameScene"; 

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
