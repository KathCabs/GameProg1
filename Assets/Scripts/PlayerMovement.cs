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

    //forda double jump
    private int jumpsRemaining = 0;
    public int maxJumps = 2;

    //isfacing
    private bool isFacingRight = true;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>(); //puts these properties inside the gameobject

        moveSpeed = 1f;
        jumpForce = 10f;
        isJumping = false;
    }

    void Update() //movement
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) //left or right movement
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse); //no need for delta time because it is applied in default in addforce
                                                                                             //impulse makes the movement instantaneous
        }
        if (!isJumping && moveVertical > 0.1f) //left or right movement. checking if the player is jumping
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);

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
        if (Input.GetKeyDown(KeyCode.W) && jumpsRemaining > 0)
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
            //animator.SetBool("Jump", false);
        }

    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}