using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * class to handle buttons for paus menu
**/

public class showMenuButtons : MonoBehaviour {

	public GameObject pausmenu;

	// Update is called once per frame
	void OnGUI () {

		GUI.backgroundColor = Color.clear;

		GUIStyle resumeButton = new GUIStyle("Resume");
		resumeButton.fontSize = 70;
		resumeButton.normal.textColor = Color.Lerp(Color.red, Color.yellow, 0.5f);
		
		GUIStyle mainmenuButton = new GUIStyle("Main menu");
		mainmenuButton.fontSize = 70;
		mainmenuButton.normal.textColor = Color.Lerp(Color.red, Color.yellow, 0.5f);

		//check if game is paused
		if (pausmenu.GetComponent<pausMenuScript> ().paused) {
		
			if (GUI.Button (new Rect (Screen.width/16*6+20, Screen.height/16*7, 300, 100), "Resume", resumeButton)) {
				resumeButton.normal.textColor = Color.gray;
				pausmenu.GetComponent<pausMenuScript>().resume();
			}

			if (GUI.Button (new Rect (Screen.width/16*6, Screen.height/8*5, 200, 100), "Main menu", mainmenuButton)) {
				mainmenuButton.normal.textColor = Color.gray;
				Application.LoadLevel(0);
			}

		}
	}
}
