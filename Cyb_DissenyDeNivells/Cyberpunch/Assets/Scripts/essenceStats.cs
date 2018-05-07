using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class essenceStats : MonoBehaviour {

    [Header("Essence variables")][Space]
    public int minimumEssence, maximumEssence;
	public float catchableTimer;
	public int essenceDrop;
	public int headLevelMultiplier;
	private float Timer;
	private statsPlayer statsPlayer;
	private movementPlayer movementPlayer;
    private floatingTextControllerEssence floatingTextEss;
	private soundManager soundManager;

    void Start () {
		essenceDrop = createRandom(minimumEssence, maximumEssence);
		Timer = Time.time + catchableTimer;
		statsPlayer = GameObject.Find("player").GetComponent<statsPlayer>();
		movementPlayer =  GameObject.Find("player").GetComponent<movementPlayer>();
		Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), movementPlayer.playerCollider, true);

        floatingTextEss = GameObject.Find("gameController").GetComponent<floatingTextControllerEssence>();
        floatingTextControllerEssence.Initialize();
		soundManager = GameObject.Find ("Sounds").GetComponent<soundManager> ();
    }
	void Update () {
		 if (Timer < Time.time) {
				Timer = Time.time + catchableTimer;
				Physics.IgnoreCollision(this.GetComponent<BoxCollider>(), movementPlayer.playerCollider, false);
			}
	}

	 void OnTriggerEnter(Collider collision) {

        switch(collision.gameObject.tag){
		case "player":
			statsPlayer.essence += essenceDrop;
			soundManager.CollectEssenceSound ();
        	Destroy(this.gameObject);
            floatingTextEss.CreateFloatingText(essenceDrop.ToString(), transform);
            break;
        }
    }

	public int createRandom(int min, int max){
		int newRandom = Random.Range(min + (PlayerPrefs.GetInt("headLevel") * headLevelMultiplier), max + (PlayerPrefs.GetInt("headLevel") * headLevelMultiplier));
		return newRandom;
	}
}
