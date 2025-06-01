using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float bounciness = 100f;
    private SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // Fienden rör sig vertikalt
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        // Flippa sprite beroende på riktning (valfritt)
        rend.flipX = moveSpeed > 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vänd riktning om den träffar annan fiende eller vägg
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBlock"))
        {
            moveSpeed = -moveSpeed;
        }

        // Om den träffar spelaren
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * bounciness);
            }
            Destroy(gameObject);
        }
    }
}

