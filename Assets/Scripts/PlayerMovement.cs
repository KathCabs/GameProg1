using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>(); //puts these properties inside the gameobject

        moveSpeed = 1f;
        jumpForce = 50f;
        isJumping = false;
    }

    void Update()
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

    }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Platform")
            {
                isJumping = false;
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Platform")
            {
                isJumping = true;
            }
        }


    
}