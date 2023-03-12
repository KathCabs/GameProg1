using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBullet : MonoBehaviour
{

    public float speed = 50f;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject powereffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.gameObject.CompareTag("Enemy") || hitInfo.gameObject.CompareTag("Ground"))
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }


            Destroy(gameObject);

        }
    }
}
