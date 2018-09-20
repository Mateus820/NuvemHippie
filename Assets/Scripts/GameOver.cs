using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public PlayerLife playerLife;

	void Start () {
		playerLife.CurrentLife = playerLife.maxLife;
		GameManager.instance.SaveGame();
	}
}
