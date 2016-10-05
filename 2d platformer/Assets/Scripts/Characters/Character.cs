using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public float health;
    public bool isDead;
    public string identifier; //identifier is a tag of a gameobject
    
    public Character()
    {
        health = 100;
        isDead = false;
    }
    void Awake()
    {
        identifier = gameObject.tag;

    }
    // Use this for initialization
    void Start () {
	
	}
	public void ApplyDamage(float damage)
    {
        health -= damage;
    }
    void Death()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
        Death();
	}
}
