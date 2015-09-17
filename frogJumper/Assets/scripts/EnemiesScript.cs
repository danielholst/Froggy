using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Class to handle enemies of levels
 **/

public class EnemiesScript : MonoBehaviour {

	public bool enemiesDead;
	private enemy[] enemies;
	private enemyProjectile[] enemyShots;
	public GameObject player;
	public GameObject enemyProjectileObject;
	public GameObject smallEnemyObject;
	public GameObject mediumEnemyObject;
	public GameObject bossEnemeyObject;
	public GameObject enemyShadow;
	public GameObject projectileShadowObject;
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
		enemies = new enemy[10];
		enemyShots = new enemyProjectile[10];

		for (int i = 0; i < enemies.Length; i++) {
			enemies [i] = new enemy();
			enemyShots[i] = new enemyProjectile(enemyProjectileObject, projectileShadowObject);
		}

		timer = 0f;

		//set time of the level
		if (level == 2 || level == 4 || level == 5) {
			endTime = 30f;
		}
		else if (level == 3) {
			endTime = 20f;
		}
		else if ( level == 10 ) {
			endTime = 40f;
		}
		else {
			endTime = 25f;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//update timer
		if (timer != endTime) 
			timer += Time.deltaTime;

		//function for enemyManger of the different levels
		getLevelSpawns (level, timer);

		enemyCounter = 0;
		enemiesSpawned = 0;
		for (int i = 0; i < enemies.Length; i++) {

			//move enemy projectiles
			if(enemyShots[i].getIsShot()) {
				enemyShots[i].moveProjectile();
			}

			//if enemy is spawned
			if (enemies[i].getEnemyObject() != null) {

				//Move enemies
				enemies[i].movement();

				//handle nr of spawned enemies
				if(enemies[i].getSpawned())
					enemiesSpawned++;

				//Enemy shoot
				if (enemies[i].getEnemyObject().transform.position.y < 8f && !enemyShots[i].getIsShot()) {
					enemyShots[i].shoot (enemies[i].getEnemyObject(), player.transform.position, enemyProjectileObject, projectileShadowObject);
				}
			}
			//to destroy enemy shadows after the enemy is killed
			else {
				enemies[i].destroyEnemyShadow();
			}
		}

		//check if all enemies are killed before next level starts
		if (enemyCounter == enemiesSpawned) {
			enemiesDead = true;
		}
	}

