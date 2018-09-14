using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickLotteryNumbers : MonoBehaviour {

	public List<int> numberPool = new List<int>();
	public List<int> chosenNumbers = new List<int>();
	public int maxNumber;
	int randomNumber;

	// Use this for initialization
	void Start () {

		for(int i = 1; i<maxNumber; i++)
		{
			numberPool.Add(i);
		}

		for (int j = 0; j < maxNumber; j++)
		{
			randomNumber = Random.Range (0, numberPool.Count);
			chosenNumbers.Add(randomNumber);
			numberPool.Remove(randomNumber);
			//chosenNumbers[j] = randomNumber;

		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
