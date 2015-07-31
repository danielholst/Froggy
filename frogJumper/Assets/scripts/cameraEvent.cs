using UnityEngine;
using System.Collections;

/**
 *  Function to make the camera move for a couple of seconds
**/

public class cameraEvent : MonoBehaviour {

	public GameObject EventHandler;
	
	void Update() {


		if (!(EventHandler.GetComponent<holdTime>().startGame)) {
		
			transform.position -= new Vector3(0f, 0.04f, 0f);
//			print("TRansform = " + transform.position);
		
		}
	}
}