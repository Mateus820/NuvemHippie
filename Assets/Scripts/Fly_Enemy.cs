using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Enemy : MonoBehaviour {

	public Rigidbody2D rb;
	public Rigidbody2D targetRb;
	public Rigidbody2D homeRb;
	[SerializeField] private Transform playerTransform;
	[SerializeField] private bool lineCast;
	public float speed;
	public bool chase;

	void Start()
	{
		targetRb = Singleton.GetInstance.player.rb;
		playerTransform = Singleton.GetInstance.player.transform;
	}
	void Update () {
		if(chase){
			MoveTowards();
		}
		else if(!chase && rb.position != homeRb.position){
			BackHome();
		}
	}

	void MoveTowards(){
		lineCast = Physics.Linecast(transform.position, playerTransform.position);
		Debug.DrawLine(transform.position, playerTransform.position, Color.red);
		if(!lineCast){
			rb.position = Vector3.MoveTowards(rb.position, targetRb.position, Mathf.Abs(speed) * Time.deltaTime);
		}
	}

	void BackHome(){
		rb.position = Vector3.MoveTowards(rb.position, homeRb.position, Mathf.Abs(speed) * Time.deltaTime);
	}
}
