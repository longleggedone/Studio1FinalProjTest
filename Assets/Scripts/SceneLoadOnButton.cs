﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoadOnButton: MonoBehaviour {

	//public string currentScene;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space))
			SceneManager.LoadScene ("MainGame");
	
	}
}
