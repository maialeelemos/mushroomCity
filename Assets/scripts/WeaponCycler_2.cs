using UnityEngine;
using System.Collections;

public class WeaponCycler_2 : MonoBehaviour {

	public GameObject[] weapons; 
	public int currentWeapon;
	private int nrWeapons;

	// Use this for initialization
	void Start () {
		nrWeapons = weapons.Length;
	
		currentWeapon = 0;
		deactivateWeapons();
		SwitchWeapon(currentWeapon);

	}
	
	// Update is called once per frame
	void Update () {

		for ( int i = 0; i < 10; ++i )
		{
			if ( Input.GetKeyDown( "" + i ) )
			{
				Debug.Log("keystroke was" + i);
				currentWeapon = i;
				Debug.Log ("update says current weapon is " + currentWeapon);
				if(currentWeapon <= nrWeapons)
				{
					SwitchWeapon(currentWeapon);
				}
			}
		}


	
	}

	void SwitchWeapon(int currentWeapon)
	{	
	
		deactivateWeapons();
		weapons[currentWeapon].gameObject.SetActive(true);

	}

	public void deactivateWeapons()
	{
		int num = 0;
		foreach (GameObject element in weapons)
		{
			Debug.Log("in SW current weapon is " + currentWeapon);
			weapons[num].gameObject.SetActive(false);
			num++;
		}
	}
}
