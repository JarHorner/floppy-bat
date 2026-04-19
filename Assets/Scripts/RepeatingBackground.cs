using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RepeatingBackground : MonoBehaviour
{
    private float groundHorizontalLength;

    void Start()
    {
        groundHorizontalLength = 30f;
    }

    void Update()
    {
        if (transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground() 
    {
        Vector2 groundOffset = new Vector2 (groundHorizontalLength * 2f, 0f);
        transform.position = (Vector2) transform.position + groundOffset;
    }
}
