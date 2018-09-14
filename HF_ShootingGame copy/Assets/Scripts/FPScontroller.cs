using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroller : MonoBehaviour {

	public float speed = 2f;
	public float sensitivity = 2f;
	CharacterController PlayerAvatar;
	//private Rigidbody rb;

	public GameObject PlayerCamera;

	//public GameObject shot;
	//public Transform shotSpawn;
	//public float fireRate;
	//private float nextFire;

	float moveFB; //front back
	float moveLR; //left right
	float rotX;
	float rotY;

	public float jumpForce = 4f;
	private float vertVelocity;
	private bool hasJumped, isCrouched;

	public float pushPower = 2.0F; //player's ability/power to push objects in scene


	void Start () 
		{
		PlayerAvatar = GetComponent <CharacterController> ();
		}
	

	void FixedUpdate () {

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

		PlayerCamera.transform.localRotation = Quaternion.Euler (rotY, 0, 0);//handle rotationj

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

	void OnControllerColliderHit(ControllerColliderHit hit) //Pretty sure this allows the player to push things in the environment.
	{
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;

		if (hit.moveDirection.y < -0.3F)
			return;

		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;
	}
}

