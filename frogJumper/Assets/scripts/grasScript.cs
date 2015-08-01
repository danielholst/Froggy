using UnityEngine;
using System.Collections;

public class grasScript : MonoBehaviour {

	public bool isASign;
	private Vector3 movementVec;
	
	// Use this for initialization
	void Start () {
		movementVec = new Vector3 (0f, -2.3f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += movementVec* Time.deltaTime;
		
		if (transform.position.y < -10f && !isASign) {
			transform.position = new Vector3 (0f, 14f, 0f);
		}
	}
	
}
