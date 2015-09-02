using UnityEngine;
using System.Collections;

/**
 * Function to make the frog able to shot
 **/

public class shootingScript : MonoBehaviour {

	public GameObject projectile;
	private float shootingSpeed;
	private int nrOfShots;
	private GameObject instantiatedProjectile;
	private bool shooting;
	private float shotPos;

	// Use this for initialization
	void Start () {

		projectile.GetComponent<Renderer> ().enabled = false;
		shootingSpeed = 0.2f;
		nrOfShots = 20;
		shooting = false;
		shotPos = 0f;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp ("space") && !(shooting) && !GetComponent<lifeScript>().sinking) {

			projectile.GetComponent<Renderer> ().enabled = true;
			Vector3 projectileSpawn = new Vector3(transform.position.x, transform.position.y+1f, 1f); 
//			print ("Shooting!");
			instantiatedProjectile = Instantiate(projectile,projectileSpawn,transform.rotation)as GameObject;
			shooting = true;
		}

		if (shooting) {
			instantiatedProjectile.transform.position += new Vector3(0f,shootingSpeed, 0f);
			if(instantiatedProjectile.transform.position.y > 8) {
				Destroy(instantiatedProjectile);
				shooting = false;
			}
		}
	}
}
