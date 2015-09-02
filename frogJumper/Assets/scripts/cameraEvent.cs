using UnityEngine;
using System.Collections;

/**
 *  Function to make the camera move for a couple of seconds in the beginning of the level
**/

public class cameraEvent : MonoBehaviour {

	public GameObject EventHandler;
	
	void Update() {


		if (!(EventHandler.GetComponent<holdTime>().startGame)) {
		
			transform.position -= new Vector3(0f, 0.04f, 0f);
		}
	}
}