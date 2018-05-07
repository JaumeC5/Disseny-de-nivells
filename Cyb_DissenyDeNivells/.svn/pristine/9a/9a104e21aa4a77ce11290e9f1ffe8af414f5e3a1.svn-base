using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretCross : MonoBehaviour {

	public enum shootingDirection {Cross, DiagonalCross, CrossAndDiagonalCross}
	[Header("Shooting variables")]
	public shootingDirection _shootingDirection;
	public GameObject ProjectileGO;

	[Header("Projectile Variables")]
	public float shootRate;
	public float shotSpeed;
	public float projectileDamage;
	public float deathTimer;

	private float Timer;
	private Transform spawn;
	private movementPlayer movementPlayer;

	void Start () {
		Timer = Time.time + shootRate;
		spawn = this.transform;
		movementPlayer = GameObject.Find("player").GetComponent<movementPlayer>();
	}
	
	void Update () {

		if(movementPlayer.checkDistance(this.transform.position)){
			if (Timer < Time.time) {
				if (_shootingDirection == shootingDirection.Cross) { fireCross ();}
				if (_shootingDirection == shootingDirection.DiagonalCross) { fireDiagonalCross ();}
				if (_shootingDirection == shootingDirection.CrossAndDiagonalCross) { fireCrossAndDiagonalCross ();}
				Timer = Time.time + shootRate;
			}
		}
	}

	void fireCross(){

		fireShot(spawn, spawn.right);
		fireShot(spawn, -spawn.right);
		fireShot(spawn, spawn.up);
		fireShot(spawn, -spawn.up);

	}

	void fireDiagonalCross(){

		fireShot(spawn, (spawn.right + spawn.up));
		fireShot(spawn, -(spawn.right + spawn.up));
		fireShot(spawn, -(-spawn.right + spawn.up));
		fireShot(spawn, (-spawn.right + spawn.up));

	}

	void fireCrossAndDiagonalCross(){

		fireShot(spawn, (spawn.right + spawn.up));
		fireShot(spawn, -(spawn.right + spawn.up));
		fireShot(spawn, -(-spawn.right + spawn.up));
		fireShot(spawn, (-spawn.right + spawn.up));
		fireShot(spawn, spawn.right);
		fireShot(spawn, -spawn.right);
		fireShot(spawn, spawn.up);
		fireShot(spawn, -spawn.up);


	}

	void fireShot(Transform spawnPosition, Vector3 directionProjectile){

		GameObject projectile = Instantiate(ProjectileGO) as GameObject;
		projectile.GetComponent<projectileStats>().deathTimer = deathTimer;
		projectile.transform.position = spawnPosition.position;
		Rigidbody RB = projectile.GetComponent<Rigidbody>();
		RB.useGravity = false;
		Vector3 direction = directionProjectile;
		direction.Normalize();
		RB.velocity = direction * shotSpeed;
		projectile.GetComponent<projectileStats>().projectileDamage = projectileDamage;
	}

}

