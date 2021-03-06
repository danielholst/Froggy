﻿using UnityEngine;
using System.Collections;

/**
 *  Function to make the game start after a couple of seconds to make the player ready 
**/

public class holdTime : MonoBehaviour {

	public bool startGame;

	IEnumerator Start()
	{
		startGame = false;
		// Start function WaitAndPrint as a coroutine
		yield return StartCoroutine("WaitAndPrint");
	}

	IEnumerator WaitAndPrint()
	{
		// suspend execution for 5 seconds
		yield return new WaitForSeconds(3);
		startGame = true;

	}

}