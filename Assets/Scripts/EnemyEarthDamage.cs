using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEarthDamage : MonoBehaviour {

	[SerializeField] private PlayerLife playerLife;

	void Start() {
		playerLife = Singleton.GetInstance.playerLife.GetComponent<PlayerLife>();
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			playerLife.CurrentLife--;
		}
		if(other.gameObject.tag == "Weapon"){
			EnemyLife en = GetComponent<EnemyLife>();
			en.currentLife--;

			var destroy = GetComponentInParent<Earth_Enemy2>();
			if(destroy != null)
				destroy.Destroy();
		}
	}
}
