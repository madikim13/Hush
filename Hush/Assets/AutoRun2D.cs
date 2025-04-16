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
    private float originalSpeed;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    // 🌟 Sprites
    public Sprite idleSprite;
    public Sprite jumpSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // make sure your character has this
    }

    void Update()
    {
        // Sprite switching
        if (!isGrounded)
        {
            spriteRenderer.sprite = jumpSprite;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }

        // Optional jump input (if you enable jumping later)
        // if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        // }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SlowZone"))
        {
            originalSpeed = moveSpeed;
            moveSpeed = moveSpeed * 0.2f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SlowZone"))
        {
            moveSpeed = originalSpeed;
        }
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
