using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float bounciness = 100;
    private SpriteRenderer rend;

    // Start is called before the first frame update
    private void Start()
    {
        rend GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vetor2(moveSpeed, 0) * Time.deltaTime);

        if (moveSpeed > 0)
        {
            rend.flipX = true;
        }

        if (moveSpeed < 0)
        {
            rend.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            moveSpeed = -moveSpeed;
        }

        if (other.gameObject.CompareTag("EnemyBlock"))
        {
            moveSpeed = -moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTage("Player"))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>());
            other.GetComponent<Rigidbody2D>().AddForce = (new Vector2(0, bounciness));
            Destroy(gameObject);
        }

    }
}
