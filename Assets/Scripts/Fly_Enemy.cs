using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Enemy : MonoBehaviour {

	public Rigidbody2D rb;
	public Rigidbody2D targetRb;
	public Rigidbody2D homeRb;
	public float speed;
	public bool chase;
	void Start () {
		
	}
	void Update () {
		if(chase){
			rb.position = Vector3.MoveTowards(rb.position, targetRb.position, Mathf.Abs(speed) * Time.deltaTime);
		}
		else if(!chase && rb.position != homeRb.position){
			rb.position = Vector3.MoveTowards(rb.position, homeRb.position, Mathf.Abs(speed) * Time.deltaTime);
		}
	}
}
