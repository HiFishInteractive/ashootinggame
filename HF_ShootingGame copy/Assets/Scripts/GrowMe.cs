using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowMe : MonoBehaviour {

	public int growTimer;

	void Start()
	{
		StartCoroutine(ScaleOverTime(.1f));
		//transform.localScale += new Vector3(2, 2, 2);
	}
 
	     IEnumerator ScaleOverTime(float time)
     {
         Vector3 originalScale = transform.localScale;
         Vector3 destinationScale = new Vector3(2.0f, 2.0f, 2.0f);
         
         float currentTime = 0.0f;
         
         do
         {
             transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
             currentTime += Time.deltaTime;
             yield return null;
			 
         } while (currentTime <= time);
         
         //Destroy(gameObject);
     }

	
	
}
