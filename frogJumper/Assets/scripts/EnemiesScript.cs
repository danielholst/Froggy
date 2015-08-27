using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Script to handle enemies of levels
 **/

public class EnemiesScript : MonoBehaviour {

	private enemy[] enemies;
	public GameObject player;
	public GameObject enemyProjectile;
	public GameObject smallEnemyObject;
	public int level;
	private float timer;
	private float endTime;

	// Use this for initialization
	void Start () {

		enemies = new enemy[5];;
		for (int i = 0; i < enemies.Length; i++) {
			enemies [i] = new enemy();
		}

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

			if (enemies[i].getEnemyObject() != null) {
				enemies[i].movement();

				if (enemies[i].getEnemyObject().transform.position.y < 8f && enemies[i].getEnemyProjectile() == null) {
					enemies[i].shoot (player.transform.position, enemyProjectile);
				}

				if(enemies[i].getEnemyProjectile() != null) {
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
		if ((int)time == 5f && enemies[0].getSpawned() == false) {
			print ("Spawn enemy after 5 sec ");
			createSmallEnemy (0);
		}
	
		//spawn of enemy after 15 seconds
		if ((int)time == 15f && enemies[1].getSpawned() == false ) {
			print( "Spawn enemy after 15 sec ");
			createSmallEnemy(1);
		}
	}

	private Vector3 spawnEnemyPosition() {
		//randomize spawn position
		int randomNr = Random.Range (-6, 6);
		Vector3 spawnPos = new Vector3 (randomNr, 10f, 1f);
		return spawnPos;
	}


	//create a new small enemy
	private void createSmallEnemy(int index) {
	
		GameObject enemyObject;
		enemyObject = Instantiate (smallEnemyObject, spawnEnemyPosition (), new Quaternion (0f, 0f, 0f, 1f)) as GameObject;

		enemies [index] = new enemy (enemyObject, 1);
	}


	//class for enemy bugs
	public class enemy 
	{
		private Vector3 movVec = new Vector3 (0f, 0.01f, 0f);
		private GameObject typeOfEnemy;
		private GameObject projectile;
		private int healthOfEnemy;
		private bool enemySpawned;
		private Vector3 shootDirection;
		
		public enemy()
		{
			typeOfEnemy = null;
			healthOfEnemy = 0;
			enemySpawned = false;
			
		}
		
		public enemy(GameObject type, int health)
		{
			typeOfEnemy = type;
			healthOfEnemy = health;
			enemySpawned = true;
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

		public GameObject getEnemyObject()
		{
			return typeOfEnemy;
		}

		public GameObject getEnemyProjectile()
		{
			return projectile;
		}

		public int getEnemyHealth()
		{
			return healthOfEnemy;
		}

		public bool getSpawned()
		{
			return enemySpawned;
		}

		private void setSpawned(bool spawned)
		{
			enemySpawned = spawned;
		}

	}

	
}

