using UnityEngine;
using System.Collections;

public class FadeCanvas : MonoBehaviour {

	public float fadeSpeed = 1f;

	private bool haltOut = false;
	private bool haltIn = false;

	public void FadeOut(){
		haltIn = true;
		haltOut = false;
		StartCoroutine (DoFadeOut()); //begins fade out coroutine
	}

	IEnumerator DoFadeOut(){
		CanvasGroup canvasGroup = GetComponent<CanvasGroup>(); //finds canvas group
		if(haltOut == true){
			yield break;
		}
		while (canvasGroup.alpha>0){ //while canvas group alpha is more than 0
			if(haltOut == true){
				yield break;
			}
			canvasGroup.alpha -= Time.deltaTime / fadeSpeed; //subtract deltatime divided by 2
			yield return null; //execute over multiple frames
		}
		canvasGroup.interactable = false; //disables player interaction with canvas
		yield return null;
	}

	public void FadeIn(){
		haltIn = false;
		haltOut = true;
		StartCoroutine (DoFadeIn());
	}

	IEnumerator DoFadeIn(){
		CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
		if(haltIn == true){
			yield break;
		}
		while(canvasGroup.alpha < 0.999f){
			if (haltIn == true){
				yield break;
			}
			canvasGroup.alpha += Time.deltaTime / fadeSpeed;
			yield return null;
		}
		canvasGroup.interactable = false;
		yield return null;
	}
}
