using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour {


	#region Variables
	public GameObject pauseGO;
	public GameObject optionsPanel;
	public GameObject controlsPanel;
    public GameObject returnPanel;

    private GameObject capsule;
    private upgradeMenuControl upgradeMenuControl;
    private baseToPlay baseToPlay;
	#endregion

	#region Methods

    void Start(){
        capsule = GameObject.Find("Capsule");
        upgradeMenuControl = GameObject.Find("Capsule").GetComponent<upgradeMenuControl>();
        baseToPlay = GameObject.Find("invisibleWallToPlay").GetComponent<baseToPlay>();
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || controllerScript.StartButton() || controllerScript.BButton())
        {
            if (Time.timeScale == 1) {
                if (capsule != null) {
                    if (capsule.GetComponent<upgradeMenuControl>().upgradePanel.gameObject.activeInHierarchy)
                    {
                        capsule.GetComponent<upgradeMenuControl>().upgradePanel.SetActive(false);
                        capsule.GetComponent<upgradeMenuControl>().closeInfo();
                    }
                    else if (baseToPlay.enterPanel.gameObject.activeInHierarchy)
                    {
                        baseToPlay.enterPanel.SetActive(false);
                    }
                    else
                    {
                        pause();
                    }
                }

                else
                {
                    pause();
                } 
            }

			else if (Time.timeScale == 0 && pauseGO.gameObject.activeInHierarchy && controlsPanel.gameObject.activeInHierarchy){
				exitControls(); 
			}

            else if (Time.timeScale == 0 && pauseGO.gameObject.activeInHierarchy && optionsPanel.gameObject.activeInHierarchy){
                exitOptions(); 
            }

            else if (Time.timeScale == 0 && pauseGO.gameObject.activeInHierarchy && returnPanel.gameObject.activeInHierarchy)
            {
                exitReturn();
            }

            else if (Time.timeScale == 0 && pauseGO.gameObject.activeInHierarchy){
                resume(); 
            }

        }
    }

	public void pause() {

		if (!pauseGO.gameObject.activeInHierarchy) {
            pauseGO.gameObject.SetActive(true);
			Time.timeScale = 0;
		}

	}

	public void openMenu()
	{
		SceneManager.LoadScene("mainMenu");
	}

	public void resume() {
        pauseGO.gameObject.SetActive(false);
		optionsPanel.SetActive (false);
		Time.timeScale = 1;
	}

	public void enterOptions(){
		optionsPanel.SetActive(true);
	}

	public void exitOptions(){
		optionsPanel.SetActive (false);
	}

	public void enterControls(){
		controlsPanel.SetActive (true);
	}
    
    public void exitReturn()
    {
        returnPanel.SetActive(false);
    }
    public void enterReturn()
    {
        returnPanel.SetActive(true);
    }


    public void exitControls(){
		controlsPanel.SetActive (false);
	}


	#endregion
}
