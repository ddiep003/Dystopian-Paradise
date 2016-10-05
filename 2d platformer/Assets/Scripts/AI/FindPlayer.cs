using UnityEngine;
using System.Collections;

public class FindPlayer : MonoBehaviour
{
    public float SightRange = 30;   //How far the enemy can detect the player
    Transform detection;

    // Use this for initialization
    void Start()
    {
        detection = transform;
    }

    // Update is called once per frame
    void Update()
    {
        FindObject();
    }
    public float x;
    public float y;
    public bool FindObject()
    {
        Vector2 fwd = detection.TransformDirection(new Vector2 (x,y));
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




}
