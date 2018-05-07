using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingBoss : MonoBehaviour {

	public enum rotationDirection {left, right};
	public enum shootingDirection {Cross, DiagonalCross, CrossAndDiagonalCross}

	public Transform spawn;
	[Header("First Phase Variables")]
	public bool P1_Rotation;
	public rotationDirection P1_rotationDirection;
	public float P1_rotationSpeed; 
	public shootingDirection P1_shootingDirection;
	public float P1_shootRate;
	public float P1_shotSpeed;
	public float P1_Duration;
	public float P1_TimerNextPhase;
	public float P1_projectileDamage;
	public GameObject P1_ProjectileGO;

	[Header("Second Phase Variables")]
	public bool P2_Rotation;
	public rotationDirection P2_rotationDirection;
	public float P2_rotationSpeed; 
	public shootingDirection P2_shootingDirection;
	public float P2_shootRate;
	public float P2_shotSpeed;
	public float P2_Duration;
	public float P2_TimerNextPhase;
	public float P2_projectileDamage;
	public GameObject P2_ProjectileGO;
	

	[Header("Third Phase Variables")]
	public bool P3_Rotation;
	public rotationDirection P3_rotationDirection;
	public float P3_rotationSpeed; 
	public shootingDirection P3_shootingDirection;
	public float P3_shootRate;
	public float P3_shotSpeed;
	public float P3_Duration;
	public float P3_TimerNextPhase;
	public float P3_projectileDamage;
	public GameObject P3_ProjectileGO;

	private float PhaseTimer, ProjectileTimer, TempTimer;
	private movementPlayer movementPlayer;
	private int Phase;

	void Start () {
		 ProjectileTimer = Time.time + P1_shootRate;
		 PhaseTimer = 0;
		 Phase = 1;
		 TempTimer = 0;
		 movementPlayer = GameObject.Find("player").GetComponent<movementPlayer>();
	}
	
	void Update () {

	if(movementPlayer.checkDistance(this.transform.position)){
			switch(Phase){
				case 1:
				PhaseTimer += Time.deltaTime;
				if(PhaseTimer >= P1_Duration){TempTimer += Time.deltaTime; if(TempTimer > P1_TimerNextPhase){PhaseTimer = 0; TempTimer = 0; Phase = 2;} }
				else{
					if(P1_Rotation){
						if(P1_rotationDirection == rotationDirection.left){transform.Rotate(Vector3.forward * P1_rotationSpeed);}
						if(P1_rotationDirection == rotationDirection.right){transform.Rotate(-Vector3.forward * P1_rotationSpeed);}
					}

					if (ProjectileTimer < Time.time) {

							if(P1_shootingDirection == shootingDirection.Cross){ fireCross (P1_shotSpeed,P1_projectileDamage, P1_ProjectileGO); }

							if(P1_shootingDirection == shootingDirection.DiagonalCross){ fireDiagonalCross(P1_shotSpeed, P1_projectileDamage, P1_ProjectileGO); }

							if(P1_shootingDirection == shootingDirection.CrossAndDiagonalCross){ fireCrossAndDiagonalCross(P1_shotSpeed, P1_projectileDamage, P1_ProjectileGO); }

						ProjectileTimer = Time.time + P1_shootRate;
					}
				}

				break;

				case 2:
					PhaseTimer += Time.deltaTime;
					if(PhaseTimer >= P2_Duration){TempTimer += Time.deltaTime; if(TempTimer > P2_TimerNextPhase){PhaseTimer = 0; TempTimer = 0; Phase = 3;} }
					else{
						if(P2_Rotation){
							if(P2_rotationDirection == rotationDirection.left){transform.Rotate(Vector3.forward * P2_rotationSpeed);}
							if(P2_rotationDirection == rotationDirection.right){transform.Rotate(-Vector3.forward * P2_rotationSpeed);}
						}

						if (ProjectileTimer < Time.time) {

								if(P2_shootingDirection == shootingDirection.Cross){ fireCross (P2_shotSpeed, P2_projectileDamage, P2_ProjectileGO); }

								if (P2_shootingDirection == shootingDirection.DiagonalCross) { fireDiagonalCross (P2_shotSpeed, P2_projectileDamage, P2_ProjectileGO); }

								if(P2_shootingDirection == shootingDirection.CrossAndDiagonalCross){ fireCrossAndDiagonalCross (P2_shotSpeed, P2_projectileDamage, P2_ProjectileGO); }

							ProjectileTimer = Time.time + P2_shootRate;
						}
					}
				break;

				case 3:
					PhaseTimer += Time.deltaTime;
						if(PhaseTimer >= P3_Duration){TempTimer += Time.deltaTime; if(TempTimer > P3_TimerNextPhase){PhaseTimer = 0; TempTimer = 0; Phase = 1;} }
						else{
							if(P3_Rotation){
								if(P3_rotationDirection == rotationDirection.left){transform.Rotate(Vector3.forward * P3_rotationSpeed);}
								if(P3_rotationDirection == rotationDirection.right){transform.Rotate(-Vector3.forward * P3_rotationSpeed);}
							}

							if (ProjectileTimer < Time.time) {

									if(P3_shootingDirection == shootingDirection.Cross){ fireCross (P3_shotSpeed, P3_projectileDamage, P3_ProjectileGO); }

									if(P3_shootingDirection == shootingDirection.DiagonalCross){ fireDiagonalCross (P3_shotSpeed, P3_projectileDamage, P3_ProjectileGO); }

									if(P3_shootingDirection == shootingDirection.CrossAndDiagonalCross){ fireCrossAndDiagonalCross (P3_shotSpeed, P3_projectileDamage, P3_ProjectileGO); }

								ProjectileTimer = Time.time + P3_shootRate;
							}
						}
				break;


			}
		}
		
	}


	void fireCross(float shotSpeed, float projectileDamage, GameObject projectileGO){

		fireShot(spawn, spawn.right, shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, -spawn.right,shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, spawn.up,shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, -spawn.up, shotSpeed, projectileDamage, projectileGO);

	}


	void fireDiagonalCross(float shotSpeed, float projectileDamage, GameObject projectileGO){

		fireShot(spawn, (spawn.right + spawn.up), shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, -(spawn.right + spawn.up),shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, -(-spawn.right + spawn.up),shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, (-spawn.right + spawn.up), shotSpeed, projectileDamage, projectileGO);

	}

	void fireCrossAndDiagonalCross(float shotSpeed, float projectileDamage, GameObject projectileGO){

		fireShot(spawn, (spawn.right + spawn.up), shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, -(spawn.right + spawn.up),shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, -(-spawn.right + spawn.up),shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, (-spawn.right + spawn.up), shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, spawn.right, shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, -spawn.right,shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, spawn.up,shotSpeed, projectileDamage, projectileGO);
		fireShot(spawn, -spawn.up, shotSpeed, projectileDamage, projectileGO);


	}

	void fireShot(Transform spawnPosition, Vector3 directionProjectile, float bulletSpeed, float projectileDamage, GameObject projectileType){

		GameObject projectile = Instantiate(projectileType) as GameObject;
		projectile.GetComponent<projectileStats>().deathTimer = 100;
		projectile.transform.position = spawnPosition.position;
		Rigidbody RB = projectile.GetComponent<Rigidbody>();
		RB.useGravity = false;
		Vector3 direction = directionProjectile;
		direction.Normalize();
		RB.velocity = direction * bulletSpeed;
		projectile.GetComponent<projectileStats>().projectileDamage = projectileDamage;
	}

}
