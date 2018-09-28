using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour {

	public RawImage img;
	[SerializeField] private float speed;

	void Update () {
		Rect rect = img.uvRect;
		rect.x += speed;
		img.uvRect = rect;
	}
}
