using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGO;
    float maxSpawnRateInSecond = 5f;
    // Start is called before the first frame update 
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSecond);
        //increase spawn rate every 30 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //instantate an enemy
        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.y), max.y);

        //Schedule when to spawn next enemy
        ScheduleNextEnemySpawn();
    }
    void ScheduleNextEnemySpawn()
    {
        float spawnInNSecond;
        if (maxSpawnRateInSecond > 1f)
        {
            //pick a number between 1 and maxSpawnRateInSecond
            spawnInNSecond = Random.Range(1f, maxSpawnRateInSecond);
        }
        else
        {
            spawnInNSecond = 1f;
        }
        Invoke("SpawnEnemy", spawnInNSecond);    
    //function to increase the difficulty of the game 
    void IncreaseSpawnRate()
        {
            if(maxSpawnRateInSecond > 1f)
            {
                maxSpawnRateInSecond--;
            }
            if(maxSpawnRateInSecond == 1f)
            {
                CancelInvoke("IncreaseSpawnRate");
            }
        }
    }
}
