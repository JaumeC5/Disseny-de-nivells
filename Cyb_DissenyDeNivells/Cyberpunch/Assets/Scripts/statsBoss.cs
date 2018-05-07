using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statsBoss : MonoBehaviour {

	#region Variables
	[Header("Enemy variables")][Space]
	public string enemyName;
	public float life;
	public float maxLife;
	public float damage;
	public float power;
	private GameObject player;
	[Header("Enemy drop variables")][Space]
	public GameObject essenceGO;
	[Header("Enemy status")][Space]
	public bool isAlive;
	public bool isHit;
	private statsPlayer playerStats;
	private movementPlayer playerMovement;
	private movementPatrol patrolMovement;
	private Rigidbody RB;
	#endregion

	#region Methods
	void Start () {
		life = maxLife;
		isAlive = true;
		isHit = false;
		player = GameObject.Find("player");
		playerStats = player.GetComponent<statsPlayer>();
		playerMovement = player.GetComponent<movementPlayer>();
		patrolMovement = this.gameObject.GetComponent<movementPatrol>();
	}
	
	void Update () {
		checkStats ();
	}

	//When an enemy gets hit
	public void hitEnemy(float damage){
		life -= damage;
		checkStats();
		isHit = true;
	}
	
	public void killEnemy(){
       	playerStats.power += power;
		GameObject essenceDrop = Instantiate(essenceGO) as GameObject;
		essenceDrop.transform.position = this.transform.position;
		essenceDrop.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		essenceDrop.GetComponent<Rigidbody>().AddForce(new Vector3(0, 100,0), ForceMode.Force);
        Destroy(this.gameObject);
	}

	void OnCollisionEnter(Collision collision) {
	
        if (collision.gameObject.tag == "player") {
			playerStats.hit(damage);
            StartCoroutine(playerMovement.knockback(this.gameObject));
        }
	}

	public void checkStats(){
		if (life <= 0) { life = 0; isAlive = false; killEnemy ();} else { isAlive = true; }
		isHit = false;
	}
	
	#endregion
}

