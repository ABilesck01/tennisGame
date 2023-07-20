using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 3;

    private Rigidbody rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float moveX;
    private bool canWalk = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        EnableWalk();
    }

    //private void Update()
    //{
    //    Flip();
    //}

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(!canWalk) return;

        moveX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveX, 0f, 0f);
        rb.velocity = walkSpeed * movement;
        animator.SetBool("walk", moveX != 0f);
    }

    private void Flip()
    {
        if(moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(moveX < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void EnableWalk()
    {
        canWalk = true;
    }

    public void DisableWalk()
    {
        canWalk = false;
    }
}
