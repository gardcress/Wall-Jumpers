using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDuration = 10f;

    private Vector3 originalPosition;
    private GameObject player;
    private bool isMovingLeft = false;
    private bool playerIsInFront = false;

    public bool isLeft = true;


    void Start()
    {
        originalPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the Player is tagged 'Player'.");
        }
    }

    void Update()
    {
        if (player.transform.position.y <= transform.position.y + 0.5f && player.transform.position.y >= transform.position.y - 0.5f)
        {
            playerIsInFront = true;
        }


        if (!isMovingLeft && playerIsInFront)
        {
            StartCoroutine(MoveLeftForTime());
        }

        if (isMovingLeft && isLeft)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        } else if (isMovingLeft && !isLeft) {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

    }

    IEnumerator MoveLeftForTime()
    {
        isMovingLeft = true;

        yield return new WaitForSeconds(moveDuration);

        transform.position = originalPosition;
        playerIsInFront = false;
        isMovingLeft = false;
    }
}
