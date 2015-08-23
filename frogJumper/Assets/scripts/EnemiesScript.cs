using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Script to handle enemies of levels
 **/

public class EnemiesScript : MonoBehaviour {


	public class enemy 
	{
		private Vector3 movVec = new Vector3 (0f, 0.01f, 0f);
		public GameObject typeOfEnemy;
		public GameObject projectile;
		private int healthOfEnemy;
		private static Vector3 shootDirection;

		public enemy()
		{
			typeOfEnemy = null;
			healthOfEnemy = 0;

		}

		public enemy(GameObject type, int health)
		{
			typeOfEnemy = type;
			healthOfEnemy = health;
		}

		//movement for the enemy so it moves to top of screen
		public void movement()
		{
			if(typeOfEnemy.transform.position.y > 6f)
			{
				typeOfEnemy.transform.position -= movVec;
			}
		}

		// create a projectile from the enemy flying towards the player
		public void shoot(Vector3 playerPos, GameObject enemyProjectile)
		{
			projectile = Instantiate(enemyProjectile, typeOfEnemy.transform.position, typeOfEnemy.transform.rotation) as GameObject;
			
			//get vector towards frog
			shootDirection = new Vector3(playerPos.x - projectile.transform.position.x, 
				                             playerPos.y - projectile.transform.position.y, 
				   	         	             1f);
		}

		public void moveProjectile()
		{
			projectile.transform.position += shootDirection/70;

			if (projectile.transform.position.y < -6f)
				Destroy (projectile);
		}
	}


	private enemy[] enemies;
	public GameObject player;
	public GameObject enemyProjectile;
	public GameObject smallEnemyObject;
	public int level;
	private float timer;
	private float endTime;
	private bool enemySpawned1;
	private bool enemySpawned2;

	// Use this for initialization
	void Start () {

		enemies = new enemy[5];
		for (int i = 0; i < enemies.Length; i++) {
			enemies [i] = new enemy();
		}
		enemySpawned1 = false;
		enemySpawned2 = false;

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

		for (int i = 0; i < enemies.Length; i++) {

			if (enemies[i].typeOfEnemy != null) {
				enemies[i].movement();

				if (enemies[i].typeOfEnemy.transform.position.y < 8f && enemies[i].projectile == null) {
					enemies[i].shoot (player.transform.position, enemyProjectile);
				}

				if(enemies[i].projectile != null) {
					enemies[i].moveProjectile();
				}
			}
		}


		//function for enemyManger of level 2
		if(level == 2)
			level2(timer);
	}
	
	private void level2(float time) {

		//spawn of enemy after 5 seconds
		if ((int)time == 5f && !enemySpawned1) {
			print ("Spawn enemy after 5 sec ");
			createSmallEnemy ();
			enemySpawned1 = true;
		}
	
		//spawn of enemy after 15 seconds
		if ((int)time == 15f && !enemySpawned2) {
			print( "Spawn enemy after 15 sec ");
			createSmallEnemy();
			enemySpawned2 = true;
		}
	}

	private Vector3 spawnEnemyPosition() {
		//randomize spawn position
		int randomNr = Random.Range (-6, 6);
		Vector3 spawnPos = new Vector3 (randomNr, 10f, 1f);
		return spawnPos;
	}


	//create a new small enemy
	private void createSmallEnemy() {
	
		GameObject enemyObject;
		enemyObject = Instantiate (smallEnemyObject, spawnEnemyPosition (), new Quaternion (0f, 0f, 0f, 1f)) as GameObject;

		int i = 0;
		while (enemies[i] != null && i < 4)
			i++;

		enemies [i] = new enemy (enemyObject, 1);
	}
	
}

