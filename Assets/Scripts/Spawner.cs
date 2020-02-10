using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public float spawnTimer = 0.5f;
    private float spawnTime;
    public int randSpawn;
    void Start()
    {
        spawnTime = spawnTimer;
    }


    void Update()
    {
        spawnEnemy();
    }

    void spawnEnemy()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime < 0)
        {
            randSpawn = Random.Range(0, 4);
            GameObject Clone = Instantiate(enemies[0], spawnPoints[randSpawn].position, spawnPoints[randSpawn].rotation);
            spawnTime = spawnTimer;
        }

    }
}
