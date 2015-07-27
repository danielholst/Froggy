using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
	
	public Texture2D icon;
	
	void OnGUI () {
		if (GUI.Button (new Rect (10,10, 100, 50), icon)) {
			print ("you clicked the icon");
			//start game
			Application.LoadLevel(1);

		}
		
		if (GUI.Button (new Rect (10,70, 100, 20), "This is text")) {
			print ("you clicked the text button");
		}
	}
	
}