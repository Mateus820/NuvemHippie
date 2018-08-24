using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public PlayerLife playerlife;
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
	void Start () {
		
	}
	void Update () {
	
	}
	public void SaveGame()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Path.Combine(Application.streamingAssetsPath, FILE_PATH));

		saveGameData save = new saveGameData();
		save.lifes = playerlife.currentLife;
		save.points = 0;

		bf.Serialize(file, save);
		file.Close();

	}
		public void Load()
		{
			if (File.Exists())
		}

}

[Serizable]
class saveGameData
{
	public int lifes;
	public int points;

}
