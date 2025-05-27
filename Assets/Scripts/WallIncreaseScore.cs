using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallIncreaseScore : MonoBehaviour
{
    private bool hasBeenHit = false;  // <- Track if this wall was already hit

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasBeenHit && collision.gameObject.CompareTag("Player"))
        {
            Score.instance.UpdateScore();
            hasBeenHit = true;  // <- Mark this wall as already hit
        }
    }
}