using UnityEngine;
using System.Collections;

public class swingSword : MonoBehaviour {

	Animator anim;
	private float nextSwing;
	public float swordSwingRate;

	void Start () 
	{
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButton("Fire1"))
		{
			GetComponent<Animation>().Play("swordSlash");
		}


		/* if (Input.GetButton("Fire1")&& Time.time > nextSwing)
		{
			nextSwing = Time.time + swordSwingRate;

	
		} */
	}
}
