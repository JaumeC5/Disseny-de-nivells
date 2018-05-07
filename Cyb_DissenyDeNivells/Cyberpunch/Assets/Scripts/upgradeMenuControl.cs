using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class upgradeMenuControl : MonoBehaviour
{
	public GameObject upgradePanel;
	public GameObject pressButton;

	public GameObject infoPanel;
	public GameObject infoBg;

	private soundManager soundManager;

	void Start(){
		soundManager = GameObject.Find ("Sounds").GetComponent<soundManager> ();
	}

	void openInfo(){
		infoPanel.SetActive(true);
		infoBg.SetActive(true);

	}

	public void closeInfo(){
		infoPanel.SetActive(false);
		infoBg.SetActive(false);
	}

	public void infoPanelController()
	{
		if (infoPanel.gameObject.activeInHierarchy == false)
		{
			openInfo();
		}
		else { closeInfo(); }
	}

	void OnTriggerStay(Collider other)
	{
		if (Input.GetKeyDown(KeyCode.F) || controllerScript.YButton()) 
		{
			upgradeMenuController();
		}
		if (controllerScript.BackButton())
		{
			if (infoPanel.gameObject.activeInHierarchy == false)
			{
				openInfo();
			}
			else { closeInfo();  }
		}

		if (upgradePanel.gameObject.activeInHierarchy == false)
		{
			pressButton.SetActive(true);
		}
		else pressButton.SetActive(false);
	}

	private void OnTriggerExit(Collider other)
	{
		pressButton.SetActive(false);
		upgradePanel.SetActive(false);
		closeInfo();
	}

	void upgradeMenuController()
	{
		if (upgradePanel.gameObject.activeInHierarchy == false)
		{
			openMenu ();
		}
		else
		{
			closeMenu();
		}
	}
	public void openMenu(){
		upgradePanel.SetActive(true);
		pressButton.SetActive(false);
		soundManager.CapsuleSound();
	}

	public void closeMenu()
	{
		upgradePanel.SetActive(false);
        soundManager.CapsuleSoundPause();
	}
}
