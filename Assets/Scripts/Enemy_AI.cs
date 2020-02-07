using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public float speed = 3f;
    public float timer = 1f;
    public float movePattern = 1f;
    public Rigidbody2D rb;

    void Start()
    {
        //Chooses a random movement pattern.
    }
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        movement1();
    }

    void movement1()
    {
        if(movePattern == 1f)
        {
            if(timer > 0)
            {
                rb.velocity = transform.up * speed;
            }
            else
            {
                movePattern = 1.1f;
                timer = 1;
                Debug.Log("Change 1");
            }
        }
        if(movePattern == 1.1f)
        {
            if (timer > 0)
            {
                rb.velocity = transform.right * speed;
            }
            if (timer < 0)
            {
                movePattern = 1.2f;
                timer = 3;
                Debug.Log("Change 2");
            }
        }
    }
}
