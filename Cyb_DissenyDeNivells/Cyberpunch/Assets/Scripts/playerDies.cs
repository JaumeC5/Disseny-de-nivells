using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerDies : MonoBehaviour
{

    public GameObject diedPanel;
    private statsPlayer statsPlayer;
	private soundManager soundManager;

	void Start(){
		statsPlayer = GameObject.Find("player").GetComponent<statsPlayer>();
		soundManager = GameObject.Find ("Sounds").GetComponent<soundManager> ();
	}

    void Update()
    {
        if (!statsPlayer.isAlive) { isKilled(); }
    }

    void isKilled()
    {
		soundManager.PlayerDiesSound();
        statsPlayer.health = 0;
        diedPanel.SetActive(true);
        Time.timeScale = 0;

    }

    public void clickToBase()
    {
        statsPlayer.health = statsPlayer.maxHealth;
        statsPlayer.isAlive = true;
        SceneManager.LoadScene("BaseScene");
        Time.timeScale = 1;
    }
}