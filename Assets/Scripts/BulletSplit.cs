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

    void OnEnable()
    {
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
        rb.velocity = transform.up * speed * Time.deltaTime * splitTime;
    }

    void bulletSplit()
    {
        splitTime -= Time.deltaTime;
        if (splitTime < 0)
        {
            for(int i = 0; i < firePoint.Length; i++)
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

    }

    void splitCheck()
    {
        if(split == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
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
