using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoadOnTrigger: MonoBehaviour {

	//public string currentScene;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {

		if (other.CompareTag("Player"))
			SceneManager.LoadScene ("PoemScene");
	
	}
}
