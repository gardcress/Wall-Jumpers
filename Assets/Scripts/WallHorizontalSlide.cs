using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHorizontalSlide : MonoBehaviour
{
    public float moveDistance = 2f;   // Distance to move left and right
    public float moveSpeed = 2f;      // Speed of movement
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = startPos + new Vector3(offset, 0, 0);
    }
}