	private void getLevelSpawns(int level, float timer)
	{
		if(level == 2)
			level2(timer);
		if (level == 3)
			level3 (timer);
		if (level == 4)
			level4 (timer);
		if(level == 5)
			level5(timer);
		if (level == 6)
			level6 (timer);
		if (level == 7)
			level7 (timer);
		if(level == 8)
			level8(timer);
		if (level == 9)
			level9 (timer);
		if(level == 10)
			level10(timer);

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

	//spawns on level 4
	private void level4(float time) {
		
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

		//spawn of medium enemy after 20 seconds
		if ((int)time == 20f && enemies[4].getSpawned() == false && enemies[4].getSpawned() == false ) {
			print( "Spawn medium enemy after 20 sec ");
			createMediumEnemy(4);
		}
	}

	//spawns on level 5
	private void level5(float time) {
		
		//spawn of enemy after 5 seconds
		if ((int)time == 5f && enemies[0].getSpawned() == false) {
			print ("Spawn 2 enemies after 5 sec ");
			createSmallEnemy (0);
		}

		//spawn after 7 seconds
		if((int)time == 7f && enemies[1].getSpawned() == false) {
			createMediumEnemy(1);
		}

		if((int)time == 11f && enemies[2].getSpawned() == false) {
			createSmallEnemy(2);
		}
		//spawn of enemy after 15 seconds
		if ((int)time == 15f && enemies[3].getSpawned() == false) {
			createSmallEnemy(3);
		}
		
		//spawn of medium enemy after 20 seconds
		if ((int)time == 20f && enemies[4].getSpawned() == false) {
			createMediumEnemy(4);
		}
	}

	//spawns on level 6
	private void level6(float time) {

		//spawn after 7 seconds
		if ((int)time == 7f && enemies [0].getSpawned () == false) {
			createSmallEnemy (0);
		}
		if((int)time == 7f && enemies[1].getSpawned() == false) {
			createSmallEnemy(1);
		}
		
		//spawn of enemy after 13 seconds
		if((int)time == 13f && enemies[2].getSpawned() == false) {
			createMediumEnemy(2);
		}
		if ((int)time == 15f && enemies[3].getSpawned() == false) {
			createMediumEnemy(3);
		}
		if ((int)time == 17f && enemies[4].getSpawned() == false) {
			createMediumEnemy(4);
		}
	}

	//spawns on level 7
	private void level7(float time) {

		//spawn after 7 seconds
		if ((int)time == 7f && enemies [0].getSpawned () == false) {
			createSmallEnemy (0);
		}
		if((int)time == 8f && enemies[1].getSpawned() == false) {
			createSmallEnemy(1);
		}
		if((int)time == 10f && enemies[2].getSpawned() == false) {
			createSmallEnemy(2);
		}
		if ((int)time == 12f && enemies[3].getSpawned() == false) {
			createSmallEnemy(3);
		}
		if ((int)time == 15f && enemies[4].getSpawned() == false) {
			createSmallEnemy(4);
		}
		if ((int)time == 19f && enemies[5].getSpawned() == false) {
			createSmallEnemy(5);
		}
		if ((int)time == 23f && enemies[6].getSpawned() == false) {
			createSmallEnemy(6);
		}
		if ((int)time == 27f && enemies[7].getSpawned() == false) {
			createSmallEnemy(7);
		}
	}

	//spawns on level 8
	private void level8(float time) {

		//spawn after 7 seconds
		if ((int)time == 7f && enemies [0].getSpawned () == false) {
			createMediumEnemy (0);
		}
		if((int)time == 9f && enemies[1].getSpawned() == false) {
			createMediumEnemy(1);
		}
		if((int)time == 14f && enemies[2].getSpawned() == false && enemies[3].getSpawned() == false) {
			createSmallEnemy(2);
			createSmallEnemy(3);
		}

		if ((int)time == 25f && enemies[4].getSpawned() == false && enemies[5].getSpawned() == false) {
			createMediumEnemy(4);
			createMediumEnemy(5);
		}
	}

	//spawns on level 9
	private void level9(float time) {

		if ((int)time == 7f && enemies [0].getSpawned () == false) {
			createSmallEnemy (0);
		}
		if((int)time == 8f && enemies[1].getSpawned() == false) {
			createSmallEnemy(1);
		}
		if((int)time == 10f && enemies[2].getSpawned() == false) {
			createSmallEnemy(2);
		}
		if ((int)time == 12f && enemies[3].getSpawned() == false) {
			createSmallEnemy(3);
		}
		if ((int)time == 15f && enemies[4].getSpawned() == false) {
			createSmallEnemy(4);
		}
		if ((int)time == 19f && enemies[5].getSpawned() == false) {
			createSmallEnemy(5);
		}
		if ((int)time == 23f && enemies[6].getSpawned() == false) {
			createSmallEnemy(6);
		}
		if ((int)time == 27f && enemies [7].getSpawned () == false) {
			createSmallEnemy (7);
		}
		if ((int)time == 28f && enemies [8].getSpawned () == false) {
			createSmallEnemy (8);
		}
		if ((int)time == 29f && enemies[9].getSpawned() == false) {
			createSmallEnemy(9);
		}
	}

	//spawns on level 10
	private void level10(float time) {

		if ((int)time == 7f && enemies [0].getSpawned () == false) {
			createMediumEnemy (0);
		}
		if((int)time == 11f && enemies[1].getSpawned() == false) {
			createMediumEnemy(1);
		}
		if((int)time == 15f && enemies[2].getSpawned() == false) {
			createMediumEnemy(2);
		}
		if ((int)time == 20f && enemies[3].getSpawned() == false) {
			createMediumEnemy(3);
		}
		if ((int)time == 25f && enemies[4].getSpawned() == false) {
			createMediumEnemy(4);
		}
		if ((int)time == 28 && enemies[5].getSpawned() == false) {
			createMediumEnemy(5);
		}

		//Spawn last boss
		if ((int)time == 35f && enemies[6].getSpawned() == false) {
			print ("Booss spawned");
			createBossEnemy(6);
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
		GameObject shadowObject;
		Vector3 pos = spawnEnemyPosition ();

		enemyObject = Instantiate (smallEnemyObject, pos, new Quaternion (0f, 0f, 0f, 1f)) as GameObject;
		shadowObject = Instantiate (enemyShadow, new Vector3(pos.x, pos.y - 0.6f, 1f), new Quaternion (0f, 0f, 0f, 1f)) as GameObject;

		enemies [index] = new enemy (enemyObject, 1, shadowObject);
	}

	//create a new medium enemy
	private void createMediumEnemy(int index) {
		
		GameObject enemyObject;
		GameObject shadowObject;
		Vector3 pos = spawnEnemyPosition ();

		enemyObject = Instantiate (mediumEnemyObject, pos, new Quaternion (0f, 0f, 0f, 1f)) as GameObject;
		shadowObject = Instantiate (enemyShadow, new Vector3(pos.x, pos.y - 0.6f, 1f), new Quaternion (0f, 0f, 0f, 1f)) as GameObject;
		shadowObject.transform.localScale = new Vector3 (0.2f, -0.2f, 1f);
		
		enemies [index] = new enemy (enemyObject, 2, shadowObject);
	}

	private void createBossEnemy(int index) {

		GameObject enemyObject;
		GameObject shadowObject;
		Vector3 pos = new Vector3 (0f, 10f, 0f);

		enemyObject = Instantiate (bossEnemeyObject, spawnEnemyPosition (), new Quaternion (0f, 0f, 0f, 1f)) as GameObject;
		shadowObject = Instantiate (enemyShadow, new Vector3(pos.x, pos.y - 0.6f, 1f), new Quaternion (0f, 0f, 0f, 1f)) as GameObject;
		shadowObject.transform.localScale = new Vector3 (0.4f, -0.4f, 1f);

		enemies[index] = new enemy (enemyObject, 10, enemyShadow);
	}


	//class for enemy bugs
	public class enemy 
	{
		private Vector3 movVec = new Vector3 (0f, 0.01f, 0f);
		private GameObject typeOfEnemy;
		private int healthOfEnemy;
		private bool enemySpawned;
		private GameObject shadow;
		
		public enemy()
		{
			typeOfEnemy = null;
			healthOfEnemy = 0;
			enemySpawned = false;
			shadow = null;
			
		}
		
		public enemy(GameObject type, int health, GameObject shadowObject)
		{
			typeOfEnemy = type;
			healthOfEnemy = health;
			enemySpawned = true;
			shadow = shadowObject;
		}
		
		//movement for the enemy so it moves to top of screen
		public void movement()
		{

			if(typeOfEnemy.transform.position.y > 6f)
			{
				shadow.transform.position -= movVec * 100 * Time.deltaTime;
				typeOfEnemy.transform.position -= movVec * 100 * Time.deltaTime;
			}
		}

		public void destroyEnemyShadow()
		{
			if (shadow != null)
				Destroy (shadow);
		}

		public GameObject getEnemyObject()
		{
			return typeOfEnemy;
		}

		public int getEnemyHealth()
		{
			return healthOfEnemy;
		}

		public void decreaseEnemyHealth()
		{
			healthOfEnemy--;
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
		private GameObject projectileShadow;
		private bool isShot;
		private Vector3 shotDirection;

		public enemyProjectile()
		{
			projectile = null;
			isShot = false;
			projectileShadow = null;
		}


		public enemyProjectile(GameObject proj, GameObject shadow)
		{
			projectile = proj;
			projectileShadow = shadow;
			isShot = false;
		}

		// create a projectile from the enemy flying towards the player
		public void shoot(GameObject enemy, Vector3 playerPos, GameObject enemyProjectile, GameObject projectileShadowObj)
		{
			Vector3 projectileSpawnPos = new Vector3 (enemy.transform.position.x, enemy.transform.position.y - 0.1f, 1f);
			projectile = Instantiate(enemyProjectile, projectileSpawnPos, enemy.transform.rotation) as GameObject;
			projectileShadow = Instantiate(projectileShadowObj	,projectileSpawnPos, enemy.transform.rotation) as GameObject;
			
			//get vector towards frog
			shotDirection = new Vector3(playerPos.x - projectile.transform.position.x, 
			                             playerPos.y - projectile.transform.position.y, 
			                             1f);

			//add small diff to shot
			float diff = Random.Range (-3, 3) / 10;
			shotDirection.x += diff;
			setIsShot (true);
		}

		public void moveProjectile()
		{
			projectile.transform.position += shotDirection/10*8 * Time.deltaTime;
			projectileShadow.transform.position = new Vector3(projectile.transform.position.x, projectile.transform.position.y - 0.6f, 1f);


			if (projectile.transform.position.y < -6f)
			{
				Destroy (projectile);
				Destroy (projectileShadow);
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