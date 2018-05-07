using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class splashScene : MonoBehaviour {


	public float SplashDuration;
	private float Timer;


	void Start () {
		Timer = Time.time + SplashDuration;
	}
	
	// Update is called once per frame
	void Update () {
		 if (Timer < Time.time) {	SceneManager.LoadScene("mainMenu"); }
	}
}
