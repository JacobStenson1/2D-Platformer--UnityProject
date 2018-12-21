using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : MonoBehaviour
{
    public int health = 100;

    public Animator animator;
    //public Collider enemyCollider;

    private CircleCollider2D circleCollider;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("isDead", false);
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Runs the animation to show that the troll has died.
        animator.SetBool("isDead", true);
        circleCollider.enabled = false;
        boxCollider.enabled = false;
        rb.gravityScale = 0;
            
        //Destroy(gameObject);
    }
}
