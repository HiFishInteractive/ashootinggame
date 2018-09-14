using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaycastHitThat : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	public float range = 50;
	public Camera fpsCam;
	//public Transform hitPointMarker;
	public GameObject hitPointSphere;

	public AudioClip enemyHitSound;
	public AudioClip ricochet;
	public AudioSource gunShot;
	
	public GameObject shotSoundObject;
	gunShotSound makingSound;
	

	//doom stuff
	public int gunDamage = 1; 

	// Use this for initialization
	void Start () {
		gunShot = GetComponent<AudioSource>();
		makingSound = shotSoundObject.GetComponent<gunShotSound>();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			Shoot ();
			makingSound.dumbPizza();
		}
	}
		

	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
		{

			if (hit.transform.tag == "DoomEnemy")
			{
				gunShot.clip = enemyHitSound;
				gunShot.Play();
				
			}
			else
			{
				gunShot.clip = ricochet;
				gunShot.Play();
			}
			
			
			DoomEnemyKillIt health = hit.collider.GetComponent<DoomEnemyKillIt>();

                // If there was a health script attached
                if (health != null)
                {
                    // Call the damage function of that script, passing in our gunDamage variable
                    health.Damage (gunDamage);
					StartCoroutine(health.ShotDelay());

                }

			//Debug.Log (hit.point);
			//Debug.Log (hit.transform.name);
			//hitPointMarker = hit;
			Instantiate (shot, shotSpawn.position, Quaternion.LookRotation(hit.point-transform.position));
			
			Instantiate (hitPointSphere, hit.point, Quaternion.identity); //Spawns object at hitpoint
			nextFire = Time.time + fireRate;
			//Quaternion.LookRotation(hit.point)
		}
	}
}
