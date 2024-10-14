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
    float e = -4f;

    int enemyDir;

    float ex, px;

    void Start()
    {
        // Add the helper script and store a reference to it                                               
        helper = gameObject.AddComponent<HelperScript>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyDir = 2;
    }


    void Update()
    {
        //EnemyMove();
        EnemyPatrol();
        //EnemyGrounded();
    }

    void EnemyMove()
    {
        helper.FlipObject(true);

        if (helper.ExtendedRayCollisionCheck(0.5f, 0.4f) == true)
        {
            isGrounded = true;
        }
        if (helper.ExtendedRayCollisionCheck(-0.5f, 0.4f) == true)
        {
            isGrounded = true;
        }

        ex = enemy.transform.position.x;
        px = player.transform.position.x;

        if (isGrounded == true)
        {
            print("walk left");
            rb.velocity = new Vector2(e, 0);





            if (helper.ExtendedRayCollisionCheck(-0.5f, 0.4f) == false)
            {
                e = e * -1;
                helper.FlipObject(true);
            }

            if (helper.ExtendedRayCollisionCheck(0.5f, 0.4f) == false)
            {
                e = e * -1;
                helper.FlipObject(true);
            }



        }    }

        void EnemyPatrol()
        {
            rb.velocity = new Vector2(enemyDir, 0);


            // check for righthand side

            if (helper.ExtendedRayCollisionCheck(0.5f, 0.0f) == false)
            {
                if (enemyDir > 0)
                {
                    enemyDir = -enemyDir;
                    helper.FlipObject(true);
                }
            }

            // check for lefthand side

            if (helper.ExtendedRayCollisionCheck(-0.5f, 0.0f) == false)
            {
                if (enemyDir < 0)
                {
                    enemyDir = -enemyDir;
                    helper.FlipObject(false);
                }
            }
        }







}