using UnityEngine;
using System.Collections;

/**
 * Function to make the frog able to shoot
 **/

public class shootingScript : MonoBehaviour {

	public GameObject projectile;
	private int shootingSpeed;
	private int nrOfShots;
	private Rigidbody instantiatedProjectile;
	private bool shooting;
	private float shotPos;

	// Use this for initialization
	void Start () {

		projectile.GetComponent<Renderer> ().enabled = false;
		shootingSpeed = 40;
		nrOfShots = 20;
		shooting = false;
		shotPos = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("space")) {

			projectile.GetComponent<Renderer> ().enabled = true;
//			print ("Shooting!");
			instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as Rigidbody;
			shooting = true;
		}

		if (shooting) {
			instantiatedProjectile.transform.position += new Vector3(0f,shootingSpeed, 0f);
			if(instantiatedProjectile.transform.position.y > 15) {
				Destroy(instantiatedProjectile);
				shooting = false;
			}
		}
	}
}
