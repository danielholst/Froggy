using UnityEngine;
using System.Collections;

public class mainMenuHandler : MonoBehaviour {
	
	public Texture2D startButton;
	public Texture2D levelButton;
	
	void OnGUI () {

		GUI.backgroundColor = Color.clear;

		if (GUI.Button (new Rect (400,100, 100, 50), startButton)) {
			print ("you clicked the icon");
			//start game
			Application.LoadLevel(2);

		}
		
		if (GUI.Button (new Rect (400,170, 100, 20), levelButton)) {
			print ("you clicked the text button");
			Application.LoadLevel(1);
		}
	}
	
}