using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public bool enemyInsideTriggerArea;

    private void Start()
    {
        enemyInsideTriggerArea = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInsideTriggerArea = true;
            print("true");
        }
    }
}
