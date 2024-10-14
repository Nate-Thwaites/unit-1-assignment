using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    HelperScript helper;
    Rigidbody2D rb;
    Animator anim;
    public GameObject player;
    public GameObject enemy;
    bool isGrounded;
    float r = -7f;

    int health = 10;

    int enemyDir;

    

    void Start()
    {
        // Add the helper script and store a reference to it                                               
        helper = gameObject.AddComponent<HelperScript>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyDir = 6;
    }


    void Update()
    {
        EnemyChase1();
        //EnemyPatrol();
        //EnemyGrounded();
        //TakeDamage();
        EnemyDie();

    }

    void EnemyChase1()
    {
        helper.EnemyChase();
        

        
    }

    void TakeDamage(float damage)
    {
        print(damage);
        health = health - 5;


    }

    void EnemyDie()
    {
        if (health == 0)
        {
            anim.SetBool("die", true);

        }
    }
    
    

        /*void EnemyPatrol()
         {
            rb.velocity = new Vector2(enemyDir, 0);


            // check for righthand side

            if (helper.ExtendedRayCollisionCheck(0.5f, 0.0f) == false)
            {
                if (enemyDir > 0)
                {
                    enemyDir = -enemyDir;
                    helper.FlipObject(true);
                    anim.SetBool("move", true);
                }
            }

            // check for lefthand side

            if (helper.ExtendedRayCollisionCheck(-0.5f, 0.0f) == false)
            {
                if (enemyDir < 0)
                {
                    enemyDir = -enemyDir;
                    helper.FlipObject(false);
                    anim.SetBool("move", true);
                }

                
            }
        }*/







    
}