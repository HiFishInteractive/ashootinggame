using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putMeBack : MonoBehaviour {

	 public Quaternion startRot;
	 public Vector3 startPos;
	 public bool putBack = false;
	 public bool dontMove = false;
	 public int waitTime = 2;
	 public AudioSource bumpAudio;

	void Start () {
		bumpAudio = GetComponent<AudioSource>();

		startPos = transform.position;
		startRot = transform.rotation;
		StartCoroutine(AudioInitialize());
		
	}
	
	void Update () {

			if (this.transform.position != startPos && putBack == false)
			{
				putBack = true;
				StartCoroutine(takeMeHome());	
			}

			if(dontMove == true)
			{
				
				bumpAudio.mute = true;
			}
			else
			{
				bumpAudio.mute = false;
			}
	}

	IEnumerator takeMeHome()
	{
		yield return new WaitForSeconds(waitTime);
		if (dontMove == false)
			{
			this.transform.position = startPos;
			transform.rotation = startRot;
			putBack = false;
			}
			else
			{
				putBack = false;
			}
	}
	IEnumerator AudioInitialize()
	{
		
		yield return new WaitForSeconds(2);
		bumpAudio.mute = true;

	}
}
