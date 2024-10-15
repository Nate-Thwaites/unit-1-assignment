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
    public bool isGrounded;
    public bool doPatrol;

    public GameObject triggerArea;

    float ex, px;
    float r = 4f;

    public bool chasePlayer = false;

    int health = 10;

    int enemyDir;

    

    void Start()
    {
        // Add the helper script and store a reference to it                                               
        helper = gameObject.AddComponent<HelperScript>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyDir = 6;
        doPatrol= false;
        
    }


    void Update()
    {
        EnemyChase1();


        EnemyPatrol();

        EnemyAttack();
    

        //EnemyGrounded();
        
        EnemyDie();

    }


        
    void EnemyChase1()
    {
        //check for player entering trigger area

        if (triggerArea.GetComponent<EnemyTriggerScript>().playerInsideTriggerArea == false)
        {
            return;
        }



        ex = enemy.transform.position.x;
        px = player.transform.position.x;


       
        
        if (helper.ExtendedRayCollisionCheck(0.5f, 0.4f) && (helper.ExtendedRayCollisionCheck(-0.5f, 0.4f) == true))
        {
            isGrounded = true;
        }

        else
        {
            isGrounded = false;
        }


        

        if (ex < px)
        {
                
            rb.velocity = new Vector2(r, 0);
            anim.SetBool("move", true);
            helper.FlipObject(false);
        }

        if (ex > px)
        {
            anim.SetBool("move", true);
            rb.velocity = new Vector2(-r, 0);
            helper.FlipObject(true);
              
        }
        
    }




    void TakeDamage(float damage)
    {
        print(damage);
        health = health - 5;
        print(health);
        
        


    }

    void EnemyDie()
    {
        if (health == 0)
        {
            anim.SetBool("die", true);

        }
    }
    
    

    void EnemyPatrol()
    {

        if (triggerArea.GetComponent<EnemyTriggerScript>().playerInsideTriggerArea == true)
        {
            return;
        }




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
    }

    void EnemyAttack()
    {
        if (triggerArea.GetComponent<EnemyAttackTrigger>().enemyInsideTriggerArea == false)
        {
            return;

        }

        if (triggerArea.GetComponent<EnemyAttackTrigger>().enemyInsideTriggerArea == true)
        {
            anim.SetBool("attack", true);
            print("enemy attack");
        }
        



    }






}