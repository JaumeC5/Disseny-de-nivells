using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileStats : MonoBehaviour {

	#region Variables
    public float projectileDamage;
    public string[] collisionTags;
    public bool isHoming;
    private Transform target;
    private Rigidbody RB;
    public float speed, deathTimer;
    private float Timer;
    private statsPlayer statsPlayer;
    private movementPlayer movementPlayer;
	#endregion

	#region Methods
	void Start () {
        RB = GetComponent<Rigidbody>();
        target = GameObject.Find("player").transform;
        Timer = Time.time + deathTimer;
        statsPlayer =  GameObject.Find("player").GetComponent<statsPlayer>();
        movementPlayer = GameObject.Find("player").GetComponent<movementPlayer>();
	}
	
	void FixedUpdate () {

        if(isHoming){

            Vector3 direction = target.transform.position - this.transform.position;
            direction.Normalize();
            RB.velocity = direction * speed;
        }
        else{}

        if (Timer < Time.time) { Destroy(this.gameObject); }

    }


    //For projectile to destroy when in contact with the following tags:
    void OnCollisionEnter(Collision collision) {

       for(int i = 0; i < collisionTags.Length; i++){

            if(collision.gameObject.tag == collisionTags[i]){ 
                Destroy(this.gameObject);}
        }

    }

    void OnTriggerEnter(Collider collision){

           for(int i = 0; i < collisionTags.Length; i++){

            if(collision.gameObject.tag == collisionTags[i]){ 
                if(collisionTags[i] == "player"){
                    if(!movementPlayer.isImmune){
                    statsPlayer.hit(projectileDamage);
                    StartCoroutine(movementPlayer.knockback(this.gameObject));
                }
                Destroy(this.gameObject);}
            }
        }
    }

    #endregion
}
