using UnityEngine;
using System.Collections;

/**
 * Function to handle length and settings of the level.
 **/

public class levelSettings : MonoBehaviour {

	public GameObject fader;
	public GameObject holdTime;
	public int gameSpeed;
	public int level;
	private float timer;

	// Use this for initialization
	void Start () {

		//set time of the level
		if (level == 1 || level == 2 || level == 4)
			timer = 30f;

		if (level == 3)
			timer = 20f;
	}
	
	// Update is called once per frame
	void Update () {

		if (holdTime.GetComponent<holdTime> ().startGame) {
			if (!(timer <= 0f)) {

				timer -= Time.deltaTime;
				if(timer <=1f) {
					fader.GetComponent<faderScript>().EndScene();
				}

			} else {
				//reached end of level
				//fade out level
				//then load and fade in next level
				Application.LoadLevel(level+2);
			}
		}
	}
}
