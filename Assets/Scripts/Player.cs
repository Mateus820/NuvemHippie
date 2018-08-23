using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speedQuantity = 3f;
    private Rigidbody2D bori;
    public bool grounded;
    public Vector2 jumpVector;
    public Transform grounder;
    public float radius;
    public LayerMask ground;


    void Start () {
        bori = GetComponent<Rigidbody2D>();
    }
    
    
    void Update () {
        
        if(Input.GetKey(KeyCode.A))
        {
            bori.velocity = new Vector2(-speedQuantity, bori.velocity.y);
            transform.localScale = new Vector3 (-1,1,1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            bori.velocity = new Vector2(speedQuantity, bori.velocity.y);
            transform.localScale = new Vector3 (1,1,1);
        }
        else
        {
            bori.velocity = new Vector2(0, bori.velocity.y);
        }


        grounded = Physics2D.OverlapCircle(grounder.transform.position, radius, ground);

        if(Input.GetKey(KeyCode.W) && grounded == true)
        {
            bori.AddForce(jumpVector, ForceMode2D.Force);
        }
    }

}
