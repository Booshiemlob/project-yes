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

    void Start()
    {
        splitTime = Random.Range(0f, 2f);
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
                Instantiate(bullet, firePoint[i].position, firePoint[i].rotation);
                Debug.Log(i);
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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
        if (hitInfo.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
