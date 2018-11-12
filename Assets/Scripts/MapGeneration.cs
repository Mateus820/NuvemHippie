﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

	public int levelNumber;
	[SerializeField] private GameObject pointPrefab;
	[SerializeField] private Transform points;
	public CameraFollow cameraFollow;
	public Level[] levels;
	public ColorTile[] colorTile;

	void Start () {
		cameraFollow.minCam = levels[levelNumber].cameraMin;
		cameraFollow.maxCam = levels[levelNumber].cameraMax;
		GenerateLevel();
	}
	
	void GenerateLevel(){
		for (int x = 0; x < levels[levelNumber].map.width; x++)
		{
			for (int y = 0; y < levels[levelNumber].map.height; y++)
			{
				GenerateTile(x, y);
			}
		}
	}
	void GenerateTile(int x, int y){
		
		Color pixelColor = levels[levelNumber].map.GetPixel(x, y);
		
		if(pixelColor.a == 0){
			//PointGenerator(x, y);
			return;
		}
		foreach (ColorTile tile in colorTile)
		{
			if(tile.color.Equals(pixelColor))
			{
				Vector2 position = new Vector2(x, y);
				Instantiate(tile.prefab, position, Quaternion.identity, transform);
			}
		}
	}

	void PointGenerator(int x, int y){
		foreach(ColorTile tile in colorTile){
			if(tile.canPoint){
				Vector2 position = new Vector2(x, y);
				Instantiate(pointPrefab, position, Quaternion.identity, points);
			}
		}
	}
}
