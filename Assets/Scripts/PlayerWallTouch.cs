using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWallTouch : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D playerRb;
    private Animator ani;

    public float gravityValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        ani = playerRb.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // right
                if (Vector2.Dot(contact.normal, Vector2.left) > 0.9f)
                {
                    StopPlayer();
                    ani.SetBool("IsJumping", false);
                    ApplyGravity(gravityValue);
                    return;
                }

                // left
                if (Vector2.Dot(contact.normal, Vector2.right) > 0.9f)
                {
                    StopPlayer();
                    ani.SetBool("IsJumping", false);
                    ApplyGravity(gravityValue);

                    return;
                }

                
                // top
                if (Vector2.Dot(contact.normal, Vector2.down) > 0.9f)
                {
                    StopPlayer();
                    ani.SetBool("IsJumping", false);
                    ani.SetBool("IsStanding", true);
                    ApplyGravity(0);
                    return;
                }

                // bottom
                if (Vector2.Dot(contact.normal, Vector2.up) > 0.9f)
                {
                    // do nothing
                    return;
                }


            }
        }

        
        
    }

    private void StopPlayer()
    {
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        playerRb.velocity = Vector2.zero;
    }

    private void ApplyGravity(float gravity)
    {
        playerRb.gravityScale = gravity;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        ApplyGravity(0.7f);
        ani.SetBool("IsJumping", true);
    }
}
