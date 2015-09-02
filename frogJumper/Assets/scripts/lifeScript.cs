 using UnityEngine;
using System.Collections;

/**
 * Function to handle if the frog lands on leaves or in the water 
 **/

public class lifeScript : MonoBehaviour {

	public SpriteRenderer sprender;
	public int level;
	public Rigidbody2D leaf1;
	public Rigidbody2D leaf2;
	public Rigidbody2D leaf3;
	public Rigidbody2D leaf4;
	private Vector3 frogPosition;
	private Color frogColor;
	public bool sinking;
	// Use this for initialization
	void Start () {

		frogPosition = transform.position;
		frogColor = GetComponent<SpriteRenderer> ().color;
		sinking = false;
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<SpriteRenderer> ().color = frogColor;
		if (sinking) {
			if(frogColor.a == 1f)
				frogColor.a = 0.8f;

			frogColor.a -= 0.01f;
			if (frogColor.a <= 0.1f) {
				print ("reloading level");
				Application.LoadLevel (level+1);
			}
		}
		frogPosition = transform.position;

		if (transform.localScale.x >= 0.39f && transform.localScale.x <= 0.41f) {

			//check if frog is on leaf 1
			if (frogPosition.x < (leaf1.position.x + 1f) && frogPosition.x > (leaf1.position.x - 1f) && frogPosition.y < (leaf1.position.y + 1f) && frogPosition.y > (leaf1.position.y - 1f)) {

				//on leaf 1
			}

			//check if frog is on leaf 2
			else if (frogPosition.x < (leaf2.position.x + 1f) && frogPosition.x > (leaf2.position.x - 1f) && frogPosition.y < (leaf2.position.y + 1f) && frogPosition.y > (leaf2.position.y - 1f)) {
			
				//on leaf 2
			}

			//check if frog is on leaf 3
			else if (frogPosition.x < (leaf3.position.x + 1f) && frogPosition.x > (leaf3.position.x - 1f) && frogPosition.y < (leaf3.position.y + 1f) && frogPosition.y > (leaf3.position.y - 1f)) {
			
				//on leaf 3
			}
			//check if frog is on leaf 4
			else if (frogPosition.x < (leaf4.position.x + 1f) && frogPosition.x > (leaf4.position.x - 1f) && frogPosition.y < (leaf4.position.y + 1f) && frogPosition.y > (leaf4.position.y - 1f)) {
				//on leaf 4
			}
			//frog is not on any leaf
			else {
				sinking = true;
			}

		}
	}
	
}
