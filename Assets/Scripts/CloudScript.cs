using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private Transform target; 
    private Vector3 initialOffset;

    private float driftingXOffset;
    public float moveSpeed = 1f;
    private int direction = 1;

    void Start()
    {
        direction = Random.value < 0.5f ? -1 : 1;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null)
        {
            Debug.LogWarning("No GameObject with tag 'Player' found!");
            target = Camera.main.transform;
        }
        else
        {
            target = playerObj.transform;
        }

        initialOffset = transform.position - target.position;
        driftingXOffset = initialOffset.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Accumulate drifting movement over time
        driftingXOffset += (moveSpeed * Time.deltaTime) * direction;

        float screenRight = Camera.main.transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect);
        float screenLeft = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect);

        if (direction > 0 && transform.position.x > screenRight)
        {
            direction *= -1; // moving right → hit right edge → go left
        }
        else if (direction < 0 && transform.position.x < screenLeft)
        {
            direction *= -1; // moving left → hit left edge → go right
        }

        Vector3 targetPos = target.position + initialOffset;
        targetPos.x += (driftingXOffset - initialOffset.x); // apply drift

        if (target.position.y >= -0.5f)
        {
            transform.position = targetPos;
        }
        else
        {
            transform.position = new Vector3(targetPos.x, transform.position.y, transform.position.z);
        }
    }

}
