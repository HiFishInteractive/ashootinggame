using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartGameStarting : MonoBehaviour {
	
	AudioSource startButtonClick;
	AudioSource bgMusic;
	public Animator musicFade;
	public Animator openingFade;
	//public GameObject fadeScreen;
	public RectTransform screenFade;

	void Start()
	{
		//fadeScreen.SetActive(false);
	}


	public void StarGame()
	{
		screenFade.SetAsLastSibling();
		startButtonClick = GetComponent<AudioSource>();
        startButtonClick.Play();
		//fadeScreen.SetActive(true);
		musicFade.SetTrigger("FadeMusic");
		openingFade.SetTrigger("PressedStart");
		StartCoroutine(FadeAndLoad());
	}

	IEnumerator FadeAndLoad()
	{
		
		yield return new WaitForSeconds(2);
		Application.LoadLevel ("FPS_Scene1_Opening");
	}
	

}
