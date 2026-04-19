using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float scrollSpeed;
    private bool scrolling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameController.instance.jumped && !scrolling)
        {
            rb.linearVelocity = new Vector2 (-scrollSpeed, 0);
            scrolling = true;
        }

        if (GameController.instance.scoreNum % 4 == 0 && GameController.instance.scoreNum >= 4)
        {
            ChangeScrollSpeed();
        }

        if (GameController.instance.gameOver)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void ChangeScrollSpeed()
    {
        if (GameController.instance.scoreNum == 4)
        {
            scrollSpeed = 11.25f;
            rb.linearVelocity = new Vector2 (-scrollSpeed, 0);
        }
        else if (GameController.instance.scoreNum == 8)
        {
            scrollSpeed = 11.5f;
            rb.linearVelocity = new Vector2 (-scrollSpeed, 0);
        } 
        else if (GameController.instance.scoreNum == 12)
        {
            scrollSpeed = 11.75f;
            rb.linearVelocity = new Vector2 (-scrollSpeed, 0);
        }
        else if (GameController.instance.scoreNum == 16)
        {
            scrollSpeed = 12f;
            rb.linearVelocity = new Vector2 (-scrollSpeed, 0);
        } 
    }
}
