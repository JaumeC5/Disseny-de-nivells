using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class enemyStats : MonoBehaviour {

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
	private movementJump movementJump;
	private movementPatrol patrolMovement;
	private effectsManager effectsManager;
    private floatingTextControllerDamage floatingTextDmg;
    private Rigidbody RB;
	private float hitDuration = 0.1f;
	private Animator animator;
	private bool animationCD = false;
	private float Timer;
	private soundManager soundManager;
    #endregion

    

    #region Methods
    void Start () {
		life = maxLife;
		isAlive = true;
		isHit = false;
		player = GameObject.Find("player");
		setName();
		playerStats = player.GetComponent<statsPlayer>();
		playerMovement = player.GetComponent<movementPlayer>();
		patrolMovement = this.gameObject.GetComponent<movementPatrol>();
		effectsManager = GameObject.Find ("gameController").GetComponent<effectsManager> ();
		animator = this.GetComponent<Animator> ();
        floatingTextDmg = GameObject.Find("gameController").GetComponent<floatingTextControllerDamage>();
        floatingTextControllerDamage.Initialize();
		movementJump = this.GetComponent<movementJump>();
		Timer = Time.time + hitDuration;
		soundManager = GameObject.Find ("Sounds").GetComponent<soundManager> ();
    }
	
	void Update () {
		checkStats ();
		if (animationCD) {
			if (Timer < Time.time) {
				animator.SetBool ("isHit", false);
				animationCD = false;
			}
		}
	}

    //When an enemy gets hit
    public void hitEnemy(float damage){
        floatingTextDmg.CreateFloatingText(damage.ToString(), transform);
        animator.SetBool("isHit", true);
		animationCD = true;
		Timer = Time.time + hitDuration;
		life -= damage;
		checkStats();
		checkDirection();
		isHit = true;
		soundManager.EnemyHitSound ();

	}
	
	public void killEnemy(){
       	playerStats.power += power;
		GameObject essenceDrop = Instantiate(essenceGO) as GameObject;
		essenceDrop.transform.position = this.transform.position;
		essenceDrop.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		essenceDrop.GetComponent<Rigidbody>().AddForce(new Vector3(0, 100,0), ForceMode.Force);
		effectsManager.instanceDeath (new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z));
        Destroy(this.gameObject);
		soundManager.EnemyDiesSound ();
	}

	void OnTriggerEnter(Collider collision) {
	
        if (collision.gameObject.tag == "player") {
			if(!playerMovement.isImmune){
				playerStats.hit(damage);
				checkDirection();
				StartCoroutine(playerMovement.knockback(this.gameObject));
			}
        }
	}

	public void checkStats(){
    if (life <= 0) { 

        if(this.gameObject.tag == "boss"){ SceneManager.LoadScene("youWinScene");}
        life = 0; isAlive = false; killEnemy ();} 
		else { isAlive = true; }

    isHit = false;
}

	public void checkDirection(){

		if (this.gameObject.tag == "patrolX" || this.gameObject.tag == "ghost2" || this.gameObject.tag == "ghost2" ) { patrolMovement.changeDirection (); }
		if (this.gameObject.tag == "rabbit1" || this.gameObject.tag == "rabbit2") { movementJump.changeDirection (); }


	}

	public void setName(){
		switch(this.gameObject.tag){
            case "turretP":
                enemyName = "Slime";
            break;
            case "turretS":
				enemyName = "Superior Slime";
			break;
			case "turretD":
				enemyName = "Ultra Slime";
			break;
			case "patrolX":
				enemyName = "Ghost";
			break;
            case "ghost2":
                enemyName = "Superior Ghost";
            break;
            case "patrolY":
				enemyName = "Bat";
			break;
            case "bat2":
                enemyName = "Superior Bat";
            break;
            case "rabbit1":
                enemyName = "Rabbit";
                break;
            case "rabbit2":
                enemyName = "Superior Rabbit";
                break;
            case "boss":
                enemyName = "BOSS";
                break;
        }
	}

	#endregion
}
