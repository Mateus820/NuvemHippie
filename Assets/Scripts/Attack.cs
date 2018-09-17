using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {

	// Use this for initialization
	public GameObject attack;
	private IEnumerator dlay;
	[SerializeField]
	public bool attacking;

	void Start () {
		attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.C) && !attacking){
			Wait();
		}
	}

	void Wait(){
		dlay = AttackDlay(0.5f);
		StartCoroutine(dlay);
	}

	IEnumerator AttackDlay (float time){
		attacking = true;
		attack.SetActive (true);
        yield return new WaitForSeconds(time);
		attack.SetActive (false);
		yield return new WaitForSeconds(0.5f);
		attacking = false;
	}
}
