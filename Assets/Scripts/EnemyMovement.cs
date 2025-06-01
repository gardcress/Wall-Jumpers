using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float bounceForce = 300f;  // Hur mycket spelaren studsar upp

    private Vector3 target;
    private SpriteRenderer rend;

    void Start()
    {
        target = pointB.position;
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }

        rend.flipX = target.x < transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Kolla om spelaren är över fienden (liten buffert för bättre känsla)
            if (collision.contacts[0].normal.y > 0.5f)
            {
                // Döda fienden
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    playerRb.velocity = Vector2.zero;
                    playerRb.AddForce(Vector2.up * bounceForce);
                }
                Destroy(gameObject);
            }
            else
            {
                // Här kan du lägga skada på spelaren, t.ex.
                Debug.Log("Spelaren skadas eller dör!");
                // Skriv din kod för att hantera spelarens död/skada här
            }
        }
    }
}


