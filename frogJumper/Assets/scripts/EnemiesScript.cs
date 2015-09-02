﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Script to handle enemies of levels
 **/

public class EnemiesScript : MonoBehaviour {

	public bool enemiesDead;
	private enemy[] enemies;
	private enemyProjectile[] enemyShots;
	public GameObject player;
	public GameObject enemyProjectileObject;
	public GameObject smallEnemyObject;
	public int level;
	private float timer;
	private float endTime;
	private int enemyCounter;
	private int enemiesSpawned;

	// Use this for initialization
	void Start () {

		enemiesDead = false;
		enemyCounter = 0;
		enemiesSpawned = 0;
		enemies = new enemy[5];
		enemyShots = new enemyProjectile[5];
		for (int i = 0; i < enemies.Length; i++) {
			enemies [i] = new enemy();
			enemyShots[i] = new enemyProjectile(enemyProjectileObject);
		}

		//set time of the level
		if (level == 2) {
			timer = 0f;
			endTime = 30f;
		}
		if(level == 3) {
			timer = 0f;
			endTime = 20f;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//update timer
		if (timer != endTime) 
			timer += Time.deltaTime;

		//function for enemyManger of level 2
		if(level == 2)
			level2(timer);
		if (level == 3)
			level3 (timer);
		enemyCounter = 0;
		enemiesSpawned = 0;
		for (int i = 0; i < enemies.Length; i++) {

			if(enemyShots[i].getIsShot()) {
				enemyShots[i].moveProjectile();
			}

			if (enemies[i].getEnemyObject() != null) {

				if(enemies[i].getSpawned())
					enemiesSpawned++;
				enemies[i].movement();

				if (enemies[i].getEnemyObject().transform.position.y < 8f && !enemyShots[i].getIsShot()) {
					//enemies[i].shoot (player.transform.position, enemyProjectileObject);
					enemyShots[i].shoot (enemies[i].getEnemyObject(), player.transform.position, enemyProjectileObject);
				}
			}
		}

		//check if all enemies are killed before next level starts
		if (enemyCounter == enemiesSpawned) {
			enemiesDead = true;
		}
	}

	//spawns on level 2
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

	//spawns on level 3
	private void level3(float time) {
		
		//spawn of enemy after 5 seconds
		if ((int)time == 5f && enemies[0].getSpawned() == false && enemies[1].getSpawned() == false) {
			print ("Spawn 2 enemies after 5 sec ");
			createSmallEnemy (0);
			createSmallEnemy (1);
		}
		
		//spawn of enemy after 15 seconds
		if ((int)time == 13f && enemies[2].getSpawned() == false && enemies[3].getSpawned() == false ) {
			print( "Spawn 2 enemies after 13 sec ");
			createSmallEnemy(2);
			createSmallEnemy(3);
		}
	}

	//function to get a random spawn position for enemy
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
		private Vector3 shotDirection;
		
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
		
//		// create a projectile from the enemy flying towards the player
//		public void shoot(Vector3 playerPos, GameObject enemyProjectile)
//		{
//			projectile = Instantiate(enemyProjectile, typeOfEnemy.transform.position, typeOfEnemy.transform.rotation) as GameObject;
//			
//			//get vector towards frog
//			shotDirection = new Vector3(playerPos.x - projectile.transform.position.x, 
//			                             playerPos.y - projectile.transform.position.y, 
//			                             1f);
//		}
		
		public void moveProjectile()
		{
			projectile.transform.position += shotDirection/70;
			
			if (projectile.transform.position.y < -6f)
				Destroy (projectile);
		}

		public GameObject getEnemyObject()
		{
			return typeOfEnemy;
		}

//		public GameObject getEnemyProjectile()
//		{
//			return projectile;
//		}

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
	
	//class for the enemies projectiles
	public class enemyProjectile
	{
		private GameObject projectile;
		private bool isShot;
		private Vector3 shotDirection;

		public enemyProjectile()
		{
			projectile = null;
			isShot = false;
		}


		public enemyProjectile(GameObject proj)
		{
			projectile = proj;
			isShot = false;
		}

		// create a projectile from the enemy flying towards the player
		public void shoot(GameObject enemy, Vector3 playerPos, GameObject enemyProjectile)
		{
			projectile = Instantiate(enemyProjectile, enemy.transform.position, enemy.transform.rotation) as GameObject;
			
			//get vector towards frog
			shotDirection = new Vector3(playerPos.x - projectile.transform.position.x, 
			                             playerPos.y - projectile.transform.position.y, 
			                             1f);
			setIsShot (true);
		}

		public void moveProjectile()
		{
			projectile.transform.position += shotDirection/90;
			
			if (projectile.transform.position.y < -6f)
			{
				Destroy (projectile);
				setIsShot(false);
			}
		}

		public bool getIsShot()
		{
			return isShot;
		}

		public void setIsShot(bool fired)
		{
			isShot = fired;
		}

		public GameObject getEnemyProjectile()
		{
			return projectile;
		}

	}

	
}

