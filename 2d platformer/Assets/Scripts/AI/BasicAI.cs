using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {

    public bool AI_is_on = true;
    public float RightMoveTime = 5;
    public float LeftMoveTime = 5;
    public float SightRange = 30;   //How far the enemy can detect the player
    float resettime;
    public float jumpforce = 100;   //controls jump height
    public float speed = 30;             //variable for movement speed
    Transform detection;
    Rigidbody2D RBody; //variable to represent this gameobject's rigidbody2d
    // Use this for initialization
    void Start () {
        RBody = GetComponent<Rigidbody2D>();
        resettime = LeftMoveTime;
        detection = transform.FindChild("Detection");
	}

    // Update is called once per frame
	void Update () {
        FindPlayer();
        if(AI_is_on == true)
        {
            RBody.AddForce(Vector2.left * speed);
        }
	}

    public bool FindPlayer()
    {
        Vector2 fwd = detection.TransformDirection(Vector2.left);
        Debug.DrawRay(detection.position, fwd * SightRange, Color.green); //Draws a line as long as the sight range
        RaycastHit2D detection2 = Physics2D.Raycast(detection.position, fwd, SightRange); 
        if (detection2.collider != null)
        {
            Character enemy = detection2.collider.GetComponent<Character>();
            if (enemy != null)
            {
                if (enemy.identifier == "Player")
                {
                    Debug.Log("Player sighted");
                    return true;
                }
                else
                {
                    Debug.Log("There is something here.");
                    return false;
                }
            }
            else
            {
                Debug.Log("Not Character Object");
            }
            

        }
        return false;
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        //m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        //Vector3 theScale = playerGraphics.localScale;
        //theScale.x *= -1;
        //playerGraphics.localScale = theScale;
    }

}
