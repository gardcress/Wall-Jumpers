using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    //public Transform groundReference; // Assign the ground object here
    public string menuSceneName = "MenuScene";

    void Start()
    {
    }

    void Update()
    {
        //if (groundReference == null) return;

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene(menuSceneName);
        }
    }
}
