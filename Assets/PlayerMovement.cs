using System.Transactions;
using System;
//using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public Joystick joystick;

    float horizontalMove = 0f;
    public float speed;

    public GameObject hitBox;

    public Transform hitBoxPosition;

    public float maxLife;
    public float currentLife;

    void Start() {
        maxLife = currentLife;
    }

    // Update is called once per frame
    void Update()
    {

        if (joystick.Horizontal >= .2f)
        {
            transform.Translate(new Vector3(.02f, .0f) * speed);
        } else if (joystick.Horizontal <= -.2f)
        {
            transform.Translate(new Vector3(-.02f, .0f) * speed);
        } else
        {
            horizontalMove = 0f;
        }

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -12, 12);
        transform.position = clampedPosition;

    }

    public void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
    
    public void attackPlayer()
    {
        animator.SetBool("attack", true);
    }

    public void attackFalsePlayer()
    {
        animator.SetBool("attack", false);
    }

    public void executeAttack()
    {
        Instantiate(hitBox, hitBoxPosition.position, hitBoxPosition.rotation);
    }
}