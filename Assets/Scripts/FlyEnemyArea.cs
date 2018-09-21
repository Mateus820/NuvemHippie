using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyArea : MonoBehaviour {

	public Fly_Enemy enemy;

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag == "Player"){
			enemy.chase = true;
		}
	}
	void OnTriggerExit2D(Collider2D coll) {
		if(coll.gameObject.tag == "Player"){
			enemy.chase = false;
		}
	}
}
