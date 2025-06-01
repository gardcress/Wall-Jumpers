using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    //public Transform groundReference; // Assign the ground object here
    public string menuSceneName = "MenuScene";
    private float yDeathLevel = -10;
    public AudioClip deathSound;
    private AudioSource audioSource;
    private GameObject deathMenu;
    private GameObject deathMenuChild;

    private bool hasDied = false;


    void Start()
    {
        // Call "CleanUpObjectsBelowY" first after 1 second, then every 6 seconds
        InvokeRepeating("CleanUpObjectsBelowY", 1f, 6f);
        audioSource = GetComponent<AudioSource>();
        deathMenu = GameObject.FindWithTag("DeathMenu");
        deathMenuChild = deathMenu.transform.Find("Container").gameObject;

    }

    // DESPAWN OBJECTS THAT ARE BELOW A CERTAIN Y LEVEL ALSO UPDATE AT WHAT LEVEL THE PLAYER SHOULD DIE AT
    void CleanUpObjectsBelowY()
    {
        //Debug.Log("Cleaning up");
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        if(transform.position.y - 50f >= -10)
        {
            yDeathLevel = transform.position.y - 50f;
        }

        foreach (GameObject obj in allObjects)
        {
            if (!obj.activeInHierarchy) continue;

            // Skip UI elements and other objects like the mapgenerator
            if (obj.GetComponent<Canvas>() != null || obj.layer == LayerMask.NameToLayer("UI")) continue;
            if (obj.GetComponent<BoxCollider2D>() == null) continue;

            if (obj.transform.position.y < yDeathLevel)
            {
                Debug.Log(obj.transform.position.y + " yd: " + yDeathLevel);
                Destroy(obj);
            }
        }
    }

    void Update()
    {
        //if (groundReference == null) return;

        if (hasDied == false && transform.position.y < yDeathLevel)
        {
            //Debug.Log("Death level: " + yDeathLevel);
            //SceneManager.LoadScene(menuSceneName);
            audioSource.clip = deathSound;
            audioSource.Play();
            PlayerDeath();
            hasDied = true;
        }
    }

    void PlayerDeath()
    {
        PausPanelScript.isPaused = true;
        Time.timeScale = 0f;
        deathMenuChild.SetActive(true);
    }
}
