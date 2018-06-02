using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeContact : MonoBehaviour {

	//this is for the shots fired out of player's gun. The shots will destroy themselves upon contact with another object.
	public GameObject explodeHere;


	void OnTriggerEnter (Collider other)
	{
		Destroy (gameObject);		
	}

	void OnCollisionEnter(Collision collision)
	{
		ContactPoint contact = collision.contacts[0];
		//Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		Destroy(gameObject);
	}

}
