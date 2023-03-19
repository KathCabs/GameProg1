using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPosition : MonoBehaviour
{
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        float posX = PlayerPrefs.GetFloat("PosX", transform.position.x);
        float posY = PlayerPrefs.GetFloat("PosY", transform.position.y);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            float posX = PlayerPrefs.GetFloat("PosX", transform.position.x);
            float posY = PlayerPrefs.GetFloat("PosY", transform.position.y);
            transform.position = new Vector3(posX, posY, transform.position.z);
            if (transform.position != startingPosition)
            {
                Debug.Log("Position loaded!");
            }
        }
    }
}
