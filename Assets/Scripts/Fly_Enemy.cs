using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Enemy : MonoBehaviour {

	public Rigidbody2D rb;
	public Rigidbody2D targetRb;
	public float speed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rb.position = Vector3.MoveTowards(rb.position, targetRb.position, Mathf.Abs(speed) * Time.deltaTime);
	}
}
