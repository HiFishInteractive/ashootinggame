using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExplosionOnImpact : MonoBehaviour {

	public float radius;
	public float power;
	public float upwardForce;
	private Vector3 Location;
	public GameObject explosionVisual;

	void OnCollisionEnter(Collision collision)
	{
		ContactPoint contact = collision.contacts[0];
		//Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		Instantiate (explosionVisual, explosionPos, Quaternion.identity);

		foreach (Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb != null)
				rb.AddExplosionForce(power, explosionPos, radius, upwardForce);

		}
	}

}