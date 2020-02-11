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
    public List<GameObject> enemy = new List<GameObject>();

    public Enemy_AI eAI;
    void Start()
    {
        spawnTime = spawnTimer;
    }


    void LateUpdate()
    {
        spawnEnemy();
    }

    void spawnEnemy()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime < 0)
        {
            randSpawn = Random.Range(0, 5);

            GameObject Clone = Instantiate(enemies[0], spawnPoints[randSpawn].position, spawnPoints[randSpawn].rotation);
            spawnTime = spawnTimer;
            enemy.Add(Clone.GetComponent<GameObject>());
        }

    }
}
