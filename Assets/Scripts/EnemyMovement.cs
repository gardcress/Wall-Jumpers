using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float moveHeight = 2.0f;
    [SerializeField] private float bounciness = 300f;
    [SerializeField] private string menuSceneName = "MenuScene"; // Samma scen som i GameOverScript

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float newY = startPos.y + Mathf.PingPong(Time.time * moveSpeed, moveHeight);
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            // Kontrollera om spelaren hoppar på fienden uppifrån
            if (other.transform.position.y > transform.position.y + 0.3f)
            {
                if (rb != null)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * bounciness);
                }

                Destroy(gameObject); // Fienden dör
            }
            else
            {
                // Spelaren träffade fienden från sidan eller underifrån → Game Over
                SceneManager.LoadScene(menuSceneName); // Samma som när spelaren faller ner
            }
        }
    }
}




