using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private Vector3 Checkpoint1;

    void Start()
    {
        // Load player's position from PlayerPrefs
        float checkpointX = PlayerPrefs.GetFloat("CheckpointX");
        float checkpointY = PlayerPrefs.GetFloat("CheckpointY");
        float checkpointZ = PlayerPrefs.GetFloat("CheckpointZ");
        transform.position = new Vector3(checkpointX, checkpointY, checkpointZ);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            // Save player's progress here
            PlayerPrefs.SetFloat("CheckpointX", transform.position.x);
            PlayerPrefs.SetFloat("CheckpointY", transform.position.y);
            PlayerPrefs.SetFloat("CheckpointZ", transform.position.z);
            PlayerPrefs.Save();
            Debug.Log("Checkpoint reached!");
        }
    }
}
