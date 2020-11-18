using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //"Public" variables
    [SerializeField] private float speed = 100.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    //Private Variables
    private Rigidbody2D rBody;
    private Animator anim;
    //
    private bool attack;
    [SerializeField] bool isGrounded = false;

    public Transform bow;
    public GameObject arrow;
    public bool facingRight = true;
    public Transform player;
    


    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    //
  
    //
    private void HandleAttacks()
    {
        if (attack && !this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            anim.SetTrigger("attack");
            rBody.velocity = Vector2.zero;
        }
    }
    //
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attack = true;
        }
    }

    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();
        Vector3 bowPos = bow.transform.localPosition;
        Vector3 playerPos = player.transform.localPosition;
        //
        HandleAttacks();
        //
        ResetValues();

        //jump
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }

        //rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        //Communicate with the animator
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", rBody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);

        //
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
        }

        if (horiz > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            bow.GetComponent<SpriteRenderer>().flipX = false;
            bowPos.x = playerPos.x + 498;
            bowPos.y = playerPos.y + 200;
            bow.transform.position = bowPos;
            facingRight = true;
        }
        else if (horiz < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            bow.GetComponent<SpriteRenderer>().flipX = true;
            bowPos.x = playerPos.x + 455;
            bowPos.y = playerPos.y + 200;
            bow.transform.position = bowPos;
            facingRight = false;
        }
    }

    public void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Q))
        {

            GameObject anArrow = Instantiate(arrow, bow.transform.position, bow.transform.rotation);
            ArrowController aScript = anArrow.GetComponent<ArrowController>();
            aScript.Shoot(facingRight);

        }
        //
        HandleInput();
    }

    private void ResetValues()
    {
        attack = false;
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);

    }
}