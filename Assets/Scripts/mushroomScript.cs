using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MushroomScript : MonoBehaviour
{
    public GameObject[] targets;  // Drag your 4 targets here in the Inspector

    private int currentTargetIndex = 0;
    private GameObject nextTarget;
    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is missing!");
            return;
        }

        if (anim == null)
        {
            Debug.LogError("Animator component is missing!");
            return;
        }

        if (targets == null || targets.Length == 0)
        {
            Debug.LogError("Target array is not assigned or empty.");
            return;
        }

        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] == null)
            {
                Debug.LogError($"Target at index {i} is null.");
                return;
            }
        }

        agent.stoppingDistance = 0.05f;
        currentTargetIndex = 0;
        nextTarget = targets[currentTargetIndex];

        GoToTarget();
    }


    void Update()
    {
        Debug.Log($"Agent stopped: {agent.isStopped}, Remaining distance: {agent.remainingDistance}, PathPending: {agent.pathPending}");

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            Debug.Log("Reached target, choosing next.");
            StopAndChooseNextTarget();
        }
        else
        {
            Debug.Log("Going to target...");
            GoToTarget();
        }
    }


    private void GoToTarget()
    {
        agent.isStopped = false;
        anim.SetBool("isWalking", true);
        agent.SetDestination(nextTarget.transform.position);
    }

    private void StopAndChooseNextTarget()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);

        currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        nextTarget = targets[currentTargetIndex];

        GoToTarget();
    }
}
