using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	public GameObject target;
	[Tooltip("Si la camera no encaixa, es poden tocar aquest valors per adaptar-ho el millor possible")]
	
	[Header("Camera offset")]
    [Space]
	public float offsetX;
	public float offsetY;
	public float offsetZ;
	
	void Start () {
		offsetZ = this.transform.position.z;
	}
	
	void Update () {

		this.transform.position = new Vector3(target.transform.position.x + offsetX, target.transform.position.y + offsetY, offsetZ);
		
	}
}
