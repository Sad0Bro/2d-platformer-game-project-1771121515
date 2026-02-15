using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;

    private bool isJumping = false;
    private bool isFacingRight = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }

        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

public class GameManager : MonoBehaviour
{
    void Start()
    {
        // Initialize game state
    }

    void Update()
    {
        // Update game state
    }
}

public class Platform : MonoBehaviour
{
    void Start()
    {
        // Initialize platform
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle collision with player
    }
}