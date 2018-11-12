using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour {

	public RawImage img;
	[SerializeField] private bool playerFollow;
	[SerializeField] private float speed;

	void Update () {
		if(playerFollow == true){
			float s;
			if((s = Singleton.GetInstance.player.Speed) == 0)
				return;
			Rect rect = img.uvRect;
			rect.x += speed * s;
			img.uvRect = rect;
		}
		else{
			Rect rect = img.uvRect;
			rect.x += speed;
			img.uvRect = rect;
		}
	}

}
