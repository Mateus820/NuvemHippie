using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false, configIsClose = true;
	public GameObject pauseMenuUI, configMenuUI, quitMenuUI;

	void Start() {
		gameIsPaused = false;
	}
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (gameIsPaused) {
				Resume ();
			} 
			else 
			{
				Pause ();
			}
		}
	}
	public void Resume()
	{
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}
	void Pause ()
	{
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}
	public void ResumeButton()
	{
		Resume();
	}

	public void ConfigButton()
	{
		configMenuUI.SetActive (true);
		pauseMenuUI.SetActive (false);
	}

	public void QuitButton()
	{
		quitMenuUI.SetActive (true);
		pauseMenuUI.SetActive (false);
	}

	//configMenu
	public void BackButton()
	{
		configMenuUI.SetActive (false);
		pauseMenuUI.SetActive (true);
	}

	//quitMenu
	public void YesButton() {
		SceneManager.LoadScene("StartMenu");
		Time.timeScale = 1f;
	}

	public void NoButton()
	{
		quitMenuUI.SetActive (false);
		pauseMenuUI.SetActive (true);
	}
}


