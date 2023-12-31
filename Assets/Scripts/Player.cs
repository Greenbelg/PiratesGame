using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private bool isRightDirection = false;
    private Vector2 direction;
    readonly float speed = 6.0f;
    public float jumpForce = 125f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 2.5f;

    private bool isGrounded;

    void Update()
    {
        Flip();
        Move();
        Jump();
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void Move()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = direction * speed;
    }

    public void Flip()
    {
        if (isRightDirection && direction.x < 0f || !isRightDirection && direction.x > 0f)
        {
            isRightDirection = !isRightDirection;
            var localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
