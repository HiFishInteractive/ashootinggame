using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitThat : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	public float range = 50;
	public Camera fpsCam;
	//public Transform hitPointMarker;
	public GameObject hitPointSphere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			Shoot ();
		}
	}
		

	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
		{
			Debug.Log (hit.point);
			Debug.Log (hit.transform.name);
			//hitPointMarker = hit;
			Instantiate (shot, shotSpawn.position, Quaternion.LookRotation(hit.point-transform.position));
			//Instantiate (hitPointSphere, hit.point, Quaternion.identity); //Spawns object at hitpoint
			nextFire = Time.time + fireRate;
			//Quaternion.LookRotation(hit.point)
		}
	}
}
