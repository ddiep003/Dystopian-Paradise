using UnityEngine;
using System.Collections;

public class OnHitEffect : MonoBehaviour {

    // Use this for initialization
    float damage = 20;
    void OnTriggerEnter2D(Collider2D OnHit) {
        //Write what happens when the game object with a trigger collider does when it hits.
        if(OnHit.tag == "Player")
        {
            Character enemy = OnHit.GetComponent<Character>();
            if (enemy != null)
            {
                enemy.ApplyDamage(damage);

            }
        }
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}