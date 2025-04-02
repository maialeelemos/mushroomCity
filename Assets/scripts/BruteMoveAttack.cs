using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BruteMoveAttack : MonoBehaviour
{


    NavMeshAgent agent;
    GameObject target;
    Animator anim;



    public float range;
    public StartBattle battle;

    private bool firstAttack;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        firstAttack = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (battle.battleStarts == true)
        {


            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance < range)
            {
                    StopEnemy();
            }
            else
            {
                GoToTarget();
            }
            
        }
    }

    private void GoToTarget()
    {
        agent.isStopped = false;
        anim.SetBool("attack", false);
        anim.SetBool("isWalking", true);
        agent.SetDestination(target.transform.position);

        if (firstAttack == true)
        {
            agent.speed = 3.5f;
           
        }
        else
        {
            agent.speed = 1f;
            firstAttack = false;
        }
        
        
    }

    private void StopEnemy()
    {

            agent.isStopped = true;
            anim.SetBool("isWalking", false);
            anim.SetBool("attack", true);
        
    }
}



