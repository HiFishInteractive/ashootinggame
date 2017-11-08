using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour {

	public int gunDamage = 1; //damage done by gun, duh
	public float fireRate = .25f; //limits how often the weapon fires
	public float weaponRange = 50f;	//limits the range of the raycast
	public float hitForce = 100f; //applies force to the target struck by raycast
	public Transform gunEnd; //location of the end of the player gun

	private Camera fpsCam; //I think this is the game camera
	private WaitForSeconds shotDuration = new WaitForSeconds (.07f); //how long the line (laser) remains on screen
	private AudioSource gunAudio; //gun audio sound
	private LineRenderer laserLine; //renders the line
	private float nextFire; //uh...

	void Start () 
	{
		laserLine = GetComponent<LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		fpsCam = GetComponentInParent<Camera> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;

			StartCoroutine (ShotEffect ());
			//calls the coroutine shot effect


			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (.5f, .5f, 0)); //originates a raycast at center of screen and 0 is right at the player
				RaycastHit hit; //variable that holds info returned from the raycasting hitting object, raycasts return true/false

				laserLine.SetPosition (0, gunEnd.position); //to start the line renderer at the end of gun
		
				if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange))//starting place, forward from camera, store info of what hit, distance ray streches
				{
					laserLine.SetPosition (1, hit.point); //raycast hits something

				ShootableBox health = hit.collider.GetComponent<ShootableBox> ();//references the ShootableBox script on hit object

					if (health != null) //there is a shootable box on hit object
					{
					health.Damage (gunDamage);
					}
				if (hit.rigidbody != null) 
					{
					hit.rigidbody.AddForce (-hit.normal * hitForce);//adds force in opposite direciton from raycast received times force
					}
					
				}
				else
				{
					laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange)); //renderers line if nothing is hit
				}

		}
			
	}

	private IEnumerator ShotEffect() //creates a coroutine
	{
		//gunAudio.Play ();

		laserLine.enabled = true; //turn on line
		yield return shotDuration; //delay set time
		laserLine.enabled = false; //turn off line
	}
}
