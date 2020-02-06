using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullets : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 3;
    public float timer = 5f;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
}
