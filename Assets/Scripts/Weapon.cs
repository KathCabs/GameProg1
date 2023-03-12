using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;

    public GameObject Playerbullet;

    public GameObject Powerbullet;

    public bool usingPowerbullet = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            usingPowerbullet = true;
        }
    }

    void Shoot()
    {
        if (usingPowerbullet)
        {
            Instantiate(Powerbullet, firePoint.position, firePoint.rotation);
        }

        else
        {
            Instantiate(Playerbullet, firePoint.position, firePoint.rotation);
        }

    }


}
