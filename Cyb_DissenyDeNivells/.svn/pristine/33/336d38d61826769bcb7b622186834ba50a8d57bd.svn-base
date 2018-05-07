using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class resetPlayerPrefs : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.P))
        { //Reset PlayerPrefs
            GameObject.Find("player").GetComponent<statsPlayer>().essence = 0;
            GameObject.Find("player").GetComponent<statsPlayer>().maxHealth = 100;
            GameObject.Find("player").GetComponent<statsPlayer>().power = 0;
            GameObject.Find("player").GetComponent<statsPlayer>().attack = 70;
            GameObject.Find("gameController").GetComponent<upgradeMenu>().headLevel = 0;
            GameObject.Find("gameController").GetComponent<upgradeMenu>().handsLevel = 0;
            GameObject.Find("gameController").GetComponent<upgradeMenu>().chestLevel = 0;
            GameObject.Find("gameController").GetComponent<upgradeMenu>().legsLevel = 0;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("firstPhaseShow");
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("secondPhaseShow");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("bossShow");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene("BaseScene");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject.Find("player").GetComponent<statsPlayer>().essence += 100;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject.Find("player").GetComponent<statsPlayer>().power = 100;
        }
    }
}
