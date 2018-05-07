using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class essenceCounter : MonoBehaviour {


    public Text currentEssence;
    private statsPlayer statsPlayer;
    private float essence;

    void Start(){
        statsPlayer = GameObject.Find("player").GetComponent<statsPlayer>();
    }

	void Update () {
        currentEssence.text = (int)statsPlayer.essence + "";
    }
}
