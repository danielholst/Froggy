﻿using UnityEngine;
using System.Collections;

/**
* Handles the water animation when frog lands on leaves
**/

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

		else
			widthOfLeaf = 1f;
	}

	// Update is called once per frame
	void Update () {

		transform.position = leaf.transform.position;
		GetComponent<SpriteRenderer> ().color = colorWaterRing;
		leaf.GetComponent<SpriteRenderer> ().color = colorLeaf;
		transform.localScale = new Vector3(scale, scale, 1f);

		//resets colors
		if (leaf.transform.position.y > 6) {
			colorLeaf.a = 1f;
			colorWaterRing.a = 1f;
		}

		if (growing) {

			scale += 1.2f * Time.deltaTime;
			colorLeaf.a -= 0.7f * Time.deltaTime;
			colorWaterRing.a -= 0.7f * Time.deltaTime;

			if(scale > 2.5f) {
				growing = false;
				scale = 0.5f;
			}
		}

		//if leaf position.y = 0 (when frog lands on leaf) the scaling starts of the water rings
		if (leaf.transform.position.y >= 0.2f && leaf.transform.position.y <= 0.3f
		    && frog.transform.position.x < (leaf.transform.position.x + widthOfLeaf + 0.5f) && frog.transform.position.x > (leaf.transform.position.x - (widthOfLeaf + 0.5f))) {
			growing = true;
		}
	}
}