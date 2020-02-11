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
        time2Shoot -= Time.deltaTime;
        if(time2Shoot < 0)
        {
            Shooting();
            time2Shoot = timer;
        }

    }
    void Shooting()
    {
        GameObject clone = (GameObject)Instantiate(pBullet, pBulletSpawn.position, pBulletSpawn.rotation) ;
    }
}
