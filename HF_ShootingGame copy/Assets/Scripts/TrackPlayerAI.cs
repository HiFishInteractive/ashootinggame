using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerAI : MonoBehaviour {

	public UnityEngine.AI.NavMeshAgent agent;
	public Transform goHere;
    
    // Update is called once per frame
    void Update () 
    {
        
      

            
                agent.SetDestination(goHere.position);
            

    }
}
