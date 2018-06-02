using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

	public float destroyTimer;

	void Start()
	{
		StartCoroutine(DestructDelay());
	}

	IEnumerator DestructDelay()
	{
		
		yield return new WaitForSeconds(destroyTimer);
		Destroy (gameObject);

	}

}
