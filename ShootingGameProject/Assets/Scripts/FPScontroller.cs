using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroller : MonoBehaviour {

	public float speed = 2f;
	public float sensitivity = 2f;
	CharacterController PlayerAvatar;
	//private Rigidbody rb;

	public GameObject PlayerCamera;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	float moveFB; //front back
	float moveLR; //left right
	float rotX;
	float rotY;

	public float jumpForce = 4f;
	private float vertVelocity;
	private bool hasJumped, isCrouched;


	void Start () {
		//rb = GetComponent<Rigidbody> ();
		PlayerAvatar = GetComponent <CharacterController> ();
		
	}
	

	void Update () {

		//connect inputs to Axis(x2)
		moveFB = Input.GetAxis ("Vertical") * speed; 
		moveLR = Input.GetAxis ("Horizontal") * speed;

		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY -= Input.GetAxis ("Mouse Y") * sensitivity;
		rotY = Mathf.Clamp (rotY, -60f, 60f);

		Vector3 movement = new Vector3 (moveLR, vertVelocity, moveFB);   //Inputs now adjust player vector
		transform.Rotate (0, rotX, 0);

		movement = transform.rotation * movement;             //Movement is relative to player rotation
		PlayerAvatar.Move (movement * Time.deltaTime);
		//rb.velocity = movement * Time.deltaTime;


		//from space tutorial
		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//rb.velocity = movement * speed;
		//rb.position = new Vector3

		PlayerCamera.transform.localRotation = Quaternion.Euler (rotY, 0, 0);//handle rotationj

			
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
			//audioSource.Play ();
		}

		/*if (Input.GetButtonDown("Jump"))
		{
			hasJumped = true;
			//cause player to jump when jump button pressed. see ApplyGravity
		}*/

		/*if (Input.GetButtonDown ("Crouch")) 
		{
			if (isCrouched == false) {
				PlayerAvatar.height = PlayerAvatar.height / 2;
				isCrouched = true;
			}
			else
			{
				PlayerAvatar.height = PlayerAvatar.height * 2;
				isCrouched = false;
			}
		}*/

		ApplyGravity ();
		
	}



	private void ApplyGravity()
	{
		if (PlayerAvatar.isGrounded == true) 
		{
			
			if (hasJumped == false) {
				vertVelocity = Physics.gravity.y;
				//as long as the player is grounded, force on the player is equal to gravity (floating)
			} else 
			{
				vertVelocity = jumpForce;
			}
		} 
		else 
		{
			vertVelocity += Physics.gravity.y * Time.deltaTime;
			vertVelocity = Mathf.Clamp (vertVelocity, -50f, jumpForce);
			hasJumped = false;
		}
	}
}

