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
    // private bool isSlowingDown = false;
    private float originalSpeed;

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
        // if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        // }
    }

    void FixedUpdate()
    {
        // Constantly move to the right
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SlowZone"))
        {
            originalSpeed = moveSpeed;
            moveSpeed = moveSpeed * 0.2f; // Slow down to 20%
            // isSlowingDown = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SlowZone"))
        {
            moveSpeed = originalSpeed;
            // if (isSlowingDown)
            // {
            //     StartCoroutine(RestoreSpeed()); // Start coroutine to restore speed
            // }
        }
    }

    // private IEnumerator RestoreSpeed()
    // {
    //     float timeToRestore = 0.5f; // Adjust this value for speed of restoration
    //     float elapsedTime = 0f;

    //     float currentSpeed = moveSpeed;

    //     while (elapsedTime < timeToRestore)
    //     {
    //         moveSpeed = Mathf.Lerp(currentSpeed, originalSpeed, (elapsedTime / timeToRestore));
    //         elapsedTime += Time.deltaTime;
    //         yield return null; // Wait until next frame
    //     }

    //     moveSpeed = originalSpeed; // Ensure it reaches the exact original speed
    //     isSlowingDown = false;
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            health--;
            Debug.Log("Ouch! Health: " + health);
        }
    }
}
