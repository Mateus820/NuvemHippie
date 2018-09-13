using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public PlayerLife playerLife;
	public Player player;
	public Rigidbody2D playerRb;
	public string FILE_PATH = "saveGameData.dat";

	void Awake() {
		if(instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if(instance != this){
			Destroy(gameObject);
		}
	}
	void Start() {
		playerRb = player.GetComponent<Rigidbody2D>();
		
		print(PlayerPrefs.GetInt("Mode"));

		if(PlayerPrefs.GetInt("Mode") == 0){
			SaveGame();
		}
		else if(PlayerPrefs.GetInt("Mode") == 1){
			LoadGame();
		}
	}
	public void SaveGame()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Path.Combine(Application.streamingAssetsPath, FILE_PATH));

		SaveGameData save = new SaveGameData();

		//Erro ao sair do Jogo;
		if(playerLife.CurrentLife <= 0){
			save.lifes = 3;
		}
		else{
			save.lifes = playerLife.CurrentLife;
		}
		save.points = 0;
		save.posx = playerRb.position.x;
		save.posy = playerRb.position.y;

		print(playerRb.position.x);
		print(playerRb.position.y);

		bf.Serialize(file, save);
		file.Close();

	}
	public void LoadGame()
	{
		if (File.Exists(Path.Combine(Application.streamingAssetsPath, FILE_PATH))){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Path.Combine(Application.streamingAssetsPath, FILE_PATH), FileMode.Open);

			SaveGameData save = (SaveGameData) bf.Deserialize(file);

			file.Close();

			playerLife.CurrentLife = save.lifes;
			Vector2 playerPosition = new Vector2(save.posx, save.posy);
			playerRb.position = playerPosition;
			print(playerPosition);
		}
	}
	void OnApplicationQuit() {
		SaveGame();
		print("Jogo Salvo");
	}
}
