using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretDirect : MonoBehaviour {

    #region Variables
    public enum shootingBehaviour { Direct, DirectWithGravity, Homing };
    [Header("Shooting behaviour")]
	[Space]
    public shootingBehaviour shotType;
    [Header("Projectile variables")]
	[Space]
    public float bulletSpeed;
   
    public float spawnTime;
    public float damageProjectile;
    public float deathTimer;
    
    private Transform target;
    [Header("GameObject options")]
	[Space]
	public Transform projectileSpawn;
    public GameObject projectileGO;
    
    private float Timer;
    private movementPlayer movementPlayer;
	#endregion

	#region Methods
	void Start () {
        Timer = Time.time + spawnTime;
        target = GameObject.Find("player").transform;
        movementPlayer = GameObject.Find("player").GetComponent<movementPlayer>();
	}
	
	void Update () {

    if(movementPlayer.checkDistance(this.transform.position)){
            if (Timer< Time.time){

                GameObject projectile = Instantiate(projectileGO) as GameObject;
                projectile.GetComponent<projectileStats>().deathTimer = deathTimer;
                projectile.transform.position = projectileSpawn.position;
                Rigidbody RB = projectile.GetComponent<Rigidbody>();
                if(shotType == shootingBehaviour.Direct){RB.useGravity = false;}
                if(shotType == shootingBehaviour.Homing){RB.useGravity = false; projectile.GetComponent<projectileStats>().isHoming = true; projectile.GetComponent<projectileStats>().speed = bulletSpeed;}
                Vector3 direction = target.transform.position - projectileSpawn.position;
                direction.Normalize();
                RB.velocity = direction * bulletSpeed;
                projectile.GetComponent<projectileStats>().projectileDamage = damageProjectile;
                Timer = Time.time + spawnTime;
            }
        }
    }

    #endregion
}
