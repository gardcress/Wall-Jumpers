using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    void Start()
    {
        // Get the camera's view bounds
        Camera cam = Camera.main;
        float screenHeight = cam.orthographicSize * 2;
        float screenWidth = (screenHeight * cam.aspect);

        // Adjust the position and scale of the square
        // Set the square's width to cover the entire screen width
        transform.localScale = new Vector3(screenWidth, transform.localScale.y, transform.localScale.z);

        // Move the square so the bottom edge aligns with the bottom of the screen
        transform.position = new Vector3(0, -screenHeight / 2 + transform.localScale.y / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
