using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public float moveSpeed;
    public float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    public Animator animator;

    public float speed = 15f;

    //forda double jump
    private int jumpsRemaining = 0;
    public int maxJumps = 2;

    private Vector3 playerRestart;

    //isfacing
    private bool isFacingRight = true;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>(); //puts these properties inside the gameobject

        moveSpeed = 1f;
        jumpForce = 10f;
        isJumping = false;

        jumpsRemaining = maxJumps;

        animator = GetComponent<Animator>();

        playerRestart = GameObject.FindGameObjectWithTag("Player").transform.position; //gets the initial position


    }


    void Update() //movement
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        rb2D.velocity = new Vector2(horizontal * speed, rb2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && jumpsRemaining > 0)
        {
            animator.SetBool("isJumping", true);
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            jumpsRemaining--;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 3f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 1f;
        }

        //forda jump
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            //animator.SetBool("Jump", true);
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            jumpsRemaining--;
        }

        // Flip player horizontally if moving left
        if (moveHorizontal > 0 && !isFacingRight)
        {
            Flip();
        }
        // Flip player horizontally if moving right
        else if (moveHorizontal < 0 && isFacingRight)
        {
            Flip();
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }

        if (collision.gameObject.tag == "goal")
        {
            Debug.Log("Congratulations, you've won");
        }

        if (collision.gameObject.CompareTag("Hell"))
        {
            transform.position = playerRestart;
        }
        else if(collision.tag == "Checkpoint")
        {
            playerRestart = transform.position;
        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
    //double jump
    public void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Platform"))
        {
            jumpsRemaining = maxJumps;
            animator.SetBool("isJumping", false);
        }

        if (other.gameObject.tag == "goal")
        {
            CameraFollow.Instance.scenetomoveto();
        }


    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}