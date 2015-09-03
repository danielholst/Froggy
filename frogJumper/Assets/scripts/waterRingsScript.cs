using UnityEngine;
using System.Collections;

public class waterRingsScript : MonoBehaviour {

	public int level;
	public GameObject leaf;
	public GameObject frog;
	private float scale;
	private bool growing;
	private Color colorLeaf;
	private Color colorWaterRing;
	private float widthOfLeaf;
	// Use this for initialization
	void Start () {

		scale = 0.5f;
		growing = false;
		colorLeaf = leaf.GetComponent<SpriteRenderer>().color;
		colorWaterRing = GetComponent<SpriteRenderer>().color;

		if (level == 1)
			widthOfLeaf = 1.6f;
		else if (level == 2)
			widthOfLeaf = 1.4f;
		
		if (level == 3)
			widthOfLeaf = 1.2f;
		
		if (level == 4)
			widthOfLeaf = 1f;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = leaf.transform.position;
		GetComponent<SpriteRenderer> ().color = colorWaterRing;
		leaf.GetComponent<SpriteRenderer> ().color = colorLeaf;
		transform.localScale = new Vector3(scale, scale, 1f);

		if (growing) {
//			print ("alpha = " + colorWaterRing.a);
			scale += 0.02f;
			colorLeaf.a -= 0.01f;
			colorWaterRing.a -= 0.01f;

			if(scale > 2.5f) {
				growing = false;
				scale = 0.5f;
				colorWaterRing.a = 1f;
				colorLeaf.a = 1f;
			}
		}

		//if leaf position.y = 0 (when frog lands on leaf) the scaling starts of the water rings
		if (leaf.transform.position.y >= 0.2f && leaf.transform.position.y <= 0.3f 
		    && frog.transform.position.x < (leaf.transform.position.x + widthOfLeaf) && frog.transform.position.x > (leaf.transform.position.x - widthOfLeaf)) {
			growing = true;
		}
	}
}