using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    private Rigidbody2D rb;
    private Animator anim;
    private float xAngle;
    private float yAngle;
    private float zAngle;

    [Header("Movement")]
    [SerializeField] private float PlayerSpeed;
    private float directionX;
    private KeyCode Left;
    private KeyCode Right;
    public bool canMove;

    [Header("Jump")]
    [SerializeField] private float JumpForce;
    public bool isJumping;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        canMove = true;
        Left = KeyCode.LeftArrow;
        Right = KeyCode.RightArrow;
    }

    void Update()
    {
        directionX = Input.GetAxis("Horizontal");
        if(canMove)
        {
            Move();
        }

        if(directionX != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Jump();
        }
        if (Input.GetKeyDown("up") && !isJumping)
        {
            littleJump();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(PlayerSpeed * directionX, rb.velocity.y);

        if(Input.GetKeyDown(Left))
        {
            GetComponent<Transform>().eulerAngles = new Vector3 (0, 180, 0);
        }

        if(Input.GetKeyDown(Right))
        {
            GetComponent<Transform>().eulerAngles = new Vector3 (0, 0, 0);
        }
    }

    private void littleJump()
    {
        rb.AddForce(new Vector2(rb.velocity.x, JumpForce / 2));
        isJumping = true;
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(rb.velocity.x, JumpForce));
        isJumping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
