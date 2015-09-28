using UnityEngine;
using System.Collections;

/**
* Class for paus menu
**/

public class pausMenuScript : MonoBehaviour {

	public GameObject EventHandler;
	private GameObject frog;
	public bool paused;
	// Use this for initialization
	void Start () {
	
		paused = false;

		GetComponent<Renderer> ().enabled = false;
		frog = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {

		//show texture for paus menu
		if (Input.GetKeyDown (KeyCode.Escape) && EventHandler.GetComponent<holdTime> ().startGame && !frog.GetComponent<lifeScript>().sinking ) {
			print ("PAUS");

			if (!paused) 
			{
				GetComponent<Renderer> ().enabled = true;
				Time.timeScale = 0.0f;
				paused = true;
			}
			else
			{
				resume();
			}
		}
	}

	public void resume() {

		GetComponent<Renderer> ().enabled = false;
		paused = false;
		Time.timeScale = 1.0f;

	}
}
