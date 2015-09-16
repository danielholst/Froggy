using UnityEngine;
using System.Collections;

/**
 * Class to handle selection of level in the level selection scene
**/


public class levelSelection : MonoBehaviour {
	
	public GameObject waterCircle;
	public GameObject levelsCleared;

	void OnGUI () {
		GUI.backgroundColor = Color.clear;
		if (GUI.Button (new Rect (Screen.width/10*1, Screen.height/6, Screen.width/6, Screen.height/6), " ")) {
			print ("load level 1");
			Application.LoadLevel(2);
		}

		if (GUI.Button (new Rect (Screen.width/10*3, Screen.height/6, Screen.width/6, Screen.height/6), " ") && levelsCleared.GetComponent<levelsCleared>().getClearedLevels() > 0) {
			print ("load level 2");
			Application.LoadLevel(3);
		}
		
		if (GUI.Button (new Rect (Screen.width/10*5, Screen.height/6, Screen.width/6, Screen.height/6), " ") && levelsCleared.GetComponent<levelsCleared>().getClearedLevels() > 1) {
			print ("load level 3");
			Application.LoadLevel(4);
		}
		
		if (GUI.Button (new Rect (Screen.width/10*7, Screen.height/6,Screen.width/6, Screen.height/6), " ") && levelsCleared.GetComponent<levelsCleared>().getClearedLevels() > 2) {
			print ("load level 4");
			Application.LoadLevel(5);
		}
		
		if (GUI.Button (new Rect (Screen.width/10*1, Screen.height/10*4,Screen.width/6, Screen.height/6), " ") && levelsCleared.GetComponent<levelsCleared>().getClearedLevels() > 3) {
			print ("load level 5");
			Application.LoadLevel(6);
		}
		
		if (GUI.Button (new Rect (Screen.width/10*3, Screen.height/10*4, Screen.width/6, Screen.height/6), " ") && levelsCleared.GetComponent<levelsCleared>().getClearedLevels() > 4) {
			print ("load level 6");
			Application.LoadLevel(7);
		}
		
		if (GUI.Button (new Rect (Screen.width/10*5, Screen.height/10*4, Screen.width/6, Screen.height/6), " ") && levelsCleared.GetComponent<levelsCleared>().getClearedLevels() > 5) {
			print ("load level 7");
			Application.LoadLevel(8);
		}
		
		if (GUI.Button (new Rect (Screen.width/10*7, Screen.height/10*4, Screen.width/6, Screen.height/6), " ") && levelsCleared.GetComponent<levelsCleared>().getClearedLevels() > 6) {
			print ("load level 8");
			Application.LoadLevel(9);
		}
		
		if (GUI.Button (new Rect (Screen.width/10*3, Screen.height/10*7, Screen.width/6, Screen.height/6), " ") && levelsCleared.GetComponent<levelsCleared>().getClearedLevels() > 7) {
			print ("load level 9");
			Application.LoadLevel(10);
		}
		
		if (GUI.Button (new Rect (Screen.width/10*5, Screen.height/10*7, Screen.width/6, Screen.height/6), " ") && levelsCleared.GetComponent<levelsCleared>().getClearedLevels() > 8) {
			print ("load level 10");
			Application.LoadLevel(11);
		}
		//button to return to main menu
		if (GUI.Button (new Rect (0, Screen.height/10*7, 230, 130), " ")) {
			print ("load level 10");
			Application.LoadLevel(0);
		}
	}
}
