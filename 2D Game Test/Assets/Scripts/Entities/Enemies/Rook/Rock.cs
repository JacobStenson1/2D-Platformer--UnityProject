using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 30;

    void Update()
    {
        rb.velocity = transform.right * speed;

        if (transform.up.y != 0)
        {
            rb.gravityScale += (float)0.1;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerActions player = hitInfo.GetComponent<PlayerActions>();

        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        else if (hitInfo.tag == "Enviroment")
        {
            rb.gravityScale = 0;
            Debug.Log("Rock hit enviroment.");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
