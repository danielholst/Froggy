using UnityEngine;
using System.Collections;

public class creditTextScript : MonoBehaviour {

	private Vector3 movVec;
	// Use this for initialization
	void Start () {
		movVec = new Vector3 (0f, 0.02f, 0f);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position -= movVec;

		if (transform.position.y <= -9f)
			Application.LoadLevel (0);
	}
}
