using UnityEngine;
using System.Collections;

public class waterscript : MonoBehaviour {

	public float waterSpeed;
	private Vector3 movementVec;

	// Use this for initialization
	void Start () {
		if (waterSpeed == 0)
			waterSpeed = -2.66f;	
		movementVec = new Vector3 (0f, waterSpeed, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += movementVec* Time.deltaTime;

		if (transform.position.y < -10f) {
			transform.position = new Vector3 (0f, 14f, 0f);
		}
	}

}
