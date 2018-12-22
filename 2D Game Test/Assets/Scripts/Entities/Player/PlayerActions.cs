using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float runSpeed = 25f;

    float horizontalMove = 0f;
    bool doJump = false;
    bool doCrouch = false;

    public int health = 150;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            doJump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            doCrouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            doCrouch = false;
        }
    }

    void FixedUpdate()
    {
        //Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, doCrouch, doJump);
        doJump = false;
    }



    //-------



    //Defining functions for UI buttons.
    public void JumpButton()
    {
        doJump = true;
    }

    public void ShootButton()
    {
        Shoot();
    }

    //Defines the shoot function.
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
