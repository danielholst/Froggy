using UnityEngine;
using System.Collections;

/**
 * Class to handle collision between projectile and enemies
**/

public class ColliderScript : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag == "Enemy")
		{
			Destroy(other.gameObject);
		}
	}
}
