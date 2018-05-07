using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour {

	#region Variables
	private float playerAttack;
	public string[] enemyTags;
	#endregion

	#region Methods
	void Start () {
		playerAttack = GameObject.Find("player").GetComponent<statsPlayer>().attack;
	}
	
	void Update () {
		
	}

	void updateEnemyBar(GameObject gameObject){
		enemyHealthBar.enemyLife = gameObject.GetComponent<enemyStats>().life;
		enemyHealthBar.enemyMaxLife = gameObject.GetComponent<enemyStats>().maxLife;
		enemyHealthBar.enemyName = gameObject.GetComponent<enemyStats>().enemyName;
		enemyHealthBar.enemyHit = true;
	}

	void OnTriggerEnter(Collider col){

		if (col.isTrigger != true)
			for (int i = 0; i < enemyTags.Length; i++) {

				if (col.gameObject.tag == enemyTags [i]) {
					col.gameObject.GetComponent<enemyStats> ().hitEnemy (playerAttack);
					updateEnemyBar(col.gameObject);
                }

				if(col.gameObject.tag == "chest"){
					col.gameObject.GetComponent<chestScript>().destroyChest();
				}
			}
		}
	}



	#endregion

