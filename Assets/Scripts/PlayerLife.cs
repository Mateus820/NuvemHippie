using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {

	public int CurrentLife;
	public int maxLife;
    public Image life_Hud;

	public Sprite[] lifeSprite;
	
	void Start () {
		CurrentLife = maxLife;
        GameManager.instance.playerLife = this;
	}
	void Update () {
        if(CurrentLife >= 0 && CurrentLife <= maxLife){
            life_Hud.sprite = lifeSprite[CurrentLife];
        }
        else{
            print("Erro: Vida atual maior que o Index");
        }

        if(CurrentLife > maxLife){
            CurrentLife = maxLife;
        }
        else if(CurrentLife <= 0){
            GameManager.instance.SaveGame();
            SceneManager.LoadScene("GameOver");
        }
	}
}
