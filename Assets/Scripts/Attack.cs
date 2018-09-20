using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	public float timeDelay;
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
		dlay = AttackDlay(timeDelay);
		StartCoroutine(dlay);
	}

	IEnumerator AttackDlay (float time){
		attacking = true;
		attack.SetActive (true);
        yield return new WaitForSeconds(time);
		attack.SetActive (false);
		yield return new WaitForSeconds(0.01f);
		attacking = false;
	}
}
