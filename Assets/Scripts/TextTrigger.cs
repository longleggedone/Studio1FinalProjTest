using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour {

	public GameObject managerObject;
	public GameObject canvas;
	private FadeCanvas fader;
	public UIManager textManager;
	[TextArea(3,10)]
	public string newText;

	void Start(){
		managerObject = GameObject.FindGameObjectWithTag("UIManager");
		canvas = GameObject.FindGameObjectWithTag("Canvas");
		fader = canvas.GetComponent<FadeCanvas>();
		textManager = managerObject.GetComponent<UIManager>();

	}

	void OnTriggerEnter (Collider other){
		if(other.CompareTag("Player")){
			textManager.displayText = newText;
			Debug.Log("Enter");
			fader.FadeIn();
		}
	}

	void OnTriggerExit (Collider other){
		if(other.CompareTag("Player")){
			//textManager.story_text.text = null;
			Debug.Log("Exit");
			fader.FadeOut();
		}
	}
}
