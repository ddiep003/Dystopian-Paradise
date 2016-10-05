using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
    GameObject Player;
    public float Range = 30;
    public float Distance;
    float FiringAngle;
    public Transform FirePoint;
    public GameObject ProjectileFired;
    GameObject InstantiateProjectile;
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        FirePoint = transform.FindChild("Sprite");
        FirePoint = FirePoint.FindChild("FirePoint");

    }
	// Use this for initialization
	void Start () {
	
	}
    public float RateOfFire = 0; //0 = full automatic fire
    float timeToFire = 0; //otherwise 1 = 1 shot per second etc.
	// Update is called once per frame
	void Update () {
        
        if (Player != null )
        {
            Distance = Mathf.Abs(Player.transform.position.x - transform.position.x);
            if (Distance <= Range)
            {
                if (RateOfFire == 0)
                {
                    ShootPlayer();
                }
                else
                {
                    if (Time.time > timeToFire)
                    { //semi automatic
                        timeToFire = Time.time + 1 / RateOfFire;
                        ShootPlayer();
                    }
                }
            }
            
        }
        
    }

    void ShootPlayer()
    {
        Vector2 PlayerPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 firePointPosition = new Vector2(FirePoint.position.x, FirePoint.position.y);
        Vector2 firedirection = PlayerPosition - firePointPosition;

        //RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);

        FiringAngle = Mathf.Atan2(firedirection.y, firedirection.x) * Mathf.Rad2Deg;
        FirePoint.rotation = Quaternion.Euler(0, 0, FiringAngle);
        InstantiateProjectile = Instantiate(ProjectileFired, FirePoint.position, FirePoint.rotation) as GameObject;
    }
}
