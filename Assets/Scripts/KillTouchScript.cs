using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillTouchScript : MonoBehaviour
{

    public string menuSceneName = "MenuScene";
    
    public AudioClip deathSound;
    private AudioSource audioSource;
    private GameObject player;
    private GameObject deathMenu;
    private GameObject deathMenuChild;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        deathMenu = GameObject.FindWithTag("DeathMenu");
        deathMenuChild = deathMenu.transform.Find("Container").gameObject;
        audioSource = player.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            

            audioSource.clip = deathSound;
            //audioSource.PlayOneShot(deathSound);
            audioSource.Play();
            //SceneManager.LoadScene(menuSceneName);
            PlayerDeath(player);
        }
    }

    void PlayerDeath(GameObject player)
    {
        PausPanelScript.isPaused = true;
        Time.timeScale = 0f;
        deathMenuChild.SetActive(true);
    }
}
