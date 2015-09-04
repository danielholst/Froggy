using UnityEngine;
using System.Collections;

public class mainMenuHandler : MonoBehaviour {
	
	private Texture2D startButton;
	
	void OnGUI () {

		GUI.backgroundColor = Color.clear;

		if (GUI.Button (new Rect (260,300, 300, 300), startButton)) {
			print ("Start Game");
			//start game
			Application.LoadLevel(2);

		}
		
		if (GUI.Button (new Rect (860, 300, 300, 300), startButton)) {
			print ("Level Selection");
			Application.LoadLevel(1);
		}
	}
	
}