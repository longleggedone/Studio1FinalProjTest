using UnityEngine;
using System.Collections;

public class CharacterControllerScript: MonoBehaviour {

	[System.Serializable]
	public class MoveSettings{
		public float forwardVel = 12f;
		public float rotateVel = 100f;
		public float jumpVel = 25f;
		public float distToGrounded = 0.1f;
		public LayerMask ground;
	}

	[System.Serializable]
	public class PhysSettings{
		public float downAccel = 0.75f;
	}

	[System.Serializable]
	public class InputSettings{
		public float inputDelay = 0.1f; //
		public string FORWARD_AXIS = "Vertical";
		public string TURN_AXIS = "Horizontal";
		public string JUMP_AXIS = "Jump";
	}

	public AudioClip jumpAudio;

	public MoveSettings moveSetting = new MoveSettings();
	public PhysSettings physSetting = new PhysSettings();
	public InputSettings inputSetting = new InputSettings();


	//bool canJump = true;

	Vector3 velocity = Vector3.zero;
	Quaternion targetRotation;
	public Rigidbody rb;
	float forwardInput, turnInput, jumpInput;

	public Quaternion TargetRotation {
		get { return targetRotation; }
	}

	bool Grounded(){
		return Physics.Raycast(transform.position, Vector3.down, moveSetting.distToGrounded, moveSetting.ground);
	}
	//public float moveSpeed;


	// Use this for initialization
 	void Start () {

		//GetComponent<Collider>().attachedRigidbody.AddForce(0, 1, 0);

		targetRotation = transform.rotation;

		if (GetComponent<Rigidbody> ()) { //if the object contains a rigidbody
			rb = GetComponent<Rigidbody> (); //set rb to equal rigidbody

			forwardInput = turnInput = jumpInput =  0;
		}


	
//		moveSpeed = 10f;
//		rb = GetComponent<Rigidbody> ();
	}

	void GetInput()
	{
		forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS);
		turnInput = Input.GetAxis (inputSetting.TURN_AXIS); 
		jumpInput = Input.GetAxisRaw (inputSetting.JUMP_AXIS);

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

		rb.velocity = transform.TransformDirection(velocity);
	}

	void Run()
	{
		if(Mathf.Abs(forwardInput)>inputSetting.inputDelay) //checks if the absolute value of our forward input is greater than our input delay
		{
			velocity.z = moveSetting.forwardVel * forwardInput;
			//rb.velocity = transform.forward * forwardInput * moveSetting.forwardVel; //set forward/backward movement
		}
		else {
			velocity.z = 0;
			//rb.velocity = Vector3.zero; //ensure zero movement
		}
	}
	
	void Turn()
	{
		if (Mathf.Abs (turnInput) > inputSetting.inputDelay) 
		{
			targetRotation *= Quaternion.AngleAxis (moveSetting.rotateVel * 10f * turnInput * Time.deltaTime, Vector3.up); //rotate on the up axis
			transform.rotation = targetRotation;
		}
	}

	void Jump()
	{
		if (jumpInput > 0 && Grounded()){ //if we are grounded and our we input for a jump
			velocity.y = moveSetting.jumpVel; //set our upward velocity to jumping velocity
		}else if (jumpInput == 0 && Grounded()){ //if we are grounded and are not inputing a jump
			velocity.y = 0; //zero out upward velocity
		}else{ //if we are falling
			velocity.y -= physSetting.downAccel; //decrease upward velocity
		}
				//if(Mathf.Abs (jumpInput)> inputSetting.inputDelay){
				//rb.velocity = transform.up * jumpInput;
				//}
	}
}
	