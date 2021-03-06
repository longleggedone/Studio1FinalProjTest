﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3 (0, 6, -8);
	public float xTilt = 10;

	Vector3 destination = Vector3.zero;
	CharacterControllerScript charController;
	float rotateVel = 0;




	// Use this for initialization
	void Start () {

		SetCameraTarget (target);
	
	}

	void SetCameraTarget (Transform t){

		target = t;

		if (target != null) {
			if (target.GetComponent<CharacterControllerScript> ()) {
				charController = target.GetComponent<CharacterControllerScript> ();
			} else
				Debug.Log ("camera's target needs a character controller");

		} else
			Debug.Log (" camera needs a target");


	}

	void LateUpdate (){

		//moving
		MoveToTarget();

		//rotating
		LookAtTarget();


	}

	void MoveToTarget(){

		destination = charController.TargetRotation * offsetFromTarget;
		destination += target.position;
		transform.position = destination;

	}

	void LookAtTarget(){

		float eulerYAngle = Mathf.SmoothDampAngle (transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
		transform.rotation = Quaternion.Euler (transform.eulerAngles.x, eulerYAngle, 0);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
