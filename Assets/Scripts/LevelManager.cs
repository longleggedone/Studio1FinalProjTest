using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public void LoadGame (string name) {

		Application.LoadLevel (name);
	
	}

	public void QuitGame(){

		Application.Quit ();

	}

}
