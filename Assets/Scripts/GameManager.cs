using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public PlayerLife playerLife;
	private const string FILE_PATH = "saveGameData.dat";

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
		Load();
	}
	public void SaveGame()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Path.Combine(Application.streamingAssetsPath, FILE_PATH));

		SaveGameData save = new SaveGameData();
		save.lifes = playerLife.CurrentLife;
		save.points = 0;

		bf.Serialize(file, save);
		file.Close();

	}
	public void Load()
	{
		if (File.Exists(Path.Combine(Application.streamingAssetsPath, FILE_PATH))){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Path.Combine(Application.streamingAssetsPath, FILE_PATH), FileMode.Open);

			SaveGameData save = (SaveGameData) bf.Deserialize(file);

			file.Close();

			playerLife.CurrentLife = save.lifes;
		}
	}
	void OnApplicationQuit() {
		SaveGame();
	}
}
