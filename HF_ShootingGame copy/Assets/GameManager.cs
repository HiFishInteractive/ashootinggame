using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject livingRoomPlayer; //reference to the living room player
	public GameObject doomRoomPlayer;	//reference to the doom level player
	public GameObject doomGunArm;		//reference to the the arm of the doom player (to get disabled)
	public GameObject livingGun;		//reference to the living room gun thing
	private FPScontroller livingController; //reference for living room player FPS script (to be activated)
	private FPScontroller doomController;	//reference for doom player FPS script (to be deactivated)
	private RaycastHitThat disableThisScript; //reference to the script on the gun arm of the doom level (to be deactivated)
	private RaycastHitThat enableThisScript; //reference the script that activates when we switch to the living room

	public Camera playerCam;
	public float time;

	// Use this for initialization
	void Start () {

		disableThisScript = doomGunArm.GetComponent<RaycastHitThat>(); //reference
		enableThisScript = livingGun.GetComponent<RaycastHitThat>();	//reference
		livingController = livingRoomPlayer.GetComponent<FPScontroller>();	//reference
		livingController.enabled = !livingController.enabled; //the ! tells it to toggle to the opposite of its current state
		enableThisScript.enabled = !enableThisScript.enabled;
		doomController = doomRoomPlayer.GetComponent<FPScontroller>();


		StartCoroutine(ActivatePlayer());
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator ActivatePlayer()
	{
		yield return new WaitForSeconds(time);
		livingController.enabled = !livingController.enabled;
		doomController.enabled = !doomController.enabled;
		disableThisScript.enabled = !disableThisScript.enabled;
		enableThisScript.enabled = !enableThisScript.enabled;
		playerCam.depth = 0;
	}
}
