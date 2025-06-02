using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform target; // The object to follow
    public Vector3 offset;   // Offset from the target
    public float smoothSpeed = 4.0f; // Smoothness of the camera movement
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        target = player.transform;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            if(target.position.y >= -0.5f)
            {
                Vector3 desiredPosition = target.position + offset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z); // Keep original Z
            }
            else
            {
                Vector3 desiredPosition = target.position + offset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z); // Keep original Z
            }
        }
    }
}
