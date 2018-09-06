using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Enemies : MonoBehaviour {

	public GameObject enemy; 
    public float timeSpawn; 
	public int enemiesSpawn; 
    public Transform spawnPoint;

    void Start () {
		StartCoroutine(ReapetingSpawn());
    }

    void Spawn()
    {
        Instantiate(enemy, spawnPoint.position, Quaternion.identity);
    }
	IEnumerator ReapetingSpawn(){

		for(int i = 0; i < enemiesSpawn; i++){
			Spawn();
			yield return new WaitForSeconds(timeSpawn);
		}
	}
}
