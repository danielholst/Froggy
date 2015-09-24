using UnityEngine;
using System.Collections;

/**
 * Buttons for main menu
 **/

public class mainMenuHandler : MonoBehaviour {

	public Texture2D frog;
	void OnGUI () {

		GUI.backgroundColor = Color.clear;

		if (GUI.Button (new Rect (Screen.width/20*3,Screen.height/10*4, Screen.width/20*5, Screen.height/10*4), frog)) {
			Application.LoadLevel(2);

		}
		
		if (GUI.Button (new Rect (Screen.width/10*6, Screen.height/10*4, Screen.width/20*5, Screen.height/10*4), frog)) {
			Application.LoadLevel(1);
		}
	}
	
}