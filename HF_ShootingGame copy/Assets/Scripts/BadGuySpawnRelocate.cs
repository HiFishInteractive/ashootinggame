using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuySpawnRelocate : MonoBehaviour {

	public Transform setSpawnLocationHere;
	public GameObject enemySpawner;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag ("Player"))
		{
			enemySpawner.transform.position = setSpawnLocationHere.position;
		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
