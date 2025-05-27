using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillTouchScript : MonoBehaviour
{

    public string menuSceneName = "MenuScene";
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            SceneManager.LoadScene(menuSceneName);
        }
    }

}
