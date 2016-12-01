using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {
	
	public float moveSpeed = 2;

	public float rotationSmooth = 0.2f;
	float turnSmoothVelocity;

	void Start () {
		
	}

	void Update() {
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")); //takes horizontal and verticl inputs and converts to vector
		Vector2 inputDirection = input.normalized; //normalizes input to get direction

		if(inputDirection != Vector2.zero){
			float targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, 
				targetRotation, ref turnSmoothVelocity, rotationSmooth);//sets the rotation using fancymath
		}

		float speed = moveSpeed * inputDirection.magnitude;
		transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
	}
}
