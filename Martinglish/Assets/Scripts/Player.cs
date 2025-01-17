using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    Rigidbody2D rb;
    Collider2D col;
    float movex;
    bool jump;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col= GetComponent<Collider2D>(); 
        anim= GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Walk();
        Flip();
        Jump();
    }


    void Update()
    {
        movex = Input.GetAxisRaw("Horizontal");
        if (!jump && Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        
    }
    void Walk()
    {
        Vector2 vel = new Vector2(movex * speed * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = vel;
        anim.SetBool("isWalking", Mathf.Abs(rb.velocity.x) > Mathf.Epsilon);
    }

    void Flip()
    {
        float vx = rb.velocity.x;
        if (Mathf.Abs(vx) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(vx), 1);
        }
    }
    void Jump()
    {
        if (!jump) return;

        jump = false;

        if (!col.IsTouchingLayers(LayerMask.GetMask("Terrain", "Platforms","Traps")))
            return;

        rb.velocity += new Vector2(0, jumpSpeed);
        anim.SetTrigger("isJumping");


    }







}
