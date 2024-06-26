using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jump = 4f;
    public float runSpeedMultiplier = 1.5f;
    public float currentSpeed;

    public bool isFacingRight = false;
    public bool canJump = true; 
    bool isRunning = false;
    public bool tailControl;

    public Animator animator;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            currentSpeed = 0f;
            tailControl = true;
        }
        else
        {
            currentSpeed = speed;
            tailControl = false;
        }
        //Store horizontal value
        horizontal = Input.GetAxis("Horizontal");

        //Flip Spite when changing direction
        FlipSprite();


        //Jump
        if(Input.GetButtonDown("Jump") && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isRunning = false; //Player stops running when they jump / stops momentum
        }


        //Sprint detection
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (canJump == true) //Player cant run mid air after jumping
            {
                isRunning = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

    }


    private void FixedUpdate()
    {
        //Player walk movement
        rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);

        //Increase player speed if they run / press shift
        if (isRunning && tailControl == false)
        {
            animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
            rb.velocity = new Vector2(horizontal * (speed * runSpeedMultiplier), rb.velocity.y);
        }

    }

    //Flip sprite so it faces direction it is running
    void FlipSprite()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }


    //Check if player is colliding with ground == Jump allowed
    private void OnCollisionEnter2D(Collision2D onGround)
    {
        if((onGround.gameObject.CompareTag("Ground")) || (onGround.gameObject.CompareTag("Enemy")))
        {
            canJump = true;
        }

    }
    private void OnCollisionExit2D(Collision2D offGround)
    {
        if((offGround.gameObject.CompareTag("Ground")) || (offGround.gameObject.CompareTag("Enemy")))
        {
            canJump = false;
        }
    }

}