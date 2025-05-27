using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string gameSceneName = "GameScene";
    public string characterSceneName = "CharacterSelectScene";
    public string menuSceneName = "MenuScene";


    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void SelectCharacter()
    {
        SceneManager.LoadScene(characterSceneName);
    }

    public void Menu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
