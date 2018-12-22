using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : MonoBehaviour
{
    public int health = 100;
    private bool isDead = false;

    public Animator animator;

    private CircleCollider2D circleCollider;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    public Transform firePoint;
    public GameObject rockPrefab;

    float waitTime = 3;
    bool doneWait;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        animator.SetBool("isDead", false);
        doneWait = false;
    }

    void Update()
    {
        
        waitTime -= Time.deltaTime;
        
        if (waitTime < 0)
        {
            if (doneWait == false)
            {
                ThrowRock();
                waitTime = 3;
            }
            
        }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void ThrowRock ()
    {
        if (isDead != true)
        {
            Instantiate(rockPrefab, firePoint.position, firePoint.rotation);
        }
        
    }

    void Die()
    {
        //Runs the animation to show that the rook has died.
        animator.SetBool("isDead", true);
        //Disables the colliders on the Rook so the player can walk through it.
        circleCollider.enabled = false;
        boxCollider.enabled = false;

        isDead = true;

        //Stops the Rook from falling
        rb.gravityScale = 0;
        
        //Removes the rook from the game.
        //Destroy(gameObject);
    }
}
