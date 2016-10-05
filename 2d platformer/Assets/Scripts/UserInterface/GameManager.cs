using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
    public GameObject playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 2;

    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
        if(playerPrefab == null)
        {
            playerPrefab = GameObject.FindGameObjectWithTag("Player");
        }
    }
    
    //public Transform spawnPrefab;

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        //GameObject clone = Instantiate (spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        //Destroy (clone, 3f);
        //Debug.Log ("Todo: Add Spawn Particles");

    }
    // Update is called once per frame
    void Update () {
	    if(playerPrefab == null)
        {
            gm.StartCoroutine(gm.RespawnPlayer());
            playerPrefab = GameObject.FindGameObjectWithTag("Player");

        }
    }
}
