using UnityEngine;
using System.Collections;

public class StatusBar : MonoBehaviour {

    Character ThisObject;
    float maxHP;
    float curHP;
    public GameObject healthBar;
    void Awake()
    {
        ThisObject = GetComponent<Character>();
        maxHP = ThisObject.health;
        curHP = maxHP;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        curHP = ThisObject.health;
        float calc_Health = curHP / maxHP;
        SetHealthBar(calc_Health);
	}
    public void SetHealthBar(float myHealth)
    {
        //myHealth value 0 - 1
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth, 0f, 1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
