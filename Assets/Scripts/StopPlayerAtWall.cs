using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerAtWall : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D playerRb;
    private Animator ani;
    public float GravityValue = 0f;



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
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Check if player hit the underside of this object
                if (Vector2.Dot(contact.normal, Vector2.up) > 0.9f)
                {
                    // Underside hit — do nothing, let gravity do its job
                    return;
                }
                if (Vector2.Dot(contact.normal, Vector2.down) > 0.9f)
                {
                    ani.SetBool("IsStanding", true);
                    playerRb.gravityScale = 0f;
                    playerRb.velocity = Vector2.zero;
                    ani.SetBool("IsJumping", false);
                    return;
                }
            }
            // You can also stop the player, e.g.:
            playerRb.gravityScale = GravityValue;
            playerRb.velocity = Vector2.zero;
            ani.SetBool("IsJumping", false);
        }
    }
}
