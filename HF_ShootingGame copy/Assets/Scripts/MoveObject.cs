using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
	public Transform endPos;
	public float speed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("g"))
		{
		
			MoveCamera();
		}
		
	}

	void MoveCamera()
	{
		float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);
	}
		
	
}
