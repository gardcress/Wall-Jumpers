using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Transform groundReference; // Assign the ground object here
    public string menuSceneName = "MenuScene";

    void Update()
    {
        if (groundReference == null) return;

        if (transform.position.y < (groundReference.position.y - 2.0f))
        {
            SceneManager.LoadScene(menuSceneName);
        }
    }
}
