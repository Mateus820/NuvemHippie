using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	private bool fileExist;
	[SerializeField] private string sceneNamePlay;
	public Button buttonContinue;
	public GameObject mainMenu;
	public GameObject playConfirmMenu;

	public void Play(){
		if(fileExist){
			mainMenu.SetActive(false);
			playConfirmMenu.SetActive(true);
		}
		else{
			SceneManager.LoadScene(sceneNamePlay);
		}
	}
	public void ChoiceNot(){
		playConfirmMenu.SetActive(false);
		mainMenu.SetActive(true);
	}

	public void Exit(){
		Application.Quit();
	}

	void Start () {

		mainMenu.SetActive(true);
		playConfirmMenu.SetActive(false);

		if (File.Exists(Path.Combine(Application.streamingAssetsPath, "saveGameData.dat"))){
			buttonContinue.interactable = true;
			fileExist = true;
		}
		else{
			buttonContinue.interactable = false;
			fileExist = false;
		}
	}
}
