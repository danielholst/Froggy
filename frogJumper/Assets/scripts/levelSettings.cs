using UnityEngine;
using System.Collections;

/**
 * Function to handle length and settings of the level.
 **/

public class levelSettings : MonoBehaviour {

	private GameObject enemies;
	public GameObject fader;
//	public GameObject levelsCleared;
	public GameObject holdTime;
	public int gameSpeed;
	public int level;
	private float timer;
	private int stagesCleared;
	private float lastSpawn;
	public static int clearedLevels;


	// Use this for initialization
	void Start () {
	
		enemies = GameObject.FindGameObjectWithTag ("EnemyHandler");
		//set time of the level
		if (level == 2 || level == 4 || level == 5)
			timer = 30f;
		else if (level == 3)
			timer = 20f;
		else if (level == 10)
			timer = 40f;
		else 
			timer = 25f;

		lastSpawn = 0f;
		clearedLevels = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (level != 0 && holdTime.GetComponent<holdTime> ().startGame) {
			if (!(timer <= 0f)) {

				if(timer >=1f)
					timer -= Time.deltaTime;

				//Check if all enemies are dead before next level is loaded
				if( enemies.GetComponent<EnemiesScript>().enemiesDead && timer <= 1f) {
					fader.GetComponent<faderScript>().EndScene();
					timer -= Time.deltaTime;
				}

			}
			else {
				//reached end of level
				//fade out level
				//then load and fade in next level
//				GetComponent<levelsCleared> ().addClearedLevels();
//				print ("levels cleared = " + GetComponent<levelsCleared> ().getClearedLevels());
				clearedLevels++;
				Application.LoadLevel(level+2);
			}
		}
	}

	public void setLastSpawn(float pos)
	{
		lastSpawn = pos;
	}

	public float getLastSpawn()
	{
		return lastSpawn;
	}
}
