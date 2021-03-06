using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public Animator animator;
    public GameObject hitBox;
    public Transform hitBoxPosition;

    public bool rightMovement; 

    public float countMovement;
    public float countAttack;

    public float speed;

    public float maxLife;
    public float currentLife;
    public int ataque;
    public int defensa;
    public int experiencia;
    public int oro;
    public int velocidad;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        maxLife = (float)Random.Range(10, 30);
        currentLife = maxLife;

        ataque = Random.Range(2, 15);
        defensa = Random.Range(10, 30);
        oro = Random.Range(1, 100);

        countMovement = Random.Range(1, 3);
        countAttack = Random.Range(1, 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        randomMovement();
        randomAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HitBoxPlayer")
        {
            float playerDamage = player.ataque - player.defensa/2;
            if(playerDamage < 0){
                playerDamage = -playerDamage;
            }
            float auxLife = currentLife - playerDamage;
            currentLife = auxLife;
            Destroy(collision.gameObject);

            if(currentLife <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    public void randomMovement()
    {
        if (rightMovement == true)
        {
            transform.position += transform.right * Time.deltaTime * speed;
            animator.SetBool("moveRight", true);
            animator.SetBool("moveLeft", false);
        }
        else
        {
            transform.position -= transform.right * Time.deltaTime * speed;
            animator.SetBool("moveLeft", true);
            animator.SetBool("moveRight", false);
        }

        if (countMovement <= 0)
        {
            rightMovement = !rightMovement;
            countMovement = Random.Range(1, 4.5f);
        }
        else
        {
            countMovement -= Time.deltaTime;
        }

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -12, 12);
        transform.position = clampedPosition;

    }

    public void randomAttack()
    {

        if (countAttack > 0)
        {
            countAttack -= Time.deltaTime;
            if (countAttack <= 0)
            {
                attackEnemy();
                attackFalseEnemy();
            }
        }
        else if (countAttack <= 0)
        {
            attackEnemy();
            
            attackFalseEnemy();
        }
    }

    public void attackEnemy()
    {
        animator.Play("StickmanAttackR");
        countAttack = Random.Range(1, 3);
    }

    public void attackFalseEnemy()
    {
        animator.SetBool("attackEnemy", false);
    }

    public void executeAttackEnemy()
    {
        Instantiate(hitBox, hitBoxPosition.position, hitBoxPosition.rotation);
        
    }
}
