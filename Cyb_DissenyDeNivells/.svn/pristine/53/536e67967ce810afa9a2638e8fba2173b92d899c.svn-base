using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthBar : MonoBehaviour {

    public Image currentHealthBar;
    public GameObject enemyBar;
    public Text ratioText;
    public float healthbarTimer;
    private float totalTime;
    public Text enemyText;
    public static string enemyName;
    public static float enemyLife;
    public static float enemyMaxLife;
    public static bool enemyHit;

    // Use this for initialization
    void Start () {
        enemyHit = false;
        enemyLife = 1;
        enemyMaxLife = 1;
    }
	
	// Update is called once per frame
	void Update () {

        currentHealthBar.rectTransform.localScale = new Vector3(enemyLife / enemyMaxLife, 1, 1);
        ratioText.text = (int)enemyLife + " / " + enemyMaxLife;
        enemyText.text = enemyName;
        totalTime += Time.deltaTime;

        if (enemyHit) {
            enemyBar.SetActive(true);
            totalTime = 0;
        }

        enemyHit = false;
        
        if (healthbarTimer < totalTime) {
            enemyBar.SetActive(false);
        }
    }

}
