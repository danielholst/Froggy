using UnityEngine;
using System.Collections;

/**
 * Class to handle the behavior of the leaves
**/

public class leafScript : MonoBehaviour {

	private float rotationspeed;
	public Vector2 startPos;
	private Vector3 movementVec;
	public GameObject EventHandler;
	public int level;
	public int counter;
	private GameObject settings;

	// Use this for initialization
	void Start () {

		settings = GameObject.FindGameObjectWithTag ("Settings");
		movementVec = new Vector3 (0f, -2.54f, 0f);
		rotationspeed = 10f;
		counter = 0;
	}

	// Update is called once per frame
	void Update () {

		if (EventHandler.GetComponent<holdTime> ().startGame) {
			transform.position += movementVec * Time.deltaTime;
			transform.Rotate (new Vector3 (0f, 0f, rotationspeed * Time.deltaTime));

			if (transform.position.y < -5f) {
				settings.GetComponent<levelSettings>().setLastSpawn( respawn (settings.GetComponent<levelSettings>().getLastSpawn()));
				counter++;
			}

		}
	}

	//Function to respawn the leaf at a random position
	float respawn(float prevSpawn) {

		//randomize start position
		float randomNr = randomFunction (prevSpawn);
		transform.position = new Vector3 (randomNr, 11f, 0f);

		transform.rotation = Quaternion.Euler (0f, 0f,Random.Range(1,360));

		return randomNr;
	}

	//function to get a random position without making it spawn at same place as previous leaf
	float randomFunction (float prevSpawn) {
		int randomNr = Random.Range (-6, 6);
		while (randomNr >= prevSpawn -2 && randomNr <= prevSpawn +2 ) {
			randomNr = Random.Range (-6, 6);
		}


		return randomNr;
	}

}
