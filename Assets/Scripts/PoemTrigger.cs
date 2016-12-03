using UnityEngine;
using System.Collections;

public class PoemTrigger : MonoBehaviour {

	public GameObject managerObject;
	public GameObject canvas;
	private FadeCanvas fader;
	public UIManager textManager;
	public string newText;

	void Awake(){
		managerObject = GameObject.FindGameObjectWithTag("UIManager");
		canvas = GameObject.FindGameObjectWithTag("Canvas");
		fader = canvas.GetComponent<FadeCanvas>();
		textManager = managerObject.GetComponent<UIManager>();
		textManager.displayText = newText;
		//Debug.Log("Enter");
		fader.FadeIn();

	}


}
