using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEarthDamage : MonoBehaviour {

	private PlayerLife playerLife;
	void Start () {
		playerLife = GameObject.FindGameObjectWithTag("PlayerLife").GetComponent<PlayerLife>();
	}
	void OnTriggerEnter2D(Collider2D other) {
		print("Coll");
		if(other.gameObject.tag == "Player"){
			playerLife.CurrentLife--;
		}	
	}
}
