using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public Joystick joystick;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));



    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove, false, false);
    }

    
}