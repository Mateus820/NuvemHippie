using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Enemy : MonoBehaviour {

	private Rigidbody2D rb;
	[SerializeField] private float velocidade;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate (){
		rb.velocity = new Vector2 (velocidade, rb.velocity.y);
	}
}
