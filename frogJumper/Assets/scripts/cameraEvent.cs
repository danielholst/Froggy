using UnityEngine;
using System.Collections;

/**
 *  Function to make the camera move for a couple of seconds
**/

public class cameraEvent : MonoBehaviour {

	public GameObject EventHandler;

	void Start(){

	}

	void Update() {


		if (!(EventHandler.GetComponent<eventHandler>().startGame)) {
		
			transform.position -= new Vector3(0f, 0.06f, 0f);


			print("TRansform = " + transform.position);
		
		}


	}
	
}