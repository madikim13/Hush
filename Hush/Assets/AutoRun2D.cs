using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRun2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int health = 3;

    private Rigidbody2D rb;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump on key press
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Constantly move to the right
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            health--;
            Debug.Log("Ouch! Health: " + health);
        }
    }
}
