using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretStraight : MonoBehaviour {

    #region Variables
    public enum projectileDirection {Front, Back, Up, Down};
    [Header("Shooting behaviour")]
    [Space]
    public projectileDirection directionProjectile;
    [Header("Projectile variables")]
    [Space]
    [Range(0, 20)] public int bulletSpeed;
    public float damageProjectile;
    public float spawnTime, deathTimer;
    [Header("GameObject options")]
	[Space]

    public GameObject projectileGO;
	public Transform projectileSpawn;
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

                if (directionProjectile == projectileDirection.Front) {

                    GameObject projectile = Instantiate(projectileGO) as GameObject;
                    projectile.GetComponent<projectileStats>().deathTimer = deathTimer;
					projectile.transform.position = projectileSpawn.position;
                    Rigidbody RB = projectile.GetComponent<Rigidbody>();
                    RB.useGravity = false;
                    Vector3 direction = transform.forward;
                    direction.Normalize();
                    RB.velocity = direction * bulletSpeed;
                    projectile.GetComponent<projectileStats>().projectileDamage = damageProjectile;
                }

                if (directionProjectile == projectileDirection.Back) {

                    GameObject projectile = Instantiate(projectileGO) as GameObject;
                    projectile.GetComponent<projectileStats>().deathTimer = deathTimer;
					projectile.transform.position = projectileSpawn.position;
                    Rigidbody RB = projectile.GetComponent<Rigidbody>();
                    RB.useGravity = false;
                    Vector3 direction = -transform.forward;
                    direction.Normalize();
                    RB.velocity = direction * bulletSpeed;
                    projectile.GetComponent<projectileStats>().projectileDamage = damageProjectile;
                }

                if (directionProjectile == projectileDirection.Up) {

                    GameObject projectile = Instantiate(projectileGO) as GameObject;
                    projectile.GetComponent<projectileStats>().deathTimer = deathTimer;
					projectile.transform.position = projectileSpawn.position;
                    Rigidbody RB = projectile.GetComponent<Rigidbody>();
                    RB.useGravity = false;
                    Vector3 direction = transform.up;
                    direction.Normalize();
                    RB.velocity = direction * bulletSpeed;
                    projectile.GetComponent<projectileStats>().projectileDamage = damageProjectile;

                }

                if (directionProjectile == projectileDirection.Down) {

                    GameObject projectile = Instantiate(projectileGO) as GameObject;
                    projectile.GetComponent<projectileStats>().deathTimer = deathTimer;
					projectile.transform.position = projectileSpawn.position;
                    Rigidbody RB = projectile.GetComponent<Rigidbody>();
                    RB.useGravity = false;
                    Vector3 direction = -transform.up;
                    direction.Normalize();
                    RB.velocity = direction * bulletSpeed;
                    projectile.GetComponent<projectileStats>().projectileDamage = damageProjectile;

                }

                Timer = Time.time + spawnTime;
            }
        }
    }
    
    #endregion
}