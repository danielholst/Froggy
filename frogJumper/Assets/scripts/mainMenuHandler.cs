using UnityEngine;
using System.Collections;

public class mainMenuHandler : MonoBehaviour {
	
	void OnGUI () {

		GUI.backgroundColor = Color.clear;

		if (GUI.Button (new Rect (Screen.width/20*3,Screen.height/10*4, 250, 250), " ")) {
//			print ("Start Game");
			//start game
			Application.LoadLevel(2);

		}
		
		if (GUI.Button (new Rect (Screen.width/10*5, Screen.height/10*4, 250, 250), " ")) {
			print ("Level Selection");
			Application.LoadLevel(1);
		}
	}
	
}