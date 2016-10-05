using UnityEngine;
using System.Collections;

public class TankControl : MonoBehaviour {

    public float speed = 50;      //variable for movement speed
    Rigidbody2D RBody2D; //variable to represent this gameobject's rigidbody2d
    float horizontal;        //variable to hold the horizontal value: [-1, 0, 1]
    float vertical;          //variable to hold the vertical values: [-1, 0, 1]
    
    // Use this for initialization
    void Start () {
        RBody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector2 MoveDirection = new Vector2(horizontal, vertical);
        RBody2D.velocity = (MoveDirection * speed);
    }
}
