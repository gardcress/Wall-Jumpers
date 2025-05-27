using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVerticalSlide : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 2f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = startPos + new Vector3(0, offset, 0);
    }
}
