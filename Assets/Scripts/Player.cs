using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxSpeed;
	[SerializeField] private float speed;
    public Rigidbody2D rb;
    public bool onGround;
    public bool jump;
    public bool doubleJump;
    public bool facingRight = true;
    public bool canReceiveDamage = true;
    public float jumpForce;
    public float playerSpeed;  //allows us to be able to change speed in Unity
    public Vector2 jumpHeight;
    
    public Transform groundCheck;
    private PlayerLife playerLife;
    private IEnumerator damageDlay;
    public SpriteRenderer sprite;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        GameManager.instance.playerRb = rb;    
        GameManager.instance.player = this;
        speed = maxSpeed;
        speed *= 10;
        sprite = GetComponentInParent<SpriteRenderer>();
        playerLife = GameObject.FindGameObjectWithTag("PlayerLife").GetComponent<PlayerLife>();
        if(PlayerPrefs.GetInt("Mode") == 1){
            GameManager.instance.LoadGame();
        }
    }
    void FixedUpdate() {
       Movement();
       onGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

       if(Input.GetKeyDown(KeyCode.Space) && onGround)         
            jump = true;


       if(jump)    
       {
           rb.velocity = Vector2.zero;
           rb.AddForce(Vector2.up * jumpForce);
           jump = false;
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
        transform.localScale = scale;
        }

    void Update ()
    {
        transform.Translate(playerSpeed * Time.deltaTime, 0f, 0f);  //makes player run

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(canReceiveDamage) {
		    /*print("Coll");
		    if(other.gameObject.tag == "Enemy"){
			    playerLife.CurrentLife--;
		    }
            */
        }
	}
    void DamageReceived() {
        damageDlay = DamageDlay();
        StartCoroutine (damageDlay);
    }
    IEnumerator DamageDlay() {
        canReceiveDamage = false;
        sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        canReceiveDamage = true;
    }
}
