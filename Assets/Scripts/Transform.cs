using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log ("I have started");
        Debug.LogWarning("Warning Log");
        Debug.LogError("Log Error");


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log ("updating");

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.0001f, transform.position.z);
    }
}
