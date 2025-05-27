using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeWallScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D playerRb;
    private Animator ani;
    public float GravityValue = 0f;
    public string menuSceneName = "MenuScene";
    public bool isRight = true;


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
                if (Vector2.Dot(contact.normal, Vector2.left) > 0.9f && isRight)
                {
                    SceneManager.LoadScene(menuSceneName);
                    return;
                }
                else if (Vector2.Dot(contact.normal, Vector2.right) > 0.9f && !isRight)
                {
                    SceneManager.LoadScene(menuSceneName);
                    return;
                }

                // Check if player hit the underside of this object
                if (Vector2.Dot(contact.normal, Vector2.up) > 0.9f)
                {
                    // Underside hit — do nothing, let gravity do its job
                    return;
                }
                if (Vector2.Dot(contact.normal, Vector2.down) > 0.9f)
                {
                    ani.SetBool("IsStanding", true);
                    break;
                }
            }
            // You can also stop the player, e.g.:
            playerRb.gravityScale = GravityValue;
            playerRb.velocity = Vector2.zero;
            ani.SetBool("IsJumping", false);
        }
    }
}
