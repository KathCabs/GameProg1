using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private Vector3 playerRestart;

    // Start is called before the first frame update
    void Start()
    {
        playerRestart = GameObject.FindGameObjectWithTag("Player").transform.position; //gets the initial position
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = playerRestart; //puts the player back to the initial position 
        }

    }


}
