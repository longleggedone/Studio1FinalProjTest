using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {


	public float forwardVel = 40;
	public float rotateVel = 50;
	public float inputDelay = 0.1f;
	//bool canJump = true;

	
	Quaternion targetRotation;
	public Rigidbody rb;


	float forwardInput, turnInput, jumpInput;

	public Quaternion TargetRotation {
		get { return targetRotation; }
	}
		
	//public float moveSpeed;


	// Use this for initialization
 void Start () {

		GetComponent<Collider>().attachedRigidbody.AddForce(0, 1, 0);

		targetRotation = transform.rotation;

		if (GetComponent<Rigidbody> ()) { //if the object contains a rigidbody
			rb = GetComponent<Rigidbody> (); //set rb to equal rigidbody

			forwardInput = turnInput = 0;
		}

	
//		moveSpeed = 10f;
//		rb = GetComponent<Rigidbody> ();
	}

void GetInput()
{
		forwardInput = Input.GetAxis("Vertical");
		turnInput = Input.GetAxis ("Horizontal"); 
		jumpInput = Input.GetAxis ("Jump");

}

	// Update is called once per frame
void Update () {

		GetInput ();
		Turn ();
//		transform.Translate (moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
//	
//		if (Input.GetButtonDown("Jump"))
//			rb.velocity = new Vector3(0, 5, 0);
	}

void FixedUpdate()
{
	Run();
	Jump();
}

void Run()
{
	if(Mathf.Abs(forwardInput)>inputDelay)
	{
		//move
			rb.velocity = transform.forward * forwardInput * forwardVel;
	}
	else 
		//zero velocity
			rb.velocity = Vector3.zero;
}

void Turn()
	{
		if (Mathf.Abs (turnInput) > inputDelay) 
		{
			targetRotation = Quaternion.AngleAxis (rotateVel * 10f * turnInput * Time.deltaTime, Vector3.up);
			transform.rotation *= targetRotation;
		}
	}

void Jump()
	{
		if(Mathf.Abs (jumpInput)> inputDelay){
			rb.velocity = transform.up * jumpInput;
		}
	}

}
	