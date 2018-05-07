using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class baseToPlay : MonoBehaviour
{

    public GameObject enterPanel;
    public GameObject pressButton;

    private soundManager soundManager;

    void Start()
    {
        soundManager = GameObject.Find("Sounds").GetComponent<soundManager>();
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) || controllerScript.YButton())
        {
            enterPanelController();
        }

        if (enterPanel.gameObject.activeInHierarchy == false)
        {
            pressButton.SetActive(true);
        }
        else pressButton.SetActive(false);
    }


    private void OnTriggerExit(Collider other)
    {
        pressButton.SetActive(false);
        enterPanel.SetActive(false);
    }

    void enterPanelController()
    {
        if (enterPanel.gameObject.activeInHierarchy == false)
        {
            enterPanel.SetActive(true);
            pressButton.SetActive(false);
        }
        else
        {
            closeMenu();
        }
    }

    public void closeMenu()
    {
        enterPanel.SetActive(false);
    }

    public void openGame()
    {

        soundManager.PortalSound();

        PlayerPrefs.SetFloat("essence", 0f);
        PlayerPrefs.SetFloat("power", 0f);

        int newRandom = Random.Range(0, 3);

        switch (newRandom)
        {
            case 0:
                SceneManager.LoadScene("Release");
                break;
            case 1:
                SceneManager.LoadScene("Release1");
                break;
            case 2:
                SceneManager.LoadScene("Release2");
                break;
            case 3:
                SceneManager.LoadScene("Release3");
                break;

        }



    }
}