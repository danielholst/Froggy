﻿using UnityEngine;
using System.Collections;

/**
 * Function to handle length and settings of the level.
 **/

public class levelSettings : MonoBehaviour {

	public GameObject fader;
	public GameObject holdTime;
	public int gameSpeed;
	public int level;
	private float timer;

	// Use this for initialization
	void Start () {

		//set time of the level
		if (level == 1 || level == 2)
			timer = 30f;
	}
	
	// Update is called once per frame
	void Update () {

		//test
//		print ("Time = " + timer);
		if (holdTime.GetComponent<holdTime> ().startGame) {
			if (!(timer <= 0f)) {

				timer -= Time.deltaTime;
				if(timer <=1f) {
					fader.GetComponent<faderScript>().EndScene();
				}

			} else {
				//reached end of level
				//fade out level
				//then load and fade in next level
				Application.LoadLevel(level+2);
			}
		}
	}
}