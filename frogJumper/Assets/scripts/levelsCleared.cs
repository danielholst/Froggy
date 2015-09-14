using UnityEngine;
using System.Collections;

public class levelsCleared : MonoBehaviour {

	private static int clearedLevels;

	public static levelsCleared instance;

	void Awake()
	{
		instance = this;
//		clearedLevels = 0;
	}

	public void addClearedLevels()
	{
		clearedLevels++;
	}

	public int getClearedLevels()
	{
		return clearedLevels;
	}

}

