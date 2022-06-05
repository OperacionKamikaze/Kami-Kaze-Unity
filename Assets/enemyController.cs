using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    public bool rightMovement; 

    public float countMovement;

    public int life;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        countMovement = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        randomMovement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HitBoxPlayer")
        {
            life--;
            Destroy(collision.gameObject);

            if(life <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    public void randomMovement(){
        if(rightMovement == true){
            transform.position += transform.right * Time.deltaTime * speed;
        }else{
            transform.position -= transform.right * Time.deltaTime * speed;
        }

        if(countMovement <= 0){
            rightMovement = !rightMovement;
            countMovement = Random.Range(1, 4.5f);
        }else{
            countMovement -= Time.deltaTime;
        }

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -13, 13);
        transform.position = clampedPosition;

    }
}
