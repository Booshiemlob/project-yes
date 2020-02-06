using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    public GameObject pBullet;
    public Transform pBulletSpawn;
    public float timer = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Shooting();
            timer = 0.1f;
            Debug.Log("yes");
        }

    }
    void Shooting()
    {
        GameObject clone = (GameObject)Instantiate(pBullet, pBulletSpawn.position, pBulletSpawn.rotation) ;
    }
}
