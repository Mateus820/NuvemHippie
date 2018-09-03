using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour {

	public Button buttonContinue;

	void Start () {
		if (File.Exists(Path.Combine(Application.streamingAssetsPath, "saveGameData.dat"))){
			buttonContinue.interactable = true;
		}
		else{
			buttonContinue.interactable = false;
		}
	}
}
