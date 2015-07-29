﻿ using UnityEngine;
using System.Collections;

public class lifeScript : MonoBehaviour {

	public SpriteRenderer sprender;
	public int level;
	public Rigidbody2D leaf1;
	public Rigidbody2D leaf2;
	public Rigidbody2D leaf3;
	public Rigidbody2D leaf4;
	private Vector3 frogPosition;
	// Use this for initialization
	void Start () {

		frogPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		frogPosition = transform.position;

		if (transform.localScale.x >= 0.39f && transform.localScale.x <= 0.41f) {

			//check if frog is on leaf 1
			if (frogPosition.x < (leaf1.position.x + 1f) && frogPosition.x > (leaf1.position.x - 1f) && frogPosition.y < (leaf1.position.y + 1f) && frogPosition.y > (leaf1.position.y - 1f)) {

				print ("on leaf 1");
			}

			//check if frog is on leaf 2
			else if (frogPosition.x < (leaf2.position.x + 1f) && frogPosition.x > (leaf2.position.x - 1f) && frogPosition.y < (leaf2.position.y + 1f) && frogPosition.y > (leaf2.position.y - 1f)) {
			
				print ("on leaf 2");
			}

			//check if frog is on leaf 3
			else if (frogPosition.x < (leaf3.position.x + 1f) && frogPosition.x > (leaf3.position.x - 1f) && frogPosition.y < (leaf3.position.y + 1f) && frogPosition.y > (leaf3.position.y - 1f)) {
			
				print ("on leaf 3");
			}
			//check if frog is on leaf 4
			else if (frogPosition.x < (leaf4.position.x + 1f) && frogPosition.x > (leaf4.position.x - 1f) && frogPosition.y < (leaf4.position.y + 1f) && frogPosition.y > (leaf4.position.y - 1f)) {
			
				print ("on leaf 4");
			}
			//frog is not on any leaf
			else {
				//make frog dissapear before restarting 	TODO
				sprender.enabled=false;
				resetLevel();
				print ("MISSSSS" );

			}

		}
	}

	void resetLevel()
	{
		print ("reloading level");
		Application.LoadLevel (level+1);
	}
}
