using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSplit : MonoBehaviour
{
    public float splitTime;
    public float speed = 15;
    public GameObject bullet;
    public Rigidbody2D rb;
    public Transform[] firePoint;
    public bool split;
    public bool milanFactor;

    void OnEnable()
    {
        //Resets the bullet on active.
        //Chooses a random time to split.
        splitTime = Random.Range(0f, 2f);
        split = false;
    }
    void FixedUpdate()
    {
        bulletMove();
    }

    void Update()
    {
        bulletSplit();
        splitCheck();
    }

    void bulletMove()
    {
        //Constantly moves the bullet in one direction, slowing down as until it splits.
        rb.velocity = transform.up * speed * Time.deltaTime * splitTime;
    }

    void bulletSplit()
    {
        //When the splitTime reaches/goes below 0, spawns a bullet in each direction around the split bullet.
        splitTime -= Time.deltaTime;
        if (splitTime < 0)
        {
            if(milanFactor == false)
            {
                for (int i = 0; i < firePoint.Length; i++)
                {
                    GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Enemy Bullets 2");
                    if (bullet != null)
                    {
                        bullet.transform.position = firePoint[i].transform.position;
                        bullet.transform.rotation = firePoint[i].transform.rotation;
                        bullet.SetActive(true);
                    }
                    if (i == 7)
                    {
                        split = true;
                    }
                }
            }
            //Same thing but for the milanHead.
            if( milanFactor == true)
            {
                for (int i = 0; i < firePoint.Length; i++)
                {
                    GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("MilanHead Bullet");
                    if (bullet != null)
                    {
                        bullet.transform.position = firePoint[i].transform.position;
                        bullet.transform.rotation = firePoint[i].transform.rotation;
                        bullet.SetActive(true);
                    }
                    if (i == 7)
                    {
                        split = true;
                    }
                }
            }
        }

    }

    void splitCheck()
    {
        //Checks if it has split, if true sets it inactive.
        if(split == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //If the object has colliding with an object with the following tags, sets it inactive.
        if (hitInfo.CompareTag("Barrier"))
        {
            gameObject.SetActive(false);

        }
        if (hitInfo.CompareTag("Player"))
        {
            gameObject.SetActive(false);

        }
    }
}
