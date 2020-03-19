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
    public bool MilanCheck;
    public scoreTracker1 scores;
    public Story storyCheck;




    void Start()
    {
        //Finds the score script that is attached to the object "score1".
        scores = GameObject.Find("score1").GetComponent<scoreTracker1>();
        storyCheck = GameObject.Find("story").GetComponent<Story>();
        currentSpawnTime = spawnTimer;
    }


    void LateUpdate()
    {
        CheckSpawning();

    }

    void MilanSpawn()
    {
        //Spawns MilanHead when the score reaches 212.
        if (scores.score2 >= 212 && MilanCheck == false)
        {
            Instantiate(MilanBoss, spawnPoints[2].position, spawnPoints[2].rotation);
            MilanCheck = true;
        }
    }
    
    void CheckSpawning ()
    {
        //Reduces the time in real life time.
        currentSpawnTime -= Time.deltaTime;
        //When the timer reaches/goes below zero calls the spawnEnemy function.
        if (currentSpawnTime <= 0)
        {
            storyPause();
        }
    }

    void spawnEnemy()
    {
        //Chooses a random spawn location
        randSpawn = Random.Range(0, spawnPoints.Length);
        //Gets an enemy that is inactive in the scene and spawns it at the random location decides earlier.
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Enemy");
        if (bullet != null)
        {
            bullet.transform.position = spawnPoints[randSpawn].transform.position;
            bullet.transform.rotation = spawnPoints[randSpawn].transform.rotation;
            bullet.SetActive(true);
        }
        currentSpawnTime = spawnTimer;
    }

    void storyPause()
    {
        if(storyCheck.softPause == false)
        {
            spawnEnemy();
            MilanSpawn();
        }
        else
        {
            return;
        }
    }
}
