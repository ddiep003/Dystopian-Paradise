using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public float max_Health = 100f;
	public float cur_Health = 0f;
	public GameObject healthBar;
	//https://www.youtube.com/watch?v=87R0PziLDJ0

	// Use this for initialization
	void Start ()
	{
		cur_Health = max_Health;
		//InvokeRepeating ("decreaseHealth", 1f, 1f);
	}

	//Instead of InvokeRepeating use Update

	// Update is called once per frame
	void Update () {
	
	}
	void decreaseHealth()
	{
		if (cur_Health > 1f) {
			cur_Health -= 2f;
		}
		float calc_Health = cur_Health / max_Health;	// if cur 80 / 100 = 0.8f
		SetHealthBar (calc_Health);
	}

	public void SetHealthBar(float myHealth)
	{
		//myHealth value 0 - 1
		healthBar.transform.localScale = new Vector3 (Mathf.Clamp(myHealth, 0f, 1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
        {
            cur_Health -= 10;
            float calc_Health = cur_Health / max_Health;    // if cur 80 / 100 = 0.8f
            SetHealthBar(calc_Health);
            if (cur_Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    //Use below function for normal use instead of decreaseHealth

    //void changehealth (int healthvalue)
    //{
    //if (cur_Health == healthvalue) {
    //return;
    //}
    //if (healthvalue > max_Health) {
    //cur_Health = max_Health;
    //} 
    //else if (healthvalue >= 0) {
    //cur_Health = healthvalue;
    //} 
    //else {
    //cur_Health = 0;
    //}
    //float calc_Health = cur_Health / max_Health;
    //SetHealthBar (calc_Health);
    //}	
}
