﻿using UnityEngine;
using System.Collections;

/**
 * script to handle collision between enemy projectile and player
 **/

public class enemyProjectileCollisionScript : MonoBehaviour {
	
	private GameObject player;
	private Vector3 playerPos;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("Player");
		playerPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		//if enemy projectile hits frog
		if (transform.position.x <= playerPos.x + 0.02f && transform.position.x >= playerPos.x - 0.02f && transform.position.y <= playerPos.y + 0.02f && transform.position.y >= playerPos.y - 0.02f) {
			player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, -40f, 0f));
			print ("frog is hit");
		}
	}
}
