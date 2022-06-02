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

    public GameObject hitBox;

    public Transform hitBoxPosition;

    // Update is called once per frame
    void Update()
    {

        if (joystick.Horizontal >= .2f)
        {
            //horizontalMove = runSpeed;
            transform.Translate(new Vector3(.01f, .0f));
        } else if (joystick.Horizontal <= -.2f)
        {
            //horizontalMove = -runSpeed;
            transform.Translate(new Vector3(-.01f, .0f));
        } else
        {
            horizontalMove = 0f;
        }

        

    }

    public void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    }
    
    public void attack()
    {
        animator.SetBool("attack", true);
    }

    public void attackFalse()
    {
        animator.SetBool("attack", false);
    }

    public void executeAttack()
    {
        Instantiate(hitBox, hitBoxPosition.position, hitBoxPosition.rotation);
    }
}