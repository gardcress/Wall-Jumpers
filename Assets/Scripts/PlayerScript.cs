using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound, pickupSound;
    public float jumpForce = 5f;    // Vertical force for the jump
    public float moveForce = 3f;     // Horizontal force for the jump direction
    private Rigidbody2D rb;          // Rigidbody2D for physics interactions
    private bool isFacingRight = true; // Keeps track of the current direction (facing right or left)
    private SpriteRenderer sr;
    private AudioSource audioSource;

    public Animator ani;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        // Check for mouse click or screen tap
        if (Input.GetMouseButtonDown(0))
        {
            if(rb.gravityScale <= 0.2f)
            {
                Jump();
            } 
            else
            {
                ChangeDirection();
            }
        }
    }

    void ChangeDirection()
    {
        float direction = isFacingRight ? 1f : -1f;
        rb.velocity = new Vector2(direction * moveForce, rb.velocity.y);
        isFacingRight = !isFacingRight;
        sr.flipX = !sr.flipX;
    }

    void Jump ()
    {
        ResumeFalling();
        ChangeDirection();
        ani.SetBool("IsStanding", false);
        ani.SetBool("IsJumping", true);
        audioSource.PlayOneShot(jumpSound, 0.5f);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void ResumeFalling()
    {
        rb.gravityScale = 0.7f;
    }
}
