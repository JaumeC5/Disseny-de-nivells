using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerMovement : MonoBehaviour {

#region Variables
    [Header("Player variables")][Space]
    public float speed;
    public float maxSpeedX;
    public float maxSpeedY;
	public Collider playerCollider;
	public Transform raycastPosition;

    [Header("Physics variables")] [Space]
    public float jumpForce;
    [Tooltip("Multiplicador de caiguda del salt del jugador")]
    public float fallMultiplier;
    [Tooltip("Multiplicador de força del salt del jugador")]
    public float lowJumpMultiplier;
    public float jumpForce2;
    public float lowJumpMultiplier2;

    [Header("Knockback settings")][Space]
 
    public float knockbackDuration;
    public float knockbackPower;
    public Vector3 knockbackDirection;
    public float invincibleTime;
    public float immunityTimer;

    private bool facingRight;
    public bool isImmune;
    private float distanceGround;
    private float Timer;
    private float fallingTimer = 0.8f;
	private Transform currentPlatform;
    private float rayCastValue = 0.53f;
    private enum HitDirection { None, Top, Bottom, Forward, Back, Left, Right }
    private Rigidbody RB;
    private statsPlayer statsPlayer;
	private Actions actions;
    private bool jumpAgain = false;
    #endregion

    #region Methods

    void Start () {

        Timer = Time.time + fallingTimer;
        distanceGround = playerCollider.bounds.extents.y;
        facingRight = false;
		transform.parent = null;
        RB = this.GetComponent<Rigidbody>();      
        statsPlayer = GetComponent<statsPlayer>(); 
		actions = GetComponent<Actions>();
    }

    void controllerMovement() {

    }
	
	void FixedUpdate () {

        Rigidbody RB = this.GetComponent<Rigidbody>(); //Short player rigibidy body variable name
        Vector3 playerPos = this.transform.position; //Short player transform

        //Movement implementation
        if (!statsPlayer.isInvicible) {
            if (Input.GetKey(KeyCode.W) && isGrounded(this.gameObject) || controllerScript.AButton() && isGrounded(this.gameObject)) { //Jump
                RB.velocity = Vector3.up * jumpForce * (lowJumpMultiplier - 1) * Time.deltaTime; //When player is jumping
                jumpAgain = true;
				actions.Jump();
            }

            if (Input.GetKey(KeyCode.W) && jumpAgain == true && !isGrounded(this.gameObject) || controllerScript.AButton() && jumpAgain == true && !isGrounded(this.gameObject)  ) { //Jump Again
                RB.velocity = Vector3.up * jumpForce2 * (lowJumpMultiplier2 - 1) * Time.deltaTime; //When player is jumping
                jumpAgain = false;
				actions.Jump();
            }

            if (Input.GetKey(KeyCode.A) || controllerScript.hAxisLeft()) { //Left
                RB.transform.position = new Vector3(playerPos.x - speed, playerPos.y, playerPos.z);
				actions.Run();
                if (facingRight == false && attackPlayer.attacking == false) {
                    this.transform.Rotate(Vector3.up, 180);
                    facingRight = true;
                }
            }

            if (Input.GetKey(KeyCode.D) || controllerScript.hAxisRight()) { //Right
                RB.transform.position = new Vector3(playerPos.x + speed, playerPos.y, playerPos.z);
				actions.Run();
                if (facingRight == true && attackPlayer.attacking == false) {
                    this.transform.Rotate(Vector3.up, -180);
                    facingRight = false;
                }
            }

            if (Input.GetKey(KeyCode.S) || controllerScript.hAxisDown()) {
                RB.velocity = Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
                Physics.IgnoreLayerCollision(10, 9, true);
            }

            else {
                if (Timer < Time.time) {
					actions.Stay();
                    Timer = Time.time + fallingTimer;
                    Physics.IgnoreLayerCollision(10, 9, false);
                }
			

            }

            if (RB.velocity.y < 0) { RB.velocity = Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime; } //When player is falling

        }

        if (Input.GetKey(KeyCode.K) || controllerScript.BButton()) {statsPlayer.heal(); }

        //Activate and deactivate collision with enemies
        if(isImmune){Physics.IgnoreLayerCollision(9,14);}
        if(!isImmune){Physics.IgnoreLayerCollision(9,14, false);}

        //Stop knockback on touching ground
        if(this.GetComponent<statsPlayer>().isInvicible == true && isGrounded(this.gameObject)){RB.velocity = new Vector3(0,0,0);}

        //Control max speed
        if (RB.velocity.x > maxSpeedX){
            RB.velocity = new Vector3(maxSpeedX, RB.velocity.y, RB.velocity.z);
        }

        if(RB.velocity.x < -maxSpeedX){
            RB.velocity = new Vector3(-maxSpeedX, RB.velocity.y, RB.velocity.z);
        }

        if(RB.velocity.y > maxSpeedY){
            RB.velocity = new Vector3(RB.velocity.x, maxSpeedY, RB.velocity.z);
        }

        if(RB.velocity.y < -maxSpeedY){
            RB.velocity = new Vector3(RB.velocity.x, -maxSpeedY, RB.velocity.z);
        }

    }

    //Detect wheter a gameObject is touching the ground
    bool isGrounded(GameObject player) { 
        /*if(Physics.Raycast(player.transform.position, -Vector3.up, distanceGround + 0.001f) == true){return true;}
        if(Physics.Raycast(player.transform.position, new Vector3(rayCastValue,-1,0), distanceGround + 0.1f) == true) {return true; }
        if(Physics.Raycast(player.transform.position, new Vector3(-rayCastValue,-1,0), distanceGround + 0.1f) == true) {return true; }
        else{ return false; }*/
		return true;
        
    }


    //Knockback for the player or other gameObjects
    public IEnumerator knockback(GameObject collided){


        if(!this.GetComponent<statsPlayer>().isInvicible && !isImmune){
        StartCoroutine(invincible());
        float timer = 0;

        while(knockbackDuration > timer){

            timer += Time.deltaTime;
            RB.velocity = new Vector3(0,0,0);
            HitDirection collisionSide = checkCollisionSide(this.gameObject, collided);

            //Decide knockback direction
            if(facingRight == false && collisionSide == HitDirection.Left){RB.AddForce(new Vector3(knockbackDirection.x, knockbackDirection.y * knockbackPower, transform.position.z), ForceMode.Force);}
            if(facingRight == false && collisionSide == HitDirection.Right){RB.AddForce(new Vector3(-knockbackDirection.x, knockbackDirection.y * knockbackPower, transform.position.z), ForceMode.Force);}
            if(facingRight == true && collisionSide == HitDirection.Right){ RB.AddForce(new Vector3(-knockbackDirection.x, knockbackDirection.y * knockbackPower, transform.position.z), ForceMode.Force);}
            if(facingRight == true && collisionSide == HitDirection.Left){ RB.AddForce(new Vector3(knockbackDirection.x, knockbackDirection.y * knockbackPower, transform.position.z), ForceMode.Force);}
            if(facingRight == true && collisionSide == HitDirection.Bottom){ RB.AddForce(new Vector3(knockbackDirection.x, knockbackDirection.y * knockbackPower, transform.position.z), ForceMode.Force);}
            if(facingRight == false && collisionSide == HitDirection.Bottom){RB.AddForce(new Vector3(-knockbackDirection.x, knockbackDirection.y * knockbackPower, transform.position.z), ForceMode.Force);}
            if(facingRight == true && collisionSide == HitDirection.Top){ RB.AddForce(new Vector3(knockbackDirection.x, -knockbackDirection.y * knockbackPower, transform.position.z), ForceMode.Force);}
            if(facingRight == false && collisionSide == HitDirection.Top){ RB.AddForce(new Vector3(-knockbackDirection.x, -knockbackDirection.y * knockbackPower, transform.position.z), ForceMode.Force);}
        }
        isImmune = true;
        Invoke("resetInvulnerability", immunityTimer);
        yield return 0;
        }
    }

    public IEnumerator invincible(){

       statsPlayer.isInvicible = true;
       yield return new WaitForSeconds(invincibleTime);
       statsPlayer.isInvicible = false;           
       RB.velocity = new Vector3(0,0,0);   
    }

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "platform"){
			currentPlatform = collision.gameObject.transform;
			transform.SetParent(currentPlatform);
		}
	}

	void OnCollisionExit(Collision collision){
		if(collision.gameObject.tag == "platform"){transform.parent = null;}
	}

   private HitDirection checkCollisionSide( GameObject Object, GameObject ObjectHit ){
         
         HitDirection hitDirection = HitDirection.None;
         RaycastHit MyRayHit;
         Vector3 direction = ( Object.transform.position - ObjectHit.transform.position ).normalized;
         Ray MyRay = new Ray( ObjectHit.transform.position, direction );
         
         if ( Physics.Raycast( MyRay, out MyRayHit ) ){
                 
             if ( MyRayHit.collider != null ){
                 
                 Vector3 MyNormal = MyRayHit.normal;
                 MyNormal = MyRayHit.transform.TransformDirection( MyNormal );
                 
                 if( MyNormal == MyRayHit.transform.up ){ hitDirection = HitDirection.Top; }
                 if( MyNormal == -MyRayHit.transform.up ){ hitDirection = HitDirection.Bottom; }
                 if( MyNormal == MyRayHit.transform.forward ){ hitDirection = HitDirection.Forward; }
                 if( MyNormal == -MyRayHit.transform.forward ){ hitDirection = HitDirection.Back; }
                 if( MyNormal == MyRayHit.transform.right ){ hitDirection = HitDirection.Right; }
                 if( MyNormal == -MyRayHit.transform.right ){ hitDirection = HitDirection.Left; }
             }    
         }
         return hitDirection;
     }

    void resetInvulnerability(){ isImmune = false; }

    #endregion

}
