using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpList : MonoBehaviour {

	public bool obtainedList;
	public Animator fadeOut;
	public FPScontroller playerControls;

	void Start()
	{
		playerControls = GetComponent<FPScontroller>();
		obtainedList = false;
	}

	void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("List"))
        {
		
        	other.gameObject.SetActive(false);
			obtainedList = true;

        }

		if(other.gameObject.CompareTag("frontDoor"))
			{
				StartCoroutine(LoadLevelDelay());
			}
    }	

	IEnumerator LoadLevelDelay()
	{
		playerControls.enabled = !playerControls.enabled;
		fadeOut.SetTrigger("FrontDoorFadeOut");
		yield return new WaitForSeconds(1);
		Application.LoadLevel ("Shooter_Main");
	}
	
}
