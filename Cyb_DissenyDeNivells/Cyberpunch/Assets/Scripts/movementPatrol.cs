using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPatrol : MonoBehaviour {

    public enum directionEnum { MovementX, MovementY };
    public enum behaviourEnum { byPositions, byTime, byCollision };
    #region Variables
    [Header("Patrol options and direction")]
    [Space]
    public directionEnum patrolDirection;
    public behaviourEnum patrolBehaviour;
    public bool gravity;
    [Header("Patrol controlled by time")]
    [Tooltip("Canvi de direcció cada 'x' segons")]
    [Range(0, 20)] public float patrolChangeTime;
    [Header("Patrol controlled by positions")]
    public Vector2 position1;
    public Vector2 position2;

    [Header("Patrol varaibles")]
    [Space]
    [Range(0, 1)] public float speed;
    public int direction = 1;
    [Header("Collision tags")]
    [Space]
    public string[] collisionTags;
    private float Timer;
    private Vector3 startPosition;
    private Rigidbody RB;
    private movementPlayer movementPlayer;

	#endregion

	#region Methods
	void Start () {

        Timer = Time.time + patrolChangeTime;
        startPosition = this.transform.position;
        RB = this.GetComponent<Rigidbody>();
        movementPlayer = GameObject.Find("player").GetComponent<movementPlayer>();
    }


    void Update () {

        inspectorChecker();

        if(movementPlayer.checkDistance(this.transform.position)){
            if(Time.timeScale == 0){}   

            else{

                if (patrolDirection == directionEnum.MovementX) {this.transform.position = new Vector3(this.transform.position.x - (speed * direction), this.transform.position.y, this.transform.position.z); } 
                else { this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (speed * direction), this.transform.position.z); }

                if (patrolBehaviour == behaviourEnum.byTime) {
                    if (Timer < Time.time) {
                        changeDirection();
                        Timer = Time.time + patrolChangeTime;
                    }
                }

                if(patrolBehaviour == behaviourEnum.byPositions){
                    switch(patrolDirection){

                        case directionEnum.MovementX:
                            if(this.transform.position.x >= (startPosition.x + position1.x) || this.transform.position.x <= (startPosition.x  - position2.x)){changeDirection();}
                        break;
                        case directionEnum.MovementY:
                            if(this.transform.position.y >= (startPosition.y + position1.y) || this.transform.position.y <= (startPosition.y  - position2.y)){changeDirection();}
                        break;

                    }
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        for(int i = 0; i < collisionTags.Length; i++){

            if(collision.gameObject.tag == collisionTags[i]){ changeDirection();}
        }
    }
    public void changeDirection(){

        if(patrolDirection == directionEnum.MovementX){
              direction *= -1;
              this.transform.Rotate(Vector3.up, (180 * direction));
        }

        else{
            direction *= -1;
        }
    }

    public void inspectorChecker(){

        if(!gravity){RB.useGravity = false; } else{RB.useGravity = true; }
    }

    #endregion
}
