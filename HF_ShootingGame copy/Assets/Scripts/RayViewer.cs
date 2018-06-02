using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour {

	public float weaponRange = 50f; //how far the line travels

	private Camera fpsCam; //reference camera on player

	void Start () {
		fpsCam = GetComponentInParent<Camera>();
		
	}
	

	void Update () {
		Vector3 lineOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (.5f, .5f, 0));
		Debug.DrawRay (lineOrigin, fpsCam.transform.forward * weaponRange, Color.green, .05f);
		
	}
}
