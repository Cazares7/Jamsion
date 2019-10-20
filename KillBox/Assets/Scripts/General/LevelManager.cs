using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject[] spawners;
    public DeathMenu dm;
    int totalSpawnedEnemies;
    int enemyIncrement = 3;
    int totalEnemiesKilled = 3;
    int enemiesKilledIncrement = 1;
    int currentEnemiesKilled;
    float spawnTimer = 5.0f;
	// Use this for initialization
	void Start () {
        totalSpawnedEnemies = 3;
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            spawnTimer = 5f;
            SpawnEnemies();
        }
	}
    
    public void ImproveStats()
    {
        totalSpawnedEnemies += enemyIncrement;
        totalEnemiesKilled += 1;
        currentEnemiesKilled = 0;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().ResetFOV();
    }
    void IncreaseEnemyKillCount()
    {
        currentEnemiesKilled++;
        if(currentEnemiesKilled >= totalEnemiesKilled)
        {
            GameObject.FindGameObjectWithTag("Stairway").GetComponent<Stairway>().ShowStairCase();
        }
    }

    void SpawnEnemies()
    {
        if (!dm.IsDeathMenuActive())
        {
            for (int i = 0; i < totalSpawnedEnemies; i++)
            {
                int chosenSpawner = Random.Range(0, spawners.Length);
                spawners[chosenSpawner].GetComponent<Spawner>().Spawn();
            }
        }
    }
}
