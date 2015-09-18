using UnityEngine;
using System.Collections;

/**
 * Class to handle the jumping of frog
 * Handling the shadow of frog
 * Handling waterRings
**/

public class jumpScript : MonoBehaviour {

	private float speed;
	private float scale;
	private Vector2 scaleVec;
	public Rigidbody2D shadow;
	public GameObject EventHandler;
	public GameObject waterRing;
	private Color colorWaterRing;
	private float scaleWaterRing;
	private bool growing;
	private Vector3 splashPos;
	private bool setSplashPos;

	//for sound
	public AudioClip splashSound;
	private AudioSource source;
	private float volMin = 0.1f;
	private float volMax = 0.2f;

	// Use this for initialization
	void Start () {

		speed = 1.3f;
		scale = 1f;
		scaleVec = new Vector2(1f, 1f);
		colorWaterRing = waterRing.GetComponent<SpriteRenderer> ().color;
		waterRing.GetComponent<SpriteRenderer> ().enabled = false;
		scaleWaterRing = 1f;
		growing = false;
		setSplashPos = false;
		splashPos = new Vector3 (0f, 0f, 0f);
		waterRing.transform.position = splashPos;
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		//handle drag back after collision
		if(transform.position.y < 0f)
		{
			transform.position += new Vector3(0f, 0.002f, 0f);
		}

		waterRing.GetComponent<SpriteRenderer> ().color = colorWaterRing;

		waterRing.transform.localScale = new Vector3(scaleWaterRing, scaleWaterRing, 1f);

		//if frog missed a leaf and is sinking
		if (GetComponent<lifeScript> ().sinking) {
			waterRing.transform.position = new Vector3 (splashPos.x, transform.position.y - 0.03f, 1f);
			waterRing.GetComponent<SpriteRenderer> ().enabled = true;
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.03f, 1f);
			shadow.GetComponent<SpriteRenderer>().enabled = false;
			growing = true;
			if(!setSplashPos) {

				//play spash when missed leaf
				source.PlayOneShot(splashSound, 0.6f);

				splashPos = transform.position;
				setSplashPos = true;
			}

		}

		//prevent frog to jump of screen 
		if (transform.position.x > 9f)
			transform.position = new Vector3 (9f, 0f, 1f);
		if (transform.position.x < -9f)
			transform.position = new Vector3 (-9f, 0f, 1f);

		//scaling of water rings
		if (growing) {
			scaleWaterRing += 0.01f;
			colorWaterRing.a -= 0.01f;
			
			if(scaleWaterRing > 2.5f) {
				growing = false;
				scaleWaterRing = 0.5f;
				colorWaterRing.a = 1f;
			}
		}

		//else frog is jumping
		if (EventHandler.GetComponent<holdTime>().startGame && !GetComponent<lifeScript>().sinking) {
			//set interval, differ between max and min
			if (scale > 2.0f) 
				speed = -1.3f;

			if (scale < 1.0f) {

				//create splash sound
				float vol = Random.Range(volMin, volMax);
				source.PlayOneShot(splashSound, vol);

				speed = 1.3f;
			}
			scale += speed * Time.deltaTime;

			//scale frog so it loops like it jumps up
			scaleVec = new Vector2 (0.4f * scale, 0.6f * scale);
			transform.localScale = scaleVec;
//			shadow.position = new Vector2 (transform.position.x, -3f * scaleVec.y + 1.7f);
			shadow.position = new Vector2 (transform.position.x, -3f * scaleVec.y + 1.7f + transform.position.y);

		}	
	}
}
