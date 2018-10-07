using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactAudio : MonoBehaviour {

	private AudioSource impactAudio;
	private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;

	// Use this for initialization
	void Start () {
		impactAudio = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	   void OnCollisionEnter (Collision coll)
    {
        impactAudio.pitch = Random.Range (lowPitchRange,highPitchRange);
        impactAudio.Play();
    }
}
