using UnityEngine;
using System.Collections;

public class leafScript : MonoBehaviour {

	private float rotationspeed;
	public Vector2 startPos;
	private Vector3 movementVec;
	public GameObject EventHandler;
	public int level;
	private float prevSpawn;
	public int counter;

	// Use this for initialization
	void Start () {

		movementVec = new Vector3 (0f, -2.54f, 0f);
		rotationspeed = 0.1f;
		prevSpawn = 0f;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (EventHandler.GetComponent<holdTime> ().startGame) {
			transform.position += movementVec * Time.deltaTime;
			transform.Rotate (new Vector3 (0f, 0f, rotationspeed));

			if (transform.position.y < -5f) {
				prevSpawn = respawn (prevSpawn);
				counter++;
			}

		}
	}

	float respawn(float prevSpawn) {

		//randomize start position
		float randomNr = randomFunction (prevSpawn);
		transform.position = new Vector3 (randomNr, 11f, 0f);

		//randomize start rotation
		transform.rotation = Quaternion.Euler (0f, 0f,Random.Range(1,360)); // 0f,1f, Random.Range(1, 360));

		return randomNr;
	}

	//function to get a random position without making it spawn at same place as previous leaf
	float randomFunction (float prevSpawn) {
		int randomNr = Random.Range (-6, 6);
		while (randomNr >= prevSpawn -1 && randomNr <= prevSpawn +1) {
			randomNr = Random.Range (-6, 6);
		}


		return randomNr;
	}

}
