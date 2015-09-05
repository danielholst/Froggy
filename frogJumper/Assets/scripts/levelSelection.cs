using UnityEngine;
using System.Collections;

/**
 * Class to handle selection of level in the level selection scene
**/


public class levelSelection : MonoBehaviour {

	private Texture2D button;	
	public GameObject waterCircle;
	
	void OnGUI () {
		GUI.backgroundColor = Color.clear;
		if (GUI.Button (new Rect (150, 70, 200, 100), button)) {
			print ("load level 1");
			Application.LoadLevel(2);
		}

		if (GUI.Button (new Rect (450, 70, 200, 100), button)) {
			print ("load level 2");
			Application.LoadLevel(3);
		}

		if (GUI.Button (new Rect (750, 70, 200, 100), button)) {
			print ("load level 3");
			Application.LoadLevel(4);
		}

		if (GUI.Button (new Rect (1050, 70, 200, 100), button)) {
			print ("load level 4");
			Application.LoadLevel(5);
		}

		if (GUI.Button (new Rect (140, 290, 200, 100), button)) {
			print ("load level 5");
			Application.LoadLevel(6);
		}

		if (GUI.Button (new Rect (450, 290, 200, 100), button)) {
			print ("load level 6");
			Application.LoadLevel(7);
		}

		if (GUI.Button (new Rect (750, 290, 200, 100), button)) {
			print ("load level 7");
			Application.LoadLevel(8);
		}

		if (GUI.Button (new Rect (1050, 290, 200, 100), button)) {
			print ("load level 8");
			Application.LoadLevel(9);
		}

		if (GUI.Button (new Rect (450, 480, 200, 100), button)) {
			print ("load level 9");
			Application.LoadLevel(10);
		}

		if (GUI.Button (new Rect (750, 480, 200, 100), button)) {
			print ("load level 10");
			Application.LoadLevel(11);
		}

		//button to return to main menu
		if (GUI.Button (new Rect (-10, 540, 230, 130), button)) {
			print ("load level 10");
			Application.LoadLevel(0);
		}
	}
}
