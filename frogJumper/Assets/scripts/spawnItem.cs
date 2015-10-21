using UnityEngine;
using System.Collections;

/**
* To spawn the gun object at end of first level
**/

public class spawnItem : MonoBehaviour {

	public GameObject leaf;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {

		//Spawn of gun texture in the end of level 1
		if (leaf.GetComponent<leafScript>().counter == 5) {
			GetComponent<SpriteRenderer>().enabled = true;
		}

		if (GetComponent<SpriteRenderer> ().enabled == true && transform.position.y < 0.1f) {
			GetComponent<SpriteRenderer> ().enabled = false;
		}
	}
}
