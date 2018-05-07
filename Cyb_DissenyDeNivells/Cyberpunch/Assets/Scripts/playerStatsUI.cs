using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStatsUI : MonoBehaviour {

    private float health, attack, essence, heal;
    public Text healthText, attackText, essenceText, healText;
    
    private statsPlayer statsPlayer;

    void Start()
    {
        statsPlayer = GameObject.Find("player").GetComponent<statsPlayer>();
    }

    void Update()
    {
        health = statsPlayer.maxHealth;
        attack = statsPlayer.attack;
        essence = ((10 + (PlayerPrefs.GetInt("headLevel") * 2)) + (15 + (PlayerPrefs.GetInt("headLevel") * 2))) / 2;
        heal = statsPlayer.healPower;

        healthText.text = (int)health + "";
        attackText.text = (int)attack + "";
        essenceText.text = "~" + (int)essence;
        healText.text = (int)heal + "";

    }

}
