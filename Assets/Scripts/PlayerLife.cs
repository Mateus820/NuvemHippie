using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

	public int currentLife;
	public int maxLife;

	public Sprite[] lifeSprite;
	
	// Use this for initialization
	void Start () {
		currentLife = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
