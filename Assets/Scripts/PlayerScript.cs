using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float jumpForce = 10f;    // Vertical force for the jump
    public float moveForce = 5f;     // Horizontal force for the jump direction
    private Rigidbody2D rb;          // Rigidbody2D for physics interactions
    private bool isJumping = false;  // Flag to check if the player is in the air
    private bool isFacingRight = true; // Keeps track of the current direction (facing right or left)

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for mouse click or screen tap
        if (Input.GetMouseButtonDown(0))
        {
            if (!isJumping)
            {
                // Jump if not currently jumping
                Jump();
            }
            else
            {
                // Reverse direction if already jumping
                ReverseDirection();
                Jump(); // Jump again in the new direction
            }
        }
    }

    void Jump()
    {
        // Apply vertical jump force (Y-axis)
        if (!isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // Set the Y velocity for the jump

        }

        // Apply horizontal force in the current direction (right or left)
        float direction = isFacingRight ? 1f : -1f;
        
        rb.velocity = new Vector2(direction * moveForce, rb.velocity.y); // Apply the horizontal force to the velocity

        // Set jumping state to true
        isJumping = true;
    }

    // Reverse the direction of the jump
    void ReverseDirection()
    {
        // Flip the direction flag
        isFacingRight = !isFacingRight;
    }

    // Check when the player lands (to allow more jumps)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player hits the ground (or any object tagged "Ground")
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;  // Reset jump state to allow another jump
        }
    }
}
