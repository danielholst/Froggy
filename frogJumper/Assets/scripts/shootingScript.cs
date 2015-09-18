using UnityEngine;
using System.Collections;

/**
 * Function to make the frog able to shot
 **/

public class shootingScript : MonoBehaviour {

	public GameObject projectile;
	public GameObject projectileShadow;
	private GameObject holdTime;
	private float shootingSpeed;
	private GameObject instantiatedProjectile;
	private GameObject instantiatedProjectileShadow;
	private bool shooting;
	private int hitsOnBoss;
	private bool bossKilled;

	// Use this for initialization
	void Start () {

		holdTime = GameObject.FindGameObjectWithTag ("HoldTime");
		projectile.GetComponent<Renderer> ().enabled = false;
		projectileShadow.GetComponent<Renderer> ().enabled = false;
		shootingSpeed = 0.2f;
		shooting = false;
		hitsOnBoss = 0;
		bossKilled = false;
	}
	
	// Update is called once per frame
	void Update () {

		//to destroy projectile shadow
		if(instantiatedProjectile == null && instantiatedProjectileShadow != null)
			Destroy (instantiatedProjectileShadow);

		//if space is pressed a projectile is launched from the frog
		if (Input.GetKeyUp ("space") && holdTime.GetComponent<holdTime> ().startGame && !(shooting) && !GetComponent<lifeScript>().sinking) {

			shooting = true;
			projectile.GetComponent<Renderer> ().enabled = true;
			projectileShadow.GetComponent<Renderer>().enabled = true;

			//get spawn pos for projectile
			Vector3 projectileSpawn = new Vector3(transform.position.x, transform.position.y + 0.5f, 1f);

			//instantate new projectile
			instantiatedProjectile = Instantiate(projectile,projectileSpawn,transform.rotation)as GameObject;
			instantiatedProjectileShadow = Instantiate(projectileShadow,new Vector3 (projectileSpawn.x, projectileSpawn.y - 0.6f, 1f),transform.rotation)as GameObject;
		}

		//if shot is fired, move projectile
		if (shooting) {

			instantiatedProjectile.transform.position += new Vector3(0f,shootingSpeed, 0f);
			instantiatedProjectileShadow.transform.position += new Vector3(0f,shootingSpeed, 0f);

			//if projectile reaches below screen destroy it
			if(instantiatedProjectile.transform.position.y > 9) {
				Destroy(instantiatedProjectile);
				shooting = false;
			}
		}
	}

	public void setShooting(bool boolShoot)
	{
		shooting = boolShoot;
	}

	//for boss at last level
	public void increaseHitsOnBoss() 
	{
		hitsOnBoss++;
		print (hitsOnBoss);
	}

	public int getHitsOnBoss()
	{
		return hitsOnBoss;
	}

	public void bossIsKilled()
	{
		bossKilled = true;
	}

	public bool getIsBossKilled()
	{
		return bossKilled;
	}
}
