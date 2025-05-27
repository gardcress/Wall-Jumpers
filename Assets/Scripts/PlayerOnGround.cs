using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D playerRb;
    private Animator ani;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        ani = playerRb.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            ani.SetBool("IsStanding", true);
            playerRb.velocity = Vector2.zero;
            ani.SetBool("IsJumping", false);
        }
    }
}
