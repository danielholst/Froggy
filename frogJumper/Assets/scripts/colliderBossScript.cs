using UnityEngine;
using System.Collections;

/**
 * Class to handle collision between projectile and enemies
**/

public class colliderBossScript : MonoBehaviour {
	
	private GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "BossEnemy") {
			
			Destroy (gameObject);
			player.GetComponent<shootingScript> ().setShooting (false);
			
			if (player.GetComponent<shootingScript>().getHitsOnBoss() == 10) {
				Destroy (other.gameObject);
			} 
			else {
				player.GetComponent<shootingScript>().increaseHitsOnBoss();
			}
		}
	}
}