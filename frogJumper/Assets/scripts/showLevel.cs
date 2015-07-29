using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showLevel : MonoBehaviour {

	public int level;
	private Text text;

	void Start()
	{
		text = GetComponent<Text>();
	}
	
	void OnGUI () {

		text.text = "Level " + level;
		Color color = text.color;
		text.fontSize = 32;
		color.a -= 0.005f;
		text.color = color;
	
		GUI.backgroundColor = Color.clear;


	}

//	function Start(){ 
//		guiText.material.color.a = 0;
//		yield WaitForSeconds(2);
//		FadeIn();
//	}  
//	function FadeIn(){
//		while (guiText.material.color.a < 1){
//			guiText.material.color.a += 0.1 * Time.deltaTime * 2;
//			yield;    
//		}  
//		yield WaitForSeconds(2);
//		FadeOut();  
//	}
//	
//	function FadeOut(){
//		while (guiText.material.color.a > 0){
//			guiText.material.color.a -= 0.1 * Time.deltaTime * 2;
//			yield;    
//		}    
//		Destroy (gameObject);
//	}

}