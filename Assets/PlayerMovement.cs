using System.Transactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.SceneManagement;


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
    public int ataque;
    public int defensa;
    public int experiencia;
    public int oro;
    public int velocidad;
    public int vida;

    public enemyController enemy;

    DatabaseReference reference;

    void Start() {

        FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
        reference = database.RootReference;

        maxLife = 5;
        currentLife = maxLife;
        
        reference.Child("users").Child("pepito").GetValueAsync().ContinueWith(task =>
        {
            if(task.IsCompleted)
            {
                DataSnapshot snap = task.Result;
                //maxLife = (float)snap.Child("vida").Value;
                ataque = int.Parse(snap.Child("ataque").Value.ToString());
                defensa = int.Parse(snap.Child("defensa").Value.ToString());
                experiencia = int.Parse(snap.Child("experiencia").Value.ToString());
                oro = int.Parse(snap.Child("oro").Value.ToString());
                velocidad = int.Parse(snap.Child("velocidad").Value.ToString());
                vida = int.Parse(snap.Child("vida").Value.ToString());
                
                maxLife = (float)vida;
                currentLife = maxLife;


            } else
            {
                print("Fallo la conexi�n");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

        if (joystick.Horizontal >= .2f)
        {
            transform.Translate(new Vector3(.02f, .0f) * speed);
            animator.SetBool("moveRight", true);
            animator.SetBool("moveLeft", false);
        } else if (joystick.Horizontal <= -.2f)
        { 
            transform.Translate(new Vector3(-.02f, .0f) * speed);
            animator.SetBool("moveLeft", true);
            animator.SetBool("moveRight", false);
        } else
        {
            animator.SetBool("moveRight", false);
            animator.SetBool("moveLeft", false);
            horizontalMove = 0f;
        }

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -12, 12);
        transform.position = clampedPosition;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HitBoxPlayer")
        {
            float enemyDamage = enemy.ataque - enemy.defensa/2;
            if(enemyDamage < 0) {
                enemyDamage = -enemyDamage;
            }
            float auxLife = currentLife - enemyDamage;
            currentLife = auxLife;
            Destroy(collision.gameObject);

            if (currentLife <= 0)
            {
                Destroy(gameObject);
            }
        }

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