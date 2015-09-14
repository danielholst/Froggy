using UnityEngine;
using System.Collections;

/**
 * Function to handle length and settings of the level.
 **/

public class levelSettings : MonoBehaviour {

	public GameObject fader;
	public GameObject levelsCleared;
	public GameObject holdTime;
	public int gameSpeed;
	public int level;
	private float timer;
	private int stagesCleared;

	// Use this for initialization
	void Start () {
	
//		stagesCleared = levelsCleared.GetComponent<levelsCleared> ().clearedLevels;

		//set time of the level
		if (level == 1 || level == 2 || level >= 4)
			timer = 30f;
		else if (level == 3)
			timer = 20f;
		else if (level >= 5 && level <= 8)
			timer = 40f;
		else 
			timer = 50f;
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
//				GetComponent<levelsCleared> ().addClearedLevels();
//				print ("levels cleared = " + GetComponent<levelsCleared> ().getClearedLevels());
				Application.LoadLevel(level+2);
			}
		}
	}
}
