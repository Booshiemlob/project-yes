using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    public GameObject pBullet;
    public Transform pBulletSpawn;
    public float timer;
    private float time2Shoot;
    void Start()
    {
        time2Shoot = timer;
    }

    // Update is called once per frame
    void Update()
    {
        //Reduces time in real life time.
        time2Shoot -= Time.deltaTime;
        //When the timer reaches/goes below zero calls the shoot function
        if (time2Shoot < 0)
        {
            Shooting();
            time2Shoot = timer;
        }

    }
    void Shooting()
    {
        //Gets an enemy that is inactive in the scene and spawns the player's fire point.
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Player Bullets");
        if (bullet != null)
        {
            bullet.transform.position = pBulletSpawn.transform.position;
            bullet.transform.rotation = pBulletSpawn.transform.rotation;
            bullet.SetActive(true);
        }
    }
}
