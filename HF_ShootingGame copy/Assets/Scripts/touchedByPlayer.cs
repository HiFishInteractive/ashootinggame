using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class touchedByPlayer : MonoBehaviour {

	 public float touchDelayTime;
	 DoomEnemyKillIt mainBody;
	 //NavMeshAgent thisAgent2;

	 void Start()
	 {
		 //thisAgent2 = GetComponent<NavMeshAgent>();
		 mainBody = gameObject.GetComponentInParent<DoomEnemyKillIt>();
	 }


	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.CompareTag ("Player"))
		{
			
			mainBody.PlayerTouchStopper();
		
		}
	}
	
	
}
