using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public Text story_text;

	public string displayText;
	//public string testText = null;
	//public string newText = "Goomba";

	// Use this for initialization
	void Start () {
		displayText = "text";
	}
	
	// Update is called once per frame
	void Update () {
		story_text.text = displayText;
	}
}
