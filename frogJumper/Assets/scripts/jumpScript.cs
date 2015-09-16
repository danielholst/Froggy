using UnityEngine;
using System.Collections;

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
	}
	
	// Update is called once per frame
	void Update () {

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
				splashPos = transform.position;
				setSplashPos = true;
			}

		}

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

			if (scale < 1.0f)
				speed = 1.3f;

			scale += speed * Time.deltaTime;

			//scale frog so it loops like it jumps up
			scaleVec = new Vector2 (0.4f * scale, 0.6f * scale);
			transform.localScale = scaleVec;
//			shadow.position = new Vector2 (transform.position.x, -3f * scaleVec.y + 1.7f);
			shadow.position = new Vector2 (transform.position.x, -3f * scaleVec.y + 1.7f + transform.position.y);

		}	
	}
}
