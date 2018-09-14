using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraCinematic : MonoBehaviour {

public GameObject moveMe; //this is the object that will be moved.
public Transform startPos; //starting position for moving object
public Transform endPos; //ending position for moving object
public float speed; //rate of moving object moving.
private bool goTime; //boolean that tells the object to begin moving
public float timer;

public RenderTexture tvTexture; //render texture that is applied to tv screen
public Camera doomCam; //camera that will be applied to render texture

public Animator anim; //attach screenfader from canvas to access animator...
public Animator animSphere; //animator for the sphere
public Animator fadeIn; //for fade in when scene opens

public GameObject toyGun; //this is the gun the player is using to play on TV
public GameObject plasmaGun; //this is the gun that replaces the toyGun

public Text getTheList; //text referencing the command to get the shopping list
public Text gotTheList; //text referencing the notification that the player picked up the list
public Text timeToLeave; //text referencing the command to leave the house
public PickUpList obtainedList; //variable to hold play's script
public GameObject player; //play avatar goes here
public bool leaveCommandText; //track whether to tell the player to leave


	void Start () {
		plasmaGun.SetActive(false); //hide the plasma gun
		goTime = false; //waiting to be activated
		getTheList.text = ""; //hides the text
		gotTheList.text = ""; //hides the text
		timeToLeave.text = "";  //hides the text
		obtainedList = player.GetComponent<PickUpList>(); //to access scripts boolean.

		anim = anim.GetComponent<Animator>(); //set anim to screenfader's animator object
		animSphere = animSphere.GetComponent<Animator>(); //set animSphere to gunswitch animation
		fadeIn.SetTrigger("GameStartFadeIn");

		StartCoroutine(TransitionTimer());
		
	}

	void Update () 
	{
		if(goTime == true)
		{
			MoveCam();
		}

		if(moveMe.transform.position == endPos.position)
		{
			StartCoroutine(GunSwitch());
		}

		if (obtainedList.obtainedList == true)
		{
			getTheList.text = " ";
			gotTheList.text = "You got the Shopping List!";
			StartCoroutine(TimeToLeaveText());
		}

		if (leaveCommandText == true)
		{
			gotTheList.text = " ";
			timeToLeave.text = "Now, leave through the front door!";
		}

		
	}

	void MoveCam()
	{
		float step = speed * Time.deltaTime;
        moveMe.transform.position = Vector3.MoveTowards(startPos.transform.position, endPos.position, step);
	}

	IEnumerator TransitionTimer() //Starts a timer at beginning of game till transition begins
	{
		yield return new WaitForSeconds(timer);
		StartCoroutine(GameTransition());
		goTime = true; //allows the move camera animation to start
	}

	IEnumerator GameTransition () //creates fade and switches cameras
	{
		anim.SetTrigger("AvatarSwitch"); //call upon the AvatarSwitch transition from the Animation
		yield return new WaitForSeconds(1);
		doomCam.targetTexture = tvTexture; 	
	}

	IEnumerator GunSwitch()
	{
		animSphere.SetTrigger("GunGun");
		yield return new WaitForSeconds(1);
		toyGun.SetActive(false);
		plasmaGun.SetActive(true);
		StartCoroutine(GetTheListActivate());

	}

	IEnumerator GetTheListActivate()
	{
		yield return new WaitForSeconds(1);
		getTheList.text = "Stop playing that game and get the shopping list off the fridge!";
	}

	IEnumerator TimeToLeaveText()
	{
		yield return new WaitForSeconds(3);
		leaveCommandText = true;
		
	}

	
}
