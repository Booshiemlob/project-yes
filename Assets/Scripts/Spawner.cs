using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnTimer = 0.5f;
    private float currentSpawnTime;
    public int randSpawn;
    public GameObject MilanBoss;

    public scoreTracker1 scores;


    void Start()
    {
        scores = GameObject.Find("score1").GetComponent<scoreTracker1>();
        currentSpawnTime = spawnTimer;
    }


    void LateUpdate()
    {
        CheckSpawning();
        MilanCheck();
    }

    void MilanCheck()
    {
        if (scores.score2 > 212)
        {
            Instantiate(MilanBoss, spawnPoints[2].position, spawnPoints[2].rotation);
        }
    }

    void CheckSpawning ()
    {
        currentSpawnTime -= Time.deltaTime;

        if (currentSpawnTime <= 0)
        {
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        randSpawn = Random.Range(0, spawnPoints.Length);
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Enemy");
        if (bullet != null)
        {
            bullet.transform.position = spawnPoints[randSpawn].transform.position;
            bullet.transform.rotation = spawnPoints[randSpawn].transform.rotation;
            bullet.SetActive(true);
        }
        currentSpawnTime = spawnTimer;
    }
}
