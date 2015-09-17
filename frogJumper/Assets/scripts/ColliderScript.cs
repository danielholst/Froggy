using UnityEngine;
using System.Collections;

/**
 * Class to handle collision between projectile and enemies
**/

public class ColliderScript : MonoBehaviour {

	private GameObject player;
	private GameObject projectileShadow;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
//		projectileShadow = GameObject.FindGameObjectWithTag ("ProjectileShadow");
	}

	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag == "Enemy")
		{
			Destroy(other.gameObject);
			player.GetComponent<shootingScript>().setShooting(false);
			Destroy (gameObject);
//			Destroy (projectileShadow);
		}
	}
}
