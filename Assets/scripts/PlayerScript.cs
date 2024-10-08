using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    Rigidbody2D rb;
    Animator anim;

    bool isGrounded;
    bool isJumping;

    HelperScript helper;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();

        isGrounded = true;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSprite();
        SpriteJump();
        SpriteLand();
        DoGroundCheck();
        SpriteAttack();

        int yMovement = (int)Input.GetAxisRaw("vertical");
        if (yMovement == 1)
        {
            SpriteJump();
        }
    }

    void MoveSprite()
    {
        anim.SetBool("run", false);


        //moving left
        if (Input.GetKey("left") == true) //detects key pressesd
        {

            rb.velocity = new Vector2(-6f, rb.velocity.y); //speed of movement, the minus means left
            anim.SetBool("run", true); //calls animation
            helper.FlipObject(true);

        }

        if (Input.GetKey("right") == true)
        {

            rb.velocity = new Vector2(6f, rb.velocity.y);
            anim.SetBool("run", true);
            helper.FlipObject(false); // x axis doesn't flip
        }

        if (Input.GetKey("left") != true && Input.GetKey("right") != true)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void SpriteJump()
    {
        if (Input.GetKeyDown("space") && (isGrounded == true)) //the next peice of code will only execute if both are true
        {
            
            rb.AddForce(new Vector3(0, 6, 0), ForceMode2D.Impulse); //sends him upwards, as it is coordinbates, x y z, it sends the sprite up with a force of 5
        }
    }

    void SpriteLand()
    {
        if (isJumping && isGrounded && (rb.velocity.y <= 0)) //checks to see if you're on the ground and jumping, but you velocity is less thatn or equal to 0 
        {
            isJumping = false;
        }
    }

    void DoGroundCheck()
    {
        isGrounded = false;
        anim.SetBool("jump", true);

        if (helper.ExtendedRayCollisionCheck(0.5f, 0.48f) == true)

        {
            isGrounded = true;
            anim.SetBool("jump", false);
        }

        if (helper.ExtendedRayCollisionCheck(-0.5f, 0.48f) == true)
        {
            isGrounded = true;
            anim.SetBool("jump", false);
        }
    }

    void SpriteAttack()
    {

        if (Input.GetKeyDown("m"))
        {
            anim.SetBool("attack", true);
        }
    }
    public void AttackEnd()
    {
        anim.SetBool("attack", false);
    }
}

