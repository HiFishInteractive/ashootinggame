using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryListPU : MonoBehaviour {

	public GameObject deactivateMe;

	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.CompareTag ("Player"))
        {
            deactivateMe.SetActive(false);
        }
    }
}
