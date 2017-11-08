using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeContact : MonoBehaviour {

	//this is for the shots fired out of player's gun. The shots will destroy themselves upon contact with another object.

	void OnTriggerEnter (Collider other)
	{
		//Destroy (other.gameObject);
		Destroy (gameObject);
		//Instantiate (explosion, transform.position, transform.rotation);
		//gameController.AddScore (scoreValue);		
	}

}
