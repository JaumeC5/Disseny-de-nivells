using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthBar : MonoBehaviour {

    public Image currentHealthBar;
    public Text ratioText;
    private statsPlayer statsPlayer;

    private float health,maxHealth;

    void Start(){
        statsPlayer = GameObject.Find("player").GetComponent<statsPlayer>();
    }

    void Update() {
        health = statsPlayer.health;
        maxHealth = statsPlayer.maxHealth;
        currentHealthBar.rectTransform.localScale = new Vector3(health / maxHealth, 1, 1);
        ratioText.text = (int)health + " / " + maxHealth;
    }

}
