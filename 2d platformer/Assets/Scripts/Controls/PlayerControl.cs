using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {

    //variables for player controls

    public float jumpforce = 100;   //controls jump height
    public float speed;             //variable for movement speed

    Rigidbody2D rigidbody2d; //variable to represent this gameobject's rigidbody2d
    Animator anim;           //variable to hold the animator component on the gameobject

    float horizontal;        //variable to hold the horizontal value: [-1, 0, 1]
    float vertical;          //variable to hold the vertical values: [-1, 0, 1]
    bool crouch;             //boolean to check for crouching in animation
    bool ground;
    bool falling;
 

	// Use this for initialization
	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        crouch = false;
        //anim = GetComponentInChildren<Animator>();
        
        
	}
	
	// Update is called once per frame
	void Update () {
        OnGroundCheck();
	}

    void FixedUpdate()
    {
        //Debug.Log(horizontal);
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 move1 = new Vector2(horizontal, 0); //creates new direction vector
        if (horizontal != 0)
        {
            rigidbody2d.AddForce (move1 * speed);
        }
        else 
        {
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (ground)
            {
                Vector2 jump = new Vector2(0, jumpforce);
                rigidbody2d.AddForce(jump);
            }
            
        }
        
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("Touching Ground");

        if (collider.gameObject.tag == "Ground")
        {
            ground = true;
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Ground")
        {
            ground = false;
        }
    }
    void OnGroundCheck()
    {
        if(!ground)
        {
            rigidbody2d.gravityScale = 5;
        }
        else
        {
            rigidbody2d.gravityScale = 1;
        }
    }
    
}
