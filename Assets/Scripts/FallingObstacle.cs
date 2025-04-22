using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 2.0f;
    [SerializeField] private float destroyDelay = 1.5f;
    [SerializeField] private float fallDelay = 0.5f;

    private SpriteRenderer rend;
    private Rigidbody2D rb;
    private bool hasFallen = false;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if (fallSpeed > 0)
        {
            rend.flipX = true;
        }

        if (fallSpeed < 0)
        {
            rend.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FallingObstacle") || other.gameObject.CompareTag("Fallen"))
        {
            fallSpeed = -fallSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasFallen)
        {
            hasFallen = true;
            Invoke("StartFalling", fallDelay);
        }
    }

    void StartFalling()
    {
        rb.gravityScale = 1f;
        Invoke("DestroySelf", destroyDelay);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
