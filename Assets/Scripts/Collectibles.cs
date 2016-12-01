using UnityEngine;
using System.Collections;

public class Collectibles : MonoBehaviour {

	public int value;
	public float rotateSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.Rotate (Vector3.right * Time.deltaTime * -rotateSpeed);
	
	}

	void OnTriggerEnter() {
	
		GameManager.instance.Collect (value, gameObject);

		AudioSource source = GetComponent <AudioSource> ();

		source.Play ();

	
	}


}
