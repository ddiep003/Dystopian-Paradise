using UnityEngine;
using System.Collections;

public class BasicAnimationController : MonoBehaviour {

    Animator Anime;
    BasicAI EnemyAI;
    

	// Use this for initialization
	void Start () {
        Anime = GetComponentInChildren<Animator>();
        EnemyAI = GetComponent<BasicAI>();
	}
	
	// Update is called once per frame
	void Update () {
        if(EnemyAI.FindPlayer() == true)
        {
            Anime.SetBool("Attack", true);
        }
        else
        {
            Anime.SetBool("Attack", false);
        }        
	}
}
