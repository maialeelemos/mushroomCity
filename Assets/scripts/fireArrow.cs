using UnityEngine;
using System.Collections;

public class fireArrow : MonoBehaviour {

	//public GameObject arrow;
	public Rigidbody arrow;
	public GameObject arrowSpawnSpot;
	public float arrowFireRate;

	public float arrowSpeed ;
	

	private float nextFire;

	void Start () 
	{
		nextFire = 0;
		


	}

	void Update ()
	{
		
		if (Input.GetButton("Fire1")&& Time.time > nextFire)
		{
			nextFire = Time.time + arrowFireRate;
			Rigidbody thisArrow;
			thisArrow = Instantiate(arrow, arrowSpawnSpot.transform.position , arrowSpawnSpot.transform.rotation)as Rigidbody;
			thisArrow.linearVelocity = transform.TransformDirection(Vector3.forward * arrowSpeed);


		}
		
	}

}
