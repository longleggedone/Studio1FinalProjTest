using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoadOnTrigger: MonoBehaviour {
	public string levelToLoad = "PoemScene";
	public float timer = 5f;


	//public string currentScene;



	IEnumerator WaitToLoad(){
		yield return new WaitForSeconds(timer);
		SceneManager.LoadScene(levelToLoad);
	}

	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {

		if (other.CompareTag("Player"))
			StartCoroutine(WaitToLoad());
			//SceneManager.LoadScene (levelToLoad);
	
	}
}
