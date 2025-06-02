using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private AudioClip jumpSound1;
    [SerializeField] private AudioClip randomPitchJumpSound;
    [SerializeField] private AudioClip jumpSound2;
    [SerializeField] private AudioClip jumpSound3;
    [SerializeField] private AudioClip jumpSound4;
    [SerializeField] private AudioClip pickupSound;
    public float jumpForce = 5f;    // Vertical force for the jump
    public float moveForce = 3f;     // Horizontal force for the jump direction
    private Rigidbody2D rb;          // Rigidbody2D for physics interactions
    private bool isFacingRight = true; // Keeps track of the current direction (facing right or left)
    private SpriteRenderer sr;
    private AudioSource audioSource;
    private AudioClip[] jumpSounds;

    public Animator ani;

    private bool useFirstJumpSound = true; // Flag to alternate jump sounds

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        ani.SetBool("IsJumping", true);
        ani.SetBool("IsStanding", false);

        AudioClip[] allClips = new AudioClip[] { jumpSound1, jumpSound2, jumpSound3, jumpSound4 };
        jumpSounds = System.Array.FindAll(allClips, clip => clip != null);

    }

    void Update()
    {
        // Check for mouse click or screen tap
        if (!PausPanelScript.isPaused && Input.GetMouseButtonDown(0))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (rb.gravityScale <= 0.4f)
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
        //sr.flipX = !sr.flipX;
        Vector3 flipX = transform.localScale;
        flipX.x *= -1;
        transform.localScale = flipX;
    }

    void Jump ()
    {
        ResumeFalling();
        ChangeDirection();
        ani.SetBool("IsStanding", false);
        ani.SetBool("IsJumping", true);
        if (useFirstJumpSound)
        {
            AudioClip selected = jumpSounds[Random.Range(0, jumpSounds.Length)];
            audioSource.PlayOneShot(selected, 0.5f); //Add commentMore actions
        }
        else if (randomPitchJumpSound != null) 
        {
            audioSource.pitch = Random.Range(0.8f, 1.3f); // Set pitch
            audioSource.clip = randomPitchJumpSound;               // Assign clip
            audioSource.Play();
        } else
        {
            AudioClip selected = jumpSounds[Random.Range(0, jumpSounds.Length)];
            audioSource.PlayOneShot(selected, 0.5f); //Add commentMore actions
        }


        useFirstJumpSound = !useFirstJumpSound; // Toggle the flag
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void ResumeFalling()
    {
        rb.gravityScale = 0.7f;
    }
}
