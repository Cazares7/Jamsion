using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject [] enemies;
    GameObject spawnee;
    

	// Use this for initialization
    
	void Start () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void Spawn()
    {
       
        
        int chosenSpawnee = Random.Range(0, enemies.Length);
        spawnee = enemies[chosenSpawnee];
        Instantiate(spawnee, transform.position, transform.rotation);
        
    }
}
