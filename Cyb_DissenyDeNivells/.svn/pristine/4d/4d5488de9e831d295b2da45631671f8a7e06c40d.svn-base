using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class powerBar : MonoBehaviour
{
    public Image currentPowerBar;
    public Text ratioText;
    private float power, maxPower;
    private statsPlayer statsPlayer;

    void Start(){
        statsPlayer = GameObject.Find("player").GetComponent<statsPlayer>();
    }

    void Update()
    {
        power = statsPlayer.power;
        maxPower = statsPlayer.maxPower;
        currentPowerBar.rectTransform.localScale = new Vector3(power / maxPower, 1, 1);
        ratioText.text = (int)power + " / " + maxPower;
    }
}
