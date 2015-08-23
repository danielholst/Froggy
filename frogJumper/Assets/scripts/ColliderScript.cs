using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag == "Enemy")
		{
			Destroy(other.gameObject);

		}
	}
}
