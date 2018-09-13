using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	// Use this for initialization
	public GameObject atack;
	private IEnumerator dlay;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.C)){
			Wait();
		}
	}

	void Wait(){
		dlay = AtackDlay(0.5f);
		StartCoroutine(dlay);
	}

	IEnumerator AtackDlay (float time){
		atack.SetActive (true);
        yield return new WaitForSeconds(time);
		atack.SetActive (false);
	}
}
