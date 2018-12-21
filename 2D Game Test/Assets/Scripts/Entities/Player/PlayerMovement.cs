using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;

    public float runSpeed = 25f;

    float horizontalMove = 0f;
    bool doJump = false;
    bool doCrouch = false;

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
}
