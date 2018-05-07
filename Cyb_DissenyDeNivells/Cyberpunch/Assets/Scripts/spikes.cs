using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour {

	[Header("Spikes variables")]
	public float spikesDamage;
	private statsPlayer statsPlayer;
	private movementPlayer playerMovement;

	void Start () {
		statsPlayer = GameObject.Find("player").GetComponent<statsPlayer>();
		playerMovement =  GameObject.Find("player").GetComponent<movementPlayer>();
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.tag == "player"){
            statsPlayer.hit(spikesDamage);
            StartCoroutine(playerMovement.knockback(this.gameObject));
        }
    }
}