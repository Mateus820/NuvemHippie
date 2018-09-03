using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed;
	[SerializeField] private float speed;
    private Rigidbody2D rb;
    public bool onGround;
    public bool Jump;
    public bool doubleJump;
    public bool facingRight = true;
    public float jumpForce;
    public float playerSpeed;  //allows us to be able to change speed in Unity
    public Vector2 jumpHeight;
    
    public Transform groundCheck;



    void Start () {
        rb = GetComponent<Rigidbody2D>();
        speed = maxSpeed;
        speed *= 10;
    }
    void FixedUpdate() {
       Movement();
       onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
       if(onGround)
            doubleJump = false;

       if(Input.GetKeyDown(KeyCode.Space) && (onGround || !doubleJump))         
            doubleJump = true;


       if(Jump)    
       {
           rb.velocity = Vector2.zero;
           rb.AddForce(Vector2.up * jumpForce);
           Jump = false;
       } 
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

    void Update ()
    {
        transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
    }
}
