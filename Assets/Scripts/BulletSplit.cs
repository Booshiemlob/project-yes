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


    void Start()
    {
        splitTime -= Time.deltaTime;
        if (splitTime < 0)
        {
            bulletSplit();
            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }

    void bulletMove()
    {
        rb.velocity = transform.up * speed * Time.deltaTime * splitTime;
    }

    void bulletSplit()
    {
        Instantiate(Instantiate(bullet, firePoint[0].position, firePoint[0].rotation));
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
