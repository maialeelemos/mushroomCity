using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    NavMeshAgent agent;
    GameObject target;
    Animator anim;

    public float range;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
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

    private void GoToTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        anim.SetBool("isWalking", true);
    }

    private void StopEnemy()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
    }


    private void EnemyAttack()
    {
        anim.SetBool("attack", true);
    }
}
