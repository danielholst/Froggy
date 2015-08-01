using UnityEngine;
using System.Collections;

public class waterRingsScript : MonoBehaviour {

	public GameObject leaf;
	private float scale;
	private bool growing;
	private Color colorLeaf;
	private Color colorWaterRing;
	// Use this for initialization
	void Start () {

		scale = 0.005f;
		growing = false;
		colorLeaf = leaf.GetComponent<SpriteRenderer>().color;
		colorWaterRing = GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = leaf.transform.position;
		GetComponent<SpriteRenderer> ().color = colorWaterRing;
		leaf.GetComponent<SpriteRenderer> ().color = colorLeaf;
//		print ("scale = " + transform.localScale);
		transform.localScale = new Vector3(scale, scale, 1f);

		if (growing) {
			print ("alpha = " + colorWaterRing.a);
			scale += 0.025f;
			colorLeaf.a -= 0.01f;
			colorWaterRing.a -= 0.01f;

			if(scale > 2.5f) {
				growing = false;
				scale = 0.005f;
				colorWaterRing.a = 1f;
				colorLeaf.a = 1f;
			}
		}

		//if leaf position.y = 0 (when frog lands on leaf) the scaling starts of the water rings
		if (leaf.transform.position.y >= 0.2f && leaf.transform.position.y <= 0.5f) {
			growing = true;
		}
	}
}
