using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

	public float destroyTimer;
	public float disappearTimer;
	MeshRenderer coatOfPaint;

	void Start()
	{
		coatOfPaint = GetComponent<MeshRenderer>();
		StartCoroutine(DestructDelay());
		StartCoroutine(DisappearDelay());
	}

	IEnumerator DestructDelay()
	{
		
		yield return new WaitForSeconds(destroyTimer);
		Destroy (gameObject);

	}

	IEnumerator DisappearDelay()
	{
		
		yield return new WaitForSeconds(disappearTimer);
		coatOfPaint.enabled = !coatOfPaint.enabled;

	}

}
