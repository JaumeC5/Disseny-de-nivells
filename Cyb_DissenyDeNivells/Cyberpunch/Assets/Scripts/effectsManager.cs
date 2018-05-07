using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectsManager : MonoBehaviour {

	public GameObject healEffect;
	public GameObject deathEffect;
	public GameObject essenceEffect;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void instanceHeal(Vector3 position){
		GameObject heal = Instantiate(healEffect) as GameObject;
		heal.transform.position = position;
		
	}

	public void instanceDeath(Vector3 position){
		GameObject death = Instantiate(deathEffect) as GameObject;
		death.transform.position = position;

	}

	public void instanceEssence(Vector3 position){
		GameObject essence = Instantiate(essenceEffect) as GameObject;
		essence.transform.position = position;
	}

}
