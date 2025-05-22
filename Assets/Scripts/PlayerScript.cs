using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound1;
    [SerializeField] private AudioClip jumpSound2;
    [SerializeField] private AudioClip pickupSound;

    public float jumpForce = 10f;
    public float moveForce = 5f;

    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool isFacingRight = true;
    private AudioSource audioSource;

    private bool useFirstJumpSound = true; // Flag to alternate jump sounds

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isJumping)
            {
                ResumeFalling();
                Jump();
            }
            else
            {
                ResumeFalling();
                ReverseDirection();
                Jump();
            }
        }
    }

    void Jump()
    {
        if (!isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        float direction = isFacingRight ? 1f : -1f;
        rb.velocity = new Vector2(direction * moveForce, rb.velocity.y);

        isJumping = true;

        // Play alternating jump sounds
        if (useFirstJumpSound)
        {
            audioSource.PlayOneShot(jumpSound1, 0.5f);
        }
        else
        {
            audioSource.PlayOneShot(jumpSound2, 0.5f);
        }

        useFirstJumpSound = !useFirstJumpSound; // Toggle the flag
    }

    void ReverseDirection()
    {
        isFacingRight = !isFacingRight;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MapObject"))
        {
            isJumping = false;
            ReverseDirection();
            StopFalling();
        }
    }

    void StopFalling()
    {
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
    }

    void ResumeFalling()
    {
        rb.gravityScale = 0.7f;
    }
}