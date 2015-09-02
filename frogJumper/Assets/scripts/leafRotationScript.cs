using UnityEngine;
using System.Collections;

/**
 * Class to handle rotation of the leaves
**/ 

public class leafRotationScript : MonoBehaviour {

	private float rotationspeed;

	// Use this for initialization
	void Start () {
		rotationspeed = 0.2f;

		//randomize start rotation
		transform.rotation = Quaternion.Euler (0f, 0f,Random.Range(1,360));
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (new Vector3 (0f, 0f, rotationspeed));
	
	}
}
