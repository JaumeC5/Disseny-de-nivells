using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestScript : MonoBehaviour {

    public GameObject essenceGO;
    private bool destroyed = false;
    public float essenceScale;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void dropEssence(){
		destroyed = true;
		GameObject essenceDrop = Instantiate(essenceGO) as GameObject;
		essenceDrop.transform.position = this.transform.position;
		essenceDrop.transform.localScale *= essenceScale;
		essenceDrop.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		essenceDrop.GetComponent<Rigidbody>().AddForce(new Vector3(0, 100,0), ForceMode.Force);
		Destroy(this.gameObject);
	}

	public void destroyChest(){
		if(destroyed == false){dropEssence();}
	}
}
