using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementJump : MonoBehaviour {

	public enum behaviourEnum { byPositions, byTime, byCollision };
	#region Variables
	[Header("Patrol options and direction")]
	[Space]
	public behaviourEnum patrolBehaviour;
	[Header("Jump variables")]
	public float jumpTimer;
	public float jumpForce;
	[Header("Patrol controlled by time")]
	[Tooltip("Canvi de direcció cada 'x' segons")]
	[Range(0, 20)] public float patrolChangeTime;
	[Header("Patrol controlled by positions")]
	public float position1;
	public float position2;

	[Header("Patrol varaibles")]
	[Space]
	[Range(0, 1)] public float speed;
	public int direction = 1;
	[Header("Collision tags")]
	[Space]
	public string[] collisionTags;
	private float Timer,TimerJump, distanceGround;
	private Vector3 startPosition;
	private bool isGrounded = false;
	private Rigidbody RB;
	private movementPlayer movementPlayer;

	#endregion

	#region Methods
	void Start () {

		Timer = Time.time + patrolChangeTime;
		TimerJump = Time.time + jumpTimer;
		startPosition = this.transform.position;
		distanceGround = this.GetComponent<Collider>().bounds.extents.y;
		RB = this.GetComponent<Rigidbody>();
		movementPlayer = GameObject.Find("player").GetComponent<movementPlayer>();
	}


	void Update () {

		inspectorChecker();
		if(movementPlayer.checkDistance(this.transform.position)){
			if(Time.timeScale == 0){}   

			else{

				this.transform.position = new Vector3(this.transform.position.x - (speed * direction), this.transform.position.y, this.transform.position.z); 

				if (patrolBehaviour == behaviourEnum.byTime) {
					if (Timer < Time.time) {
						changeDirection();
						Timer = Time.time + patrolChangeTime;
					}
				}


				if(patrolBehaviour == behaviourEnum.byPositions){
						if(this.transform.position.x >= (startPosition.x + position1) || this.transform.position.x <= (startPosition.x  - position2)){changeDirection();}
					}
				}

				
				if(TimerJump < Time.time){
					if(isGrounded){
						jump();
						TimerJump = Time.time + jumpTimer;
					}
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		for(int i = 0; i < collisionTags.Length; i++){
			if(collision.gameObject.tag == collisionTags[i]){ changeDirection();}
		}

		if(collision.gameObject.tag == "ground"){
			isGrounded = true;
		}

		else{ isGrounded = false;}
	}

	public void changeDirection(){
			direction *= -1;
			this.transform.Rotate(Vector3.up, (180 * direction));
	}

	public void jump(){
		RB.velocity = new Vector3(0,0,0);
		RB.velocity = Vector3.up * jumpForce * (15 - 1) * Time.deltaTime;
		isGrounded = false;
	}


	public void inspectorChecker(){
		
	}

	#endregion
}

