using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int Health = 10;
    private bool isFacingRight = true;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 playerRestart;

    // Start is called before the first frame update
    void Start()
    {
        playerRestart = GameObject.FindGameObjectWithTag("Player").transform.position; //gets the initial position
    }

    // Update is called once per frame
    void Update()
    {
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

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = playerRestart;
        }
    }

}
