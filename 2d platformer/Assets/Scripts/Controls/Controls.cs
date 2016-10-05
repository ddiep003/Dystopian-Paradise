using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	public float speed = 0; //speed of movement
	bool facingRight = true; //checks which direction sprite facing
	Transform playerGraphics; //references the Sprite child
	public LayerMask whatisGround; //Layers check where is ground
	public float jump = 0; //jump force higher value = higher jump
	bool grounded = false; //checks if object is on the ground
	// Use this for initialization

	void Start () {
		playerGraphics = transform.FindChild ("Sprites"); //finds Sprite object attached to parent
	}

	void FixedUpdate() //Update4s every other frame
	{
		//Gets input from horizontal buttons
		//if (Input.GetAxis ("Horizontal") != 0) {
		//	float move = Input.GetAxis ("Horizontal");
		//	GetComponent<Rigidbody2D> ().AddForce (new Vector2(speed * move , 0));
		//}
		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
		if (Input.GetAxisRaw("Horizontal") < 0)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}

		//float move2 = Input.GetAxis("Horizontal");
		//GetComponent<Rigidbody2D>().velocity = new Vector2(move2 * speed, 0);
	}

	// Update is called once per frame
	void Update () {
		if (grounded && Input.GetKey (KeyCode.Space)) { // if on the ground and space is pressed down
			grounded = false;	//no longer considered to be on the ground
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jump)); // Makes sprite jump
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "ground") {	//if the collider is touching the ground
			grounded = true;	//object is considered to be on the ground
			Debug.Log ("touching ground!");	//outputs message into console
		}
	}
}
