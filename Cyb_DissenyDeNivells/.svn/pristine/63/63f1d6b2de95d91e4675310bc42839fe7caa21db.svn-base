using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeMenu : MonoBehaviour {

	#region Variables
	public int headLevel, handsLevel, chestLevel, legsLevel;
    //        Current level    0   1   2   3   4   5   6   7   8    9   10   11   12   13   14   15   16   17   18   19   20   21   22   23   24  25
	private int[] headCost = {10, 30, 50, 70, 90, 110, 130, 150, 170, 190, 210, 230, 250, 270, 290, 310, 330, 350, 370, 390, 410, 430, 450, 470, 490, 0};
	private int[] handsCost = {10, 30, 50, 70, 90, 110, 130, 150, 170, 190, 210, 230, 250, 270, 290, 310, 330, 350, 370, 390, 410, 430, 450, 470, 490, 0};
	private int[] chestCost = {10, 30, 50, 70, 90, 110, 130, 150, 170, 190, 210, 230, 250, 270, 290, 310, 330, 350, 370, 390, 410, 430, 450, 470, 490, 0};
	private int[] legsCost = {10, 30, 50, 70, 90, 110, 130, 150, 170, 190, 210, 230, 250, 270, 290, 310, 330, 350, 370, 390, 410, 430, 450, 470, 490, 0};
	public Text headText, handsText, chestText, legsText;
    public Text textHeadLevel, textHandsLevel, textChestLevel, textLegsLevel;
    private int maxLevel = 25;
    private statsPlayer statsPlayer;
	#endregion

	void Awake () {

        headLevel = PlayerPrefs.GetInt("headLevel");
        handsLevel = PlayerPrefs.GetInt("handsLevel");
        chestLevel = PlayerPrefs.GetInt("chestLevel");
        legsLevel = PlayerPrefs.GetInt("legsLevel");
        statsPlayer = GameObject.Find ("player").GetComponent<statsPlayer> ();
		
	}

    void Update() {
       
        //Mostra el nivell de cada part
        textHeadLevel.text = (int)headLevel + "";
        textHandsLevel.text = (int)handsLevel + "";
        textChestLevel.text = (int)chestLevel + "";
        textLegsLevel.text = (int)legsLevel + "";

        //Mostra el cost de cada part pel seu pròxim upgrade, si ha arribat al nivell màxim, el seu text es MAX
        if (headLevel < maxLevel) { headText.text = (int)headCost[headLevel] + ""; }
        else { headLevel = maxLevel; headText.text = "MAX"; }

        if (handsLevel < maxLevel) { handsText.text = (int)handsCost[handsLevel] + ""; }
        else { handsLevel = maxLevel; handsText.text = "MAX"; }

        if (chestLevel < maxLevel) { chestText.text = (int)chestCost[chestLevel] + ""; }
        else { chestLevel = maxLevel; chestText.text = "MAX"; }

        if (legsLevel < maxLevel) { legsText.text = (int)legsCost[legsLevel] + ""; }
        else { legsLevel = maxLevel; legsText.text = "MAX"; }

        updatePlayerPrefs();
        statsPlayer.maxHealth = 100 + (20 * chestLevel);
        statsPlayer.attack = 50 + (10 * handsLevel);

    }

	void spendEssence(float value){ //Funcio per restar l'essencia segons el valor passat. S'utilitza en les funcions upgrade pels botos quan fas upgrade.
		statsPlayer.essence -= value;
	}


	public void upgradeHead(){ 
        if (headLevel < maxLevel) { 
		    if (statsPlayer.essence >= chestCost[headLevel]) {
			    spendEssence(headCost[chestLevel]);
			    headLevel++; 
		    }
        }

    }

	public void upgradeHands(){
        if (handsLevel < maxLevel){
            if (statsPlayer.essence >= handsCost[handsLevel]){
                spendEssence(handsCost[handsLevel]);
                handsLevel++;
            }
        }
	}

	public void upgradeChest(){
        if (chestLevel < maxLevel){
            if (statsPlayer.essence >= chestCost[chestLevel]){
                spendEssence(chestCost[chestLevel]);
                chestLevel++;
            }
        }
	}

	public void upgradeLegs(){
        if (legsLevel < maxLevel){
            if (statsPlayer.essence >= legsCost[legsLevel]){
                spendEssence(legsCost[legsLevel]);
                legsLevel++;
            }
        }
	}

    public void updatePlayerPrefs(){
        PlayerPrefs.SetInt("headLevel", headLevel);
        PlayerPrefs.SetInt("handsLevel", handsLevel);
        PlayerPrefs.SetInt("legsLevel", legsLevel);
        PlayerPrefs.SetInt("chestLevel", chestLevel);
    }

}
