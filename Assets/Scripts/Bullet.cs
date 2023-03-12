using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2D;

    public float bulletSpeed = 10;

    public int hitDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb2D.velocity = transform.right * bulletSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D bulletcollision)
    {
        if (bulletcollision.gameObject.CompareTag("Enemy") || bulletcollision.gameObject.CompareTag("Wall")) 
        {
            Enemy enemy = bulletcollision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(hitDamage);

            }
        }

    }
}
