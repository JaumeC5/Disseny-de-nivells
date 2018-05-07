using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretParabola : MonoBehaviour {

    #region Variables
    [Header("Projectile options")]
	[Space]
    public Vector3 projectileForce;
    public float damageProjectile;
    public float bulletSpeed,spawnTime, deathTimer;
    
    [Header("GameObject options")]
	[Space]
    public Transform target;
	public Transform projectileSpawn;
    public GameObject projectileGO;
    private float Timer;
    private movementPlayer movementPlayer;
    #endregion

    #region Methods
    void Start() {
        Timer = Time.time + spawnTime;
         movementPlayer = GameObject.Find("player").GetComponent<movementPlayer>();
    }

    void Update() {

        if(movementPlayer.checkDistance(this.transform.position)){
            if (Timer < Time.time) {
                GameObject projectile = Instantiate(projectileGO) as GameObject;
                projectile.GetComponent<projectileStats>().deathTimer = deathTimer;
                projectile.transform.position = projectileSpawn.position;
                Rigidbody RB = projectile.GetComponent<Rigidbody>();
                Vector3 direction = target.position - projectileSpawn.position;
                direction.Normalize();
                RB.AddForce(projectileForce, ForceMode.Impulse); RB.velocity = direction * bulletSpeed;
                projectile.GetComponent<projectileStats>().projectileDamage = damageProjectile;
                Timer = Time.time + spawnTime;
            }

        }
    }

    #endregion
}
