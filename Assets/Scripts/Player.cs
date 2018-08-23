using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed;
	[SerializeField] private float speed;
    private Rigidbody2D rb;
    public bool onGround;
    public bool facingRight = true;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        speed = maxSpeed;
        speed *= 10;
    }
    void FixedUpdate() {
       Movement();
    }
    void Movement(){
         float i = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(i * speed * Time.deltaTime, rb.velocity.y);

        if(i > 0 && !facingRight){
            Flip();
        }
        else if(i < 0 && facingRight){
            Flip();
        }
    }
    void Flip(){
        facingRight = !facingRight;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
    }
    void Update () {

    }

}
