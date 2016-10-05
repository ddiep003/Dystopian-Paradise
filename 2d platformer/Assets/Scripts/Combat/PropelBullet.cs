using System.Collections;
using UnityEngine;

/*This Script Causes the spawned projectile to travel in the direction towards the mouse cursor*/



public class PropelBullet : MonoBehaviour {

    // Use this for initialization
    GameObject Player;

    public int bulletspeeds;
    public float lifetime = 2.0f;
    public float damage = 40;
    Collider2D bulletcollider;
    Rigidbody2D bullet;
    public string identifier = "Enemy"; //identifier is a tag of a gameobject
    public bool TravelToMouse = true;
    public Vector2 fdirection;
    void Awake()
    {
        bullet= GetComponent<Rigidbody2D>();
        bulletcollider = GetComponent<Collider2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        

    }
    void Start () {
        //if(TravelToMouse == true)
        //{
        //    Travel2Mouse();
        //}
        //else
        //{
        //    TravelToPlayer();
        //}
        bullet.AddForce(fdirection * bulletspeeds);
    }
    /*
    void Travel2Mouse()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 currentpos = this.transform.position;
        Vector2 Direction = mousePosition - currentpos;
        Direction.Normalize();
        bullet.velocity = Direction * bulletspeeds; 
    }
    void TravelToPlayer()
    {
        Vector2 PlayerPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 currentpos = this.transform.position;
        Vector2 Direction = PlayerPosition - currentpos;
        Direction.Normalize();
        bullet.velocity = Direction * bulletspeeds;
    }
    */
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitbox)
    {
        if (hitbox.tag == identifier)
        {
            Character enemy = hitbox.GetComponent<Character>();
            if(enemy != null)
            {
                enemy.ApplyDamage(damage);
                Destroy(gameObject);

            }
        }
        Debug.Log("Bullet hit target");
    }

    void Update () {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
	}
}
