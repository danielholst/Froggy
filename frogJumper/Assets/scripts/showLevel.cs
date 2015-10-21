using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
* Show a text with the current level at start of scene
**/

public class showLevel : MonoBehaviour {

	public int level;
	private Text text;

	void Start()
	{
		text = GetComponent<Text>();
	}

	void OnGUI () {

		text.text = "Level " + level;
		Color color = text.color;
		text.fontSize = 32;
		color.a -= 0.005f;
		text.color = color;
		GUI.backgroundColor = Color.clear;


	}
}