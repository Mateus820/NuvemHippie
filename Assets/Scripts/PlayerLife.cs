using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {

	public int currentLife;
	public int maxLife;
    public Image life_Hud;

	public Sprite[] lifeSprite;
	
	void Start () {
		currentLife = maxLife;
	}
	void Update () {
        switch (currentLife)
        {
            case 0:
                life_Hud.sprite = lifeSprite[0];
                break;
            case 1:
                life_Hud.sprite = lifeSprite[1];
                break;
            case 2:
                life_Hud.sprite = lifeSprite[2];
                break;
            case 3:
                life_Hud.sprite = lifeSprite[3];
                break;
            default:
                life_Hud.sprite = lifeSprite[0];
                break;
        }
	}
}
