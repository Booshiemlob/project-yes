using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemies;
    public float spawnTimer = 0.5f;
    private float currentSpawnTime;
    public int randSpawn;
 //   public List<GameObject> enemy = new List<GameObject>();

    void Start()
    {
        currentSpawnTime = spawnTimer;
    }


    void LateUpdate()
    {

        CheckSpawning();
    }

    void CheckSpawning ()
    {
        currentSpawnTime -= Time.deltaTime;

        if (currentSpawnTime <= 0)
        {
            spawnEnemy();
            Debug.Log("spawner help");
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
  //      enemy.Add(clone);
    }
}
