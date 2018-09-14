using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoomEnemyKillIt : MonoBehaviour {

	
    //The Doom Enemy's current health point total
    public int currentHealth = 3;
	public Transform spawnHere;

    Rigidbody rb;

    public float shotDelayTime;
    public float touchDelayTime;
    NavMeshAgent thisAgent;

    void Start()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }
    
    

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (currentHealth <= 0) 
        {
            //if health has fallen below zero, deactivate it 
            //gameObject.SetActive (false);
			transform.position = spawnHere.position;
			currentHealth = 3;
        }
    }

    public IEnumerator ShotDelay()
    {
        thisAgent.Stop();
        yield return new WaitForSeconds(shotDelayTime);
        thisAgent.Resume();
    }

    public void PlayerTouchStopper()
    {
        StartCoroutine(PlayerTouchDelay());
    }

    public IEnumerator PlayerTouchDelay()
    {
        thisAgent.Stop();
        yield return new WaitForSeconds(touchDelayTime);
        thisAgent.Resume();
    }

}
