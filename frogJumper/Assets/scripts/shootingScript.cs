using UnityEngine;
using System.Collections;

/**
 * Function to make the frog able to shoot
 **/

public class shootingScript : MonoBehaviour {

	private int shootingSpeed;
	private int nrOfShots;

	// Use this for initialization
	void Start () {

		shootingSpeed = 5;
		nrOfShots = 20;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("space")) {
			
//			print ("Shooting!");

		}
	}
}
