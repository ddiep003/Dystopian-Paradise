using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    public GameObject spawnobject;
    GameObject instantbullet;
    public int bulletspeed = 50;
    public Transform firepoint;
    public LayerMask whatToHit;
    float angle;
    public KeyCode FireButton = KeyCode.Mouse0; //variavle that changes Keybinding
    public Transform direction;
    public float RateOfFire = 0;
    public float timeToFire;
    // Use this for initialization
    void Awake()
    {

        //bullet = transform.FindChild("Sprite");
        //bullet = bullet.FindChild("Arm");
        //bullet = bullet.FindChild("Firepoint");


 
  
    }

    void Start () {

	
	}
    public void Shoot()
    {
        //Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 directionVector = new Vector2(direction.position.x, direction.position.y);
        Vector2 firePointPosition = new Vector2(firepoint.position.x, firepoint.position.y);
        Vector2 firedirection = directionVector - firePointPosition;

        //RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);

        angle = Mathf.Atan2(firedirection.y, firedirection.x) * Mathf.Rad2Deg;
        firepoint.rotation = Quaternion.Euler(0, 0, angle);
        instantbullet = Instantiate(spawnobject, firepoint.position, firepoint.rotation) as GameObject;
        instantbullet.GetComponent<PropelBullet>().bulletspeeds = bulletspeed;
        instantbullet.GetComponent<PropelBullet>().fdirection = firedirection;
        //instantbullet.velocity = new Vector2(firedirection.x * bulletspeed, firedirection.y * bulletspeed);
        //Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(FireButton))
        {
            if (RateOfFire == 0)
            {
                Shoot();
            }
            else
            {
                if (Time.time > timeToFire)
                { //semi automatic
                    timeToFire = Time.time + 1 / RateOfFire;
                    Shoot();
                }
            }
        }
    }
}
