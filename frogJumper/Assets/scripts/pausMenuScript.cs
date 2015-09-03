using UnityEngine;
using System.Collections;

/**
* Class for paus menu
**/

public class pausMenuScript : MonoBehaviour {

	private bool paused;
	// Use this for initialization
	void Start () {
	
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.Escape)) {
			print ("PAUS");

			paused = true;
		
			//show texture for paus menu 

			//add buttons for the different choices

			//if return to game is presses
			paused = false;

			//if go back to main menu us presses
			Application.LoadLevel (0);

			//if go to level selection is presses
			Application.LoadLevel(1);

			//if exit game is pressed
			Application.Quit();
		
		}
	}
}
