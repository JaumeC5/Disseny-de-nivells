using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class statsPlayer : MonoBehaviour {

    #region Variables
    [Header("Player variables")][Space]
    public float health;
    public float maxHealth = 100;
    public float power;
    public float maxPower = 100;
    public float essence = 0;
    public float attack;
    public int healPower = 30;
    [Header("Player stats")][Space]
	public bool isAlive; public bool isHit; public bool hasEssence; public bool hasPower; public bool isInvicible;
    private Color startingColor;
	private effectsManager effectsManager;
	private soundManager soundManager;
    #endregion

    #region Methods

    void Awake(){

       Scene currentScene = SceneManager.GetActiveScene ();
        switch(currentScene.name){
            case "Release":
            essence = 0;
            break;
            case "Release1":
            essence = 0;
            break;
            case "Release2":
            essence = 0;
            break;
            case "Release3":
            essence = 0;
            break;
            case "BaseScene":
            essence = PlayerPrefs.GetFloat("essence");
            break;
        }

        maxHealth = PlayerPrefs.GetFloat("maxHP");
        power = PlayerPrefs.GetFloat("power");
        attack = PlayerPrefs.GetFloat("attack");
        healPower = 20 + (PlayerPrefs.GetInt("legsLevel") * 20);
        if(maxHealth == 0){maxHealth = 100;}
		effectsManager = GameObject.Find ("gameController").GetComponent<effectsManager> ();
		soundManager = GameObject.Find ("Sounds").GetComponent<soundManager> ();

    }
    void Start () {
		isAlive = true;
		isHit = false;
		hasEssence = false;
		hasPower = false;	
        health = maxHealth;
        power = 0;
	}
	
	void Update () {
		
        //Control essence variable
		if(essence < 0) { essence = 0;}else{hasEssence = true;}
		if(health <= 0){ isAlive = false;} else{isAlive = true;}
		if (power > maxPower) {power = maxPower; hasPower = true;}else{hasPower = false;}
		isHit = false;	
        updatePlayerPrefs();

	}

    //Hit function and variable changes for it
    public void hit(float damage) {
        if(!isInvicible && GameObject.Find("player").GetComponent<movementPlayer>().isImmune == false){
		    isHit = true;
	        health -= damage;
			if (health > 0) {
				soundManager.PlayerHitSound ();
			}

        }
    }

    public void updatePlayerPrefs(){
        PlayerPrefs.SetFloat("essence", essence);
        PlayerPrefs.SetFloat("maxHP", maxHealth);
        PlayerPrefs.SetFloat("power", power);
        PlayerPrefs.SetFloat("attack", attack);
        healPower = 20 + (PlayerPrefs.GetInt("legsLevel") * 20);
    }

    public void heal(){
		if(power == maxPower){ 
			effectsManager.instanceHeal (new Vector3(this.transform.position.x, this.transform.position.y +1, this.transform.position.z - 0.5f));
			health += healPower;
			if (health > maxHealth) {
				health = maxHealth;
			}
			power = 0;
			soundManager.PlayerHealSound ();
		}
    }
    
    #endregion
}
