using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPlayer : MonoBehaviour {

	#region Variables
	public static bool attacking = false;
	private float attackTimer = 0;
	public float attackDuration = 0.3f;
	public Collider attackTrigger;
	private GameObject player;
	private statsPlayer statsPlayer;
	private movementPlayer movementPlayer;
	private Actions actions;
	private soundManager soundManager;
	#endregion
	
	#region Methods
	void Start () {
		attackTrigger.enabled = false;
		player = GameObject.Find ("player");
		statsPlayer = player.GetComponent<statsPlayer> ();
		movementPlayer = player.GetComponent<movementPlayer>();
		actions = player.GetComponent<Actions>();
		soundManager = GameObject.Find ("Sounds").GetComponent<soundManager> ();

	}
	
	void Update () {

		if(Input.GetKeyDown("j") && !attacking|| controllerScript.XButton() && !attacking)
        {
			if (!statsPlayer.isInvicible) {
				actions.Attack();
				attacking = true;
				attackTimer = attackDuration;
				attackTrigger.enabled = true;
				soundManager.PlayerAttackSound ();
			}

		}

		if(attacking){

			if(attackTimer > 0) attackTimer -= Time.deltaTime;
			else{ attacking = false; attackTrigger.enabled = false;}

		}
		
	}

	#endregion
}
