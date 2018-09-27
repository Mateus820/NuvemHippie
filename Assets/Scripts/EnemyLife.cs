using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {

	public int currentLife;

	void Update() {
		if(currentLife < 1){
			Destroy(this.gameObject);
		}	
	}
}
