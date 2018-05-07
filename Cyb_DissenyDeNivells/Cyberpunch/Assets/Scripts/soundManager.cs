using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {

	public AudioSource capsuleSound;
	public AudioSource collectEssenceSound;
	public AudioSource enemyDiesSound;
	public AudioSource enemyHitSound;
	public AudioSource playerHealSound;
	public AudioSource playerHitSound;
	public AudioSource playerDiesSound;
	public AudioSource playerAttackSound;
	public AudioSource portalSound;


	public void CapsuleSound(){
		capsuleSound.volume = PlayerPrefs.GetFloat ("music");
		capsuleSound.Play();
	}
    public void CapsuleSoundPause()
    {
        capsuleSound.Stop();
    }

    public void CollectEssenceSound(){
		collectEssenceSound.volume = PlayerPrefs.GetFloat ("music");
		collectEssenceSound.Play();
	}
	public void EnemyDiesSound(){
		enemyDiesSound.volume = PlayerPrefs.GetFloat ("music");
		enemyDiesSound.Play();
	}
	public void PlayerHealSound(){
		playerHealSound.volume = PlayerPrefs.GetFloat ("music");
		playerHealSound.Play();
	}
	public void EnemyHitSound(){
		enemyHitSound.volume = PlayerPrefs.GetFloat ("music");
		enemyHitSound.Play();
	}
	public void PlayerHitSound(){
		playerHitSound.volume = PlayerPrefs.GetFloat ("music");
		playerHitSound.Play();
	}
	public void PlayerDiesSound(){
		playerDiesSound.volume = PlayerPrefs.GetFloat ("music");
		playerDiesSound.Play ();
	}
	public void PlayerAttackSound(){
		playerAttackSound.volume = PlayerPrefs.GetFloat ("music");
		playerAttackSound.Play ();
	}
	public void PortalSound(){
		portalSound.volume = PlayerPrefs.GetFloat ("music");
		portalSound.Play ();
	}

}
