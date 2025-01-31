using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;
    float jumpPower = 5f;
    public bool isGrounded = false;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Getting player horizontal movement input
        horizontalInput = Input.GetAxis("Horizontal"); 

        FlipSprite(); // Make sure the sprite is facing the movement direction

        // Check if player pressed jump and is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void FixedUpdate()
    {
        // Apply player horizontal velocity based on the input
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y); 
        // Update animator blend tree parameter
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput > 0f || !isFacingRight && horizontalInput < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Update the flag when player character touches the ground
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }
}
