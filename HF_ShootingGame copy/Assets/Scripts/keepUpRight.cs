using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepUpRight : MonoBehaviour {

	public GameObject keepThisUpRight;
	Quaternion startRot;
	private float zRotation;
	private float yRotation;

	// Use this for initialization
	void Start () {

		//startRot = keepThisUpRight.transform(0,0,0);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		yRotation = keepThisUpRight.transform.rotation.eulerAngles.y;
		keepThisUpRight.transform.eulerAngles = new Vector3(0, yRotation, 0);

		
		
	}
}
