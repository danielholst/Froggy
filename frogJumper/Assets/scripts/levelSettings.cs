using UnityEngine;
using System.Collections;

/**
 * Function to handle length and settings of the level.
 **/

public class levelSettings : MonoBehaviour {

	private GameObject enemies;
	public GameObject fader;
	public GameObject holdTime;
	private GameObject player;
	public int gameSpeed;
	public int level;
	private float timer;
	private int stagesCleared;
	private float lastSpawn;
	public static int clearedLevels;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		enemies = GameObject.FindGameObjectWithTag ("EnemyHandler");

		//set time of the level
		if (level == 1 || level == 2 || level == 4 || level == 5)
			timer = 30f;
		else if (level == 3)
			timer = 20f;
		else if (level == 6 || level == 8)
			timer = 35f;
		else if (level == 7 || level == 9)
			timer = 40f;
		else if (level == 10 || level == 11)
			timer = 120f;
		else 
			timer = 2f;

		lastSpawn = 0f;
		clearedLevels = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (level != 0 && holdTime.GetComponent<holdTime> ().startGame) {

			//handle the timer, decreases until time = 1 and checks if all enemies are killed, then fades over to next level
			if (!(timer <= 0f)) {

				if(timer >=1f)
					timer -= Time.deltaTime;

				if(level == 10 && player.GetComponent<shootingScript>().getIsBossKilled()) {

					timer = 0.9f;
					player.GetComponent<shootingScript>().bossIsKilled(false);

				}
				if( level == 1 && timer <= 1f) {
					fader.GetComponent<faderScript>().EndScene();
					timer -= Time.deltaTime;
				}

				if( level > 1 && timer <= 1f && enemies.GetComponent<EnemiesScript>().getActiveEnemies() == 0) {
					fader.GetComponent<faderScript>().EndScene();
					timer -= Time.deltaTime;
				}

			}

			//fade out level,then load and fade in next level
			else {

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
