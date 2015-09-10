using UnityEngine;
using System.Collections;

/**
* Class for paus menu
**/

public class pausMenuScript : MonoBehaviour {

	public GameObject EventHandler;
	private bool paused;
	// Use this for initialization
	void Start () {
	
		paused = false;

		GetComponent<Renderer> ().enabled = false;


	}
	
	// Update is called once per frame
	void Update () {

		//show texture for paus menu
		if (Input.GetKeyDown (KeyCode.Escape) && EventHandler.GetComponent<holdTime> ().startGame) {
			print ("PAUS");

			if (!paused) 
			{
				GetComponent<Renderer> ().enabled = true;
//				print (menuTexture.transform.position);
				Time.timeScale = 0.0f;
				paused = true;
			}
			else
			{
				GetComponent<Renderer> ().enabled = false;
				Time.timeScale = 1.0f;
				paused = false;
			}
		}

			//if return to game is presses
//			paused = false;

			//if go back to main menu us presses
//			Application.LoadLevel (0);

			//if exit game is pressed
//			Application.Quit();
		

	}
}
