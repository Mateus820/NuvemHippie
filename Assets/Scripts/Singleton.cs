using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

	public static Singleton instance;
	public Player player;
	
	public static Singleton GetInstance
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
