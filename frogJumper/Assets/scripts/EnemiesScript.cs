using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Script to handle enemies of levels
 **/

public class EnemiesScript : MonoBehaviour {

	public GameObject smallEnemyObject;
	public int level;
	private float timer;
	private float endTime;
	private bool enemySpawned1;
	private bool enemySpawned2;
	private GameObject enemy;
	private Vector3 movVec;

	// Use this for initialization
	void Start () {

		enemySpawned1 = false;
		enemySpawned2 = false;
		movVec = new Vector3 (0f, 0.01f, 0f);

		//set time of the level
		if (level == 2) {
			timer = 0f;
			endTime = 30f;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//update timer
		if (timer != endTime) 
			timer += Time.deltaTime;

		//makes the enemy move down to the top of the screen after being spawned
		if (enemySpawned1) {
			if (enemy.transform.position.y > 6f)
				enemy.transform.position -= movVec;
		}

		//function for enemyManger of level 2
		if(level == 2)
			level2(timer);
	}
	
	private void level2(float time) {

		//spawn of enemy after 5 seconds
		if ((int)time == 5f) {
			if(!enemySpawned1) {
				print( "Spawn enemy after 5 sec ");
				createSmallEnemy();
				enemySpawned1 = true;
			}
		}


		//spawn of enemy after 15 seconds
		if ((int)time == 15f) {
			if(!enemySpawned2) {
				print( "Spawn enemy after 15 sec ");
				createSmallEnemy();
				enemySpawned2 = true;
			}
		}
	}

	public Vector3 spawnEnemyPosition() {
		//randomize spawn position
		int randomNr = Random.Range (-6, 6);
		Vector3 spawnPos = new Vector3 (randomNr, 10f, 1f);
		return spawnPos;
	}

	//create a new small enemy
	public void createSmallEnemy() {
		enemy = Instantiate (smallEnemyObject, spawnEnemyPosition (), new Quaternion (0f, 0f, 0f, 1f)) as GameObject;
	}
}
