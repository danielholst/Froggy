using UnityEngine;
using System.Collections;

public class levelsCleared : MonoBehaviour {

	public int clearedLevels;
	private GameObject settings;
	private bool[] cleared;

	void Start()
	{
		cleared = new bool[10];
		for (int i = 0; i < 10; i++) {
			cleared [i] = false;
		}

		settings = GameObject.FindGameObjectWithTag ("Settings");
		clearedLevels = 0;
	}
	void Awake()
	{
		DontDestroyOnLoad (this);
	}

	void Update()
	{
		if (settings != null) {
			if (settings.GetComponent<levelSettings> ().level == 2 && cleared [0] == false) {
				print ("increase levels cleared.. levels cleared = " + clearedLevels);
				clearedLevels++;
				cleared [0] = true;
			}
		}
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

