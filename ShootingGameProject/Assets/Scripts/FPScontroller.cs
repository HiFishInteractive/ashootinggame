using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScontroller : MonoBehaviour {

	public float speed = 2f;
	public float sensitivity = 2f;
	CharacterController PlayerAvatar;

	public GameObject PlayerCamera;

	float moveFB; //front back
	float moveLR; //left right
	float rotX;
	float rotY;


	void Start () {
		PlayerAvatar = GetComponent <CharacterController> ();
		
	}
	

	void Update () {

		//connect inputs to Axis(x2)
		moveFB = Input.GetAxis ("Vertical") * speed;
		moveLR = Input.GetAxis ("Horizontal") * speed;

		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY = Input.GetAxis ("Mouse Y") * sensitivity;
		//rotY = Mathf.Clamp (rotY, -60f, 60f);

		Vector3 movement = new Vector3 (moveLR, 0, moveFB);   //Inputs now adjust player vector
		transform.Rotate (0, rotX, 0);
		movement = transform.rotation * movement;             //Movement is relative to player rotation
		PlayerAvatar.Move (movement * Time.deltaTime);
		PlayerCamera.transform.Rotate (-rotY, 0, 0);

		
	}
}
