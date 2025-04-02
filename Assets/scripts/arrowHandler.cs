using UnityEngine;
using System.Collections;

public class arrowHandler : MonoBehaviour 
{

	//public GameObject arrowHit;

	private AudioSource source;
	public AudioClip hitWall;


	// Use this for initialization
	void Start()
	{
		Destroy(gameObject, 5);
		source = GetComponent<AudioSource>();
	}

		// Update is called once per frame
		void Update() {

		}


		void OnTriggerEnter(Collider other)
		{

			if (other.tag == "villain")
			{
				//transform.parent = other.transform;
				//GameObject  villain = other.gameObject;
				//Transform arrow = GetComponent<Transform>();

				//source.PlayOneShot(hitWall);
			

				//Destroy(other.gameObject);
				//

				//arrow.SetParent(villain.transform);


			}

			else
			{
				source.PlayOneShot(hitWall);
			}
		}


		void OnCollisionEnter(Collision other)
		{
			source.PlayOneShot(hitWall);
			Destroy(GetComponent<Rigidbody>());
			Destroy(GetComponent<Collider>());
		}



}