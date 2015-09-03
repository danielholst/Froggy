using UnityEngine;
using System.Collections;

public class mainMenuHandler : MonoBehaviour {
	
	public Texture2D startButton;
	public Texture2D levelButton;
	
	void OnGUI () {

		GUI.backgroundColor = Color.clear;

		if (GUI.Button (new Rect (500,250, 200, 100), startButton)) {
			print ("Start Game");
			//start game
			Application.LoadLevel(2);

		}
		
		if (GUI.Button (new Rect (500, 400, 200, 100), levelButton)) {
			print ("Level Selection");
			Application.LoadLevel(1);
		}
	}
	
}