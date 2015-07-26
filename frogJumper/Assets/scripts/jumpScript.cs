using UnityEngine;
using System.Collections;

public class jumpScript : MonoBehaviour {

	private float speed;
	private float scale;
	private Vector2 scaleVec;
	public Rigidbody2D shadow;
	public GameObject EventHandler;

	// Use this for initialization
	void Start () {

		speed = 1.3f;
		scale = 1f;
		scaleVec = new Vector2(1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {

		
		if (EventHandler.GetComponent<eventHandler>().startGame) {
			//set interval, differ between max and min
			if (scale > 2.0f) 
				speed = -1.3f;

			if (scale < 1.0f)
				speed = 1.3f;

			scale += speed * Time.deltaTime;

			//scale frog so it loops like it jumps up
			//shadowPos = new Vector2 (scale, scale);
			scaleVec = new Vector2 (0.4f * scale, 0.6f * scale);
			transform.localScale = scaleVec;
			shadow.position = new Vector2 (transform.position.x, -3f * scaleVec.y + 1.7f);
		}
	}
}
