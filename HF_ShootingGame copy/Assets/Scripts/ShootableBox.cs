using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour {

	public int currentHealth = 3; //Health of object

	public void Damage (int damageAmount) //takes damage and tracks health -- int damageAmount declares var = to passed parameter when void called
	{
		currentHealth -= damageAmount; //makes health = current health minus damage taken
		if (currentHealth <= 0) 
		{
			gameObject.SetActive (false); //turns off object when health is lost
		}
	}
}
