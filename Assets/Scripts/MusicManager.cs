﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip mainTheme;
	public AudioClip menuTheme;

	string sceneName;

	void Awake(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void Start(){
		//AudioManager.instance.PlayMusic(menuTheme, 2);
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode){
		string newSceneName = SceneManager.GetActiveScene().name;
		if(newSceneName != sceneName){
			sceneName = newSceneName;
			Invoke("PlayMusic",.2f);
		}
	}

	void PlayMusic(){
		AudioClip clipToPlay = null;
		if(sceneName == "OpenScene"){
			clipToPlay = menuTheme;
		}else if(sceneName == "MainGame"){
			clipToPlay = mainTheme;
		}else if(sceneName == "PoemScene"){
			clipToPlay = menuTheme;
		}

		if (clipToPlay != null){
			AudioManager.instance.PlayMusic(clipToPlay, 2);
			Invoke("PlayMusic", clipToPlay.length);
		}
	}
}
