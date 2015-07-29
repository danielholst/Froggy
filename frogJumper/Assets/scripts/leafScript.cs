﻿using UnityEngine;
using System.Collections;

public class leafScript : MonoBehaviour {

	private float rotationspeed;
	public Vector2 startPos;
	private Vector3 movementVec;
	public GameObject EventHandler;

	// Use this for initialization
	void Start () {

		movementVec = new Vector3 (0f, -2.54f, 0f);
		rotationspeed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {

		if (EventHandler.GetComponent<holdTime> ().startGame) {
			transform.position += movementVec * Time.deltaTime;
			transform.Rotate (new Vector3 (0f, 0f, rotationspeed));

			if (transform.position.y < -5f) {
				respawn ();
			}

		}
	}

	void respawn() {


		//randomize start position
		transform.position = new Vector3 (Random.Range(-6,6), 11f, 0f);

		//randomize start rotation
		transform.rotation = Quaternion.Euler (0f, 0f,Random.Range(1,360)); // 0f,1f, Random.Range(1, 360));
	}


}
