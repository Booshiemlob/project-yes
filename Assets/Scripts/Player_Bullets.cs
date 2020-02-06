using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullets : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 15;
    public float timer = 3f;
    public GameObject bullet;


    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(this);
        }
    }

    void FixedUpdate()
    {
        //Constantly add velocity to move up.
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Barrier"))
        {
            Destroy(bullet);
        }
    }
}
