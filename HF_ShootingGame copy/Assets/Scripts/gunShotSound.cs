using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShotSound : MonoBehaviour {

	public AudioSource gunShot;
	public int pizzapizza = 1;

	public void dumbPizza()
	{
		gunShot.Play();
	}
}
