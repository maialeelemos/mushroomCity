using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SkeletonManager : MonoBehaviour 
{ 

    NavMeshAgent agent;
    GameObject target;
    Animator anim;
    public float range;
    public int startingHitPoints;
    private int currentHitPoints;
    public GameObject deathSplosion;
    public GameObject arrowSplosionSound;
    public GameObject deathSplosionSound;
    public int numSkeletons;
    public int numForVictory;
    public Image victoryImage;
    public  VictoryNow victoryObject;
    public StartBattle battle;

    //for explosion when arrow hits
    public GameObject arrowHit;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        currentHitPoints = startingHitPoints;
        anim.SetBool("isDead", false);
        victoryImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (battle.battleStarts == true)
        {


            if (PlayerHealth.gameOver == false)
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
            else
            {
                Debug.Log("SkelManger says GomeOver");
                anim.SetBool("GameOver", true);

            }
        }


    }


    private void GoToTarget()
    {
        agent.isStopped = false;
        anim.SetBool("attack", false);
        agent.SetDestination(target.transform.position);
        anim.SetBool("isWalking", true);
    }

    private void StopEnemy()
    {
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
        anim.SetBool("attack", true);
    }


    private void EnemyAttack()
    {
         anim.SetBool("attack", true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "arrow")

        {
            //anim.SetBool("isHit", true);
            Transform arrow;
            arrow = other.GetComponent<Transform>();
            Instantiate(arrowHit, arrow.position, arrow.rotation);
            Instantiate(arrowSplosionSound, arrow.position, arrow.rotation);
            Destroy(other.gameObject);
            currentHitPoints = (currentHitPoints - 1);
           

            if (currentHitPoints <= 0)
            {
                anim.SetBool("isWalking", false);
                VillainDeath();
            }
        }

        if (other.tag == "sword")
        {
            currentHitPoints = (currentHitPoints - 4);
            Debug.Log("sword hit");
            VillainDeath();
        }
    }

    void VillainDeath()
    {
        //anim.SetBool("isHit", false);
        anim.SetBool("isWalking", false);
        Transform explosionSpawn;
        explosionSpawn = GetComponent<Transform>();
        Instantiate(deathSplosion, explosionSpawn.position, explosionSpawn.rotation);
        Instantiate(deathSplosionSound, explosionSpawn.position, explosionSpawn.rotation);
        numSkeletons = numSkeletons + 1;
        if (numSkeletons == numForVictory)
        {
            victoryImage.enabled = true;
            Debug.Log("Here");
            victoryObject.Victory();
            Debug.Log("DidIBreakHere?");
        }

        Destroy(gameObject);
    }
 

}

