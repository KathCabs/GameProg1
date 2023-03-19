using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{

    public int score = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding game object has a tag "Collectible"
        if (collision.gameObject.CompareTag("Enemy") || )
        {
            // Add 1 to score
            score += 1;

            // Destroy the collectible game object
            Destroy(collision.gameObject);
        }
    }
}