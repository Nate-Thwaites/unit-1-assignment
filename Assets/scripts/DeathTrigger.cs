using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerDead;
    public GameObject triggerArea;

    private void Start()
    {
        playerDead = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


           
            print("dead");
            playerDead = true;
        }

        if (playerDead == true)
        {
            SceneManager.LoadScene("Death Screen");
            

            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Game");
                playerDead = false;
                print("revive");
            }   
                
            
        }


        

            



            
        
    }
}

