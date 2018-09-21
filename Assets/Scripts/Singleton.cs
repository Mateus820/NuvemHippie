using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

	public static Singleton instance;
	public Player player;
	void Awake() {
		if(instance == null){
			instance = this;
		}
		else if(instance != this){
			Destroy(this.gameObject);
		}
	}
	public static Singleton Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<Singleton>();
			}
			return instance;
		}
	}
}
