using UnityEngine;
using System.Collections;

/**
 * Function to make the frog able to shoot
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

		if (Input.GetKeyUp ("space") && !(shooting)) {

			projectile.GetComponent<Renderer> ().enabled = true;
//			print ("Shooting!");
			instantiatedProjectile = Instantiate(projectile,transform.position,transform.rotation)as GameObject;
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
