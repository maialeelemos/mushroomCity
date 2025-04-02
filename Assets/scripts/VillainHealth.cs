using UnityEngine;
using System.Collections;

public class VillainHealth : MonoBehaviour {

	//public GameObject deathSplosion ;
	//public Transform explosionSpawn;
	public int startingHitPoints;
	private int currentHitPoints;
	public GameObject deathSplosion;

	//for explosion when arrow hits
	public GameObject arrowHit;
	Animator anim;

	void Start () 
	{

		currentHitPoints = startingHitPoints;
		anim = GetComponent<Animator>();

	}
	


	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "arrow")
		
		{
			//anim.SetBool("isHit", true);
			Transform arrow;
			arrow = other.GetComponent<Transform>();

			Instantiate(arrowHit, arrow.position, arrow.rotation);
			Destroy(other.gameObject);

			currentHitPoints = (currentHitPoints - 1);
	 


			if (currentHitPoints <= 0)
			{
				VillainDeath ();
			}



	
		}

		if (other.tag == "sword")
		{
			currentHitPoints = (currentHitPoints - 4);
			Debug.Log ("currentHitPoints = " + currentHitPoints);
			VillainDeath ();
		}



	}

	void VillainDeath ()
	{
		//anim.SetBool("isDead", true);
		Transform explosionSpawn;
		explosionSpawn = GetComponent<Transform>();
		Instantiate(deathSplosion,explosionSpawn.position, explosionSpawn.rotation);
		Destroy(gameObject, 1);
		
	}
}
