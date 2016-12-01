using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	public Animator anim; //animator component
	//public Rigidbody rb; //rigidbody


	//public float speed = 20f;
	private float inputH; //horizontal input
	private float inputV; //vertical input

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> (); //animator component on this object
		//rb = GetComponent<Rigidbody> (); //rigidbody component on this object
	
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("up") ) //if up is pressed
		{
			anim.Play ("Walk", -1, 0.2f); //play walk animation
		}

		if (Input.GetKeyDown("right") ) //if up is pressed
		{
			anim.Play ("Walk", -1, 0.2f); //play walk animation
		}
	
		if (Input.GetKeyDown("space"))  //if space is pressed
		{
			anim.Play ("Jump", -1, 0.2f); //play jump animation
		}


		inputH = Input.GetAxis ("Horizontal"); //horizontal input
		inputV = Input.GetAxis ("Vertical"); //vertical input

		anim.SetFloat("inputH", inputH); 
		anim.SetFloat("inputV", inputV);

		//float moveX = inputH * speed * Time.deltaTime;
		//float moveZ = inputV * speed * Time.deltaTime;

		//rb.velocity = new Vector3 (moveX, 0f, moveZ); //set rigidbody velocity to horizontal and vertical inputs times time and speed

			
	}
			
}
