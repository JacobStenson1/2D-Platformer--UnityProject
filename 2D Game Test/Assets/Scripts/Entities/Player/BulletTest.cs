using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public int damage = 30;


    // Move the bullet to the right according to the speed.
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Rook enemy = hitInfo.GetComponent<Rook>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }


        Destroy(gameObject);
    }
}
