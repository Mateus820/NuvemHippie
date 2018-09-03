using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour {
	
	//Mode = 0 Start a new game;
	//Mode = 1 Continue the save game;
	public void SetMode(int mode) {
		PlayerPrefs.SetInt("Mode", mode);
	}
}
