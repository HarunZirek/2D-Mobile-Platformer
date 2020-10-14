using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playables : MonoBehaviour
{
    public int health;
    public float speed;
    public float jumpCount;
    public float jumpForce;
    public float hole;

    private Rigidbody2D rb;
    private Animator anim;

    public bool isPlaying = true;
    private bool isJumping;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatGround;
    public float checkRadius;

    void Start()
    {
        health = 1;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatGround);

        if(health<1)
        {
            isPlaying = false;
            isJumping = false;
            rb.velocity = new Vector2(0, 0);     
        }
 
        if(isPlaying==true)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if(transform.position.y<=hole)
        {
            health = 0;          
        }

        if(isGrounded==true)
        {
            isJumping = false;
            jumpCount = 2;
        }
        else if(isGrounded==false)
        {
            isJumping = true;

            if(jumpCount==2)
            {
                jumpCount = 1;
            }
        }

        Panimation();
   
    }

    public void jump()
    {
        if(jumpCount>0 && isPlaying==true)
        {
            jumpCount--;
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<audioManager>().Play("player_jump");
            isJumping = true;
        }
    }

 
    private void Panimation()
    {
       
        if(isJumping==true && health>0)
        {
            if(jumpCount==1)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isDoubleJumping", false);
            }
            else if(jumpCount==0)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isDoubleJumping", true);
            }
        }
        else
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isDoubleJumping", false);
        }
    }  
}
