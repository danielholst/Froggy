using UnityEngine;
using System.Collections;

/**
 * script to handle collision between enemy projectile and player
 **/

public class enemyProjectileCollisionScript : MonoBehaviour {

	public GameObject fader;
	private GameObject player;
	private Vector3 playerPos;

	// Use this for initialization
	void Start () {

		fader = GameObject.FindGameObjectWithTag ("Fader");
		player = GameObject.FindGameObjectWithTag("Player");
		playerPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		//if enemy projectile hits frog
		if (transform.position.x <= playerPos.x + 0.05f && transform.position.x >= playerPos.x - 0.05f && transform.position.y <= playerPos.y + 0.05f && transform.position.y >= playerPos.y - 0.05f) {
			fader.GetComponent<faderScript>().EndScene();
			print ("frog is hit");
		}
	}
}
