using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathGround : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player"){
			SceneManager.LoadScene("Game");
		}
		else if(other.gameObject.tag == "Untagged"){
			Destroy(other.gameObject);
		}		
	}
}
