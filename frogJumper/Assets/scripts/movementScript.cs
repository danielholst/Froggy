using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {

	private Vector2 forceVec;
	public Rigidbody2D body;
	public GameObject EventHandler;

	// Use this for initialization
	void Start () {

		forceVec = new Vector2 (15f, 0f);
	}
	
	// Update is called once per frame
	void Update () {

		if (EventHandler.GetComponent<holdTime> ().startGame) {
			if (Input.GetKey ("left") && !GetComponent<lifeScript>().sinking) {
				if (body.velocity.x > 2f)
					body.velocity = body.velocity - 0.1f * body.velocity;
				else {
					//add force on frog to the left
					body.AddForce (-forceVec);
				}
			} else if (Input.GetKey ("right") && !GetComponent<lifeScript>().sinking) {
				if (body.velocity.x < -2f)
					body.velocity = body.velocity - 0.1f * body.velocity;
				else {
					//add force on frog to the right
					body.AddForce (forceVec);
				}
			} else {
				//stabilize frog when no force is added
				body.velocity = body.velocity - 0.1f * body.velocity;
			}
		}
	}

}



